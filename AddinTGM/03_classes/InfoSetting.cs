using LmCorbieUI.Metodos.AtributosCustomizados;
using LmCorbieUI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace AddinTGM {
  public class InfoSetting {
    public static bool AddTodosConfigs { get; set; } 

    private static string diretorio = Environment.ExpandEnvironmentVariables("%AppData%") + "\\Lm Projetos\\Addin\\";
    private static string name = "InfoSetting.corbie";

    public static void Salvar() {
      try {
        var filename = diretorio + name;

        string texto = $"{AddTodosConfigs}";

        File.WriteAllText(filename, texto);
      } catch (Exception ex) {
        MsgBox.Show("Erro ao Carregar Configuração do Utilitário Customax.", "Utilitário Customax", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    public static void Carregar() {
      try {
        var filename = diretorio + name;

        if (!File.Exists(filename)) return;

        var registro = File.ReadAllText(filename);//.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        AddTodosConfigs = Convert.ToBoolean(registro);
      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro ao Listar Materiais");
      }
    }
  }
}
