using LmCorbieUI;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddinTGM {
  public class ProcessoFabricacao {
    [Browsable(false)]
    [DisplayName("ID")]
    public int IdProcesso { get; set; }

    [Browsable(false)]
    public string DescricaoTemp { get; set; } = string.Empty;

    [DisplayName("PROCESSO")]
    public string DescricaoProcesso { get; set; } = string.Empty;

    [DisplayName("CÓDIGO")]
    public string CodigoItem { get; set; } = string.Empty;

    [DisplayName("DENOMINAÇÃO")]
    public string DescricaoItem { get; set; } = string.Empty;

    //[DisplayName("ESPES.")]
    //public double EspessuraMaterial { get; set; } = 0;

    [DisplayName("QTD")]
    public int QtdItem { get; set; } = 0;

    //public List<string> DesenhosFilhos { get; set; }

    [Browsable(false)]
    public string NomeComponente { get; set; }

    [Browsable(false)]
    public string PathName { get; set; }

    #region Metodos

    public static List<ProcessoFabricacao> GetProcessoFabricacao() {
      var listaProcessoFabricacao = new List<ProcessoFabricacao>();

      try {
        SldWorks swApp = new SldWorks();
        var swModel = (ModelDoc2)swApp.ActiveDoc;

        ConfigurationManager swConfMgr;
        Configuration swConf;
        Component2 swRootComp;
        string pathName = swModel.GetPathName();

        swConfMgr = swModel.ConfigurationManager;
        swConf = swConfMgr.ActiveConfiguration;

        // PegarListaComponentes(swModel.Extension, swConf.Name);

        var processoFabricacao = new ProcessoFabricacao();
        if (PossuiProcesso(swModel, swConf.Name, processoFabricacao) == true) {
          processoFabricacao.DescricaoTemp = Path.GetFileNameWithoutExtension(pathName) + "?" + swConf.Name;

          var spl = processoFabricacao.DescricaoProcesso.Split('^');
          foreach (var p in spl) {
            var pSplit = p.Split('|');

            var codProc = pSplit[0];
            var descrProc = pSplit[1].Replace(@"/", "_");

            if (!string.IsNullOrEmpty(p.Trim()) && int.TryParse(codProc, out int idProc)) {
              //  var codigo = listaComponentes.Where(x => x.PathName == pathName.ToUpper()).FirstOrDefault()?.Codigo;
              listaProcessoFabricacao.Add(new ProcessoFabricacao {
                IdProcesso = idProc,
                DescricaoProcesso = descrProc,
                //  CodigoItem = codigo,
                DescricaoItem = processoFabricacao.DescricaoItem,
                DescricaoTemp = processoFabricacao.DescricaoTemp,
                QtdItem = processoFabricacao.QtdItem,
                PathName = pathName,
                NomeComponente = Path.GetFileNameWithoutExtension(pathName),
              });
            }
          }
        }
        swRootComp = swConf.GetRootComponent3(true);

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocASSEMBLY) {
          TraverseComponent(swModel, swRootComp, listaProcessoFabricacao, 1);
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao retornar Processo de Fabricacao\n\n{ex.Message}", "Addin LM Projetos",
          MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      listaProcessoFabricacao = listaProcessoFabricacao.OrderBy(x => x.IdProcesso).ToList();
      return listaProcessoFabricacao;
    }

    private static void TraverseComponent(ModelDoc2 swModel, Component2 swComp, List<ProcessoFabricacao> listaProcessoFabricacao, long nLevel) {
      string nameShort = "";
      try {
        object[] vChildComp;

        Component2 swChildComp;

        vChildComp = (object[])swComp.GetChildren();

        for (int i = 0; i < vChildComp.Length; i++) {
          swChildComp = (Component2)vChildComp[i];
          bool supress = swChildComp.IsSuppressed();
          bool exclude = swChildComp.ExcludeFromBOM;
          string refConfig = swChildComp.ReferencedConfiguration;
          var usaNomeConfig = swChildComp.UseNamedConfiguration;

          swModel = swChildComp.GetModelDoc2();
          if (swModel == null) continue;

          swModel.GetCustomInfoNames();
          string pathName = swModel.GetPathName();

          nameShort = Path.GetFileNameWithoutExtension(pathName);
          string nameLong = "";

          if (supress == false && exclude == false) {
            bool canAdd = true;

            ProcessoFabricacao processoFabricacao = new ProcessoFabricacao();

            if (PossuiProcesso(swModel, refConfig, processoFabricacao) == true) {
              nameLong = nameShort + "?" + refConfig;

              if (listaProcessoFabricacao.Any(x => x.DescricaoTemp == nameLong)) {
                var itemNaLista = listaProcessoFabricacao.Where(x => x.DescricaoTemp == nameLong).FirstOrDefault();
                itemNaLista.QtdItem += 1;
                canAdd = false;
              }

              processoFabricacao.DescricaoTemp = nameLong;

              if (canAdd == true) {
                var spl = processoFabricacao.DescricaoProcesso.Split('^');
                foreach (var p in spl) {
                  if (string.IsNullOrEmpty(p))
                    continue;

                  var pSplit = p.Split('|');

                  var codProc = pSplit[0];
                  var descrProc = $"{pSplit[0]} - {pSplit[1].Replace(@"/", "_")}";

                  if (!string.IsNullOrEmpty(p.Trim()) && int.TryParse(codProc, out int idProc)) {
                    //  var codigo = listaComponentes.Where(x => x.PathName == pathName.ToUpper()).FirstOrDefault()?.Codigo;
                    listaProcessoFabricacao.Add(new ProcessoFabricacao {
                      IdProcesso = idProc,
                      DescricaoProcesso = descrProc,
                      CodigoItem = processoFabricacao.CodigoItem,
                      DescricaoItem = processoFabricacao.DescricaoItem,
                      DescricaoTemp = processoFabricacao.DescricaoTemp,
                      QtdItem = processoFabricacao.QtdItem,
                      PathName = pathName,
                      NomeComponente = Path.GetFileNameWithoutExtension(pathName),
                      //EspessuraMaterial = processoFabricacao.EspessuraMaterial,
                    });
                  }
                }
              }

              //continue;
            }

            TraverseComponent(swModel, swChildComp, listaProcessoFabricacao, nLevel + 1);
          }
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao carregar componente. + [{nameShort}]\n\n{ex.Message}", "Addin LM Projetos",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private static bool PossuiProcesso(ModelDoc2 swModel, string activeConfig, ProcessoFabricacao processoFabricacao) {
      bool _return = false;

      try {
        ModelDocExtension swModelDocExt = default(ModelDocExtension);
        Configuration swConfig = default(Configuration);
        ConfigurationManager swConfMgr = default(ConfigurationManager);
        CustomPropertyManager swCustPropMngr = default(CustomPropertyManager);

        object[] configNameArr = null;
        object[] vPropNames;
        bool status = false;
        bool ehTerceiro = false;
        int nNbrProps;
        string valOut;
        string resolvedValOut;
        string codigoOperacao = "";
        string comp = "";
        string denom = "";

        swConfMgr = swModel.ConfigurationManager;
        swModelDocExt = swModel.Extension;
        configNameArr = (object[])swModel.GetConfigurationNames();

        swConfig = (Configuration)swModel.GetConfigurationByName(activeConfig);

        status = swModel.ShowConfiguration2(activeConfig);

        swCustPropMngr = swConfig.CustomPropertyManager;
        nNbrProps = swCustPropMngr.Count;
        vPropNames = (object[])swCustPropMngr.GetNames();

        swCustPropMngr.Get2("Denominação", out valOut, out resolvedValOut);
        denom = resolvedValOut;

        swCustPropMngr = swModelDocExt.get_CustomPropertyManager("");
        nNbrProps = swCustPropMngr.Count;
        vPropNames = (object[])swCustPropMngr.GetNames();

        string sValue, sResolvedvalue;

        if (vPropNames != null) {
          foreach (var name in vPropNames.Where(x => x.ToString().StartsWith("op-"))) {
            //string nm = Convert.ToString(name);
            //if (nm.Contains("op-"))
            //{
            swCustPropMngr.Get2((string)name, out sValue, out sResolvedvalue);
            var spl = sResolvedvalue.Split(';');
            var splName = name.ToString().Split('-');
            codigoOperacao += $"{spl[0]}|{splName[3]}^";
            //}
          }
        }

        swCustPropMngr.Get2("Terceiro", out valOut, out resolvedValOut);
        ehTerceiro = resolvedValOut == "Sim";

        if (denom == "") {
          swCustPropMngr.Get2("Denominação", out valOut, out resolvedValOut);
          denom = resolvedValOut;
        }

        if (swConfig.UseAlternateNameInBOM == true) {
          swConfig.UseAlternateNameInBOM = true;

          if (!string.IsNullOrEmpty(swConfig.AlternateName))
            comp = swConfig.AlternateName;
        } else {
          comp = Path.GetFileNameWithoutExtension(swModel.GetPathName());
        }

        if ((swModel.GetType() == (int)swDocumentTypes_e.swDocPART && !ehTerceiro) || (codigoOperacao == "" && ehTerceiro)) {
          var opTmp = codigoOperacao;
          codigoOperacao = GetOpFromCutList(swModel, processoFabricacao);
          if (codigoOperacao == "")
            codigoOperacao = opTmp;
        }


        if (codigoOperacao != "") {
          //var codigo = listaComponentes.Where(x => x.PathName == pathName.ToUpper()).FirstOrDefault()?.Codigo;
          _return = true;
          processoFabricacao.CodigoItem = comp;
          processoFabricacao.DescricaoProcesso = codigoOperacao;
          processoFabricacao.DescricaoItem = denom.Trim();
          processoFabricacao.QtdItem = 1;
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao verificar CheckList\n\n{ex.Message}", "Addin LM Projetos",
           MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      return _return;
    }

    private static string GetOpFromCutList(ModelDoc2 swModel, ProcessoFabricacao processoFabricacao) {
      string _return = string.Empty;
      bool boolstatus;

      try {
        FeatureManager swFeatMgr = default(FeatureManager);
        Feature swFeat = default(Feature);
        string FeatType = null;
        string FeatTypeName = null;
        int bodyCount = 0;

        BodyFolder swBodyFolder = default(BodyFolder);

        Feature[] featureArr = new Feature[3];

        swFeatMgr = swModel.FeatureManager;

        swFeat = (Feature)swModel.FirstFeature();


        while ((swFeat != null)) {
          FeatType = swFeat.Name;
          FeatTypeName = swFeat.GetTypeName2();


          if (FeatTypeName == "CutListFolder") {
            swBodyFolder = (BodyFolder)swFeat.GetSpecificFeature2();
            bodyCount = swBodyFolder.GetBodyCount();

            if (bodyCount > 0) {
              boolstatus = swModel.Extension.SelectByID2(FeatType, "SUBWELDFOLDER", 0, 0, 0, false, 0, null, 0);

              SelectionMgr swSelMgr = (SelectionMgr)swModel.SelectionManager;
              swFeat = (Feature)swSelMgr.GetSelectedObject6(1, 0);

              CustomPropertyManager swCustPropMngr = swFeat.CustomPropertyManager;

              object[] custPropNames = (object[])swCustPropMngr.GetNames();

              if (custPropNames != null) {
                string sValue, sResolvedvalue;

                swBodyFolder = (BodyFolder)swFeat.GetSpecificFeature2();
                boolstatus = swBodyFolder.SetAutomaticCutList(true);
                boolstatus = swBodyFolder.UpdateCutList();

                //swCustPropMngr.Get2("Espessura da Chapa metálica", out sValue, out sResolvedvalue);
                //if (!string.IsNullOrEmpty(sResolvedvalue))
                //    processoFabricacao.EspessuraMaterial = Convert.ToDouble(sResolvedvalue.Replace("Ø", "").Replace(".", ","));

                foreach (var name in custPropNames.Where(x => x.ToString().StartsWith("op-"))) {
                  //string nm = Convert.ToString(name);
                  //if (nm.Contains("op-"))
                  //{
                  swCustPropMngr.Get2((string)name, out sValue, out sResolvedvalue);
                  var spl = sResolvedvalue.Split(';');
                  var splName = name.ToString().Split('-');
                  _return += $"{spl[0]}|{splName[3]}^";
                  //}
                }
              }
            }
          }
          swFeat = (Feature)swFeat.GetNextFeature();
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao pegar lista corte\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      if (_return.EndsWith("^"))
        _return = _return.Substring(0, _return.Length - 1);

      return _return;
    }

    public static List<Z_Padrao> GetDescricaoProcesso(List<ProcessoFabricacao> listaProcessoFabricacao) {
      var _return = new List<Z_Padrao>();

      try {
        foreach (var processo in listaProcessoFabricacao) {
          if (!_return.Any(x => x.Descricao == processo.DescricaoProcesso))
            _return.Add(new Z_Padrao { Codigo = processo.IdProcesso, Descricao = processo.DescricaoProcesso });
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao retornar descrição volume\n\n{ex.Message}", "Addin LM Projetos",
           MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return _return;
    }

    #endregion
  }
}
