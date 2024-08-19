using LmCorbieUI;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.IO;

namespace AddinTGM {
  internal class Componente {
    public string denominacao { get; set; }
    public string short_name { get; set; }
    public string long_name { get; set; }
    public string config_name { get; set; }
    public double massa { get; set; }
    public List<ListaCorte> itens_corte { get; set; }

    public static Componente GetComponente(ModelDoc2 swModel) {
      Componente _return = new Componente();

      try {
        object[] ativeConfiguration = null;
        string valOut;
        string resolvedValOut;
        double[] massProp;

        var swModelDocExt = swModel.Extension;

        swModel.Rebuild((int)swRebuildOptions_e.swRebuildAll);

        ConfigurationManager swConfMgr;
        Configuration swConf;

        swConfMgr = swModel.ConfigurationManager;
        swConf = swConfMgr.ActiveConfiguration;
        ativeConfiguration = (object[])swModel.GetConfigurationNames();

        var swCustPropMngr = swModelDocExt.get_CustomPropertyManager(swConf.Name);

        swCustPropMngr.Get2("Denominação", out valOut, out resolvedValOut);
        _return.denominacao = resolvedValOut;

        _return.long_name = swModel.GetPathName();
        _return.short_name = Path.GetFileNameWithoutExtension(_return.long_name);
        _return.config_name = (string)ativeConfiguration[0];

        massProp = (double[])swModelDocExt.GetMassProperties(1, 0);

        if (massProp != null)
          _return.massa = Math.Round(massProp[5], 3);

        _return.itens_corte = ListaCorte.GetCutList(swModel);

      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro ao Caregar Componente");
      }

      return _return;
    }

  }
}
