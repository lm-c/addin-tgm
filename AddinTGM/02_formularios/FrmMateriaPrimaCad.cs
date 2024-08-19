using LmCorbieUI;
using LmCorbieUI.LmForms;
using LmCorbieUI.Metodos;
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
  public partial class FrmMateriaPrimaCad : LmSingleForm {
    public FrmMateriaPrimaCad(int idMateriaPrima = 0) {
      InitializeComponent();

      txtID.Text = idMateriaPrima.ToString("#");
      CarregarComboMaterial();
      MateriaPrima.Carregar();
    }

    private void FrmMateriaPrimaCad_Load(object sender, EventArgs e) {
      if (!string.IsNullOrEmpty(txtID.Text))
        TxtID_Leave(txtID, new EventArgs());
      else
        BtnLimpar_Click(null, new EventArgs());
    }

    private void BtnLimpar_Click(object sender, EventArgs e) {
      txtID.ReadOnly = false;
      txtCodigo.Focus();
      txtID.Text = txtCodigo.Text = txtEspessura.Text = txtDescricao.Text = string.Empty;
      txtMaterial.SelectedValue = null;
      ckbSituacao.Checked = true;
      MateriaPrima.model = new MateriaPrima();
    }

    private void BtnSalvar_Click(object sender, EventArgs e) {
      try {
        if (Controles.PossuiCamposInvalidos(this)) return;

        if (string.IsNullOrEmpty(txtCodigo.Text))
          txtCodigo.Text = "0";

        MateriaPrima.model.Espessura = Convert.ToDouble(txtEspessura.Text);
        MateriaPrima.model.ChapaID = Convert.ToInt32(txtCodigo.Text);
        MateriaPrima.model.ChapaDesc = txtDescricao.Text;
        MateriaPrima.model.MaterialID = (int)txtMaterial.SelectedValue;
        MateriaPrima.model.MaterialDesc = txtMaterial.Text;
        MateriaPrima.model.Ativo = ckbSituacao.Checked;

        if (MateriaPrima.ListaMateriaPrima.Any(x => x.ID != MateriaPrima.model.ID && x.ChapaDesc == MateriaPrima.model.ChapaDesc)) {
          MsgBox.Show("Já existe um registro com esta mesma descrição!",
            "Ação não permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        } else {
          MateriaPrima.Salvar();
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
        MateriaPrima.ListaMateriaPrima, "Consulta de Matéria Prima");
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

          if (MateriaPrima.model?.ID == id) return;
          MateriaPrima.model = MateriaPrima.ListaMateriaPrima.FirstOrDefault(x => x.ID == id);
          if (MateriaPrima.model != null) {
            txtEspessura.Text = MateriaPrima.model.Espessura.ToString();
            txtCodigo.Text = MateriaPrima.model.ChapaID.ToString();
            txtDescricao.Text = MateriaPrima.model.ChapaDesc;
            txtMaterial.SelectedValue = MateriaPrima.model.MaterialID;
            txtMaterial.Text = MateriaPrima.model.MaterialDesc;
            ckbSituacao.Checked = MateriaPrima.model.Ativo;

            txtID.ReadOnly = true;
          } else {
            MsgBox.Show($"Matéria Prima '{id}' não encontrada.",
              "Ação não permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            MateriaPrima.model = new MateriaPrima();
            txtID.Text = string.Empty;
          }
        } catch (Exception ex) {
          LmException.ShowException(ex, "Erro ao Carregar Matéria prima");
        }
      }
    }

    private void TxtMaterial_ButtonClickF8(object sender, EventArgs e) {
      FrmMaterialCad frm = new FrmMaterialCad();
      frm.ShowDialog();
      CarregarComboMaterial();
    }

    private void CarregarComboMaterial() {
      try {
        Material.Carregar();
        txtMaterial.CarregarComboBox(Material.ListaMaterial);
      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro ao carregar grid Material");
      }
    }

    private void BtnUpload_Click(object sender, EventArgs e) {
      string name = "MateriaPrima.corbie";
      var filename = Config_db.LocalBaseDados + "\\" + name;

      if (!File.Exists(filename)) return;

      var registros = File.ReadAllText(filename).Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
      foreach (var registro in registros) {
        var reg = registro.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);
        int materialID = int.Parse(reg[4]);
        var matDescr = Material.ListaMaterial.FirstOrDefault(x => x.ID == materialID)?.Descricao;

        MateriaPrima.model = new MateriaPrima {
          Espessura = double.Parse(reg[2]),
          ChapaID = int.Parse(reg[1]),
          ChapaDesc = reg[3],
          MaterialID = materialID,
          MaterialDesc = matDescr,
          Ativo = bool.Parse(reg[5])
        };

        MateriaPrima.Salvar();
      }
      MsgBox.Show("Importado com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
  }
}
