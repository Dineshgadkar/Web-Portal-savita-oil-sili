using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Presentation_Configuration_EditCommand : System.Web.UI.Page
{
    string CommandNo = "";
    string CommandDesc = "";
    string Sp1 = "";
    string sp2 = "";
    BusinessAccessLayer BAL = new BusinessAccessLayer();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getCommandData();
        }
    }

    public void getCommandData()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = BAL.getCommandData();

            ddlCommandNo.DataSource = dt;
            ddlCommandNo.DataTextField = "CMNDNo";
            ddlCommandNo.DataValueField = "CMNDNo";

            ddlCommandNo.DataBind();
            ddlCommandNo.Items.Insert(0, "Select Command No");
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
    protected void ddlCommandNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommandNo = ddlCommandNo.SelectedValue;
       
        try
        {
            DataTable dt = new DataTable();
            dt = BAL.GetEditCommandData(CommandNo);

            if (dt.Rows.Count > 0)
            {
                txtCommandDesc.InnerText = dt.Rows[0]["CMNDName"].ToString();
                txtSP1.Text=dt.Rows[0]["CMNDUnitSP1"].ToString();
                txtSP2.Text = dt.Rows[0]["CMNDUnitSP2"].ToString();
            }
        }
        catch(Exception ex)
        {
            this.LogError(ex);
        }
    }
    public void btnAdd_Click(object sender, EventArgs e)
    {
        CommandNo = ddlCommandNo.SelectedValue;
        CommandDesc = txtCommandDesc.InnerText;
        Sp1 = txtSP1.Text;
        sp2 = txtSP2.Text;

        try
        {
            DataTable dt = new DataTable();
            dt = BAL.UpdateCommandData(CommandNo, CommandDesc, Sp1, sp2);
            clearAll();
            Response.Redirect("ViewCommand.aspx");
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    public void clearAll()
    {
        txtCommandDesc.InnerText = "";
        txtSP1.Text= "" ;
        txtSP2.Text = "";
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