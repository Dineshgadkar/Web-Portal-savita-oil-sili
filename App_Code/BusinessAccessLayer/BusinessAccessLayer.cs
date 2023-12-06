using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using System.Web.Script.Serialization;
using System.Collections;
using System.Globalization;
//using Excel = Microsoft.Office.Interop.Excel;


/// <summary>
/// Summary description for BusinessAccessLayer
/// </summary>
public class BusinessAccessLayer
{
    DataAccessLayer DAL = new DataAccessLayer();

    public BusinessAccessLayer()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //static Excel._Application WA_Csv = new Excel.Application();
    ////static string workbookPath_Csv = @"C:\CASTROL\PRODUCTS\F-0\FORMULA\FORMULA1\1_F1.CSV";
    //static string workbookPath_Csv = "";

    #region Base Oil Data

    public DataTable GetBaseOilData()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.GetBaseOilData();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    #endregion

    #region Bulk Additive Data

    public DataTable GetBulkAddTVData()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.GetBulkAddTVData();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    #endregion

    #region Man Additive Data

    public DataTable GetManAddData()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.GetManAddData();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    #endregion

    #region Drum Additive Data

    public DataTable GetDrumAddData()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.GetDrumAddData();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    #endregion

    #region PickList

    //public DataTable GetPickList()
    //{
    //    DataTable dt = new DataTable();

    //    DataTable dtPickList = new DataTable();

    //    DataColumn dcFamily = new DataColumn("Family");
    //    DataColumn dcFGCode = new DataColumn("FGCode");
    //    DataColumn dcRMCode = new DataColumn("RMCode");
    //    DataColumn dcRMDescription = new DataColumn("RMDescription");
    //    DataColumn dcPackType = new DataColumn("PackType");
    //    DataColumn dcPrecautions = new DataColumn("Precautions");
    //    DataColumn dcQty = new DataColumn("Qty");
    //    DataColumn dcBatchSize = new DataColumn("BatchSize");

    //    dtPickList.Columns.Add(dcFamily);
    //    dtPickList.Columns.Add(dcFGCode);
    //    dtPickList.Columns.Add(dcRMCode);
    //    dtPickList.Columns.Add(dcRMDescription);
    //    dtPickList.Columns.Add(dcPackType);
    //    dtPickList.Columns.Add(dcPrecautions);
    //    dtPickList.Columns.Add(dcQty);
    //    dtPickList.Columns.Add(dcBatchSize);

    //    int counter = 0;

    //    try
    //    {

    //        dt = DAL.GetPickList();

    //        if (dt.Rows.Count > 0)
    //        {

    //            for (int i = 0; i < dt.Rows.Count; i++)
    //            {

    //                string currentSheet = "Sheet1";

    //                string FRMULA = "";
    //                string FORMULA_NO = "";
    //                string Csv_File = "";
    //                string path_Csv = "";

    //                int str1_BO = 0;
    //                int str1_BA = 0;
    //                int str1_MA = 0;
    //                int str1_DA = 0;
    //                double R_qty = 0.0;

    //                string family = dt.Rows[i]["FAMILY"].ToString();
    //                string productName = dt.Rows[i]["PRODUCT"].ToString();
    //                double batchSize = Convert.ToDouble(dt.Rows[i]["BSIZE"]);
    //                string formula = dt.Rows[i]["FORMULA"].ToString();

    //                FRMULA = "FORMULA" + formula;
    //                FORMULA_NO = formula;

    //                Csv_File = productName + "_" + "F" + FORMULA_NO;
    //                path_Csv = @"C:\CASTROL\PRODUCTS\" + family + @"\FORMULA\" + FRMULA + @"\" + Csv_File + @".CSV";

    //                //CsvExcelpath(path_Csv);

    //                Excel.Workbook excelWorkbook_Csv = WA_Csv.Workbooks.Open(path_Csv, 0, true, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
    //                Excel.Sheets excelSheets_Csv = excelWorkbook_Csv.Worksheets;
    //                //Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelSheets_Csv.get_Item(currentSheet);


    //                Excel.Worksheet excelWorksheet_csv = (Excel.Worksheet)excelSheets_Csv.get_Item(1);

    //                string records = Convert.ToString((excelWorksheet_csv.Cells[1, 1] as Excel.Range).Value);
    //                string[] recordsSplit = records.Split(',');

    //                #region BO

    //                str1_BO = Convert.ToInt32(recordsSplit[2]);
    //                //DataRow dr = dtPickList.NewRow();
    //                dtPickList.Rows.Add(family, productName, "", "", "", "", "", batchSize.ToString());
    //                counter = dtPickList.Rows.Count;

    //                if (str1_BO > 0)
    //                {

    //                    if (Convert.ToString(dtPickList.Rows[counter - 1]["PackType"]) != "")
    //                    {
    //                        //R = R + 1;

    //                        string RMCode = recordsSplit[6].ToString();
    //                        string PackType = "BASE OIL";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[34])) / 100);
    //                        string Qty = R_qty.ToString();

    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);

    //                        counter = dtPickList.Rows.Count;

    //                        //dtPickList.Rows[counter]["RMCode"] = recordsSplit[6].ToString();
    //                        //dtPickList.Rows[counter]["PackType"] = "BASE OIL";

    //                        //dtPickList.Rows[counter]["Qty"] = R_qty.ToString();

    //                    }
    //                }
    //                if (str1_BO > 1)
    //                {
    //                    counter = counter + str1_BO;
    //                    counter = counter - 2;
    //                }
    //                if (str1_BO == 2)
    //                {

    //                    string RMCode = recordsSplit[7].ToString();
    //                    string PackType = "BASE OIL";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[35])) / 100);
    //                    string Qty = R_qty.ToString();

    //                    dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                    counter = dtPickList.Rows.Count;

    //                    //dtPickList.Rows[counter]["RMCode"] = recordsSplit[7].ToString();
    //                    //dtPickList.Rows[counter]["PackType"] = "BASE OIL";
    //                    //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[35])) / 100);
    //                    //dtPickList.Rows[counter]["Qty"] = R_qty.ToString();
    //                }
    //                else if (str1_BO == 3)
    //                {
    //                    //DataRow dr0 = dtPickList.NewRow();
    //                    //dtPickList.Rows.Add(dr0);

    //                    string RMCode = recordsSplit[7].ToString();
    //                    string PackType = "BASE OIL";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[35])) / 100);
    //                    string Qty = R_qty.ToString();

    //                    dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                    counter = dtPickList.Rows.Count;

    //                    //dtPickList.Rows[counter - 1]["RMCode"] = recordsSplit[7].ToString();
    //                    //dtPickList.Rows[counter - 1]["dcRMCode"] = "BASE OIL";
    //                    //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[35])) / 100);
    //                    //dtPickList.Rows[counter - 1]["Qty"] = R_qty.ToString();

    //                    //DataRow dr1 = dtPickList.NewRow();
    //                    //dtPickList.Rows.Add(dr1);

    //                    string RMCode1 = recordsSplit[8].ToString();
    //                    string PackType1 = "BASE OIL";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[36])) / 100);
    //                    string Qty1 = R_qty.ToString();

    //                    dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1);
    //                    counter = dtPickList.Rows.Count;

    //                    //dtPickList.Rows[counter]["RMCode"] = recordsSplit[8].ToString();
    //                    //dtPickList.Rows[counter]["PackType"] = "BASE OIL";
    //                    //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[36])) / 100);
    //                    //dtPickList.Rows[counter]["Qty"] = R_qty.ToString();
    //                }


    //                #endregion

    //                #region BA

    //                str1_BA = Convert.ToInt32(recordsSplit[3]);

    //                if (str1_BA > 0)
    //                {
    //                    if (Convert.ToString(Convert.ToString(dtPickList.Rows[counter - 1]["PackType"])) != "")
    //                    {
    //                        counter = counter + 1;

    //                        string RMCode = recordsSplit[9].ToString();
    //                        string PackType = "BULK ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[37])) / 100);
    //                        string Qty = R_qty.ToString();

    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;

    //                        //dtPickList.Rows[counter]["RMCode"] = recordsSplit[9].ToString();
    //                        //dtPickList.Rows[counter]["PackType"] = "BULK ADDITIVE";
    //                        //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[37])) / 100);
    //                        //dtPickList.Rows[counter]["Qty"] = R_qty.ToString();
    //                    }
    //                    else
    //                    {
    //                        string RMCode = recordsSplit[9].ToString();
    //                        string PackType = "BULK ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[37])) / 100);
    //                        string Qty = R_qty.ToString();

    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                        //dtPickList.Rows[counter]["RMCode"] = recordsSplit[9].ToString();
    //                        //dtPickList.Rows[counter]["PackType"] = "BULK ADDITIVE";
    //                        //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[37])) / 100);
    //                        //dtPickList.Rows[counter]["Qty"] = R_qty.ToString();
    //                    }
    //                }

    //                if (str1_BA > 1)
    //                {
    //                    counter = counter + str1_BA;
    //                    counter = counter - 1;
    //                }

    //                if (str1_BA == 2)
    //                {
    //                    string RMCode = recordsSplit[10].ToString();
    //                    string PackType = "BULK ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[38])) / 100);
    //                    string Qty = R_qty.ToString();

    //                    dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                    counter = dtPickList.Rows.Count;

    //                    //dtPickList.Rows[counter]["RMCode"] = recordsSplit[10].ToString();
    //                    //dtPickList.Rows[counter]["PackType"] = "BULK ADDITIVE";
    //                    //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[38])) / 100);
    //                    //dtPickList.Rows[counter]["Qty"] = R_qty.ToString();
    //                }

    //                else if (str1_BA == 3)
    //                {


    //                    string RMCode = recordsSplit[10].ToString();
    //                    string PackType = "BULK ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[38])) / 100);
    //                    string Qty = R_qty.ToString();

    //                    dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode1 = recordsSplit[11].ToString();
    //                    string PackType1 = "BULK ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[39])) / 100);
    //                    string Qty1 = R_qty.ToString();

    //                    dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1);
    //                    counter = dtPickList.Rows.Count;

    //                    //dtPickList.Rows[counter - 1]["RMCode"] = recordsSplit[10].ToString();
    //                    //dtPickList.Rows[counter - 1]["dcRMCode"] = "BASE OIL";
    //                    //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[38])) / 100);
    //                    //dtPickList.Rows[counter - 1]["Qty"] = R_qty.ToString();




    //                    //dtPickList.Rows[counter]["RMCode"] = recordsSplit[8].ToString();
    //                    //dtPickList.Rows[counter]["PackType"] = "BULK ADDITIVE";
    //                    //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[39])) / 100);
    //                    //dtPickList.Rows[counter]["Qty"] = R_qty.ToString();
    //                }

    //                else if (str1_BA == 4)
    //                {

    //                    string RMCode = recordsSplit[10].ToString();
    //                    string PackType = "BULK ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[38])) / 100);
    //                    string Qty = R_qty.ToString();

    //                    dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                    counter = dtPickList.Rows.Count;

    //                    //dtPickList.Rows[counter - 2]["RMCode"] = recordsSplit[10].ToString();
    //                    //dtPickList.Rows[counter - 2]["dcRMCode"] = "BASE OIL";
    //                    //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[38])) / 100);
    //                    //dtPickList.Rows[counter - 2]["Qty"] = R_qty.ToString();

    //                    string RMCode1 = recordsSplit[11].ToString();
    //                    string PackType1 = "BULK ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[39])) / 100);
    //                    string Qty1 = R_qty.ToString();

    //                    dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1);
    //                    counter = dtPickList.Rows.Count;

    //                    //dtPickList.Rows[counter - 1]["RMCode"] = recordsSplit[11].ToString();
    //                    //dtPickList.Rows[counter - 1]["dcRMCode"] = "BASE OIL";
    //                    //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[39])) / 100);
    //                    //dtPickList.Rows[counter - 1]["Qty"] = R_qty.ToString();

    //                    string RMCode2 = recordsSplit[12].ToString();
    //                    string PackType2 = "BULK ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[40])) / 100);
    //                    string Qty2 = R_qty.ToString();

    //                    dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2);
    //                    counter = dtPickList.Rows.Count;

    //                    //dtPickList.Rows[counter]["RMCode"] = recordsSplit[12].ToString();
    //                    //dtPickList.Rows[counter]["PackType"] = "BULK ADDITIVE";
    //                    //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[40])) / 100);
    //                    //dtPickList.Rows[counter]["Qty"] = R_qty.ToString();


    //                }
    //                else if (str1_BA == 5)
    //                {

    //                    string RMCode = recordsSplit[10].ToString();
    //                    string PackType = "BULK ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[38])) / 100);
    //                    string Qty = R_qty.ToString();

    //                    dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                    counter = dtPickList.Rows.Count;

    //                    //dtPickList.Rows[counter - 2]["RMCode"] = recordsSplit[10].ToString();
    //                    //dtPickList.Rows[counter - 2]["dcRMCode"] = "BASE OIL";
    //                    //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[38])) / 100);
    //                    //dtPickList.Rows[counter - 2]["Qty"] = R_qty.ToString();

    //                    string RMCode1 = recordsSplit[11].ToString();
    //                    string PackType1 = "BULK ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[39])) / 100);
    //                    string Qty1 = R_qty.ToString();

    //                    dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1);
    //                    counter = dtPickList.Rows.Count;

    //                    //dtPickList.Rows[counter - 1]["RMCode"] = recordsSplit[11].ToString();
    //                    //dtPickList.Rows[counter - 1]["dcRMCode"] = "BASE OIL";
    //                    //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[39])) / 100);
    //                    //dtPickList.Rows[counter - 1]["Qty"] = R_qty.ToString();

    //                    string RMCode2 = recordsSplit[12].ToString();
    //                    string PackType2 = "BULK ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[40])) / 100);
    //                    string Qty2 = R_qty.ToString();

    //                    dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2);
    //                    counter = dtPickList.Rows.Count;

    //                    //dtPickList.Rows[counter - 3]["RMCode"] = recordsSplit[10].ToString();
    //                    //dtPickList.Rows[counter - 3]["dcRMCode"] = "BASE OIL";
    //                    //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[38])) / 100);
    //                    //dtPickList.Rows[counter - 3]["Qty"] = R_qty.ToString();

    //                    //dtPickList.Rows[counter - 2]["RMCode"] = recordsSplit[11].ToString();
    //                    //dtPickList.Rows[counter - 2]["dcRMCode"] = "BASE OIL";
    //                    //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[39])) / 100);
    //                    //dtPickList.Rows[counter - 2]["Qty"] = R_qty.ToString();

    //                    //dtPickList.Rows[counter - 1]["RMCode"] = recordsSplit[12].ToString();
    //                    //dtPickList.Rows[counter - 1]["dcRMCode"] = "BASE OIL";
    //                    //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[40])) / 100);
    //                    //dtPickList.Rows[counter - 1]["Qty"] = R_qty.ToString();

    //                    string RMCode3 = recordsSplit[12].ToString();
    //                    string PackType3 = "BULK ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[40])) / 100);
    //                    string Qty3 = R_qty.ToString();

    //                    dtPickList.Rows.Add("", "", RMCode3, "", PackType3, "", Qty3);
    //                    counter = dtPickList.Rows.Count;

    //                    //dtPickList.Rows[counter]["RMCode"] = recordsSplit[13].ToString();
    //                    //dtPickList.Rows[counter]["PackType"] = "BULK ADDITIVE";
    //                    //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[41])) / 100);
    //                    //dtPickList.Rows[counter]["Qty"] = R_qty.ToString();

    //                }
    //                #endregion

    //                #region DA

    //                str1_DA = Convert.ToInt32(recordsSplit[4]);

    //                if (str1_DA > 0)
    //                {
    //                    if ((Convert.ToString(dtPickList.Rows[counter - 1]["PackType"])) != "")
    //                    {
    //                        counter = counter + 1;

    //                        string RMCode = recordsSplit[14].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[42])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;


    //                    }
    //                    else
    //                    {
    //                        string RMCode = recordsSplit[14].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[42])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;


    //                    }
    //                }

    //                if (str1_DA > 1)
    //                {
    //                    counter = counter + 9;
    //                    if (recordsSplit[15].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[15].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }

    //                    if (recordsSplit[16].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[16].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[17].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[17].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[18].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[18].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[19].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[19].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }


    //                    if (recordsSplit[20].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[20].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[21].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[21].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[22].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[22].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[23].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[23].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }


    //                }


    //                if (str1_DA == 2)
    //                {
    //                    counter = counter + 8;
    //                    if (recordsSplit[15].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[15].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }

    //                    if (recordsSplit[16].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[16].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[17].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[17].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[18].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[18].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[19].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[19].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }


    //                    if (recordsSplit[20].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[20].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[21].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[21].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[22].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[22].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[23].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[23].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                }

    //                if (str1_DA == 3)
    //                {
    //                    counter = counter + 7;
    //                    if (recordsSplit[15].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[15].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }

    //                    if (recordsSplit[16].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[16].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[17].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[17].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[18].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[18].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[19].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[19].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }


    //                    if (recordsSplit[20].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[20].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[21].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[21].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[22].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[22].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[23].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[23].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }


    //                }

    //                if (str1_DA == 4)
    //                {
    //                    counter = counter + 6;
    //                    if (recordsSplit[15].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[15].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }

    //                    if (recordsSplit[16].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[16].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[17].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[17].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[18].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[18].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[19].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[19].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }


    //                    if (recordsSplit[20].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[20].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[21].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[21].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[22].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[22].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[23].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[23].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }


    //                }

    //                if (str1_DA == 5)
    //                {
    //                    counter = counter + 5;
    //                    if (recordsSplit[15].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[15].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }

    //                    if (recordsSplit[16].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[16].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[17].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[17].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[18].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[18].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[19].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[19].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }


    //                    if (recordsSplit[20].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[20].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[21].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[21].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[22].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[22].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[23].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[23].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }


    //                }

    //                if (str1_DA == 7)
    //                {
    //                    counter = counter + 3;
    //                    if (recordsSplit[15].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[15].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }

    //                    if (recordsSplit[16].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[16].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[17].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[17].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[18].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[18].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[19].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[19].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }


    //                    if (recordsSplit[20].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[20].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[21].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[21].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[22].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[22].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[23].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[23].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                }

    //                if (str1_DA == 8)
    //                {
    //                    counter = counter + 2;
    //                    if (recordsSplit[15].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[15].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }

    //                    if (recordsSplit[16].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[16].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[17].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[17].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[18].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[18].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[19].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[19].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }


    //                    if (recordsSplit[20].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[20].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[21].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[21].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[22].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[22].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[23].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[23].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }


    //                }

    //                if (str1_DA == 9)
    //                {
    //                    counter = counter + 1;
    //                    if (recordsSplit[15].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[15].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }

    //                    if (recordsSplit[16].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[16].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[17].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[17].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[18].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[18].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[19].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[19].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }


    //                    if (recordsSplit[20].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[20].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[21].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[21].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[22].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[22].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[23].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[23].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                }

    //                if (str1_DA == 10)
    //                {

    //                    if (recordsSplit[15].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[15].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }

    //                    if (recordsSplit[16].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[16].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[17].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[17].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[18].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[18].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[19].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[19].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }


    //                    if (recordsSplit[20].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[20].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[21].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[21].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[22].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[22].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }

    //                    if (recordsSplit[23].ToString() != "NIL")
    //                    {
    //                        string RMCode = recordsSplit[23].ToString();
    //                        string PackType = "DRUM ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;
    //                    }
    //                    else
    //                    {
    //                        counter = counter - 1;
    //                    }


    //                }

    //                #endregion

    //                #region MA


    //                str1_MA = Convert.ToInt32(recordsSplit[5]);

    //                if (str1_MA > 0)
    //                {
    //                    if ((Convert.ToString(dtPickList.Rows[counter - 1]["PackType"])) != "")
    //                    {
    //                        counter = counter + 1;

    //                        string RMCode = recordsSplit[24].ToString();
    //                        string PackType = "MANUAL ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[52])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;

    //                    }

    //                    else
    //                    {
    //                        string RMCode = recordsSplit[24].ToString();
    //                        string PackType = "MANUAL ADDITIVE";
    //                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[52])) / 100);
    //                        string Qty = R_qty.ToString();
    //                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                        counter = dtPickList.Rows.Count;

    //                    }

    //                }

    //                if (str1_MA > 1)
    //                {
    //                    counter = counter + str1_MA;
    //                    counter = counter - 1;
    //                }

    //                if (str1_MA == 2)
    //                {
    //                    string RMCode = recordsSplit[25].ToString();
    //                    string PackType = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
    //                    string Qty = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                    counter = dtPickList.Rows.Count;


    //                }

    //                if (str1_MA == 3)
    //                {
    //                    string RMCode = recordsSplit[25].ToString();
    //                    string PackType = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
    //                    string Qty = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode1 = recordsSplit[26].ToString();
    //                    string PackType1 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
    //                    string Qty1 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1);
    //                    counter = dtPickList.Rows.Count;

    //                }

    //                if (str1_MA == 4)
    //                {

    //                    string RMCode = recordsSplit[25].ToString();
    //                    string PackType = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
    //                    string Qty = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode1 = recordsSplit[26].ToString();
    //                    string PackType1 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
    //                    string Qty1 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1);
    //                    counter = dtPickList.Rows.Count;


    //                    string RMCode2 = recordsSplit[27].ToString();
    //                    string PackType2 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[55])) / 100);
    //                    string Qty2 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2);
    //                    counter = dtPickList.Rows.Count;

    //                    //excelWorksheet.Cells[R, 3] = recordsSplit[27].ToString();
    //                    //excelWorksheet.Cells[R, 5] = "MANUAL ADDITIVE";
    //                    //R_qty = ((STR_QNTY * Convert.ToDouble(recordsSplit[55])) / 100);
    //                    //excelWorksheet.Cells[R, 7] = R_qty.ToString();

    //                }

    //                if (str1_MA == 5)
    //                {
    //                    string RMCode = recordsSplit[25].ToString();
    //                    string PackType = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
    //                    string Qty = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode1 = recordsSplit[26].ToString();
    //                    string PackType1 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
    //                    string Qty1 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1);
    //                    counter = dtPickList.Rows.Count;


    //                    string RMCode2 = recordsSplit[27].ToString();
    //                    string PackType2 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[55])) / 100);
    //                    string Qty2 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode3 = recordsSplit[28].ToString();
    //                    string PackType3 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[56])) / 100);
    //                    string Qty3 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode3, "", PackType3, "", Qty3);
    //                    counter = dtPickList.Rows.Count;

    //                }

    //                if (str1_MA == 6)
    //                {
    //                    string RMCode = recordsSplit[25].ToString();
    //                    string PackType = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
    //                    string Qty = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode1 = recordsSplit[26].ToString();
    //                    string PackType1 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
    //                    string Qty1 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1);
    //                    counter = dtPickList.Rows.Count;


    //                    string RMCode2 = recordsSplit[27].ToString();
    //                    string PackType2 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[55])) / 100);
    //                    string Qty2 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode3 = recordsSplit[28].ToString();
    //                    string PackType3 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[56])) / 100);
    //                    string Qty3 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode3, "", PackType3, "", Qty3);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode4 = recordsSplit[29].ToString();
    //                    string PackType4 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[57])) / 100);
    //                    string Qty4 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode4, "", PackType4, "", Qty4);
    //                    counter = dtPickList.Rows.Count;



    //                }

    //                if (str1_MA == 7)
    //                {
    //                    string RMCode = recordsSplit[25].ToString();
    //                    string PackType = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
    //                    string Qty = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode1 = recordsSplit[26].ToString();
    //                    string PackType1 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
    //                    string Qty1 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1);
    //                    counter = dtPickList.Rows.Count;


    //                    string RMCode2 = recordsSplit[27].ToString();
    //                    string PackType2 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[55])) / 100);
    //                    string Qty2 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode3 = recordsSplit[28].ToString();
    //                    string PackType3 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[56])) / 100);
    //                    string Qty3 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode3, "", PackType3, "", Qty3);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode4 = recordsSplit[29].ToString();
    //                    string PackType4 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[57])) / 100);
    //                    string Qty4 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode4, "", PackType4, "", Qty4);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode5 = recordsSplit[30].ToString();
    //                    string PackType5 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[58])) / 100);
    //                    string Qty5 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode5, "", PackType5, "", Qty5);
    //                    counter = dtPickList.Rows.Count;

    //                }

    //                if (str1_MA == 8)
    //                {
    //                    string RMCode = recordsSplit[25].ToString();
    //                    string PackType = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
    //                    string Qty = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode1 = recordsSplit[26].ToString();
    //                    string PackType1 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
    //                    string Qty1 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1);
    //                    counter = dtPickList.Rows.Count;


    //                    string RMCode2 = recordsSplit[27].ToString();
    //                    string PackType2 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[55])) / 100);
    //                    string Qty2 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode3 = recordsSplit[28].ToString();
    //                    string PackType3 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[56])) / 100);
    //                    string Qty3 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode3, "", PackType3, "", Qty3);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode4 = recordsSplit[29].ToString();
    //                    string PackType4 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[57])) / 100);
    //                    string Qty4 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode4, "", PackType4, "", Qty4);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode5 = recordsSplit[30].ToString();
    //                    string PackType5 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[58])) / 100);
    //                    string Qty5 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode5, "", PackType5, "", Qty5);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode6 = recordsSplit[31].ToString();
    //                    string PackType6 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[59])) / 100);
    //                    string Qty6 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode6, "", PackType6, "", Qty6);
    //                    counter = dtPickList.Rows.Count;

    //                }

    //                if (str1_MA == 9)
    //                {
    //                    string RMCode = recordsSplit[25].ToString();
    //                    string PackType = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
    //                    string Qty = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode1 = recordsSplit[26].ToString();
    //                    string PackType1 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
    //                    string Qty1 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1);
    //                    counter = dtPickList.Rows.Count;


    //                    string RMCode2 = recordsSplit[27].ToString();
    //                    string PackType2 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[55])) / 100);
    //                    string Qty2 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode3 = recordsSplit[28].ToString();
    //                    string PackType3 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[56])) / 100);
    //                    string Qty3 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode3, "", PackType3, "", Qty3);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode4 = recordsSplit[29].ToString();
    //                    string PackType4 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[57])) / 100);
    //                    string Qty4 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode4, "", PackType4, "", Qty4);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode5 = recordsSplit[30].ToString();
    //                    string PackType5 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[58])) / 100);
    //                    string Qty5 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode5, "", PackType5, "", Qty5);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode6 = recordsSplit[31].ToString();
    //                    string PackType6 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[59])) / 100);
    //                    string Qty6 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode6, "", PackType6, "", Qty6);
    //                    counter = dtPickList.Rows.Count;


    //                    string RMCode7 = recordsSplit[32].ToString();
    //                    string PackType7 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[60])) / 100);
    //                    string Qty7 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode7, "", PackType7, "", Qty7);
    //                    counter = dtPickList.Rows.Count;

    //                }

    //                if (str1_MA == 10)
    //                {
    //                    string RMCode = recordsSplit[25].ToString();
    //                    string PackType = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
    //                    string Qty = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode1 = recordsSplit[26].ToString();
    //                    string PackType1 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
    //                    string Qty1 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1);
    //                    counter = dtPickList.Rows.Count;


    //                    string RMCode2 = recordsSplit[27].ToString();
    //                    string PackType2 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[55])) / 100);
    //                    string Qty2 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode3 = recordsSplit[28].ToString();
    //                    string PackType3 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[56])) / 100);
    //                    string Qty3 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode3, "", PackType3, "", Qty3);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode4 = recordsSplit[29].ToString();
    //                    string PackType4 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[57])) / 100);
    //                    string Qty4 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode4, "", PackType4, "", Qty4);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode5 = recordsSplit[30].ToString();
    //                    string PackType5 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[58])) / 100);
    //                    string Qty5 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode5, "", PackType5, "", Qty5);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode6 = recordsSplit[31].ToString();
    //                    string PackType6 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[59])) / 100);
    //                    string Qty6 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode6, "", PackType6, "", Qty6);
    //                    counter = dtPickList.Rows.Count;


    //                    string RMCode7 = recordsSplit[32].ToString();
    //                    string PackType7 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[60])) / 100);
    //                    string Qty7 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode7, "", PackType7, "", Qty7);
    //                    counter = dtPickList.Rows.Count;

    //                    string RMCode8 = recordsSplit[33].ToString();
    //                    string PackType8 = "MANUAL ADDITIVE";
    //                    R_qty = ((batchSize * Convert.ToDouble(recordsSplit[61])) / 100);
    //                    string Qty8 = R_qty.ToString();
    //                    dtPickList.Rows.Add("", "", RMCode8, "", PackType8, "", Qty8);
    //                    counter = dtPickList.Rows.Count;

    //                }



    //                #endregion


    //            }

    //            for (int i = 0; i < dtPickList.Rows.Count; i++)
    //            {
    //                if (i != dtPickList.Rows.Count - 1)
    //                {
    //                    string rmCode = dtPickList.Rows[i + 1]["RMCode"].ToString();
    //                    string PackType = dtPickList.Rows[i + 1]["PackType"].ToString();
    //                    string Qty = dtPickList.Rows[i + 1]["Qty"].ToString();

    //                    dtPickList.Rows[i]["RMCode"] = rmCode;
    //                    dtPickList.Rows[i]["PackType"] = PackType;
    //                    dtPickList.Rows[i]["Qty"] = Qty;


    //                }

    //            }

    //            DataRow dr = dtPickList.Rows[dtPickList.Rows.Count - 1];

    //            dtPickList.Rows.Remove(dr);


    //            for (int i = 0; i < dtPickList.Rows.Count; i++)
    //            {
    //                string rmCode = dtPickList.Rows[i]["RMCode"].ToString();

    //                if (rmCode != "")
    //                {
    //                    DataTable dtRmData = DAL.getRMData(rmCode);

    //                    if (dtRmData.Rows.Count > 0)
    //                    {
    //                        string rmDesc = dtRmData.Rows[0]["RM_DESC"].ToString();
    //                        string rmPrecaution = dtRmData.Rows[0]["PRECAUTION"].ToString();

    //                        dtPickList.Rows[i]["RMDescription"] = rmDesc;
    //                        dtPickList.Rows[i]["Precautions"] = rmPrecaution;

    //                    }
    //                }

    //            }



    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        this.LogError(ex);
    //    }
    //    finally
    //    {

    //    }

    //    return dtPickList;
    //}

    public DataTable GetPickListDDU()
    {
        DataTable dt = new DataTable();

        DataTable dtPickList = new DataTable();

        DataColumn dcFamily = new DataColumn("Family");
        DataColumn dcFGCode = new DataColumn("FGCode");
        DataColumn dcRMCode = new DataColumn("RMCode");
        DataColumn dcRMDescription = new DataColumn("RMDescription");
        DataColumn dcPackType = new DataColumn("PackType");
        DataColumn dcPrecautions = new DataColumn("Precautions");
        DataColumn dcQty = new DataColumn("Qty");
        DataColumn dcBatchSize = new DataColumn("BatchSize");
        DataColumn dcRMType = new DataColumn("RMType");

        dtPickList.Columns.Add(dcFamily);
        dtPickList.Columns.Add(dcFGCode);
        dtPickList.Columns.Add(dcRMCode);
        dtPickList.Columns.Add(dcRMDescription);
        dtPickList.Columns.Add(dcPackType);
        dtPickList.Columns.Add(dcPrecautions);
        dtPickList.Columns.Add(dcQty);
        dtPickList.Columns.Add(dcBatchSize);
        dtPickList.Columns.Add(dcRMType);

        int counter = 0;

        try
        {
            dt = DAL.GetPickList();

            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string currentSheet = "Sheet1";

                    string FRMULA = "";
                    string FORMULA_NO = "";
                    string Csv_File = "";
                    string path_Csv = "";

                    int str1_BO = 0;
                    int str1_BA = 0;
                    int str1_MA = 0;
                    int str1_DA = 0;
                    double R_qty = 0.0;

                    string family = dt.Rows[i]["FAMILY"].ToString();
                    string productName = dt.Rows[i]["PRODUCT"].ToString();
                    string productName1 = dt.Rows[i]["PRODUCT"].ToString() + " - " + dt.Rows[i]["PROD_DESC"].ToString();
                    double batchSize = Convert.ToDouble(dt.Rows[i]["BSIZE"]);
                    string formula = dt.Rows[i]["FORMULA"].ToString();

                    FRMULA = "FORMULA" + formula;
                    FORMULA_NO = formula;

                    Csv_File = productName + "_" + "F" + FORMULA_NO;
                    path_Csv = @"C:\CASTROL\PRODUCTS\" + family + @"\FORMULA\" + FRMULA + @"\" + Csv_File + @".CSV";

                    string csvData = GetDataTabletFromCSVFile(path_Csv);

                    string[] recordsSplit = csvData.Split(',');

                    #region DA

                    str1_DA = Convert.ToInt32(recordsSplit[4]);
                    dtPickList.Rows.Add(family, productName1, "", "", "", "", "", batchSize.ToString());
                    counter = dtPickList.Rows.Count;

                    if (str1_DA > 0)
                    {
                        if ((Convert.ToString(dtPickList.Rows[counter - 1]["PackType"])) == "")
                        {
                            counter = counter + 1;

                            string RMCode = recordsSplit[14].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[42])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;


                        }
                        else
                        {
                            string RMCode = recordsSplit[14].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[42])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;


                        }
                    }

                    if (str1_DA == 1)
                    {
                        counter = counter + 9;
                        if (recordsSplit[15].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[15].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }

                        if (recordsSplit[16].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[16].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[17].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[17].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[18].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[18].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[19].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[19].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                        if (recordsSplit[20].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[20].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[21].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[21].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[22].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[22].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[23].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[23].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                    }


                    if (str1_DA == 2)
                    {
                        counter = counter + 8;
                        if (recordsSplit[15].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[15].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }

                        if (recordsSplit[16].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[16].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[17].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[17].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[18].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[18].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[19].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[19].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                        if (recordsSplit[20].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[20].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[21].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[21].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[22].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[22].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[23].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[23].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                    }

                    if (str1_DA == 3)
                    {
                        counter = counter + 7;
                        if (recordsSplit[15].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[15].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }

                        if (recordsSplit[16].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[16].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[17].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[17].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[18].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[18].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[19].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[19].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                        if (recordsSplit[20].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[20].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[21].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[21].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[22].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[22].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[23].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[23].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                    }

                    if (str1_DA == 4)
                    {
                        counter = counter + 6;
                        if (recordsSplit[15].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[15].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }

                        if (recordsSplit[16].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[16].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[17].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[17].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[18].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[18].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[19].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[19].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                        if (recordsSplit[20].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[20].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[21].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[21].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[22].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[22].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[23].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[23].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                    }

                    if (str1_DA == 5)
                    {
                        counter = counter + 5;
                        if (recordsSplit[15].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[15].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }

                        if (recordsSplit[16].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[16].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[17].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[17].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[18].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[18].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[19].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[19].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                        if (recordsSplit[20].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[20].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[21].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[21].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[22].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[22].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[23].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[23].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                    }


                    if (str1_DA == 6)
                    {
                        counter = counter + 3;
                        if (recordsSplit[15].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[15].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }

                        if (recordsSplit[16].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[16].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[17].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[17].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[18].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[18].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[19].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[19].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                        if (recordsSplit[20].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[20].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[21].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[21].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[22].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[22].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[23].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[23].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                    }

                    if (str1_DA == 7)
                    {
                        counter = counter + 3;
                        if (recordsSplit[15].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[15].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }

                        if (recordsSplit[16].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[16].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[17].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[17].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[18].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[18].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[19].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[19].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                        if (recordsSplit[20].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[20].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[21].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[21].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[22].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[22].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[23].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[23].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                    }

                    if (str1_DA == 8)
                    {
                        counter = counter + 2;
                        if (recordsSplit[15].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[15].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }

                        if (recordsSplit[16].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[16].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[17].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[17].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[18].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[18].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[19].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[19].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                        if (recordsSplit[20].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[20].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[21].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[21].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[22].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[22].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[23].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[23].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                    }

                    if (str1_DA == 9)
                    {
                        counter = counter + 1;
                        if (recordsSplit[15].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[15].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }

                        if (recordsSplit[16].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[16].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[17].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[17].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[18].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[18].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[19].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[19].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                        if (recordsSplit[20].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[20].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[21].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[21].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[22].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[22].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[23].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[23].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                    }

                    if (str1_DA == 10)
                    {

                        if (recordsSplit[15].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[15].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }

                        if (recordsSplit[16].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[16].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[17].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[17].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[18].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[18].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[19].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[19].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                        if (recordsSplit[20].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[20].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[21].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[21].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[22].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[22].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[23].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[23].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                    }

                    #endregion

                    #region MA


                    str1_MA = Convert.ToInt32(recordsSplit[5]);
                    counter = dtPickList.Rows.Count;
                    if (str1_MA > 0)
                    {
                        if ((Convert.ToString(dtPickList.Rows[counter - 1]["PackType"])) == "")
                        {
                            counter = counter + 1;

                            string RMCode = recordsSplit[24].ToString();
                            string PackType = "MANUAL ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[52])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "MA");
                            counter = dtPickList.Rows.Count;

                        }

                        else
                        {
                            string RMCode = recordsSplit[24].ToString();
                            string PackType = "MANUAL ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[52])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "MA");
                            counter = dtPickList.Rows.Count;

                        }

                    }

                    if (str1_MA > 1)
                    {
                        counter = counter + str1_MA;
                        counter = counter - 1;
                    }

                    if (str1_MA == 2)
                    {
                        string RMCode = recordsSplit[25].ToString();
                        string PackType = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
                        string Qty = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "MA");
                        counter = dtPickList.Rows.Count;


                    }

                    if (str1_MA == 3)
                    {
                        string RMCode = recordsSplit[25].ToString();
                        string PackType = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
                        string Qty = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode1 = recordsSplit[26].ToString();
                        string PackType1 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
                        string Qty1 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1, "", "MA");
                        counter = dtPickList.Rows.Count;

                    }

                    if (str1_MA == 4)
                    {

                        string RMCode = recordsSplit[25].ToString();
                        string PackType = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
                        string Qty = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode1 = recordsSplit[26].ToString();
                        string PackType1 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
                        string Qty1 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1, "", "MA");
                        counter = dtPickList.Rows.Count;


                        string RMCode2 = recordsSplit[27].ToString();
                        string PackType2 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[55])) / 100);
                        string Qty2 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2, "", "MA");
                        counter = dtPickList.Rows.Count;

                        //excelWorksheet.Cells[R, 3] = recordsSplit[27].ToString();
                        //excelWorksheet.Cells[R, 5] = "MANUAL ADDITIVE";
                        //R_qty = ((STR_QNTY * Convert.ToDouble(recordsSplit[55])) / 100);
                        //excelWorksheet.Cells[R, 7] = R_qty.ToString();

                    }

                    if (str1_MA == 5)
                    {
                        string RMCode = recordsSplit[25].ToString();
                        string PackType = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
                        string Qty = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode1 = recordsSplit[26].ToString();
                        string PackType1 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
                        string Qty1 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1, "", "MA");
                        counter = dtPickList.Rows.Count;


                        string RMCode2 = recordsSplit[27].ToString();
                        string PackType2 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[55])) / 100);
                        string Qty2 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode3 = recordsSplit[28].ToString();
                        string PackType3 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[56])) / 100);
                        string Qty3 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode3, "", PackType3, "", Qty3, "", "MA");
                        counter = dtPickList.Rows.Count;

                    }

                    if (str1_MA == 6)
                    {
                        string RMCode = recordsSplit[25].ToString();
                        string PackType = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
                        string Qty = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode1 = recordsSplit[26].ToString();
                        string PackType1 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
                        string Qty1 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1, "", "MA");
                        counter = dtPickList.Rows.Count;


                        string RMCode2 = recordsSplit[27].ToString();
                        string PackType2 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[55])) / 100);
                        string Qty2 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode3 = recordsSplit[28].ToString();
                        string PackType3 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[56])) / 100);
                        string Qty3 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode3, "", PackType3, "", Qty3, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode4 = recordsSplit[29].ToString();
                        string PackType4 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[57])) / 100);
                        string Qty4 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode4, "", PackType4, "", Qty4, "", "MA");
                        counter = dtPickList.Rows.Count;



                    }

                    if (str1_MA == 7)
                    {
                        string RMCode = recordsSplit[25].ToString();
                        string PackType = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
                        string Qty = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode1 = recordsSplit[26].ToString();
                        string PackType1 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
                        string Qty1 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1, "", "MA");
                        counter = dtPickList.Rows.Count;


                        string RMCode2 = recordsSplit[27].ToString();
                        string PackType2 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[55])) / 100);
                        string Qty2 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode3 = recordsSplit[28].ToString();
                        string PackType3 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[56])) / 100);
                        string Qty3 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode3, "", PackType3, "", Qty3, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode4 = recordsSplit[29].ToString();
                        string PackType4 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[57])) / 100);
                        string Qty4 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode4, "", PackType4, "", Qty4, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode5 = recordsSplit[30].ToString();
                        string PackType5 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[58])) / 100);
                        string Qty5 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode5, "", PackType5, "", Qty5, "", "MA");
                        counter = dtPickList.Rows.Count;

                    }

                    if (str1_MA == 8)
                    {
                        string RMCode = recordsSplit[25].ToString();
                        string PackType = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
                        string Qty = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode1 = recordsSplit[26].ToString();
                        string PackType1 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
                        string Qty1 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1, "", "MA");
                        counter = dtPickList.Rows.Count;


                        string RMCode2 = recordsSplit[27].ToString();
                        string PackType2 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[55])) / 100);
                        string Qty2 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode3 = recordsSplit[28].ToString();
                        string PackType3 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[56])) / 100);
                        string Qty3 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode3, "", PackType3, "", Qty3, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode4 = recordsSplit[29].ToString();
                        string PackType4 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[57])) / 100);
                        string Qty4 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode4, "", PackType4, "", Qty4, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode5 = recordsSplit[30].ToString();
                        string PackType5 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[58])) / 100);
                        string Qty5 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode5, "", PackType5, "", Qty5, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode6 = recordsSplit[31].ToString();
                        string PackType6 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[59])) / 100);
                        string Qty6 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode6, "", PackType6, "", Qty6, "", "MA");
                        counter = dtPickList.Rows.Count;

                    }

                    if (str1_MA == 9)
                    {
                        string RMCode = recordsSplit[25].ToString();
                        string PackType = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
                        string Qty = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode1 = recordsSplit[26].ToString();
                        string PackType1 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
                        string Qty1 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1, "", "MA");
                        counter = dtPickList.Rows.Count;


                        string RMCode2 = recordsSplit[27].ToString();
                        string PackType2 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[55])) / 100);
                        string Qty2 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode3 = recordsSplit[28].ToString();
                        string PackType3 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[56])) / 100);
                        string Qty3 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode3, "", PackType3, "", Qty3, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode4 = recordsSplit[29].ToString();
                        string PackType4 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[57])) / 100);
                        string Qty4 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode4, "", PackType4, "", Qty4, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode5 = recordsSplit[30].ToString();
                        string PackType5 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[58])) / 100);
                        string Qty5 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode5, "", PackType5, "", Qty5, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode6 = recordsSplit[31].ToString();
                        string PackType6 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[59])) / 100);
                        string Qty6 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode6, "", PackType6, "", Qty6, "", "MA");
                        counter = dtPickList.Rows.Count;


                        string RMCode7 = recordsSplit[32].ToString();
                        string PackType7 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[60])) / 100);
                        string Qty7 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode7, "", PackType7, "", Qty7, "", "MA");
                        counter = dtPickList.Rows.Count;

                    }

                    if (str1_MA == 10)
                    {
                        string RMCode = recordsSplit[25].ToString();
                        string PackType = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
                        string Qty = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode1 = recordsSplit[26].ToString();
                        string PackType1 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
                        string Qty1 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1, "", "MA");
                        counter = dtPickList.Rows.Count;


                        string RMCode2 = recordsSplit[27].ToString();
                        string PackType2 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[55])) / 100);
                        string Qty2 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode3 = recordsSplit[28].ToString();
                        string PackType3 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[56])) / 100);
                        string Qty3 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode3, "", PackType3, "", Qty3, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode4 = recordsSplit[29].ToString();
                        string PackType4 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[57])) / 100);
                        string Qty4 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode4, "", PackType4, "", Qty4, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode5 = recordsSplit[30].ToString();
                        string PackType5 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[58])) / 100);
                        string Qty5 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode5, "", PackType5, "", Qty5, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode6 = recordsSplit[31].ToString();
                        string PackType6 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[59])) / 100);
                        string Qty6 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode6, "", PackType6, "", Qty6, "", "MA");
                        counter = dtPickList.Rows.Count;


                        string RMCode7 = recordsSplit[32].ToString();
                        string PackType7 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[60])) / 100);
                        string Qty7 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode7, "", PackType7, "", Qty7, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode8 = recordsSplit[33].ToString();
                        string PackType8 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[61])) / 100);
                        string Qty8 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode8, "", PackType8, "", Qty8, "", "MA");
                        counter = dtPickList.Rows.Count;

                    }



                    #endregion

                }

                for (int ij = 0; ij < dtPickList.Rows.Count; ij++)
                {
                    if (ij != dtPickList.Rows.Count - 1)
                    {


                        string rmCode = dtPickList.Rows[ij + 1]["RMCode"].ToString();
                        string PackType = dtPickList.Rows[ij + 1]["PackType"].ToString();
                        string Qty = dtPickList.Rows[ij + 1]["Qty"].ToString();
                        string RMType = dtPickList.Rows[ij + 1]["RMType"].ToString();
                        if (dtPickList.Rows[ij]["RMCode"].ToString() == "")
                        {
                            dtPickList.Rows[ij]["RMCode"] = rmCode;
                            dtPickList.Rows[ij]["PackType"] = PackType;
                            dtPickList.Rows[ij]["Qty"] = Qty;
                            dtPickList.Rows[ij]["RMType"] = RMType;

                            dtPickList.Rows[ij + 1]["RMCode"] = "";
                            dtPickList.Rows[ij + 1]["PackType"] = "";
                            dtPickList.Rows[ij + 1]["Qty"] = "";
                            dtPickList.Rows[ij + 1]["RMType"] = "";
                        }




                    }

                }

                DataRow dr = dtPickList.Rows[dtPickList.Rows.Count - 1];

                dtPickList.Rows.Remove(dr);


                for (int j = 0; j < dtPickList.Rows.Count; j++)
                {
                    string rmCode = dtPickList.Rows[j]["RMCode"].ToString();

                    string rmDescription = dtPickList.Rows[j]["RMDescription"].ToString();

                    string rmType = dtPickList.Rows[j]["RMType"].ToString();

                    if (rmCode != "")
                    {
                        if (rmDescription == "")
                        {
                            DataTable dtRmData = DAL.getRMDataPickList(rmCode, rmType);

                            if (dtRmData.Rows.Count > 0)
                            {
                                string rmDesc = dtRmData.Rows[0]["PROD_DESC"].ToString();
                                string rmPrecaution = dtRmData.Rows[0]["PROD_PRECAU"].ToString();

                                dtPickList.Rows[j]["RMDescription"] = rmDesc;
                                dtPickList.Rows[j]["Precautions"] = rmPrecaution;

                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        finally
        {

        }

        return dtPickList;
    }

    public DataTable getPickListData()
    {
        DataTable dt = new DataTable();

        DataTable dtPickList = new DataTable();

        #region Add Columns

        DataColumn dcFamily = new DataColumn("Family");
        DataColumn dcFGCode = new DataColumn("FGCode");
        DataColumn dcRMCode = new DataColumn("RMCode");
        DataColumn dcRMDescription = new DataColumn("RMDescription");
        DataColumn dcPackType = new DataColumn("PackType");
        DataColumn dcPrecautions = new DataColumn("Precautions");
        DataColumn dcQty = new DataColumn("Qty");
        DataColumn dcBatchSize = new DataColumn("BatchSize");
        DataColumn dcRMType = new DataColumn("RMType");

        dtPickList.Columns.Add(dcFamily);
        dtPickList.Columns.Add(dcFGCode);
        dtPickList.Columns.Add(dcRMCode);
        dtPickList.Columns.Add(dcRMDescription);
        dtPickList.Columns.Add(dcPackType);
        dtPickList.Columns.Add(dcPrecautions);
        dtPickList.Columns.Add(dcQty);
        dtPickList.Columns.Add(dcBatchSize);
        dtPickList.Columns.Add(dcRMType);

        #endregion

        int counter = 0;

        try
        {
            dt = DAL.GetPickList();

            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string currentSheet = "Sheet1";

                    string FRMULA = "";
                    string FORMULA_NO = "";
                    string Csv_File = "";
                    string path_Csv1 = "";
                    string path_Csv2 = "";
                    string path_Csv3 = "";
                    string path_Csv4 = "";
                    string path_Csv = "";

                    int str1_BO = 0;
                    int str1_BA = 0;
                    int str1_MA = 0;
                    int str1_DA = 0;
                    double R_qty = 0.0;

                    //+" - " + dt.Rows[i]["PROD_DESC"].ToString()

                    string family = dt.Rows[i]["FAMILY"].ToString();
                    string productName = dt.Rows[i]["PRODUCT"].ToString();
                    string productName1 = dt.Rows[i]["PRODUCT"].ToString() + " - " + dt.Rows[i]["PROD_DESC"].ToString();
                    double batchSize = Convert.ToDouble(dt.Rows[i]["BSIZE"]);
                    string formula = dt.Rows[i]["FORMULA"].ToString();

                    FRMULA = "FORMULA" + formula;
                    FORMULA_NO = formula;

                    Csv_File = productName + "_" + "F" + FORMULA_NO;
                    path_Csv = @"C:\SAVITA\PRODUCTS\" + family + @"\BLENDING\FORMULA\" + FRMULA + @"\" + Csv_File + @".CSV";
                    path_Csv2 = @"C:\SAVITA\PRODUCTS\" + family + @"\DRUM_FILLING\FORMULA\" + FRMULA + @"\" + Csv_File + @".CSV";
                    path_Csv3 = @"C:\SAVITA\PRODUCTS\" + family + @"\PROCESSING\FORMULA\" + FRMULA + @"\" + Csv_File + @".CSV";
                    path_Csv4 = @"C:\SAVITA\PRODUCTS\" + family + @"\TANKER_FILLING\FORMULA\" + FRMULA + @"\" + Csv_File + @".CSV";

                    string csvData ="";

                    csvData = GetDataTabletFromCSVFile(path_Csv);

                    if (csvData == "")
                    {
                        csvData = GetDataTabletFromCSVFile(path_Csv2);

                        if (csvData == "")
                        {
                             csvData = GetDataTabletFromCSVFile(path_Csv3);

                             if (csvData == "")
                             {
                                 csvData = GetDataTabletFromCSVFile(path_Csv4);

                                 if (csvData == "")
                                 {
                                     
                                 }
                             }
                        }
                    }
                                          
                    string[] recordsSplit = csvData.Split(',');

                    #region BO

                    str1_BO = Convert.ToInt32(recordsSplit[2]);
                    //DataRow dr = dtPickList.NewRow();
                    dtPickList.Rows.Add(family, productName1, "", "", "", "", "", batchSize.ToString());
                    counter = dtPickList.Rows.Count;

                    if (str1_BO > 0)
                    {

                        if (Convert.ToString(dtPickList.Rows[counter - 1]["PackType"]) == "")
                        {
                            //R = R + 1;

                            string RMCode = recordsSplit[6].ToString();
                            string PackType = "BASE OIL";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[34])) / 100);
                            string Qty = R_qty.ToString();

                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "BO");

                            counter = dtPickList.Rows.Count;

                            //dtPickList.Rows[counter]["RMCode"] = recordsSplit[6].ToString();
                            //dtPickList.Rows[counter]["PackType"] = "BASE OIL";

                            //dtPickList.Rows[counter]["Qty"] = R_qty.ToString();

                        }
                    }
                    if (str1_BO > 1)
                    {
                        counter = counter + str1_BO;
                        counter = counter - 2;
                    }
                    if (str1_BO == 2)
                    {

                        string RMCode = recordsSplit[7].ToString();
                        string PackType = "BASE OIL";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[35])) / 100);
                        string Qty = R_qty.ToString();

                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "BO");
                        counter = dtPickList.Rows.Count;

                        //dtPickList.Rows[counter]["RMCode"] = recordsSplit[7].ToString();
                        //dtPickList.Rows[counter]["PackType"] = "BASE OIL";
                        //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[35])) / 100);
                        //dtPickList.Rows[counter]["Qty"] = R_qty.ToString();
                    }
                    else if (str1_BO == 3)
                    {
                        //DataRow dr0 = dtPickList.NewRow();
                        //dtPickList.Rows.Add(dr0);

                        string RMCode = recordsSplit[7].ToString();
                        string PackType = "BASE OIL";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[35])) / 100);
                        string Qty = R_qty.ToString();

                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "BO");
                        counter = dtPickList.Rows.Count;

                        //dtPickList.Rows[counter - 1]["RMCode"] = recordsSplit[7].ToString();
                        //dtPickList.Rows[counter - 1]["dcRMCode"] = "BASE OIL";
                        //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[35])) / 100);
                        //dtPickList.Rows[counter - 1]["Qty"] = R_qty.ToString();

                        //DataRow dr1 = dtPickList.NewRow();
                        //dtPickList.Rows.Add(dr1);

                        string RMCode1 = recordsSplit[8].ToString();
                        string PackType1 = "BASE OIL";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[36])) / 100);
                        string Qty1 = R_qty.ToString();

                        dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1, "", "BO");
                        counter = dtPickList.Rows.Count;

                        //dtPickList.Rows[counter]["RMCode"] = recordsSplit[8].ToString();
                        //dtPickList.Rows[counter]["PackType"] = "BASE OIL";
                        //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[36])) / 100);
                        //dtPickList.Rows[counter]["Qty"] = R_qty.ToString();
                    }


                    #endregion

                    #region BA

                    str1_BA = Convert.ToInt32(recordsSplit[3]);
                    counter = dtPickList.Rows.Count;
                    if (str1_BA > 0)
                    {
                        if (Convert.ToString(Convert.ToString(dtPickList.Rows[counter - 1]["PackType"])) == "")
                        {
                            counter = counter + 1;

                            string RMCode = recordsSplit[9].ToString();
                            string PackType = "BULK ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[37])) / 100);
                            string Qty = R_qty.ToString();

                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "BA");
                            counter = dtPickList.Rows.Count;

                            //dtPickList.Rows[counter]["RMCode"] = recordsSplit[9].ToString();
                            //dtPickList.Rows[counter]["PackType"] = "BULK ADDITIVE";
                            //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[37])) / 100);
                            //dtPickList.Rows[counter]["Qty"] = R_qty.ToString();
                        }
                        else
                        {
                            string RMCode = recordsSplit[9].ToString();
                            string PackType = "BULK ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[37])) / 100);
                            string Qty = R_qty.ToString();

                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "BA");
                            counter = dtPickList.Rows.Count;
                            //dtPickList.Rows[counter]["RMCode"] = recordsSplit[9].ToString();
                            //dtPickList.Rows[counter]["PackType"] = "BULK ADDITIVE";
                            //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[37])) / 100);
                            //dtPickList.Rows[counter]["Qty"] = R_qty.ToString();
                        }
                    }

                    if (str1_BA > 1)
                    {
                        counter = counter + str1_BA;
                        counter = counter - 1;
                    }

                    if (str1_BA == 2)
                    {
                        string RMCode = recordsSplit[10].ToString();
                        string PackType = "BULK ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[38])) / 100);
                        string Qty = R_qty.ToString();

                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "BA");
                        counter = dtPickList.Rows.Count;

                        //dtPickList.Rows[counter]["RMCode"] = recordsSplit[10].ToString();
                        //dtPickList.Rows[counter]["PackType"] = "BULK ADDITIVE";
                        //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[38])) / 100);
                        //dtPickList.Rows[counter]["Qty"] = R_qty.ToString();
                    }

                    else if (str1_BA == 3)
                    {


                        string RMCode = recordsSplit[10].ToString();
                        string PackType = "BULK ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[38])) / 100);
                        string Qty = R_qty.ToString();

                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "BA");
                        counter = dtPickList.Rows.Count;

                        string RMCode1 = recordsSplit[11].ToString();
                        string PackType1 = "BULK ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[39])) / 100);
                        string Qty1 = R_qty.ToString();

                        dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1, "", "BA");
                        counter = dtPickList.Rows.Count;

                        //dtPickList.Rows[counter - 1]["RMCode"] = recordsSplit[10].ToString();
                        //dtPickList.Rows[counter - 1]["dcRMCode"] = "BASE OIL";
                        //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[38])) / 100);
                        //dtPickList.Rows[counter - 1]["Qty"] = R_qty.ToString();




                        //dtPickList.Rows[counter]["RMCode"] = recordsSplit[8].ToString();
                        //dtPickList.Rows[counter]["PackType"] = "BULK ADDITIVE";
                        //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[39])) / 100);
                        //dtPickList.Rows[counter]["Qty"] = R_qty.ToString();
                    }

                    else if (str1_BA == 4)
                    {

                        string RMCode = recordsSplit[10].ToString();
                        string PackType = "BULK ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[38])) / 100);
                        string Qty = R_qty.ToString();

                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "BA");
                        counter = dtPickList.Rows.Count;

                        //dtPickList.Rows[counter - 2]["RMCode"] = recordsSplit[10].ToString();
                        //dtPickList.Rows[counter - 2]["dcRMCode"] = "BASE OIL";
                        //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[38])) / 100);
                        //dtPickList.Rows[counter - 2]["Qty"] = R_qty.ToString();

                        string RMCode1 = recordsSplit[11].ToString();
                        string PackType1 = "BULK ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[39])) / 100);
                        string Qty1 = R_qty.ToString();

                        dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1, "", "BA");
                        counter = dtPickList.Rows.Count;

                        //dtPickList.Rows[counter - 1]["RMCode"] = recordsSplit[11].ToString();
                        //dtPickList.Rows[counter - 1]["dcRMCode"] = "BASE OIL";
                        //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[39])) / 100);
                        //dtPickList.Rows[counter - 1]["Qty"] = R_qty.ToString();

                        string RMCode2 = recordsSplit[12].ToString();
                        string PackType2 = "BULK ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[40])) / 100);
                        string Qty2 = R_qty.ToString();

                        dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2, "", "BA");
                        counter = dtPickList.Rows.Count;

                        //dtPickList.Rows[counter]["RMCode"] = recordsSplit[12].ToString();
                        //dtPickList.Rows[counter]["PackType"] = "BULK ADDITIVE";
                        //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[40])) / 100);
                        //dtPickList.Rows[counter]["Qty"] = R_qty.ToString();


                    }
                    else if (str1_BA == 5)
                    {

                        string RMCode = recordsSplit[10].ToString();
                        string PackType = "BULK ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[38])) / 100);
                        string Qty = R_qty.ToString();

                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "BA");
                        counter = dtPickList.Rows.Count;

                        //dtPickList.Rows[counter - 2]["RMCode"] = recordsSplit[10].ToString();
                        //dtPickList.Rows[counter - 2]["dcRMCode"] = "BASE OIL";
                        //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[38])) / 100);
                        //dtPickList.Rows[counter - 2]["Qty"] = R_qty.ToString();

                        string RMCode1 = recordsSplit[11].ToString();
                        string PackType1 = "BULK ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[39])) / 100);
                        string Qty1 = R_qty.ToString();

                        dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1, "", "BA");
                        counter = dtPickList.Rows.Count;

                        //dtPickList.Rows[counter - 1]["RMCode"] = recordsSplit[11].ToString();
                        //dtPickList.Rows[counter - 1]["dcRMCode"] = "BASE OIL";
                        //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[39])) / 100);
                        //dtPickList.Rows[counter - 1]["Qty"] = R_qty.ToString();

                        string RMCode2 = recordsSplit[12].ToString();
                        string PackType2 = "BULK ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[40])) / 100);
                        string Qty2 = R_qty.ToString();

                        dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2, "", "BA");
                        counter = dtPickList.Rows.Count;

                        //dtPickList.Rows[counter - 3]["RMCode"] = recordsSplit[10].ToString();
                        //dtPickList.Rows[counter - 3]["dcRMCode"] = "BASE OIL";
                        //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[38])) / 100);
                        //dtPickList.Rows[counter - 3]["Qty"] = R_qty.ToString();

                        //dtPickList.Rows[counter - 2]["RMCode"] = recordsSplit[11].ToString();
                        //dtPickList.Rows[counter - 2]["dcRMCode"] = "BASE OIL";
                        //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[39])) / 100);
                        //dtPickList.Rows[counter - 2]["Qty"] = R_qty.ToString();

                        //dtPickList.Rows[counter - 1]["RMCode"] = recordsSplit[12].ToString();
                        //dtPickList.Rows[counter - 1]["dcRMCode"] = "BASE OIL";
                        //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[40])) / 100);
                        //dtPickList.Rows[counter - 1]["Qty"] = R_qty.ToString();

                        string RMCode3 = recordsSplit[12].ToString();
                        string PackType3 = "BULK ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[40])) / 100);
                        string Qty3 = R_qty.ToString();

                        dtPickList.Rows.Add("", "", RMCode3, "", PackType3, "", Qty3, "", "BA");
                        counter = dtPickList.Rows.Count;

                        //dtPickList.Rows[counter]["RMCode"] = recordsSplit[13].ToString();
                        //dtPickList.Rows[counter]["PackType"] = "BULK ADDITIVE";
                        //R_qty = ((batchSize * Convert.ToDouble(recordsSplit[41])) / 100);
                        //dtPickList.Rows[counter]["Qty"] = R_qty.ToString();

                    }
                    #endregion

                    #region DA

                    str1_DA = Convert.ToInt32(recordsSplit[4]);
                    counter = dtPickList.Rows.Count;
                    if (str1_DA > 0)
                    {
                        if ((Convert.ToString(dtPickList.Rows[counter - 1]["PackType"])) == "")
                        {
                            counter = counter + 1;

                            string RMCode = recordsSplit[14].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[42])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;


                        }
                        else
                        {
                            string RMCode = recordsSplit[14].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[42])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;


                        }
                    }

                    if (str1_DA == 1)
                    {
                        counter = counter + 9;
                        if (recordsSplit[15].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[15].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }

                        if (recordsSplit[16].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[16].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[17].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[17].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[18].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[18].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[19].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[19].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                        if (recordsSplit[20].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[20].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[21].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[21].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[22].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[22].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[23].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[23].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                    }


                    if (str1_DA == 2)
                    {
                        counter = counter + 8;
                        if (recordsSplit[15].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[15].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }

                        if (recordsSplit[16].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[16].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[17].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[17].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[18].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[18].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[19].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[19].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                        if (recordsSplit[20].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[20].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[21].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[21].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[22].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[22].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[23].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[23].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                    }

                    if (str1_DA == 3)
                    {
                        counter = counter + 7;
                        if (recordsSplit[15].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[15].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }

                        if (recordsSplit[16].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[16].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[17].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[17].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[18].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[18].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[19].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[19].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                        if (recordsSplit[20].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[20].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[21].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[21].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[22].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[22].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[23].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[23].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                    }

                    if (str1_DA == 4)
                    {
                        counter = counter + 6;
                        if (recordsSplit[15].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[15].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }

                        if (recordsSplit[16].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[16].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[17].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[17].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[18].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[18].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[19].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[19].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                        if (recordsSplit[20].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[20].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[21].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[21].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[22].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[22].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[23].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[23].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                    }

                    if (str1_DA == 5)
                    {
                        counter = counter + 5;
                        if (recordsSplit[15].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[15].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }

                        if (recordsSplit[16].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[16].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[17].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[17].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[18].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[18].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[19].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[19].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                        if (recordsSplit[20].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[20].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[21].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[21].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[22].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[22].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[23].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[23].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                    }

                    if (str1_DA == 6)
                    {
                        counter = counter + 3;
                        if (recordsSplit[15].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[15].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }

                        if (recordsSplit[16].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[16].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[17].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[17].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[18].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[18].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[19].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[19].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                        if (recordsSplit[20].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[20].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[21].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[21].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[22].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[22].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[23].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[23].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                    }

                    if (str1_DA == 7)
                    {
                        counter = counter + 3;
                        if (recordsSplit[15].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[15].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }

                        if (recordsSplit[16].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[16].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[17].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[17].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[18].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[18].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[19].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[19].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                        if (recordsSplit[20].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[20].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[21].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[21].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[22].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[22].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[23].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[23].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                    }

                    if (str1_DA == 8)
                    {
                        counter = counter + 2;
                        if (recordsSplit[15].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[15].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }

                        if (recordsSplit[16].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[16].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[17].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[17].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[18].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[18].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[19].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[19].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                        if (recordsSplit[20].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[20].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[21].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[21].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[22].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[22].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[23].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[23].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                    }

                    if (str1_DA == 9)
                    {
                        counter = counter + 1;
                        if (recordsSplit[15].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[15].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }

                        if (recordsSplit[16].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[16].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[17].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[17].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[18].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[18].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[19].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[19].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                        if (recordsSplit[20].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[20].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[21].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[21].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[22].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[22].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[23].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[23].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                    }

                    if (str1_DA == 10)
                    {

                        if (recordsSplit[15].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[15].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[43])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }

                        if (recordsSplit[16].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[16].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[44])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[17].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[17].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[45])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[18].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[18].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[46])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[19].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[19].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[47])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                        if (recordsSplit[20].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[20].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[48])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[21].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[21].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[49])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[22].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[22].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[50])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }

                        if (recordsSplit[23].ToString() != "NIL")
                        {
                            string RMCode = recordsSplit[23].ToString();
                            string PackType = "DRUM ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[51])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "DA");
                            counter = dtPickList.Rows.Count;
                        }
                        else
                        {
                            counter = counter - 1;
                        }


                    }

                    #endregion

                    #region MA


                    str1_MA = Convert.ToInt32(recordsSplit[5]);
                    counter = dtPickList.Rows.Count;
                    if (str1_MA > 0)
                    {
                        if ((Convert.ToString(dtPickList.Rows[counter - 1]["PackType"])) == "")
                        {
                            counter = counter + 1;

                            string RMCode = recordsSplit[24].ToString();
                            string PackType = "MANUAL ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[52])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "MA");
                            counter = dtPickList.Rows.Count;

                        }

                        else
                        {
                            string RMCode = recordsSplit[24].ToString();
                            string PackType = "MANUAL ADDITIVE";
                            R_qty = ((batchSize * Convert.ToDouble(recordsSplit[52])) / 100);
                            string Qty = R_qty.ToString();
                            dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "MA");
                            counter = dtPickList.Rows.Count;

                        }

                    }

                    if (str1_MA > 1)
                    {
                        counter = counter + str1_MA;
                        counter = counter - 1;
                    }

                    if (str1_MA == 2)
                    {
                        string RMCode = recordsSplit[25].ToString();
                        string PackType = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
                        string Qty = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "MA");
                        counter = dtPickList.Rows.Count;


                    }

                    if (str1_MA == 3)
                    {
                        string RMCode = recordsSplit[25].ToString();
                        string PackType = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
                        string Qty = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode1 = recordsSplit[26].ToString();
                        string PackType1 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
                        string Qty1 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1, "", "MA");
                        counter = dtPickList.Rows.Count;

                    }

                    if (str1_MA == 4)
                    {

                        string RMCode = recordsSplit[25].ToString();
                        string PackType = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
                        string Qty = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode1 = recordsSplit[26].ToString();
                        string PackType1 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
                        string Qty1 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1, "", "MA");
                        counter = dtPickList.Rows.Count;


                        string RMCode2 = recordsSplit[27].ToString();
                        string PackType2 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[55])) / 100);
                        string Qty2 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2, "", "MA");
                        counter = dtPickList.Rows.Count;

                        //excelWorksheet.Cells[R, 3] = recordsSplit[27].ToString();
                        //excelWorksheet.Cells[R, 5] = "MANUAL ADDITIVE";
                        //R_qty = ((STR_QNTY * Convert.ToDouble(recordsSplit[55])) / 100);
                        //excelWorksheet.Cells[R, 7] = R_qty.ToString();

                    }

                    if (str1_MA == 5)
                    {
                        string RMCode = recordsSplit[25].ToString();
                        string PackType = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
                        string Qty = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode1 = recordsSplit[26].ToString();
                        string PackType1 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
                        string Qty1 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1, "", "MA");
                        counter = dtPickList.Rows.Count;


                        string RMCode2 = recordsSplit[27].ToString();
                        string PackType2 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[55])) / 100);
                        string Qty2 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode3 = recordsSplit[28].ToString();
                        string PackType3 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[56])) / 100);
                        string Qty3 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode3, "", PackType3, "", Qty3, "", "MA");
                        counter = dtPickList.Rows.Count;

                    }

                    if (str1_MA == 6)
                    {
                        string RMCode = recordsSplit[25].ToString();
                        string PackType = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
                        string Qty = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode1 = recordsSplit[26].ToString();
                        string PackType1 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
                        string Qty1 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1, "", "MA");
                        counter = dtPickList.Rows.Count;


                        string RMCode2 = recordsSplit[27].ToString();
                        string PackType2 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[55])) / 100);
                        string Qty2 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode3 = recordsSplit[28].ToString();
                        string PackType3 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[56])) / 100);
                        string Qty3 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode3, "", PackType3, "", Qty3, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode4 = recordsSplit[29].ToString();
                        string PackType4 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[57])) / 100);
                        string Qty4 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode4, "", PackType4, "", Qty4, "", "MA");
                        counter = dtPickList.Rows.Count;



                    }

                    if (str1_MA == 7)
                    {
                        string RMCode = recordsSplit[25].ToString();
                        string PackType = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
                        string Qty = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode1 = recordsSplit[26].ToString();
                        string PackType1 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
                        string Qty1 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1, "", "MA");
                        counter = dtPickList.Rows.Count;


                        string RMCode2 = recordsSplit[27].ToString();
                        string PackType2 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[55])) / 100);
                        string Qty2 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode3 = recordsSplit[28].ToString();
                        string PackType3 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[56])) / 100);
                        string Qty3 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode3, "", PackType3, "", Qty3, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode4 = recordsSplit[29].ToString();
                        string PackType4 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[57])) / 100);
                        string Qty4 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode4, "", PackType4, "", Qty4, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode5 = recordsSplit[30].ToString();
                        string PackType5 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[58])) / 100);
                        string Qty5 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode5, "", PackType5, "", Qty5, "", "MA");
                        counter = dtPickList.Rows.Count;

                    }

                    if (str1_MA == 8)
                    {
                        string RMCode = recordsSplit[25].ToString();
                        string PackType = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
                        string Qty = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode1 = recordsSplit[26].ToString();
                        string PackType1 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
                        string Qty1 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1, "", "MA");
                        counter = dtPickList.Rows.Count;


                        string RMCode2 = recordsSplit[27].ToString();
                        string PackType2 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[55])) / 100);
                        string Qty2 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode3 = recordsSplit[28].ToString();
                        string PackType3 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[56])) / 100);
                        string Qty3 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode3, "", PackType3, "", Qty3, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode4 = recordsSplit[29].ToString();
                        string PackType4 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[57])) / 100);
                        string Qty4 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode4, "", PackType4, "", Qty4, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode5 = recordsSplit[30].ToString();
                        string PackType5 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[58])) / 100);
                        string Qty5 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode5, "", PackType5, "", Qty5, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode6 = recordsSplit[31].ToString();
                        string PackType6 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[59])) / 100);
                        string Qty6 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode6, "", PackType6, "", Qty6, "", "MA");
                        counter = dtPickList.Rows.Count;

                    }

                    if (str1_MA == 9)
                    {
                        string RMCode = recordsSplit[25].ToString();
                        string PackType = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
                        string Qty = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode1 = recordsSplit[26].ToString();
                        string PackType1 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
                        string Qty1 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1, "", "MA");
                        counter = dtPickList.Rows.Count;


                        string RMCode2 = recordsSplit[27].ToString();
                        string PackType2 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[55])) / 100);
                        string Qty2 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode3 = recordsSplit[28].ToString();
                        string PackType3 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[56])) / 100);
                        string Qty3 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode3, "", PackType3, "", Qty3, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode4 = recordsSplit[29].ToString();
                        string PackType4 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[57])) / 100);
                        string Qty4 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode4, "", PackType4, "", Qty4, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode5 = recordsSplit[30].ToString();
                        string PackType5 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[58])) / 100);
                        string Qty5 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode5, "", PackType5, "", Qty5, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode6 = recordsSplit[31].ToString();
                        string PackType6 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[59])) / 100);
                        string Qty6 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode6, "", PackType6, "", Qty6, "", "MA");
                        counter = dtPickList.Rows.Count;


                        string RMCode7 = recordsSplit[32].ToString();
                        string PackType7 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[60])) / 100);
                        string Qty7 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode7, "", PackType7, "", Qty7, "", "MA");
                        counter = dtPickList.Rows.Count;

                    }

                    if (str1_MA == 10)
                    {
                        string RMCode = recordsSplit[25].ToString();
                        string PackType = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[53])) / 100);
                        string Qty = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode, "", PackType, "", Qty, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode1 = recordsSplit[26].ToString();
                        string PackType1 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[54])) / 100);
                        string Qty1 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode1, "", PackType1, "", Qty1, "", "MA");
                        counter = dtPickList.Rows.Count;


                        string RMCode2 = recordsSplit[27].ToString();
                        string PackType2 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[55])) / 100);
                        string Qty2 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode2, "", PackType2, "", Qty2, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode3 = recordsSplit[28].ToString();
                        string PackType3 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[56])) / 100);
                        string Qty3 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode3, "", PackType3, "", Qty3, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode4 = recordsSplit[29].ToString();
                        string PackType4 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[57])) / 100);
                        string Qty4 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode4, "", PackType4, "", Qty4, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode5 = recordsSplit[30].ToString();
                        string PackType5 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[58])) / 100);
                        string Qty5 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode5, "", PackType5, "", Qty5, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode6 = recordsSplit[31].ToString();
                        string PackType6 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[59])) / 100);
                        string Qty6 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode6, "", PackType6, "", Qty6, "", "MA");
                        counter = dtPickList.Rows.Count;


                        string RMCode7 = recordsSplit[32].ToString();
                        string PackType7 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[60])) / 100);
                        string Qty7 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode7, "", PackType7, "", Qty7, "", "MA");
                        counter = dtPickList.Rows.Count;

                        string RMCode8 = recordsSplit[33].ToString();
                        string PackType8 = "MANUAL ADDITIVE";
                        R_qty = ((batchSize * Convert.ToDouble(recordsSplit[61])) / 100);
                        string Qty8 = R_qty.ToString();
                        dtPickList.Rows.Add("", "", RMCode8, "", PackType8, "", Qty8, "", "MA");
                        counter = dtPickList.Rows.Count;

                    }



                    #endregion

                }

                for (int ij = 0; ij < dtPickList.Rows.Count; ij++)
                {
                    if (ij != dtPickList.Rows.Count - 1)
                    {


                        string rmCode = dtPickList.Rows[ij + 1]["RMCode"].ToString();
                        string PackType = dtPickList.Rows[ij + 1]["PackType"].ToString();
                        string Qty = dtPickList.Rows[ij + 1]["Qty"].ToString();
                        string RMType = dtPickList.Rows[ij + 1]["RMType"].ToString();

                        if (dtPickList.Rows[ij]["RMCode"].ToString() == "")
                        {
                            dtPickList.Rows[ij]["RMCode"] = rmCode;
                            dtPickList.Rows[ij]["PackType"] = PackType;
                            dtPickList.Rows[ij]["Qty"] = Qty;
                            dtPickList.Rows[ij]["RMType"] = RMType;

                            dtPickList.Rows[ij + 1]["RMCode"] = "";
                            dtPickList.Rows[ij + 1]["PackType"] = "";
                            dtPickList.Rows[ij + 1]["Qty"] = "";
                            dtPickList.Rows[ij + 1]["RMType"] = "";
                        }
                    }
                }

                DataRow dr = dtPickList.Rows[dtPickList.Rows.Count - 1];

                dtPickList.Rows.Remove(dr);

                for (int j = 0; j < dtPickList.Rows.Count; j++)
                {
                    string rmCode = dtPickList.Rows[j]["RMCode"].ToString();

                    string rmDescription = dtPickList.Rows[j]["RMDescription"].ToString();

                    string rmType = dtPickList.Rows[j]["RMType"].ToString();

                    if (rmCode != "")
                    {
                        if (rmDescription == "")
                        {
                            DataTable dtRmData = DAL.getRMDataPickList(rmCode, rmType);

                            if (dtRmData.Rows.Count > 0)
                            {
                                string rmDesc = dtRmData.Rows[0]["PROD_DESC"].ToString();
                                string rmPrecaution = dtRmData.Rows[0]["PROD_PRECAU"].ToString();

                                dtPickList.Rows[j]["RMDescription"] = rmDesc;
                                dtPickList.Rows[j]["Precautions"] = rmPrecaution;

                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        finally
        {

        }

        return dtPickList;
    }

    public string GetDataTabletFromCSVFile(string csv_file_path)
    {
        string csvString = "";
        try
        {
            using (Microsoft.VisualBasic.FileIO.TextFieldParser csvReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(csv_file_path))
            {
                csvReader.SetDelimiters(new string[] { "," });
                csvReader.HasFieldsEnclosedInQuotes = true;
                //read column names
                string[] colFields = csvReader.ReadFields();



                for (int i = 0; i < colFields.Length; i++)
                {
                    if (csvString == "")
                    {
                        csvString = colFields[i].ToString();
                    }
                    else
                    {
                        csvString = csvString + "," + colFields[i].ToString();
                    }
                }

            }
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return csvString;
    }

    public DataTable GetPickListData()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.GetPickListData();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    #endregion

    #region FamilyWiseProductList

    public DataTable GetFamilyProductListData()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.GetProductListData();

            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add("Fam");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string Family = "";
                    string PreFamily = "";

                    Family = dt.Rows[i]["FAMILY"].ToString();
                    if (i == 0)
                    {
                        PreFamily = dt.Rows[i]["FAMILY"].ToString();
                        dt.Rows[i]["Fam"] = Family;
                    }
                    else
                    {
                        PreFamily = dt.Rows[i - 1]["FAMILY"].ToString();
                    }
                    if (i >= 1)
                    {
                        if (Family == PreFamily)
                        {
                            Family = " ";
                            dt.Rows[i]["Fam"] = Family;
                        }
                        else
                        {
                            Family = dt.Rows[i]["FAMILY"].ToString();
                            dt.Rows[i]["Fam"] = Family;
                        }
                    }

                }
            }
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    #endregion

    #region BatchReport

    public DataTable getBlenderData()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getBlenderData();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    public DataTable getProductList(string blender_Name)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getProductList(blender_Name);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    public DataTable getBatchList(string blender_Name, string prdName)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getBatchList(blender_Name, prdName);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    public DataTable getReportData(string blender_Name, string prdName, string btchName)
    {
        DataTable dt = new DataTable();
        DataTable dtFinalReport = new DataTable();
        try
        {
            dt = DAL.getReportData(blender_Name, prdName, btchName);

            if (dt.Rows.Count > 0)
            {

                #region  Commented

                //string BlendTime = Convert.ToString(dt.Rows[dt.Rows.Count - 1]["BlendTime"]);
                //string StopTime = Convert.ToString(dt.Rows[dt.Rows.Count - 1]["SuspendTime"]);


                //string[] ArrBlendTime = BlendTime.Split(':');
                //string[] ArrStopTime = StopTime.Split(':');

                //double BlendTimeHH = Convert.ToDouble(ArrBlendTime[0]);
                //double BlendTimeMM = Convert.ToDouble(ArrBlendTime[1]);
                //double BlendTimeSS = Convert.ToDouble(ArrBlendTime[2]);

                //double StopTimeHH = Convert.ToDouble(ArrStopTime[0]);
                //double StopTimeMM = Convert.ToDouble(ArrStopTime[1]);
                //double StopTimeSS = Convert.ToDouble(ArrStopTime[2]);
                ////int hours = BlendTime.h

                //int hours = Convert.ToInt32(BlendTimeHH + StopTimeHH);
                //int minutes = Convert.ToInt32(BlendTimeMM + StopTimeMM);

                //if (minutes > 60)
                //{
                //    hours = hours + 1;
                //    minutes = minutes - 60;
                //}
                //else if (minutes == 60)
                //{
                //    hours = hours + 1;
                //    minutes = 0;
                //}

                ////
                //string sHours = "";
                //string sMinutes = "";

                //if (hours < 10)
                //{

                //    if (hours == 0)
                //    {
                //        sHours = "00";
                //    }

                //    sHours = hours.ToString().PadLeft(2, '0');
                //}
                //else
                //{
                //    sHours = hours.ToString();
                //}
                //if (minutes < 10)
                //{
                //    if (minutes == 0)
                //    {
                //        sMinutes = "00";
                //    }

                //    sMinutes = minutes.ToString().PadLeft(2, '0');
                //}
                //else
                //{
                //    sMinutes = minutes.ToString();
                //}
                //string BatchTime = sHours + ":" + sMinutes + ":" + "00";



                //OLD
                //DataColumn dcBatchTime = new DataColumn("BatchTimeFinal");
                //dcBatchTime.DefaultValue = BatchTime;
                //dt.Columns.Add(dcBatchTime);

                #endregion

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ingredent = Convert.ToString(dt.Rows[i]["INGRDNT"]);

                    if (ingredent == "NIL")
                    {
                        dt.Rows[i]["INGRDNT"] = "";
                        dt.Rows[i]["RM_DESC"] = "";
                        dt.Rows[i]["PRECAUTION"] = "";
                    }

                    //Comments Added On 07-07-2017 by CM

                    else if (ingredent != "NIL")
                    {
                        string command = Convert.ToString(dt.Rows[i]["CMND"]);
                        DataTable dtRmData = new DataTable();

                        //Changed by Nikhil as per Command List Provided by customer

                        #region Command Filter

                        //if (command == "22")
                        //{
                        //    dtRmData = DAL.getRMDataPickList(ingredent, "BA");
                        //}
                        //else if (command == "13" || command == "18" || command == "21" || command == "23" || command == "29" || command == "31" || command == "32" || command == "33" || command == "34" || command == "36" || command == "38" || command == "40" || command == "48" || command == "49" || command == "50" || command == "52" || command == "53")
                        //{
                        //    dtRmData = DAL.getRMDataPickList(ingredent, "BO");
                        //}
                        //else if (command == "12" || command == "30" || command == "47")
                        //{
                        //    dtRmData = DAL.getRMDataPickList(ingredent, "DA");
                        //}
                        //if (command == "35" || command == "6")
                        //{
                        //    dtRmData = DAL.getRMDataPickList(ingredent, "MA");
                        //}

                        dtRmData = DAL.getRMDataPickList(ingredent, "BO");

                        if (dtRmData.Rows.Count > 0)
                        {
                            string rmDesc = dtRmData.Rows[0]["PROD_DESC"].ToString();
                            string rmPrecaution = dtRmData.Rows[0]["PROD_PRECAU"].ToString();
                            dt.Rows[i]["RM_DESC"] = rmDesc;
                            dt.Rows[i]["PRECAUTION"] = rmPrecaution;
                        }

                        #endregion

                    }


                }

                dtFinalReport = RemoveDuplicateRows(dt, "SN");

                string familyVal = Convert.ToString(dtFinalReport.Rows[0]["Family"]);

                #region Family Filter Commented

                //if ((familyVal == "F-6H") || (familyVal == "F-6M") || (familyVal == "F-6O"))
                //{
                //    for (int i = 0; i < dtFinalReport.Rows.Count; i++)
                //    {
                //        string CMND = Convert.ToString(dtFinalReport.Rows[i]["CMND"]);

                //        if (CMND == "15")
                //        {

                //            int SP1 = Convert.ToInt32(dtFinalReport.Rows[i]["SP1"]);
                //            string unit = "";
                //            if (SP1 <= 20)
                //            {
                //                unit = "Mins";
                //            }
                //            else if (SP1 > 20)
                //            {
                //                unit = "Deg C";
                //            }

                //            dtFinalReport.Rows[i]["CMNDUnitSP1"] = unit;
                //            dtFinalReport.Rows[i]["CMNDUnitSP2"] = unit;

                //        }

                //    }
                //}

                #endregion

                #region Phase Duration and Step stop time calc Commented bcz not logged

                string ActiveDurS = Convert.ToString(dtFinalReport.Compute("SUM(PhaseDuration)", string.Empty));

                double ActiveDur = 0.0;

                if (ActiveDurS != "")
                {
                    ActiveDur = Convert.ToDouble(ActiveDurS);
                }
                else
                {
                    ActiveDur = 0.0;
                }

                string StopDurS = Convert.ToString(dtFinalReport.Compute("SUM(STEP_STOP_TIME)", string.Empty));

                double StopDur = 0.0;
                if (StopDurS != "")
                {
                    StopDur = Convert.ToDouble(StopDurS);
                }
                else
                {
                    StopDur = 0.0;
                }

                double BatchTime = ActiveDur + StopDur;
                TimeSpan tBatchDuration = TimeSpan.FromMinutes(Math.Round(BatchTime, 0));

                DataColumn dcBatchTime = new DataColumn("BatchTimeFinal", typeof(string));
                dcBatchTime.DefaultValue = tBatchDuration.ToString();
                dtFinalReport.Columns.Add(dcBatchTime);

                //dtFinalReport.Columns.Add("BatchTimeFinal");
                //dtFinalReport.Columns["BatchTimeFinal"].DefaultValue = BtchDuration;


                //dcBatchTime.DefaultValue = BtchDuration;

                //Total Blend Time
                DataColumn dcActTime = new DataColumn("tActTime");
                TimeSpan ActiveDuration = TimeSpan.FromMinutes(Math.Round(ActiveDur, 0));
                dcActTime.DefaultValue = ActiveDuration.ToString();
                dtFinalReport.Columns.Add(dcActTime);

                //Total Stop Time
                DataColumn dcStTime = new DataColumn("tStTime");
                TimeSpan TStopDuration = TimeSpan.FromMinutes(Math.Round(StopDur, 0));
                dcStTime.DefaultValue = TStopDuration.ToString();
                dtFinalReport.Columns.Add(dcStTime);

                #endregion

                double prodQtyFinal = 0.0;
                dtFinalReport.Columns.Add("ProducedQty");
                dtFinalReport.Columns.Add("BlenderNo");

                #region Filter for produced quantity

                for (int i = 0; i < dtFinalReport.Rows.Count; i++)
                {
                    string unit = dtFinalReport.Rows[i]["CMNDUnitSP1"].ToString();
                    
                    double prodQty = Convert.ToDouble(dtFinalReport.Rows[i]["PV1"]) + Convert.ToDouble(dtFinalReport.Rows[i]["PV2"]);

                    prodQtyFinal = prodQtyFinal + prodQty;
                    
                    dtFinalReport.Rows[i]["ProducedQty"] = prodQtyFinal;
                    dtFinalReport.Rows[i]["BlenderNo"] = blender_Name;

                    //string Cmnd = dtFinalReport.Rows[i]["CMND"].ToString();
                    
                    //dtFinalReport.Rows[i]["PV1"] = 0;
                    
                }

                #endregion
            }

        }
        catch (Exception ex)
        {

        }
        return dtFinalReport;
    }

    #endregion

    #region Batch Accuracy

    public DataTable GetBatchAccuracyData(string blender_Name, string ProductName, string batchNo)
    {
        DataTable dt = new DataTable();
        DataTable dtFinalReport = new DataTable();
        try
        {
            dt = DAL.GetBatchAccuracyData(blender_Name, ProductName, batchNo);

            if (dt.Rows.Count > 0)
            {
                string BlendTime = Convert.ToString(dt.Rows[dt.Rows.Count - 1]["BlendTime"]);
                string StopTime = Convert.ToString(dt.Rows[dt.Rows.Count - 1]["SuspendTime"]);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ingredent = Convert.ToString(dt.Rows[i]["INGRDNT"]);

                    if (ingredent == "NIL")
                    {
                        dt.Rows[i]["INGRDNT"] = "";
                        dt.Rows[i]["RM_DESC"] = "";
                        dt.Rows[i]["PRECAUTION"] = "";
                    }

                    //Comments Added By Chhotumal 07-07-2017

                    else if ((ingredent != "NIL") && !(ingredent.Contains("PREMIX")))
                    {
                        string command = Convert.ToString(dt.Rows[i]["CMND"]);
                        DataTable dtRmData = new DataTable();

                        //Changed by Nikhil as per Command List Provided by Sourav

                        if (command == "22")
                        {
                            dtRmData = DAL.getRMDataPickList(ingredent, "BA");
                        }
                        else if (command == "13" || command == "18" || command == "21" || command == "23" || command == "29" || command == "31" || command == "32" || command == "33" || command == "34" || command == "36" || command == "38" || command == "40" || command == "48" || command == "49" || command == "50" || command == "52" || command == "53")
                        {
                            dtRmData = DAL.getRMDataPickList(ingredent, "BO");
                        }
                        else if (command == "12" || command == "30" || command == "47")
                        {
                            dtRmData = DAL.getRMDataPickList(ingredent, "DA");
                        }
                        if (command == "35" || command == "6")
                        {
                            dtRmData = DAL.getRMDataPickList(ingredent, "MA");
                        }

                        if (dtRmData.Rows.Count > 0)
                        {
                            string rmDesc = dtRmData.Rows[0]["PROD_DESC"].ToString();
                            string rmPrecaution = dtRmData.Rows[0]["PROD_PRECAU"].ToString();
                            dt.Rows[i]["RM_DESC"] = rmDesc;
                            dt.Rows[i]["PRECAUTION"] = rmPrecaution;
                        }

                    }

                }

                dtFinalReport = RemoveDuplicateRows(dt, "SN");

                string familyVal = Convert.ToString(dtFinalReport.Rows[0]["Family"]);

                if ((familyVal == "F-6H") || (familyVal == "F-6M") || (familyVal == "F-6O"))
                {
                    for (int i = 0; i < dtFinalReport.Rows.Count; i++)
                    {
                        string CMND = Convert.ToString(dtFinalReport.Rows[i]["CMND"]);

                        if (CMND == "15")
                        {

                            int SP1 = Convert.ToInt32(dtFinalReport.Rows[i]["SP1"]);
                            string unit = "";
                            if (SP1 <= 20)
                            {
                                unit = "Mins";
                            }
                            else if (SP1 > 20)
                            {
                                unit = "Deg C";
                            }

                            dtFinalReport.Rows[i]["CMNDUnitSP1"] = unit;
                            dtFinalReport.Rows[i]["CMNDUnitSP2"] = unit;

                        }

                    }
                }

                #region Commented

                //string[] ArrBlendTime = BlendTime.Split(':');
                //string[] ArrStopTime = StopTime.Split(':');

                //double BlendTimeHH = Convert.ToDouble(ArrBlendTime[0]);
                //double BlendTimeMM = Convert.ToDouble(ArrBlendTime[1]);
                //double BlendTimeSS = Convert.ToDouble(ArrBlendTime[2]);

                //double StopTimeHH = Convert.ToDouble(ArrStopTime[0]);
                //double StopTimeMM = Convert.ToDouble(ArrStopTime[1]);
                //double StopTimeSS = Convert.ToDouble(ArrStopTime[2]);
                ////int hours = BlendTime.h

                //int hours = Convert.ToInt32(BlendTimeHH + StopTimeHH);
                //int minutes = Convert.ToInt32(BlendTimeMM + StopTimeMM);

                //if (minutes > 60)
                //{
                //    hours = hours + 1;
                //    minutes = minutes - 60;
                //}
                //else if (minutes == 60)
                //{
                //    hours = hours + 1;
                //    minutes = 0;
                //}

                ////
                //string sHours = "";
                //string sMinutes = "";

                //if (hours < 10)
                //{

                //    if (hours == 0)
                //    {
                //        sHours = "00";
                //    }

                //    sHours = hours.ToString().PadLeft(2, '0');
                //}
                //else
                //{
                //    sHours = hours.ToString();
                //}
                //if (minutes < 10)
                //{
                //    if (minutes == 0)
                //    {
                //        sMinutes = "00";
                //    }

                //    sMinutes = minutes.ToString().PadLeft(2, '0');
                //}
                //else
                //{
                //    sMinutes = minutes.ToString();
                //}

                //string BatchTime = sHours + ":" + sMinutes + ":" + "00";

                #endregion

                string ActiveDurS = Convert.ToString(dtFinalReport.Compute("SUM(PhaseDuration)", string.Empty));

                double ActiveDur = 0.0;

                if (ActiveDurS != "")
                {
                    ActiveDur = Convert.ToDouble(ActiveDurS);
                }
                else
                {
                    ActiveDur = 0.0;
                }

                string StopDurS = Convert.ToString(dtFinalReport.Compute("SUM(STEP_STOP_TIME)", string.Empty));

                double StopDur = 0.0;
                if (StopDurS != "")
                {
                    StopDur = Convert.ToDouble(StopDurS);
                }
                else
                {
                    StopDur = 0.0;
                }

                double BatchTime = ActiveDur + StopDur;
                TimeSpan tBatchDuration = TimeSpan.FromMinutes(Math.Round(BatchTime, 0));


                DataColumn dcBatchTime = new DataColumn("BatchTimeFinal");
                dcBatchTime.DefaultValue = tBatchDuration.ToString();
                dt.Columns.Add(dcBatchTime);

                DataColumn dcActTime = new DataColumn("tActTime");
                TimeSpan ActiveDuration = TimeSpan.FromMinutes(Math.Round(ActiveDur, 0));
                dcActTime.DefaultValue = ActiveDuration.ToString();
                dtFinalReport.Columns.Add(dcActTime);

                //Total Stop Time
                DataColumn dcStTime = new DataColumn("tStTime");
                TimeSpan TStopDuration = TimeSpan.FromMinutes(Math.Round(StopDur, 0));
                dcStTime.DefaultValue = TStopDuration.ToString();
                dtFinalReport.Columns.Add(dcStTime);



                double prodQtyFinal = 0.0;
                dtFinalReport.Columns.Add("ProducedQty");
                dtFinalReport.Columns.Add("BlenderNo");

                for (int i = 0; i < dtFinalReport.Rows.Count; i++)
                {
                    string unit = dtFinalReport.Rows[i]["CMNDUnitSP1"].ToString();
                    if (unit == "Kgs")
                    {
                        double prodQty = Convert.ToDouble(dtFinalReport.Rows[i]["PV1"]) + Convert.ToDouble(dtFinalReport.Rows[i]["PV2"]);

                        prodQtyFinal = prodQtyFinal + prodQty;
                    }
                    dtFinalReport.Rows[i]["ProducedQty"] = prodQtyFinal;
                    dtFinalReport.Rows[i]["BlenderNo"] = blender_Name;
                }

            }




        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dtFinalReport;
    }

    #endregion

    #region Cumulative Report

    #region Cumulative Family Wise

    public DataTable getFamilyName()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getFamilyName();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    public DataTable getCumulativeReportData(string FamilyName, string BatchNo)
    {
        DataTable dt = new DataTable();

        DataTable dtBatchData = new DataTable();

        DataTable dtFinalBatchReport = new DataTable();

        string BatchStartDTTM = "";
        string BatchEndDTTM = "";
        string BlendTime = "";
        string StopTime = "";
        string BatchDuration = "";
        try
        {
            dt = DAL.getCumulativeReportData(FamilyName, BatchNo);

            dtBatchData = DAL.getCumulativeBatchData(FamilyName, BatchNo);

            if (dtBatchData.Rows.Count > 0)
            {
                BatchStartDTTM = Convert.ToString(dtBatchData.Rows[0]["BatchStartDTTM"]);
                BatchEndDTTM = Convert.ToString(dtBatchData.Rows[0]["BatchEndDTTM"]);

                BlendTime = Convert.ToString(dtBatchData.Rows[0]["BlendTime"]);
                StopTime = Convert.ToString(dtBatchData.Rows[0]["StopTime"]);

                string ActiveDurS = Convert.ToString(dtBatchData.Rows[0]["StepDuration"]);

                double ActiveDur = 0.0;

                if (ActiveDurS != "")
                {
                    ActiveDur = Convert.ToDouble(ActiveDurS);
                }
                else
                {
                    ActiveDur = 0.0;
                }

                string StopDurS = Convert.ToString(dtBatchData.Rows[0]["StopDuration"]);

                double StopDur = 0.0;
                if (StopDurS != "")
                {
                    StopDur = Convert.ToDouble(StopDurS);
                }
                else
                {
                    StopDur = 0.0;
                }

                //double ActiveDur = Convert.ToDouble(dtBatchData.Compute("SUM(StepDuration)", string.Empty));
                //double StopDur = Convert.ToDouble(dtBatchData.Compute("SUM(StopDuration)", string.Empty));
                double BatchTime = ActiveDur + StopDur;
                TimeSpan tBatchDuration = TimeSpan.FromMinutes(Math.Round(BatchTime, 0));
                BatchDuration = tBatchDuration.ToString();
                //DataColumn dcBatchTime = new DataColumn("BatchTimeFinal", typeof(string));
                //dcBatchTime.DefaultValue = tBatchDuration.ToString();
                //dtBatchData.Columns.Add(dcBatchTime);
            }

            if (dt.Rows.Count > 0)
            {
                string destination = "";

                destination = DAL.getDestinationData(FamilyName, BatchNo);

                DataColumn dcBatchStartDTTM = new DataColumn("BatchStartDTTM");
                DataColumn dcBatchEndDTTM = new DataColumn("BatchEndDTTM");
                DataColumn dcBlendTime = new DataColumn("BlendTime");
                DataColumn dcStopTime = new DataColumn("StopTime");

                dcBatchStartDTTM.DefaultValue = BatchStartDTTM;
                dcBatchEndDTTM.DefaultValue = BatchEndDTTM;
                dcBlendTime.DefaultValue = BlendTime;
                dcStopTime.DefaultValue = StopTime;

                dt.Columns.Add(dcBatchStartDTTM);
                dt.Columns.Add(dcBatchEndDTTM);
                dt.Columns.Add(dcBlendTime);
                dt.Columns.Add(dcStopTime);

                BlendTime = Convert.ToString(dt.Rows[dt.Rows.Count - 1]["BlendTime"]);
                StopTime = Convert.ToString(dt.Rows[dt.Rows.Count - 1]["StopTime"]);

                string[] ArrBlendTime = BlendTime.Split(':');
                string[] ArrStopTime = StopTime.Split(':');

                double BlendTimeHH = Convert.ToDouble(ArrBlendTime[0]);
                double BlendTimeMM = Convert.ToDouble(ArrBlendTime[1]);
                double BlendTimeSS = Convert.ToDouble(ArrBlendTime[2]);

                double StopTimeHH = Convert.ToDouble(ArrStopTime[0]);
                double StopTimeMM = Convert.ToDouble(ArrStopTime[1]);
                double StopTimeSS = Convert.ToDouble(ArrStopTime[2]);
                //int hours = BlendTime.h

                int hours = Convert.ToInt32(BlendTimeHH + StopTimeHH);
                int minutes = Convert.ToInt32(BlendTimeMM + StopTimeMM);

                if (minutes > 60)
                {
                    hours = hours + 1;
                    minutes = minutes - 60;
                }
                else if (minutes == 60)
                {
                    hours = hours + 1;
                    minutes = 0;
                }

                //
                string sHours = "";
                string sMinutes = "";

                if (hours < 10)
                {

                    if (hours == 0)
                    {
                        sHours = "00";
                    }

                    sHours = hours.ToString().PadLeft(2, '0');
                }
                else
                {
                    sHours = hours.ToString();
                }
                if (minutes < 10)
                {
                    if (minutes == 0)
                    {
                        sMinutes = "00";
                    }

                    sMinutes = minutes.ToString().PadLeft(2, '0');
                }
                else
                {
                    sMinutes = minutes.ToString();
                }
                string BatchTime = sHours + ":" + sMinutes + ":" + "00";

                // OLD

                //DataColumn dcBatchTime = new DataColumn("BatchTime");

                //dcBatchTime.DefaultValue = BatchDuration;
                //dt.Columns.Add(dcBatchTime);


                // Batch Time New Calculation


                DateTime dtStartTime = DateTime.ParseExact(BatchStartDTTM, "yyyy-MM-dd HH:mm:ss", new DateTimeFormatInfo());
                DateTime dtStopTime = DateTime.ParseExact(BatchEndDTTM, "yyyy-MM-dd HH:mm:ss", new DateTimeFormatInfo());

                TimeSpan tDiff1 = dtStopTime.Subtract(dtStartTime);
                
                //double diff1 = (tDiff1.Hours * 60) + (tDiff1.Minutes);

                DataColumn dcBatchTime = new DataColumn("BatchTime");

                dcBatchTime.DefaultValue = tDiff1.ToString();
                dt.Columns.Add(dcBatchTime);


                DataColumn dcDestination = new DataColumn("Destination");
                dcDestination.DefaultValue = destination;

                dt.Columns.Add(dcDestination);

                DataColumn dcRM_DESC = new DataColumn("RM_DESC");
                DataColumn dcPRECAUTION = new DataColumn("PRECAUTION");
                DataColumn dcTankDescription = new DataColumn("TankDescription");

                dt.Columns.Add(dcRM_DESC);
                dt.Columns.Add(dcPRECAUTION);
                dt.Columns.Add(dcTankDescription);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string rmCode = dt.Rows[i]["INGRDNT"].ToString();
                    DataTable dtRmData = new DataTable();
                    dtRmData = DAL.getRMData(rmCode);
                    string TankDescription = "";
                    TankDescription = DAL.getTankDescription(BatchNo, rmCode);
                    dt.Rows[i]["TankDescription"] = TankDescription;
                    if (dtRmData.Rows.Count > 0)
                    {
                        string rmDesc = dtRmData.Rows[0]["PROD_DESC"].ToString();
                        string rmPrecaution = dtRmData.Rows[0]["PROD_PRECAU"].ToString();

                        dt.Rows[i]["RM_DESC"] = rmDesc;
                        dt.Rows[i]["PRECAUTION"] = rmPrecaution;

                    }
                }

                double BTCH_SIZE_SP = DAL.getBatchSizeData(BatchNo);
                string BlenderName = DAL.getBlenderData(BatchNo);

                string[] BlenderNameArr = BlenderName.Split(',');

                DataColumn dcBTCH_SIZE_SP = new DataColumn("BTCH_SIZE_SP");
                DataColumn dcBlenderName = new DataColumn("BlenderName");
                DataColumn dcBlenderCount = new DataColumn("BlenderCount");

                dcBTCH_SIZE_SP.DefaultValue = BTCH_SIZE_SP;
                dcBlenderName.DefaultValue = BlenderNameArr[0].ToString();
                dcBlenderCount.DefaultValue = BlenderNameArr[1].ToString();

                dt.Columns.Add(dcBTCH_SIZE_SP);
                dt.Columns.Add(dcBlenderName);
                dt.Columns.Add(dcBlenderCount);
            }

            //dtFinalBatchReport = RemoveDuplicateRows(dt, "INGRDNT");

            dtFinalBatchReport = dt;
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dtFinalBatchReport;
    }

    #endregion

    #region Cumulative Blender Wise

    public DataTable getCumulativeBlenderReportData(string blenderNo, string BatchNo)
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        try
        {
            DataTable dtFinal = new DataTable();

            dt = DAL.getFamilyNames(blenderNo, BatchNo);

            if (dt.Rows.Count > 0)
            {
                string familyName = dt.Rows[0]["FAMILY"].ToString();

                dt1 = getCumulativeReportData(familyName, BatchNo);
            }


        }
        catch (Exception ex)
        {

        }
        return dt1;
    }

    public DataTable getBatchNumbers(string blenderNo)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getBatchNumbers(blenderNo);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    #endregion

    #endregion

    #region Blenderwise BCT Report Data

    public DataTable getBCTData(string blender_Name, string Date, string EDate)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getBCTData(blender_Name, Date, EDate);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    #endregion

    #region ProductWise BCT Report Data

    public DataTable getProductWiseBCT(string Product, string FDate, string EDate, string blender)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getProductWiseBCT(Product, FDate, EDate, blender);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string blenderName = Convert.ToString(dt.Rows[i]["BlenderNo"]);

                    if ((blenderName != "V101") && (blenderName != "V301") && (blenderName != "V302") && (blenderName != "V401") && (blenderName != "V501") && (blenderName != "V502") && (blenderName != "V601") && (blenderName != "V602") && (blenderName != "V701") && (blenderName != "V702") && (blenderName != "V801") && (blenderName != "V901") && (blenderName != "V902") && (blenderName != "V2401"))
                    {
                        DataRow dr = dt.Rows[i];
                        dt.Rows.Remove(dr);
                    }
                }

                dt.AcceptChanges();
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable GetProductListData()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.GetProductList();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    #endregion

    #region RM Consumption Report

    public DataTable getRMConsData(string fdtm, string tdtm)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getRMConsData(fdtm, tdtm);

            #region Commented

            //if (dt.Rows.Count > 0)
            //{

            //    dt.Columns.Add("RMCode");

            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        string RMCode = "";
            //        string PreRMCode = "";

            //        RMCode = dt.Rows[i]["INGRDNT"].ToString();
            //        if (i == 0)
            //        {
            //            PreRMCode = dt.Rows[i]["INGRDNT"].ToString();
            //            dt.Rows[i]["RMCode"] = RMCode;
            //        }
            //        else
            //        {
            //            PreRMCode = dt.Rows[i - 1]["INGRDNT"].ToString();
            //        }
            //        if (i >= 1)
            //        {
            //            if (RMCode == PreRMCode)
            //            {
            //                RMCode = " ";
            //                dt.Rows[i]["RMCode"] = RMCode;
            //            }
            //            else
            //            {
            //                RMCode = dt.Rows[i]["INGRDNT"].ToString();
            //                dt.Rows[i]["RMCode"] = RMCode;
            //            }
            //        }
            //    }
            //}

            #endregion

        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    #endregion

    #region Cumulative Consumption Data

    public DataTable getCumulativeConsData(string fdtm, string tdtm)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getCumulativeConsData(fdtm, tdtm);

            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add("RM_DESC");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string RMCode = "";

                    RMCode = dt.Rows[i]["RMCode"].ToString();

                    DataTable dtRmData = new DataTable();
                    dtRmData = DAL.getRMData(RMCode);

                    if (dtRmData.Rows.Count > 0)
                    {
                        string rmDesc = dtRmData.Rows[0]["PROD_DESC"].ToString();

                        dt.Rows[i]["RM_DESC"] = rmDesc;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    #endregion

    #region Configuration

    #region Blender Configuration

    public DataTable getViewData()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getViewData();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    public DataTable AddBlenderData(string BlenderName, string ViewName)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.AddBlenderData(BlenderName, ViewName);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    public DataTable UpdateGVData(System.Web.UI.WebControls.Label ID, System.Web.UI.WebControls.TextBox name, System.Web.UI.WebControls.DropDownList view)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.UpdateGVData(ID, name, view);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    #endregion

    #region Command Configuration

    public DataTable getCommandData()
    {
        DataTable dtAll = new DataTable();
        try
        {
            dtAll = DAL.getCommandData();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dtAll;
    }

    public DataTable AddCommandData(string CmdNo, string CmdDesc, string sp1Unit, string sp2Unit)
    {
        DataTable dtAll = new DataTable();
        try
        {
            dtAll = DAL.AddCommandData(CmdNo, CmdDesc, sp1Unit, sp2Unit);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dtAll;
    }

    public DataTable GetEditCommandData(string CommandNo)
    {
        DataTable dtAll = new DataTable();
        try
        {
            dtAll = DAL.GetEditCommandData(CommandNo);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dtAll;
    }

    public DataTable UpdateCommandData(string CommandNo, string CommandDesc, string Sp1, string sp2)
    {
        DataTable dtAll = new DataTable();
        try
        {
            dtAll = DAL.UpdateCommandData(CommandNo, CommandDesc, Sp1, sp2);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dtAll;
    }

    #endregion

    #region Source Tank Configuration

    public DataTable AddTankSourceData(string TankNo, string TankDesc)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.AddTankSourceData(TankNo, TankDesc);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    public DataTable getSourceTankData()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getSourceTankData();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    public DataTable EditTankSourceData(string TankNo, string TankDesc)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.EditTankSourceData(TankNo, TankDesc);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    public DataTable GetEditTankData(string TankNo)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.GetEditTankData(TankNo);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    #endregion

    #region Family Configuration

    public DataTable getFamilyData()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getFamilyData();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    public DataTable AddFamilyData(string familyName, string ViewName)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.AddFamilyData(familyName, ViewName);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    public DataTable UpdateFamilyData(System.Web.UI.WebControls.Label ID, System.Web.UI.WebControls.TextBox name, System.Web.UI.WebControls.DropDownList view)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.UpdateFamilyData(ID, name, view);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    public DataTable getFamilyData(string FamilyName)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getFamilyData(FamilyName);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    #endregion

    #region BCT Configuration

    public DataTable getFamily()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getFamily();
        }
        catch (Exception ex)
        {

        }

        return dt;
    }

    public DataTable getProductDetails(string familyName)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getProductDetails(familyName);
        }
        catch (Exception ex)
        {

        }

        return dt;
    }

    public DataTable getProductCodes()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getProductCodes();
        }
        catch (Exception ex)
        {

        }

        return dt;

    }

    public DataTable getProductCodeDetails(string productCode, string familyName)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getProductCodeDetails(productCode, familyName);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    public DataTable getProductCodeBCT(string productCode, string familyName)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getProductCodeBCT(productCode, familyName);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    public int insertBCTData(string productCode, string fixedBCT, string variableBCT, string family)
    {

        int result = 0;

        try
        {
            result = DAL.insertBCTData(productCode, fixedBCT, variableBCT, family);
        }
        catch (Exception ex)
        {
            result = 0;
            this.LogError(ex);
        }

        return result;

    }

    public int updateBCTData(string productCode, string fixedBCT, string variableBCT, string family)
    {
        int result = 0;

        try
        {
            result = DAL.updateBCTData(productCode, fixedBCT, variableBCT, family);
        }
        catch (Exception ex)
        {
            result = 0;
            this.LogError(ex);
        }

        return result;

    }

    #endregion

    #endregion

    #region PreBatch Report

    public DataTable getProductData(string BatchNo)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getProductData(BatchNo);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    public DataTable getBatchNo(string equipmentNo)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getBatchNo(equipmentNo);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    public DataTable getPreBatchData(string BatchNo, string ProductCode, string vesselNo)
    {
        DataTable dt = new DataTable();
        DataTable dtFinal = new DataTable();
        try
        {
            dt = DAL.getPreBatchData(BatchNo, ProductCode, vesselNo);

            dtFinal = RemoveDuplicateRows(dt, "SN");
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dtFinal;
    }

    #endregion

    #region Not Used

    public DataTable getConfigData()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getConfigData();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    public DataTable getBatchData(string FamilyName)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getBatchData(FamilyName);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    #endregion

    //public DataTable getCumulativeReportData(string FamilyName, string BatchNo)
    //{
    //    DataTable dt = new DataTable();

    //    DataTable dtFinal = new DataTable();

    //    DataColumn dcBatchNo = new DataColumn("BatchNo");
    //    DataColumn dcProductName = new DataColumn("ProductName");
    //    DataColumn dcProductCode = new DataColumn("ProductCode");
    //    DataColumn dcInitialSP = new DataColumn("InitialSP");
    //    DataColumn dcBatchTime = new DataColumn("BatchTime");
    //    DataColumn dcFamily = new DataColumn("Family");
    //    DataColumn dcDestination = new DataColumn("Destination");
    //    DataColumn dcBlenderNo = new DataColumn("BlenderNo");
    //    DataColumn dcStartDate = new DataColumn("StartDate");
    //    DataColumn dcEndDate = new DataColumn("EndDate");
    //    DataColumn dcRMCode = new DataColumn("RMCode");
    //    DataColumn dcRMDescription = new DataColumn("RMDescription");
    //    DataColumn dcSP1 = new DataColumn("SP1", typeof(double));
    //    DataColumn dcPV1 = new DataColumn("PV1", typeof(double));
    //    DataColumn dcTankSource = new DataColumn("TankSource");

    //    dtFinal.Columns.Add(dcBatchNo);
    //    dtFinal.Columns.Add(dcProductName);
    //    dtFinal.Columns.Add(dcProductCode);
    //    dtFinal.Columns.Add(dcInitialSP);
    //    dtFinal.Columns.Add(dcBatchTime);
    //    dtFinal.Columns.Add(dcFamily);
    //    dtFinal.Columns.Add(dcDestination);
    //    dtFinal.Columns.Add(dcBlenderNo);
    //    dtFinal.Columns.Add(dcStartDate);
    //    dtFinal.Columns.Add(dcEndDate);
    //    dtFinal.Columns.Add(dcRMCode);
    //    dtFinal.Columns.Add(dcRMDescription);
    //    dtFinal.Columns.Add(dcSP1);
    //    dtFinal.Columns.Add(dcPV1);
    //    dtFinal.Columns.Add(dcTankSource);



    //    DataTable dtFinalBatchReport = new DataTable();
    //    try
    //    {

    //        dt = DAL.getCumulativeReportData(FamilyName, BatchNo);

    //        dtFinalBatchReport = RemoveDuplicateRows(dt, "INGRDNT");


    //        for (int i = 0; i < dtFinalBatchReport.Rows.Count; i++)
    //        {
    //            string BTCH_NO = dtFinalBatchReport.Rows[i]["BTCH_NO"].ToString();
    //            string RMCode = dtFinalBatchReport.Rows[i]["INGRDNT"].ToString();
    //            string prductName = dtFinalBatchReport.Rows[i]["PRODUCT_DESC"].ToString();
    //            string prductCode = dtFinalBatchReport.Rows[i]["PRODUCT_NAME"].ToString();
    //            string InitialSP = dtFinalBatchReport.Rows[i]["BTCH_SIZE_SP"].ToString();
    //            string BatchTime = dtFinalBatchReport.Rows[i]["BatchTime"].ToString();
    //            string Family = dtFinalBatchReport.Rows[i]["FAMILY"].ToString();
    //            string Destination = dtFinalBatchReport.Rows[i]["DestinationTank"].ToString();
    //            string StartDate = dtFinalBatchReport.Rows[i]["BatchStartDTTM"].ToString();
    //            string EndDate = dtFinalBatchReport.Rows[i]["BatchEndDTTM"].ToString();

    //            string BlenderName = dtFinalBatchReport.Rows[i]["BlenderName"].ToString();
    //            string RMDesc = dtFinalBatchReport.Rows[i]["RM_DESC"].ToString();
    //            string tankSource = dtFinalBatchReport.Rows[i]["TankDescription"].ToString();

    //            double pv1 = 0.0;
    //            double sp1 = 0.0;

    //            for (int j = 0; j < dtFinalBatchReport.Rows.Count; j++)
    //            {
    //                string RMCode1 = dtFinalBatchReport.Rows[j]["INGRDNT"].ToString();

    //                if (RMCode == RMCode1)
    //                {

    //                    sp1 = sp1 + Convert.ToDouble(dtFinalBatchReport.Rows[j]["SP1"]);
    //                    pv1 = pv1 + Convert.ToDouble(dtFinalBatchReport.Rows[j]["PV1"]);
    //                }

    //            }

    //            dtFinal.Rows.Add(BatchNo, prductName, prductCode, InitialSP, BatchTime, Family, Destination, BlenderName, StartDate, EndDate, RMCode, RMDesc, sp1, pv1, tankSource);

    //        }

    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //    return dtFinal;
    //}

    #region Product Code report

    public DataTable getProductCode()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getProductCode();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    public DataTable getProductCodeData(string ProdCode, string StrtDate, string EndDate)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getProductCodeData(ProdCode, StrtDate, EndDate);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    #endregion

    #region PeriodicReport

    public DataTable GetPeriodicData(string StartDate, string EndDate)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.GetPeriodicData(StartDate, EndDate);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dt;
    }

    #endregion

    #region CumulativeFamilyWise

    public DataTable getCumulativeReport(string FamilyName, string BatchNo)
    {
        DataTable dtAll = new DataTable();
        try
        {
            dtAll = DAL.getCumulativeReport(FamilyName, BatchNo);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return dtAll;
    }

    #endregion

    public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
    {
        Hashtable hTable = new Hashtable();
        ArrayList duplicateList = new ArrayList();

        //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
        //And add duplicate item value in arraylist.
        foreach (DataRow drow in dTable.Rows)
        {
            if (hTable.Contains(drow[colName]))
                duplicateList.Add(drow);
            else
                hTable.Add(drow[colName], string.Empty);
        }

        //Removing a list of duplicate items from datatable.
        foreach (DataRow dRow in duplicateList)
            dTable.Rows.Remove(dRow);

        //Datatable which contains unique records will be return as output.
        return dTable;
    }

    int excl_count = 0;

    //private void CsvExcelpath(string path_Csv)
    //{

    //    Excel.Workbook excelWorkbook_Csv = WA_Csv.Workbooks.Open(workbookPath_Csv, 0, true, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
    //    Excel.Sheets excelSheets_Csv = excelWorkbook_Csv.Worksheets;

    //    if (excl_count == 0)
    //    {
    //        BusinessAccessLayer.WA_Csv = new Excel.Application();
    //        BusinessAccessLayer.workbookPath_Csv = path_Csv;

    //        excelWorkbook_Csv = WA_Csv.Workbooks.Open(workbookPath_Csv, 0, true, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
    //        excelSheets_Csv = excelWorkbook_Csv.Worksheets;
    //    }

    //}

    #region Daily Blending Report

    public DataTable getDailyBlendingData(string tDate)
    {
        DataTable dtBlendingData = new DataTable();

        DataColumn dcBlenderNo = new DataColumn("BlenderNo");
        DataColumn dcProductCode = new DataColumn("ProductCode");
        DataColumn dcProductDescription = new DataColumn("ProductDescription");
        DataColumn dcBatchNo = new DataColumn("BatchNo");
        DataColumn dcVolume = new DataColumn("BatchSizePVKL", typeof(double));
        DataColumn dcQCTime = new DataColumn("QCTime", typeof(double));
        DataColumn dcDischargeTime = new DataColumn("DischargeTime", typeof(double));
        DataColumn dcStopTime = new DataColumn("StoppageTimeMins", typeof(double));

        dtBlendingData.Columns.Add(dcBlenderNo);
        dtBlendingData.Columns.Add(dcProductCode);
        dtBlendingData.Columns.Add(dcProductDescription);
        dtBlendingData.Columns.Add(dcBatchNo);
        dtBlendingData.Columns.Add(dcVolume);
        dtBlendingData.Columns.Add(dcQCTime);
        dtBlendingData.Columns.Add(dcDischargeTime);
        dtBlendingData.Columns.Add(dcStopTime);


        try
        {

            string[] blenderNameArr = { "V101", "V301", "V302", "V401", "V501", "V503", "V504", "V601", "V701", "V801", "V901", "V2401" };

            for (int i = 0; i < blenderNameArr.Length; i++)
            {
                string blendername = blenderNameArr[i];


                DataTable dt = new DataTable();

                dt = DAL.getDailyBlendingData(blendername, tDate);


                if (dt.Rows.Count > 0)
                {

                    double sumVolume = Convert.ToDouble(dt.Compute("sum(BatchSizePVKL)", ""));
                    double sumQC = Convert.ToDouble(dt.Compute("sum(QCTime)", ""));
                    double sumDischarge = Convert.ToDouble(dt.Compute("sum(DischargeTime)", ""));
                    double sumStop = Convert.ToDouble(dt.Compute("sum(StoppageTimeMins)", ""));

                    int cnt = dt.Rows.Count;


                    sumVolume = Math.Round(sumVolume, 0);
                    sumQC = Math.Round(sumQC, 0);
                    sumDischarge = Math.Round(sumDischarge, 0);
                    sumStop = Math.Round(sumStop, 0);

                    dt.Rows.Add("Total", cnt, cnt, cnt, sumVolume, sumQC, sumDischarge, sumStop);

                    dtBlendingData.Merge(dt);


                }



            }

            if (dtBlendingData.Rows.Count > 0)
            {

                double sumVolume = Convert.ToDouble(dtBlendingData.Compute("sum(BatchSizePVKL)", "BlenderNo = 'Total'"));
                double sumQC = Convert.ToDouble(dtBlendingData.Compute("sum(QCTime)", "BlenderNo = 'Total'"));
                double sumDischarge = Convert.ToDouble(dtBlendingData.Compute("sum(DischargeTime)", "BlenderNo = 'Total'"));
                double sumStop = Convert.ToDouble(dtBlendingData.Compute("sum(StoppageTimeMins)", "BlenderNo = 'Total'"));


                sumVolume = Math.Round(sumVolume, 0);
                sumQC = Math.Round(sumQC, 0);
                sumDischarge = Math.Round(sumDischarge, 0);
                sumStop = Math.Round(sumStop, 0);

                dtBlendingData.Rows.Add("Final Total", "", "", "", sumVolume, sumQC, sumDischarge, sumStop);


            }




        }
        catch (Exception ex)
        {

        }
        finally
        {

        }

        return dtBlendingData;
    }


    #endregion

    #region Cumulative Blending Report

    public DataTable getCumulativeBlendingData(string sDate, string eDate)
    {
        DataTable dtFinal = new DataTable();

        DataTable dt = new DataTable();

        DataTable dtTranspose = new DataTable();

        try
        {
            dtFinal = DAL.getCumulativeBlendingData(sDate, eDate);

            if (dtFinal.Rows.Count > 0)
            {
                dt = dtFinal.Clone();

                string[] blenderNameArr = { "V101", "V301", "V302", "V401", "V501", "V503", "V504", "V601", "V701", "V801", "V901", "V2401" };

                for (int i = 0; i < blenderNameArr.Length; i++)
                {

                    string blenderName = blenderNameArr[i];

                    for (int j = 0; j < dtFinal.Rows.Count; j++)
                    {
                        string tDate = dtFinal.Rows[j]["tDate"].ToString();
                        string blender = dtFinal.Rows[j]["BlenderNo"].ToString();
                        string batchCount = dtFinal.Rows[j]["BatchCount"].ToString();
                        string volume = dtFinal.Rows[j]["VolumeBlended"].ToString();

                        if (blenderName == blender)
                        {

                            dt.Rows.Add(blender, tDate, batchCount, volume);

                        }

                    }

                }

                //dtTranspose = GenerateTransposedTable(dt);

            }


        }
        catch (Exception ex)
        {

        }
        finally
        {

        }

        return dt;
    }

    public DataTable GenerateTransposedTable(DataTable inputTable)
    {
        DataTable outputTable = new DataTable();

        try
        {
            // Add columns by looping rows

            // Header row's first column is same as in inputTable
            outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

            // Header row's second column onwards, 'inputTable's first column taken
            foreach (DataRow inRow in inputTable.Rows)
            {
                string newColName = inRow[0].ToString();
                outputTable.Columns.Add(newColName);
            }

            // Add rows by looping columns        
            for (int rCount = 1; rCount <= inputTable.Columns.Count - 1; rCount++)
            {
                DataRow newRow = outputTable.NewRow();

                // First column is inputTable's Header row's second column
                newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
                for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
                {
                    string colValue = inputTable.Rows[cCount][rCount].ToString();
                    newRow[cCount + 1] = colValue;
                }
                outputTable.Rows.Add(newRow);
            }

        }
        catch (Exception ex)
        {

        }


        return outputTable;
    }

    #endregion

    #region OEE Report

    public DataTable getOEE(string sdate, string edate, string blendername)
    {
        DataTable dt = new DataTable();
        double oee = 0.0;
        double stdBCT = 0.0;
        double actBCT = 0.0;
        double sbct = 0.0;
        double abct = 0.0;
        double EmStop = 0.0;
        try
        {

            dt = DAL.getOEE(sdate, edate, blendername);

            dt.Columns.Add("OEE");
            dt.Columns.Add("SubBCT");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    stdBCT = Convert.ToDouble(dt.Rows[i]["StdBCT"]);
                    actBCT = Convert.ToDouble(dt.Rows[i]["ActBCT"]);
                    EmStop = Convert.ToDouble(dt.Rows[i]["EmergStopTimeMins"]);
                    sbct = actBCT - EmStop;
                    oee = Math.Round(((stdBCT / sbct) * 100), 2);

                    if (oee > 100)
                    {
                        oee = 100;
                    }

                    dt.Rows[i]["OEE"] = oee;
                    dt.Rows[i]["SubBCT"] = sbct;
                    //sbct = sbct + stdBCT;
                    //abct = abct + actBCT;
                }

                //oee = (sbct / abct) * 100;
                //int cnt = dt.Rows.Count;
                //dt.Rows.Add("OEE");
                //dt.Rows[cnt]["OEE"] = oee;
            }
        }
        catch (Exception ex)
        {

        }

        return dt;
    }

    #endregion

    #region AlarmReport

    public DataTable getAlarmsHistory(string sdate, string edate)
    {
        DataTable dt = new DataTable();

        try
        {
            dt = DAL.getAlarmsHistory(sdate, edate);
        }
        catch (Exception ex)
        {

        }

        return dt;

    }

    #endregion

    #region DDU Work Time Data

    public DataTable getDDUWorkTimeData(string sdate, string edate, string ddu, string blenderName)
    {
        DataTable dt = new DataTable();
        string DDU_Time = "";
        string StartTime = "";
        string StopTime = "";
        int PumpRunTime_HH = 0;
        int PumpRunTime_MM = 0;
        int PumpRunTime_SS = 0;
        double PumpRunTime = 0.0;
        double DosingQty = 0.0;
        double TheoryThroughput = 0.0;
        double ThroughputDiff = 0.0;

        try
        {
            dt = DAL.getDDUWorkTimeData(sdate, edate, ddu, blenderName);

            if (dt.Rows.Count > 0)
            {
                DataColumn dcDiff1 = new DataColumn("Difference1", typeof(System.Double));
                DataColumn dcDiff2 = new DataColumn("Difference2", typeof(System.Double));
                DataColumn dcThroughput = new DataColumn("Throughput", typeof(System.Double));
                DataColumn dcPumpRuntime = new DataColumn("PUMP_RUNTIME", typeof(System.Double));
                DataColumn dcThroughputDiff = new DataColumn("ThroughputDiff", typeof(System.Double));

                dt.Columns.Add(dcDiff1);
                dt.Columns.Add(dcDiff2);
                dt.Columns.Add(dcThroughput);
                dt.Columns.Add(dcPumpRuntime);
                dt.Columns.Add(dcThroughputDiff);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DDU_Time = Convert.ToString(dt.Rows[i]["DDU_DTTM"]); // DDU_DTTM
                    StartTime = Convert.ToString(dt.Rows[i]["START_DTTM"]); //START_DTTM
                    StopTime = Convert.ToString(dt.Rows[i]["STOP_DTTM"]); //STOP_DTTM
                    PumpRunTime_HH = Convert.ToInt32(dt.Rows[i]["PUMP_RUNTIME_HH"]);// ADD HH:mm:ss
                    PumpRunTime_MM = Convert.ToInt32(dt.Rows[i]["PUMP_RUNTIME_MIN"]);// ADD HH:mm:ss
                    PumpRunTime_SS = Convert.ToInt32(dt.Rows[i]["PUMP_RUNTIME_SS"]);// ADD HH:mm:ss
                    TheoryThroughput = Convert.ToDouble(dt.Rows[i]["Theoratical_Throughput"]);


                    PumpRunTime = (PumpRunTime_HH * 60) + PumpRunTime_MM + (PumpRunTime_SS / 60);

                    DosingQty = Convert.ToDouble(dt.Rows[i]["DOSING_QTY"]);

                    DateTime dtDDU = DateTime.ParseExact(DDU_Time, "yyyy-MM-dd HH:mm:ss", new DateTimeFormatInfo());
                    DateTime dtStartTime = DateTime.ParseExact(StartTime, "yyyy-MM-dd HH:mm:ss", new DateTimeFormatInfo());
                    DateTime dtStopTime = DateTime.ParseExact(StopTime, "yyyy-MM-dd HH:mm:ss", new DateTimeFormatInfo());

                    TimeSpan tDiff1 = dtDDU.Subtract(dtStartTime); 
                    TimeSpan tTimeDiff = dtStopTime.Subtract(dtStartTime);

                    double diff1 = (tDiff1.Hours * 60) + (tDiff1.Minutes);
                    double timeDiff = (tTimeDiff.Hours * 60) + (tTimeDiff.Minutes);

                    double PlantStopTime = 510.0; //night time
                    if (timeDiff >= PlantStopTime)
                    {
                        timeDiff = timeDiff - PlantStopTime;
                    }
                    if (diff1 >= PlantStopTime)
                    {
                        diff1 = diff1 - PlantStopTime;
                    }

                    double diff2 = timeDiff - diff1;

                    double differnce = diff2 - PumpRunTime;

                    //new addtion as per customer 23082018 nikhil

                    if (PumpRunTime <= 0 )
                    {
                        PumpRunTime = 0.5;
                    }

                    double Throughput = DosingQty / PumpRunTime;

                    //if (double.IsInfinity(Throughput))
                    //{
                    //    Throughput = 0.0;
                    //}

                    ThroughputDiff = TheoryThroughput - Throughput;

                    dt.Rows[i]["Difference1"] = diff1;
                    dt.Rows[i]["Difference2"] = differnce;
                    dt.Rows[i]["Throughput"] = Throughput;
                    dt.Rows[i]["PUMP_RUNTIME"] = PumpRunTime;
                    dt.Rows[i]["ThroughputDiff"] = ThroughputDiff;
                }
            }

        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }

        return dt;

    }

    public DataTable getDDUName()
    {
        DataTable dt = new DataTable();

        try
        {
            dt = DAL.getDDUName();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }

        return dt;
    }

    public DataTable getBlenderDataDDU(string dduName)
    {
        DataTable dt = new DataTable();

        try
        {
            dt = DAL.getBlenderDataDDU(dduName);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }

        return dt;

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

    #region Pigging Report Data

    public string getPigTable(string SelectedArea)
    {
        string TableName = "";
        try
        {
            TableName = DAL.getPigTable(SelectedArea);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return TableName;
    }
    public string getDosingTable(string SelectedArea)
    {
        string TableName = "";
        try
        {
            TableName = DAL.getPigTable(SelectedArea);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
        return TableName;
    }

    public DataTable getPigData(string FromDate, string ToDate, string ViewName, string SelectedArea)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getPigData(FromDate, ToDate, ViewName, SelectedArea);

            string StartDTTM = "";
            string EndDTTM = "";
            DataColumn dcDiff1 = new DataColumn("Difference", typeof(System.Double));
            DataColumn dcFromDate = new DataColumn("FromDate", typeof(System.String));
            DataColumn dcToDate = new DataColumn("ToDate", typeof(System.String));
            DataColumn dcBlenderName = new DataColumn("BlenderName", typeof(System.String));
            dt.Columns.Add(dcDiff1);
            dt.Columns.Add(dcFromDate);
            dt.Columns.Add(dcToDate);
            dt.Columns.Add(dcBlenderName);


            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    StartDTTM = Convert.ToString(dt.Rows[i]["StartDTTM"]);
                    EndDTTM = Convert.ToString(dt.Rows[i]["EndDTTM"]);

                    DateTime dtStartTime = DateTime.ParseExact(StartDTTM, "yyyy-MM-dd HH:mm:ss", new DateTimeFormatInfo());
                    DateTime dtStopTime = DateTime.ParseExact(EndDTTM, "yyyy-MM-dd HH:mm:ss", new DateTimeFormatInfo());

                    TimeSpan tDiff1 = dtStopTime.Subtract(dtStartTime);

                    double diff1 = (tDiff1.Hours * 60) + (tDiff1.Minutes);
                    
                    dt.Rows[i]["Difference"] = diff1;
                    dt.Rows[i]["FromDate"] = FromDate;
                    dt.Rows[i]["ToDate"] = ToDate;
                    dt.Rows[i]["BlenderName"] = SelectedArea;


                }
            }
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }

        return dt;
    }
    public DataTable getDosingData(string FromDate, string ToDate, string ViewName)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getDosingData(FromDate, ToDate, ViewName);

            string StartDTTM = "";
            string EndDTTM = "";
            DataColumn dcDiff1 = new DataColumn("Difference", typeof(System.Double));
            DataColumn dcFromDate = new DataColumn("FromDate", typeof(System.String));
            DataColumn dcToDate = new DataColumn("ToDate", typeof(System.String));
            dt.Columns.Add(dcDiff1);
            dt.Columns.Add(dcFromDate);
            dt.Columns.Add(dcToDate);


            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    dt.Rows[i]["FromDate"] = FromDate;
                    dt.Rows[i]["ToDate"] = ToDate;


                }
            }
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }

        return dt;
    }
    
    #endregion



    public DataTable getRMCodeData()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getRMCodeData();
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }

        return dt;
    }

    public DataTable getRMConsDataFilter(string fdtm, string tdtm, string RMCode, string FilterBy)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getRMConsDataFilter(fdtm, tdtm, RMCode,FilterBy);
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }

        return dt;
    }

    public string getTankData()
    {
        string data = "";
        //string HotWaterData = "";


        DataTable dt = new DataTable();
        try
        {
            dt = DAL.getTankData();

            

            if (dt.Rows.Count > 0)
            {
                List<string> add_list = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string TankName = "";



                    TankName = dt.Rows[i]["TankDescription"].ToString();

                    //      var obj = new TankNameClass(TankName);
                    //TankNameList.Add(obj);





                    add_list.Add(dt.Rows[i]["TankDescription"].ToString());

                    Console.WriteLine(add_list);
                }

                //plotData += obj;



                string plotData = "";
                JavaScriptSerializer js1 = new JavaScriptSerializer();
                plotData = (js1.Serialize(add_list));

                //   plotData = TankNameList.ToString();

                //  JsonConvert.SerializeObject(tags)
                //   plotData = TankNameList;

                data = plotData;

            }
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }

        return data;
    }
}