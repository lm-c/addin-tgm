﻿using LmCorbieUI;
using LmCorbieUI.Metodos.AtributosCustomizados;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AddinTGM {
  public class DrawExport {
    [NaoImprimirColunaNoGrid]
    public int IndexTree { get; set; }

    [DisplayName("Sel")]
    public bool Exportar { get; set; }

    [DisplayName("NOME")]
    public string NomeComponente { get; set; }

    [DisplayName("CÓDIGO")]
    public string CodComponente { get; set; }

    [Browsable(false)]
    public string CodProduto { get; set; }

    [DisplayName("DENOMINAÇÃO")]
    public string Denominacao { get; set; }

    [Browsable(false)]
    public string PathName { get; set; }

    [DisplayName("QTD")]
    public int Quantidade { get; set; }

    [Browsable(false)]
    public swDocumentTypes_e Tipo { get; set; }

    #region Metodos

    public static List<DrawExport> GetDrawing(string nomeListaPecas = "", bool gerarTodaHierarquia = false) {
      var _listaFinal = new List<DrawExport>();
      var _listaDraw = new List<DrawExport>();

      try {
        SldWorks swApp = new SldWorks();
        var swModel = (ModelDoc2)swApp.ActiveDoc;
        ModelDocExtension swModelDocExt;
        CustomPropertyManager swCustPropMngr = default(CustomPropertyManager);

        var PathNameDraw = swModel.GetPathName().ToUpper().Replace("SLDASM", "SLDDRW");
        var pastaProjeto = Path.GetDirectoryName(PathNameDraw);

        ConfigurationManager swConfMgr;
        Configuration swConf;
        Component2 swRootComp;

        swModelDocExt = swModel.Extension;
        swConfMgr = swModel.ConfigurationManager;
        swConf = swConfMgr.ActiveConfiguration;
        swRootComp = swConf.GetRootComponent3(true);

        DrawExport drawExport = new DrawExport();
        int indexTree = 1;

        if (File.Exists(PathNameDraw)) {

          var fileCapa = $"{Path.GetDirectoryName(PathNameDraw)}//{Path.GetFileNameWithoutExtension(PathNameDraw)} CAPA DO PROJETO.SLDDRW";
          //Directory.GetFiles(pastaProjeto).Where(x => x.ToUpper().Contains("CAPA DO PROJETO")).FirstOrDefault();

          if (File.Exists(fileCapa)) {
            _listaFinal.Add(new DrawExport {
              IndexTree = 0,
              Exportar = true,
              NomeComponente = Path.GetFileNameWithoutExtension(fileCapa),
              PathName = fileCapa,
              Denominacao = "CAPA DO PROJETO",
              CodComponente = "CAPA DO PROJETO",
              Tipo = swDocumentTypes_e.swDocASSEMBLY,
              Quantidade = 1,
            });
          }

          if (!string.IsNullOrEmpty(nomeListaPecas)) {
            if (File.Exists(nomeListaPecas)) {
              _listaFinal.Add(new DrawExport {
                IndexTree = 0,
                Exportar = true,
                NomeComponente = Path.GetFileNameWithoutExtension(nomeListaPecas),
                PathName = nomeListaPecas,
                Denominacao = "LISTA DE PECAS",
                CodComponente = "LISTA DE PECAS",
                Tipo = swDocumentTypes_e.swDocLAYOUT,
                Quantidade = 1,
              });
            }
          }

          drawExport.IndexTree = indexTree;
          drawExport.Exportar = true;
          drawExport.PathName = PathNameDraw;
          drawExport.NomeComponente = Path.GetFileNameWithoutExtension(PathNameDraw);
          //drawExport.CodComponente = "000 - " + DadosArtama.GetShortName(PathNameDraw); 

          string valOut;
          string resolvedValOut;

          swCustPropMngr = swModelDocExt.get_CustomPropertyManager("");
          swCustPropMngr.Get2("Denominação", out valOut, out resolvedValOut);
          drawExport.Denominacao = resolvedValOut;
          swCustPropMngr.Get2("CÓDIGO PROJETO", out valOut, out resolvedValOut);
          drawExport.CodComponente = RetornaCodigoPrincipal(swModel, swModelDocExt, swCustPropMngr);
          swCustPropMngr.Get2("Código Produto", out valOut, out resolvedValOut);
          drawExport.CodProduto = resolvedValOut;
          drawExport.Tipo = swDocumentTypes_e.swDocASSEMBLY;
          drawExport.Quantidade = 1;

          if (string.IsNullOrEmpty(drawExport.CodProduto)) {
            swCustPropMngr = swConf.CustomPropertyManager;
            swCustPropMngr.Get2("Código Produto", out valOut, out resolvedValOut);
            drawExport.CodProduto = resolvedValOut;
          }

          _listaFinal.Add(drawExport);
        }

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocASSEMBLY) {
          // Inserir lista de material e pegar dados
          string templateGeral = $"{Application.StartupPath}\\01 - Addin TGM 4.0\\ListaExportacao.sldbomtbt";
          int BomTypeGeral = (int)swBomType_e.swBomType_Indented;
          int NumberingType = (int)swNumberingType_e.swNumberingType_Detailed;
          var swBOMAnnotationGeral = swModelDocExt.InsertBomTable3(templateGeral, 0, 1, BomTypeGeral, swConf.Name, false, NumberingType, DetailedCutList: false);
          PegaDadosListaGeral(swBOMAnnotationGeral, _listaDraw, indexTree, gerarTodaHierarquia);
          ExcluirLista(swModel);
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao pegar desenho\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      if (!gerarTodaHierarquia)
        _listaDraw = _listaDraw.OrderBy(x => x.NomeComponente).ToList();

      _listaDraw.ForEach(x => { _listaFinal.Add(x); });

      return _listaFinal;
    }

    private static void PegaDadosListaGeral(BomTableAnnotation swBOMAnnotation, List<DrawExport> listaDraw, int indexTree, bool gerarTodaHierarquia) {
      string nameShort = "";
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

            var drawExport = new DrawExport();
            string ptNm = vModelPathNames[0];

            drawExport.PathName = ptNm.Substring(0, ptNm.Length - 6) + "SLDDRW";
            drawExport.NomeComponente = Path.GetFileNameWithoutExtension(drawExport.PathName);

            if (!File.Exists(drawExport.PathName))
              continue;

            var qtd = Convert.ToInt32(swTableAnnotation.get_Text(i, 4));

            drawExport.CodComponente = swTableAnnotation.get_Text(i, 1).Trim();
            drawExport.CodProduto = swTableAnnotation.get_Text(i, 2).Trim();

            if (!gerarTodaHierarquia && listaDraw.Any(x => x.CodComponente == drawExport.CodComponente)) {
              var item = listaDraw.Where(x => x.CodComponente == drawExport.CodComponente).FirstOrDefault();
              item.Quantidade += qtd;
              continue;
            }

            indexTree++;
            drawExport.Tipo = ptNm.ToUpper().EndsWith("SLDPRT") ? swDocumentTypes_e.swDocPART : swDocumentTypes_e.swDocASSEMBLY;

            drawExport.IndexTree = indexTree;
            drawExport.Denominacao = swTableAnnotation.get_Text(i, 3);
            drawExport.Exportar = true;
            drawExport.Quantidade = qtd;
            listaDraw.Add(drawExport);
          }
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao pegar dados da Lista\n\n{ex.Message}", "Addin LM Projetos",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private static void PegaDadosListaPecas(BomTableAnnotation swBOMAnnotation, List<DrawExport> listaPecas) {
      string nameShort = "";
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
            //if (string.IsNullOrEmpty(swTableAnnotation.get_Text(i, 3)))
            //    continue;

            var drawExport = new DrawExport();
            string pathName = vModelPathNames[0];

            drawExport.PathName = pathName;

            drawExport.IndexTree = Convert.ToInt32(swTableAnnotation.get_Text(i, 0));
            drawExport.CodComponente = swTableAnnotation.get_Text(i, 1);
            var qtd = Convert.ToInt32(swTableAnnotation.get_Text(i, 2));
            drawExport.Denominacao = swTableAnnotation.get_Text(i, 3);

            if (listaPecas.Any(x => x.CodComponente == drawExport.CodComponente)) {
              var item = listaPecas.Where(x => x.CodComponente == drawExport.CodComponente).FirstOrDefault();
              item.Quantidade += qtd;
              continue;
            }

            drawExport.Tipo = swDocumentTypes_e.swDocPART;

            drawExport.Exportar = true;
            drawExport.Quantidade = qtd;
            listaPecas.Add(drawExport);
          }
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao pegar lista de peças\n\n{ex.Message}", "Addin LM Projetos",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    public static string RetornaCodigoPrincipal(ModelDoc2 swModel, ModelDocExtension swModelDocExt, CustomPropertyManager swCustPropMngr) {
      string _return = "";

      try {
        string valOut;
        string resolvedValOut;

        swModelDocExt = swModel.Extension;
        swCustPropMngr = swModelDocExt.get_CustomPropertyManager("");

        swCustPropMngr.Get2("CÓDIGO PROJETO", out valOut, out resolvedValOut);

        if (!string.IsNullOrEmpty(resolvedValOut))
          _return = resolvedValOut;
        else
          _return = Path.GetFileNameWithoutExtension(swModel.GetPathName());
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao pegar desenho\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return _return;
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

    public static List<DrawExport> GeListPart(List<DrawExport> listaPecas, ModelDoc2 swModel, ModelDocExtension swModelDocExt, CustomPropertyManager swCustPropMngr) {
      listaPecas = new List<DrawExport>();

      try {
        ConfigurationManager swConfMgr;
        Configuration swConf;

        swConfMgr = swModel.ConfigurationManager;
        swConf = swConfMgr.ActiveConfiguration;

        swModelDocExt = swModel.Extension;
        swCustPropMngr = swModelDocExt.get_CustomPropertyManager("");

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocASSEMBLY) {
          string templatePecas = $"{Application.StartupPath}\\01 - Addin TGM 4.0\\ListaPecas.sldbomtbt";
          int BomTypePeca = (int)swBomType_e.swBomType_PartsOnly;
          int NumberingType = (int)swNumberingType_e.swNumberingType_Detailed;
          var swBOMAnnotationPecas = swModelDocExt.InsertBomTable3(templatePecas, 0, 1, BomTypePeca, swConf.Name, false, NumberingType, true);
          PegaDadosListaPecas(swBOMAnnotationPecas, listaPecas);
          ExcluirLista(swModel);
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao pegar desenho\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      BubbleSort(listaPecas);
      for (int i = 1; i < listaPecas.Count + 1; i++)
        listaPecas[i - 1].IndexTree = i;

      return listaPecas;
    }

    public static string GetFolder(string sufixo, ModelDoc2 swModel = default(ModelDoc2)) {
      string _return = "";

      try {
        ModelDocExtension swModelDocExt;
        CustomPropertyManager swCustPropMngr = default(CustomPropertyManager);

        swModelDocExt = swModel.Extension;

        string valOut;
        string resolvedValOut;

        swCustPropMngr = swModelDocExt.get_CustomPropertyManager("");
        swCustPropMngr.Get2("CÓDIGO PROJETO", out valOut, out resolvedValOut);
        string codComponente = resolvedValOut;

        _return = Path.GetDirectoryName(swModel.GetPathName()) + "\\" + Path.GetFileNameWithoutExtension(swModel.GetPathName()) + sufixo + "\\";

      } catch (Exception ex) {
        MsgBox.Show($"Erro ao retornar pasta PDF\n\n{ex.Message}", "Addin LM Projetos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return _return;
    }

    private static void BubbleSort(List<DrawExport> listaPecas) {
      try {
        DrawExport packChange = new DrawExport();

        for (int i = 0; i < listaPecas.Count; i++) {
          for (int h = i + 1; h < listaPecas.Count; h++) {
            int j = string.Compare(listaPecas[i].CodComponente, listaPecas[h].CodComponente);
            if (j == 1) {
              packChange = listaPecas[i];
              listaPecas[i] = listaPecas[h];
              listaPecas[h] = packChange;
            }
          }
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao ordenar\n\n{ex.Message}", "Addin LM Projetos",
           MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    #endregion
  }
}
