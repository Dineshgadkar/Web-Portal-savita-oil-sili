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

public partial class Presentation_StandardReports_DailyBlendingReport : System.Web.UI.Page
{

    BusinessAccessLayer BAL = new BusinessAccessLayer();
    DataTable dataset;
    private int m_currentPageIndex;
    private IList<Stream> m_streams;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {

        DataTable dt = new DataTable();

        try
        {

            string tDate = txtFromDate.Text;

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = "Presentation/Reports/DailyBlendingReport.rdlc";

            dataset = BAL.getDailyBlendingData(tDate);

            DataColumn dcDate = new DataColumn("ToDate", typeof(string));
            dcDate.DefaultValue = tDate.ToString();
            dataset.Columns.Add(dcDate);

            ReportDataSource datasource = new ReportDataSource("DataSet1", dataset);
            ReportViewer1.LocalReport.EnableHyperlinks = true;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.Refresh();

            //ReportParameter[] param = new ReportParameter[1];
            //param[0] = new ReportParameter("Date", tDate);
            //ReportViewer1.LocalReport.SetParameters(param);

        }
        catch (Exception ex)
        {

        }
        finally
        { 
        
        
        }
    }

    #region Print Button Code

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        LocalReport report = new LocalReport();
        report.ReportPath = "Presentation/Reports/DailyBlendingReport.rdlc";
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
                <PageWidth>14in</PageWidth>
                <PageHeight>9in</PageHeight>
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