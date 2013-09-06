using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UBI_2
{
    public partial class DataImport : Form
    {
        public DataImport()
        {
            InitializeComponent();

            if (Servercon.conn == null)
            {
                Servercon sconn = new Servercon();
                if (!sconn.ServerCon())
                {
                    MessageBox.Show("서버 접속에 실패하엿습니다.");
                    return;
                }                
            }           
        }

        private void Part_Imp_Info_bt_Click(object sender, EventArgs e)
        {
            SqlTransaction STan;
            if (Servercon.conn.State != System.Data.ConnectionState.Open)
            {
                Servercon.conn.Open();
            }
            STan = Servercon.conn.BeginTransaction();

            try
            {
                string Str_Insert = "";
                Str_Insert = Str_Insert + "Insert Into _2정보 ( ";
                Str_Insert = Str_Insert + "  TableN, SID, Code, Rev, 제목, 작성일, 작성자, Path ) ";
                Str_Insert = Str_Insert + " Select ";
                Str_Insert = Str_Insert + " '부품명세서', ID, 부품코드, 0, 부품명, 등록일, 등록자코드, FileList ";
                Str_Insert = Str_Insert + " From 부품명세서 ";
                
                SqlCommand SCom = new SqlCommand(Str_Insert, Servercon.conn);

                SCom.Transaction = STan;

                SCom.ExecuteNonQuery();


                STan.Commit();

            }
            catch (Exception ex)
            {
                STan.Rollback();
                string EMessage = ex.ToString();
                MessageBox.Show("오류로 인하여 입력이 취소되었습니다.");
            }
           
            Servercon.conn.Close();
        }

        private void PartTree_Imp_Info_bt_Click(object sender, EventArgs e)
        {
            string[] Cid;
            string[] CidItem;
            string Pid;
            string Info_Cid;
            string select = "select ID, 부품목록 from 부품명세서 ";

            SqlDataAdapter da = new SqlDataAdapter(select, Servercon.conn);
            DataSet Partds = new DataSet();
            da.Fill(Partds, "CoLName");

            select = "select ID, SID from _2정보 Where TableN = '부품명세서'";

            da = new SqlDataAdapter(select, Servercon.conn);
            DataSet Infods = new DataSet();            
            da.Fill(Infods, "CoLName");

            DataRow[] InfoPIDdr;
            DataRow[] InfoCIDdr;            

            if (Servercon.conn.State != System.Data.ConnectionState.Open)
            {
                Servercon.conn.Open();
            }

            SqlTransaction STan;
            STan = Servercon.conn.BeginTransaction();
            //STan.Commit();
            try
            {  
                string Str_Insert = "";

                for (int i = 0; i < Partds.Tables[0].Rows.Count; i++)
                {                    
                    Cid = Partds.Tables[0].Rows[i][1].ToString().Split(':');

                    if (Cid.Length > 1)
                    {

                        if (Cid.Length > 2)
                        {
                            //MessageBox.Show("2개짜리");
                        }

                        InfoPIDdr = Infods.Tables[0].Select("SID = " + Partds.Tables[0].Rows[i][0].ToString());
                        if (InfoPIDdr.Length != 1)
                        {
                            MessageBox.Show("PID 검색 실패 (" + Partds.Tables[0].Rows[i][0].ToString() + ")");
                            STan.Rollback();
                            return;
                        }
                        else
                        {
                            Pid = InfoPIDdr[0][0].ToString();
                        }

                        Str_Insert = "";

                        for (int j = 1; j < Cid.Length; j++)
                        {
                            CidItem = Cid[j].Split(',');

                            InfoCIDdr = Infods.Tables[0].Select("SID = " + CidItem[0]);
                            if (InfoCIDdr.Length != 1)
                            {
                                MessageBox.Show("CID 검색 실패 (" + CidItem[0] + ")");
                                STan.Rollback();
                                return;
                            }
                            else
                            {
                                Info_Cid = InfoCIDdr[0][0].ToString();
                            }
                            
                            Str_Insert = Str_Insert + "Insert Into _2정보_Info ( ";
                            Str_Insert = Str_Insert + "  PID, CID, Qty ) ";
                            Str_Insert = Str_Insert + " Values ";
                            Str_Insert = Str_Insert + " ( " + Pid ;
                            Str_Insert = Str_Insert + " , " + Info_Cid;
                            Str_Insert = Str_Insert + " , " + CidItem[1];
                            Str_Insert = Str_Insert + " ) ; ";                                                        
                        }

                        //STan = Servercon.conn.BeginTransaction();

                        SqlCommand SCom = new SqlCommand(Str_Insert, Servercon.conn);

                        SCom.Transaction = STan;

                        SCom.ExecuteNonQuery();

                        
                    }
                }

                STan.Commit();                

            }
            catch (Exception ex)
            {
                STan.Rollback();
                string EMessage = ex.ToString();
                MessageBox.Show("오류로 인하여 입력이 취소되었습니다.");
            }

            Servercon.conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlTransaction STan;
            if (Servercon.conn.State != System.Data.ConnectionState.Open)
            {
                Servercon.conn.Open();
            }
            STan = Servercon.conn.BeginTransaction();

            try
            {
                
                string Str_Insert = "";
                Str_Insert = Str_Insert + "Insert Into _2정보_Info ( ";
                Str_Insert = Str_Insert + "  PID, CID, Qty ) ";
                Str_Insert = Str_Insert + " Select ";
                Str_Insert = Str_Insert + " '3602', tb.ID, '0' ";
                Str_Insert = Str_Insert + " From _2정보 AS tb  ";
                Str_Insert = Str_Insert + " Left Outer join _2정보_Info AS tb2 On tb.ID =  tb2.CID ";
                Str_Insert = Str_Insert + " Where ISNull(tb2.CID,0) = 0";

                SqlCommand SCom = new SqlCommand(Str_Insert, Servercon.conn);

                SCom.Transaction = STan;

                SCom.ExecuteNonQuery();

            
                STan.Commit();

            }
            catch (Exception ex)
            {
                STan.Rollback();
                string EMessage = ex.ToString();
                MessageBox.Show("오류로 인하여 입력이 취소되었습니다.");
            }

            Servercon.conn.Close();
        }

        private void CodeConvert_bt_Click(object sender, EventArgs e)
        {

            string select = "select ID from _2정보 Where TableN = '부품명세서'";

            SqlDataAdapter da = new SqlDataAdapter(select, Servercon.conn);
            DataSet Infods = new DataSet();
            da.Fill(Infods, "CoLName");

            SqlTransaction STan;
            if (Servercon.conn.State != System.Data.ConnectionState.Open)
            {
                Servercon.conn.Open();
            }
            STan = Servercon.conn.BeginTransaction();

            try
            {
                for (int i = 0; i < Infods.Tables[0].Rows.Count; i++)
                {
                    string Str_Update = "";
                    Str_Update = Str_Update + "Update _2정보 Set ";
                    Str_Update = Str_Update + "  Code =  '";

                    string ConvCode = "1301-" + Infods.Tables[0].Rows[i][0].ToString().Trim().PadLeft(4, '0');

                    Str_Update = Str_Update + ConvCode;
                    Str_Update = Str_Update + "' where ID = ";
                    Str_Update = Str_Update + Infods.Tables[0].Rows[i][0].ToString().Trim();
                    Str_Update = Str_Update + " AND TableN = '부품명세서';";  
 
                    SqlCommand SCom = new SqlCommand(Str_Update, Servercon.conn);

                    SCom.Transaction = STan;

                    SCom.ExecuteNonQuery();
                }

                STan.Commit();

            }
            catch (Exception ex)
            {
                STan.Rollback();
                string EMessage = ex.ToString();
                MessageBox.Show("오류로 인하여 입력이 취소되었습니다.");
            }

            Servercon.conn.Close();
        }
    }
}
