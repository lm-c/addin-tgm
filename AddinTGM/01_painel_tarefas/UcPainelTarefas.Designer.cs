namespace AddinTGM
{
    partial class UcPainelTarefas
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcPainelTarefas));
      this.tmr = new System.Windows.Forms.Timer(this.components);
      this.cmxToolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.msConfig = new LmCorbieUI.Controls.LmMenuItem();
      this.msRelatorio = new LmCorbieUI.Controls.LmMenuItem();
      this.msImprimir = new LmCorbieUI.Controls.LmMenuItem();
      this.msDesenho = new LmCorbieUI.Controls.LmMenuItem();
      this.msProperties = new LmCorbieUI.Controls.LmMenuItem();
      this.msProcess = new LmCorbieUI.Controls.LmMenuItem();
      this.msCadastros = new LmCorbieUI.Controls.LmMenuItem();
      this.msMenuRelatorio = new LmCorbieUI.Controls.LmDropdownMenu(this.components);
      this.msPastaFormas = new System.Windows.Forms.ToolStripMenuItem();
      this.msPastaMaquinas = new System.Windows.Forms.ToolStripMenuItem();
      this.msProcessoFabricacao = new System.Windows.Forms.ToolStripMenuItem();
      this.msPackList = new System.Windows.Forms.ToolStripMenuItem();
      this.msMenuCadastro = new LmCorbieUI.Controls.LmDropdownMenu(this.components);
      this.msMaterialCad = new System.Windows.Forms.ToolStripMenuItem();
      this.msMateriaPrimaCad = new System.Windows.Forms.ToolStripMenuItem();
      this.msMenuDesenho = new LmCorbieUI.Controls.LmDropdownMenu(this.components);
      this.msCriarDesenho = new System.Windows.Forms.ToolStripMenuItem();
      this.msAtualizarDesenho = new System.Windows.Forms.ToolStripMenuItem();
      this.pnlMain = new LmCorbieUI.Controls.LmPanel();
      this.msMenu = new LmCorbieUI.Controls.LmPanel();
      this.msMenuRelatorio.SuspendLayout();
      this.msMenuCadastro.SuspendLayout();
      this.msMenuDesenho.SuspendLayout();
      this.msMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // tmr
      // 
      this.tmr.Interval = 1000;
      this.tmr.Tag = "0";
      // 
      // msConfig
      // 
      this.msConfig.Dock = System.Windows.Forms.DockStyle.Right;
      this.msConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.msConfig.Image = ((System.Drawing.Image)(resources.GetObject("msConfig.Image")));
      this.msConfig.Location = new System.Drawing.Point(298, 0);
      this.msConfig.Name = "msConfig";
      this.msConfig.Size = new System.Drawing.Size(30, 30);
      this.msConfig.TabIndex = 6;
      this.msConfig.TabStop = false;
      this.msConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.cmxToolTip1.SetToolTip(this.msConfig, "Configuração");
      this.msConfig.UseSelectable = true;
      this.msConfig.UseVisualStyleBackColor = false;
      this.msConfig.Click += new System.EventHandler(this.MsConfig_Click);
      // 
      // msRelatorio
      // 
      this.msRelatorio.Dock = System.Windows.Forms.DockStyle.Left;
      this.msRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.msRelatorio.Image = ((System.Drawing.Image)(resources.GetObject("msRelatorio.Image")));
      this.msRelatorio.Location = new System.Drawing.Point(150, 0);
      this.msRelatorio.Name = "msRelatorio";
      this.msRelatorio.Size = new System.Drawing.Size(30, 30);
      this.msRelatorio.TabIndex = 5;
      this.msRelatorio.TabStop = false;
      this.msRelatorio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.cmxToolTip1.SetToolTip(this.msRelatorio, "Listagem");
      this.msRelatorio.UseSelectable = true;
      this.msRelatorio.UseVisualStyleBackColor = false;
      this.msRelatorio.Click += new System.EventHandler(this.MsRelatorio_Click);
      // 
      // msImprimir
      // 
      this.msImprimir.Dock = System.Windows.Forms.DockStyle.Left;
      this.msImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.msImprimir.Image = ((System.Drawing.Image)(resources.GetObject("msImprimir.Image")));
      this.msImprimir.Location = new System.Drawing.Point(90, 0);
      this.msImprimir.Name = "msImprimir";
      this.msImprimir.Size = new System.Drawing.Size(30, 30);
      this.msImprimir.TabIndex = 4;
      this.msImprimir.TabStop = false;
      this.msImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.cmxToolTip1.SetToolTip(this.msImprimir, "Gerar PDFs");
      this.msImprimir.UseSelectable = true;
      this.msImprimir.UseVisualStyleBackColor = false;
      this.msImprimir.Click += new System.EventHandler(this.MsImprimir_Click);
      // 
      // msDesenho
      // 
      this.msDesenho.Dock = System.Windows.Forms.DockStyle.Left;
      this.msDesenho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.msDesenho.Image = ((System.Drawing.Image)(resources.GetObject("msDesenho.Image")));
      this.msDesenho.Location = new System.Drawing.Point(60, 0);
      this.msDesenho.Name = "msDesenho";
      this.msDesenho.Size = new System.Drawing.Size(30, 30);
      this.msDesenho.TabIndex = 3;
      this.msDesenho.TabStop = false;
      this.msDesenho.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.cmxToolTip1.SetToolTip(this.msDesenho, "Desenhos");
      this.msDesenho.UseSelectable = true;
      this.msDesenho.UseVisualStyleBackColor = false;
      this.msDesenho.Click += new System.EventHandler(this.MsDesenho_Click);
      // 
      // msProperties
      // 
      this.msProperties.Dock = System.Windows.Forms.DockStyle.Left;
      this.msProperties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.msProperties.Image = ((System.Drawing.Image)(resources.GetObject("msProperties.Image")));
      this.msProperties.Location = new System.Drawing.Point(30, 0);
      this.msProperties.Name = "msProperties";
      this.msProperties.Size = new System.Drawing.Size(30, 30);
      this.msProperties.TabIndex = 2;
      this.msProperties.TabStop = false;
      this.msProperties.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.cmxToolTip1.SetToolTip(this.msProperties, "Propriedades Personalizadas");
      this.msProperties.UseSelectable = true;
      this.msProperties.UseVisualStyleBackColor = false;
      this.msProperties.Click += new System.EventHandler(this.MsProperties_Click);
      // 
      // msProcess
      // 
      this.msProcess.Dock = System.Windows.Forms.DockStyle.Left;
      this.msProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.msProcess.Image = ((System.Drawing.Image)(resources.GetObject("msProcess.Image")));
      this.msProcess.Location = new System.Drawing.Point(0, 0);
      this.msProcess.Name = "msProcess";
      this.msProcess.Size = new System.Drawing.Size(30, 30);
      this.msProcess.TabIndex = 0;
      this.msProcess.TabStop = false;
      this.msProcess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.cmxToolTip1.SetToolTip(this.msProcess, "Aplicação de Materiais");
      this.msProcess.UseSelectable = true;
      this.msProcess.UseVisualStyleBackColor = false;
      this.msProcess.Click += new System.EventHandler(this.MsProcess_Click);
      // 
      // msCadastros
      // 
      this.msCadastros.Dock = System.Windows.Forms.DockStyle.Left;
      this.msCadastros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.msCadastros.Image = ((System.Drawing.Image)(resources.GetObject("msCadastros.Image")));
      this.msCadastros.Location = new System.Drawing.Point(120, 0);
      this.msCadastros.Name = "msCadastros";
      this.msCadastros.Size = new System.Drawing.Size(30, 30);
      this.msCadastros.TabIndex = 7;
      this.msCadastros.TabStop = false;
      this.msCadastros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.cmxToolTip1.SetToolTip(this.msCadastros, "Cadastros");
      this.msCadastros.UseSelectable = true;
      this.msCadastros.UseVisualStyleBackColor = false;
      this.msCadastros.Click += new System.EventHandler(this.MsCadastros_Click);
      // 
      // msMenuRelatorio
      // 
      this.msMenuRelatorio.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.msMenuRelatorio.IsMainMenu = false;
      this.msMenuRelatorio.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msPastaFormas,
            this.msPastaMaquinas,
            this.msProcessoFabricacao,
            this.msPackList});
      this.msMenuRelatorio.MenuItemHeight = 25;
      this.msMenuRelatorio.MenuItemTextColor = System.Drawing.Color.Empty;
      this.msMenuRelatorio.Name = "msMenuSistema";
      this.msMenuRelatorio.NaoInverterCorImagem = false;
      this.msMenuRelatorio.PrimaryColor = System.Drawing.Color.Empty;
      this.msMenuRelatorio.Size = new System.Drawing.Size(193, 108);
      this.msMenuRelatorio.Z_Teste = 0;
      // 
      // msPastaFormas
      // 
      this.msPastaFormas.Image = ((System.Drawing.Image)(resources.GetObject("msPastaFormas.Image")));
      this.msPastaFormas.Name = "msPastaFormas";
      this.msPastaFormas.Size = new System.Drawing.Size(192, 26);
      this.msPastaFormas.Text = "Gerar Pasta Formas";
      this.msPastaFormas.Click += new System.EventHandler(this.MsPastaFormas_Click);
      // 
      // msPastaMaquinas
      // 
      this.msPastaMaquinas.Image = ((System.Drawing.Image)(resources.GetObject("msPastaMaquinas.Image")));
      this.msPastaMaquinas.Name = "msPastaMaquinas";
      this.msPastaMaquinas.Size = new System.Drawing.Size(192, 26);
      this.msPastaMaquinas.Text = "Gerar Pasta Máquinas";
      this.msPastaMaquinas.Click += new System.EventHandler(this.MsPastaMaquinas_Click);
      // 
      // msProcessoFabricacao
      // 
      this.msProcessoFabricacao.Image = ((System.Drawing.Image)(resources.GetObject("msProcessoFabricacao.Image")));
      this.msProcessoFabricacao.Name = "msProcessoFabricacao";
      this.msProcessoFabricacao.Size = new System.Drawing.Size(192, 26);
      this.msProcessoFabricacao.Text = "Gerar Pasta Processos";
      this.msProcessoFabricacao.Click += new System.EventHandler(this.MsProcessoFabricacao_Click);
      // 
      // msPackList
      // 
      this.msPackList.Image = ((System.Drawing.Image)(resources.GetObject("msPackList.Image")));
      this.msPackList.Name = "msPackList";
      this.msPackList.Size = new System.Drawing.Size(192, 26);
      this.msPackList.Text = "Pack List";
      this.msPackList.Click += new System.EventHandler(this.MsPackList_Click);
      // 
      // msMenuCadastro
      // 
      this.msMenuCadastro.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.msMenuCadastro.IsMainMenu = false;
      this.msMenuCadastro.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMaterialCad,
            this.msMateriaPrimaCad});
      this.msMenuCadastro.MenuItemHeight = 25;
      this.msMenuCadastro.MenuItemTextColor = System.Drawing.Color.Empty;
      this.msMenuCadastro.Name = "msMenuSistema";
      this.msMenuCadastro.NaoInverterCorImagem = false;
      this.msMenuCadastro.PrimaryColor = System.Drawing.Color.Empty;
      this.msMenuCadastro.Size = new System.Drawing.Size(219, 56);
      this.msMenuCadastro.Z_Teste = 0;
      // 
      // msMaterialCad
      // 
      this.msMaterialCad.Image = ((System.Drawing.Image)(resources.GetObject("msMaterialCad.Image")));
      this.msMaterialCad.Name = "msMaterialCad";
      this.msMaterialCad.Size = new System.Drawing.Size(218, 26);
      this.msMaterialCad.Text = "Cadastro de Material";
      this.msMaterialCad.Click += new System.EventHandler(this.MsMaterialCad_Click);
      // 
      // msMateriaPrimaCad
      // 
      this.msMateriaPrimaCad.Image = ((System.Drawing.Image)(resources.GetObject("msMateriaPrimaCad.Image")));
      this.msMateriaPrimaCad.Name = "msMateriaPrimaCad";
      this.msMateriaPrimaCad.Size = new System.Drawing.Size(218, 26);
      this.msMateriaPrimaCad.Text = "Cadastro de Matéria Prima";
      this.msMateriaPrimaCad.Click += new System.EventHandler(this.MsMateriaPrimaCad_Click);
      // 
      // msMenuDesenho
      // 
      this.msMenuDesenho.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.msMenuDesenho.IsMainMenu = false;
      this.msMenuDesenho.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msCriarDesenho,
            this.msAtualizarDesenho});
      this.msMenuDesenho.MenuItemHeight = 25;
      this.msMenuDesenho.MenuItemTextColor = System.Drawing.Color.Empty;
      this.msMenuDesenho.Name = "msMenuSistema";
      this.msMenuDesenho.NaoInverterCorImagem = false;
      this.msMenuDesenho.PrimaryColor = System.Drawing.Color.Empty;
      this.msMenuDesenho.Size = new System.Drawing.Size(257, 56);
      this.msMenuDesenho.Z_Teste = 0;
      // 
      // msCriarDesenho
      // 
      this.msCriarDesenho.Image = ((System.Drawing.Image)(resources.GetObject("msCriarDesenho.Image")));
      this.msCriarDesenho.Name = "msCriarDesenho";
      this.msCriarDesenho.Size = new System.Drawing.Size(256, 26);
      this.msCriarDesenho.Text = "Criar/Alterar Desenhos";
      this.msCriarDesenho.Click += new System.EventHandler(this.MsCriarDesenho_Click);
      // 
      // msAtualizarDesenho
      // 
      this.msAtualizarDesenho.Image = ((System.Drawing.Image)(resources.GetObject("msAtualizarDesenho.Image")));
      this.msAtualizarDesenho.Name = "msAtualizarDesenho";
      this.msAtualizarDesenho.Size = new System.Drawing.Size(256, 26);
      this.msAtualizarDesenho.Text = "Atualizar Templates dos Desenhos";
      this.msAtualizarDesenho.Click += new System.EventHandler(this.MsAtualizarDesenho_Click);
      // 
      // pnlMain
      // 
      this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
      this.pnlMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlMain.BackgroundImage")));
      this.pnlMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlMain.IsPanelMenu = false;
      this.pnlMain.Location = new System.Drawing.Point(0, 30);
      this.pnlMain.Name = "pnlMain";
      this.pnlMain.Size = new System.Drawing.Size(328, 475);
      this.pnlMain.TabIndex = 26;
      // 
      // msMenu
      // 
      this.msMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(71)))));
      this.msMenu.Controls.Add(this.msRelatorio);
      this.msMenu.Controls.Add(this.msCadastros);
      this.msMenu.Controls.Add(this.msConfig);
      this.msMenu.Controls.Add(this.msImprimir);
      this.msMenu.Controls.Add(this.msDesenho);
      this.msMenu.Controls.Add(this.msProperties);
      this.msMenu.Controls.Add(this.msProcess);
      this.msMenu.Dock = System.Windows.Forms.DockStyle.Top;
      this.msMenu.IsPanelMenu = true;
      this.msMenu.Location = new System.Drawing.Point(0, 0);
      this.msMenu.Name = "msMenu";
      this.msMenu.Size = new System.Drawing.Size(328, 30);
      this.msMenu.TabIndex = 25;
      // 
      // UcPainelTarefas
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.pnlMain);
      this.Controls.Add(this.msMenu);
      this.Name = "UcPainelTarefas";
      this.Size = new System.Drawing.Size(328, 505);
      this.Load += new System.EventHandler(this.UcPainelTarefas_Load);
      this.msMenuRelatorio.ResumeLayout(false);
      this.msMenuCadastro.ResumeLayout(false);
      this.msMenuDesenho.ResumeLayout(false);
      this.msMenu.ResumeLayout(false);
      this.ResumeLayout(false);

        }

    #endregion

    private System.Windows.Forms.Timer tmr;
    private System.Windows.Forms.ToolTip cmxToolTip1;
    private LmCorbieUI.Controls.LmMenuItem msConfig;
    private LmCorbieUI.Controls.LmMenuItem msRelatorio;
    private LmCorbieUI.Controls.LmMenuItem msImprimir;
    private LmCorbieUI.Controls.LmMenuItem msDesenho;
    private LmCorbieUI.Controls.LmMenuItem msProperties;
    private LmCorbieUI.Controls.LmMenuItem msProcess;
    private LmCorbieUI.Controls.LmDropdownMenu msMenuRelatorio;
    private System.Windows.Forms.ToolStripMenuItem msPastaFormas;
    private System.Windows.Forms.ToolStripMenuItem msPastaMaquinas;
    private System.Windows.Forms.ToolStripMenuItem msProcessoFabricacao;
    private System.Windows.Forms.ToolStripMenuItem msPackList;
    private LmCorbieUI.Controls.LmDropdownMenu msMenuCadastro;
    private System.Windows.Forms.ToolStripMenuItem msMaterialCad;
    private System.Windows.Forms.ToolStripMenuItem msMateriaPrimaCad;
    private LmCorbieUI.Controls.LmDropdownMenu msMenuDesenho;
    private System.Windows.Forms.ToolStripMenuItem msCriarDesenho;
    private System.Windows.Forms.ToolStripMenuItem msAtualizarDesenho;
    private LmCorbieUI.Controls.LmPanel pnlMain;
    private LmCorbieUI.Controls.LmPanel msMenu;
    private LmCorbieUI.Controls.LmMenuItem msCadastros;
  }
}
