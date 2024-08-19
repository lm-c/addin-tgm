﻿using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Document = iTextSharp.text.Document;
using LmCorbieUI.LmForms;
using LmCorbieUI;

namespace AddinTGM {
  public partial class FrmPastaMaquinas : LmChildForm {
    public SldWorks swApp = new SldWorks();
    ModelDoc2 swModel = default(ModelDoc2);
    ModelDocExtension swModelDocExt;
    CustomPropertyManager swCustPropMngr = default(CustomPropertyManager);

    List<DrawExport> _dadosDraw = new List<DrawExport>();

    string _pastaPdf = "";

    public FrmPastaMaquinas() {
      InitializeComponent();

      _dadosDraw = new List<DrawExport>();

      dgv.Grid.DataSource = _dadosDraw;

      FormatarGrid();
    }

    private void Btn_MouseEnter(object sender, EventArgs e) {
      int qtdPontos = 33;

      var cor = (Color)((Label)sender).Tag;

      int red = ((cor.R - qtdPontos > 0) ? (cor.R - qtdPontos) : 0);
      int green = ((cor.G - qtdPontos > 0) ? (cor.G - qtdPontos) : 0);
      int blue = ((cor.B - qtdPontos > 0) ? (cor.B - qtdPontos) : 0);

      cor = Color.FromArgb(red, green, blue);

      ((Label)sender).BackColor = cor;
    }

    private void Btn_MouseLeave(object sender, EventArgs e) {
      var cor = (Color)((Label)sender).Tag;
      ((Label)sender).BackColor = cor;
    }

    private void BtnRefresh_Click(object sender, EventArgs e) {
      try {
        if (swApp.ActiveDoc == null) {
          MsgBox.Show($"Sem documentos abertos", "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Information);
          return;
        }

        swModel = (ModelDoc2)swApp.ActiveDoc;

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocDRAWING) {
          MsgBox.Show($"Comando Apenas para Montagem", "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Information);
          return;
        }

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocASSEMBLY) {
          MsgBox.ShowWaitMessage("Lendo componentes da montagem...");

          CarregarPastaPDFs();

          string nomeListaPecas = $@"{_pastaPdf}LISTA DE PECAS.PDF";
          _dadosDraw = DrawExport.GetDrawing(nomeListaPecas, gerarTodaHierarquia: true);

          dgv.Grid.DataSource = _dadosDraw;

          FormatarGrid();

          string pathName = swModel.GetPathName();
          string shortName = Path.GetFileNameWithoutExtension(pathName);

          if (!Directory.Exists(_pastaPdf))
            Directory.CreateDirectory(_pastaPdf);
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao carregar desenhos\n\n{ex.Message}", "Addin LM Projetos",
           MessageBoxButtons.OK, MessageBoxIcon.Error);
      } finally {
        MsgBox.CloseWaitMessage();
      }
    }

    private void BtnGerarPasta_Click(object sender, EventArgs e) {
      if (_dadosDraw.Count == 0) return;

      string targetPDF = "";

      try {
        MsgBox.ShowWaitMessage("Gerando Pasta Máquinas...");

        var pathName = swModel.GetPathName();

        targetPDF = $@"{_pastaPdf}000_{Path.GetFileNameWithoutExtension(pathName)} MONTAGEM GERAL.PDF";

        using (FileStream stream = new FileStream(targetPDF, FileMode.Create)) {
          Document pdfDoc = new Document(PageSize.A4);
          PdfCopy pdf = new PdfCopy(pdfDoc, stream);
          pdfDoc.Open();

          var files = Directory.GetFiles(_pastaPdf);

          foreach (DrawExport draw in _dadosDraw) {
            if (!draw.Exportar)
              continue;

            var name = Path.GetFileNameWithoutExtension(draw.PathName);

            var file = files.FirstOrDefault(x => Path.GetFileNameWithoutExtension(x) == name);

            if (file != null)
              pdf.AddDocument(new PdfReader(file));
          }

          pdf.Close();
          pdf.Dispose();
          pdfDoc.Close();
          pdfDoc.Dispose();
        }

        if (File.Exists(targetPDF) && MsgBox.Show("Pasta de montagem de máquinas gerada com sucesso!\r\n" +
            "Gostaria de abrir o PDF agora?",
            "Sucesso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
          Process.Start(targetPDF);

        if (MsgBox.Show("Deseja Enviar os PDFs para a pasta do PCP?",
            "Sucesso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
          Config.Carregar();

          var files = Directory.GetFiles(_pastaPdf);

          List<string> enviados = new List<string>();

          foreach (DrawExport draw in _dadosDraw) {
            if (enviados.Any(x => x == draw.CodComponente) || !draw.Exportar || string.IsNullOrEmpty(draw.CodProduto))
              continue;

            var name = Path.GetFileNameWithoutExtension(draw.PathName);

            var file = files.FirstOrDefault(x => Path.GetFileNameWithoutExtension(x) == name);

            if (file != null) {
              var origem = file;
              var destino = $"{Config.model.LocalDesenhosPCP}\\{draw.CodProduto} - {Path.GetFileName(origem)}";

              File.Copy(origem, destino, overwrite: true);

              enviados.Add(draw.CodComponente);
            }
          }

          Process.Start("explorer.exe", Config.model.LocalDesenhosPCP);

          MsgBox.Show("PDFs para PCP gerados com sucesso!",
              "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao mesclar PDF da montagem\n\n{ex.Message}", "Addin LM Projetos",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
      } finally {
        MsgBox.CloseWaitMessage();
        GC.SuppressFinalize(targetPDF);
        GC.Collect();
      }
    }

    private void BtnSair_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void Dgv_CellEnter(object sender, DataGridViewCellEventArgs e) {
      try {
        if (sender != null && _dadosDraw.Count > 0) {
          lblPercDesenho.Text = $"{(dgv.Grid.CurrentRow.Index + 1)} de {dgv.Grid.RowCount} - " +
              $"{(((dgv.Grid.CurrentRow.Index + 1) * 100) / dgv.Grid.RowCount)}%";
        }
      } catch (Exception) {

      }
    }

    private void FormatarGrid() {
      dgv.Grid.Columns["Exportar"].Width = 30;
      dgv.Grid.Columns["CodComponente"].Width = 80;
      dgv.Grid.Columns["CodComponente"].Width = 250;

      dgv.Grid.Columns["Exportar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.Grid.Columns["Exportar"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.Grid.Columns["CodComponente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.Grid.Columns["CodComponente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

      dgv.Grid.ReadOnly = false;
      dgv.Grid.Columns["CodComponente"].ReadOnly = true;
      dgv.Grid.Columns["Denominacao"].ReadOnly = true;
      dgv.Grid.Columns["NomeComponente"].ReadOnly = true;
    }

    private void CarregarPastaPDFs() {
      _pastaPdf = DrawExport.GetFolder("-" + DateTime.Now.Year.ToString().Substring(2, 2) + "_PDF", swModel);

      if (!Directory.Exists(_pastaPdf))
        Directory.CreateDirectory(_pastaPdf);
    }

    private void TsmSelectAll_Click(object sender, EventArgs e) {
      foreach (DataGridViewRow row in dgv.Grid.Rows)
        row.Cells[0].Value = true;
    }

    private void TsmUnselectAll_Click(object sender, EventArgs e) {
      foreach (DataGridViewRow row in dgv.Grid.Rows)
        row.Cells[0].Value = false;
    }

    private void TsmOpen3D_Click(object sender, EventArgs e) {
      try {
        string fileName = "", openFileNamePart = "", openFileNameAssembly = "";
        int status = 0;
        int warnings = 0;
        fileName = ((DrawExport)dgv.Grid.CurrentRow.DataBoundItem).PathName;

        openFileNamePart = fileName.Replace("SLDDRW", "SLDPRT");
        openFileNameAssembly = fileName.Replace("SLDDRW", "SLDASM");


        if (File.Exists(openFileNamePart)) {
          swApp.OpenDoc6(openFileNamePart, (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref status, ref warnings);
          int errors = 0;
          swApp.ActivateDoc2(openFileNamePart, false, (int)errors);
        } else if (File.Exists(openFileNameAssembly)) {
          swApp.OpenDoc6(openFileNameAssembly, (int)swDocumentTypes_e.swDocASSEMBLY, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref status, ref warnings);
          int errors = 0;
          swApp.ActivateDoc2(openFileNameAssembly, false, (int)errors);
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao abrir arquivo 3D\n\n{ex.Message}", "Addin LM Projetos",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void TsmOpen2D_Click(object sender, EventArgs e) {
      try {
        string fileName = "";
        int status = 0;
        int warnings = 0;
        fileName = ((DrawExport)dgv.Grid.CurrentRow.DataBoundItem).PathName;


        if (File.Exists(fileName)) {
          swApp.OpenDoc6(fileName, (int)swDocumentTypes_e.swDocDRAWING, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref status, ref warnings);
          int errors = 0;
          swApp.ActivateDoc2(fileName, false, (int)errors);
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao abrir arquivo 2D\n\n{ex.Message}", "Addin LM Projetos",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
  }
}
