namespace AddinTGM {
  partial class FrmMaterialCad {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialCad));
      this.txtID = new LmCorbieUI.Controls.LmTextBox();
      this.btnSalvar = new LmCorbieUI.Controls.LmButton();
      this.btnNovo = new LmCorbieUI.Controls.LmButton();
      this.btnExcluir = new LmCorbieUI.Controls.LmButton();
      this.lblID = new LmCorbieUI.Controls.LmLabel();
      this.lblNome = new LmCorbieUI.Controls.LmLabel();
      this.txtDescricao = new LmCorbieUI.Controls.LmTextBox();
      this.btnUpload = new LmCorbieUI.Controls.LmButton();
      this.SuspendLayout();
      // 
      // txtID
      // 
      this.txtID.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.txtID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtID.BorderRadius = 15;
      this.txtID.BorderSize = 2;
      this.txtID.F7ToolTipText = "Pesquisar [F7]";
      this.txtID.F8ToolTipText = "Item Anterior [F8]";
      this.txtID.F9ToolTipText = "Próximo Item [F9]";
      this.txtID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtID.IconF7 = ((System.Drawing.Image)(resources.GetObject("txtID.IconF7")));
      this.txtID.IconF8 = ((System.Drawing.Image)(resources.GetObject("txtID.IconF8")));
      this.txtID.IconF9 = ((System.Drawing.Image)(resources.GetObject("txtID.IconF9")));
      this.txtID.IconToolTipText = null;
      this.txtID.Lines = new string[0];
      this.txtID.Location = new System.Drawing.Point(143, 60);
      this.txtID.MaxLength = 32767;
      this.txtID.Name = "txtID";
      this.txtID.PasswordChar = '\0';
      this.txtID.Propriedade = "ID";
      this.txtID.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtID.SelectedText = "";
      this.txtID.SelectionLength = 0;
      this.txtID.SelectionStart = 0;
      this.txtID.ShortcutsEnabled = true;
      this.txtID.ShowButtonF7 = true;
      this.txtID.Size = new System.Drawing.Size(185, 30);
      this.txtID.TabIndex = 0;
      this.txtID.UnderlinedStyle = false;
      this.txtID.UseSelectable = true;
      this.txtID.Valor = LmCorbieUI.Design.LmValueType.Num_Inteiro;
      this.txtID.Valor_Decimais = ((short)(0));
      this.txtID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
      this.txtID.ButtonClickF7 += new LmCorbieUI.Controls.LmTextBox.ButClick(this.TxtID_ButtonClickF7);
      this.txtID.Leave += new System.EventHandler(this.TxtID_Leave);
      // 
      // btnSalvar
      // 
      this.btnSalvar.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnSalvar.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnSalvar.BorderRadius = 13;
      this.btnSalvar.BorderSize = 0;
      this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
      this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnSalvar.Location = new System.Drawing.Point(143, 132);
      this.btnSalvar.Name = "btnSalvar";
      this.btnSalvar.Size = new System.Drawing.Size(100, 26);
      this.btnSalvar.TabIndex = 2;
      this.btnSalvar.Text = " &Salvar";
      this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btnSalvar.UseVisualStyleBackColor = false;
      this.btnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
      // 
      // btnNovo
      // 
      this.btnNovo.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.btnNovo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnNovo.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnNovo.BorderRadius = 13;
      this.btnNovo.BorderSize = 0;
      this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
      this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnNovo.Location = new System.Drawing.Point(249, 132);
      this.btnNovo.Name = "btnNovo";
      this.btnNovo.Size = new System.Drawing.Size(100, 26);
      this.btnNovo.TabIndex = 3;
      this.btnNovo.Text = " &Limpar";
      this.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btnNovo.UseVisualStyleBackColor = false;
      this.btnNovo.Click += new System.EventHandler(this.BtnLimpar_Click);
      // 
      // btnExcluir
      // 
      this.btnExcluir.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.btnExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnExcluir.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnExcluir.BorderRadius = 13;
      this.btnExcluir.BorderSize = 0;
      this.btnExcluir.Enabled = false;
      this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
      this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnExcluir.Location = new System.Drawing.Point(143, 164);
      this.btnExcluir.Name = "btnExcluir";
      this.btnExcluir.Size = new System.Drawing.Size(100, 26);
      this.btnExcluir.TabIndex = 108;
      this.btnExcluir.Text = " E&xcluir";
      this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btnExcluir.UseVisualStyleBackColor = false;
      this.btnExcluir.Visible = false;
      this.btnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
      // 
      // lblID
      // 
      this.lblID.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.lblID.BackColor = System.Drawing.Color.Transparent;
      this.lblID.Location = new System.Drawing.Point(42, 66);
      this.lblID.Margin = new System.Windows.Forms.Padding(3);
      this.lblID.Name = "lblID";
      this.lblID.Size = new System.Drawing.Size(95, 19);
      this.lblID.TabIndex = 110;
      this.lblID.Text = "Código";
      this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lblNome
      // 
      this.lblNome.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.lblNome.BackColor = System.Drawing.Color.Transparent;
      this.lblNome.Location = new System.Drawing.Point(42, 102);
      this.lblNome.Margin = new System.Windows.Forms.Padding(3);
      this.lblNome.Name = "lblNome";
      this.lblNome.Size = new System.Drawing.Size(95, 19);
      this.lblNome.TabIndex = 111;
      this.lblNome.Text = "Descrição *";
      this.lblNome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txtDescricao
      // 
      this.txtDescricao.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.txtDescricao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtDescricao.BorderRadius = 15;
      this.txtDescricao.BorderSize = 2;
      this.txtDescricao.CampoObrigatorio = true;
      this.txtDescricao.F7ToolTipText = null;
      this.txtDescricao.F8ToolTipText = null;
      this.txtDescricao.F9ToolTipText = null;
      this.txtDescricao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtDescricao.IconF7 = null;
      this.txtDescricao.IconToolTipText = null;
      this.txtDescricao.Lines = new string[0];
      this.txtDescricao.Location = new System.Drawing.Point(143, 96);
      this.txtDescricao.MaxLength = 250;
      this.txtDescricao.Name = "txtDescricao";
      this.txtDescricao.PasswordChar = '\0';
      this.txtDescricao.Propriedade = "Descricao";
      this.txtDescricao.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtDescricao.SelectedText = "";
      this.txtDescricao.SelectionLength = 0;
      this.txtDescricao.SelectionStart = 0;
      this.txtDescricao.ShortcutsEnabled = true;
      this.txtDescricao.Size = new System.Drawing.Size(450, 30);
      this.txtDescricao.TabIndex = 1;
      this.txtDescricao.UnderlinedStyle = false;
      this.txtDescricao.UseSelectable = true;
      this.txtDescricao.Valor_Decimais = ((short)(0));
      this.txtDescricao.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtDescricao.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
      // 
      // btnUpload
      // 
      this.btnUpload.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.btnUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnUpload.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnUpload.BorderRadius = 13;
      this.btnUpload.BorderSize = 0;
      this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnUpload.Image")));
      this.btnUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnUpload.Location = new System.Drawing.Point(249, 164);
      this.btnUpload.Name = "btnUpload";
      this.btnUpload.Size = new System.Drawing.Size(100, 26);
      this.btnUpload.TabIndex = 353;
      this.btnUpload.Text = " Upload";
      this.btnUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btnUpload.UseVisualStyleBackColor = false;
      this.btnUpload.Visible = false;
      this.btnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
      // 
      // FrmMaterialCad
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ChavePrimaria = this.txtID;
      this.ClientSize = new System.Drawing.Size(630, 199);
      this.Controls.Add(this.btnUpload);
      this.Controls.Add(this.txtID);
      this.Controls.Add(this.btnSalvar);
      this.Controls.Add(this.btnNovo);
      this.Controls.Add(this.btnExcluir);
      this.Controls.Add(this.lblID);
      this.Controls.Add(this.lblNome);
      this.Controls.Add(this.txtDescricao);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Location = new System.Drawing.Point(0, 0);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FrmMaterialCad";
      this.Resizable = false;
      this.Text = "Cadastro de Material";
      this.Load += new System.EventHandler(this.FrmMaterialCad_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private LmCorbieUI.Controls.LmTextBox txtID;
    private LmCorbieUI.Controls.LmButton btnSalvar;
    private LmCorbieUI.Controls.LmButton btnNovo;
    private LmCorbieUI.Controls.LmButton btnExcluir;
    private LmCorbieUI.Controls.LmLabel lblID;
    private LmCorbieUI.Controls.LmLabel lblNome;
    private LmCorbieUI.Controls.LmTextBox txtDescricao;
    private LmCorbieUI.Controls.LmButton btnUpload;
  }
}