using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Presentation_Configuration_CommandConfiguration : System.Web.UI.Page
{
    BusinessAccessLayer BAL = new BusinessAccessLayer();
    string CmdNo = "";
    string CmdDesc = "";
    string sp1Unit = "";
    string sp2Unit = "";

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    public void btnAdd_Click(object sender, EventArgs e)
    {
        CmdNo = txtCommand.Text;
        CmdDesc = txtCommandDesc.InnerText;
        sp1Unit = txtSP1.Text;
        sp2Unit = txtSP2.Text;

        try
        {
            DataTable dt = new DataTable();
            dt = BAL.AddCommandData(CmdNo, CmdDesc, sp1Unit, sp2Unit);
            clearAll();
            Response.Redirect("ViewCommand.aspx");
        }
        catch(Exception ex)
        {
            this.LogError(ex);
        }
    }

    public void clearAll()
    {
        txtCommand.Text= "";
        txtCommandDesc.InnerText = "" ;
        txtSP1.Text = "" ;
        txtSP2.Text= "" ;
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