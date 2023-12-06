using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Presentation_Configuration_SourceConfiguration : System.Web.UI.Page
{
    BusinessAccessLayer BAL = new BusinessAccessLayer();

    string TankNo = "";
    string TankDesc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
 
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        TankNo = txtTankNo.Text;
        TankDesc = txtTankSource.Text;
        try
        {
            DataTable dt = new DataTable();
            dt = BAL.AddTankSourceData(TankNo, TankDesc);
            clearAll();
            Response.Redirect("ViewTankSource.aspx");
        }
        catch(Exception ex)
        {
            this.LogError(ex);
        }
    }

    private void clearAll()
    {
        txtTankNo.Text = "";
        txtTankSource.Text = "";
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