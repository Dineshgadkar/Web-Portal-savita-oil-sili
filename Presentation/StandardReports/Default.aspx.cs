using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentation_StandardReports_Default : System.Web.UI.Page
{
    BusinessAccessLayer BAL = new BusinessAccessLayer();

    protected void Page_Load(object sender, EventArgs e)
    {
        fetchOverallData();
    }

    private void fetchOverallData()
    {
        //try
        //{
        //    ReportViewer1.ProcessingMode = ProcessingMode.Local;
        //    ReportViewer1.LocalReport.ReportPath = "Presentation/Reports/OEEReport.rdlc";

        //    DataTable dt = new DataTable();
        //    //dt = BAL.fetchOverallData();

        //    ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
        //    ReportViewer1.LocalReport.EnableHyperlinks = true;
        //    ReportViewer1.LocalReport.DataSources.Clear();
        //    ReportViewer1.LocalReport.DataSources.Add(datasource);
        //    ReportViewer1.LocalReport.Refresh();

        //}
        //catch (Exception ex)
        //{

        //}
    }
}