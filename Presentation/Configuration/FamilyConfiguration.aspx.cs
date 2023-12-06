using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Presentation_Configuration_FamilyConfiguration : System.Web.UI.Page
{
    BusinessAccessLayer BAL = new BusinessAccessLayer();

    string familyName = "";
    string ViewName = "";

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
            DataTable dt = new DataTable();
            dt = BAL.getViewData();

            ddlViews.DataSource = dt;
            ddlViews.DataTextField = "name";
            ddlViews.DataValueField = "name";

            ddlViews.DataBind();
        }
        catch(Exception ex)
        {
            this.LogError(ex);
        }
    }

    public void fillGridData()
    {
        try
        {
            DataTable dt = new DataTable();

            dt = BAL.getFamilyData();

            if (dt.Rows.Count > 0)
            {
                gdvFamily.DataSource = dt;
                gdvFamily.DataBind();
            }
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        familyName = txtFamilyName.Text;
        ViewName = ddlViews.SelectedValue;

        try
        {
            DataTable dt = new DataTable();
            dt = BAL.AddFamilyData(familyName, ViewName);
            fillGridData();
            txtFamilyName.Text = "";
            ddlViews.SelectedIndex = 0;
        }
        catch(Exception ex)
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

    protected void gdvFamily_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gdvFamily.EditIndex = e.NewEditIndex;

        fillGridData();
    }
    protected void gdvFamily_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gdvFamily.EditIndex = -1;

        fillGridData();
    }
    protected void gdvFamily_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            Label ID = gdvFamily.Rows[e.RowIndex].FindControl("Label6") as Label;
            TextBox name = gdvFamily.Rows[e.RowIndex].FindControl("TextBox2") as TextBox;
            DropDownList view = gdvFamily.Rows[e.RowIndex].FindControl("DropDownList1") as DropDownList;
            DataTable dt = new DataTable();
            dt = BAL.UpdateFamilyData(ID, name, view);
            gdvFamily.EditIndex = -1;
            fillGridData();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }
}