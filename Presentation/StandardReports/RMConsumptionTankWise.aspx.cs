﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Microsoft.Reporting.WebForms;
using System.Text;
using System.Drawing.Imaging;
using System.Reflection;
using System.Drawing.Printing;
using System.Drawing;


public partial class Presentation_StandardReports_RMConsumptionTankWise : System.Web.UI.Page
{
    string fdtm = "";
    string tdtm = "";

    DataTable dataset;
    private int m_currentPageIndex;
    private IList<Stream> m_streams;

    BusinessAccessLayer BAL = new BusinessAccessLayer();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getTankName();
        }
    }

    public class TankName
    {

        public string TName { get; set; }
    }
    private void getTankName()
    {
        try
        {
            DataTable dt = new DataTable();

        //    dt = BAL.getTankData();

            List<TankName> TankNameList = new List<TankName>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TankName TankName = new TankName();
              
                TankName.TName = dt.Rows[i]["TankDescription"].ToString();

                TankNameList.Add(TankName);
                ddlTank.Items.Add(TankName.TName);
            }

         
           

         //   ddlTank.DataSource = TankNameList;  //Set Datasource to CheckBox List  
            
         //   ddlTank.DataBind(); // Bind the checkboxList with String List.  



            //ddlTank.DataSource = dt;
            //ddlTank.DataValueField = "TankDescription";
            //ddlTank.DataTextField = "TankDescription";
            //ddlTank.DataBind();

            //string selectedvalues = string.Empty;
            //foreach (ListItem li in ddlTank.Items)
            //{
            //    if (li.Selected == true)
            //    {
            //        selectedvalues += li.Text + ",";
            //    }
            //}

        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        fdtm = txtFromDate.Text;
        tdtm = txtToDate.Text;
     //  string Tank = ddlTank.SelectedItem.Text;
        



        string selectedvalues = string.Empty;
        foreach (ListItem li in ddlTank.Items)
        {
            if (li.Selected == true)
            {
                selectedvalues += li.Text + ",";
            }
        }
        string Tank = selectedvalues;


        try
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = "Presentation/Reports/RMConsumptionReport.rdlc";

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
        report.ReportPath = "Presentation/Reports/RMConsumptionReport.rdlc";
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

    protected void ddlTank_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedvalues = string.Empty;
        foreach (ListItem li in ddlTank.Items)
        {
            if (li.Selected == true)
            {
                selectedvalues += li.Text + ",";
            }
        }


    }
}