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
  public class MateriaPrima {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [LarguraColunaGrid(80)]
    [DataObjectField(true, false)]
    public int ID { get; set; }

    [LarguraColunaGrid(80)]
    [DisplayName("Espessura")]
    public double? Espessura { get; set; } = null;

    [DisplayName("Código")]
    [LarguraColunaGrid(120)]
    public int ChapaID { get; set; }

    [LarguraColunaGrid(300)]
    [DisplayName("Chapa Descrição")]
    [DataObjectField(false, true)]
    public string ChapaDesc { get; set; }

    [Browsable(false)]
    public int MaterialID { get; set; }

    [LarguraColunaGrid(300)]
    [DisplayName("Material")]
    public string MaterialDesc { get; set; }

    [LarguraColunaGrid(80)]
    public bool Ativo { get; set; }

    public static List<MateriaPrima> ListaMateriaPrima { get; set; } = new List<MateriaPrima>();

    public static MateriaPrima model = new MateriaPrima();

    public static void Salvar() {
      try {
        Config_db.Carregar();

        using (SQLiteContexto db = new SQLiteContexto()) {
          if (model.ID == 0) {
            model = new MateriaPrima {
              Espessura = model.Espessura,
              ChapaID = model.ChapaID,
              ChapaDesc = model.ChapaDesc,
              MaterialID = model.MaterialID,
              MaterialDesc = model.MaterialDesc,
              Ativo = model.Ativo,
            };
            db.MateriaPrima.Add(model);
            db.SaveChanges();
            ListaMateriaPrima.Add(model);
          } else {
            var modelAlt = db.MateriaPrima.FirstOrDefault(x => x.ID == model.ID);
            modelAlt.Espessura = model.Espessura;
            modelAlt.ChapaID = model.ChapaID;
            modelAlt.ChapaDesc = model.ChapaDesc;
            modelAlt.MaterialID = model.MaterialID;
            modelAlt.MaterialDesc = model.MaterialDesc;
            modelAlt.Ativo = model.Ativo;

            db.SaveChanges();
            MateriaPrima.Carregar();
          }
        }
      } catch (Exception ex) {
        MsgBox.Show("Erro ao Carregar Materias.", "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    public static void Carregar() {
      ListaMateriaPrima = new List<MateriaPrima>();
      try {
        Config_db.Carregar();

        using (SQLiteContexto db = new SQLiteContexto()) {
          ListaMateriaPrima = db.MateriaPrima.ToList();
        }
      } catch (Exception ex) {
        ListaMateriaPrima = new List<MateriaPrima>();
        LmException.ShowException(ex, "Erro ao Listar Materiais");
      }
    }

    public static List<MateriaPrima> SelecionarParaComboBox(double espessura) {
      List<MateriaPrima> _return = new List<MateriaPrima>();

      var chapas = ListaMateriaPrima
      .OrderBy(x => x.Espessura)
      .Where(x => x.Ativo && x.Espessura >= (espessura - 0.3) && x.Espessura <= (espessura + 0.3)).ToList();

      foreach (var chapa in chapas) {
        _return.Add(new MateriaPrima {
          ID = chapa.ID,
          Espessura = chapa.Espessura,
          ChapaID = chapa.ChapaID,
          ChapaDesc = chapa.ChapaDesc,
          MaterialID = chapa.MaterialID,
          MaterialDesc = chapa.MaterialDesc,
          Ativo = chapa.Ativo,
        });
      }

      return _return;
    }
  }
}
