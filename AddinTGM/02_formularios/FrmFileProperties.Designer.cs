namespace AddinTGM
{
    partial class FrmFileProperties
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFileProperties));
      this.btnClose = new LmCorbieUI.Controls.LmButton();
      this.btnSalvar = new LmCorbieUI.Controls.LmButton();
      this.cmxLabel6 = new LmCorbieUI.Controls.LmLabel();
      this.cmxToolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.btnCarregar = new LmCorbieUI.Controls.LmButton();
      this.dtpDataDesenho = new LmCorbieUI.Controls.LmTextBox();
      this.cmbResponsavel = new LmCorbieUI.Controls.LmTextBox();
      this.cmbProjetista = new LmCorbieUI.Controls.LmTextBox();
      this.cmxGroupBox1 = new LmCorbieUI.Controls.LmGroupBox();
      this.rdbPasta = new LmCorbieUI.Controls.LmRadioButton();
      this.txtNome = new LmCorbieUI.Controls.LmTextBox();
      this.rdbNome = new LmCorbieUI.Controls.LmRadioButton();
      this.cmxLabel4 = new LmCorbieUI.Controls.LmLabel();
      this.cmxLabel1 = new LmCorbieUI.Controls.LmLabel();
      this.cmxLabel2 = new LmCorbieUI.Controls.LmLabel();
      this.txtCodigo = new LmCorbieUI.Controls.LmTextBox();
      this.lmLabel1 = new LmCorbieUI.Controls.LmLabel();
      this.lblCaractere = new LmCorbieUI.Controls.LmLabel();
      this.txtConjunto = new LmCorbieUI.Controls.LmTextBox();
      this.lmLabel2 = new LmCorbieUI.Controls.LmLabel();
      this.cmxGroupBox1.SuspendLayout();
      this.SuspendLayout();
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
      this.btnClose.Location = new System.Drawing.Point(313, 24);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(31, 31);
      this.btnClose.TabIndex = 2;
      this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.cmxToolTip1.SetToolTip(this.btnClose, "Fechar Janela");
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
      this.btnSalvar.Location = new System.Drawing.Point(42, 24);
      this.btnSalvar.Margin = new System.Windows.Forms.Padding(1);
      this.btnSalvar.Name = "btnSalvar";
      this.btnSalvar.Size = new System.Drawing.Size(31, 31);
      this.btnSalvar.TabIndex = 1;
      this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.cmxToolTip1.SetToolTip(this.btnSalvar, "Aplicar Propriedades");
      this.btnSalvar.UseVisualStyleBackColor = false;
      this.btnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
      // 
      // cmxLabel6
      // 
      this.cmxLabel6.AutoSize = true;
      this.cmxLabel6.Dock = System.Windows.Forms.DockStyle.Top;
      this.cmxLabel6.FontWeight = LmCorbieUI.Design.LmLabelWeight.Bold;
      this.cmxLabel6.Location = new System.Drawing.Point(0, 0);
      this.cmxLabel6.Margin = new System.Windows.Forms.Padding(3);
      this.cmxLabel6.Name = "cmxLabel6";
      this.cmxLabel6.Size = new System.Drawing.Size(204, 19);
      this.cmxLabel6.TabIndex = 71;
      this.cmxLabel6.Text = "Propriedades Personalizadas";
      // 
      // btnCarregar
      // 
      this.btnCarregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btnCarregar.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnCarregar.BorderRadius = 15;
      this.btnCarregar.BorderSize = 0;
      this.btnCarregar.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnCarregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCarregar.Image = ((System.Drawing.Image)(resources.GetObject("btnCarregar.Image")));
      this.btnCarregar.Location = new System.Drawing.Point(9, 24);
      this.btnCarregar.Margin = new System.Windows.Forms.Padding(1);
      this.btnCarregar.Name = "btnCarregar";
      this.btnCarregar.Size = new System.Drawing.Size(31, 31);
      this.btnCarregar.TabIndex = 0;
      this.cmxToolTip1.SetToolTip(this.btnCarregar, "Carregar Dados Padrão");
      this.btnCarregar.UseVisualStyleBackColor = false;
      this.btnCarregar.Click += new System.EventHandler(this.BtnCarregar_Click);
      // 
      // dtpDataDesenho
      // 
      this.dtpDataDesenho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.dtpDataDesenho.BorderRadius = 15;
      this.dtpDataDesenho.BorderSize = 2;
      this.dtpDataDesenho.F7ToolTipText = null;
      this.dtpDataDesenho.F8ToolTipText = null;
      this.dtpDataDesenho.F9ToolTipText = null;
      this.dtpDataDesenho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.dtpDataDesenho.IconF7 = ((System.Drawing.Image)(resources.GetObject("dtpDataDesenho.IconF7")));
      this.dtpDataDesenho.IconToolTipText = null;
      this.dtpDataDesenho.Lines = new string[0];
      this.dtpDataDesenho.Location = new System.Drawing.Point(145, 273);
      this.dtpDataDesenho.MaxLength = 32767;
      this.dtpDataDesenho.Name = "dtpDataDesenho";
      this.dtpDataDesenho.PasswordChar = '\0';
      this.dtpDataDesenho.Propriedade = null;
      this.dtpDataDesenho.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.dtpDataDesenho.SelectedText = "";
      this.dtpDataDesenho.SelectionLength = 0;
      this.dtpDataDesenho.SelectionStart = 0;
      this.dtpDataDesenho.ShortcutsEnabled = true;
      this.dtpDataDesenho.ShowButtonF7 = true;
      this.dtpDataDesenho.Size = new System.Drawing.Size(130, 31);
      this.dtpDataDesenho.TabIndex = 7;
      this.dtpDataDesenho.UnderlinedStyle = false;
      this.dtpDataDesenho.UseSelectable = true;
      this.dtpDataDesenho.Valor = LmCorbieUI.Design.LmValueType.Data;
      this.dtpDataDesenho.Valor_Decimais = ((short)(0));
      this.dtpDataDesenho.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.dtpDataDesenho.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
      // 
      // cmbResponsavel
      // 
      this.cmbResponsavel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cmbResponsavel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.cmbResponsavel.BorderRadius = 15;
      this.cmbResponsavel.BorderSize = 2;
      this.cmbResponsavel.F7ToolTipText = null;
      this.cmbResponsavel.F8ToolTipText = null;
      this.cmbResponsavel.F9ToolTipText = null;
      this.cmbResponsavel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.cmbResponsavel.IconF7 = ((System.Drawing.Image)(resources.GetObject("cmbResponsavel.IconF7")));
      this.cmbResponsavel.IconToolTipText = null;
      this.cmbResponsavel.Lines = new string[0];
      this.cmbResponsavel.Location = new System.Drawing.Point(6, 218);
      this.cmbResponsavel.MaxLength = 32767;
      this.cmbResponsavel.Name = "cmbResponsavel";
      this.cmbResponsavel.PasswordChar = '\0';
      this.cmbResponsavel.Propriedade = null;
      this.cmbResponsavel.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.cmbResponsavel.SelectedText = "";
      this.cmbResponsavel.SelectionLength = 0;
      this.cmbResponsavel.SelectionStart = 0;
      this.cmbResponsavel.ShortcutsEnabled = true;
      this.cmbResponsavel.Size = new System.Drawing.Size(338, 31);
      this.cmbResponsavel.TabIndex = 5;
      this.cmbResponsavel.UnderlinedStyle = false;
      this.cmbResponsavel.UseSelectable = true;
      this.cmbResponsavel.Valor_Decimais = ((short)(0));
      this.cmbResponsavel.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.cmbResponsavel.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
      // 
      // cmbProjetista
      // 
      this.cmbProjetista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cmbProjetista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.cmbProjetista.BorderRadius = 15;
      this.cmbProjetista.BorderSize = 2;
      this.cmbProjetista.F7ToolTipText = null;
      this.cmbProjetista.F8ToolTipText = null;
      this.cmbProjetista.F9ToolTipText = null;
      this.cmbProjetista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.cmbProjetista.IconF7 = ((System.Drawing.Image)(resources.GetObject("cmbProjetista.IconF7")));
      this.cmbProjetista.IconToolTipText = null;
      this.cmbProjetista.Lines = new string[0];
      this.cmbProjetista.Location = new System.Drawing.Point(6, 162);
      this.cmbProjetista.MaxLength = 32767;
      this.cmbProjetista.Name = "cmbProjetista";
      this.cmbProjetista.PasswordChar = '\0';
      this.cmbProjetista.Propriedade = null;
      this.cmbProjetista.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.cmbProjetista.SelectedText = "";
      this.cmbProjetista.SelectionLength = 0;
      this.cmbProjetista.SelectionStart = 0;
      this.cmbProjetista.ShortcutsEnabled = true;
      this.cmbProjetista.Size = new System.Drawing.Size(338, 31);
      this.cmbProjetista.TabIndex = 4;
      this.cmbProjetista.UnderlinedStyle = false;
      this.cmbProjetista.UseSelectable = true;
      this.cmbProjetista.Valor_Decimais = ((short)(0));
      this.cmbProjetista.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.cmbProjetista.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
      // 
      // cmxGroupBox1
      // 
      this.cmxGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cmxGroupBox1.Controls.Add(this.rdbPasta);
      this.cmxGroupBox1.Controls.Add(this.txtNome);
      this.cmxGroupBox1.Controls.Add(this.rdbNome);
      this.cmxGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
      this.cmxGroupBox1.Location = new System.Drawing.Point(3, 312);
      this.cmxGroupBox1.Name = "cmxGroupBox1";
      this.cmxGroupBox1.Size = new System.Drawing.Size(344, 90);
      this.cmxGroupBox1.TabIndex = 8;
      this.cmxGroupBox1.TabStop = false;
      this.cmxGroupBox1.Text = "Atualizar Somente";
      // 
      // rdbPasta
      // 
      this.rdbPasta.AutoSize = true;
      this.rdbPasta.Checked = true;
      this.rdbPasta.Location = new System.Drawing.Point(6, 25);
      this.rdbPasta.Name = "rdbPasta";
      this.rdbPasta.Size = new System.Drawing.Size(189, 15);
      this.rdbPasta.TabIndex = 0;
      this.rdbPasta.TabStop = true;
      this.rdbPasta.Text = "Na Mesma Pasta da Montagem";
      this.rdbPasta.UseSelectable = true;
      // 
      // txtNome
      // 
      this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtNome.BorderRadius = 15;
      this.txtNome.BorderSize = 2;
      this.txtNome.F7ToolTipText = null;
      this.txtNome.F8ToolTipText = null;
      this.txtNome.F9ToolTipText = null;
      this.txtNome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtNome.IconF7 = null;
      this.txtNome.IconToolTipText = null;
      this.txtNome.Lines = new string[0];
      this.txtNome.Location = new System.Drawing.Point(144, 49);
      this.txtNome.MaxLength = 32767;
      this.txtNome.Name = "txtNome";
      this.txtNome.PasswordChar = '\0';
      this.txtNome.Propriedade = null;
      this.txtNome.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtNome.SelectedText = "";
      this.txtNome.SelectionLength = 0;
      this.txtNome.SelectionStart = 0;
      this.txtNome.ShortcutsEnabled = true;
      this.txtNome.Size = new System.Drawing.Size(194, 31);
      this.txtNome.TabIndex = 0;
      this.txtNome.UnderlinedStyle = false;
      this.txtNome.UseSelectable = true;
      this.txtNome.Valor_Decimais = ((short)(0));
      this.txtNome.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtNome.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
      // 
      // rdbNome
      // 
      this.rdbNome.AutoSize = true;
      this.rdbNome.Location = new System.Drawing.Point(6, 57);
      this.rdbNome.Name = "rdbNome";
      this.rdbNome.Size = new System.Drawing.Size(132, 15);
      this.rdbNome.TabIndex = 1;
      this.rdbNome.Text = "Nome Começa Com";
      this.rdbNome.UseSelectable = true;
      // 
      // cmxLabel4
      // 
      this.cmxLabel4.AutoSize = true;
      this.cmxLabel4.Location = new System.Drawing.Point(6, 143);
      this.cmxLabel4.Margin = new System.Windows.Forms.Padding(3);
      this.cmxLabel4.Name = "cmxLabel4";
      this.cmxLabel4.Size = new System.Drawing.Size(66, 19);
      this.cmxLabel4.TabIndex = 77;
      this.cmxLabel4.Text = "Projetista";
      this.cmxLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // cmxLabel1
      // 
      this.cmxLabel1.AutoSize = true;
      this.cmxLabel1.Location = new System.Drawing.Point(6, 199);
      this.cmxLabel1.Margin = new System.Windows.Forms.Padding(3);
      this.cmxLabel1.Name = "cmxLabel1";
      this.cmxLabel1.Size = new System.Drawing.Size(84, 19);
      this.cmxLabel1.TabIndex = 78;
      this.cmxLabel1.Text = "Responsavel";
      this.cmxLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // cmxLabel2
      // 
      this.cmxLabel2.AutoSize = true;
      this.cmxLabel2.Location = new System.Drawing.Point(145, 254);
      this.cmxLabel2.Margin = new System.Windows.Forms.Padding(3);
      this.cmxLabel2.Name = "cmxLabel2";
      this.cmxLabel2.Size = new System.Drawing.Size(96, 19);
      this.cmxLabel2.TabIndex = 80;
      this.cmxLabel2.Text = "Data Desenho";
      this.cmxLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtCodigo
      // 
      this.txtCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtCodigo.BorderRadius = 15;
      this.txtCodigo.BorderSize = 2;
      this.txtCodigo.F7ToolTipText = null;
      this.txtCodigo.F8ToolTipText = null;
      this.txtCodigo.F9ToolTipText = null;
      this.txtCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtCodigo.IconF7 = ((System.Drawing.Image)(resources.GetObject("txtCodigo.IconF7")));
      this.txtCodigo.IconToolTipText = null;
      this.txtCodigo.Lines = new string[0];
      this.txtCodigo.Location = new System.Drawing.Point(6, 273);
      this.txtCodigo.MaxLength = 32767;
      this.txtCodigo.Name = "txtCodigo";
      this.txtCodigo.PasswordChar = '\0';
      this.txtCodigo.Propriedade = null;
      this.txtCodigo.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtCodigo.SelectedText = "";
      this.txtCodigo.SelectionLength = 0;
      this.txtCodigo.SelectionStart = 0;
      this.txtCodigo.ShortcutsEnabled = true;
      this.txtCodigo.Size = new System.Drawing.Size(130, 31);
      this.txtCodigo.TabIndex = 6;
      this.txtCodigo.UnderlinedStyle = false;
      this.txtCodigo.UseSelectable = true;
      this.txtCodigo.Valor_Decimais = ((short)(0));
      this.txtCodigo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtCodigo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
      // 
      // lmLabel1
      // 
      this.lmLabel1.AutoSize = true;
      this.lmLabel1.Location = new System.Drawing.Point(6, 254);
      this.lmLabel1.Margin = new System.Windows.Forms.Padding(3);
      this.lmLabel1.Name = "lmLabel1";
      this.lmLabel1.Size = new System.Drawing.Size(101, 19);
      this.lmLabel1.TabIndex = 82;
      this.lmLabel1.Text = "Código Projeto";
      this.lmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblCaractere
      // 
      this.lblCaractere.AutoSize = true;
      this.lblCaractere.Location = new System.Drawing.Point(6, 117);
      this.lblCaractere.Margin = new System.Windows.Forms.Padding(3);
      this.lblCaractere.Name = "lblCaractere";
      this.lblCaractere.Size = new System.Drawing.Size(66, 19);
      this.lblCaractere.TabIndex = 83;
      this.lblCaractere.Text = "Projetista";
      this.lblCaractere.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtConjunto
      // 
      this.txtConjunto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtConjunto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtConjunto.BorderRadius = 15;
      this.txtConjunto.BorderSize = 2;
      this.txtConjunto.F7ToolTipText = null;
      this.txtConjunto.F8ToolTipText = null;
      this.txtConjunto.F9ToolTipText = null;
      this.txtConjunto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtConjunto.IconF7 = ((System.Drawing.Image)(resources.GetObject("txtConjunto.IconF7")));
      this.txtConjunto.IconToolTipText = null;
      this.txtConjunto.Lines = new string[0];
      this.txtConjunto.Location = new System.Drawing.Point(6, 87);
      this.txtConjunto.MaxLength = 50;
      this.txtConjunto.Name = "txtConjunto";
      this.txtConjunto.PasswordChar = '\0';
      this.txtConjunto.Propriedade = null;
      this.txtConjunto.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtConjunto.SelectedText = "";
      this.txtConjunto.SelectionLength = 0;
      this.txtConjunto.SelectionStart = 0;
      this.txtConjunto.ShortcutsEnabled = true;
      this.txtConjunto.Size = new System.Drawing.Size(338, 31);
      this.txtConjunto.TabIndex = 3;
      this.txtConjunto.UnderlinedStyle = false;
      this.txtConjunto.UseSelectable = true;
      this.txtConjunto.Valor_Decimais = ((short)(0));
      this.txtConjunto.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtConjunto.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
      this.txtConjunto.TextChanged += new System.EventHandler(this.TxtConjunto_TextChanged);
      // 
      // lmLabel2
      // 
      this.lmLabel2.AutoSize = true;
      this.lmLabel2.Location = new System.Drawing.Point(6, 68);
      this.lmLabel2.Margin = new System.Windows.Forms.Padding(3);
      this.lmLabel2.Name = "lmLabel2";
      this.lmLabel2.Size = new System.Drawing.Size(58, 19);
      this.lmLabel2.TabIndex = 85;
      this.lmLabel2.Text = "Conjuto";
      this.lmLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // FrmFileProperties
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(350, 450);
      this.Controls.Add(this.btnCarregar);
      this.Controls.Add(this.lmLabel2);
      this.Controls.Add(this.txtConjunto);
      this.Controls.Add(this.txtCodigo);
      this.Controls.Add(this.lmLabel1);
      this.Controls.Add(this.dtpDataDesenho);
      this.Controls.Add(this.cmbResponsavel);
      this.Controls.Add(this.cmbProjetista);
      this.Controls.Add(this.cmxGroupBox1);
      this.Controls.Add(this.cmxLabel4);
      this.Controls.Add(this.cmxLabel1);
      this.Controls.Add(this.cmxLabel2);
      this.Controls.Add(this.cmxLabel6);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.btnSalvar);
      this.Controls.Add(this.lblCaractere);
      this.Name = "FrmFileProperties";
      this.Padding = new System.Windows.Forms.Padding(0);
      this.Text = "FrmFileProperties";
      this.Loaded += new LmCorbieUI.LmForms.LmChildForm.FormLoad(this.FrmFileProperties_Loaded);
      this.Load += new System.EventHandler(this.FrmFileProperties_Load);
      this.cmxGroupBox1.ResumeLayout(false);
      this.cmxGroupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private LmCorbieUI.Controls.LmButton btnClose;
        private LmCorbieUI.Controls.LmButton btnSalvar;
        private LmCorbieUI.Controls.LmLabel cmxLabel6;
        private System.Windows.Forms.ToolTip cmxToolTip1;
        private LmCorbieUI.Controls.LmTextBox dtpDataDesenho;
        private LmCorbieUI.Controls.LmTextBox cmbResponsavel;
        private LmCorbieUI.Controls.LmTextBox cmbProjetista;
        private LmCorbieUI.Controls.LmGroupBox cmxGroupBox1;
        private LmCorbieUI.Controls.LmRadioButton rdbPasta;
        private LmCorbieUI.Controls.LmTextBox txtNome;
        private LmCorbieUI.Controls.LmRadioButton rdbNome;
        private LmCorbieUI.Controls.LmLabel cmxLabel4;
        private LmCorbieUI.Controls.LmLabel cmxLabel1;
        private LmCorbieUI.Controls.LmLabel cmxLabel2;
        private LmCorbieUI.Controls.LmTextBox txtCodigo;
        private LmCorbieUI.Controls.LmLabel lmLabel1;
        private LmCorbieUI.Controls.LmLabel lblCaractere;
        private LmCorbieUI.Controls.LmTextBox txtConjunto;
        private LmCorbieUI.Controls.LmLabel lmLabel2;
        private LmCorbieUI.Controls.LmButton btnCarregar;
    }
}