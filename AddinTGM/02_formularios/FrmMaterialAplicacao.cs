using LmCorbieUI;
using LmCorbieUI.LmForms;
using LmCorbieUI.Metodos;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AddinTGM {
  public partial class FrmMaterialAplicacao : LmChildForm {
    public SldWorks swApp = new SldWorks();
    ModelDoc2 swModel = default(ModelDoc2);
    ModelDocExtension swModelDocExt;
    CustomPropertyManager swCustPropMngr = default(CustomPropertyManager);

    string _montagemPrincipal = string.Empty;
    int _posAtualItemCorte = 0;
    Componente _componente = new Componente();
    SortableBindingList<W_Componente> _componentes = new SortableBindingList<W_Componente>();

    public FrmMaterialAplicacao() {
      InitializeComponent();

      _componentes = new SortableBindingList<W_Componente>();

      dgv.MontarGrid<W_Componente>();
    }

    private void FrmMaterialAplicacao_Load(object sender, EventArgs e) {
      InfoSetting.Carregar();
      ckbAddDenom.Checked = InfoSetting.AddTodosConfigs;
    }

    private void BtnCarrProcess_Click(object sender, EventArgs e) {
      try {
        swModel = (ModelDoc2)swApp.ActiveDoc;

        if (swApp.ActiveDoc == null) {
          MsgBox.Show($"Sem documentos abertos", "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Information);
          return;
        }

        if (swModel.GetType() != (int)swDocumentTypes_e.swDocDRAWING) {
          MateriaPrima.Carregar();

          _componentes = new SortableBindingList<W_Componente>();
          dgv.Grid.DataSource = _componentes;

          _montagemPrincipal = swModel.GetPathName().ToLower();

          _componentes = W_Componente.GetComponents();
          dgv.CarregarGrid(_componentes);

          //FormatarGrid();

        } else {
          MsgBox.Show($"Comando apenas para Peças e Montagens", "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao carregar componentes\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      } finally {
        MsgBox.CloseWaitMessage();
      }
    }

    private void BtnSalvar_Click(object sender, EventArgs e) {
      try {
        if (swApp.ActiveDoc == null) {
          MsgBox.Show($"Sem documentos abertos", "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Information);
          return;
        }
        PartDoc swPart = default(PartDoc);

        swModel = (ModelDoc2)swApp.ActiveDoc;
        swPart = (PartDoc)swModel;

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocPART) {
          var idMat = (int)txtMateriaPrima.SelectedValue;
          var mat = MateriaPrima.ListaMateriaPrima.FirstOrDefault(x => x.ID == idMat);
          if (mat != null) {

            Config.Carregar();
            FormatoFolha.Carregar();

            lblCodMat.Text = mat.ChapaID.ToString("000000000");
            lblDescMat.Text = mat.ChapaDesc;

            swModelDocExt = swModel.Extension;
            swCustPropMngr = swModelDocExt.get_CustomPropertyManager("");

            swCustPropMngr.Add3("Massa", (int)swCustomInfoType_e.swCustomInfoText, "\"SW-Mass\"", (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);

            if (swModel.GetType() == (int)swDocumentTypes_e.swDocPART) {
              swCustPropMngr.Add3("Material", (int)swCustomInfoType_e.swCustomInfoText, "\"SW-Material\"", (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);

              AdicionarDenominacaotodasConfiguracoes();

              if (_componente.itens_corte.Count > 0) {
                swModel = (ModelDoc2)swApp.ActiveDoc;

                var cutList = _componente.itens_corte[_posAtualItemCorte];
                cutList.codigo = mat.ChapaID;
                cutList.denominacao = mat.ChapaDesc;
                cutList.material = mat.MaterialDesc;

                swPart.SetMaterialPropertyName2(_componente.config_name, Config.model.LocalBaseDadosMat, mat.MaterialDesc);
                lblMaterial.Text = cutList.material;

                bool boolstatus = swModel.Extension.SelectByID2(cutList.nome_lista, "SUBWELDFOLDER", 0, 0, 0, false, 0, null, 0);

                SelectionMgr swSelMgr = (SelectionMgr)swModel.SelectionManager;
                Feature swFeat = (Feature)swSelMgr.GetSelectedObject6(1, 0);
                CustomPropertyManager swCustPropMngr = swFeat.CustomPropertyManager;

                if (cutList.tipo == TipoListaMaterial.Chapa) {
                  string nomePeca = Path.GetFileName(swModel.GetPathName());

                  swCustPropMngr.Add3("CÓDIGO MATERIAL", (int)swCustomInfoType_e.swCustomInfoText, cutList.codigo.ToString(), (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
                  swCustPropMngr.Add3("DESCRIÇÃO MATERIAL", (int)swCustomInfoType_e.swCustomInfoText, cutList.denominacao.ToString(), (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
                  swCustPropMngr.Add3("COMPRIMENTO", (int)swCustomInfoType_e.swCustomInfoText,
                      $"\"SW-Largura da Caixa delimitadora@@@{cutList.nome_lista}@{nomePeca}\" X \"SW-Comprimento da Caixa delimitadora@@@{cutList.nome_lista}@{nomePeca}\"",
                      (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
                }
              }
              lblMaterial.UseCustomColor =
              lblCodMat.UseCustomColor =
              lblDescMat.UseCustomColor = false;
            }
          }
        } else {
          MsgBox.Show("Propriedades de Material só pode ser aplicada em peça.",
          "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        swModel.Save();
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao salvar..\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnVoltar_Click(object sender, EventArgs e) {
      try {
        if (_componentes.Count == 0) {
          MsgBox.Show($"Favor Carregar Componentes primeiro", "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Information);
          return;
        }

        swModel = (ModelDoc2)swApp.ActiveDoc;

        if (dgv.Grid.CurrentRow.Index > 0)
          dgv.Grid.Rows[dgv.Grid.CurrentRow.Index - 1].Cells[1].Selected = true;
        else
          MsgBox.Show($"Você está no primeiro componente", "Addin LM Projetos",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao voltar peça\n\n{ex.Message}", "Addin LM Projetos",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnProximo_Click(object sender, EventArgs e) {
      try {
        if (_componentes.Count == 0) {
          MsgBox.Show($"Favor Carregar Componentes primeiro", "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Information);
          return;
        }

        swModel = (ModelDoc2)swApp.ActiveDoc;

        if (dgv.Grid.CurrentRow.Index + 1 < dgv.Grid.RowCount)
          dgv.Grid.Rows[dgv.Grid.CurrentRow.Index + 1].Cells[1].Selected = true;
        else
          MsgBox.Show($"Você já chegou no último componente", "Addin LM Projetos",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao avançar peça\n\n{ex.Message}", "Addin LM Projetos",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnClose_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void Dgv_RowIndexChanged(object sender, EventArgs e) {
      try {
        if (sender == null) return;

        lblPercDesenho.Text = $"Peça {dgv.Grid.CurrentRow.Index + 1} de {dgv.Grid.RowCount}";

        swModel = (ModelDoc2)swApp.ActiveDoc;

        if (swModel != null && swModel.GetPathName().ToLower() != _montagemPrincipal) {
          swModel.ShowNamedView("*Isométrica");
          swModel.ViewZoomtofit();

          swModel.Save();
          swApp.CloseDoc(swModel.GetPathName());
        }

        AtualizarComponente();
      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro ao atualizar dados Componente");
      }
    }

    private void AtualizarComponente() {
      try {
        lblPeso.Text = "0,000Kg";
        lblEspess.Text = "---";
        lblCodMat.Text = "---";
        lblDescMat.Text = "---";
        lblMaterial.Text = "---";

        txtMateriaPrima.CarregarComboBox(new List<Material>());
        txtMateriaPrima.Text = string.Empty;
        lblCodMat.UseCustomColor =
        lblDescMat.UseCustomColor =
        lblMaterial.UseCustomColor = false;
        var w_componente = dgv.Grid.CurrentRow.DataBoundItem as W_Componente;
        _componente = new Componente();
        _posAtualItemCorte = 0;

        Sw.swApp.OpenDoc6(w_componente.PathName, (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", 0, 0);

        swModel = (ModelDoc2)swApp.ActivateDoc2(Name: w_componente.PathName, Silent: false, Errors: 0);
        if (swModel == null)
          return;

        swModel.ClearSelection2(true);

        _componente = Componente.GetComponente(swModel);

        if (_componente.itens_corte.Count > 0) {
          AtualizarInformacoes();
        } else
          lblPeso.Text = _componente.massa + " kg";

      } catch (Exception ex) {
        MsgBox.Show($"Erro ao Atualizar Dados\n\n{ex.Message}", "Addin LM Projetos",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnUpDownDes_Click(object sender, EventArgs e) {
      try {
        if (swApp.ActiveDoc == null) {
          MsgBox.Show($"Sem documentos abertos", "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Information);
          return;
        }

        if (swModel.GetType() != (int)swDocumentTypes_e.swDocPART || _componente.itens_corte.Count == 0)
          return;

        if (_componente.itens_corte.Count > 0) {
          if (((Button)sender).Tag.ToString() == "Up")
            _posAtualItemCorte = _posAtualItemCorte < _componente.itens_corte.Count - 1 ? _posAtualItemCorte + 1 : 0;
          if (((Button)sender).Tag.ToString() == "Down")
            _posAtualItemCorte = _posAtualItemCorte > 0 ? _posAtualItemCorte - 1 : _componente.itens_corte.Count - 1;
        }

        AtualizarInformacoes();
      } catch (Exception ex) {
        MsgBox.Show($"Erro \n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void AtualizarInformacoes() {
      var espess = _componente.itens_corte[_posAtualItemCorte].cxd_espess;
      var codigo = _componente.itens_corte[_posAtualItemCorte].codigo;
      var tipo = _componente.itens_corte[_posAtualItemCorte].tipo;

      lblttLista.Text = "Lista: " + (_posAtualItemCorte + 1) + " de " + _componente.itens_corte.Count;
      lblListaCorte.Text = _componente.itens_corte[_posAtualItemCorte].nome_lista;
      lblPeso.Text = _componente.itens_corte[_posAtualItemCorte].massa + " kg";
      lblEspess.Text = espess + "x" +
          _componente.itens_corte[_posAtualItemCorte].cxd_larg + "x" +
          _componente.itens_corte[_posAtualItemCorte].cxd_compr;
      lblCodMat.Text = codigo.ToString("000000000");
      lblDescMat.Text = _componente.itens_corte[_posAtualItemCorte].denominacao;
      lblMaterial.Text = _componente.itens_corte[_posAtualItemCorte].material;

      txtDenominacao.Text = _componente.denominacao;

      if (tipo == TipoListaMaterial.Chapa) {
        var list = MateriaPrima.SelecionarParaComboBox(espess);
        txtMateriaPrima.CarregarComboBox(list);

        if (list.Count > 0) {
          var mat = list.FirstOrDefault(x => x.MaterialDesc == _componente.itens_corte[_posAtualItemCorte].material);
          if (mat != null) {
            txtMateriaPrima.SelectedValue = mat.ID;
            txtMateriaPrima.Text = mat.ChapaDesc;
          } else {
            mat = list.FirstOrDefault(x => x.ChapaID == codigo);
            if (mat != null) {
              txtMateriaPrima.SelectedValue = mat.ID;
              txtMateriaPrima.Text = mat.ChapaDesc;
            }
          }
        } else if (list.Count == 1) {
          txtMateriaPrima.SelectedValue = list[0].ID;
          txtMateriaPrima.Text = list[0].ChapaDesc;
        }

        var id = (int?)txtMateriaPrima.SelectedValue;
        var mat2 = list.FirstOrDefault(x => x.ChapaID == codigo);
        if (mat2 != null && mat2.ID != (int?)txtMateriaPrima.SelectedValue) {
          lblCodMat.UseCustomColor =
          lblDescMat.UseCustomColor = true;
        }
      }
    }

    private void TxtMateriaPrima_SelectedValueChanched(object sender, EventArgs e) {
      try {
        if (txtMateriaPrima.SelectedValue != null) {
          var id = (int)txtMateriaPrima.SelectedValue;
          var mat = MateriaPrima.ListaMateriaPrima.FirstOrDefault(x => x.ID == id);
          if (mat != null && _componente.itens_corte[_posAtualItemCorte] != null) {
            if (mat.MaterialDesc != _componente.itens_corte[_posAtualItemCorte].material) {
              lblMaterial.UseCustomColor = true;
            } else {
              lblMaterial.UseCustomColor = false;
            }
            if (mat.ChapaID != _componente.itens_corte[_posAtualItemCorte].codigo) {
              lblCodMat.UseCustomColor =
              lblDescMat.UseCustomColor = true;
            } else {
              lblCodMat.UseCustomColor =
              lblDescMat.UseCustomColor = false;
            }
            lblMaterial.Refresh();
            lblCodMat.Refresh();
            lblDescMat.Refresh();
          }
        }
      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro ");
      }
    }

    private void AdicionarDenominacaotodasConfiguracoes() {
      try {
        Configuration swConfig = default(Configuration);
        ConfigurationManager swConfMgr = default(ConfigurationManager);

        object[] configNameArr = null;
        string configName = null;
        bool status = false;
        int i = 0;
        int h = 0;

        swModel = (ModelDoc2)swApp.ActiveDoc;
        swConfMgr = swModel.ConfigurationManager;
        swModelDocExt = swModel.Extension;
        configNameArr = (object[])swModel.GetConfigurationNames();

        string filename = swModel.GetPathName();

        configName = swConfMgr.ActiveConfiguration.Name;
        string defConfig = configName;

        if (ckbAddDenom.Checked) {
          for (i = 0; i <= configNameArr.GetUpperBound(0); i++) {
            configName = (string)configNameArr[i];
            swConfig = (Configuration)swModel.GetConfigurationByName(configName);
            status = swModel.ShowConfiguration2(configName);

            swModelDocExt = swModel.Extension;
            swCustPropMngr = swModelDocExt.get_CustomPropertyManager(configName);

            swCustPropMngr.Add3("Denominação", (int)swCustomInfoType_e.swCustomInfoText, _componente.denominacao, (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);

          }
        } else {
          swModelDocExt = swModel.Extension;
          swCustPropMngr = swModelDocExt.get_CustomPropertyManager(defConfig);

          swCustPropMngr.Add3("Denominação", (int)swCustomInfoType_e.swCustomInfoText, _componente.denominacao, (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
        }
        status = swModel.ShowConfiguration2(defConfig);
        //Configuration swConfig = default(Configuration);
        //ConfigurationManager swConfMgr = default(ConfigurationManager);

        //object[] configNameArr = null;
        //object[] vPropNames;
        //string configName = null;
        //bool status = false;
        //int i = 0;
        //int h = 0;
        //int nNbrProps;
        //string valOut;
        //string resolvedValOut;

        //swModel = (ModelDoc2)swApp.ActiveDoc;
        //swConfMgr = (ConfigurationManager)swModel.ConfigurationManager;
        //swModelDocExt = swModel.Extension;
        //configNameArr = (object[])swModel.GetConfigurationNames();

        //string filename = swModel.GetPathName();

        //configName = (string)configNameArr[i];
        //string def = configName;

        //for (i = 0; i <= configNameArr.GetUpperBound(0); i++) {

        //  configName = (string)configNameArr[i];
        //  swConfig = (Configuration)swModel.GetConfigurationByName(configName);
        //  status = swModel.ShowConfiguration2(configName);

        //  swCustPropMngr = swConfig.CustomPropertyManager;
        //  nNbrProps = swCustPropMngr.Count;
        //  vPropNames = (object[])swCustPropMngr.GetNames();

        //  for (h = 0; h <= nNbrProps - 1; h++) {
        //    swCustPropMngr.Get2(vPropNames[h].ToString(), out valOut, out resolvedValOut);
        //    string vPrNm = Convert.ToString(vPropNames[h]);
        //    if (vPrNm.Contains("Denominação") || vPrNm.Contains("DENOMINAÇÃO")) {
        //      swCustPropMngr.Add3("Denominação", (int)swCustomInfoType_e.swCustomInfoText,
        //          txtDenominacao.Text, (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
        //    }
        //  }
        //}
        //status = swModel.ShowConfiguration2(def);
      } catch (Exception ex) {
        MessageBox.Show("Falha ao Atualizar Denominação: \n" + ex.Message);
      }
    }

    private void TxtDenominacao_Leave(object sender, EventArgs e) {
      if (_componente != null )
        _componente.denominacao = txtDenominacao.Text;
    }

    private void CkbAddDenom_CheckedChanged(object sender, EventArgs e) {
      InfoSetting.AddTodosConfigs = ckbAddDenom.Checked;
      InfoSetting.Salvar();
    }
  }
}
