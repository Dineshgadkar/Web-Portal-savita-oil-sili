using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.IO;
using System.Text;
using System.Drawing.Imaging;
using System.Reflection;
using System.Drawing.Printing;
using System.Drawing;

public partial class Presentation_StandardReports_BatchAccuracyReport : System.Web.UI.Page
{
    string blender_Name = "";
    string ProductName = "";
    
    public string btchName = "";
    DataTable dataset;
    private int m_currentPageIndex;
    private IList<Stream> m_streams;
    BusinessAccessLayer BAL = new BusinessAccessLayer();
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getBlenderData();
        }
    }

    public void getBlenderData()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = BAL.getBlenderData();

            ddl_Vessel.DataSource = dt;

            ddl_Vessel.DataTextField = "BlenderName";
            ddl_Vessel.DataValueField = "BlenderName";

            ddl_Vessel.DataBind();

            ddl_Vessel.Items.Insert(0, "Select Blender Name");
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    protected void ddl_Vessel_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            blender_Name = ddl_Vessel.SelectedValue;
            DataTable dt = new DataTable();
            dt = BAL.getProductList(blender_Name);

            ddl_ProdCode.DataSource = dt;

            ddl_ProdCode.DataTextField = "PRODUCT_NAME";
            ddl_ProdCode.DataValueField = "PRODUCT_NAME";

            ddl_ProdCode.DataBind();

            ddl_ProdCode.Items.Insert(0, "Select Product");
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        blender_Name = ddl_Vessel.SelectedValue;
        ProductName = ddl_ProdCode.SelectedValue;
        btchName = ddl_BatchNo.Text;
        try
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = "Presentation/Reports/BatchReports/BatchAccuracy.rdlc";

            dataset = new DataTable();
            dataset = BAL.GetBatchAccuracyData(blender_Name, ProductName, btchName);

            #region Fetch Data Commented

            //string BlenderName = blender_Name;
            //string Family = Convert.ToString(dataset.Rows[0]["FAMILY"]);
            //string BTCH_SIZE_SP = Convert.ToString(dataset.Rows[0]["BTCH_SIZE_SP"]);
            //string BTCH_SIZE_PV = Convert.ToString(dataset.Rows[0]["BTCH_SIZE_PV"]);
            //string RECEIPE_NO = Convert.ToString(dataset.Rows[0]["RECEIPE_NO"]);
            //string PRODUCT_NAME = Convert.ToString(dataset.Rows[0]["PRODUCT_NAME"]);
            //string PRODUCT_DESC = Convert.ToString(dataset.Rows[0]["PRODUCT_DESC"]);
            //string FORMULA_NO = Convert.ToString(dataset.Rows[0]["FORMULA_NO"]);
            //string BTCH_NO = Convert.ToString(dataset.Rows[0]["BTCH_NO"]);
            //string TotalSteps = Convert.ToString(dataset.Rows[0]["TOT_STEPS"]);
            //string BlendTime = Convert.ToString(dataset.Rows[0]["tActTime"]);
            //string SuspendTime = Convert.ToString(dataset.Rows[0]["tStTime"]);
            //string BatchTime = Convert.ToString(dataset.Rows[0]["BatchTimeFinal"]);
            //string BatchStartDTTM = Convert.ToString(dataset.Rows[0]["BatchStartDTTM"]);
            //string BatchEndDTTM = Convert.ToString(dataset.Rows[0]["BatchEndDTTM"]);
            //string OPER_NAME = Convert.ToString(dataset.Rows[0]["OPER_NAME"]);

            //string TYPE = Convert.ToString(dataset.Rows[0]["TypeDesc"]);

            #endregion

            ReportDataSource datasource = new ReportDataSource("V102", dataset);
            ReportViewer1.LocalReport.EnableHyperlinks = true;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.Refresh();

            #region Add Parameters Programatically Commented

            //ReportParameter[] param = new ReportParameter[18];
            //param[0] = new ReportParameter("BlenderNo", BlenderName);
            //param[1] = new ReportParameter("BatchNo", BTCH_NO);
            //param[2] = new ReportParameter("ReqQuantity", BTCH_SIZE_SP);
            //param[3] = new ReportParameter("producedQuantity", BTCH_SIZE_PV);
            //param[4] = new ReportParameter("RecipeNo", RECEIPE_NO);
            //param[5] = new ReportParameter("productCode", PRODUCT_NAME);
            //param[6] = new ReportParameter("productDesc", PRODUCT_DESC);
            //param[7] = new ReportParameter("formulaNo", FORMULA_NO);
            //param[8] = new ReportParameter("type", TYPE);
            //param[9] = new ReportParameter("family", Family);
            //param[10] = new ReportParameter("totalSteps", TotalSteps);
            //param[11] = new ReportParameter("blendTime", BlendTime);
            //param[12] = new ReportParameter("SusTime", SuspendTime);
            //param[13] = new ReportParameter("batchTime", BatchTime);
            //param[14] = new ReportParameter("strtDttm", BatchStartDTTM);
            //param[15] = new ReportParameter("endDttm", BatchEndDTTM);
            //param[16] = new ReportParameter("destination", "");
            //param[17] = new ReportParameter("operatorName", OPER_NAME);

            //ReportViewer1.LocalReport.SetParameters(param);

            #endregion

        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    #region ErrorLogs

    private void LogError(Exception ex)
    {
        string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        message += string.Format("Message: {0}", ex.Message);
        message += Environment.NewLine;
        message += string.Format("StackTrace: {0}", ex.StackTrace);
        message += Environment.NewLine;
        message += string.Format("Source: {0}", ex.Source);
        message += Environment.NewLine;
        message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        string path = System.Web.HttpContext.Current.Server.MapPath("~/Logs/BusinessLayerErrorLog.txt");
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine(message);
            writer.Close();
        }
    }

    #endregion

    protected void ddl_ProdCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            blender_Name = ddl_Vessel.SelectedValue;
            ProductName = ddl_ProdCode.SelectedValue;

            DataTable dt = new DataTable();
            dt = BAL.getBatchList(blender_Name, ProductName);

            ddl_BatchNo.DataSource = dt;
            ddl_BatchNo.DataTextField = "BTCH_NO";
            ddl_BatchNo.DataValueField = "BTCH_NO";
            ddl_BatchNo.DataBind();

            ddl_BatchNo.Items.Insert(0, "Select Batch");
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    #region Print Button Code

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        LocalReport report = new LocalReport();
        report.ReportPath = "Presentation/Reports/BatchReports/BatchAccuracy.rdlc";
        btn_Submit_Click(new object(), new EventArgs());
        report.DataSources.Add(new ReportDataSource("V102", dataset));
        PrintReport.Export(report);
    }

    public static class PrintReport
    {

        private static int m_currentPageIndex;
        private static IList<Stream> m_streams;

        public static Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        public static void Export(LocalReport report, bool print = true)
        {
            try
            {
                string deviceInfo =
                  @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>20in</PageWidth>
                <PageHeight>16in</PageHeight>
                <MarginTop>0.25in</MarginTop>
                <MarginLeft>0.5in</MarginLeft>
                <MarginRight>0.5in</MarginRight>
                <MarginBottom>0.25in</MarginBottom>
                </DeviceInfo>";
                Warning[] warnings;
                m_streams = new List<Stream>();
                report.Render("Image", deviceInfo, CreateStream,
                   out warnings);
                foreach (Stream stream in m_streams)
                    stream.Position = 0;

                if (print)
                {
                    Print();
                }
            }
            catch (Exception ex)
            {

            }
        }

        // Handler for PrintPageEvents
        public static void PrintPage(object sender, PrintPageEventArgs ev)
        {
            try
            {
                Metafile pageImage = new
                   Metafile(m_streams[m_currentPageIndex]);

                // Adjust rectangular area with printer margins.
                Rectangle adjustedRect = new Rectangle(
                    ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                    ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                    ev.PageBounds.Width,
                    ev.PageBounds.Height);

                // Draw a white background for the report
                ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

                // Draw the report content
                ev.Graphics.DrawImage(pageImage, adjustedRect);

                // Prepare for the next page. Make sure we haven't hit the end.
                m_currentPageIndex++;
                ev.HasMorePages = (m_currentPageIndex < m_streams.Count);

            }
            catch (Exception ex)
            {

            }
        }

        public static void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();

            //string PrinterName = System.Configuration.ConfigurationManager.AppSettings["PrinterName"];
            //printDoc.PrinterSettings.PrinterName = PrinterName;

            //printDoc.PrinterSettings.PrinterName = "HP LaserJet M203-M206 PCL 6"; //change it after printer name change

            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.DefaultPageSettings.Landscape = true;
                printDoc.Print();
            }
        }

        //public static void PrintToPrinter(this LocalReport report)
        //{
        //    Export(report);
        //}

        public static void DisposePrint()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }
    }

    #endregion

}