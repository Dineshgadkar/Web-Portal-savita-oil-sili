using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq; 
using System.Web;
using System.Web.Script.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentation_StandardReports_Tank : System.Web.UI.Page
{
    string fdtm = "";
    string tdtm = "";

    DataTable dataset;
    private int m_currentPageIndex;
    private IList<Stream> m_streams;

    static BusinessAccessLayer BAL = new BusinessAccessLayer();
    static BusinessAccessLayer BAL1 = new BusinessAccessLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    GetTank();
        //}
        //GetTank();

    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        fdtm = txtFromDate.Value;
        tdtm = txtToDate.Value;
        //  string Tank = ddl_Machine1.Items.ToString();


        //Page.ClientScript.RegisterStartupScript(this.GetType(), "change label", "<script type='text/javascript'>change_label()</script>");
        //Label1.Text = Hidden1.Value;//This is how you will get the updated value 

        string Tank = Label1.Value;
       

        try
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = "Presentation/Reports/Tank.rdlc";

            dataset = BAL.getRMConsDataFilter(fdtm, tdtm, Tank, "TankWise");

            DataColumn dcFromDate = new DataColumn("FromDate", typeof(string));
            dcFromDate.DefaultValue = fdtm.ToString();
            dataset.Columns.Add(dcFromDate);

            DataColumn dcToDate = new DataColumn("ToDate", typeof(string));
            dcToDate.DefaultValue = tdtm.ToString();
            dataset.Columns.Add(dcToDate);

            ReportDataSource datasource = new ReportDataSource("DataSet1", dataset);
            ReportViewer1.LocalReport.EnableHyperlinks = true;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.Refresh();
            //GetTank();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        LocalReport report = new LocalReport();
        report.ReportPath = "Presentation/Reports/Tank.rdlc";
        btn_Submit_Click(new object(), new EventArgs());
        report.DataSources.Add(new ReportDataSource("DataSet1", dataset));
        PrintReport.Export(report);
    }
    public static class PrintReport
    {

        private static int m_currentPageIndex;
        private static IList<Stream> m_streams;

        public static Stream CreateStream(string name, string fileNameExtension, System.Text.Encoding encoding, string mimeType, bool willSeek)
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
                <PageWidth>14.5in</PageWidth>
                <PageHeight>8in</PageHeight>
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

    [System.Web.Services.WebMethod]
    [ScriptMethod(UseHttpGet = true)]
    public static string GetTank()
    {
       //   dt = BAL1.getTankData();

        string temp = "";

        string qwerty = "";

        qwerty = BAL.getTankData();

        if (temp != "")
        {
            qwerty = temp;


        }
        return qwerty;
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
}