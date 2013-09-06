using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Printing;

using System.Data.OleDb;
using ADOX;

using System.IO;

using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

using BrightIdeasSoftware;

using System.Drawing.Imaging;

namespace UEMScreen
{
    public partial class EGLogDataScreen : IronPanel.InformationPanel
    {       
        string CusFormatStr = "yyyy-MM";

        enum Period_Unit 
        {
            일간,
            주간,
            월간,
            연간,
            기간 // 특정 일자와 일자 사이의 데이타
        }

        private Period_Unit _selectedPeriodUnit;

        enum Row_SumUnit
        {
            분단위,
            시단위,
            일단위,
            월단위,
            연단위
        }

        private Row_SumUnit _selectedRowSumUnit;

        PrintDocument printDoc = new PrintDocument();
            
        public EGLogDataScreen()
        {
            InitializeComponent();

            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            printDoc.DefaultPageSettings.Landscape = true;
        }

        public override void StartPanel(string name)
        {
            try
            {
                ironSANClient1.ProjectPath = this.ProjectPath;
                ironSANClient1.Connect();
            }
            catch (Exception)
            {
            }
        }

        public override void StopPanel()
        {
            ironSANClient1.Disconnect();
        }

        // alarm 구현
        private void CallBack_DigitalOnChange(int id, object[] value)
        {
            try
            {
                bool data = (bool)value[0];

                if (data)
                {
                    FireAlarm(1000, false);
                }
            }
            catch
            {
            }
        }

        #region Notification when my form is fully loaded

        private bool isLoaded = false;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            this.isLoaded = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.isLoaded) this.OnLoadComplete(e);
        }

        protected virtual void OnLoadComplete(EventArgs e)
        {
        }

        //-----other case
        private void LogDataScreen_Load(Object sender, EventArgs e)
        {
            this.GotFocus += new EventHandler(LogDataScreen_GotFocus);
            //this.Focus();

            this._selectedPeriodUnit = Period_Unit.월간;
            this._selectedRowSumUnit = Row_SumUnit.일단위;

            DataTable dt = Get_Data();


            selListViewC1.ListViewItem(dt, "EGLog_Config_LV.xml", this.ProjectPath);
            selGraphViewC1.GraphViewItem(dt, "EGLog_Config.xml", this.ProjectPath); 

            this.UpdatePrintPreview(null, null);
            if (selGraphViewC1.Visible) bt_to_trend.PerformClick();
        }

        private void LogDataScreen_GotFocus(object sender, EventArgs e)
        {

            // Default 검색조건설정
            rB_month.Checked = true; // 기본보고서는 월간
            rB_row_unit_min.Checked = false;
            dTP_search_start.Format = DateTimePickerFormat.Custom;
            dTP_search_start.CustomFormat  = "yyyy-MM";
            dTP_search_start.Enabled = true;
            dTP_search_end.Format = DateTimePickerFormat.Custom;
            dTP_search_end.CustomFormat = "yyyy-MM";
            dTP_search_end.Enabled = false;


            rB_row_unit_day.Checked = true; // 기본보고서의 데이타 단위는 일간

            radioButton2.Checked = true; // 프린터의 defualt는 100%로 
        }

        #endregion

        private void button_print_Click(object sender, EventArgs e)
        {
            PrintDocument docToPrint = new PrintDocument();
            PageSettings ps = new PageSettings();

            ps.Margins = new Margins(10, 10, 10, 10);

            docToPrint.DefaultPageSettings = ps;

            PrintPreviewDialog pd = new PrintPreviewDialog();

            pd.ClientSize = new Size(500, 500);
            pd.UseAntiAlias = true;

            //docToPrint.PrintPage += new PrintPageEventHandler(doc_PrintPage);
            docToPrint.PrintPage += new PrintPageEventHandler(docToPrint_PrintPage);
            pd.Document = docToPrint;
            pd.ShowDialog();
        }

        System.Drawing.Font printFont = new System.Drawing.Font("Arial", 18);

        void docToPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            //dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            //e.Graphics.DrawImage(bm, 0, 125);

            //PaintEventArgs myPaintArgs = new PaintEventArgs(e.Graphics, new Rectangle(new Point(0, 0), this.Size));
            //this.InvokePaint(dataGridView1, myPaintArgs);

            //Image img = Image.FromFile(".\\test.png");
            //Image img = Image.FromFile(ProjectPath + "\\image\\print-image.png"); //"\\test1.png");
            //e.Graphics.DrawImage(img, 0, 0, 375, 118);     // 이미지를 표시할 위치

            float yPos = 0f;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;
            float linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);

            line = "[ 기간별 생산현황 ]"; //"sssss";

            yPos = topMargin + count * printFont.GetHeight(e.Graphics);
            leftMargin = 300;
            yPos = 50;

            e.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());

            System.Drawing.Font subFont = new System.Drawing.Font("Arial", 10);
            switch (_selectedPeriodUnit.ToString().Trim())
            {
                case "일간":
                    line = "[ 기간 : " + dTP_search_start.Value.ToString("yyyy-MM-dd") + " - " + dTP_search_end.Value.ToString("yyyy-MM-dd") + " ]";
                    break;
                case "월간":
                    line = "[ 기간 : " + dTP_search_start.Value.ToString("yyyy-MM") + " - " + dTP_search_end.Value.ToString("yyyy-MM") + " ]";
                    break;
                case "연간":
                    line = "[ 기간 : " + dTP_search_start.Value.ToString("yyyy") + " - " + dTP_search_end.Value.ToString("yyyy") + " ]";
                    break;
                case "기간":
                    line = "[ 기간 : " + dTP_search_start.Value.ToString("yyyy-MM-dd") + " - " + dTP_search_end.Value.ToString("yyyy-MM-dd") + " ]";
                    break;
                default:
                    line = "[ 기간 : " + dTP_search_start.Value.ToString("yyyy-MM-dd") + " - " + dTP_search_end.Value.ToString("yyyy-MM-dd") + " ]";
                    break;
            }
            leftMargin = 600;
            yPos = 100;

            e.Graphics.DrawString(line, subFont, Brushes.Black, leftMargin, yPos, new StringFormat());
        }

        int PageNo = 0;
        int pageStartRow = 0;
        int endRow = 50;



        void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            int nBotton = e.PageBounds.Bottom - 30;
            Graphics g = e.Graphics;
            Font PF = new Font("굴림", 11);
            int line = 0;
            for (int nRow = pageStartRow; nRow < endRow; nRow++)
            {
                line++;
                int y = line * 30;
                g.DrawString(nRow.ToString(), PF, Brushes.Black, 100, y);
                if (y > (nBotton - 50))
                {
                    pageStartRow = nRow + 1;
                    e.HasMorePages = true;
                    DrawFooter(e.Graphics, nBotton);
                    return;
                }
                else
                {
                    e.HasMorePages = false;
                }
            }
            DrawFooter(e.Graphics, nBotton);
        }

        private void DrawFooter(Graphics g, int nBottom)
        {
            Font PF = new Font("굴림", 20);

            PageNo++;
            string sPageNo = PageNo.ToString() + "Page ";
            g.DrawLine(Pens.Red, 100, nBottom, 700, nBottom);
            g.DrawString(sPageNo, PF, Brushes.Black, 300, nBottom);
        }

        OleDbConnection connection;
        //public DataSet CreateCmdsAndUpdate(DataSet dataSet, string connectionString, string queryString, string tableName)
        public DataSet CreateCmdsAndUpdate(string connectionString, string queryString, string tableName)
        {
            try
            {
                //using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (connection = new OleDbConnection(connectionString))
                {

                    OleDbDataAdapter adapter = new OleDbDataAdapter();

                    adapter.SelectCommand = new OleDbCommand(queryString, connection);

                    OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);

                    connection.Open();

                    DataSet customers = new DataSet();

                    adapter.Fill(customers, tableName); //code to modify data in dataset here

                    //adapter.Update(customers, tableName);

                    return customers;

                }
            }
            catch (Exception)
            {
                DataSet customers = new DataSet();
                return customers;
            }
        }

        #region Printer 관련 : 원시코드로 그리는 방법
        // 회사 CI 넣기 
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //Bitmap myImage = global::UEMScreen.Properties.Resources.UBI;

            //if (e.RowIndex < 0 && e.ColumnIndex < 0)
            //{
            //    e.Graphics.DrawImage(myImage, e.CellBounds);
            //    e.Handled = true;
            //}
        }

        private DataTable Get_Data()
        {
            DataTable dt =  new DataTable();
            try
            {
                string db_pathrootname;
                string db_filename_Header = "DATALOG-EEMS-M1";
                string fullFilename;
                string tablename;

                string str_startDT;   // 검색조건에 따라 시작일정의 포맷을 변경
                string str_endDT;     // 검색조건에 따라 종료일정의 포멧을 변경
                string str_where_format;
                string str_group_format;

                DateTime ndt = DateTime.Now;


                string strQuery;              

                db_pathrootname = ironSANClient1.ReadAny("SO.EEMS-R1.Path_Log").ToString().Trim();
            
                fullFilename = db_pathrootname + "\\" + ndt.ToString("yyyy") + "\\" + db_filename_Header + "-" + ndt.ToString("yyyy") + "-" + ndt.ToString("MM") + ".mdb";

               
                // 검색기간 단위위에 따라 포멧 변경하기
                switch (_selectedPeriodUnit.ToString().Trim())
                {
                    case "일간":
                        str_startDT = dTP_search_start.Value.ToString("yyyy-MM-dd");
                        str_where_format = "  WHERE Format(시스템시간,'yyyy-MM-dd') = '" + str_startDT + "'";
                        break;
                    case "월간":
                        str_startDT = dTP_search_start.Value.ToString("yyyy-MM");
                        str_where_format = " WHERE Format(시스템시간,'yyyy-MM') = '" + str_startDT + "'";
                        break;
                    case "연간":
                        str_startDT = dTP_search_start.Value.ToString("yyyy");
                        str_where_format = " WHERE Format(시스템시간,'yyyy') = '" + str_startDT + "'";
                        break;
                    case "기간":
                        str_startDT = dTP_search_start.Value.ToString("yyyy-MM-dd 00:00");
                        str_endDT = dTP_search_end.Value.ToString("yyyy-MM-dd 23:59");
                        str_where_format = "  WHERE Format(시스템시간,'yyyy-MM-dd HH:mm') BETWEEN '" + str_startDT + "' AND '" + str_endDT + "' ";
                        break;
                    default:
                        str_startDT = dTP_search_start.Value.ToString("yyyy-MM-dd 00:00");
                        str_endDT = dTP_search_end.Value.ToString("yyyy-MM-dd 23:59");
                        str_where_format = "  WHERE Format(시스템시간,'yyyy-MM-dd HH:mm') BETWEEN '" + str_startDT + "' AND '" + str_endDT + "' ";
                        break;
                }

                //검색 데이타단위에 따라 그룹 포멧 변경하기
                switch (_selectedRowSumUnit.ToString().Trim())
                {
                    case "분단위": str_group_format = "  Format(시스템시간,'yyyy-MM-dd HH:mm') "; break;
                    case "시단위": str_group_format = "  Format(시스템시간,'yyyy-MM-dd HH') "; break;
                    case "일단위": str_group_format = "  Format(시스템시간,'yyyy-MM-dd') "; break;
                    //case "주단위"; str_group_format = "  GROUP BY Format(시스템시간,'yyyy-MM-dd HH:mm') "; break;
                    case "월단위": str_group_format = "  Format(시스템시간,'yyyy-MM') "; break;

                    default: str_group_format = " Format(시스템시간,'yyyy-MM-dd') "; break;
                }

                // GridView에 표시할 데이타 가져오기 
                tablename = "LOG_FULLDATA";
               
                strQuery = " SELECT " + str_group_format + " AS 작업일시, " +
                           " MAX(전력_PLC) AS 전력_PLC, SUM(전력사용량) AS 전력사용량, " +
                           " MAX(가스_PLC) AS 가스_PLC, SUM(가스사용량) AS 가스사용량 " +                          
                           " FROM " + tablename + str_where_format + " GROUP BY " + str_group_format;

                //DataSet ds1 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);
                
                DataSet ds1 = new DataSet();

                if (_selectedPeriodUnit.ToString().Trim() == "일간" || _selectedPeriodUnit.ToString().Trim() == "월간")
                {

                    string MonthFileName = db_pathrootname + "\\" + dTP_search_start.Value.ToString("yyyy") + "\\" + db_filename_Header + "-" + dTP_search_start.Value.ToString("yyyy") + "-" + dTP_search_start.Value.ToString("MM") + ".mdb";
                    ds1 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MonthFileName, strQuery, tablename);
                }
                else
                {
                    DataSet tempds1 = new DataSet();

                    string MonthFileName;
                    DateTime StartDate, EndDate;

                    if (_selectedPeriodUnit.ToString().Trim() == "연간")
                    {
                        StartDate = DateTime.Parse(dTP_search_start.Value.ToString("yyyy") + "-1-1");
                        EndDate = StartDate.AddYears(1).AddDays(-1);
                    }
                    else
                    {
                        StartDate = DateTime.Parse(dTP_search_start.Value.ToString("yyyy-MM") + "-1");
                        EndDate = DateTime.Parse(dTP_search_end.Value.ToString("yyyy-MM") + "-1");
                        EndDate = EndDate.AddMonths(1).AddDays(-1);
                    }

                    ds1.Clear();
                    for (DateTime i = StartDate; i <= EndDate; i = i.AddMonths(1))
                    {
                        MonthFileName = db_pathrootname + "\\" + ndt.ToString("yyyy") + "\\" + db_filename_Header + "-" + i.ToString("yyyy") + "-" + i.ToString("MM") + ".mdb";

                        if (File.Exists(MonthFileName))
                        {
                            tempds1.Clear();

                            tempds1 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MonthFileName, strQuery, tablename);
                            if (ds1.Tables.Count == 0)
                            {
                                if (tempds1.Tables.Count == 0)
                                {
                                    continue;
                                }
                                else
                                {
                                    ds1 = tempds1.Clone();
                                }
                            }
                            ds1.Tables[0].Merge(tempds1.Tables[0]);

                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                //this.dataGridView1.DataSource = ds1.Tables[tablename];

                //int last_row = ds1.Tables[tablename].Rows.Count;    

                //if (last_row > 0)
                //{
                //    DateTime dt_first_row;
                //    DateTime dt_first_row_before;

                //    switch (_selectedRowSumUnit.ToString().Trim())
                //    {
                //        case "분단위":
                //            dt_first_row = Convert.ToDateTime(ds1.Tables[0].Rows[0][0].ToString().Trim());
                //            dt_first_row_before = dt_first_row - TimeSpan.FromMinutes(1);
                //            str_startDT = dt_first_row_before.ToString("yyyy-MM-dd HH:mm"); break;
                //        case "시단위":
                //            dt_first_row = Convert.ToDateTime(ds1.Tables[0].Rows[0][0].ToString().Trim() + ":00");
                //            dt_first_row_before = dt_first_row - TimeSpan.FromHours(1);
                //            str_startDT = dt_first_row_before.ToString("yyyy-MM-dd HH"); break;
                //        case "일단위":
                //            dt_first_row = Convert.ToDateTime(ds1.Tables[0].Rows[0][0].ToString().Trim() + " 00:00");
                //            dt_first_row_before = dt_first_row - TimeSpan.FromDays(1);
                //            str_startDT = dt_first_row_before.ToString("yyyy-MM-dd"); break;
                //        //case "주단위"; 
                //        //dt_first_row = Convert.ToDateTime(ds1.Tables[0].Rows[0][0].ToString().Trim() + "00 00:00");
                //        //dt_first_row_betore = dt_first_row - TimeSpan.FromMinutes(1); 
                //        //str_startDT = dt_first_row_before.ToString("yyyy-MM-dd HH:mm"); break;
                //        case "월단위":
                //            dt_first_row = Convert.ToDateTime(ds1.Tables[0].Rows[0][0].ToString().Trim() + "-01 00:00");
                //            dt_first_row_before = dt_first_row - TimeSpan.FromDays(1);
                //            str_startDT = dt_first_row_before.ToString("yyyy-MM"); break;

                //        default:
                //            dt_first_row = Convert.ToDateTime(ds1.Tables[0].Rows[0][0].ToString().Trim());
                //            dt_first_row_before = dt_first_row - TimeSpan.FromMinutes(1);
                //            str_startDT = dt_first_row_before.ToString("yyyy-MM-dd HH:mm"); break;
                //    }



                //    // 검색조건 직전의 분값
                //    double acc_electric_before;
                //    double acc_gas_before;

                //    tablename = "LOG_FULLDATA";
                //    strQuery = "SELECT 전력_PLC, 가스_PLC FROM " + tablename + " WHERE 시스템시간 LIKE '" + dt_first_row_before + "%'";
                //    DataSet ds3 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

                //    if (Convert.ToUInt16(ds3.Tables[0].Rows.Count) > 0)
                //    {
                //        acc_electric_before = Convert.ToDouble(ds3.Tables[0].Rows[0][0]);
                //        acc_gas_before = Convert.ToDouble(ds3.Tables[0].Rows[0][1]);
                //    }
                //    else
                //    {
                //        // 직전의 데이타가 없다면 저장된 마지막 데이타를 가져오기 
                //        strQuery = "SELECT MAX(시스템시간) FROM " + tablename + " GROUP BY Format(시스템시간,'yyyy-MM-dd HH:mm')";
                //        DataSet ds6 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

                //        if (Convert.ToUInt16(ds6.Tables[0].Rows.Count) > 0)
                //        {
                //            strQuery = "SELECT 전력_PLC, 가스_PLC FROM " + tablename + " WHERE 시스템시간 ='" + ds6.Tables[0].Rows[0][0] + "' ";
                //            DataSet ds7 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

                //            if (Convert.ToUInt16(ds7.Tables[0].Rows.Count) > 0)
                //            {
                //                acc_electric_before = Convert.ToDouble(ds7.Tables[0].Rows[0][0]);
                //                acc_gas_before = Convert.ToDouble(ds7.Tables[0].Rows[0][1]); 
                //            }
                //        }
                //    }
                

                //DataSet ds8;
                // 범위내의 단위증분의 합[예:계량값 합산]을 구하기 위해서는 범위내에 전체 합을 구하는 Query를   
                
               // int AVG_Count = 0;
             
                strQuery = " SELECT 'SUM' AS 구분, " +
                    " MAX(전력_PLC) AS 전력_PLC, SUM(전력사용량) AS 전력사용량, " +
                    " MAX(가스_PLC) AS 가스_PLC, SUM(가스사용량) AS 가스사용량 " +                                   
                    " FROM " + tablename + str_where_format;
                
                //ds8 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);
                //string strCountQuery = " SELECT Count(시스템시간) " +
                //    " FROM " + tablename + str_where_format;

                //ds8 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

                DataSet ds8 = new DataSet();
                //DataSet ACds = new DataSet();

                if (_selectedPeriodUnit.ToString().Trim() == "일간" || _selectedPeriodUnit.ToString().Trim() == "월간")
                {
                    string MonthFileName = db_pathrootname + "\\" + dTP_search_start.Value.ToString("yyyy") + "\\" + db_filename_Header + "-" + dTP_search_start.Value.ToString("yyyy") + "-" + dTP_search_start.Value.ToString("MM") + ".mdb";
                    ds8 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MonthFileName, strQuery, tablename);
                    //ACds = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MonthFileName, strCountQuery, tablename);
                    //if (ACds.Tables[0].Rows.Count > 0)
                    //{
                    //    AVG_Count = AVG_Count + int.Parse(ACds.Tables[0].Rows[0][0].ToString());
                    //}
                }
                else
                {
                    DataSet tempds1 = new DataSet();

                    string MonthFileName;
                    DateTime StartDate, EndDate;

                    if (_selectedPeriodUnit.ToString().Trim() == "연간")
                    {
                        StartDate = DateTime.Parse(dTP_search_start.Value.ToString("yyyy") + "-1-1");
                        EndDate = StartDate.AddYears(1).AddDays(-1);
                    }
                    else
                    {
                        StartDate = DateTime.Parse(dTP_search_start.Value.ToString("yyyy-MM") + "-1");
                        EndDate = DateTime.Parse(dTP_search_end.Value.ToString("yyyy-MM") + "-1");
                        EndDate = EndDate.AddMonths(1).AddDays(-1);
                    }

                    ds8.Clear();
                    for (DateTime i = StartDate; i <= EndDate; i = i.AddMonths(1))
                    {
                        MonthFileName = db_pathrootname + "\\" + ndt.ToString("yyyy") + "\\" + db_filename_Header + "-" + i.ToString("yyyy") + "-" + i.ToString("MM") + ".mdb";

                        if (File.Exists(MonthFileName))
                        {
                            tempds1.Clear();

                            tempds1 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MonthFileName, strQuery, tablename);
                           // ACds = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MonthFileName, strCountQuery, tablename);
                            if (ds8.Tables.Count == 0)
                            {
                                if (tempds1.Tables.Count == 0)
                                {
                                    continue;
                                }
                                else
                                {
                                    ds8 = tempds1.Clone();
                                }
                            }
                            ds8.Tables[0].Merge(tempds1.Tables[0]);
                            //if (ACds.Tables[0].Rows.Count > 0)
                            //{
                            //    AVG_Count = AVG_Count + int.Parse(ACds.Tables[0].Rows[0][0].ToString());
                            //}

                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                //ds8.Tables[0].Rows[0][1] = Convert.ToUInt32(ds1.Tables[tablename].Rows[ds1.Tables[tablename].Rows.Count - 1][1]) - Convert.ToUInt32(acc_electric_before);
                //// 가스_PLC 증분
                //ds8.Tables[0].Rows[0][3] = Convert.ToUInt32(ds1.Tables[tablename].Rows[ds1.Tables[tablename].Rows.Count - 1][3]) - Convert.ToUInt32(acc_gas_before);

                if (ds8.Tables.Count > 0)
                {

                    if (ds8.Tables[0].Rows.Count > 0)
                    {
                        DataRow TempDR;
                        DataSet SumDs = new DataSet();

                        SumDs = ds8.Clone();

                        TempDR = SumDs.Tables[tablename].NewRow();
                        TempDR[0] = "SUM";

                        for (int i = 1; i < ds8.Tables[tablename].Columns.Count; i++)
                        {
                            if (ds8.Tables[tablename].Rows[0][i].ToString() != "")
                            {
                                if (i == 1 || i == 3)
                                {
                                    TempDR[i] = ds8.Tables[tablename].Compute("MAX(" + ds8.Tables[0].Columns[i].Caption + ")", "1=1");
                                }
                                else
                                {
                                    TempDR[i] = ds8.Tables[tablename].Compute("SUM(" + ds8.Tables[0].Columns[i].Caption + ")", "1=1");
                                }                               
                            }

                        }

                        SumDs.Tables[tablename].Rows.Add(TempDR);

                        ds1.Tables[tablename].Merge(SumDs.Tables[0]);
                    }
                } 

                dt = ds1.Tables[tablename];
               // }

                connection.Close();
            }
            catch (Exception)
            {
                return dt;
            }

            return dt;
        }

        private void bt_Load_Click(object sender, EventArgs e)
        {

            DataTable dt = Get_Data();
            //try
            //{
            //    string db_pathrootname;
            //    string db_filename_Header = "DATALOG-EEMS-M1";
            //    string fullFilename;
            //    string tablename;

            //    string str_startDT;   // 검색조건에 따라 시작일정의 포맷을 변경
            //    string str_endDT;     // 검색조건에 따라 종료일정의 포멧을 변경
            //    string str_where_format;
            //    string str_group_format;

            //    DateTime ndt = DateTime.Now;


            //    string strQuery;

              
                
            //    // dataGridView 조정하기
            //    //dataGridView1.RowHeadersVisible = false; // row header 안보이게
            //    dataGridView1.AutoSizeColumnsMode =    DataGridViewAutoSizeColumnsMode.Fill; // 일단은 풀사이즈로
            //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // 다시 모든 셀의 사이즈로
            //    dataGridView1.AllowUserToOrderColumns = true;                                 // 사용자가 컬럼의 위치를 바꿔가며 볼 수 있도록 
            //    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke; //Color.Aqua;

            //    db_pathrootname = ironSANClient1.ReadAny("SO.EEMS-R1.Path_Log").ToString().Trim();
            //    fullFilename = db_pathrootname + "\\" + ndt.ToString("yyyy") + "\\" + db_filename_Header + "-" + ndt.ToString("yyyy") + "-" + ndt.ToString("MM") + ".mdb";

                
            //    // 검색기간 단위위에 따라 포멧 변경하기
            //    switch (_selectedPeriodUnit.ToString().Trim())
            //    {
            //        case "일간":
            //            str_startDT = dTP_search_start.Value.ToString("yyyy-MM-dd");
            //            str_where_format = "  WHERE Format(시스템시간,'yyyy-MM-dd') = '" + str_startDT + "'";
            //            break;
            //        case "월간":
            //            str_startDT = dTP_search_start.Value.ToString("yyyy-MM");
            //            str_where_format = " WHERE Format(시스템시간,'yyyy-MM') = '" + str_startDT + "'";
            //            break;
            //        case "연간":
            //            str_startDT = dTP_search_start.Value.ToString("yyyy");
            //            str_where_format = " WHERE Format(시스템시간,'yyyy') = '" + str_startDT + "'";
            //            break;
            //        case "기간":
            //            str_startDT = dTP_search_start.Value.ToString("yyyy-MM-dd 00:00");
            //            str_endDT = dTP_search_end.Value.ToString("yyyy-MM-dd 23:59");
            //            str_where_format = "  WHERE Format(시스템시간,'yyyy-MM-dd HH:mm') BETWEEN '" + str_startDT + "' AND '" + str_endDT + "' ";
            //            break;
            //        default: 
            //            str_startDT = dTP_search_start.Value.ToString("yyyy-MM-dd 00:00");
            //            str_endDT = dTP_search_end.Value.ToString("yyyy-MM-dd 23:59");
            //            str_where_format = "  WHERE Format(시스템시간,'yyyy-MM-dd HH:mm') BETWEEN '" + str_startDT + "' AND '" + str_endDT + "' ";
            //            break;
            //    }
                
            //    //검색 데이타단위에 따라 그룹 포멧 변경하기
            //    switch (_selectedRowSumUnit.ToString().Trim())
            //    {
            //        case "분단위": str_group_format = "  Format(시스템시간,'yyyy-MM-dd HH:mm') "; break;
            //        case "시단위": str_group_format = "  Format(시스템시간,'yyyy-MM-dd HH') "; break;
            //        case "일단위": str_group_format = "  Format(시스템시간,'yyyy-MM-dd') "; break;
            //        //case "주단위"; str_group_format = "  GROUP BY Format(시스템시간,'yyyy-MM-dd HH:mm') "; break;
            //        case "월단위": str_group_format = "  Format(시스템시간,'yyyy-MM') "; break;

            //        default: str_group_format = " Format(시스템시간,'yyyy-MM-dd') "; break;
            //    }

            //    // GridView에 표시할 데이타 가져오기 
            //    tablename = "LOG_FULLDATA";

            //    //switch (_selectedRowSumUnit.ToString().Trim())
            //    //{
            //    //    case "분단위": 
            //    //        strQuery = " SELECT " + str_group_format + " AS 작업일시, " +
            //    //            " SUM(전력_PLC) AS 전력_PLC, SUM(전력사용량) AS 전력사용량, " +
            //    //            " SUM(가스_PLC) AS 가스_PLC, SUM(가스사용량) AS 가스사용량, " +
            //    //            " SUM(인고트_PLC) AS 인고트_PLC, SUM(인고트사용량) AS 인고트사용량, " +
            //    //            " SUM(스크랩_PLC) AS 스크랩_PLC, SUM(스크랩사용량) AS 스크랩사용량 " +
            //    //            " FROM " + tablename + str_where_format + " GROUP BY " + str_group_format;
            //    //        break;
            //    //    default :
            //    //        strQuery = " SELECT " + str_group_format + " AS 작업일시, " +
            //    //            " SUM(전력사용량) AS 전력사용량, " +
            //    //            " SUM(가스사용량) AS 가스사용량, " +
            //    //            " SUM(인고트사용량) AS 인고트사용량, " +
            //    //            " SUM(스크랩사용량) AS 스크랩사용량 " +
            //    //            " FROM " + tablename + str_where_format + " GROUP BY " + str_group_format;
            //    //        break;
            //    //}
            //    strQuery = " SELECT " + str_group_format + " AS 작업일시, " +
            //               " SUM(전력_PLC) AS 전력_PLC, SUM(전력사용량) AS 전력사용량, " +
            //               " SUM(가스_PLC) AS 가스_PLC, SUM(가스사용량) AS 가스사용량, " +
            //               " SUM(인고트_PLC) AS 인고트_PLC, SUM(인고트사용량) AS 인고트사용량, " +
            //               " SUM(스크랩_PLC) AS 스크랩_PLC, SUM(스크랩사용량) AS 스크랩사용량, " +
            //               " SUM(타워온도설정값_PLC) AS 타워온도설정값_PLC, SUM(타워온도설정값) AS 타워온도설정값, " +
            //               " SUM(타워온도_PLC) AS 타워온도_PLC, SUM(타워온도값) AS 타워온도값, " +
            //               " SUM(용탕온도설정값_PLC) AS 용탕온도설정값_PLC, SUM(용탕온도설정값) AS 용탕온도설정값, " +
            //               " SUM(용탕온도_PLC) AS 용탕온도_PLC, SUM(용탕온도값) AS 용탕온도값 " +
            //               " FROM " + tablename + str_where_format + " GROUP BY " + str_group_format;
                
            //    DataSet ds1 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);
            //    this.dataGridView1.DataSource = ds1.Tables[tablename];

            //    int last_row = ds1.Tables[tablename].Rows.Count;

            //    //printer 
            //    listView1.Clear();
            //    //LoadTableIntoList_HMI(this.listView1, ds1.Tables[tablename]); // printer test

            //    //selListViewC1.ListViewItem(ds1.Tables[tablename]);
            //    //this.Rebuild();
            //    //this.UpdatePrintPreview(null, null);
                

            //    //dataGridView1.Rows[last_row].DefaultCellStyle.ForeColor = Color.Red;
            //    ////dataGridView1.Rows[last_row].Frozen = true;  // 스크롤하지 못하게
            //    //dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count -1;
            //    //dataGridView1.Rows[last_row].DividerHeight = 3; // 다른 줄보다 굵게 
            //    ////dataGridView1.Rows[last_row]

            //    for (int ind = 0; ind < dataGridView1.Rows.Count - 1; ind++)
            //    {
            //        dataGridView1.Rows[ind].HeaderCell.Value = (ind + 1).ToString(); // row header 에 인덱스 넣기
            //    }

            //    for(int ind = 0; ind < dataGridView1.ColumnCount -1; ind++ ) 
            //    dataGridView1.Rows[last_row].Cells[ind].Value = 0.0;

            //    dataGridView1.Rows[last_row].Cells[0].Value = "합   계"; //dataGridView1.Rows[last_row].DataGridView.GridColor = Color.Red;
                
            //    if (last_row > 0)
            //    {
            //        DateTime dt_first_row;
            //        DateTime dt_first_row_before;

            //        switch (_selectedRowSumUnit.ToString().Trim())
            //        {
            //            case "분단위": 
            //                dt_first_row = Convert.ToDateTime(ds1.Tables[0].Rows[0][0].ToString().Trim());
            //                dt_first_row_before = dt_first_row - TimeSpan.FromMinutes(1); 
            //                str_startDT = dt_first_row_before.ToString("yyyy-MM-dd HH:mm"); break;
            //            case "시단위": 
            //                dt_first_row = Convert.ToDateTime(ds1.Tables[0].Rows[0][0].ToString().Trim() + ":00");
            //                dt_first_row_before = dt_first_row - TimeSpan.FromHours(1); 
            //                str_startDT = dt_first_row_before.ToString("yyyy-MM-dd HH"); break;
            //            case "일단위": 
            //                dt_first_row = Convert.ToDateTime(ds1.Tables[0].Rows[0][0].ToString().Trim() + " 00:00");
            //                dt_first_row_before = dt_first_row - TimeSpan.FromDays(1); 
            //                str_startDT = dt_first_row_before.ToString("yyyy-MM-dd"); break;
            //            //case "주단위"; 
            //                //dt_first_row = Convert.ToDateTime(ds1.Tables[0].Rows[0][0].ToString().Trim() + "00 00:00");
            //                //dt_first_row_betore = dt_first_row - TimeSpan.FromMinutes(1); 
            //                //str_startDT = dt_first_row_before.ToString("yyyy-MM-dd HH:mm"); break;
            //            case "월단위": 
            //                dt_first_row = Convert.ToDateTime(ds1.Tables[0].Rows[0][0].ToString().Trim() + "-01 00:00");
            //                dt_first_row_before = dt_first_row - TimeSpan.FromDays(1); 
            //                str_startDT = dt_first_row_before.ToString("yyyy-MM"); break;

            //            default:
            //                dt_first_row = Convert.ToDateTime(ds1.Tables[0].Rows[0][0].ToString().Trim());
            //                dt_first_row_before = dt_first_row - TimeSpan.FromMinutes(1);
            //                str_startDT = dt_first_row_before.ToString("yyyy-MM-dd HH:mm"); break;
            //        }

                   
                
            //        // 검색조건 직전의 분값
            //        double acc_electric_before;
            //        double acc_gas_before;

            //        tablename = "LOG_FULLDATA";
            //        strQuery = "SELECT 전력_PLC, 가스_PLC FROM " + tablename + " WHERE 시스템시간 LIKE '" + dt_first_row_before + "%'";
            //        DataSet ds3 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

            //        if (Convert.ToUInt16(ds3.Tables[0].Rows.Count) > 0)
            //        {
            //            acc_electric_before = Convert.ToDouble(ds3.Tables[0].Rows[0][0]);
            //            acc_gas_before = Convert.ToDouble(ds3.Tables[0].Rows[0][1]);
            //        }
            //        else
            //        {
            //            // 직전의 데이타가 없다면 저장된 마지막 데이타를 가져오기 
            //            strQuery = "SELECT MAX(시스템시간) FROM " + tablename + " GROUP BY Format(시스템시간,'yyyy-MM-dd HH:mm')";
            //            DataSet ds6 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

            //            if (Convert.ToUInt16(ds6.Tables[0].Rows.Count) > 0)
            //            {
            //                strQuery = "SELECT 전력_PLC, 가스_PLC FROM " + tablename + " WHERE 시스템시간 ='" + ds6.Tables[0].Rows[0][0] + "' ";
            //                DataSet ds7 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

            //                if (Convert.ToUInt16(ds7.Tables[0].Rows.Count) > 0)
            //                {
            //                    DataSet ds8;

            //                    acc_electric_before = Convert.ToDouble(ds7.Tables[0].Rows[0][0]);
            //                    acc_gas_before = Convert.ToDouble(ds7.Tables[0].Rows[0][1]);

            //                    // 전력_PLC 증분
                                
            //                    // 범위내의 단위증분의 합[예:계량값 합산]을 구하기 위해서는 범위내에 전체 합을 구하는 Query를 
            //                    //strQuery = " SELECT AVG(번호) AS 자리맞추기위한, " +
            //                    strQuery = " SELECT 'SUM' AS 구분, " + 
            //                        " SUM(전력_PLC) AS 전력_PLC, SUM(전력사용량) AS 전력사용량, " +
            //                        " SUM(가스_PLC) AS 가스_PLC, SUM(가스사용량) AS 가스사용량, " +
            //                        " SUM(인고트_PLC) AS 인고트_PLC, SUM(인고트사용량) AS 인고트사용량, " +
            //                        " SUM(스크랩_PLC) AS 스크랩_PLC, SUM(스크랩사용량) AS 스크랩사용량, " +
            //                        " SUM(타워온도설정값_PLC) AS 타워온도설정값_PLC, SUM(타워온도설정값) AS 타워온도설정값, " +
            //                        " SUM(타워온도_PLC) AS 타워온도_PLC, SUM(타워온도값) AS 타워온도값, " +
            //                        " SUM(용탕온도설정값_PLC) AS 용탕온도설정값_PLC, SUM(용탕온도설정값) AS 용탕온도설정값, " +
            //                        " SUM(용탕온도_PLC) AS 용탕온도_PLC, SUM(용탕온도값) AS 용탕온도값 " +
            //                        " FROM " + tablename + str_where_format;
            //                    //" WHERE 시스템시간 BETWEEN '" + dTP_search_start.Value.ToString("yyyy-MM-dd 00:00") + "' AND '" + dTP_search_end.Value.ToString("yyyy-MM-dd 23:59") + "'";
            //                    ds8 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

            //                    //ds8.Tables[0].Rows[0][0] = "합   계";

            //                    ds8.Tables[0].Rows[0][1] = Convert.ToUInt32(ds1.Tables[tablename].Rows[ds1.Tables[tablename].Rows.Count - 1][1]) - Convert.ToUInt32(acc_electric_before);
            //                    // 가스_PLC 증분
            //                    ds8.Tables[0].Rows[0][3] = Convert.ToUInt32(ds1.Tables[tablename].Rows[ds1.Tables[tablename].Rows.Count - 1][3]) - Convert.ToUInt32(acc_gas_before);

            //                    ds1.Tables[tablename].Merge(ds8.Tables[0]);
            //                    //switch (_selectedRowSumUnit.ToString().Trim())
            //                    //{
            //                    //    case "분단위":
            //                    //        acc_electric_before = Convert.ToDouble(ds7.Tables[0].Rows[0][0]);
            //                    //        acc_gas_before = Convert.ToDouble(ds7.Tables[0].Rows[0][1]);

            //                    //        // 전력_PLC 증분
            //                    //        dataGridView1.Rows[last_row].Cells[1].Value = Convert.ToUInt32(dataGridView1.Rows[last_row - 1].Cells[1].Value) - Convert.ToUInt32(acc_electric_before);
            //                    //        // 가스_PLC 증분
            //                    //        dataGridView1.Rows[last_row].Cells[3].Value = Convert.ToUInt32(dataGridView1.Rows[last_row - 1].Cells[3].Value) - Convert.ToUInt32(acc_gas_before);

            //                    //        // 범위내의 단위증분의 합[예:계량값 합산]을 구하기 위해서는 범위내에 전체 합을 구하는 Query를 
            //                    //        strQuery = " SELECT AVG(번호) AS 자리맞추기위한, " +
            //                    //            " SUM(전력_PLC) AS 전력_PLC, SUM(전력사용량) AS 전력사용량, " +
            //                    //            " SUM(가스_PLC) AS 가스_PLC, SUM(가스사용량) AS 가스사용량, " +
            //                    //            " SUM(인고트_PLC) AS 인고트_PLC, SUM(인고트사용량) AS 인고트사용량, " +
            //                    //            " SUM(스크랩_PLC) AS 스크랩_PLC, SUM(스크랩사용량) AS 스크랩사용량 " +
            //                    //            " FROM " + tablename + str_where_format;
            //                    //        //" WHERE 시스템시간 BETWEEN '" + dTP_search_start.Value.ToString("yyyy-MM-dd 00:00") + "' AND '" + dTP_search_end.Value.ToString("yyyy-MM-dd 23:59") + "'";
            //                    //        ds8 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

            //                    //        // 단위전력량 합계
            //                    //        dataGridView1.Rows[last_row].Cells[2].Value = Convert.ToDouble(String.Format("{0:0.0}", ds8.Tables[0].Rows[0][2]));
            //                    //        // 단위가스량 합계
            //                    //        dataGridView1.Rows[last_row].Cells[4].Value = Convert.ToDouble(String.Format("{0:0.0}", ds8.Tables[0].Rows[0][4]));
            //                    //        // 인고트_PLC 합계
            //                    //        dataGridView1.Rows[last_row].Cells[5].Value = Convert.ToDouble(String.Format("{0:0.0}", ds8.Tables[0].Rows[0][5]));
            //                    //        // 단위인고트 합계
            //                    //        dataGridView1.Rows[last_row].Cells[6].Value = Convert.ToDouble(String.Format("{0:0.0}", ds8.Tables[0].Rows[0][6]));
            //                    //        // 스크랩_PLC 합계
            //                    //        dataGridView1.Rows[last_row].Cells[7].Value = Convert.ToDouble(String.Format("{0:0.0}", ds8.Tables[0].Rows[0][7]));
            //                    //        // 단위스크랩 합계
            //                    //        dataGridView1.Rows[last_row].Cells[8].Value = Convert.ToDouble(String.Format("{0:0.0}", ds8.Tables[0].Rows[0][8]));
            //                    //        break;
            //                    //    default:
            //                    //        // 전력_PLC 증분
            //                    //        // 범위내의 단위증분의 합[예:계량값 합산]을 구하기 위해서는 범위내에 전체 합을 구하는 Query를 
            //                    //        strQuery = " SELECT AVG(번호) AS 자리맞추기위한, " +
            //                    //            " SUM(전력사용량) AS 전력사용량, " +
            //                    //            " SUM(가스사용량) AS 가스사용량, " +
            //                    //            " SUM(인고트사용량) AS 인고트사용량, " +
            //                    //            " SUM(스크랩사용량) AS 스크랩사용량 " +
            //                    //            " FROM " + tablename + str_where_format;
            //                    //        //" WHERE 시스템시간 BETWEEN '" + dTP_search_start.Value.ToString("yyyy-MM-dd 00:00") + "' AND '" + dTP_search_end.Value.ToString("yyyy-MM-dd 23:59") + "'";
            //                    //        ds8 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

            //                    //        // 단위전력량 합계
            //                    //        dataGridView1.Rows[last_row].Cells[1].Value = Convert.ToDouble(String.Format("{0:0.0}", ds8.Tables[0].Rows[0][1]));
            //                    //        // 단위가스량 합계
            //                    //        dataGridView1.Rows[last_row].Cells[2].Value = Convert.ToDouble(String.Format("{0:0.0}", ds8.Tables[0].Rows[0][2]));
            //                    //        // 단위인고트 합계
            //                    //        dataGridView1.Rows[last_row].Cells[3].Value = Convert.ToDouble(String.Format("{0:0.0}", ds8.Tables[0].Rows[0][3]));
            //                    //        // 단위스크랩 합계
            //                    //        dataGridView1.Rows[last_row].Cells[4].Value = Convert.ToDouble(String.Format("{0:0.0}", ds8.Tables[0].Rows[0][4]));
            //                    //        break;
            //                    //}
                               
            //                }
            //            }
            //        }
            //    }



            selListViewC1.ListViewItem(dt, "EGLog_Config_LV.xml", this.ProjectPath);
            selGraphViewC1.GraphViewItem(dt, "EGLog_Config.xml", this.ProjectPath); 

           // this.Rebuild();
            this.UpdatePrintPreview(null, null);

            if (selGraphViewC1.Visible) bt_to_trend.PerformClick();

            //    connection.Close();
            //}
            //catch (Exception)
            //{
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //trend1.Charting = true;
        }

        private void bt_printtrend_Click(object sender, EventArgs e)
        {
            PrintDocument docToPrint = new PrintDocument();
            PageSettings ps = new PageSettings();

            ps.Margins = new Margins(10, 10, 10, 10);

            docToPrint.DefaultPageSettings = ps;

            PrintPreviewDialog pd = new PrintPreviewDialog();

            pd.ClientSize = new Size(500, 500);
            pd.UseAntiAlias = true;

            //docToPrint.PrintPage += new PrintPageEventHandler(doc_PrintPage);
            docToPrint.PrintPage += new PrintPageEventHandler(docToPrint_PrintPage);
            pd.Document = docToPrint;
            pd.ShowDialog();
        }

        private void bt_printfooter_Click(object sender, EventArgs e)
        {

        }
        #endregion 

        #region Printer 관련 : ListViewPrinter 활용을 위한 수정

        private void LoadXmlDataIntoList()
        {
            //DataSet ds = new DataSet();
            try
            {
                string db_pathrootname;
                string db_filename_Header = "DATALOG-EEMS-M1";
                string fullFilename;
                string tablename = "LOG_FULLDATA";

                DateTime ndt = DateTime.Now;

                db_pathrootname = ironSANClient1.ReadAny("SO.EEMS-R1.Path_Log").ToString().Trim();
                //db_pathrootname = "E:\\LOG_DATA";
                fullFilename = db_pathrootname + "\\" + ndt.ToString("yyyy") + "\\" + db_filename_Header + "-" + ndt.ToString("yyyy") + "-" + ndt.ToString("MM") + ".mdb";

                DataSet ds = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, "SELECT * FROM " + tablename, tablename);
                this.dataGridView1.DataSource = ds.Tables[tablename];

                LoadTableIntoList_HMI(this.listView1, ds.Tables[tablename]);
            }
            catch (Exception)
            { // ex) {
                //MessageBox.Show(ex.Message);
            }
        }

        private void LoadTableIntoList_HMI(ListView lv, DataTable table)
        {
            lv.BeginUpdate();

            lv.Items.Clear();

            int ind = 0;
            foreach (DataColumn dc in table.Columns)
            {
                lv.Columns.Add(table.Columns[ind++].ColumnName.ToString(), 200,HorizontalAlignment.Center );
            }
            

            foreach (DataRow row in table.Rows)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = row[0].ToString();
                //lvi.ImageIndex = Int32.Parse(row[1].ToString());

                for (int i = 1; i < table.Columns.Count; i++)
                {
                    lvi.SubItems.Add(row[i].ToString());
                }
                lv.Items.Add(lvi);
            }

            lv.EndUpdate();
        }

        private void UpdatePrintPreview(object sender, EventArgs e)
        {
            this.listViewPrinter1.Header = this.tbHeader.Text.Replace("\\t", "\t") + " ( " + dTP_search_start.Value.ToString(CusFormatStr) + " ~ " + dTP_search_end.Value.ToString(CusFormatStr) + ")"; ;
            this.listViewPrinter1.Footer = this.tbFooter.Text.Replace("\\t", "\t");
            this.listViewPrinter1.Watermark = "";

            this.listViewPrinter1.IsShrinkToFit = this.cbShrinkToFit.Checked;
            //this.listViewPrinter1.IsTextOnly = !this.cbListHeaderOnEveryPage.Checked;
            this.listViewPrinter1.IsListHeaderOnEachPage = this.cbListHeaderOnEveryPage.Checked;
            this.listViewPrinter1.IsPrintSelectionOnly = this.cbPrintSelection.Checked;

            if (this.rbStyleMinimal.Checked == true)
                this.ApplyMinimalFormatting();
            else if (this.rbStyleModern.Checked == true)
                this.ApplyModernFormatting();
            else if (this.rbStyleOTT.Checked == true)
                this.ApplyOverTheTopFormatting();
            else if (this.rbStyleCustom.Checked == true)
                this.ApplyCustomFormatting();

            if (this.cbUseGridLines.Checked == false)
                this.listViewPrinter1.ListGridPen = null;

            //this.listViewPrinter1.FirstPage = (int)this.numericUpDown1.Value;
            //this.listViewPrinter1.LastPage = (int)this.numericUpDown2.Value;

            this.printPreviewControl1.InvalidatePreview();
        }

        private void bt_Print_Click(object sender, EventArgs e)
        {
            if (selGraphViewC1.Visible == true)
            {
                PrintDialog printDg = new PrintDialog();
                printDg.PrinterSettings.DefaultPageSettings.Landscape = true;
                DialogResult Result = printDg.ShowDialog();

                if (Result == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }

            if (selListViewC1.Visible == true)
            {
                this.listViewPrinter1.ListView = selListViewC1.ListViewC;
                listViewPrinter1.DefaultPageSettings.Landscape = false;
                this.listViewPrinter1.PrintWithDialog();
            }
        }

        private void bt_PageSetup_Click(object sender, EventArgs e)
        {
            if (selGraphViewC1.Visible == true)
            {
                PageSetupDialog pageDg = new PageSetupDialog();

                pageDg.PageSettings = printDoc.DefaultPageSettings;
                pageDg.PageSettings.Landscape = true;

                DialogResult Result = pageDg.ShowDialog();
            }
            if (selListViewC1.Visible == true)
            {
                listViewPrinter1.DefaultPageSettings.Landscape = false;
                this.listViewPrinter1.PageSetup();
                this.UpdatePrintPreview(null, null);
            }
        }

        private void bt_PrintPreview_Click(object sender, EventArgs e)
        {
            if (selGraphViewC1.Visible == true)
            {
                PrintPreviewDialog pdlg = new PrintPreviewDialog();

                pdlg.Document = printDoc;
                pdlg.ShowDialog();
            }
            if (selListViewC1.Visible == true)
            {
                this.listViewPrinter1.ListView = selListViewC1.ListViewC;
                listViewPrinter1.DefaultPageSettings.Landscape = false;
                this.listViewPrinter1.PrintPreview();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.printPreviewControl1.Zoom = 2.0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.printPreviewControl1.Zoom = 1.0;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.printPreviewControl1.Zoom = 0.5;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.printPreviewControl1.Zoom = 1.0;
            this.printPreviewControl1.AutoZoom = true;
        }

#endregion

        #region  Printer 관련 : ListViewPriter lib.

        //-----------------------------------------------------------------------------
        // Include all the stupid normal stuff that a ListView needs to be useful
        // Better to use an ObjectListView!

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == this.lastSortColumn)
            {
                if (this.lastSortOrder == SortOrder.Ascending)
                    this.lastSortOrder = SortOrder.Descending;
                else
                    this.lastSortOrder = SortOrder.Ascending;
            }
            else
            {
                this.lastSortOrder = SortOrder.Ascending;
                this.lastSortColumn = e.Column;
            }

            this.Rebuild();
        }
        private int lastSortColumn = 0;
        private SortOrder lastSortOrder = SortOrder.Ascending;

        private void Rebuild()
        {
            if (this.listView1.ShowGroups)
                this.BuildGroups(this.lastSortColumn);
            else
                this.listView1.ListViewItemSorter = new ColumnComparer(this.lastSortColumn, this.lastSortOrder);
        }

        private void BuildGroups(int column)
        {
            this.listView1.Groups.Clear();

            // Getting the Count forces any internal cache of the ListView to be flushed. Without
            // this, iterating over the Items will not work correctly if the ListView handle
            // has not yet been created.
            int dummy = this.listView1.Items.Count;

            // Separate the list view items into groups, using the group key as the descrimanent
            Dictionary<String, List<ListViewItem>> map = new Dictionary<String, List<ListViewItem>>();
            foreach (ListViewItem lvi in this.listView1.Items)
            {
                String key = lvi.SubItems[column].Text;
                if (column == 0 && key.Length > 0)
                    key = key.Substring(0, 1);
                if (!map.ContainsKey(key))
                    map[key] = new List<ListViewItem>();
                map[key].Add(lvi);
            }

            // Make a list of the required groups
            List<ListViewGroup> groups = new List<ListViewGroup>();
            foreach (String key in map.Keys)
            {
                groups.Add(new ListViewGroup(key));
            }

            // Sort the groups
            groups.Sort(new ListViewGroupComparer(this.lastSortOrder));

            // Put each group into the list view, and give each group its member items.
            // The order of statements is important here:
            // - the header must be calculate before the group is added to the list view,
            //   otherwise changing the header causes a nasty redraw (even in the middle of a BeginUpdate...EndUpdate pair)
            // - the group must be added before it is given items, otherwise an exception is thrown (is this documented?)
            ColumnComparer itemSorter = new ColumnComparer(column, this.lastSortOrder);
            foreach (ListViewGroup group in groups)
            {
                this.listView1.Groups.Add(group);
                map[group.Header].Sort(itemSorter);
                group.Items.AddRange(map[group.Header].ToArray());
            }
        }

        internal class ListViewGroupComparer : IComparer<ListViewGroup>
        {
            public ListViewGroupComparer(SortOrder order)
            {
                this.sortOrder = order;
            }

            public int Compare(ListViewGroup x, ListViewGroup y)
            {
                int result = String.Compare(x.Header, y.Header, true);

                if (this.sortOrder == SortOrder.Descending)
                    result = 0 - result;

                return result;
            }

            private SortOrder sortOrder;
        }

        internal class ColumnComparer : IComparer, IComparer<ListViewItem>
        {
            public ColumnComparer(int col, SortOrder order)
            {
                this.column = col;
                this.sortOrder = order;
            }

            public int Compare(object x, object y)
            {
                return this.Compare((ListViewItem)x, (ListViewItem)y);
            }

            public int Compare(ListViewItem x, ListViewItem y)
            {
                int result = String.Compare(x.SubItems[this.column].Text, y.SubItems[this.column].Text, true);

                if (this.sortOrder == SortOrder.Descending)
                    result = 0 - result;

                return result;

            }

            private int column;
            private SortOrder sortOrder;
        }

        /// <summary>
        /// Give the report a minimal set of default formatting values.
        /// </summary>
        public void ApplyMinimalFormatting()
        {
           
            this.listViewPrinter1.CellFormat = null;
            this.listViewPrinter1.ListFont = new Font("Tahoma", 9);

            this.listViewPrinter1.HeaderFormat = BlockFormat.Header(new Font("Verdana", 15, FontStyle.Bold));
            this.listViewPrinter1.HeaderFormat.TextBrush = Brushes.Black;
            this.listViewPrinter1.HeaderFormat.BackgroundBrush = null;
            this.listViewPrinter1.HeaderFormat.SetBorderPen(Sides.Bottom, new Pen(Color.Black, 0.5f));

            this.listViewPrinter1.FooterFormat = BlockFormat.Footer();
            this.listViewPrinter1.GroupHeaderFormat = BlockFormat.GroupHeader();
            this.listViewPrinter1.GroupHeaderFormat.SetBorder(Sides.Bottom, 2, new LinearGradientBrush(new Rectangle(0, 0, 1, 1), Color.Gray, Color.White, LinearGradientMode.Horizontal));

            this.listViewPrinter1.ListHeaderFormat = BlockFormat.ListHeader();
            this.listViewPrinter1.ListHeaderFormat.BackgroundBrush = null;

            this.listViewPrinter1.WatermarkFont = null;
            this.listViewPrinter1.WatermarkColor = Color.Empty;
        }

        /// <summary>
        /// Give the report a minimal set of default formatting values.
        /// </summary>
        public void ApplyModernFormatting()
        {
            this.listViewPrinter1.CellFormat = null;
            this.listViewPrinter1.ListFont = new Font("Ms Sans Serif", 9);
            this.listViewPrinter1.ListGridPen = new Pen(Color.DarkGray, 0.5f);


            this.listViewPrinter1.HeaderFormat = BlockFormat.Header(new Font("Verdana", 15, FontStyle.Bold));
            this.listViewPrinter1.HeaderFormat.BackgroundBrush = new LinearGradientBrush(new Rectangle(0, 0, 1, 1), Color.DarkBlue, Color.White, LinearGradientMode.Horizontal);

            this.listViewPrinter1.FooterFormat = BlockFormat.Footer();
            this.listViewPrinter1.FooterFormat.BackgroundBrush = new LinearGradientBrush(new Rectangle(0, 0, 1, 1), Color.White, Color.DarkBlue, LinearGradientMode.Horizontal);

            this.listViewPrinter1.GroupHeaderFormat = BlockFormat.GroupHeader();
            this.listViewPrinter1.ListHeaderFormat = BlockFormat.ListHeader(new Font("Verdana", 12));

            this.listViewPrinter1.WatermarkFont = null;
            this.listViewPrinter1.WatermarkColor = Color.Empty;
        }

        /// <summary>
        /// Give the report a some outrageous formatting values.
        /// </summary>
        public void ApplyOverTheTopFormatting()
        {
            this.listViewPrinter1.CellFormat = null;
            this.listViewPrinter1.ListFont = new Font("Ms Sans Serif", 9);
            this.listViewPrinter1.ListGridPen = new Pen(Color.Blue, 0.5f);

            this.listViewPrinter1.HeaderFormat = BlockFormat.Header(new Font("Comic Sans MS", 15));
            this.listViewPrinter1.HeaderFormat.TextBrush = new LinearGradientBrush(new Rectangle(0, 0, 1, 1), Color.Black, Color.Blue, LinearGradientMode.Horizontal);

            this.listViewPrinter1.HeaderFormat.BackgroundBrush = new TextureBrush(this.listView1.SmallImageList.Images["music"], WrapMode.Tile);
            this.listViewPrinter1.HeaderFormat.SetBorder(Sides.All, 10, new LinearGradientBrush(new Rectangle(0, 0, 1, 1), Color.Purple, Color.Pink, LinearGradientMode.Horizontal));

            this.listViewPrinter1.FooterFormat = BlockFormat.Footer(new Font("Comic Sans MS", 12));
            this.listViewPrinter1.FooterFormat.TextBrush = Brushes.Blue;
            this.listViewPrinter1.FooterFormat.BackgroundBrush = new LinearGradientBrush(new Rectangle(0, 0, 1, 1), Color.Gold, Color.Green, LinearGradientMode.Horizontal);
            this.listViewPrinter1.FooterFormat.SetBorder(Sides.All, 5, new SolidBrush(Color.FromArgb(128, Color.Green)));

            this.listViewPrinter1.GroupHeaderFormat = BlockFormat.GroupHeader();
            this.listViewPrinter1.GroupHeaderFormat.SetBorder(Sides.Bottom, 5, new HatchBrush(HatchStyle.LargeConfetti, Color.Blue, Color.Empty));

            this.listViewPrinter1.ListHeaderFormat = BlockFormat.ListHeader(new Font("Comic Sans MS", 12));
            this.listViewPrinter1.ListHeaderFormat.BackgroundBrush = Brushes.PowderBlue;
            this.listViewPrinter1.ListHeaderFormat.TextBrush = Brushes.Black;

            this.listViewPrinter1.WatermarkFont = new Font("Comic Sans MS", 72);
            this.listViewPrinter1.WatermarkColor = Color.Red;
        }


        /// <summary>
        /// Copy the formatting from the formatting that the user has setup on the custom format panel.
        /// </summary>
        public void ApplyCustomFormatting()
        {
            this.listViewPrinter1.ListFont = this.listViewPrinter2.ListFont;
            this.listViewPrinter1.CellFormat = this.listViewPrinter2.CellFormat;
            this.listViewPrinter1.HeaderFormat = this.listViewPrinter2.HeaderFormat;
            this.listViewPrinter1.FooterFormat = this.listViewPrinter2.FooterFormat;
            this.listViewPrinter1.GroupHeaderFormat = this.listViewPrinter2.GroupHeaderFormat;
            this.listViewPrinter1.ListHeaderFormat = this.listViewPrinter2.ListHeaderFormat;

            this.ApplyPenData(this.listViewPrinter1.CellFormat);
            this.ApplyPenData(this.listViewPrinter1.HeaderFormat);
            this.ApplyPenData(this.listViewPrinter1.FooterFormat);
            this.ApplyPenData(this.listViewPrinter1.GroupHeaderFormat);
            this.ApplyPenData(this.listViewPrinter1.ListHeaderFormat);

            this.listViewPrinter1.WatermarkFont = this.listViewPrinter2.WatermarkFont;
            this.listViewPrinter1.WatermarkTransparency = this.listViewPrinter2.WatermarkTransparency;
            this.listViewPrinter1.WatermarkColor = this.listViewPrinter2.WatermarkColor;
        }

        private void ApplyPenData(BlockFormat blockFormat)
        {
            blockFormat.BackgroundBrushData = blockFormat.BackgroundBrushData;
            blockFormat.BottomBorderPenData = blockFormat.BottomBorderPenData;
            blockFormat.LeftBorderPenData = blockFormat.LeftBorderPenData;
            blockFormat.RightBorderPenData = blockFormat.RightBorderPenData;
            blockFormat.TextBrushData = blockFormat.TextBrushData;
            blockFormat.TopBorderPenData = blockFormat.TopBorderPenData;
        }
        

#endregion
        
        #region Radio buttons and DTPicker setting for searching

        private void rB_day_CheckedChanged(object sender, EventArgs e)
        {
            this._selectedPeriodUnit = Period_Unit.일간;
            PeriodUnit_Changed();
        }

        private void rB_month_CheckedChanged(object sender, EventArgs e)
        {
            this._selectedPeriodUnit = Period_Unit.월간;
            PeriodUnit_Changed();
        }

        private void rB_year_CheckedChanged(object sender, EventArgs e)
        {
            this._selectedPeriodUnit = Period_Unit.연간;
            PeriodUnit_Changed();
        }

        private void rB_period_CheckedChanged(object sender, EventArgs e)
        {
            this._selectedPeriodUnit = Period_Unit.기간;
            PeriodUnit_Changed();
        }

        private void PeriodUnit_Changed()
        {
            switch (this._selectedPeriodUnit.ToString().Trim())
            {
                case "일간": 
                    rB_row_unit_min.Enabled = true; 
                    rB_row_unit_hour.Enabled = true;
                    rB_row_unit_day.Enabled = false; if(rB_row_unit_day.Checked) rB_row_unit_hour.Checked = true;
                    rb_row_unit_month.Enabled = false; if(rb_row_unit_month.Checked) rB_row_unit_hour.Checked = true;
                    dTP_search_start.Format = DateTimePickerFormat.Custom;
                    dTP_search_start.CustomFormat = "yyyy-MM-dd";
                    CusFormatStr = "yyyy-MM-dd"; 
                    dTP_search_end.Format = DateTimePickerFormat.Custom;
                    dTP_search_end.CustomFormat = "yyyy-MM-dd";
                    dTP_search_end.Enabled = false;
                    break;
                case "월간":
                    rB_row_unit_min.Enabled = false; if(rB_row_unit_min.Checked) rB_row_unit_hour.Checked = true;
                    rB_row_unit_hour.Enabled = true;
                    rB_row_unit_day.Enabled = true;
                    rb_row_unit_month.Enabled = false; if(rb_row_unit_month.Checked) rB_row_unit_day.Checked = true;
                    dTP_search_start.Format = DateTimePickerFormat.Custom;
                    dTP_search_start.CustomFormat = "yyyy-MM";
                    CusFormatStr = "yyyy-MM"; 
                    dTP_search_end.Format = DateTimePickerFormat.Custom;
                    dTP_search_end.CustomFormat = "yyyy-MM";
                    dTP_search_end.Enabled = false;
                    break;
                case "연간":
                    rB_row_unit_min.Enabled = false; if(rB_row_unit_min.Checked) rB_row_unit_day.Checked = true;
                    rB_row_unit_hour.Enabled = false;if(rB_row_unit_hour.Checked) rB_row_unit_day.Checked = true;
                    rB_row_unit_day.Enabled = true;
                    rb_row_unit_month.Enabled = true;
                    dTP_search_start.Format = DateTimePickerFormat.Custom;
                    dTP_search_start.CustomFormat = "yyyy";
                    CusFormatStr = "yyyy"; 
                    dTP_search_end.Format = DateTimePickerFormat.Custom;
                    dTP_search_end.CustomFormat = "yyyy";
                    dTP_search_end.Enabled = false;
                    break;
                case "기간":
                    rB_row_unit_min.Enabled = false; if(rB_row_unit_min.Checked) rB_row_unit_day.Checked = true;
                    rB_row_unit_hour.Enabled = true;
                    rB_row_unit_day.Enabled = true;
                    rb_row_unit_month.Enabled = true;
                    dTP_search_end.Format = DateTimePickerFormat.Custom;
                    dTP_search_start.CustomFormat = "yyyy-MM-dd";
                    CusFormatStr = "yyyy-MM-dd"; 
                    dTP_search_end.Format = DateTimePickerFormat.Custom;
                    dTP_search_end.CustomFormat = "yyyy-MM-dd";
                    dTP_search_end.Enabled = true;
                    break;
                default: break;
            }
        }

        private void rB_row_unit_min_CheckedChanged(object sender, EventArgs e)
        {
            this._selectedRowSumUnit = Row_SumUnit.분단위;
            RowSumUnit_Changed();
        }

        private void rB_row_unit_hour_CheckedChanged(object sender, EventArgs e)
        {
            this._selectedRowSumUnit = Row_SumUnit.시단위;
            RowSumUnit_Changed();
        }

        private void rB_row_unit_day_CheckedChanged(object sender, EventArgs e)
        {
            this._selectedRowSumUnit = Row_SumUnit.일단위;
            RowSumUnit_Changed();
        }

        private void rb_row_unit_month_CheckedChanged(object sender, EventArgs e)
        {
            this._selectedRowSumUnit = Row_SumUnit.월단위;
            RowSumUnit_Changed();
        }

        private void RowSumUnit_Changed()
        {
        }

        #endregion

        #region Related Excel

        private void bt_ExportExcel_Click(object sender, EventArgs e)
        {
            bool captions = true;
            string filename = "DATA";
            filename = this.bt_ExportExcel.Text;
            this.saveFileDialog1.FileName = filename + "-" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
            this.saveFileDialog1.DefaultExt = "xls";
            this.saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
            
            string ExcelDirPath = "E:\\EXCEL";
            
            this.saveFileDialog1.InitialDirectory = ExcelDirPath;
            
            if (!Directory.Exists(ExcelDirPath))
            {
                Directory.CreateDirectory(ExcelDirPath);
            }

            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                int num = 0;
                object missingType = Type.Missing;

                Excel.Application objApp;
                Excel._Workbook objBook;
                Excel.Workbooks objBooks;
                Excel.Sheets objSheets;
                Excel._Worksheet objSheet;
                Excel.Range range;

                //string[] headers = new string[dataGridView1.ColumnCount];
                //string[] columns = new string[dataGridView1.ColumnCount];

                //for (int c = 0; c < dataGridView1.ColumnCount; c++)
                //{
                //    headers[c] = dataGridView1.Rows[0].Cells[c].OwningColumn.HeaderText.ToString();
                //    num = c + 65;
                //    columns[c] = Convert.ToString((char)num);
                //}

                //try
                //{
                //    objApp = new Excel.Application();
                //    objBooks = objApp.Workbooks;
                //    objBook = objBooks.Add(Missing.Value);
                //    objSheets = objBook.Worksheets;
                //    objSheet = (Excel._Worksheet)objSheets.get_Item(1);

                //    if (captions)
                //    {
                //        for (int c = 0; c < dataGridView1.ColumnCount; c++)
                //        {
                //            range = objSheet.get_Range(columns[c] + "1", Missing.Value);
                //            range.set_Value(Missing.Value, headers[c]);
                //        }
                //    }

                //    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                //    {
                //        for (int j = 0; j < dataGridView1.ColumnCount; j++)
                //        {
                //            range = objSheet.get_Range(columns[j] + Convert.ToString(i + 2),
                //                                                   Missing.Value);
                //            range.set_Value(Missing.Value,
                //                                  dataGridView1.Rows[i].Cells[j].Value.ToString());
                //        }
                //    }
                ListView tempListview = selListViewC1.ListViewC;

                string[] headers = new string[tempListview.Columns.Count];
                string[] columns = new string[tempListview.Columns.Count];

                for (int c = 0; c < tempListview.Columns.Count ; c++)
                {
                    headers[c] = tempListview.Columns[c].Text.ToString();
                    num = c + 65;
                    columns[c] = Convert.ToString((char)num);
                }

                try
                {
                    objApp = new Excel.Application();
                    objBooks = objApp.Workbooks;
                    objBook = objBooks.Add(Missing.Value);
                    objSheets = objBook.Worksheets;
                    objSheet = (Excel._Worksheet)objSheets.get_Item(1);

                    if (captions)
                    {
                        for (int c = 0; c < tempListview.Columns.Count ; c++)
                        {
                            range = objSheet.get_Range(columns[c] + "1", Missing.Value);
                            range.set_Value(Missing.Value, headers[c]);
                        }
                    }

                    for (int i = 0; i < tempListview.Items.Count - 1; i++)
                    {
                        for (int j = 0; j < tempListview.Columns.Count; j++)
                        {
                            range = objSheet.get_Range(columns[j] + Convert.ToString(i + 2),
                                                                   Missing.Value);
                            range.set_Value(Missing.Value,
                                                  tempListview.Items[i].SubItems[j].Text.ToString());
                        }
                    }
                    objApp.Visible = false;
                    objApp.UserControl = false;

                    objBook.SaveAs(@saveFileDialog1.FileName,
                              Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                              missingType, missingType, missingType, missingType,
                              Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                              missingType, missingType, missingType, missingType, missingType);
                    objBook.Close(false, missingType, missingType);

                    Cursor.Current = Cursors.Default;

                    MessageBox.Show("Save Success!!!");
                }
                catch (Exception theException)
                {
                    String errorMessage;
                    errorMessage = "Error: ";
                    errorMessage = String.Concat(errorMessage, theException.Message);
                    errorMessage = String.Concat(errorMessage, " Line: ");
                    errorMessage = String.Concat(errorMessage, theException.Source);

                    MessageBox.Show(errorMessage, "Error");
                }
            }
        }

        #endregion

        #region Related .. NI MeasurementStudio control sample

        private void button2_Click(object sender, EventArgs e)
        {
            // Single y-axis  : Y축을 한개로 표현하기
            //double[] x = new double[10];
            //double[] y = new double[10];

            //for (int i = 0; i < 10; i++)
            //{
            //    x[i] = i;
            //    y[i] = 100 * i;
            //}

            //scatterGraph1.PlotXYAppend(x, y);


            // Double y-axis  : Y축을 두개로 표현하기
            double[] x = new double[10];
            double[,] y = new double[2, 10];
            double[] y2 = new double[10];

            for (int i = 0; i < 10; i++)
            {
                x[i] = i;
                y[0, i] = i;
                y[1, i] = 10 * i + 5;
            }

            scatterGraph1.PlotXYMultiple(x, y);

            //SELECT Format(LNG_DATE, 'yyyy-MM-dd') AS DATE_SUM, MAX(LNG_CUMULATION) AS CUMULATION_MAX, SUM(LNG_USE) AS USE_SUM       
            //FROM  LNG_TABLE
            //WHERE LNG_DATE BETWEEN #1994-01-01# And #2994-01-01#
            //GROUP BY Format(LNG_DATE, 'yyyy-MM-dd')
        }
        #endregion

        private void bt_to_trend_Click(object sender, EventArgs e)
        {
            try
            {
                selListViewC1.Visible = false;
                selGraphViewC1.Visible = true;               

                if (!selGraphViewC1.Visible)
                {
                    //scatterGraph1.Visible = true;
                    //dataGridView1.Visible = false;
                    //listView1.Visible = false;
                   

                    //scatterGraph1.ClearData();
                    
                    //ListView tempListview = selListViewC1.ListViewC;

                    //if (tempListview.Items.Count > 0)
                    //{
                    //    List<double> x = new List<double>();
                    //    List<List<double>> y = new List<List<double>>();

                    //    int cnt_y = 0;
                    //    for (cnt_y = 0; cnt_y < tempListview.Columns.Count - 1; cnt_y++)
                    //    {
                    //        y.Add(new List<double>());
                    //    }

                    //    //y.Add(new List<double>());
                    //    //y.Add(new List<double>());
                    //    //y.Add(new List<double>());
                    //    //y.Add(new List<double>());

                    //    for (int i = 0; i < tempListview.Items.Count ; i++)
                    //    {
                    //        x.Add(i);
                    //        for (cnt_y = 0; cnt_y < tempListview.Columns.Count - 1; cnt_y++)
                    //        {
                    //            if(tempListview.Items[i].SubItems[cnt_y+1].Text.ToString() == "")
                    //            {
                    //                tempListview.Items[i].SubItems[cnt_y + 1].Text = "0";
                    //            }
                                    
                    //            y[cnt_y].Add(Convert.ToDouble(tempListview.Items[i].SubItems[cnt_y+1].Text.ToString()));                               
                    //        }
                    //        //y[0].Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value.ToString()));
                    //        //y[1].Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                    //        //y[2].Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString()));
                    //        //y[3].Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value.ToString()));
                    //    }

                    //    scatterGraph1.BeginUpdate();
                    //    for (cnt_y = 0; cnt_y < tempListview.Columns.Count - 1; cnt_y++)
                    //    {
                    //        //scatterPlot1.PlotXYAppend(x.ToArray(), y[cnt_y].ToArray());
                    //        scatterGraph1.Plots[cnt_y].PlotXYAppend(x.ToArray(), y[cnt_y].ToArray());
                    //    }

                    ////if (dataGridView1.Rows.Count > 0)
                    ////{
                    ////    List<double> x = new List<double>();
                    ////    List<List<double>> y = new List<List<double>>();

                    ////    int cnt_y = 0;
                    ////    for (cnt_y = 0; cnt_y < dataGridView1.ColumnCount - 1; cnt_y++)
                    ////    {
                    ////        y.Add(new List<double>());
                    ////    }

                    ////    //y.Add(new List<double>());
                    ////    //y.Add(new List<double>());
                    ////    //y.Add(new List<double>());
                    ////    //y.Add(new List<double>());

                    ////    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    ////    {
                    ////        x.Add(i);
                    ////        for (cnt_y = 0; cnt_y < dataGridView1.ColumnCount - 1; cnt_y++)
                    ////        {
                    ////            y[cnt_y].Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[cnt_y + 1].Value.ToString()));
                    ////        }
                    ////        //y[0].Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value.ToString()));
                    ////        //y[1].Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                    ////        //y[2].Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString()));
                    ////        //y[3].Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value.ToString()));
                    ////    }

                    ////    scatterGraph1.BeginUpdate();
                    ////    for (cnt_y = 0; cnt_y < dataGridView1.ColumnCount - 1; cnt_y++)
                    ////    {
                    ////        //scatterPlot1.PlotXYAppend(x.ToArray(), y[cnt_y].ToArray());
                    ////        scatterGraph1.Plots[cnt_y].PlotXYAppend(x.ToArray(), y[cnt_y].ToArray());
                    ////    }
                    //    //scatterPlot1.PlotXYAppend(x.ToArray(), y[0].ToArray());
                    //    //scatterPlot2.PlotXYAppend(x.ToArray(), y[1].ToArray());
                    //    //scatterPlot3.PlotXYAppend(x.ToArray(), y[2].ToArray());
                    //    //scatterPlot4.PlotXYAppend(x.ToArray(), y[3].ToArray());

                    //    scatterGraph1.EndUpdate();
                    //}
                }
                else
                {
                    //scatterGraph1.Visible = false;
                    //dataGridView1.Visible = true;
                    //listView1.Visible = true;
                }
            }
            catch (Exception)
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //scatterGraph1.Visible = false;
            //dataGridView1.Visible = false;
            //listView1.Visible = false;
            selListViewC1.Visible = true;
            selGraphViewC1.Visible = false;
        }

        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            NationalInstruments.UI.IScatterGraph TempScatterG = selGraphViewC1.ScatterGraphC;

            int width = e.MarginBounds.Width;
            int height = e.MarginBounds.Height;

            using (Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppPArgb))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Rectangle bounds = new Rectangle(0, 0, width, height);
                TempScatterG.Draw(new NationalInstruments.UI.ComponentDrawArgs(g, bounds));

                e.Graphics.DrawImage(bmp, e.MarginBounds.X, e.MarginBounds.Y);
            }
        }

        private void tbWatermark_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
