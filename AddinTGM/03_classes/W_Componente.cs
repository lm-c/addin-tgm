using LmCorbieUI;
using LmCorbieUI.Metodos;
using LmCorbieUI.Metodos.AtributosCustomizados;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AddinTGM {
  internal class W_Componente {
    [DisplayName("NOME")]
    [LarguraColunaGrid(80)]
    public string NomeComponente { get; set; }

    [LarguraColunaGrid(80)]
    [DisplayName("CÓDIGO")]
    [AlinhamentoColunaGrid(DataGridViewContentAlignment.MiddleCenter)]
    public string CodComponente { get; set; }

    [LarguraColunaGrid(350)]
    [DisplayName("DENOMINAÇÃO")]
    public string Denominacao { get; set; }

    [Browsable(false)]
    public string PathName { get; set; }

    [LarguraColunaGrid(80)]
    [DisplayName("QTD")]
    [AlinhamentoColunaGrid(DataGridViewContentAlignment.MiddleCenter)]
    public int Quantidade { get; set; }

    #region Metodos

    public static SortableBindingList<W_Componente> GetComponents() {
      var _listaFinal = new SortableBindingList<W_Componente>();

      try {
        SldWorks swApp = new SldWorks();
        var swModel = (ModelDoc2)swApp.ActiveDoc;
        ModelDocExtension swModelDocExt;

        ConfigurationManager swConfMgr;
        Configuration swConf;
        Component2 swRootComp;

        swModelDocExt = swModel.Extension;
        swConfMgr = swModel.ConfigurationManager;
        swConf = swConfMgr.ActiveConfiguration;
        swRootComp = swConf.GetRootComponent3(true);
        string valOut;
        string resolvedValOut;

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocASSEMBLY) {
          MsgBox.ShowWaitMessage("Lendo componentes da montagem...");

          // Inserir lista de material e pegar dados
          string templateGeral = $"{Application.StartupPath}\\01 - Addin TGM 4.0\\ListaExportacao.sldbomtbt";
          int BomTypeGeral = (int)swBomType_e.swBomType_PartsOnly;
          int NumberingType = (int)swNumberingType_e.swNumberingType_None;
          var swBOMAnnotationGeral = swModelDocExt.InsertBomTable3(templateGeral, 0, 1, BomTypeGeral, swConf.Name, false, NumberingType, DetailedCutList: false);
          PegaDadosListaGeral(swApp, swBOMAnnotationGeral, _listaFinal);
          ExcluirLista(swModel);
        } else {
          var componente = new W_Componente();
          string ptNm = swModel.GetPathName();

          componente.PathName = ptNm;
          componente.NomeComponente = Path.GetFileNameWithoutExtension(componente.PathName);

          CustomPropertyManager swCustPropMngr = swModelDocExt.get_CustomPropertyManager(swConf.Name);

          swCustPropMngr.Get2("Código Produto", out valOut, out resolvedValOut);
          componente.CodComponente = resolvedValOut;
          swCustPropMngr.Get2("Denominação", out valOut, out resolvedValOut);
          componente.Denominacao = resolvedValOut;

          componente.Quantidade = 1;

          bool isSheetMetal = IsSheetMetal(swApp, componente.PathName, fecharPeca: false);

          if (isSheetMetal)
            _listaFinal.Add(componente);
          else
            MsgBox.Show($"Comando apenas para Peças de Chapa Metálica", "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao pegar desenho\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return _listaFinal;
    }

    private static void PegaDadosListaGeral(SldWorks swApp, BomTableAnnotation swBOMAnnotation, SortableBindingList<W_Componente> listaComponentes) {
      try {
        string[] vModelPathNames = null;
        string strItemNumber = null;
        string strPartNumber = null;
        var swTableAnnotation = (TableAnnotation)swBOMAnnotation;

        int lStartRow = 1;

        if (!(swTableAnnotation.TitleVisible == false)) {
          lStartRow = 2;
        }

        var swBOMFeature = swBOMAnnotation.BomFeature;

        for (int i = lStartRow; i < swTableAnnotation.TotalRowCount; i++) {
          vModelPathNames = (string[])swBOMAnnotation.GetModelPathNames(i, out strItemNumber, out strPartNumber);

          if (vModelPathNames != null) {
            if (string.IsNullOrEmpty(swTableAnnotation.get_Text(i, 4)))
              continue;

            var componente = new W_Componente();
            string ptNm = vModelPathNames[0];

            componente.PathName = ptNm;
            componente.NomeComponente = Path.GetFileNameWithoutExtension(componente.PathName);

            if (!File.Exists(componente.PathName) || componente.PathName.ToUpper().Contains("BIBLIOTECA") || componente.PathName.ToUpper().Contains("ESQ"))
              continue;

            var qtd = Convert.ToInt32(swTableAnnotation.get_Text(i, 4));

            componente.CodComponente = swTableAnnotation.get_Text(i, 1).Trim();
            //W_Componente.CodProduto = swTableAnnotation.get_Text(i, 2).Trim();

            componente.Denominacao = swTableAnnotation.get_Text(i, 3);
            componente.Quantidade = qtd;

            bool isSheetMetal = IsSheetMetal(swApp, componente.PathName, fecharPeca: true);

            if (isSheetMetal)
              listaComponentes.Add(componente);
          }
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao pegar dados da Lista\n\n{ex.Message}", "Addin LM Projetos",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private static bool IsSheetMetal(SldWorks swApp, string partPath, bool fecharPeca) {
      ModelDoc2 swModel = (ModelDoc2)swApp.OpenDoc(partPath, (int)swDocumentTypes_e.swDocPART);
      if (swModel != null) {
        FeatureManager swFeatMgr = default(FeatureManager);
        swFeatMgr = swModel.FeatureManager;

        var swFeat = (Feature)swModel.FirstFeature();

        while (swFeat != null) {
          if (swFeat.GetTypeName2() == "SheetMetal") {
            if (fecharPeca)
              swApp.CloseDoc(partPath);
            return true;
          }
          swFeat = swFeat.GetNextFeature();
        }
        if (fecharPeca)
          swApp.CloseDoc(partPath);
      }
      return false;
    }

    public static void ExcluirLista(ModelDoc2 swModel) {
      try {
        Feature swFeat = (Feature)swModel.FirstFeature();

        while ((swFeat != null)) {
          Debug.Print(swFeat.Name + " [" + swFeat.GetTypeName2() + "]");

          if (swFeat.GetTypeName() == "TableFolder") {
            Feature swSubFeat = (Feature)swFeat.GetFirstSubFeature();

            if ((swSubFeat != null)) {
              Debug.Print("    " + swSubFeat.Name + " [" + swSubFeat.GetTypeName() + "]");
              bool boolstatus = swModel.Extension.SelectByID2(swSubFeat.Name, "BOMFEATURE", 0, 0, 0, false, 0, null, 0);
              swModel.EditDelete();
              break;
            }
          }
          swFeat = (Feature)swFeat.GetNextFeature();
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao Excluir Lista\n\n{ex.Message}", "Addin LM Projetos",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    #endregion
  }
}
