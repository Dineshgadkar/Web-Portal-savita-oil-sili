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

public partial class Presentation_StandardReports_CumulativeBlenderWise : System.Web.UI.Page
{
    string blenderNo = "";

    DataTable dataset;
    private int m_currentPageIndex;
    private IList<Stream> m_streams;

    BusinessAccessLayer BAL = new BusinessAccessLayer();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getBlenderName();
        }
    }

    private void getBlenderName()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = BAL.getBlenderData();

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{

            //    string blenderName = Convert.ToString(dt.Rows[i]["BlenderName"]);

            //    if ((blenderName != "V101") && (blenderName != "V301") && (blenderName != "V302") && (blenderName != "V401") && (blenderName != "V501") && (blenderName != "V502") && (blenderName != "V503") && (blenderName != "V504") && (blenderName != "V601") && (blenderName != "V602") && (blenderName != "V701") && (blenderName != "V702") && (blenderName != "V801") && (blenderName != "V901") && (blenderName != "V902") && (blenderName != "V2401"))
            //    {
            //        DataRow dr = dt.Rows[i];
            //        dt.Rows.Remove(dr);
            //    }
            //}

            dt.AcceptChanges();

            ddl_Blender.DataSource = dt;

            ddl_Blender.DataTextField = "BlenderName";
            ddl_Blender.DataValueField = "BlenderName";

            ddl_Blender.DataBind();

            ddl_Blender.Items.Insert(0, "Select Blender Name");
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
   
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            string blender = "";
            blenderNo = ddl_Blender.SelectedValue;
            double initialSP = 0.0;
            string BatchNo = ddl_BatchNo.SelectedValue;
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = "Presentation/Reports/CR.rdlc";

            dataset = new DataTable();

            dataset = BAL.getCumulativeBlenderReportData(blenderNo, BatchNo);

            DataTable dt = dataset.DefaultView.ToTable("BTCH_SIZE_SP", true, "BTCH_SIZE_SP");
            DataTable dt1 = dataset.DefaultView.ToTable("BlenderName", true, "BlenderName");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double intialSP1 = Convert.ToDouble(dt.Rows[i][0]);
                initialSP = initialSP + intialSP1;
            }

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string blender1 = Convert.ToString(dt1.Rows[i][0]);

                if (blender == "")
                {
                    blender = blender1;
                }
                else
                {
                    blender = blender + " + " + blender1;
                }
            }

            #region Commented Assign Values

            //string Family = Convert.ToString(dataset.Rows[0]["FAMILY"]);
            //string SP1 = Convert.ToString(dataset.Rows[0]["SP1"]);
            //string PV1 = Convert.ToString(dataset.Rows[0]["PV1"]);
            ////string RECEIPE_NO = Convert.ToString(dataset.Rows[0]["RECEIPE_NO"]);
            //string PRODUCT_NAME = Convert.ToString(dataset.Rows[0]["PRODUCT_NAME"]);
            //string PRODUCT_DESC = Convert.ToString(dataset.Rows[0]["PRODUCT_DESC"]);
            //string BlenderNo = blender;
            //string BTCH_NO = Convert.ToString(dataset.Rows[0]["BatchNumber"]);
            ////string TotalSteps = Convert.ToString(dataset.Rows[0]["TOT_STEPS"]);
            ////string BlendTime = Convert.ToString(dataset.Rows[0]["BlendTime"]);
            ////string SuspendTime = Convert.ToString(dataset.Rows[0]["SuspendTime"]);
            //string BatchTime = "";
            //string BatchStartDTTM = Convert.ToString(dataset.Rows[0]["BatchStartDTTM"]);
            //string BatchEndDTTM = Convert.ToString(dataset.Rows[0]["BatchEndDTTM"]);
            ////string OPER_NAME = Convert.ToString(dataset.Rows[0]["OPER_NAME"]);
            //string DestinationTank = Convert.ToString(dataset.Rows[0]["Destination"]);
            ////string TYPE = Convert.ToString(dataset.Rows[0]["TYPE"]);
            //string BTCH_SIZE_SP = Convert.ToString(initialSP);

            #endregion

            ReportDataSource datasource = new ReportDataSource("DataSet1", dataset);
            ReportViewer1.LocalReport.EnableHyperlinks = true;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.Refresh();

            #region Add Paramaters Programatically Commented

            //ReportParameter[] param = new ReportParameter[12];
            //param[0] = new ReportParameter("BatchNo", BTCH_NO);
            //param[1] = new ReportParameter("producedQuantity", PV1);
            //param[2] = new ReportParameter("productCode", PRODUCT_NAME);
            //param[3] = new ReportParameter("ReqQuantity", SP1);
            //param[4] = new ReportParameter("productDesc", PRODUCT_DESC);
            //param[5] = new ReportParameter("family", Family);
            //param[6] = new ReportParameter("batchTime", BatchTime);
            //param[7] = new ReportParameter("strtDttm", BatchStartDTTM);
            //param[8] = new ReportParameter("endDttm", BatchEndDTTM);
            //param[9] = new ReportParameter("destination", DestinationTank);
            //param[10] = new ReportParameter("initialSP", BTCH_SIZE_SP);
            //param[11] = new ReportParameter("BlenderNo", BlenderNo);

            //ReportViewer1.LocalReport.SetParameters(param);

            #endregion

        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    protected void ddl_Blender_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            blenderNo = ddl_Blender.SelectedValue;
            DataTable dt = new DataTable();
            dt = BAL.getBatchNumbers(blenderNo);

            ddl_BatchNo.DataSource = dt;

            ddl_BatchNo.DataTextField = "BatchNumber";
            ddl_BatchNo.DataValueField = "BatchNumber";

            ddl_BatchNo.DataBind();

            ddl_BatchNo.Items.Insert(0, "Select Batch No");
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

    #region Print Button Code

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        LocalReport report = new LocalReport();
        report.ReportPath = "Presentation/Reports/CR.rdlc";
        btn_Submit_Click(new object(), new EventArgs());
        report.DataSources.Add(new ReportDataSource("DataSet1", dataset));
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
                <PageWidth>12in</PageWidth>
                <PageHeight>10in</PageHeight>
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