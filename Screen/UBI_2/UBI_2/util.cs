using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace UBI_2
{
    class Servercon
    {
        string server_source = "data source = 112.216.144.210,1434;persist security info=true;user id=sa; password=ubi01055392772;initial catalog=UBI_ORDER_REAL";
        
        public static string FTPAdr = "112.216.144.211";
        public static int FTPPort = 21;
        public static string FTPAdrF = "112.216.144.211:21";
        public static string FTPUsername = "iuadmin";
        public static string FTPPassword = "ubi6170";      
        public static string today = Convert.ToDateTime(System.DateTime.Today).ToString("yyyy.MM.dd");
        
        public static SqlConnection conn;       

        public bool ServerCon()
        {
            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection(server_source);
                }

                if (conn.Database != "UBI_ORDER_REAL")
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }

      

        public DataRow[] Search_Col(string PTableN)
        {         
            string select = "select COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH from INFORMATION_SCHEMA.COLUMNS where table_name ='" + PTableN + "'";

            SqlDataAdapter da = new SqlDataAdapter(select, conn);
            DataSet Colds = new DataSet();
            da.Fill(Colds, "CoLName");

            DataRow[] dr_data = Colds.Tables["CoLName"].Select();

            return dr_data;
        }
    }

    class CodeAbout
    {
        public string EMessage = "";
        private SqlConnection conn;
        private  string TableN = "N";

        public bool CodeCreate(SqlConnection Pconn, string pTableN, ref string pRcode)
        {
            EMessage = "Set Conn Error";

            try
            {
                conn = Pconn;
                TableN = pTableN;        

                if (conn == null)
                    return false;

                if (TableN == "N")
                    return false;           

                if (conn.Database != "UBI_ORDER_REAL")
                    return false;
                string DateCode = "";
                DateCode = DateCode + Servercon.today.Substring(2, 2);
                DateCode = DateCode + Servercon.today.Substring(5, 2);
                DateCode = DateCode + "-";

                int LastCode;
                LastCode = GetLastCode(pTableN, DateCode);

                if (LastCode == -1)
                {                  
                    return false;      
                }

                string CreCode = "";
                CreCode = DateCode + LastCode.ToString().Trim().PadLeft(4, '0');

                pRcode = CreCode;
            }
            catch (Exception ex)
            {
                EMessage = ex.ToString();
                return false;
            }

            EMessage = "";
            return true;

        }

        private int GetLastCode(string pTableN,string pDateCode)
        {
            int RLCode = -1;
            try
            {
                string select = "select Max(Code) from _2정보 Where TableN ='" + pTableN + "'";
                select = select + "And Code Like '" + pDateCode + "%'";
                select = select + " Group By TableN";

                SqlDataAdapter da = new SqlDataAdapter(select, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "CoLName");

                DataRow[] dr_data = ds.Tables["CoLName"].Select();

                if (dr_data.Length == 1)
                {
                    string Tempcode = dr_data[0][0].ToString();
                    Tempcode = Tempcode.Substring(5, 4);
                    RLCode = int.Parse(Tempcode);
                    RLCode = RLCode + 1;
                }
                else if (dr_data.Length == 0)
                {
                    RLCode = 1;
                }
                else
                {
                    EMessage = "LastCode Get Fail";
                    RLCode = -1;
                    return RLCode;
                }
            }
            catch (Exception ex)
            {
                EMessage = ex.ToString();
                RLCode = -1;
                return RLCode;
            }

            EMessage = "";
            return RLCode;

           
        }
    }
/*
    class InfoLV_Set
    {
        private ListViewItem item;

        public bool GetAllInformation(string tablename, ListView lv_temp, bool Search_Rev_Op, string SearchWhere)
        {
            try
            {
                lv_temp.Items.Clear();
                string SelectStr = "";

                if (Search_Rev_Op == true)
                {
                    SelectStr = SelectStr + "Select * from _2정보  as tb Where TableN  = '" + tablename + "'" + SearchWhere;
                }
                else
                {
                    SelectStr = SelectStr + "Select tb.* from _2정보 as tb";
                    SelectStr = SelectStr + "             left outer join ( Select TableN AS RTableN, MAX(tb1.ID) AS RID, tb1.Code AS RCode, MAX(tb1.Rev) AS RRev ";
                    SelectStr = SelectStr + "                                   from _2정보 as tb1";
                    SelectStr = SelectStr + "                                     Group by tb1.TableN, tb1.Code) as Stb";
                    SelectStr = SelectStr + "                    On tb.ID = Stb.RID AND tb.TableN = Stb.TableN";
                    SelectStr = SelectStr + "              Where tb.ID = Stb.RID AND tb.TableN  = '" + tablename + "'" + SearchWhere;
                }

                if (!LVColumnsTitle("_2정보", lv_temp))
                {
                    return false;
                }
                if (!query_select_ListView(SelectStr, lv_temp))
                {
                    return false;
                }                
            }
            catch (SystemException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

            return true;
        }

        public void GetHistory(string tablename, string createnum, ListView lv_temp)
        {
            try
            {
                lv_temp.Items.Clear();

                LVColumnsTitle(tablename, lv_temp);
                query_select_ListView("SELECT * FROM " + tablename + " WHERE 발행번호 = '" + createnum + "' ORDER BY 개정번호", lv_temp);
            }
            catch (SystemException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public bool LVColumnsTitle(string tablename, ListView lv_temp)
        {
            try
            {
                string select = "";

                // 선택된 테이블의 COLUMN 정보 가져오기
                select = "select COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH from INFORMATION_SCHEMA.COLUMNS where table_name ='" + tablename + "'";
                
                if (Servercon.conn == null)
                {
                    Servercon sconn = new Servercon();
                    if (!sconn.ServerCon())
                    {
                        MessageBox.Show("서버 접속에 실패하엿습니다.");
                        return false;
                    }
                }  

                SqlDataAdapter da = new SqlDataAdapter(select, Servercon.conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "CoName");

                DataRow[] dr_data = ds.Tables["CoName"].Select();               

                lv_temp.Columns.Clear();

                if (dr_data.Length > 0)
                {
                    for (int i = 0; i < dr_data.Length; i++)
                    {
                        lv_temp.Columns.Add(dr_data[i][0].ToString().Trim(), 100, HorizontalAlignment.Center);

                    }
                }
            }

            catch (System.Exception ehandle)
            {                
                MessageBox.Show(ehandle.Message);
                return false;
            }

            return true;
        }

        public bool LVColumnsTitle_Vertical(string tablename, ListView lv_temp)
        {
            try
            {
                string select = "";

                // 선택된 테이블의 COLUMN 정보 가져오기
                select = "select COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH from INFORMATION_SCHEMA.COLUMNS where table_name ='" + tablename + "'";

                if (Servercon.conn == null)
                {
                    Servercon sconn = new Servercon();
                    if (!sconn.ServerCon())
                    {
                        MessageBox.Show("서버 접속에 실패하엿습니다.");
                        return false;
                    }
                }

                SqlDataAdapter da = new SqlDataAdapter(select, Servercon.conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "CoName");

                DataRow[] dr_data = ds.Tables["CoName"].Select();

                if (dr_data.Length > 0)
                {
                    for (int i = 0; i < dr_data.Length; i++)
                    {
                        item = new ListViewItem(dr_data[i][0].ToString().Trim());                        
                        item.SubItems.Add("    ");
                        lv_temp.Items.Add(item);                      
                    }
                }
            }
            catch (System.Exception ehandle)
            {
                MessageBox.Show(ehandle.Message);
                return false;
            }

            return true;            
        }   

        public bool query_select_ListView(string str_select, ListView lv_temp)
        {
            try
            {               

                if (Servercon.conn == null)
                {
                    Servercon sconn = new Servercon();
                    if (!sconn.ServerCon())
                    {
                        MessageBox.Show("서버 접속에 실패하엿습니다.");
                        return false;
                    }
                }

                SqlDataAdapter da = new SqlDataAdapter(str_select, Servercon.conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "CoName");

                DataRow[] dr_data = ds.Tables["CoName"].Select();               

                if (dr_data.Length > 0)
                {
                    for (int i = 0; i < dr_data.Length; i++)
                    {
                        item = new ListViewItem(dr_data[i][0].ToString().Trim());

                        for (int k = 1; k < lv_temp.Columns.Count; k++)
                        {
                            item.SubItems.Add(dr_data[i][k].ToString().Trim());
                        }

                        lv_temp.Items.Add(item);
                    }

                    lv_temp.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent); // 컨텐츠의 내용에 따라 Column길이의 자동조정
                }
                else
                {
                    lv_temp.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize); // 헤더의 내용에 따라 Column길이의 자동조정
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

            return true;
           
        }
    }


    class TV_Set
    {
        public DataRow[] query_select(string str_select)
        {
            DataRow[] dr_data = null;

            try
            {        
                if (Servercon.conn == null)
                {
                    Servercon sconn = new Servercon();
                    if (!sconn.ServerCon())
                    {
                        MessageBox.Show("서버 접속에 실패하엿습니다.");
                        return dr_data;
                    }
                }

                SqlDataAdapter da = new SqlDataAdapter(str_select, Servercon.conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "CoName");

                dr_data = ds.Tables["CoName"].Select();                
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
                return dr_data;
            }
            return dr_data;
        }

        public void TV_Setting(DataRow[] SetData, TreeView TVtemp,TreeNode SelectNode)
        {

            SelectNode.Nodes.Clear();

            for (int i = 0 ; i <SetData.Length ; i++)
            {
                //SelectNode.Nodes.Add(SetData[i][4].ToString().Trim());
                //SelectNode.Nodes[i].Tag = SetData[i][0].ToString().Trim();
            }

            SelectNode.ExpandAll();

            return;
        }
    }
 * */
}
