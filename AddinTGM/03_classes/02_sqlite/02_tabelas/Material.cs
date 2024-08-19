using LmCorbieUI;
using LmCorbieUI.Metodos.AtributosCustomizados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AddinTGM {
  public class Material {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [LarguraColunaGrid(80)]
    [DataObjectField(true, false)]
    public int ID { get; set; }

    [LarguraColunaGrid(300)]
    [DisplayName("Material")]
    [DataObjectField(false, true)]
    public string Descricao { get; set; }

    public static List<Material> ListaMaterial { get; set; } = new List<Material>();

    public static Material model = new Material();

    public static void Salvar() {
      try {
        Config_db.Carregar();

        using (SQLiteContexto db = new SQLiteContexto()) {
          if (model.ID == 0) {
            model = new Material {
              Descricao = model.Descricao,
            };
            db.Material.Add(model);
            db.SaveChanges();
            ListaMaterial.Add(model);
          } else {
            var modelAlt = db.Material.FirstOrDefault(x => x.ID == model.ID);
            modelAlt.Descricao = model.Descricao;

            db.MateriaPrima.Where(x => x.MaterialID == model.ID).ToList().ForEach(x => { x.MaterialDesc = model.Descricao; });

            db.SaveChanges();

            Material.Carregar();
            MateriaPrima.Carregar();
          }
        }
      } catch (Exception ex) {
        MsgBox.Show("Erro ao Carregar Materias.", "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    public static void Carregar() {
      ListaMaterial = new List<Material>();
      try {
        Config_db.Carregar();

        using (SQLiteContexto db = new SQLiteContexto()) {
          ListaMaterial = db.Material.ToList();
        }
      } catch (Exception ex) {
        ListaMaterial = new List<Material>();
        LmException.ShowException(ex, "Erro ao Listar Materiais");
      }
    }
  }
}
