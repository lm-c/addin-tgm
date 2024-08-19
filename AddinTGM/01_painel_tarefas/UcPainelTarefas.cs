using LmCorbieUI;
using LmCorbieUI.Controls;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AddinTGM {
  [ComVisible(true)]
  [ProgId(SWTASKPANE_PROGID)]
  public partial class UcPainelTarefas : LmUserControl {
    public const string SWTASKPANE_PROGID = "AddinTgm.SWTaskPanel_SwAddin_4000";

    static UcPainelTarefas instancia;

    public static UcPainelTarefas Instancia {
      get {
        if (instancia == null)
          instancia = new UcPainelTarefas();

        return instancia;
      }
    }

    public UcPainelTarefas() {
      InitializeComponent();
    }

    private void UcPainelTarefas_Load(object sender, EventArgs e) {
      instancia = this;

      string nomeSistem = "Addin TGM";
      string pastaRaiz = "LM Projetos Data";
      string cliente = "TGM";
      string mail = "michalakleo@gmail.com";

      ValPadrao.DefinirPadrao(pastaRaiz, nomeSistem, cliente, mail);

      Config_db.Carregar();
      InfoSetting.Carregar();

      if (!string.IsNullOrEmpty(Config_db.LocalBaseDados)) {
        SemearBase.CriarTabelas();
        Config.Carregar();
        FormatoFolha.Carregar();
        Material.Carregar();
        MateriaPrima.Carregar();
      }
    }

    private void AbrirFormFilho(Form frm) {
      if (string.IsNullOrEmpty(Config_db.LocalBaseDados))
        MsConfig_Click(null, null);

      if (!pnlMain.Controls.ContainsKey(frm.Name)) {
        frm.Dock = System.Windows.Forms.DockStyle.Fill;
        frm.TopLevel = false;
        frm.Parent = pnlMain;
        frm.Show();
        pnlMain.Controls.Add(frm);
        frm.BringToFront();

      } else {
        pnlMain.Controls[frm.Name].BringToFront();
      }
    }

    private void MsProcess_Click(object sender, EventArgs e) {
      FrmMaterialAplicacao frm = new FrmMaterialAplicacao();
      AbrirFormFilho(frm);
    }

    private void MsProperties_Click(object sender, EventArgs e) {
      var frm = new FrmFileProperties();
      AbrirFormFilho(frm);
    }

    private void MsDesenho_Click(object sender, EventArgs e) {
      msMenuDesenho.Show((LmMenuItem)sender, ((LmMenuItem)sender).Width, ((LmMenuItem)sender).Height);
    }

    private void MsCriarDesenho_Click(object sender, EventArgs e) {
      var frm = new FrmDesenho();
      AbrirFormFilho(frm);
    }

    private void MsAtualizarDesenho_Click(object sender, EventArgs e) {
      var frm = new FrmFormatosAtualizar();
      AbrirFormFilho(frm);
    }

    private void MsImprimir_Click(object sender, EventArgs e) {
      FrmExportar frm = new FrmExportar();
      AbrirFormFilho(frm);
    }

    private void MsCadastros_Click(object sender, EventArgs e) {
      msMenuCadastro.Show((LmMenuItem)sender, ((LmMenuItem)sender).Width, ((LmMenuItem)sender).Height);
    }

    private void MsMaterialCad_Click(object sender, EventArgs e) {
      if (string.IsNullOrEmpty(Config_db.LocalBaseDados))
        MsConfig_Click(null, null);

      FrmMaterialCad frm = new FrmMaterialCad();
      frm.ShowDialog();
    }

    private void MsMateriaPrimaCad_Click(object sender, EventArgs e) {
      if (string.IsNullOrEmpty(Config_db.LocalBaseDados))
        MsConfig_Click(null, null);

      FrmMateriaPrimaCad frm = new FrmMateriaPrimaCad();
      frm.ShowDialog();
    }

    private void MsRelatorio_Click(object sender, EventArgs e) {
      msMenuRelatorio.Show((LmMenuItem)sender, ((LmMenuItem)sender).Width, ((LmMenuItem)sender).Height);
    }

    private void MsPastaFormas_Click(object sender, EventArgs e) {
      FrmPastaFormas frm = new FrmPastaFormas();
      AbrirFormFilho(frm);
    }

    private void MsPastaMaquinas_Click(object sender, EventArgs e) {
      FrmPastaMaquinas frm = new FrmPastaMaquinas();
      AbrirFormFilho(frm);
    }

    private void MsProcessoFabricacao_Click(object sender, EventArgs e) {
      FrmPastaProcessos frm = new FrmPastaProcessos();
      AbrirFormFilho(frm);
    }

    private void MsPackList_Click(object sender, EventArgs e) {
      FrmPackList frm = new FrmPackList();
      AbrirFormFilho(frm);
    }

    private void MsConfig_Click(object sender, EventArgs e) {
      FrmConfiguracao frm = new FrmConfiguracao();
      frm.ShowDialog();
    }

    internal void BtnCapa_Click() {
      FrmCapaProjeto frm = new FrmCapaProjeto();
      AbrirFormFilho(frm);
    }
  }
}
