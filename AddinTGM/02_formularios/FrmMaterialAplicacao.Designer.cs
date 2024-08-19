namespace AddinTGM {
  partial class FrmMaterialAplicacao {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialAplicacao));
      this.dgv = new LmCorbieUI.Controls.LmDataGridView();
      this.cmsOpenFile = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.tsmSelectAll = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmUnselectAll = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.tsmOpen3D = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmOpen2D = new System.Windows.Forms.ToolStripMenuItem();
      this.lblPercDesenho = new LmCorbieUI.Controls.LmLabel();
      this.cmxLabel6 = new LmCorbieUI.Controls.LmLabel();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.btnProximo = new LmCorbieUI.Controls.LmButton();
      this.btnVoltar = new LmCorbieUI.Controls.LmButton();
      this.btnClose = new LmCorbieUI.Controls.LmButton();
      this.btnSalvar = new LmCorbieUI.Controls.LmButton();
      this.btnCarrProcess = new LmCorbieUI.Controls.LmButton();
      this.btnUpDes = new LmCorbieUI.Controls.LmButton();
      this.btnDownDes = new LmCorbieUI.Controls.LmButton();
      this.lmPanel1 = new LmCorbieUI.Controls.LmPanel();
      this.lmLabel2 = new LmCorbieUI.Controls.LmLabel();
      this.txtDenominacao = new LmCorbieUI.Controls.LmTextBox();
      this.cmxLabel2 = new LmCorbieUI.Controls.LmLabel();
      this.lblMaterial = new LmCorbieUI.Controls.LmLabel();
      this.lblCodMat = new LmCorbieUI.Controls.LmLabel();
      this.lmLabel4 = new LmCorbieUI.Controls.LmLabel();
      this.lblttLista = new LmCorbieUI.Controls.LmLabel();
      this.lblListaCorte = new LmCorbieUI.Controls.LmLabel();
      this.lmLabel1 = new LmCorbieUI.Controls.LmLabel();
      this.lblPeso = new LmCorbieUI.Controls.LmLabel();
      this.lmLabel3 = new LmCorbieUI.Controls.LmLabel();
      this.txtMateriaPrima = new LmCorbieUI.Controls.LmTextBox();
      this.lblDescMat = new LmCorbieUI.Controls.LmLabel();
      this.lblEspess = new LmCorbieUI.Controls.LmLabel();
      this.cmxLabel3 = new LmCorbieUI.Controls.LmLabel();
      this.cmxLabel1 = new LmCorbieUI.Controls.LmLabel();
      this.ckbAddDenom = new LmCorbieUI.Controls.LmCheckBox();
      this.cmsOpenFile.SuspendLayout();
      this.lmPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // dgv
      // 
      this.dgv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
      this.dgv.Botao1Largura = 100;
      this.dgv.Botao1Texto = "";
      this.dgv.Botao2Largura = 100;
      this.dgv.Botao2Texto = "";
      this.dgv.ColunaOrdenacaoGrid = "";
      this.dgv.ColunasBloqueadasGrid = "";
      this.dgv.ColunasOcultasGrid = "";
      this.dgv.ColunasOcultasImpressGrid = "";
      this.dgv.ContextMenuStrip = this.cmsOpenFile;
      this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgv.EnabledCsvButton = true;
      this.dgv.EnabledFind = true;
      this.dgv.EnabledHideColumnsButton = true;
      this.dgv.EnabledPdfButton = true;
      this.dgv.EnabledRefreshButton = true;
      this.dgv.LimparSelecaoAposCarregar = false;
      this.dgv.Location = new System.Drawing.Point(3, 305);
      this.dgv.Margin = new System.Windows.Forms.Padding(0);
      this.dgv.MostrarRodapeBotoes = false;
      this.dgv.MostrarTotalizador = false;
      this.dgv.Name = "dgv";
      this.dgv.PermiteAutoDimensionarLinha = false;
      this.dgv.PermiteDimensionarColuna = true;
      this.dgv.PermiteOrdenarColunas = true;
      this.dgv.PermiteOrdenarLinhas = true;
      this.dgv.PermiteQuebrarLinhaCabecalho = false;
      this.dgv.PermiteSelecaoMultipla = false;
      this.dgv.PosColunasGrid = "";
      this.dgv.Size = new System.Drawing.Size(293, 174);
      this.dgv.TabIndex = 97;
      this.dgv.Texto = "";
      this.dgv.TituloRelatorio = "";
      this.dgv.UseSelectable = true;
      this.dgv.RowIndexChanged += new LmCorbieUI.Controls.LmDataGridView.RowEvent(this.Dgv_RowIndexChanged);
      // 
      // cmsOpenFile
      // 
      this.cmsOpenFile.Font = new System.Drawing.Font("Segoe UI", 12F);
      this.cmsOpenFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSelectAll,
            this.tsmUnselectAll,
            this.toolStripMenuItem2,
            this.tsmOpen3D,
            this.tsmOpen2D});
      this.cmsOpenFile.Name = "cmsOpenFile";
      this.cmsOpenFile.Size = new System.Drawing.Size(245, 114);
      // 
      // tsmSelectAll
      // 
      this.tsmSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("tsmSelectAll.Image")));
      this.tsmSelectAll.Name = "tsmSelectAll";
      this.tsmSelectAll.Size = new System.Drawing.Size(244, 26);
      this.tsmSelectAll.Text = "Selecionar Todos";
      // 
      // tsmUnselectAll
      // 
      this.tsmUnselectAll.Image = ((System.Drawing.Image)(resources.GetObject("tsmUnselectAll.Image")));
      this.tsmUnselectAll.Name = "tsmUnselectAll";
      this.tsmUnselectAll.Size = new System.Drawing.Size(244, 26);
      this.tsmUnselectAll.Text = "Remover Seleção Todos";
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(241, 6);
      // 
      // tsmOpen3D
      // 
      this.tsmOpen3D.Image = ((System.Drawing.Image)(resources.GetObject("tsmOpen3D.Image")));
      this.tsmOpen3D.Name = "tsmOpen3D";
      this.tsmOpen3D.Size = new System.Drawing.Size(244, 26);
      this.tsmOpen3D.Text = "Abrir 3D";
      // 
      // tsmOpen2D
      // 
      this.tsmOpen2D.Image = ((System.Drawing.Image)(resources.GetObject("tsmOpen2D.Image")));
      this.tsmOpen2D.Name = "tsmOpen2D";
      this.tsmOpen2D.Size = new System.Drawing.Size(244, 26);
      this.tsmOpen2D.Text = "Abrir 2D";
      // 
      // lblPercDesenho
      // 
      this.lblPercDesenho.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.lblPercDesenho.Location = new System.Drawing.Point(3, 479);
      this.lblPercDesenho.Margin = new System.Windows.Forms.Padding(3);
      this.lblPercDesenho.Name = "lblPercDesenho";
      this.lblPercDesenho.Size = new System.Drawing.Size(293, 22);
      this.lblPercDesenho.TabIndex = 95;
      this.lblPercDesenho.Text = "Peça 0 de 0";
      this.lblPercDesenho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // cmxLabel6
      // 
      this.cmxLabel6.Dock = System.Windows.Forms.DockStyle.Top;
      this.cmxLabel6.FontWeight = LmCorbieUI.Design.LmLabelWeight.Bold;
      this.cmxLabel6.Location = new System.Drawing.Point(3, 3);
      this.cmxLabel6.Margin = new System.Windows.Forms.Padding(3);
      this.cmxLabel6.Name = "cmxLabel6";
      this.cmxLabel6.Size = new System.Drawing.Size(293, 26);
      this.cmxLabel6.TabIndex = 96;
      this.cmxLabel6.Text = "Aplicação de Materiais";
      // 
      // btnProximo
      // 
      this.btnProximo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btnProximo.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnProximo.BorderRadius = 15;
      this.btnProximo.BorderSize = 0;
      this.btnProximo.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnProximo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnProximo.Image = ((System.Drawing.Image)(resources.GetObject("btnProximo.Image")));
      this.btnProximo.Location = new System.Drawing.Point(105, 214);
      this.btnProximo.Margin = new System.Windows.Forms.Padding(1);
      this.btnProximo.Name = "btnProximo";
      this.btnProximo.Size = new System.Drawing.Size(31, 31);
      this.btnProximo.TabIndex = 6;
      this.btnProximo.Tag = "Avançar";
      this.btnProximo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.toolTip1.SetToolTip(this.btnProximo, "Próxima peça");
      this.btnProximo.UseVisualStyleBackColor = false;
      this.btnProximo.Click += new System.EventHandler(this.BtnProximo_Click);
      // 
      // btnVoltar
      // 
      this.btnVoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btnVoltar.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnVoltar.BorderRadius = 15;
      this.btnVoltar.BorderSize = 0;
      this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
      this.btnVoltar.Location = new System.Drawing.Point(72, 214);
      this.btnVoltar.Margin = new System.Windows.Forms.Padding(1);
      this.btnVoltar.Name = "btnVoltar";
      this.btnVoltar.Size = new System.Drawing.Size(31, 31);
      this.btnVoltar.TabIndex = 5;
      this.btnVoltar.Tag = "Voltar";
      this.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.toolTip1.SetToolTip(this.btnVoltar, "Peça anterior");
      this.btnVoltar.UseVisualStyleBackColor = false;
      this.btnVoltar.Click += new System.EventHandler(this.BtnVoltar_Click);
      // 
      // btnClose
      // 
      this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btnClose.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnClose.BorderRadius = 15;
      this.btnClose.BorderSize = 0;
      this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
      this.btnClose.Location = new System.Drawing.Point(259, 214);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(31, 31);
      this.btnClose.TabIndex = 9;
      this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.toolTip1.SetToolTip(this.btnClose, "Fechar Janela");
      this.btnClose.UseVisualStyleBackColor = false;
      this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
      // 
      // btnSalvar
      // 
      this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btnSalvar.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnSalvar.BorderRadius = 15;
      this.btnSalvar.BorderSize = 0;
      this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
      this.btnSalvar.Location = new System.Drawing.Point(36, 214);
      this.btnSalvar.Margin = new System.Windows.Forms.Padding(1);
      this.btnSalvar.Name = "btnSalvar";
      this.btnSalvar.Size = new System.Drawing.Size(31, 31);
      this.btnSalvar.TabIndex = 4;
      this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.toolTip1.SetToolTip(this.btnSalvar, "Salvar Processos");
      this.btnSalvar.UseVisualStyleBackColor = false;
      this.btnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
      // 
      // btnCarrProcess
      // 
      this.btnCarrProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btnCarrProcess.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnCarrProcess.BorderRadius = 15;
      this.btnCarrProcess.BorderSize = 0;
      this.btnCarrProcess.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnCarrProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCarrProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnCarrProcess.Image")));
      this.btnCarrProcess.Location = new System.Drawing.Point(3, 214);
      this.btnCarrProcess.Margin = new System.Windows.Forms.Padding(1);
      this.btnCarrProcess.Name = "btnCarrProcess";
      this.btnCarrProcess.Size = new System.Drawing.Size(31, 31);
      this.btnCarrProcess.TabIndex = 3;
      this.toolTip1.SetToolTip(this.btnCarrProcess, "Carregar componentes\r\npara inserir material");
      this.btnCarrProcess.UseVisualStyleBackColor = false;
      this.btnCarrProcess.Click += new System.EventHandler(this.BtnCarrProcess_Click);
      // 
      // btnUpDes
      // 
      this.btnUpDes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.btnUpDes.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnUpDes.BorderRadius = 15;
      this.btnUpDes.BorderSize = 0;
      this.btnUpDes.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnUpDes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnUpDes.Image = ((System.Drawing.Image)(resources.GetObject("btnUpDes.Image")));
      this.btnUpDes.Location = new System.Drawing.Point(171, 214);
      this.btnUpDes.Margin = new System.Windows.Forms.Padding(1);
      this.btnUpDes.Name = "btnUpDes";
      this.btnUpDes.Size = new System.Drawing.Size(31, 31);
      this.btnUpDes.TabIndex = 8;
      this.btnUpDes.Tag = "Up";
      this.btnUpDes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.toolTip1.SetToolTip(this.btnUpDes, "Lista de corte\r\nPróxima");
      this.btnUpDes.UseVisualStyleBackColor = false;
      this.btnUpDes.Click += new System.EventHandler(this.BtnUpDownDes_Click);
      // 
      // btnDownDes
      // 
      this.btnDownDes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btnDownDes.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnDownDes.BorderRadius = 15;
      this.btnDownDes.BorderSize = 0;
      this.btnDownDes.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnDownDes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnDownDes.Image = ((System.Drawing.Image)(resources.GetObject("btnDownDes.Image")));
      this.btnDownDes.Location = new System.Drawing.Point(138, 214);
      this.btnDownDes.Margin = new System.Windows.Forms.Padding(1);
      this.btnDownDes.Name = "btnDownDes";
      this.btnDownDes.Size = new System.Drawing.Size(31, 31);
      this.btnDownDes.TabIndex = 7;
      this.btnDownDes.Tag = "Down";
      this.btnDownDes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.toolTip1.SetToolTip(this.btnDownDes, "Lista de corte\r\nAnterior");
      this.btnDownDes.UseVisualStyleBackColor = false;
      this.btnDownDes.Click += new System.EventHandler(this.BtnUpDownDes_Click);
      // 
      // lmPanel1
      // 
      this.lmPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
      this.lmPanel1.Controls.Add(this.lmLabel2);
      this.lmPanel1.Controls.Add(this.txtDenominacao);
      this.lmPanel1.Controls.Add(this.cmxLabel2);
      this.lmPanel1.Controls.Add(this.lblMaterial);
      this.lmPanel1.Controls.Add(this.lblCodMat);
      this.lmPanel1.Controls.Add(this.lmLabel4);
      this.lmPanel1.Controls.Add(this.lblttLista);
      this.lmPanel1.Controls.Add(this.lblListaCorte);
      this.lmPanel1.Controls.Add(this.btnUpDes);
      this.lmPanel1.Controls.Add(this.btnDownDes);
      this.lmPanel1.Controls.Add(this.lmLabel1);
      this.lmPanel1.Controls.Add(this.lblPeso);
      this.lmPanel1.Controls.Add(this.lmLabel3);
      this.lmPanel1.Controls.Add(this.txtMateriaPrima);
      this.lmPanel1.Controls.Add(this.lblDescMat);
      this.lmPanel1.Controls.Add(this.lblEspess);
      this.lmPanel1.Controls.Add(this.cmxLabel3);
      this.lmPanel1.Controls.Add(this.cmxLabel1);
      this.lmPanel1.Controls.Add(this.btnProximo);
      this.lmPanel1.Controls.Add(this.btnVoltar);
      this.lmPanel1.Controls.Add(this.btnClose);
      this.lmPanel1.Controls.Add(this.btnSalvar);
      this.lmPanel1.Controls.Add(this.btnCarrProcess);
      this.lmPanel1.Controls.Add(this.ckbAddDenom);
      this.lmPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.lmPanel1.IsPanelMenu = false;
      this.lmPanel1.Location = new System.Drawing.Point(3, 29);
      this.lmPanel1.Name = "lmPanel1";
      this.lmPanel1.Size = new System.Drawing.Size(293, 276);
      this.lmPanel1.TabIndex = 94;
      // 
      // lmLabel2
      // 
      this.lmLabel2.BackColor = System.Drawing.Color.Transparent;
      this.lmLabel2.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lmLabel2.Location = new System.Drawing.Point(3, 163);
      this.lmLabel2.Margin = new System.Windows.Forms.Padding(3);
      this.lmLabel2.Name = "lmLabel2";
      this.lmLabel2.Size = new System.Drawing.Size(107, 15);
      this.lmLabel2.TabIndex = 66;
      this.lmLabel2.Text = "Denominação:";
      this.lmLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtDenominacao
      // 
      this.txtDenominacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtDenominacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtDenominacao.BorderRadius = 15;
      this.txtDenominacao.BorderSize = 2;
      this.txtDenominacao.F7ToolTipText = "";
      this.txtDenominacao.F8ToolTipText = null;
      this.txtDenominacao.F9ToolTipText = null;
      this.txtDenominacao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtDenominacao.IconF7 = ((System.Drawing.Image)(resources.GetObject("txtDenominacao.IconF7")));
      this.txtDenominacao.IconToolTipText = null;
      this.txtDenominacao.Lines = new string[0];
      this.txtDenominacao.Location = new System.Drawing.Point(3, 179);
      this.txtDenominacao.MaxLength = 255;
      this.txtDenominacao.Name = "txtDenominacao";
      this.txtDenominacao.PasswordChar = '\0';
      this.txtDenominacao.Propriedade = null;
      this.txtDenominacao.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtDenominacao.SelectedText = "";
      this.txtDenominacao.SelectionLength = 0;
      this.txtDenominacao.SelectionStart = 0;
      this.txtDenominacao.ShortcutsEnabled = true;
      this.txtDenominacao.Size = new System.Drawing.Size(289, 31);
      this.txtDenominacao.TabIndex = 1;
      this.txtDenominacao.UnderlinedStyle = false;
      this.txtDenominacao.UseSelectable = true;
      this.txtDenominacao.Valor_Decimais = ((short)(0));
      this.txtDenominacao.WaterMark = "Denominação do Componente";
      this.txtDenominacao.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtDenominacao.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtDenominacao.Leave += new System.EventHandler(this.TxtDenominacao_Leave);
      // 
      // cmxLabel2
      // 
      this.cmxLabel2.BackColor = System.Drawing.Color.Transparent;
      this.cmxLabel2.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.cmxLabel2.ForeColor = System.Drawing.Color.Red;
      this.cmxLabel2.Location = new System.Drawing.Point(3, 47);
      this.cmxLabel2.Margin = new System.Windows.Forms.Padding(3);
      this.cmxLabel2.Name = "cmxLabel2";
      this.cmxLabel2.Size = new System.Drawing.Size(107, 15);
      this.cmxLabel2.TabIndex = 44;
      this.cmxLabel2.Text = "Código Material:";
      this.cmxLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lblMaterial
      // 
      this.lblMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblMaterial.BackColor = System.Drawing.Color.Transparent;
      this.lblMaterial.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lblMaterial.ForeColor = System.Drawing.Color.Red;
      this.lblMaterial.Location = new System.Drawing.Point(112, 26);
      this.lblMaterial.Margin = new System.Windows.Forms.Padding(3);
      this.lblMaterial.Name = "lblMaterial";
      this.lblMaterial.Size = new System.Drawing.Size(178, 15);
      this.lblMaterial.TabIndex = 64;
      this.lblMaterial.Text = "---";
      this.lblMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblCodMat
      // 
      this.lblCodMat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblCodMat.BackColor = System.Drawing.Color.Transparent;
      this.lblCodMat.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lblCodMat.ForeColor = System.Drawing.Color.Red;
      this.lblCodMat.Location = new System.Drawing.Point(112, 47);
      this.lblCodMat.Margin = new System.Windows.Forms.Padding(3);
      this.lblCodMat.Name = "lblCodMat";
      this.lblCodMat.Size = new System.Drawing.Size(178, 15);
      this.lblCodMat.TabIndex = 47;
      this.lblCodMat.Text = "---";
      this.lblCodMat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lmLabel4
      // 
      this.lmLabel4.BackColor = System.Drawing.Color.Transparent;
      this.lmLabel4.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lmLabel4.ForeColor = System.Drawing.Color.Red;
      this.lmLabel4.Location = new System.Drawing.Point(3, 26);
      this.lmLabel4.Margin = new System.Windows.Forms.Padding(3);
      this.lmLabel4.Name = "lmLabel4";
      this.lmLabel4.Size = new System.Drawing.Size(107, 15);
      this.lmLabel4.TabIndex = 63;
      this.lmLabel4.Text = "Material:";
      this.lmLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lblttLista
      // 
      this.lblttLista.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lblttLista.Location = new System.Drawing.Point(152, 252);
      this.lblttLista.Margin = new System.Windows.Forms.Padding(3);
      this.lblttLista.Name = "lblttLista";
      this.lblttLista.Size = new System.Drawing.Size(110, 15);
      this.lblttLista.TabIndex = 62;
      this.lblttLista.Text = "Lista 0 de 0";
      this.lblttLista.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblListaCorte
      // 
      this.lblListaCorte.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lblListaCorte.Location = new System.Drawing.Point(3, 252);
      this.lblListaCorte.Margin = new System.Windows.Forms.Padding(3);
      this.lblListaCorte.Name = "lblListaCorte";
      this.lblListaCorte.Size = new System.Drawing.Size(151, 15);
      this.lblListaCorte.TabIndex = 61;
      this.lblListaCorte.Text = "Item da lista de corte1";
      this.lblListaCorte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lmLabel1
      // 
      this.lmLabel1.BackColor = System.Drawing.Color.Transparent;
      this.lmLabel1.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lmLabel1.Location = new System.Drawing.Point(3, 110);
      this.lmLabel1.Margin = new System.Windows.Forms.Padding(3);
      this.lmLabel1.Name = "lmLabel1";
      this.lmLabel1.Size = new System.Drawing.Size(107, 15);
      this.lmLabel1.TabIndex = 58;
      this.lmLabel1.Text = "Materia Prima:";
      this.lmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblPeso
      // 
      this.lblPeso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblPeso.BackColor = System.Drawing.Color.Transparent;
      this.lblPeso.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lblPeso.ForeColor = System.Drawing.Color.Red;
      this.lblPeso.Location = new System.Drawing.Point(105, 89);
      this.lblPeso.Margin = new System.Windows.Forms.Padding(3);
      this.lblPeso.Name = "lblPeso";
      this.lblPeso.Size = new System.Drawing.Size(178, 15);
      this.lblPeso.TabIndex = 57;
      this.lblPeso.Text = "0.000 kg";
      this.lblPeso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lmLabel3
      // 
      this.lmLabel3.BackColor = System.Drawing.Color.Transparent;
      this.lmLabel3.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lmLabel3.ForeColor = System.Drawing.Color.Red;
      this.lmLabel3.Location = new System.Drawing.Point(30, 89);
      this.lmLabel3.Margin = new System.Windows.Forms.Padding(3);
      this.lmLabel3.Name = "lmLabel3";
      this.lmLabel3.Size = new System.Drawing.Size(80, 15);
      this.lmLabel3.TabIndex = 56;
      this.lmLabel3.Text = "Peso:";
      this.lmLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txtMateriaPrima
      // 
      this.txtMateriaPrima.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtMateriaPrima.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtMateriaPrima.BorderRadius = 15;
      this.txtMateriaPrima.BorderSize = 2;
      this.txtMateriaPrima.F7ToolTipText = "Selecionar Materia Prima";
      this.txtMateriaPrima.F8ToolTipText = null;
      this.txtMateriaPrima.F9ToolTipText = null;
      this.txtMateriaPrima.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtMateriaPrima.IconF7 = ((System.Drawing.Image)(resources.GetObject("txtMateriaPrima.IconF7")));
      this.txtMateriaPrima.IconToolTipText = null;
      this.txtMateriaPrima.Lines = new string[0];
      this.txtMateriaPrima.Location = new System.Drawing.Point(3, 126);
      this.txtMateriaPrima.MaxLength = 32767;
      this.txtMateriaPrima.Name = "txtMateriaPrima";
      this.txtMateriaPrima.PasswordChar = '\0';
      this.txtMateriaPrima.Propriedade = null;
      this.txtMateriaPrima.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtMateriaPrima.SelectedText = "";
      this.txtMateriaPrima.SelectionLength = 0;
      this.txtMateriaPrima.SelectionStart = 0;
      this.txtMateriaPrima.ShortcutsEnabled = true;
      this.txtMateriaPrima.ShowButtonF7 = true;
      this.txtMateriaPrima.Size = new System.Drawing.Size(289, 31);
      this.txtMateriaPrima.TabIndex = 0;
      this.txtMateriaPrima.UnderlinedStyle = false;
      this.txtMateriaPrima.UseSelectable = true;
      this.txtMateriaPrima.Valor = LmCorbieUI.Design.LmValueType.ComboBox;
      this.txtMateriaPrima.Valor_Decimais = ((short)(0));
      this.txtMateriaPrima.WaterMark = "Selecionar Materia Prima";
      this.txtMateriaPrima.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtMateriaPrima.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtMateriaPrima.SelectedValueChanched += new LmCorbieUI.Controls.LmTextBox.ValChange(this.TxtMateriaPrima_SelectedValueChanched);
      // 
      // lblDescMat
      // 
      this.lblDescMat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblDescMat.BackColor = System.Drawing.Color.Transparent;
      this.lblDescMat.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lblDescMat.ForeColor = System.Drawing.Color.Red;
      this.lblDescMat.Location = new System.Drawing.Point(112, 68);
      this.lblDescMat.Margin = new System.Windows.Forms.Padding(3);
      this.lblDescMat.Name = "lblDescMat";
      this.lblDescMat.Size = new System.Drawing.Size(178, 15);
      this.lblDescMat.TabIndex = 48;
      this.lblDescMat.Text = "---";
      this.lblDescMat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblEspess
      // 
      this.lblEspess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblEspess.BackColor = System.Drawing.Color.Transparent;
      this.lblEspess.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lblEspess.ForeColor = System.Drawing.Color.Red;
      this.lblEspess.Location = new System.Drawing.Point(112, 5);
      this.lblEspess.Margin = new System.Windows.Forms.Padding(3);
      this.lblEspess.Name = "lblEspess";
      this.lblEspess.Size = new System.Drawing.Size(178, 15);
      this.lblEspess.TabIndex = 46;
      this.lblEspess.Text = "---";
      this.lblEspess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // cmxLabel3
      // 
      this.cmxLabel3.BackColor = System.Drawing.Color.Transparent;
      this.cmxLabel3.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.cmxLabel3.ForeColor = System.Drawing.Color.Red;
      this.cmxLabel3.Location = new System.Drawing.Point(3, 68);
      this.cmxLabel3.Margin = new System.Windows.Forms.Padding(3);
      this.cmxLabel3.Name = "cmxLabel3";
      this.cmxLabel3.Size = new System.Drawing.Size(107, 15);
      this.cmxLabel3.TabIndex = 45;
      this.cmxLabel3.Text = "Descrição Material:";
      this.cmxLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cmxLabel1
      // 
      this.cmxLabel1.BackColor = System.Drawing.Color.Transparent;
      this.cmxLabel1.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.cmxLabel1.ForeColor = System.Drawing.Color.Red;
      this.cmxLabel1.Location = new System.Drawing.Point(3, 5);
      this.cmxLabel1.Margin = new System.Windows.Forms.Padding(3);
      this.cmxLabel1.Name = "cmxLabel1";
      this.cmxLabel1.Size = new System.Drawing.Size(107, 15);
      this.cmxLabel1.TabIndex = 43;
      this.cmxLabel1.Text = "Esp.xLarg.xComp.:";
      this.cmxLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // ckbAddDenom
      // 
      this.ckbAddDenom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ckbAddDenom.AutoSize = true;
      this.ckbAddDenom.Checked = true;
      this.ckbAddDenom.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ckbAddDenom.Location = new System.Drawing.Point(134, 161);
      this.ckbAddDenom.Name = "ckbAddDenom";
      this.ckbAddDenom.Propriedade = null;
      this.ckbAddDenom.Size = new System.Drawing.Size(156, 19);
      this.ckbAddDenom.TabIndex = 2;
      this.ckbAddDenom.Text = "Add em Todas Config";
      this.ckbAddDenom.UseSelectable = true;
      this.ckbAddDenom.CheckedChanged += new System.EventHandler(this.CkbAddDenom_CheckedChanged);
      // 
      // FrmMaterialAplicacao
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(299, 504);
      this.Controls.Add(this.dgv);
      this.Controls.Add(this.lblPercDesenho);
      this.Controls.Add(this.lmPanel1);
      this.Controls.Add(this.cmxLabel6);
      this.Name = "FrmMaterialAplicacao";
      this.Text = "Aplicação de Materiais";
      this.Load += new System.EventHandler(this.FrmMaterialAplicacao_Load);
      this.cmsOpenFile.ResumeLayout(false);
      this.lmPanel1.ResumeLayout(false);
      this.lmPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion
    private LmCorbieUI.Controls.LmDataGridView dgv;
    private System.Windows.Forms.ContextMenuStrip cmsOpenFile;
    private System.Windows.Forms.ToolStripMenuItem tsmSelectAll;
    private System.Windows.Forms.ToolStripMenuItem tsmUnselectAll;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem tsmOpen3D;
    private System.Windows.Forms.ToolStripMenuItem tsmOpen2D;
    private LmCorbieUI.Controls.LmLabel lblPercDesenho;
    private LmCorbieUI.Controls.LmLabel cmxLabel6;
    private System.Windows.Forms.ToolTip toolTip1;
    private LmCorbieUI.Controls.LmPanel lmPanel1;
    private LmCorbieUI.Controls.LmButton btnProximo;
    private LmCorbieUI.Controls.LmButton btnVoltar;
    private LmCorbieUI.Controls.LmButton btnClose;
    private LmCorbieUI.Controls.LmButton btnSalvar;
    private LmCorbieUI.Controls.LmButton btnCarrProcess;
    private LmCorbieUI.Controls.LmTextBox txtMateriaPrima;
    private LmCorbieUI.Controls.LmLabel lblDescMat;
    private LmCorbieUI.Controls.LmLabel lblCodMat;
    private LmCorbieUI.Controls.LmLabel lblEspess;
    private LmCorbieUI.Controls.LmLabel cmxLabel3;
    private LmCorbieUI.Controls.LmLabel cmxLabel2;
    private LmCorbieUI.Controls.LmLabel cmxLabel1;
    private LmCorbieUI.Controls.LmLabel lmLabel1;
    private LmCorbieUI.Controls.LmLabel lblPeso;
    private LmCorbieUI.Controls.LmLabel lmLabel3;
    private LmCorbieUI.Controls.LmButton btnUpDes;
    private LmCorbieUI.Controls.LmButton btnDownDes;
    private LmCorbieUI.Controls.LmLabel lblttLista;
    private LmCorbieUI.Controls.LmLabel lblListaCorte;
    private LmCorbieUI.Controls.LmLabel lblMaterial;
    private LmCorbieUI.Controls.LmLabel lmLabel4;
    private LmCorbieUI.Controls.LmLabel lmLabel2;
    private LmCorbieUI.Controls.LmTextBox txtDenominacao;
    private LmCorbieUI.Controls.LmCheckBox ckbAddDenom;
  }
}