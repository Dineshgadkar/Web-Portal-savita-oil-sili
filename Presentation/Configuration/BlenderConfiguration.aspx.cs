using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class Presentation_Configuration_Configuration : System.Web.UI.Page
{
    string connetionString = null;

    string BlenderName = "";
    string ViewName = "";

    BusinessAccessLayer BAL = new BusinessAccessLayer();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillGridData();
            showViews();
        }
    }

    public void showViews()
    {
        try
        {
            DataTable dt = BAL.getViewData();

            ddlViews.DataSource = dt;
            ddlViews.DataTextField = "name";
            ddlViews.DataValueField = "name";

            ddlViews.DataBind();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    public void fillGridData()
    {
        try
        {
            DataTable dt = new DataTable();

            dt = BAL.getBlenderData();

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;

        fillGridData();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        fillGridData();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            Label ID = GridView1.Rows[e.RowIndex].FindControl("LabelID") as Label;
            TextBox name = GridView1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
            DropDownList view = GridView1.Rows[e.RowIndex].FindControl("DropDownList1") as DropDownList;
            DataTable dt = new DataTable();
            dt = BAL.UpdateGVData(ID, name, view);
            GridView1.EditIndex = -1;
            fillGridData();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    public void btnAdd_Click(object sender, EventArgs e)
    {
        BlenderName = txtBlenderName.Text;
        ViewName = ddlViews.SelectedValue;

        try
        {
            DataTable dt = new DataTable();
            dt = BAL.AddBlenderData(BlenderName, ViewName);
            fillGridData();
            txtBlenderName.Text = "";
            ddlViews.SelectedIndex = 0;
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