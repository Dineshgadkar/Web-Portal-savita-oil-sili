using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Presentation_Configuration_BCTCOnfiguration : System.Web.UI.Page
{
    BusinessAccessLayer BAL = new BusinessAccessLayer();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getProductCodes();
        }
    }

    public void getProductCodes()
    {

        DataTable dt = new DataTable();

        try
        {
            dt = BAL.getFamily();

            if (dt.Rows.Count > 0)
            {
                ddlFamilyList.DataSource = dt;
                ddlFamilyList.DataTextField = "FAMILY";
                ddlFamilyList.DataValueField = "FAMILY";

                ddlFamilyList.SelectedValue = "---Select Family Name---";

                ddlFamilyList.DataBind();
            }

        }
        catch (Exception ex)
        {

        }
        finally
        {

        }

    }


    protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            string productCode = ddlProduct.Text;
            string familyName = ddlFamilyList.Text;

            fetchDetails(productCode, familyName);

            fetchBCT(productCode, familyName);


        }
        catch (Exception ex)
        {

        }
    }

    public void fetchDetails(string productCode, string familyName)
    {
        DataTable dt = new DataTable();

        try
        {
            dt = BAL.getProductCodeDetails(productCode, familyName);

            if (dt.Rows.Count > 0)
            {
                string ProductDesc = Convert.ToString(dt.Rows[0]["PRODUCT_DESC"]);
                string ProductFamily = Convert.ToString(dt.Rows[0]["FAMILY"]);

                txtProductDescription.Text = ProductDesc;
                txtProductFamily.Text = ProductFamily;

            }
            else
            {
                txtProductDescription.Text = "";
                txtProductFamily.Text = "";
            }

        }
        catch (Exception ex)
        {

        }
    }

    public void fetchBCT(string productCode, string familyName)
    {
        DataTable dt = new DataTable();

        try
        {
            dt = BAL.getProductCodeBCT(productCode, familyName);


            if (dt.Rows.Count > 0)
            {
                string fixedBCT = Convert.ToString(dt.Rows[0]["FixedBCT"]);
                string variableBCT = Convert.ToString(dt.Rows[0]["VariableBCT"]);

                txtFixedBCT.Text = fixedBCT;
                txtVariableBCT.Text = variableBCT;

            }
            else
            {
                txtFixedBCT.Text = "";
                txtVariableBCT.Text = "";
            }

        }
        catch (Exception ex)
        {

        }
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int result = 0;

        try
        {

            string productCode = ddlProduct.Text;
            string fixedBCT = txtFixedBCT.Text;
            string variableBCT = txtVariableBCT.Text;
            string family = ddlFamilyList.Text;
            result = BAL.insertBCTData(productCode, fixedBCT, variableBCT, family);

            if(result == 1)
            {

            }
            else
            {

            }

        }
        catch(Exception ex)
        {

        }
    }


    protected void ddlFamilyList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        string familyName = ddlFamilyList.Text;
        try
        {
            dt = BAL.getProductDetails(familyName);
            ddlProduct.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                
                ddlProduct.DataSource = dt;
                ddlProduct.DataTextField = "PROD_CODE";
                ddlProduct.DataValueField = "PROD_CODE";
                ddlProduct.Items.Add("---Select Product Code---");
                ddlProduct.SelectedValue = "---Select Product Code---";

                ddlProduct.DataBind();

                txtFixedBCT.Text = "";
                txtProductDescription.Text = "";
                txtProductFamily.Text = "";
                txtVariableBCT.Text = "";

            }
            else
            {
                
            }

        }
        catch (Exception ex)
        {

        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int result = 0;

        try
        {

            string productCode = ddlProduct.Text;
            string fixedBCT = txtFixedBCT.Text;
            string variableBCT = txtVariableBCT.Text;
            string family = ddlFamilyList.Text;
            result = BAL.updateBCTData(productCode, fixedBCT, variableBCT, family);

            if (result == 1)
            {

            }
            else
            {

            }

        }
        catch (Exception ex)
        {

        }
    }
}