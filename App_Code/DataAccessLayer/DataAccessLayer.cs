using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Globalization;

/// <summary>
/// Summary description for DataAccessLayer
/// </summary>
/// 

public class DataAccessLayer
{

    static string strcon = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
    SqlConnection con;

    #region Basic Reports

    #region Base Oil Data

    public DataTable GetBaseOilData()
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select * from BO_LIST", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    #endregion

    #region Bulk Additive Data

    public DataTable GetBulkAddTVData()
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select * from BA_LIST", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    #endregion

    #region Man Additive Data

    public DataTable GetManAddData()
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select * from MA_LIST", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    #endregion

    #region Drum Additive Data

    public DataTable GetDrumAddData()
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select * from DA_LIST", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    #endregion

    #region Picklist Data

    public DataTable GetPickList()
    {
        string ViewName = "";
        DataTable dt = new DataTable();

        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select * from PICK_LIST where FAMILY != 'NIL' order by RowId,FAMILY asc", con);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);

            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable GetPickListData()
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select * from PICK_LIST order by FAMILY asc", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable getRMData(string rmCode)
    {
        DataTable dt = new DataTable();
        try
        {
            using (con = new SqlConnection(strcon))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM CSV_DATA WHERE PRODUCT='" + rmCode + "'", con);
                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    adap.Fill(dt);
                }
                catch (Exception ex)
                {
                    this.LogError(ex);
                }
                finally
                {
                    con.Close();
                    SqlConnection.ClearPool(con);
                }
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

    public DataTable getRMDataPickList(string rmCode, string rmType)
    {
        DataTable dt = new DataTable();
        try
        {
            using (con = new SqlConnection(strcon))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM CSV_DATA WHERE PRODUCT='" + rmCode + "' and TableName = '" + rmType + "'", con);
                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    adap.Fill(dt);
                }
                catch (Exception ex)
                {
                    this.LogError(ex);
                }
                finally
                {
                    con.Close();
                    SqlConnection.ClearPool(con);
                }
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

    #endregion

    #region FamilyWiseProductList

    public DataTable GetProductListData()
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select * from PRODUCT_LIST order by Family asc", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    #endregion

    #endregion

    #region BatchReport

    public DataTable getBlenderData()
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select * from MINT_BlenderName", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable getProductList(string blender_Name)
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select ViewName from MINT_BlenderName where BlenderName=@BlenderName", con);
                cmd1.Parameters.AddWithValue("@BlenderName", blender_Name);
                cmd1.ExecuteNonQuery();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(dt1);

                SqlCommand cmd = new SqlCommand("Select distinct PRODUCT_NAME from " + dt1.Rows[0]["ViewName"] + "", con);
                //cmd.Parameters.AddWithValue("@ViewName", dt1.Rows[0]["ViewName"]);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;

    }

    public DataTable getBatchList(string blender_Name, string prdName)
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select ViewName from MINT_BlenderName where BlenderName='" + blender_Name + "'", con);
                cmd1.Parameters.AddWithValue("@BlenderName", blender_Name);
                cmd1.ExecuteNonQuery();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(dt1);

                SqlCommand cmd = new SqlCommand("Select distinct BTCH_NO from " + dt1.Rows[0]["ViewName"] + " where PRODUCT_NAME =@prdName", con);
                cmd.Parameters.AddWithValue("@prdName", prdName);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable getReportData(string blender_Name, string prdName, string btchName)
    {
        DataTable dt = new DataTable();
        DataTable dtDttm = new DataTable();
        DataTable dt1 = new DataTable();
        double BatchTime = 0.0;
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select ViewName,TableName from MINT_BlenderName where BlenderName=@blender_Name", con);
                cmd1.Parameters.AddWithValue("@blender_Name", blender_Name);
                cmd1.ExecuteNonQuery();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(dt1);

                string tableName = "";
                string viewName = "";

                if (dt1.Rows.Count > 0)
                {
                    tableName = Convert.ToString(dt1.Rows[0]["TableName"]);
                    viewName = Convert.ToString(dt1.Rows[0]["ViewName"]);
                }

                if ((tableName != "") && (viewName != ""))
                {
                    SqlCommand cmdDttm = new SqlCommand("select max(DTTM) as DTTM from " + tableName + " where PRODUCT_NAME=@prdName and BTCH_NO=@btchName", con);
                    cmdDttm.Parameters.AddWithValue("@prdName", prdName);
                    cmdDttm.Parameters.AddWithValue("@btchName", btchName);
                    cmdDttm.ExecuteNonQuery();
                    SqlDataAdapter sdaDttm = new SqlDataAdapter(cmdDttm);
                    sdaDttm.Fill(dtDttm);
                    string dttmVal = "";
                    if (dtDttm.Rows.Count > 0)
                    {
                        string dttmTemp = "";
                        dttmTemp = Convert.ToString(dtDttm.Rows[0]["DTTM"]);
                        if (dttmTemp != "")
                        {
                            DateTime dttm1 = Convert.ToDateTime(dttmTemp);
                            dttmVal = dttm1.ToString("yyyy-MM-dd HH:mm:ss");
                        }
                    }

                    if (dttmVal != "")
                    {
                        SqlCommand cmd = new SqlCommand("select * from " + viewName + " where PRODUCT_NAME=@prdName and BTCH_NO=@btchName and DTTM='" + dttmVal + "' order by DTTM asc, SN asc", con);
                        cmd.Parameters.AddWithValue("@prdName", prdName);
                        cmd.Parameters.AddWithValue("@btchName", btchName);
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);
                    }
                }

                #region Phase Duration Calculation

                if (dt.Rows.Count > 0)
                {
                    DataColumn dcPhaseDuration = new DataColumn("tPhaseDuration");
                    dt.Columns.Add(dcPhaseDuration);

                    DataColumn dcStopDuration = new DataColumn("tStopDuration");
                    dt.Columns.Add(dcStopDuration);

                    //DataColumn dcBatchTime = new DataColumn("BTime");
                    //dt.Columns.Add(dcBatchTime);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //double Duration = Convert.ToDouble(dt.Rows[i]["PhaseDuration"]);
                        double Duration = 0.0;

                        #region Phase Duration Calc

                        if (Convert.ToString(dt.Rows[i]["PhaseDuration"]) != "")
                        {
                            Duration = Convert.ToDouble(dt.Rows[i]["PhaseDuration"]);
                        }
                        else
                        {
                            Duration = 0.0;
                        }

                        TimeSpan tDuration = TimeSpan.FromMinutes(Math.Round(Duration, 0));

                        string hours = "";
                        string Minutes = "";

                        if (tDuration.Hours < 10)
                        {
                            hours = tDuration.Hours.ToString().PadLeft(2, '0');
                        }
                        else
                        {
                            hours = tDuration.Hours.ToString();
                        }

                        if (tDuration.Minutes < 10)
                        {
                            Minutes = tDuration.Minutes.ToString().PadLeft(2, '0');
                        }
                        else
                        {
                            Minutes = tDuration.Minutes.ToString();
                        }

                        string sDuration = hours + ":" + Minutes;

                        dt.Rows[i]["tPhaseDuration"] = sDuration;

                        #endregion

                        //Added for Stop Duration by Nikhil

                        #region Stop Duration Calc

                        double StopDuration = 0.0;

                        if (Convert.ToString(dt.Rows[i]["STEP_STOP_TIME"]) != "")
                        {
                            StopDuration = Convert.ToDouble(dt.Rows[i]["STEP_STOP_TIME"]);
                        }
                        else
                        {
                            StopDuration = 0.0;
                        }


                        TimeSpan tSDuration = TimeSpan.FromMinutes(Math.Round(StopDuration, 0));

                        string shours = "";
                        string sMinutes = "";

                        if (tSDuration.Hours < 10)
                        {
                            shours = tSDuration.Hours.ToString().PadLeft(2, '0');
                        }
                        else
                        {
                            shours = tSDuration.Hours.ToString();
                        }

                        if (tSDuration.Minutes < 10)
                        {
                            sMinutes = tSDuration.Minutes.ToString().PadLeft(2, '0');
                        }
                        else
                        {
                            sMinutes = tSDuration.Minutes.ToString();
                        }

                        string stopDuration = shours + ":" + sMinutes;

                        dt.Rows[i]["tStopDuration"] = stopDuration;

                        #endregion

                        //Batch Duration Calculation 
                        //BatchTime = BatchTime + Duration + StopDuration;
                        //dt.Rows[i]["BTime"] = BatchTime;
                    }
                }

                #endregion

            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    #endregion

    #region Batch Accuracy

    public DataTable GetBatchAccuracyData(string blender_Name, string ProductName, string batchNo)
    {
        DataTable dt = new DataTable();
        DataTable dtDttm = new DataTable();
        DataTable dt1 = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select ViewName,TableName from MINT_BlenderName where BlenderName=@ViewName", con);
                cmd1.Parameters.AddWithValue("@ViewName", blender_Name);
                cmd1.ExecuteNonQuery();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(dt1);

                string tableName = "";
                string viewName = "";

                if (dt1.Rows.Count > 0)
                {
                    tableName = Convert.ToString(dt1.Rows[0]["TableName"]);
                    viewName = Convert.ToString(dt1.Rows[0]["ViewName"]);
                }

                if ((tableName != "") && (viewName != ""))
                {

                    SqlCommand cmdDttm = new SqlCommand("select max(DTTM) as DTTM from " + tableName + " where PRODUCT_NAME=@prdName and BTCH_NO=@btchName", con);
                    cmdDttm.Parameters.AddWithValue("@prdName", ProductName);
                    cmdDttm.Parameters.AddWithValue("@btchName", batchNo);
                    cmdDttm.ExecuteNonQuery();
                    SqlDataAdapter sdaDttm = new SqlDataAdapter(cmdDttm);
                    sdaDttm.Fill(dtDttm);
                    string dttmVal = "";
                    if (dtDttm.Rows.Count > 0)
                    {
                        string dttmTemp = "";
                        dttmTemp = Convert.ToString(dtDttm.Rows[0]["DTTM"]);
                        if (dttmTemp != "")
                        {
                            DateTime dttm1 = Convert.ToDateTime(dttmTemp);
                            dttmVal = dttm1.ToString("yyyy-MM-dd HH:mm:ss");
                        }
                    }

                    if (dttmVal != "")
                    {

                        SqlCommand cmd = new SqlCommand("select * from " + viewName + " where PRODUCT_NAME=@prdName and BTCH_NO=@btchName and DTTM='" + dttmVal + "' order by DTTM asc, SN asc", con);
                        cmd.Parameters.AddWithValue("@prdName", ProductName);
                        cmd.Parameters.AddWithValue("@btchName", batchNo);
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);

                    }
                }

            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    #endregion

    #region Cumulative Report Family/Blender wise

    public DataTable getCumulativeReportData(string FamilyName, string BatchNo)
    {
        string ViewName = "";
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();

        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                #region OLD Report Comment

                //SqlCommand cmd1 = new SqlCommand("select ViewName from MINT_FamilyList where FamilyName = '" + FamilyName + "' order by RowId asc ", con);
                //cmd1.ExecuteNonQuery();
                //SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                //sda1.Fill(dt1);

                //if (dt1.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dt1.Rows.Count; i++)
                //    {
                //        ViewName = dt1.Rows[i]["ViewName"].ToString();

                //        SqlCommand cmd = new SqlCommand("select * from " + ViewName + " where ((FAMILY='" + FamilyName + "') and (BTCH_NO='" + BatchNo + "') and (INGRDNT != 'NIL'))", con);
                //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //        sda.Fill(dt);
                //    }
                //}

                //dtAll.Merge(dt1);

                #endregion

                //SqlCommand cmd = new SqlCommand("select * from MINT_vRMConsumption where ((FAMILY='" + FamilyName + "') and (BatchNumber ='" + BatchNo + "'))", con);

                SqlCommand cmd = new SqlCommand("select BatchNumber, INGRDNT, sum(SP1) as SP1, sum(PV1) as PV1, FAMILY, PRODUCT_NAME, PRODUCT_DESC, [TYPE] from MINT_vRMConsumption  where ((FAMILY='" + FamilyName + "') and (BatchNumber ='" + BatchNo + "') and (INGRDNT not like 'PREMIX%'))  group by INGRDNT, BatchNumber, FAMILY, PRODUCT_NAME, PRODUCT_DESC, TYPE", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable getCumulativeBatchData(string FamilyName, string BatchNo)
    {
        string ViewName = "";
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();

        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();



                SqlCommand cmd = new SqlCommand("select top 1 * from MINT_vRMConsumption where ((FAMILY='" + FamilyName + "') and (BatchNumber ='" + BatchNo + "')) order by RowInsertTime desc", con);
                //SqlCommand cmd = new SqlCommand("select BatchNumber, INGRDNT, TANK, sum(SP1) as SP1, sum(PV1) as PV1, Destination,  BlenderName, FAMILY, PRODUCT_NAME, PRODUCT_DESC, TYPE from MINT_RMConsumption  where ((FAMILY='" + FamilyName + "') and (BatchNumber ='" + BatchNo + "')) group by INGRDNT, BatchNumber, TANK, Destination,  BlenderName, FAMILY, PRODUCT_NAME, PRODUCT_DESC, TYPE", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);


            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public string getDestinationData(string familyName, string batchNo)
    {
        string destination = "";
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlCommand cmd = new SqlCommand("select Destination from MINT_RMConsumption where BatchNumber = '" + batchNo + "' and FAMILY = '" + familyName + "' order by RowInsertTime asc", con);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    destination = Convert.ToString(dt.Rows[dt.Rows.Count - 1]["Destination"]);
                }

            }
            catch (Exception ex)
            {

            }
        }
        return destination;
    }

    public DataTable getCumulativeReport(string FamilyName, string BatchNo)
    {
        string ViewName = "";
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();

        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select ViewName from MINT_FamilyList where FamilyName = '" + FamilyName + "'", con);
                cmd1.ExecuteNonQuery();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(dt1);

                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    ViewName = dt1.Rows[0]["ViewName"].ToString();

                }

                if (ViewName != "")
                {
                    SqlCommand cmd = new SqlCommand("select INGRDNT, RM_DESC, TankDescription, sum(SP1) as SP1, sum(PV1) as PV1  from " + ViewName + " where ((FAMILY='" + FamilyName + "') and (BTCH_NO='" + BatchNo + "') and (INGRDNT != 'NIL')) group by INGRDNT, RM_DESC, TankDescription", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable getFamilyName()
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select * from MINT_FamilyList", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable getBatchNumbers(string blenderNo)
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select distinct BatchNumber from MINT_vRMConsumption where BlenderName='" + blenderNo + "' order by BatchNumber asc", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();

            }
        }
        return dt;
    }

    public string getTankDescription(string batchNo, string rmCode)
    {
        DataTable dt = new DataTable();
        string TankName = "";

        using (con = new SqlConnection(strcon))
        {

            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlCommand cmd = new SqlCommand("select TankDescription from MINT_vRMConsumption where BatchNumber = @a and INGRDNT = @b", con);
                cmd.Parameters.AddWithValue("@a", batchNo);
                cmd.Parameters.AddWithValue("@b", rmCode);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string tank = "";
                    string preTank = "";
                    int flag = 0;
                    string finalTank = "";

                    if (dt.Rows.Count > 1)
                    {
                        DataTable dt1 = new DataTable();
                        DataView dv = new DataView(dt);
                        dt1 = dv.ToTable(true, "TankDescription");

                        if (dt1.Rows.Count > 0)
                        {
                            if (dt1.Rows.Count == 1)
                            {
                                TankName = Convert.ToString(dt1.Rows[0]["TankDescription"]);
                            }
                            else
                            {
                                for (int i = 0; i < dt1.Rows.Count; i++)
                                {
                                    tank = Convert.ToString(dt1.Rows[i]["TankDescription"]);

                                    if (tank != "")
                                    {
                                        tank = "*" + tank;
                                        TankName = tank;
                                        break;
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        TankName = Convert.ToString(dt.Rows[0]["TankDescription"]);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        return TankName;
    }

    public string getBlenderData(string batchNo)
    {
        string BlenderData = "";
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();

        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select distinct BlenderName from MINT_RMConsumption  where (BatchNumber ='" + batchNo + "')", con);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string blender1 = Convert.ToString(dt.Rows[i][0]);

                        if (BlenderData == "")
                        {
                            BlenderData = blender1;
                        }
                        else
                        {
                            BlenderData = BlenderData + " + " + blender1;
                        }
                    }

                    BlenderData = BlenderData + "," + dt.Rows.Count.ToString();
                }
                else
                {
                    BlenderData = "" + "," + "0";
                }
            }
            catch (Exception ex)
            {

            }
        }

        return BlenderData;
    }

    public double getBatchSizeData(string batchNo)
    {
        double batchSizeData = 0.0;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();

        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select Max(BTCH_SIZE_SP) as BTCH_SIZE_SP from MINT_RMConsumption  where (BatchNumber ='" + batchNo + "')", con);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string batchSizeDataS = Convert.ToString(dt.Rows[0]["BTCH_SIZE_SP"]);

                    batchSizeData = 0.0;

                    if (batchSizeDataS != "")
                    {
                        batchSizeData = Convert.ToDouble(batchSizeDataS);
                    }
                    else
                    {
                        batchSizeData = 0.0;
                    }



                }
            }
            catch (Exception ex)
            {

            }
        }

        return batchSizeData;
    }

    public DataTable getFamilyNames(string blenderNo, string BatchNo)
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select FAMILY from MINT_vRMConsumption where BlenderName = @a and BatchNumber = @b", con);
                cmd.Parameters.AddWithValue("@a", blenderNo);
                cmd.Parameters.AddWithValue("@b", BatchNo);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);

            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();

            }
        }
        return dt;
    }

    #endregion

    #region Blenderwise BCT Data

    public DataTable getBCTData(string blender_Name, string FDate, string EDate)
    {
        DataTable dt = new DataTable();
        DataTable dtFamily = new DataTable();

        string BlenderName = "";
        string BatchNo = "";
        string TableName = "";

        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from MINT_BatchSummary where BlenderNo=@BlenderNo and tDate between @fDate and @eDate order by RowInsertTime asc", con);
                cmd.Parameters.AddWithValue("@BlenderNo", blender_Name);
                cmd.Parameters.AddWithValue("@fDate", FDate);
                cmd.Parameters.AddWithValue("@eDate", EDate);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                DataColumn dcFamily = new DataColumn("Family");
                dt.Columns.Add(dcFamily);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BlenderName = dt.Rows[i]["BlenderNo"].ToString();
                    BatchNo = dt.Rows[i]["BatchNo"].ToString();

                    SqlCommand cmd1 = new SqlCommand("Select TableName from MINT_BlenderName where BlenderName=@blenderName", con);
                    cmd1.Parameters.AddWithValue("@blenderName", BlenderName);
                    DataTable dtTbl = new DataTable();
                    SqlDataAdapter sdaTbl = new SqlDataAdapter(cmd1);
                    sdaTbl.Fill(dtTbl);

                    TableName = dtTbl.Rows[0]["TableName"].ToString();
                    SqlCommand cmdFamily = new SqlCommand("Select FAMILY from " + TableName + " where BTCH_NO='" + BatchNo + "'", con);
                    SqlDataAdapter sdaFamily = new SqlDataAdapter(cmdFamily);
                    dtFamily.Clear();
                    sdaFamily.Fill(dtFamily);

                    string family = dtFamily.Rows[0]["FAMILY"].ToString();
                    dt.Rows[i]["Family"] = family;

                }


            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    #endregion

    #region Productwise BCT Data

    public DataTable getProductWiseBCT(string Product, string FDate, string EDate, string blender)
    {
        DataTable dt = new DataTable();
        DataTable dtFamily = new DataTable();

        string BlenderName = "";
        string BatchNo = "";
        string TableName = "";

        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("Select * from MINT_BatchSummary where ((ProductCode=@ProdCode) and (tDate between @fDate and @eDate) and (BlenderNo = @blender)) order by RowInsertTime asc", con);
                cmd.Parameters.AddWithValue("@ProdCode", Product);
                cmd.Parameters.AddWithValue("@fDate", FDate);
                cmd.Parameters.AddWithValue("@eDate", EDate);
                cmd.Parameters.AddWithValue("@blender", blender);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                DataColumn dcFamily = new DataColumn("Family");
                dt.Columns.Add(dcFamily);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BlenderName = dt.Rows[i]["BlenderNo"].ToString();
                    BatchNo = dt.Rows[i]["BatchNo"].ToString();

                    SqlCommand cmd1 = new SqlCommand("Select TableName from MINT_BlenderName where BlenderName=@blenderName", con);
                    cmd1.Parameters.AddWithValue("@blenderName", BlenderName);
                    DataTable dtTbl = new DataTable();
                    SqlDataAdapter sdaTbl = new SqlDataAdapter(cmd1);
                    sdaTbl.Fill(dtTbl);

                    TableName = dtTbl.Rows[0]["TableName"].ToString();
                    SqlCommand cmdFamily = new SqlCommand("Select FAMILY from " + TableName + " where BTCH_NO='" + BatchNo + "'", con);
                    SqlDataAdapter sdaFamily = new SqlDataAdapter(cmdFamily);
                    dtFamily.Clear();
                    sdaFamily.Fill(dtFamily);

                    string family = dtFamily.Rows[i]["FAMILY"].ToString();
                    dt.Rows[i]["Family"] = family;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        }
        return dt;
    }

    public DataTable GetProductList()
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select distinct ProductCode from MINT_BatchSummary order by ProductCode asc", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    #endregion

    #region RM Consumption Report

    public DataTable getRMConsData(string fdtm, string tdtm)
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select RMCode,TankDescription, CMNDName, sum(Consumption) as Consumption, sum(TimeConsumed) as TimeConsumed,PumpName,PumpCapacity from MINT_vConsumption where ((Consumption != 0) and (tDate between @a and @b)) group by RMCode, CMNDName,TankDescription,PumpName,PumpCapacity order by RMCode asc", con);
                cmd.Parameters.AddWithValue("@a", fdtm);
                cmd.Parameters.AddWithValue("@b", tdtm);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
                //dtAll.Merge(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    #endregion

    #region Cumulative Consumption Data

    public DataTable getCumulativeConsData(string fdtm, string tdtm)
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                fdtm = fdtm + " " + "00:00:00";
                tdtm = tdtm + " " + "00:00:00";

                SqlCommand cmd = new SqlCommand("select RMCode, sum(Consumption) as Consumption from MINT_Consumption where ((Consumption != 0) and (RowInsertTime between @a and @b)) group by RMCode order by RMCode asc", con); //check any condition for command 
                cmd.Parameters.AddWithValue("@a", fdtm);
                cmd.Parameters.AddWithValue("@b", tdtm);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
                //dtAll.Merge(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    #endregion

    #region Configuration

    #region Blender Configuration

    public DataTable getViewData()
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select * from [Savita_DB].sys.views", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable AddBlenderData(string BlenderName, string ViewName)
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("insert into MINT_BlenderName(BlenderName,ViewName) Values(@BlenderName,@ViewName)", con);
                cmd.Parameters.AddWithValue("@BlenderName", BlenderName);
                cmd.Parameters.AddWithValue("@ViewName", ViewName);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable UpdateGVData(System.Web.UI.WebControls.Label ID, System.Web.UI.WebControls.TextBox name, System.Web.UI.WebControls.DropDownList view)
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("update MINT_BlenderName set BlenderName=@BlenderName,ViewName=@ViewName where RowId=@RowId", con);
                cmd.Parameters.AddWithValue("@BlenderName", name.Text);
                cmd.Parameters.AddWithValue("@ViewName", view.SelectedValue);
                cmd.Parameters.AddWithValue("@RowId", ID.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    #endregion

    #region Command Configuration

    public DataTable getCommandData()
    {
        DataTable dt = new DataTable();

        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select * from MINT_CMNDDescription where CMNDNo!='0' order by RowId asc", con);
                cmd1.ExecuteNonQuery();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable AddCommandData(string CmdNo, string CmdDesc, string sp1Unit, string sp2Unit)
    {
        DataTable dt = new DataTable();

        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("insert into MINT_CMNDDescription(CMNDNo,CMNDName,CMNDUnitSP1,CMNDUnitSP2) Values(@CmdNo,@CmdDesc,@sp1Unit,@sp2Unit)", con);
                cmd1.Parameters.AddWithValue("@CmdNo", CmdNo);
                cmd1.Parameters.AddWithValue("@CmdDesc", CmdDesc);
                cmd1.Parameters.AddWithValue("@sp1Unit", sp1Unit);
                cmd1.Parameters.AddWithValue("@sp2Unit", sp2Unit);
                cmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable GetEditCommandData(string CommandNo)
    {
        DataTable dt = new DataTable();

        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select * from MINT_CMNDDescription where CMNDNo=@CmdNo order by RowId asc", con);
                cmd1.Parameters.AddWithValue("@CmdNo", CommandNo);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(dt);
                cmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable UpdateCommandData(string CommandNo, string CommandDesc, string Sp1, string sp2)
    {
        DataTable dt = new DataTable();

        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("update MINT_CMNDDescription set CMNDNo=@CommandNo,CMNDName=@CommandDesc,CMNDUnitSP1=@Sp1,CMNDUnitSP2=@sp2 where CMNDNo=@CommandNo", con);
                cmd1.Parameters.AddWithValue("@CommandNo", CommandNo);
                cmd1.Parameters.AddWithValue("@CommandDesc", CommandDesc);
                cmd1.Parameters.AddWithValue("@Sp1", Sp1);
                cmd1.Parameters.AddWithValue("@sp2", sp2);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(dt);
                cmd1.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    #endregion

    #region Source Tank Configuration

    public DataTable AddTankSourceData(string TankNo, string TankDesc)
    {
        DataTable dt = new DataTable();

        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("insert into MINT_RMSourceTankDesc(TankNo,TankDescription) values(@TankNo,@TankDesc)", con);
                cmd1.Parameters.AddWithValue("@TankNo", TankNo);
                cmd1.Parameters.AddWithValue("@TankDesc", TankDesc);
                cmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable getSourceTankData()
    {
        DataTable dt = new DataTable();

        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select TankNo,TankDescription from MINT_RMSourceTankDesc order by RowId asc", con);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(dt);
                cmd1.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable EditTankSourceData(string TankNo, string TankDesc)
    {
        DataTable dt = new DataTable();

        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("update MINT_RMSourceTankDesc set TankDescription=@TankDesc where TankNo=@TankNo", con);
                cmd1.Parameters.AddWithValue("@TankDesc", TankDesc);
                cmd1.Parameters.AddWithValue("@TankNo", TankNo);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(dt);
                cmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable GetEditTankData(string TankNo)
    {
        DataTable dt = new DataTable();

        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select * from MINT_RMSourceTankDesc where TankNo=@TankNo", con);
                cmd1.Parameters.AddWithValue("@TankNo", TankNo);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(dt);
                cmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    #endregion

    #region Family Configuration

    public DataTable getFamilyData()
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from MINT_FamilyList order by FamilyName asc", con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable AddFamilyData(string familyName, string ViewName)
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into MINT_FamilyList(FamilyName,ViewName) Values(@FamilyName,@ViewName)", con);
                cmd.Parameters.AddWithValue("@FamilyName", familyName);
                cmd.Parameters.AddWithValue("@ViewName", ViewName);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable UpdateFamilyData(System.Web.UI.WebControls.Label ID, System.Web.UI.WebControls.TextBox name, System.Web.UI.WebControls.DropDownList view)
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("update MINT_FamilyList set FamilyName=@FamilyName,ViewName=@ViewName where RowId=@RowId", con);
                cmd.Parameters.AddWithValue("@FamilyName", name.Text);
                cmd.Parameters.AddWithValue("@ViewName", view.SelectedValue);
                cmd.Parameters.AddWithValue("@RowId", ID.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable getFamilyData(string FamilyName)
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select distinct BatchNumber from MINT_vRMConsumption where FAMILY = @a order by BatchNumber asc", con);
                cmd.Parameters.AddWithValue("@a", FamilyName);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);

            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
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
            using (con = new SqlConnection(strcon))
            {
                SqlCommand cmd = new SqlCommand("select distinct(FAMILY) as FAMILY from PRODUCT_LIST", con);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
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

    public DataTable getProductDetails(string familyName)
    {
        DataTable dt = new DataTable();
        try
        {
            using (con = new SqlConnection(strcon))
            {
                SqlCommand cmd = new SqlCommand("select PROD_CODE as PROD_CODE from PRODUCT_LIST where FAMILY = @a", con);
                cmd.Parameters.AddWithValue("@a", familyName);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
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

    public DataTable getProductCodes()
    {
        DataTable dt = new DataTable();
        try
        {
            using (con = new SqlConnection(strcon))
            {
                SqlCommand cmd = new SqlCommand("select PROD_CODE from PRODUCT_LIST", con);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
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

    public DataTable getProductCodeDetails(string productCode, string familyName)
    {
        DataTable dt = new DataTable();
        try
        {
            using (con = new SqlConnection(strcon))
            {
                SqlCommand cmd = new SqlCommand("select * from PRODUCT_LIST where FAMILY = @a and PROD_CODE = @b", con);
                cmd.Parameters.AddWithValue("@a", familyName);
                cmd.Parameters.AddWithValue("@b", productCode);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
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

    public DataTable getProductCodeBCT(string productCode, string familyName)
    {
        DataTable dt = new DataTable();
        try
        {
            using (con = new SqlConnection(strcon))
            {
                SqlCommand cmd = new SqlCommand("select * from MINT_BCTDetailsFinal where ProductCode = @a and Family = @b", con);
                cmd.Parameters.AddWithValue("@a", productCode);
                cmd.Parameters.AddWithValue("@b", familyName);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
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

    public int insertBCTData(string productCode, string fixedBCT, string variableBCT, string family)
    {
        int result = 0;

        try
        {
            using (con = new SqlConnection(strcon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO MINT_BCTDetailsFinal (ProductCode, FixedBCT, VariableBCT, Family) VALUES(@a, @b, @c, @d)", con);
                cmd.Parameters.AddWithValue("@a", productCode);
                cmd.Parameters.AddWithValue("@b", fixedBCT);
                cmd.Parameters.AddWithValue("@c", variableBCT);
                cmd.Parameters.AddWithValue("@d", family);

                result = cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            result = 0;
        }
        finally
        {

        }

        return result;

    }

    public int updateBCTData(string productCode, string fixedBCT, string variableBCT, string family)
    {
        int result = 0;

        try
        {
            using (con = new SqlConnection(strcon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update MINT_BCTDetailsFinal set FixedBCT = @a, VariableBCT = @b where ProductCode = @c and family = @d", con);
                cmd.Parameters.AddWithValue("@a", fixedBCT);
                cmd.Parameters.AddWithValue("@b", variableBCT);
                cmd.Parameters.AddWithValue("@c", productCode);
                cmd.Parameters.AddWithValue("@d", family);

                result = cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            result = 0;
        }
        finally
        {

        }

        return result;
    }

    #endregion

    #endregion

    #region Pre Batch Data

    public DataTable getProductData(string BatchNo)
    {

        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("Select distinct PRODUCT_NAME from MINT_PreBatch where BTCH_NO=@BatchNo", con);
                cmd.Parameters.AddWithValue("@BatchNo", BatchNo);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;

    }

    public DataTable getBatchNo(string equipmentNo)
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select Distinct(BTCH_NO) from MINT_PreBatch where VES_NAME = @a", con);
                cmd.Parameters.AddWithValue("@a", equipmentNo);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable getPreBatchData(string BatchNo, string ProductCode, string vesselNo)
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select DTTM from MINT_PreBatch where BTCH_NO=@BatchNo and PRODUCT_NAME=@ProdName and VES_NAME = @vesselNo order by DTTM asc", con);
                cmd.Parameters.AddWithValue("@BatchNo", BatchNo);
                cmd.Parameters.AddWithValue("@ProdName", ProductCode);
                cmd.Parameters.AddWithValue("@vesselNo", vesselNo);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dttbl = new DataTable();
                adap.Fill(dttbl);
                string dttm = "";

                if (dttbl.Rows.Count > 0)
                {
                    DateTime dttm1 = Convert.ToDateTime(dttbl.Rows[dttbl.Rows.Count - 1]["DTTM"]);

                    dttm = dttm1.ToString("yyyy-MM-dd HH:mm:ss");
                }

                SqlCommand cmd1 = new SqlCommand("select * from MINT_PreBatch where BTCH_NO=@BatchNo and PRODUCT_NAME=@ProdName and VES_NAME = @vesselNo and dttm = @dttm order by SN asc", con);
                cmd1.Parameters.AddWithValue("@BatchNo", BatchNo);
                cmd1.Parameters.AddWithValue("@ProdName", ProductCode);
                cmd1.Parameters.AddWithValue("@vesselNo", vesselNo);
                cmd1.Parameters.AddWithValue("@dttm", dttm);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(dt);

            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    #endregion

    #region Not Used

    public DataTable getConfigData()
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select * from MINT_BlenderName", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable getBatchData(string FamilyName)
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        string ViewName = "";
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select ViewName from MINT_BlenderName order by RowId asc", con);
                cmd1.ExecuteNonQuery();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(dt1);

                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    ViewName = dt1.Rows[i]["ViewName"].ToString();

                    SqlCommand cmd = new SqlCommand("select distinct BTCH_NO from " + ViewName + " where FAMILY='" + FamilyName + "'", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    sda.Fill(dt);
                }

            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    #endregion

    public DataAccessLayer()
    {

        //
        // TODO: Add constructor logic here
        //

    }

    #region Database connection string

    //static private string GetConnectionString()
    //{
    //    // To avoid storing the connection string in your code, 
    //    // you can retrieve it from a configuration file.

    //    string connectionString = "Data Source=192.168.2.211,49152;Initial Catalog=MintFDI;User ID=sa;Password=l0GIC0N";

    //    return connectionString;
    //}

    #endregion

    #region Product Code report

    public DataTable getProductCode()
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select PROD_CODE from PROD_CODE", con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable getProductCodeData(string ProdCode, string StrtDate, string EndDate)
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from PROD_CODE where PROD_CODE=@ProdCode and STRT_DTTM=@StrtDT and END_DTTM=@EndDT", con);
                cmd.Parameters.AddWithValue("@ProdCode", ProdCode);
                cmd.Parameters.AddWithValue("@StrtDT", StrtDate);
                cmd.Parameters.AddWithValue("@EndDT", EndDate);
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    #endregion

    #region PeriodicReport

    public DataTable GetPeriodicData(string StartDate, string EndDate)
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from PROD_CODE where STRT_DTTM=@StrtDT and END_DTTM=@EndDT", con);
                cmd.Parameters.AddWithValue("@StrtDT", StartDate);
                cmd.Parameters.AddWithValue("@EndDT", EndDate);
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    #endregion

    //public DataTable getFamilyData(string FamilyName)
    //{
    //    DataTable dt = new DataTable();
    //    DataTable dt1 = new DataTable();
    //    string ViewName = "";
    //    using (con = new SqlConnection(strcon))
    //    {
    //        try
    //        {
    //            con.Open();
    //            SqlCommand cmd1 = new SqlCommand("select ViewName from MINT_FamilyList order by RowId asc", con);
    //            cmd1.ExecuteNonQuery();
    //            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
    //            sda1.Fill(dt1);

    //            for (int i = 0; i < dt1.Rows.Count; i++)
    //            {
    //                ViewName = dt1.Rows[i]["ViewName"].ToString();

    //                SqlCommand cmd = new SqlCommand("select distinct BTCH_NO from " + ViewName + " where FAMILY='" + FamilyName + "' order by BTCH_NO asc ", con);
    //                SqlDataAdapter sda = new SqlDataAdapter(cmd);

    //                sda.Fill(dt);
    //            }

    //        }
    //        catch (Exception ex)
    //        {
    //            this.LogError(ex);
    //        }
    //        finally
    //        {
    //            con.Close();
    //            SqlConnection.ClearPool(con);
    //        }
    //    }
    //    return dt;
    //}
    
    #region Daily Blending Report

    public DataTable getDailyBlendingData(string blendername, string tDate)
    {
        DataTable dt = new DataTable();
        try
        {
            using (con = new SqlConnection(strcon))
            {

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlCommand cmd = new SqlCommand("select BlenderNo, ProductCode, ProductDescription, BatchNo, BatchSizePVKL, QCTime, DischargeTime, StopDurationMins as StoppageTimeMins from MINT_BatchSummary where tDate = @a and BlenderNo = @b", con);
                cmd.Parameters.AddWithValue("@a", tDate);
                cmd.Parameters.AddWithValue("@b", blendername);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
                con.Close();
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
            SqlConnection.ClearPool(con);
        }
        return dt;
    }

    #endregion

    #region Cumulative Blending Report

    public DataTable getCumulativeBlendingData(string sDate, string eDate)
    {
        DataTable dt = new DataTable();

        try
        {
            using (con = new SqlConnection(strcon))
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlCommand cmd = new SqlCommand("select BlenderNo, tDate, count(BatchNo) as BatchCount, sum(BatchSizePVKL) as VolumeBlended from MINT_BatchSummary where (tDate between @a and @b) group by tDate, BlenderNo order by BlenderNo asc", con);
                cmd.Parameters.AddWithValue("@a", sDate);
                cmd.Parameters.AddWithValue("@b", eDate);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);

                adap.Fill(dt);

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

    #endregion

    #region OEE Report

    public DataTable getOEE(string sdate, string edate, string blendername)
    {
        DataTable dt = new DataTable();
        DataTable dtFamily = new DataTable();

        string BlenderName = "";
        string BatchNo = "";
        string TableName = "";

        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT ProductCode,sum(StandardBCTMins) as StdBCT,(sum(ActiveDurationMins) + sum(StopDurationMins)) as ActBCT,EmergStopTimeMins FROM MINT_BatchSummary where (tDate between @a and @b) and BlenderNo=@blenderName group by ProductCode,EmergStopTimeMins", con);
                cmd.Parameters.AddWithValue("@a", sdate);
                cmd.Parameters.AddWithValue("@b", edate);
                cmd.Parameters.AddWithValue("@blenderName", blendername);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);

                //DataColumn dcFamily = new DataColumn("Family");
                //dt.Columns.Add(dcFamily);

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    BatchNo = dt.Rows[i]["BatchNo"].ToString();

                //    SqlCommand cmd1 = new SqlCommand("Select TableName from MINT_BlenderName where BlenderName=@blenderName", con);
                //    cmd1.Parameters.AddWithValue("@blenderName", blendername);
                //    DataTable dtTbl = new DataTable();
                //    SqlDataAdapter sdaTbl = new SqlDataAdapter(cmd1);
                //    sdaTbl.Fill(dtTbl);

                //    TableName = dtTbl.Rows[0]["TableName"].ToString();
                //    SqlCommand cmdFamily = new SqlCommand("Select FAMILY from " + TableName + " where BTCH_NO='" + BatchNo + "'", con);
                //    SqlDataAdapter sdaFamily = new SqlDataAdapter(cmdFamily);
                //    dtFamily.Clear();
                //    sdaFamily.Fill(dtFamily);

                //    string family = dtFamily.Rows[i]["FAMILY"].ToString();
                //    dt.Rows[i]["Family"] = family;

                //}

                //dtAll.Merge(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
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
            SqlConnection conAlarms;

            sdate = sdate + " " + "00:00:00";
            edate = edate + " " + "23:59:59";

            string strcon2 = ConfigurationManager.ConnectionStrings["dbAlarms"].ConnectionString;
            using (conAlarms = new SqlConnection(strcon2))
            {
                conAlarms.Open();
                SqlCommand cmd = new SqlCommand("select * from v_AlarmEventHistory where ((EventStamp between @a and @b) and (AlarmState != 'ACK_RTN  '))", conAlarms);
                cmd.Parameters.AddWithValue("@a", sdate);
                cmd.Parameters.AddWithValue("@b", edate);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);

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

    #endregion

    #region DDU Work Time Data

    public DataTable getDDUWorkTimeData(string sdate, string edate, string ddu, string blenderName)
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();

        //DataColumn dcTheorThroughput = new DataColumn("Theoratical_Throughput", typeof(System.Double));
        //dt.Columns.Add(dcTheorThroughput);

        sdate = sdate + " " + "00:00:00";
        edate = edate + " " + "00:00:00";

        string ViewName = "";
        //double Theoratical_Throughput = 0.0;

        string whereParam = "";
        string whereParam1 = "";
        if (blenderName == "Select All")
        {
            DataTable dtBlender = new DataTable();

            dtBlender = getBlenderDataDDU(ddu);

            for (int i = 0; i < dtBlender.Rows.Count; i++)
            {

                if (whereParam == "")
                {
                    whereParam = "(BlenderName='" + dtBlender.Rows[i]["BlenderName"].ToString() + "')";
                    whereParam1 = "(VES_NAME='" + dtBlender.Rows[i]["BlenderName"].ToString() + "')";

                }
                else
                {
                    whereParam = whereParam + " OR " + "(BlenderName='" + dtBlender.Rows[i]["BlenderName"].ToString() + "')";
                    whereParam1 = whereParam1 + " OR " + "(VES_NAME='" + dtBlender.Rows[i]["BlenderName"].ToString() + "')";
                }

            }
        }
        else
        {
            whereParam = "BlenderName='"+ blenderName +"'";
            whereParam1 = "VES_NAME='" + blenderName + "'";
        }

        using (con = new SqlConnection(strcon))
        {
            try
            {
             
                con.Open();

                if (ddu != "Select DDU")
                {
                    
                    SqlCommand cmd1 = new SqlCommand("select Distinct ViewName from Mint_DDS where DDSNo = @ddsno and ("+ whereParam +")", con);
                    cmd1.Parameters.AddWithValue("@ddsno", ddu);
                    cmd1.Parameters.AddWithValue("@b", blenderName);
                    cmd1.ExecuteNonQuery();
                    SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                    sda1.Fill(dt1);
                }

                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        //ViewName = dt1.Rows[i]["DDSTableName"].ToString();
                        ViewName = dt1.Rows[i]["ViewName"].ToString();
                        //Theoratical_Throughput = Convert.ToDouble(dt1.Rows[i]["Theoratical_Throughput"]);

                        if (blenderName != "Select Blender Name")
                        {
                            SqlCommand cmd = new SqlCommand("SELECT * FROM " + ViewName + " where (tDate between @a and @b) and DDS=@ddu and (" + whereParam1 + ")", con);
                            cmd.Parameters.AddWithValue("@a", sdate);
                            cmd.Parameters.AddWithValue("@b", edate);
                            cmd.Parameters.AddWithValue("@blenderName", blenderName);
                            cmd.Parameters.AddWithValue("@ddu", ddu);
                            SqlDataAdapter adap = new SqlDataAdapter(cmd);
                            adap.Fill(dt);
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("SELECT * FROM " + ViewName + " where (tDate between @a and @b) and DDS=@ddu or (" + whereParam1 + ")", con);
                            cmd.Parameters.AddWithValue("@a", sdate);
                            cmd.Parameters.AddWithValue("@b", edate);
                            cmd.Parameters.AddWithValue("@blenderName", blenderName);
                            cmd.Parameters.AddWithValue("@ddu", ddu);
                            SqlDataAdapter adap = new SqlDataAdapter(cmd);
                            adap.Fill(dt);
                        }
                    }
                }
                //else
                //{
                //    if (blenderName != "Select Blender Name")
                //    {
                //        SqlCommand cmd = new SqlCommand("SELECT * FROM MINT_ALL_DDU where (tDate between @a and @b) and VES_NAME=@blenderName", con);
                //        cmd.Parameters.AddWithValue("@a", sdate);
                //        cmd.Parameters.AddWithValue("@b", edate);
                //        cmd.Parameters.AddWithValue("@blenderName", blenderName);
                //        SqlDataAdapter adap = new SqlDataAdapter(cmd);
                //        adap.Fill(dt);
                //    }
                //    else
                //    {
                //        SqlCommand cmd = new SqlCommand("SELECT * FROM MINT_ALL_DDU where (tDate between @a and @b) or VES_NAME=@blenderName", con);
                //        cmd.Parameters.AddWithValue("@a", sdate);
                //        cmd.Parameters.AddWithValue("@b", edate);
                //        cmd.Parameters.AddWithValue("@blenderName", blenderName);
                //        SqlDataAdapter adap = new SqlDataAdapter(cmd);
                //        adap.Fill(dt);
                //    }
                //}

                //dt.Rows[0]["Theoratical_Throughput"] = Theoratical_Throughput;

            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }

        return dt;
    }

    public DataTable getDDUName()
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select distinct DDSName, DDSNo from Mint_DDS order by DDSName asc", con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }

        return dt;
    }

    public DataTable getBlenderDataDDU(string dduName)
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select BlenderName from Mint_DDS where DDSNo = @a order by BlenderName asc", con);
                cmd.Parameters.AddWithValue("@a", dduName);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }

        return dt;
    }

    #endregion

    #region Pigging Report Data

    public string getPigTable(string SelectedArea)
    {
        string TableName = "";

        DataTable dt = new DataTable();

        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select ViewName from Mint_PigTables where Section='" + SelectedArea + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    TableName = dt.Rows[0]["ViewName"].ToString();
                }
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return TableName;
    }

    public DataTable getPigData(string FromDate, string ToDate, string ViewName, string SelectedArea)
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select * from " + ViewName + " where DTTM between '" + FromDate + "' and '" + ToDate + "' ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }


    #endregion

    #region
    public DataTable getDosingData(string FromDate, string ToDate, string ViewName)
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select * from " + ViewName + " where DTTM between '" + FromDate + "' and '" + ToDate + "' ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
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
        string path = System.Web.HttpContext.Current.Server.MapPath("~/Logs/DataLayerErrorLog.txt");
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine(message);
            writer.Close();
        }
    }

    #endregion

    public DataTable getRMCodeData()
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select distinct PRODUCT from BO_LIST", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable getRMConsDataFilter(string fdtm, string tdtm, string Condition, string FilterBy)
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                if (FilterBy == "RMWise")
                {
                    //SqlCommand cmd = new SqlCommand("select RMCode,TankDescription, CMNDName, sum(Consumption) as Consumption,  from MINT_vConsumption where ((Consumption != 0) and (tDate between '2018-12-15 15:08:53.000' and '2019-01-22 16:58:58.000')) group by RMCode, CMNDName,TankDescription order by RMCode asc", con);
                    SqlCommand cmd = new SqlCommand("select RMCode,BtahcNumber,BlenderName,TankDescription, CMNDName, sum(Consumption) as Consumption,tDate from MINT_vConsumption where (RMCode = '" + Condition + "') and (Consumption != 0) and (tDate between '" + fdtm + "' and '" + tdtm + "') group by RMCode, CMNDName,TankDescription,BtahcNumber,BlenderName,tDate order by tDate asc", con);

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    sda.Fill(dt);
                }
                else if (FilterBy == "TankWise")
                {
                   // SqlCommand cmd = new SqlCommand("select RMCode,BtahcNumber,BlenderName,TankDescription, CMNDName, sum(Consumption) as Consumption,tDate from MINT_vConsumption where (TankDescription = '" + Condition + "') and (Consumption != 0) and (tDate between '" + fdtm + "' and '" + tdtm + "') group by RMCode, CMNDName,TankDescription,BtahcNumber,BlenderName,tDate order by tDate asc", con);
                    SqlCommand cmd = new SqlCommand(" select RMCode,BlenderName,TankDescription, CMNDName, sum(Consumption) as Consumption from MINT_vConsumption where " +
                                                 " TankDescription in (" + Condition + ") and (Consumption != 0) and (tDate between '" + fdtm + "' and '" + tdtm + "') " +
                                                 " group by RMCode, CMNDName,TankDescription,BlenderName ", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    sda.Fill(dt);
                }
                else if (FilterBy == "BlenderWise")
                {
                    SqlCommand cmd = new SqlCommand("select RMCode,BtahcNumber,BlenderName,TankDescription, CMNDName, sum(Consumption) as Consumption,tDate from MINT_vConsumption where (BlenderName = '" + Condition + "') and (Consumption != 0) and (tDate between '" + fdtm + "' and '" + tdtm + "') group by RMCode, CMNDName,TankDescription,BtahcNumber,BlenderName,tDate order by tDate asc", con);

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    sda.Fill(dt);
                }
                else if (FilterBy == "ProductWise")
                {
                    SqlCommand cmd = new SqlCommand("select RMCode,BtahcNumber,BlenderName,TankDescription, CMNDName, sum(Consumption) as Consumption,tDate from MINT_vConsumption where (RMCode = '" + Condition + "') and (Consumption != 0) and (tDate between '" + fdtm + "' and '" + tdtm + "') group by RMCode, CMNDName,TankDescription,BtahcNumber,BlenderName,tDate order by tDate asc", con);

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    sda.Fill(dt);
                }
               
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }

    public DataTable getTankData()
    {
        DataTable dt = new DataTable();
        using (con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select distinct TankDescription from MINT_RMSourceTankDesc", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }
        return dt;
    }
}