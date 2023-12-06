using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Microsoft.Reporting.WebForms;

public partial class Presentation_StandardReports_PeriodicBatchReport : System.Web.UI.Page
{

    BusinessAccessLayer BAL = new BusinessAccessLayer();

    string StartDate = "";
    string EndDate = "";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        StartDate = txtFromDate.Text;
        EndDate = txtToDate.Text;

        try
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = "Presentation/Reports/BatchReports/PeriodicReport.rdlc";

            DataTable dt = new DataTable();
            dt = BAL.GetPeriodicData(StartDate, EndDate);

            ReportDataSource datasource = new ReportDataSource("PROD_CODE", dt);
            ReportViewer1.LocalReport.EnableHyperlinks = true;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.Refresh();

            ReportParameter[] param = new ReportParameter[2];
            param[0] = new ReportParameter("StartTime", StartDate);
            param[1] = new ReportParameter("EndTime", EndDate);

            ReportViewer1.LocalReport.SetParameters(param);
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
}