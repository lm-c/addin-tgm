using LmCorbieUI;
using LmCorbieUI.LmForms;
using LmCorbieUI.Metodos;
using Microsoft.WindowsAPICodePack.Sensors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddinTGM {
  public partial class FrmMaterialCad : LmSingleForm {

    public FrmMaterialCad(int idMaterial = 0) {
      InitializeComponent();

      txtID.Text = idMaterial.ToString("#");

      Material.Carregar();
    }

    private void FrmMaterialCad_Load(object sender, EventArgs e) {
      if (!string.IsNullOrEmpty(txtID.Text))
        TxtID_Leave(txtID, new EventArgs());
      else
        BtnLimpar_Click(null, new EventArgs());
    }

    private void BtnLimpar_Click(object sender, EventArgs e) {
      txtID.ReadOnly = false;
      txtDescricao.Focus();
      txtID.Text = txtDescricao.Text = string.Empty;
      Material.model = new Material();
    }

    private void BtnSalvar_Click(object sender, EventArgs e) {
      try {
        if (Controles.PossuiCamposInvalidos(this)) return;

        var descr = txtDescricao.Text;

        Material.model.Descricao = descr;

        if (Material.ListaMaterial.Any(x => x.ID != Material.model.ID && x.Descricao == Material.model.Descricao)) {
          MsgBox.Show("Já existe um registro com esta mesma descrição!",
            "Ação não permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        } else {
          Material.Salvar();
          MsgBox.Show("Salvo com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
          BtnLimpar_Click(sender, new EventArgs());
        }
      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro ao Salvar Matéria prima");
      }
    }

    private void BtnExcluir_Click(object sender, EventArgs e) {

    }

    private void TxtID_ButtonClickF7(object sender, EventArgs e) {
      FrmConsultaGeral frm = new FrmConsultaGeral(this,
        Material.ListaMaterial, "Consulta de Material");
      if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK /*&& Modo == Modo.Novo*/)
        if (int.TryParse(frm.valor[0], out int ID)) {
          txtID.Text = frm.valor[0];
          TxtID_Leave(null, new EventArgs());
        }
    }

    private void TxtID_Leave(object sender, EventArgs e) {
      if (!string.IsNullOrEmpty(txtID.Text)) {
        try {
          int id = int.Parse(txtID.Text);

          if (Material.model?.ID == id) return;
          Material.model = Material.ListaMaterial.FirstOrDefault(x => x.ID == id);

          if (Material.model != null) {
            Controles.PreencherControles(this, Material.model);
            txtID.ReadOnly = true;
          } else {
            MsgBox.Show($"Material '{id}' não encontrado.",
              "Ação não permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Material.model = new Material();
           txtID.Text = string.Empty;
          }
        } catch (Exception ex) {
          LmException.ShowException(ex, "Erro ao Carregar Material");
        }
      }
    }

    private void BtnUpload_Click(object sender, EventArgs e) {
      string name = "Material.corbie";
      var filename = Config_db.LocalBaseDados + "\\" + name;

      if (!File.Exists(filename)) return;

      var registros = File.ReadAllText(filename).Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
      foreach (var registro in registros) {
        var reg = registro.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);
        var descr = reg[1];

        Material.model = new Material {
          Descricao = descr
        };
        Material.Salvar();
      }
      MsgBox.Show("Importado com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
  }
}
