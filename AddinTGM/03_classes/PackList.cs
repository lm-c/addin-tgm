using LmCorbieUI;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AddinTGM {
  public class PackList {
    [DisplayName("ID")]
    public int IdVolume { get; set; }

    [Browsable(false)]
    public string NomeComponente { get; set; }

    [Browsable(false)]
    public string PathName { get; set; }

    [Browsable(false)]
    public string NomeConfiguracao { get; set; }

    [DisplayName("VOLUME")]
    public string DescricaoVolume { get; set; }

    [DisplayName("CÓDIGO")]
    public string CodigoItem { get; set; }

    [DisplayName("CÓD. PROD.")]
    public string CodProduto { get; set; }

    [DisplayName("DENOMINAÇÃO")]
    public string DescricaoItem { get; set; }

    [DisplayName("QTD")]
    public int QtdItem { get; set; }

    public static List<PackList> GetPackLit(out List<Z_Padrao> descVolumes) {
      var packListEstrutura = new ComponenteEstrutura();
      var listaPackList = new List<PackList>();
      List<Z_Padrao> descricaoVolumes = new List<Z_Padrao>();

      try {
        SldWorks swApp = new SldWorks();
        ModelDoc2 swModel = (ModelDoc2)swApp.ActiveDoc;

        ConfigurationManager swConfMgr;
        Configuration swConf;

        swConfMgr = swModel.ConfigurationManager;
        swConf = swConfMgr.ActiveConfiguration;

        string valOut;
        string resolvedValOut;

        ModelDocExtension swModelDocExt = swModel.Extension;
        CustomPropertyManager swCustPropMngr = swModelDocExt.get_CustomPropertyManager("");

        packListEstrutura.Nivel = "1";
        packListEstrutura.Quantidade = 1;
        swCustPropMngr.Get2("Componente", out valOut, out resolvedValOut);
        packListEstrutura.CompCodInterno = resolvedValOut;
        swCustPropMngr.Get2("Denominação", out valOut, out resolvedValOut);
        packListEstrutura.Denominacao = resolvedValOut;
        swCustPropMngr.Get2("CHECK", out valOut, out resolvedValOut);
        packListEstrutura.Check = resolvedValOut;
        swCustPropMngr.Get2("ItemPai", out valOut, out resolvedValOut);
        packListEstrutura.EhItemPai = resolvedValOut == "Sim" ? true : false;
        swCustPropMngr.Get2("Código Produto", out valOut, out resolvedValOut);
        packListEstrutura.CodProduto = resolvedValOut.Trim();

        if (string.IsNullOrEmpty(packListEstrutura.CodProduto)) {
          swCustPropMngr = swConf.CustomPropertyManager;
          swCustPropMngr.Get2("Código Produto", out valOut, out resolvedValOut);
          packListEstrutura.CodProduto = resolvedValOut.Trim();
        }

        // Inserir lista de material e pegar dados
        string lista = $"{Application.StartupPath}\\01 - Addin TGM 4.0\\ListaCompleta.sldbomtbt";

        int BomType = (int)swBomType_e.swBomType_Indented;
        int NumberingType = (int)swNumberingType_e.swNumberingType_Detailed;

        var swBOMAnnotation = swModelDocExt.InsertBomTable3(lista, 0, 1, BomType, swConf.Name, false, NumberingType, DetailedCutList: false);

        PegaDadosLista(swBOMAnnotation, packListEstrutura, descricaoVolumes);

        DrawExport.ExcluirLista(swModel);
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao retornar PackList\n\n{ex.Message}", "Addin LM Projetos",
          MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      var pkListMontado = MontarPackList(packListEstrutura, listaPackList, descricaoVolumes);

      var idsObsoletos = new List<int>();
      for (int i = 0; i < descricaoVolumes.Count; i++) {
        Z_Padrao descVol = descricaoVolumes[i];
        if (!pkListMontado.Any(x => x.IdVolume == descVol.Codigo)) {
          idsObsoletos.Add(i);
        }
      }

      idsObsoletos.ForEach(x => { descricaoVolumes.RemoveAt(x); });

      for (int i = 1; i <= descricaoVolumes.Count; i++) {
        var descVol = descricaoVolumes[i - 1];

        if (i != descVol.Codigo) {
          pkListMontado.Where(x => x.IdVolume == descVol.Codigo).ToList().ForEach(x => { x.IdVolume = i; });
          descVol.Codigo = i;
        }
      }

      descVolumes = descricaoVolumes;

      return pkListMontado;
    }

    private static void PegaDadosLista(BomTableAnnotation swBOMAnnotation, ComponenteEstrutura packListEstrutura, List<Z_Padrao> descricaoVolumes) {
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
          string ptNm = vModelPathNames[0];

          var pathName = ptNm;
          var nomeComponente = Path.GetFileNameWithoutExtension(pathName);

          var codComponente = swTableAnnotation.get_Text(i, 2).Trim();

          var packListnew = new ComponenteEstrutura();
          packListnew.NomeComponente = nomeComponente;
          packListnew.PathName = pathName;
          packListnew.Nivel = "1." + swTableAnnotation.get_Text(i, 0);
          packListnew.Quantidade = Convert.ToInt32(swTableAnnotation.get_Text(i, 1));
          packListnew.CompCodInterno = codComponente;
          packListnew.CodProduto = swTableAnnotation.get_Text(i, 3).Trim();
          packListnew.Denominacao = swTableAnnotation.get_Text(i, 5);
          packListnew.Check = swTableAnnotation.get_Text(i, 12).Trim();
          packListnew.EhItemPai = swTableAnnotation.get_Text(i, 13) == "Sim" ? true : false;
          packListnew.ConfigName = swTableAnnotation.get_Text(i, 14);

          var descTemp = $"{packListnew.Check} - FIXAÇÃO";

          if (!string.IsNullOrEmpty(packListnew.Check) && !descricaoVolumes.Any(x => x.Descricao == packListnew.Check)) {
            //if (packListnew.Check != "FIXAÇÃO")
            //{
            var codDesc = descricaoVolumes.Count > 0 ? descricaoVolumes[descricaoVolumes.Count - 1].Codigo + 1 : 1;
            descricaoVolumes.Add(new Z_Padrao {
              Codigo = codDesc,
              Descricao = packListnew.Check
            });

            if (packListnew.EhItemPai) {
              codDesc = descricaoVolumes.Count > 0 ? descricaoVolumes[descricaoVolumes.Count - 1].Codigo + 1 : 1;
              descricaoVolumes.Add(new Z_Padrao {
                Codigo = codDesc,
                Descricao = descTemp
              });
            }
            //}
          } else if (!string.IsNullOrEmpty(packListnew.Check) && packListnew.EhItemPai && !descricaoVolumes.Any(x => x.Descricao == descTemp)) {
            var codDesc = descricaoVolumes.Count > 0 ? descricaoVolumes[descricaoVolumes.Count - 1].Codigo + 1 : 1;
            descricaoVolumes.Add(new Z_Padrao {
              Codigo = codDesc,
              Descricao = descTemp
            });
          }

          var splNivel = packListnew.Nivel.Split('.');

          switch (splNivel.Length) {
            case 2: {
                packListEstrutura.CompFilhos.Add(packListnew);
              }
              break;
            case 3: {
                var nv2 = $"{splNivel[0]}.{splNivel[1]}";
                foreach (var itemN1 in packListEstrutura.CompFilhos) {
                  if (itemN1.Nivel == nv2) {
                    itemN1.CompFilhos.Add(packListnew);
                    break;
                  }
                }
              }
              break;
            case 4: {
                bool jaFoiAdd = false;
                var nv2 = $"{splNivel[0]}.{splNivel[1]}";
                var nv3 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}";
                foreach (var itemN1 in packListEstrutura.CompFilhos) {
                  if (itemN1.Nivel == nv2) {
                    foreach (var itemN2 in itemN1.CompFilhos) {
                      if (itemN2.Nivel == nv3) {
                        itemN2.CompFilhos.Add(packListnew);
                        jaFoiAdd = true;
                        break;
                      }
                    }
                  }
                  if (jaFoiAdd)
                    break;
                }
              }
              break;
            case 5: {
                bool jaFoiAdd = false;
                var nv2 = $"{splNivel[0]}.{splNivel[1]}";
                var nv3 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}";
                var nv4 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}";
                foreach (var itemN1 in packListEstrutura.CompFilhos) {
                  if (itemN1.Nivel == nv2) {
                    foreach (var itemN2 in itemN1.CompFilhos) {
                      if (itemN2.Nivel == nv3) {
                        foreach (var itemN3 in itemN2.CompFilhos) {
                          if (itemN3.Nivel == nv4) {
                            itemN3.CompFilhos.Add(packListnew);
                            jaFoiAdd = true;
                            break;
                          }
                        }
                      }
                      if (jaFoiAdd)
                        break;
                    }

                  }
                  if (jaFoiAdd)
                    break;
                }
              }
              break;
            case 6: {
                bool jaFoiAdd = false;
                var nv2 = $"{splNivel[0]}.{splNivel[1]}";
                var nv3 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}";
                var nv4 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}";
                var nv5 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}";
                foreach (var itemN1 in packListEstrutura.CompFilhos) {
                  if (itemN1.Nivel == nv2) {
                    foreach (var itemN2 in itemN1.CompFilhos) {
                      if (itemN2.Nivel == nv3) {
                        foreach (var itemN3 in itemN2.CompFilhos) {
                          if (itemN3.Nivel == nv4) {
                            foreach (var itemN4 in itemN3.CompFilhos) {
                              if (itemN4.Nivel == nv5) {
                                itemN4.CompFilhos.Add(packListnew);
                                jaFoiAdd = true;
                                break;
                              }
                            }
                          }
                          if (jaFoiAdd)
                            break;
                        }
                      }
                      if (jaFoiAdd)
                        break;
                    }
                  }
                  if (jaFoiAdd)
                    break;
                }
              }
              break;
            case 7: {
                bool jaFoiAdd = false;
                var nv2 = $"{splNivel[0]}.{splNivel[1]}";
                var nv3 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}";
                var nv4 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}";
                var nv5 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}";
                var nv6 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}.{splNivel[5]}";
                foreach (var itemN1 in packListEstrutura.CompFilhos) {
                  if (itemN1.Nivel == nv2) {
                    foreach (var itemN2 in itemN1.CompFilhos) {
                      if (itemN2.Nivel == nv3) {
                        foreach (var itemN3 in itemN2.CompFilhos) {
                          if (itemN3.Nivel == nv4) {
                            foreach (var itemN4 in itemN3.CompFilhos) {
                              if (itemN4.Nivel == nv5) {
                                foreach (var itemN5 in itemN4.CompFilhos) {
                                  if (itemN5.Nivel == nv6) {
                                    itemN5.CompFilhos.Add(packListnew);
                                    jaFoiAdd = true;
                                    break;
                                  }
                                }
                              }
                              if (jaFoiAdd)
                                break;
                            }
                          }
                          if (jaFoiAdd)
                            break;
                        }
                      }
                      if (jaFoiAdd)
                        break;
                    }
                  }
                  if (jaFoiAdd)
                    break;
                }
              }
              break;
            case 8: {
                bool jaFoiAdd = false;
                var nv2 = $"{splNivel[0]}.{splNivel[1]}";
                var nv3 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}";
                var nv4 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}";
                var nv5 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}";
                var nv6 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}.{splNivel[5]}";
                var nv7 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}.{splNivel[5]}.{splNivel[6]}";
                foreach (var itemN1 in packListEstrutura.CompFilhos) {
                  if (itemN1.Nivel == nv2) {
                    foreach (var itemN2 in itemN1.CompFilhos) {
                      if (itemN2.Nivel == nv3) {
                        foreach (var itemN3 in itemN2.CompFilhos) {
                          if (itemN3.Nivel == nv4) {
                            foreach (var itemN4 in itemN3.CompFilhos) {
                              if (itemN4.Nivel == nv5) {
                                foreach (var itemN5 in itemN4.CompFilhos) {
                                  if (itemN5.Nivel == nv6) {
                                    foreach (var itemN6 in itemN5.CompFilhos) {
                                      if (itemN6.Nivel == nv7) {
                                        itemN6.CompFilhos.Add(packListnew);
                                        jaFoiAdd = true;
                                        break;
                                      }
                                    }
                                  }
                                  if (jaFoiAdd)
                                    break;
                                }
                              }
                              if (jaFoiAdd)
                                break;
                            }
                          }
                          if (jaFoiAdd)
                            break;
                        }
                      }
                      if (jaFoiAdd)
                        break;
                    }
                  }
                  if (jaFoiAdd)
                    break;
                }
              }
              break;
            case 9: {
                bool jaFoiAdd = false;
                var nv2 = $"{splNivel[0]}.{splNivel[1]}";
                var nv3 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}";
                var nv4 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}";
                var nv5 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}";
                var nv6 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}.{splNivel[5]}";
                var nv7 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}.{splNivel[5]}.{splNivel[6]}";
                var nv8 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}.{splNivel[5]}.{splNivel[6]}.{splNivel[7]}";
                foreach (var itemN1 in packListEstrutura.CompFilhos) {
                  if (itemN1.Nivel == nv2) {
                    foreach (var itemN2 in itemN1.CompFilhos) {
                      if (itemN2.Nivel == nv3) {
                        foreach (var itemN3 in itemN2.CompFilhos) {
                          if (itemN3.Nivel == nv4) {
                            foreach (var itemN4 in itemN3.CompFilhos) {
                              if (itemN4.Nivel == nv5) {
                                foreach (var itemN5 in itemN4.CompFilhos) {
                                  if (itemN5.Nivel == nv6) {
                                    foreach (var itemN6 in itemN5.CompFilhos) {
                                      if (itemN6.Nivel == nv7) {
                                        foreach (var itemN7 in itemN6.CompFilhos) {
                                          if (itemN7.Nivel == nv8) {
                                            itemN7.CompFilhos.Add(packListnew);
                                            jaFoiAdd = true;
                                            break;
                                          }
                                        }
                                      }
                                      if (jaFoiAdd)
                                        break;
                                    }
                                  }
                                  if (jaFoiAdd)
                                    break;
                                }
                              }
                              if (jaFoiAdd)
                                break;
                            }
                          }
                          if (jaFoiAdd)
                            break;
                        }
                      }
                      if (jaFoiAdd)
                        break;
                    }
                  }
                  if (jaFoiAdd)
                    break;
                }
              }
              break;
            case 10: {
                bool jaFoiAdd = false;
                var nv2 = $"{splNivel[0]}.{splNivel[1]}";
                var nv3 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}";
                var nv4 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}";
                var nv5 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}";
                var nv6 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}.{splNivel[5]}";
                var nv7 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}.{splNivel[5]}.{splNivel[6]}";
                var nv8 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}.{splNivel[5]}.{splNivel[6]}.{splNivel[7]}";
                var nv9 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}.{splNivel[5]}.{splNivel[6]}.{splNivel[7]}.{splNivel[8]}";
                foreach (var itemN1 in packListEstrutura.CompFilhos) {
                  if (itemN1.Nivel == nv2) {
                    foreach (var itemN2 in itemN1.CompFilhos) {
                      if (itemN2.Nivel == nv3) {
                        foreach (var itemN3 in itemN2.CompFilhos) {
                          if (itemN3.Nivel == nv4) {
                            foreach (var itemN4 in itemN3.CompFilhos) {
                              if (itemN4.Nivel == nv5) {
                                foreach (var itemN5 in itemN4.CompFilhos) {
                                  if (itemN5.Nivel == nv6) {
                                    foreach (var itemN6 in itemN5.CompFilhos) {
                                      if (itemN6.Nivel == nv7) {
                                        foreach (var itemN7 in itemN6.CompFilhos) {
                                          if (itemN7.Nivel == nv8) {
                                            foreach (var itemN8 in itemN7.CompFilhos) {
                                              if (itemN8.Nivel == nv9) {
                                                itemN8.CompFilhos.Add(packListnew);
                                                jaFoiAdd = true;
                                                break;
                                              }
                                            }
                                          }
                                          if (jaFoiAdd)
                                            break;
                                        }
                                      }
                                      if (jaFoiAdd)
                                        break;
                                    }
                                  }
                                  if (jaFoiAdd)
                                    break;
                                }
                              }
                              if (jaFoiAdd)
                                break;
                            }
                          }
                          if (jaFoiAdd)
                            break;
                        }
                      }
                      if (jaFoiAdd)
                        break;
                    }
                  }
                  if (jaFoiAdd)
                    break;
                }
              }
              break;
            default:
            MsgBox.Show("Item com mais de oito níveis");
            break;
          }

          //if (vModelPathNames != null)
          //    reportWorks.PathName = vModelPathNames[0];
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao pegar dados da Lista Pack List\n\n{ex.Message}", "Addin LM Projetos",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private static List<PackList> MontarPackList(ComponenteEstrutura packListEstrutura, List<PackList> listaPackList, List<Z_Padrao> descricaoVolumes) {
      try {
        PercorrerComponentes(packListEstrutura, listaPackList, descricaoVolumes);
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao Montar PackList\n\n{ex.Message}", "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      return listaPackList.OrderBy(x => x.IdVolume).ToList();
    }

    private static void PercorrerComponentes(ComponenteEstrutura packListEstrutura, List<PackList> listaPackList, List<Z_Padrao> descricaoVolumes) {
      for (int i = 0; i < packListEstrutura.CompFilhos.Count; i++) {
        var comp = packListEstrutura.CompFilhos[i];

        if (comp != null && !string.IsNullOrEmpty(comp.Check)) {
          var itemExistaente = listaPackList.Where(x => x.CodigoItem == comp.CompCodInterno && x.DescricaoVolume == comp.Check && x.NomeConfiguracao == comp.ConfigName).FirstOrDefault();

          if (itemExistaente != null) {
            itemExistaente.QtdItem += comp.Quantidade * packListEstrutura.Quantidade;
          } else {
            listaPackList.Add(new PackList {
              CodigoItem = comp.CompCodInterno,
              CodProduto = comp.CodProduto,
              NomeComponente = comp.NomeComponente,
              PathName = comp.PathName,
              DescricaoItem = comp.Denominacao,
              DescricaoVolume = comp.Check,
              QtdItem = comp.Quantidade * packListEstrutura.Quantidade,
              NomeConfiguracao = comp.ConfigName,
              IdVolume = descricaoVolumes.Where(x => x.Descricao == comp.Check).FirstOrDefault().Codigo,
            });
          }
          if (comp.EhItemPai) {
            PercorrerComponentesFixacao(comp, $"{comp.Check} - FIXAÇÃO", listaPackList, descricaoVolumes);
          }
        }

        if (string.IsNullOrEmpty(comp.Check) && packListEstrutura.CompFilhos[i].CompFilhos.Count > 0) {
          PercorrerComponentes(packListEstrutura.CompFilhos[i], listaPackList, descricaoVolumes);
        }
      }
    }

    private static void PercorrerComponentesFixacao(ComponenteEstrutura item, string descCheck, List<PackList> listaPackList, List<Z_Padrao> descricaoVolumes) {
      for (int i = 0; i < item.CompFilhos.Count; i++) {
        var comp = item.CompFilhos[i];

        if (comp != null && comp.Check == "FIXAÇÃO") {
          var itemExistaente = listaPackList.Where(x => x.CodigoItem == comp.CompCodInterno && x.DescricaoVolume == descCheck && x.NomeConfiguracao == comp.ConfigName).FirstOrDefault();
          if (itemExistaente != null) {
            itemExistaente.QtdItem += comp.Quantidade * item.Quantidade;
          } else {
            listaPackList.Add(new PackList {
              CodigoItem = comp.CompCodInterno,
              CodProduto = comp.CodProduto,
              DescricaoItem = comp.Denominacao,
              DescricaoVolume = descCheck,
              QtdItem = comp.Quantidade * item.Quantidade,
              NomeConfiguracao = comp.ConfigName,
              IdVolume = descricaoVolumes.Where(x => x.Descricao == descCheck).FirstOrDefault().Codigo,
            });
          }


          //comp.FoiAdicionado = true;
        }

        //if (item.CompFilhos[i].CompFilhos.Count > 0)
        //{
        //    PercorrerComponentesFixacao(item.CompFilhos[i], descCheck, listaPackList, descricaoVolumes);
        //}
      }
    }

    public static string GetDenominacao() {
      string _return = "";

      try {
        ModelDocExtension swModelDocExt = default(ModelDocExtension);
        CustomPropertyManager swCustPropMngr = default(CustomPropertyManager);

        SldWorks swApp = new SldWorks();
        ModelDoc2 swModel = (ModelDoc2)swApp.ActiveDoc;
        swModelDocExt = swModel.Extension;

        swCustPropMngr = swModelDocExt.get_CustomPropertyManager("");

        swCustPropMngr.Get2("Denominação", out string valOut, out string resolvedValOut);
        _return = resolvedValOut;

        if (string.IsNullOrEmpty(_return)) {
          ConfigurationManager swConfMgr;
          Configuration swConf;

          swConfMgr = swModel.ConfigurationManager;
          swConf = swConfMgr.ActiveConfiguration;

          swCustPropMngr = swConf.CustomPropertyManager;
          swCustPropMngr.Get2("Denominação", out valOut, out resolvedValOut);
          _return = resolvedValOut;

        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao retornar denominção\n\n{ex.Message}", "Addin LM Projetos",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return _return;
    }

  }
}
