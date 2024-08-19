using LmCorbieUI;
using LmCorbieUI.LmForms;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using SolidWorks.Interop.swdocumentmgr;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AddinTGM {
  public partial class FrmCapaProjeto : LmChildForm {
    public SldWorks swApp = new SldWorks();
    ModelDoc2 swModel = default(ModelDoc2);
    string nomeCapaProjeto = string.Empty;
    public FrmCapaProjeto() {
      InitializeComponent();
    }

    private void FrmCapaProjeto_Load(object sender, EventArgs e) {
      List<Z_Padrao> comboList = new List<Z_Padrao>() {
            new Z_Padrao{Codigo = 1,  Descricao = "1 : 1"},
            new Z_Padrao{Codigo = 2,  Descricao = "1 : 2"},
            new Z_Padrao{Codigo = 3,  Descricao = "1 : 5"},
            new Z_Padrao{Codigo = 4,  Descricao = "1 : 10"},
            new Z_Padrao{Codigo = 5,  Descricao = "1 : 20"},
            new Z_Padrao{Codigo = 6,  Descricao = "1 : 50"},
            new Z_Padrao{Codigo = 7,  Descricao = "1 : 100"},
            new Z_Padrao{Codigo = 8,  Descricao = "2 : 1"},
            new Z_Padrao{Codigo = 9,  Descricao = "5 : 1" },
            new Z_Padrao{Codigo = 10, Descricao = "10 : 1" },
            new Z_Padrao{Codigo = 11, Descricao = "20 : 1" },
            new Z_Padrao{Codigo = 12, Descricao = "50 : 1" }, };

      txtEscala.CarregarComboBox(comboList);
    }

    private void FrmCapaProjeto_Loaded(object sender, EventArgs e) {
      Invoke(new MethodInvoker(() => {
        try {
          swModel = (ModelDoc2)swApp.ActiveDoc;
          var pathName = swModel.GetPathName();
          nomeCapaProjeto = $"{Path.GetDirectoryName(pathName)}\\{Path.GetFileNameWithoutExtension(pathName)} CAPA DO PROJETO.SLDDRW";

          int status = 0;
          int warnings = 0;
          int errors = 0;

          // Verificar se o arquivo já existe
          if (System.IO.File.Exists(nomeCapaProjeto)) {
            MsgBox.ShowWaitMessage("Abrindo Desenho Capa...");
            swApp.OpenDoc6(nomeCapaProjeto, (int)swDocumentTypes_e.swDocDRAWING, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref status, ref warnings);
            errors = 0;
            swApp.ActivateDoc2(nomeCapaProjeto, false, (int)errors);
            //UcPainelTarefas.Instancia.BtnCapa_Click();
            GetProperties();
            return;
          }

          MsgBox.ShowWaitMessage("Criando Desenho Capa...");
          FormatoFolha.Carregar();

          double X = 0.16;
          double Y = 0.15;
          DrawingDoc swDrawing = (DrawingDoc)swApp.NewDocument(FormatoFolha.model.FormatoA3, 5, 0.2794, 0.4318);
          swModel = (ModelDoc2)swApp.ActiveDoc;
          swDrawing = (DrawingDoc)swModel;
          var swModelDocExt = swModel.Extension;

          swDrawing.GenerateViewPaletteViews(pathName);
          var viewNames = (object[])swDrawing.GetDrawingPaletteViewNames();

          if (!(viewNames == null)) {
            var numViews = (viewNames.GetUpperBound(0) - viewNames.GetLowerBound(0));
            for (int i = 0; i < numViews; i++) {
              string viewPaletteName = (string)viewNames[i];
              if (viewPaletteName == "*Isométrica") {
                var swView = swDrawing.DropDrawingViewFromPalette2(viewPaletteName, X, Y, 0.0);
                swDrawing.ActivateSheet("Folha1");
                swDrawing.ActivateView("Vista de desenho1");
                break;
              }
            }
          }

          InserirBloc();

          MsgBox.ShowWaitMessage("Salvando Desenho Capa...");

          savaAs();
        } catch (Exception ex) {
          LmException.ShowException(ex, "Erro ao Criar Capa Proeto");
        } finally {
          MsgBox.CloseWaitMessage();
        }
      }));
    }

    private void BtnAplicar_Click(object sender, EventArgs e) {
      if (string.IsNullOrEmpty(txtItem.Text)) {
        MsgBox.Show("Informar Item!",
            "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      if (string.IsNullOrEmpty(txtPedido.Text)) {
        MsgBox.Show("Informar Pedido!",
            "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      if (string.IsNullOrEmpty(txtEscala.Text)) {
        MsgBox.Show("Selecionar uma Escala!",
            "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      AppDados();
    }

    private void BtnSalvar_Click(object sender, EventArgs e) {
      ModelDoc2 swModel = default(ModelDoc2);
      swModel = (ModelDoc2)swApp.ActiveDoc;
      string fileName = swModel.GetPathName();
      this.Close();
      swModel.Save2(true);
      swApp.CloseDoc(fileName);
    }

    private void BtnFechar_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void GetProperties() {
      string valOut;
      string resolvedValOut;
      ModelDoc2 swModel = default(ModelDoc2);
      swModel = (ModelDoc2)swApp.ActiveDoc;
      var swModelDocExt = swModel.Extension;

      var swCustPropMngr = swModelDocExt.get_CustomPropertyManager("");
      swCustPropMngr.Get2("Pedido", out valOut, out resolvedValOut);
      txtPedido.Text = resolvedValOut;
      swCustPropMngr.Get2("Item", out valOut, out resolvedValOut);
      txtItem.Text = resolvedValOut;
      swCustPropMngr.Get2("Escala", out valOut, out resolvedValOut);
      txtEscala.Text = resolvedValOut;
    }

    private void AppDados() {
      try {
        DrawingDoc swDraw;
        swModel = (ModelDoc2)swApp.ActiveDoc;
        swDraw = (DrawingDoc)swModel;
        swDraw = (DrawingDoc)swApp.ActiveDoc;
        ModelDocExtension swModelDocExt = default(ModelDocExtension);
        CustomPropertyManager swCustPropMngr = default(CustomPropertyManager);
        swModelDocExt = swModel.Extension;

        FormatoFolha.Carregar();

        double largura = 0.42;
        double altura = 0.297;

        string[] split = txtEscala.Text.Split(':');
        int sc1 = Convert.ToInt16(split[0]);
        int sc2 = Convert.ToInt16(split[1]);
        bool boolstatus = swDraw.SetupSheet5("Folha1", 12, 12, sc1, sc2, true, FormatoFolha.model.FormatoA3, largura, altura, "Valor predeterminado", true);

        swCustPropMngr = swModelDocExt.get_CustomPropertyManager("");

        swCustPropMngr.Add3("Pedido", (int)swCustomInfoType_e.swCustomInfoText, txtPedido.Text.Trim(), (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
        swCustPropMngr.Add3("Item", (int)swCustomInfoType_e.swCustomInfoText, txtItem.Text.Trim(), (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
        swCustPropMngr.Add3("Escala", (int)swCustomInfoType_e.swCustomInfoText, txtEscala.Text.Trim(), (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);

        //int retVal = swCustPropMngr.Delete("Pedido");
        //retVal = swCustPropMngr.Delete("Item");

        //retVal = swCustPropMngr.Add2("Pedido", (int)swCustomInfoType_e.swCustomInfoText, txtPedido.Text.Trim());
        //retVal = swCustPropMngr.Add2("Item", (int)swCustomInfoType_e.swCustomInfoText, txtItem.Text.Trim());
      } catch (Exception ex) {
        MsgBox.Show("Erro:\n" + ex.Message);
      }
    }

    //inserir bloco Pedido Item
    private void InserirBloc() {
      ModelDoc2 swModel;
      DrawingDoc swDraw;
      //SketchSegment[] swSkSeg = new SketchSegment[14];
      SketchPoint[] swSkPt = new SketchPoint[4];
      Note[] swSkNote = new Note[3];

      SketchBlockDefinition swSketchBlockDef2;
      SketchManager swSketchMgr;
      ModelDocExtension swModelDocExt;
      MathUtility swMathUtil;
      MathPoint swMathPoint2;
      double[] nPt = new double[3];
      Object vPt;

      swModel = swApp.IActiveDoc2;
      swDraw = (DrawingDoc)swModel;

      //Interfaces needed for block APIs 
      swSketchMgr = swModel.SketchManager;
      swModelDocExt = swModel.Extension;
      swMathUtil = swApp.IGetMathUtility();

      swSketchMgr = swModel.SketchManager;

      // Define an insertion point
      nPt[0] = 5;
      nPt[1] = 1.2;
      nPt[2] = 0.0;
      vPt = nPt;
      swMathPoint2 = (MathPoint)swMathUtil.CreatePoint(vPt);
      swModel.ClearSelection2(true);

      bool status = swDraw.ActivateSheet("Sheet1");
      status = swModel.Extension.SelectByID2("Sheet1", "SHEET", 0.295277442541428, 0.199841805779061, 0, false, 0, null, 0);
      var pathName = Path.GetDirectoryName(Config.model.ListaMontagem);
      var pathSubName = Path.GetDirectoryName(pathName);

      swSketchBlockDef2 = (SketchBlockDefinition)swSketchMgr.MakeSketchBlockFromFile(swMathPoint2, pathSubName + @"\BLOCOS\CARIMBO PEDIDO_ITEM.SLDBLK", false, 1, 0);

      // Redraw to see all changes
      swModel.GraphicsRedraw2();

      //swModel.SaveAs(nomeCapaProjeto);
    }

    private void savaAs() {
      ModelDoc2 swModel = default(ModelDoc2);
      swModel = (ModelDoc2)swApp.ActiveDoc;

      string newName = nomeCapaProjeto;

      swModel.SaveAs(newName);
    }

  }
}
