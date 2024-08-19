﻿using LmCorbieUI;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddinTGM {
  public class ListaCorte {
    public int codigo { get; set; }
    public string nome_lista { get; set; }
    public string denominacao { get; set; }
    public string comprimento { get; set; }
    public string material { get; set; }
    public double cxd_espess { get; set; }
    public double cxd_larg { get; set; }
    public double cxd_compr { get; set; }
    public double massa { get; set; }
    public int quantidade { get; set; }
    public TipoListaMaterial tipo { get; set; }


    public static List<ListaCorte> GetCutList(ModelDoc2 swModel) {
      List<ListaCorte> _return = new List<ListaCorte>();
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

        var pathName = swModel.GetPathName();

        while ((swFeat != null)) {
          ListaCorte listaCorte = new ListaCorte();

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

              swCustPropMngr.Add3("Massa", (int)swCustomInfoType_e.swCustomInfoText, "\"SW-Mass\"", (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
              swCustPropMngr.Add3("Material", (int)swCustomInfoType_e.swCustomInfoText, "\"SW-Material\"", (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);

              object[] custPropNames = (object[])swCustPropMngr.GetNames();

              if (custPropNames != null) {
                object[] vBodies = (object[])swBodyFolder.GetBodies();

                if ((vBodies != null)) {
                  for (int i = vBodies.GetLowerBound(0); i <= vBodies.GetUpperBound(0); i++) {
                    Body2 Body = default(Body2);
                    Body = (Body2)vBodies[i];

                    if (Body.IsSheetMetal())
                      listaCorte.tipo = TipoListaMaterial.Chapa;
                    else
                      listaCorte.tipo = TipoListaMaterial.Soldagem;
                  }
                }

                string sValue, sResolvedvalue;

                swBodyFolder = (BodyFolder)swFeat.GetSpecificFeature2();
                boolstatus = swBodyFolder.SetAutomaticCutList(true);
                boolstatus = swBodyFolder.UpdateCutList();

                listaCorte.nome_lista = FeatType;

                foreach (var name in custPropNames) {
                  //PEGA VALORES DA LISTA DE CORTE
                  string nomePropr = Convert.ToString(name);

                  if (nomePropr == "CÓDIGO MATERIAL") {
                    swCustPropMngr.Get2(nomePropr, out sValue, out sResolvedvalue);
                    int.TryParse(sResolvedvalue, out int cod);
                    listaCorte.codigo = cod;
                  } else if (nomePropr == "DESCRIÇÃO MATERIAL") {
                    swCustPropMngr.Get2(nomePropr, out sValue, out sResolvedvalue);
                    listaCorte.denominacao = sResolvedvalue;
                  } else if (nomePropr == "COMPRIMENTO") {
                    swCustPropMngr.Get2(nomePropr, out sValue, out sResolvedvalue);
                    listaCorte.comprimento = sResolvedvalue;
                  } else if (nomePropr == "QUANTITY") {
                    swCustPropMngr.Get2(nomePropr, out sValue, out sResolvedvalue);
                    listaCorte.quantidade = !string.IsNullOrEmpty(sResolvedvalue) ? Convert.ToInt32(sResolvedvalue) : 0;
                  } else if (nomePropr.ToLower() == "material") {
                    swCustPropMngr.Get2(nomePropr, out sValue, out sResolvedvalue);
                    listaCorte.material = sResolvedvalue;
                  } else if (nomePropr == "Quantidade") {
                    if (listaCorte.quantidade == 0) {
                      swCustPropMngr.Get2(nomePropr, out sValue, out sResolvedvalue);
                      listaCorte.quantidade = !string.IsNullOrEmpty(sResolvedvalue) ? Convert.ToInt32(sResolvedvalue) : 0;
                    }
                  } else if (nomePropr == "Espessura da Chapa metálica") {
                    swCustPropMngr.Get2(nomePropr, out sValue, out sResolvedvalue);
                    double.TryParse(sResolvedvalue.Replace(".", ","), out double esp);
                    listaCorte.cxd_espess = Math.Round(esp, 3);
                  } else if (nomePropr == "Largura da Caixa delimitadora") {
                    swCustPropMngr.Get2(nomePropr, out sValue, out sResolvedvalue);
                    double.TryParse(sResolvedvalue.Replace(".", ","), out double larg);
                    listaCorte.cxd_larg = Math.Round(larg, 3);
                  } else if (nomePropr == "Comprimento da Caixa delimitadora") {
                    swCustPropMngr.Get2(nomePropr, out sValue, out sResolvedvalue);
                    double.TryParse(sResolvedvalue.Replace(".", ","), out double comp);
                    listaCorte.cxd_compr = Math.Round(comp, 3);
                  } 
                }

                swCustPropMngr.Get2("Massa", out sValue, out sResolvedvalue);
                double.TryParse(sResolvedvalue.Replace(".", ","), out double Massa);
                listaCorte.massa = Math.Round(Massa, 3);

                if (listaCorte.tipo == TipoListaMaterial.Chapa) {
                  string nomePeca = Path.GetFileName(pathName);
                  string descCustProp = $"\"SW-Largura da Caixa delimitadora@@@{listaCorte.nome_lista}@{nomePeca}\" X \"SW-Comprimento da Caixa delimitadora@@@{listaCorte.nome_lista}@{nomePeca}\"";
                  swCustPropMngr.Add3("COMPRIMENTO", (int)swCustomInfoType_e.swCustomInfoText, descCustProp,
                      (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);

                  listaCorte.comprimento = listaCorte.cxd_larg + " X " + listaCorte.cxd_compr;
                }
              }

              _return.Add(listaCorte);
            }
          }
          swFeat = (Feature)swFeat.GetNextFeature();
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao pegar lista corte\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return _return;
    }

    public static void UpdateCutList(ModelDoc2 swModel, ListaCorte cutList) {
      bool boolstatus = swModel.Extension.SelectByID2(cutList.nome_lista, "SUBWELDFOLDER", 0, 0, 0, false, 0, null, 0);

      SelectionMgr swSelMgr = (SelectionMgr)swModel.SelectionManager;
      Feature swFeat = (Feature)swSelMgr.GetSelectedObject6(1, 0);
      CustomPropertyManager swCustPropMngr = swFeat.CustomPropertyManager;

      // excluir processos
      swCustPropMngr.Delete("Operação");

      //GETTING CUSTOM PROPERTY NAMES
      object[] custPropNames = (object[])swCustPropMngr.GetNames();

      string sValue, sResolvedvalue;

      foreach (var name in custPropNames) {
        //PEGA VALORES DA LISTA DE CORTE
        swCustPropMngr.Get2((string)name, out sValue, out sResolvedvalue);
        string nm = Convert.ToString(name);

        if (nm.Contains("op-")) {
          swCustPropMngr.Delete((string)name);
        }
      }

      if (cutList.tipo == TipoListaMaterial.Chapa) {
        string nomePeca = Path.GetFileName(swModel.GetPathName());

        swCustPropMngr.Add3("CÓDIGO MATERIAL", (int)swCustomInfoType_e.swCustomInfoText, cutList.codigo.ToString(), (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
        swCustPropMngr.Add3("DESCRIÇÃO MATERIAL", (int)swCustomInfoType_e.swCustomInfoText, cutList.denominacao.ToString(), (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
        swCustPropMngr.Add3("COMPRIMENTO", (int)swCustomInfoType_e.swCustomInfoText,
            $"\"SW-Largura da Caixa delimitadora@@@{cutList.nome_lista}@{nomePeca}\" X \"SW-Comprimento da Caixa delimitadora@@@{cutList.nome_lista}@{nomePeca}\"",
            (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
      }

    }

  }
}
