using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.IO;
using System.Text;
using System.Drawing.Imaging;
using System.Reflection;
using System.Drawing.Printing;
using System.Drawing;

public partial class Presentation_StandardReports_Default2 : System.Web.UI.Page
{

    string BatchNo="";
    string blender_Name = "";
    string ProductCode = "";
    //private int m_currentPageIndex;
    //private IList<Stream> m_streams;
    DataTable dataset;

    BusinessAccessLayer BAL = new BusinessAccessLayer();
    DataAccessLayer DAL = new DataAccessLayer();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            GetData();

            //GetBatchNoData();
        }
    }

    private void GetBatchNoData()
    {
        try
        {
            DataTable dt = new DataTable();

            string equipmentNo = ddl_Vessel.Text;

            dt = BAL.getBatchNo(equipmentNo);
            ddl_BatchNo.DataSource = dt;

            ddl_BatchNo.DataTextField = "BTCH_NO";
            ddl_BatchNo.DataValueField = "BTCH_NO";

            ddl_BatchNo.DataBind();

            ddl_BatchNo.Items.Insert(0, "Select Batch No");

        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    protected void ddl_BatchNo_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            BatchNo = ddl_BatchNo.SelectedValue;
            DataTable dt = new DataTable();
            dt = BAL.getProductData(BatchNo);

            ddl_ProdCode.DataSource = dt;

            ddl_ProdCode.DataTextField = "PRODUCT_NAME";
            ddl_ProdCode.DataValueField = "PRODUCT_NAME";

            ddl_ProdCode.DataBind();

            ddl_ProdCode.Items.Insert(0, "Select Product");
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        BatchNo = ddl_BatchNo.SelectedValue;
        ProductCode = ddl_ProdCode.SelectedValue;
        string vesselNo = ddl_Vessel.Text;
        try
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = "Presentation/Reports/BatchReports/PreBatchReport.rdlc";

            dataset = new DataTable();
            dataset = BAL.getPreBatchData(BatchNo, ProductCode, vesselNo);

            for (int i = 0; i < dataset.Rows.Count; i++)
            {
                string ingredent = Convert.ToString(dataset.Rows[i]["INGRDNT"]);

                if (ingredent == "NIL")
                {
                    dataset.Rows[i]["INGRDNT"] = "";
                    dataset.Rows[i]["RM_DESC"] = "";
                    dataset.Rows[i]["PRECAUTION"] = "";
                }

                //Comments Added By Chhotumal

                else if (ingredent != "NIL")
                {
                    string command = Convert.ToString(dataset.Rows[i]["CMND"]);
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
                        dataset.Rows[i]["RM_DESC"] = rmDesc;
                        dataset.Rows[i]["PRECAUTION"] = rmPrecaution;
                    }
                }
            }
            for (int i = 0; i < dataset.Rows.Count; i++)
            {
                if (i != 0)
                {
                    int SNPre = Convert.ToInt32(dataset.Rows[i - 1]["SN"]);

                    int SN = Convert.ToInt32(dataset.Rows[i]["SN"]);

                    if (SNPre == SN)
                    {
                        DataRow dr = dataset.Rows[i];

                        dr.Delete();
                        dataset.AcceptChanges();
                    }
                }
            }

            string familyVal = Convert.ToString(dataset.Rows[0]["Family"]);

            if ((familyVal == "F-6H") || (familyVal == "F-6M") || (familyVal == "F-6O"))
            {
                for (int i = 0; i < dataset.Rows.Count; i++)
                {
                    string CMND = Convert.ToString(dataset.Rows[i]["CMND"]);

                    if (CMND == "15")
                    {

                        int SP1 = Convert.ToInt32(dataset.Rows[i]["SP1"]);
                        string unit = "";
                        if (SP1 <= 20)
                        {
                            unit = "Mins";
                        }
                        else if (SP1 > 20)
                        {
                            unit = "Deg C";
                        }

                        dataset.Rows[i]["CMNDUnitSP1"] = unit;
                        dataset.Rows[i]["CMNDUnitSP2"] = unit;
                    }
                }
            }


            string str_Vsl_name = Convert.ToString(dataset.Rows[0]["VES_NAME"]);

            #region BlenderName

            string BlenderName = "";

            if (str_Vsl_name == "1")
            {
                BlenderName = "V101";
            }
            else if (str_Vsl_name == "2")
            {
                BlenderName = "V102";
            }
            else if (str_Vsl_name == "3")
            {
                BlenderName = "V103";
            }
            else if (str_Vsl_name == "4")
            {
                BlenderName = "V301";
            }
            else if (str_Vsl_name == "5")
            {
                BlenderName = "V302";
            }
            else if (str_Vsl_name == "6")
            {
                BlenderName = "V401";
            }
            else if (str_Vsl_name == "7")
            {
                BlenderName = "V501";
            }
            else if (str_Vsl_name == "8")
            {
                BlenderName = "V502";
            }
            else if (str_Vsl_name == "9")
            {
                BlenderName = "V503";
            }
            else if (str_Vsl_name == "10")
            {
                BlenderName = "V504";
            }
            else if (str_Vsl_name == "11")
            {
                BlenderName = "V601";
            }
            else if (str_Vsl_name == "12")
            {
                BlenderName = "V602";
            }
            else if (str_Vsl_name == "13")
            {
                BlenderName = "V701";
            }
            else if (str_Vsl_name == "14")
            {
                BlenderName = "V702";
            }
            else if (str_Vsl_name == "15")
            {
                BlenderName = "V703";
            }
            else if (str_Vsl_name == "16")
            {
                BlenderName = "V801";
            }
            else if (str_Vsl_name == "17")
            {
                BlenderName = "V802";
            }
            else if (str_Vsl_name == "18")
            {
                BlenderName = "V901";
            }
            else if (str_Vsl_name == "19")
            {
                BlenderName = "V902";
            }
            else if (str_Vsl_name == "20")
            {
                BlenderName = "V2401";
            }

            #endregion


            DataColumn dcBlenderName = new DataColumn("BlenderName", typeof(string));
            dcBlenderName.DefaultValue = BlenderName.ToString();
            dataset.Columns.Add(dcBlenderName);

            string Family = Convert.ToString(dataset.Rows[0]["FAMILY"]);
            string BTCH_SIZE_SP = Convert.ToString(dataset.Rows[0]["BTCH_SIZE_SP"]);
            string BTCH_SIZE_PV = Convert.ToString(dataset.Rows[0]["BTCH_SIZE_PV"]);
            string RECEIPE_NO = Convert.ToString(dataset.Rows[0]["RECEIPE_NO"]);
            string PRODUCT_NAME = Convert.ToString(dataset.Rows[0]["PRODUCT_NAME"]);
            string PRODUCT_DESC = Convert.ToString(dataset.Rows[0]["PRODUCT_DESC"]);
            string FORMULA_NO = Convert.ToString(dataset.Rows[0]["FORMULA_NO"]);
            string BTCH_NO = Convert.ToString(dataset.Rows[0]["BTCH_NO"]);
            string TotalSteps = Convert.ToString(dataset.Rows[0]["TOT_STEPS"]);
            //string BlendTime = Convert.ToString(dataset.Rows[0]["BlendTime"]);
            //string SuspendTime = Convert.ToString(dataset.Rows[0]["SuspendTime"]);
            //string BatchTime = Convert.ToString(dataset.Rows[0]["BatchTime"]);
            string BatchStartDTTM = Convert.ToString(dataset.Rows[0]["StartDateTime"]);
            //string BatchEndDTTM = Convert.ToString(dataset.Rows[0]["BatchEndDTTM"]);
            string OPER_NAME = Convert.ToString(dataset.Rows[0]["OPER_NAME"]);

            string TYPE = Convert.ToString(dataset.Rows[0]["TypeDesc"]);

            ReportDataSource datasource = new ReportDataSource("PreBatch", dataset);
            ReportViewer1.LocalReport.EnableHyperlinks = true;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.Refresh();

            ReportParameter[] param = new ReportParameter[13];
            param[0] = new ReportParameter("BlenderNo", BlenderName);
            param[1] = new ReportParameter("BatchNo", BTCH_NO);
            param[2] = new ReportParameter("ReqQuantity", BTCH_SIZE_SP);
            param[3] = new ReportParameter("producedQuantity", BTCH_SIZE_PV);
            param[4] = new ReportParameter("RecipeNo", RECEIPE_NO);
            param[5] = new ReportParameter("productCode", PRODUCT_NAME);
            param[6] = new ReportParameter("productDesc", PRODUCT_DESC);
            param[7] = new ReportParameter("formulaNo", FORMULA_NO);
            param[8] = new ReportParameter("type", TYPE);
            param[9] = new ReportParameter("family", Family);
            param[10] = new ReportParameter("totalSteps", TotalSteps);
            param[11] = new ReportParameter("strtDttm", BatchStartDTTM);
            param[12] = new ReportParameter("operatorName", OPER_NAME);
            //param[11] = new ReportParameter("blendTime", BlendTime);
            //param[12] = new ReportParameter("SusTime", SuspendTime);
            //param[13] = new ReportParameter("batchTime", BatchTime);

            //param[15] = new ReportParameter("endDttm", BatchEndDTTM);
            //param[16] = new ReportParameter("destination", "");



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

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        LocalReport report = new LocalReport();
        report.ReportPath = "Presentation/Reports/BatchReports/PreBatchReport.rdlc";
        btn_Submit_Click(new object(), new EventArgs());
        report.DataSources.Add(new ReportDataSource("PreBatch", dataset));
        PrintReport.Export(report);
    }

    public static class PrintReport
    {

        private static int m_currentPageIndex;
        private static IList<Stream> m_streams;

        public static Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        public static void Export(LocalReport report, bool print = true)
        {
            try
            {
                string deviceInfo =
                  @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>16.5in</PageWidth>
                <PageHeight>10in</PageHeight>
                <MarginTop>0.25in</MarginTop>
                <MarginLeft>0.5in</MarginLeft>
                <MarginRight>0.5in</MarginRight>
                <MarginBottom>0.25in</MarginBottom>
                </DeviceInfo>";
                Warning[] warnings;
                m_streams = new List<Stream>();
                report.Render("Image", deviceInfo, CreateStream,
                   out warnings);
                foreach (Stream stream in m_streams)
                    stream.Position = 0;

                if (print)
                {
                    Print();
                }
            }
            catch (Exception ex)
            {

            }
        }

        // Handler for PrintPageEvents
        public static void PrintPage(object sender, PrintPageEventArgs ev)
        {
            try
            {
                Metafile pageImage = new
                   Metafile(m_streams[m_currentPageIndex]);

                // Adjust rectangular area with printer margins.
                Rectangle adjustedRect = new Rectangle(
                    ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                    ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                    ev.PageBounds.Width,
                    ev.PageBounds.Height);

                // Draw a white background for the report
                ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

                // Draw the report content
                ev.Graphics.DrawImage(pageImage, adjustedRect);

                // Prepare for the next page. Make sure we haven't hit the end.
                m_currentPageIndex++;
                ev.HasMorePages = (m_currentPageIndex < m_streams.Count);

            }
            catch (Exception ex)
            {

            }
        }

        public static void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();

            //string PrinterName = System.Configuration.ConfigurationManager.AppSettings["PrinterName"];
            //printDoc.PrinterSettings.PrinterName = PrinterName;
            //printDoc.PrinterSettings.PrinterName = "HP LaserJet M203-M206 PCL 6"; //change it after printer name change

            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.DefaultPageSettings.Landscape = true;
                printDoc.Print();
            }
        }

        //public static void PrintToPrinter(this LocalReport report)
        //{
        //    Export(report);
        //}

        public static void DisposePrint()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }
    }

    protected void ddl_Vessel_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetBatchNoData();
    }

    private void GetData()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = BAL.getBlenderData();

            ddl_Vessel.DataSource = dt;

            ddl_Vessel.DataTextField = "BlenderName";
            ddl_Vessel.DataValueField = "EquipmentNumber";

            ddl_Vessel.DataBind();

            ddl_Vessel.Items.Insert(0, "Select Blender Name");
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }


}