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
    public partial class Input_Form : Form
    {

        private DataRow[] dr_data;      

        public Input_Form()
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

                dr_data = sconn.Search_Col("_2정보");
            }
            Input_Clean();
            
        }

        private void Cancle_bt_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void InPut_bt_Click(object sender, EventArgs e)
        {
            string ECMessage = "";
            string CrCode = "";
            bool CheCodeCre = false;
            if (Input_Check(ref ECMessage) == false)
            {
                MessageBox.Show(ECMessage);
                return;
            }

            CodeAbout CodeCre = new CodeAbout();
            CheCodeCre = CodeCre.CodeCreate(Servercon.conn, TableN_Tb.Text.ToString().Trim(), ref CrCode);

            if (CheCodeCre == false)
            {
                MessageBox.Show(CodeCre.EMessage);
                return;
            }
            else
            {
                Code_tb.Text = CrCode;
            }

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

                for (int i = 1; i < dr_data.Length; i++)
                {
                    Str_Insert = Str_Insert + dr_data[i][0].ToString().Trim();

                    if (i < dr_data.Length - 1)
                    {
                        Str_Insert = Str_Insert + ", ";
                    }
                }

                Str_Insert = Str_Insert + " ) ";
                Str_Insert = Str_Insert + "  Values ( '" + TableN_Tb.Text.ToString().Trim() + "'";
                Str_Insert = Str_Insert + "         ,  " + Sid_tb.Text.ToString().Trim();
                Str_Insert = Str_Insert + "         , '" + Code_tb.Text.ToString().Trim() + "'";
                Str_Insert = Str_Insert + "         , '" + Rev_tb.Text.ToString().Trim() + "'";
                Str_Insert = Str_Insert + "         , '" + Title_tb.Text.ToString().Trim() + "'";

                string str_Date = WriteDate_dtp.Value.ToString("yyyy-MM-dd");

                Str_Insert = Str_Insert + "         , '" + str_Date + "'";

                Str_Insert = Str_Insert + "         , '" + Writer_tb.Text.ToString().Trim() + "'";
                Str_Insert = Str_Insert + "         , '" + Path_tb.Text.ToString().Trim() + "'";
                Str_Insert = Str_Insert + "         , ''";
                Str_Insert = Str_Insert + "         )";

                SqlCommand SCom = new SqlCommand(Str_Insert, Servercon.conn);

                SCom.Transaction = STan;

                SCom.ExecuteNonQuery();


                STan.Commit();               
                
            }
            catch(Exception ex)
            {
                STan.Rollback();
                string EMessage = ex.ToString();
                MessageBox.Show("오류로 인하여 입력이 취소되었습니다.");
            }
            Input_Clean();
            Servercon.conn.Close();

        }

        private bool Input_Check(ref string pEMessage)
        {
            try
            {
                int TSid = int.Parse(Sid_tb.Text.ToString().Trim());                
            }
            catch
            {
                pEMessage = "Sid 값이 잘 못 되었습니다.";
                return false;
            }

            if (TableN_Tb.Text == "")
            {
                pEMessage = "TableN 값이 잘 못 되었습니다.";
                return false;
            }
            return true;
        }

        private void Input_Clean()
        {
            TableN_Tb.Text = "";
            Sid_tb.Text = "";
            Code_tb.Text = "";
            Rev_tb.Text = "";
            Title_tb.Text = "";
            WriteDate_dtp.Value = DateTime.Now;
            Writer_tb.Text = "";
            Path_tb.Text = "";
        }
    }
}
