using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

using BrightIdeasSoftware;


namespace UBI_2
{
    public partial class Main : IronPanel.InformationPanel
    {       
        public Main()
        {
            InitializeComponent();

            if (Servercon.conn == null)
            {
                Servercon sconn = new Servercon();
                sconn.ServerCon();
            }        
        }

        private void Main_Load(object sender, EventArgs e)
        {          
          
            if (Servercon.conn == null)
            {
                Servercon sconn = new Servercon();
                if (!sconn.ServerCon())
                {
                    MessageBox.Show("서버 접속에 실패하였습니다.");
                    return;
                }
            }
            stlV_UCP.Set_Ftp(Servercon.FTPAdr, Servercon.FTPPort, Servercon.FTPAdrF, Servercon.FTPUsername, Servercon.FTPPassword);
            stlV_UCP.Set_Conn(Servercon.conn, "_2정보", "_2정보_Info", false);
            stlV_UCC.Set_Ftp(Servercon.FTPAdr, Servercon.FTPPort, Servercon.FTPAdrF, Servercon.FTPUsername, Servercon.FTPPassword);
            stlV_UCC.Set_Conn(Servercon.conn, "_2정보", "_2정보_Info", false);
            
            //TLV_P_Search();
            //TLV_C_Search();
        }

        private void TLV_P_Search()
        {
            bool TLV_Res;

            TLV_Res = stlV_UCP.Set_TLV(-1);

            if (TLV_Res == false)
            {
                MessageBox.Show(stlV_UCP.EMessage);
            }         
        
        }

        private void TLV_C_Search()
        {
            bool TLV_Res;

            TLV_Res = stlV_UCC.Set_TLV(-1);

            if (TLV_Res == false)
            {
                MessageBox.Show(stlV_UCC.EMessage);
            }         
        }

        DataSet LoadDatasetFromXml(string fileName)
        {
            DataSet ds = new DataSet();
            FileStream fs = null;

            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new StreamReader(fs))
                {
                    ds.ReadXml(reader);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }

            return ds;
        }  

        private void Input_bt_Click(object sender, EventArgs e)
        {
            Input_Form InputF = new Input_Form();
            InputF.ShowDialog();

            TLV_P_Search();
            TLV_C_Search();
        }    

        private void Node_In_bt_Click(object sender, EventArgs e)
        {
            DataSet Pds = new DataSet();
            Pds = stlV_UCP.Get_Select_ID();
            DataSet Cds = new DataSet();
            Cds = stlV_UCC.Get_Select_ID();


            if (Pds.Tables[0].Rows.Count == 0 || Cds.Tables[0].Rows.Count ==0)
                return;
            SqlTransaction STan;
            if (Servercon.conn.State != System.Data.ConnectionState.Open)
            {
                Servercon.conn.Open();
            }
            STan = Servercon.conn.BeginTransaction();

            try
            {
                string Str_Insert = "";
                Str_Insert = Str_Insert + "  ";

                for (int i = 0; i < Pds.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < Cds.Tables[0].Rows.Count; j++)
                    {
                        Str_Insert = Str_Insert + "Insert Into _2정보_Info (PId,CId,Qty) Values ";
                        Str_Insert = Str_Insert + " ( " + Pds.Tables[0].Rows[i]["Id"].ToString().Trim();
                        Str_Insert = Str_Insert + " , " + Cds.Tables[0].Rows[j]["Id"].ToString().Trim();
                        Str_Insert = Str_Insert + " , 1) ";

                        if (j < Cds.Tables[0].Rows.Count - 1)
                        {
                            Str_Insert = Str_Insert + "; ";
                        }
                    }

                    if (i < Pds.Tables[0].Rows.Count - 1)
                    {
                        Str_Insert = Str_Insert + "; ";
                    }
                }
               

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

            TLV_P_Search();
            TLV_C_Search();

        }

        private void DataImport_bt_Click(object sender, EventArgs e)
        {
            DataImport DataImportF = new DataImport();
            DataImportF.ShowDialog();
        }

        private void CSearch_bt_Click(object sender, EventArgs e)
        {
            TLV_C_Search();
        }

        private void PSearch_bt_Click(object sender, EventArgs e)
        {
            TLV_P_Search();
        }

        private void DeleteP_bt_Click(object sender, EventArgs e)
        {
            bool TLV_Res;

            TLV_Res = stlV_UCP.Item_Delete();

            if (TLV_Res == false)
            {
                MessageBox.Show(stlV_UCP.EMessage);
            }         
        }

        private void Node_DeleteP_bt_Click(object sender, EventArgs e)
        {
            bool TLV_Res;

            TLV_Res = stlV_UCP.Node_Delete();

            if (TLV_Res == false)
            {
                MessageBox.Show(stlV_UCP.EMessage);
            }      
        }

        private void DeleteC_bt_Click(object sender, EventArgs e)
        {
            bool TLV_Res;

            TLV_Res = stlV_UCC.Item_Delete();

            if (TLV_Res == false)
            {
                MessageBox.Show(stlV_UCC.EMessage);
            }
        }

        private void Node_DeleteC_bt_Click(object sender, EventArgs e)
        {
            bool TLV_Res;

            TLV_Res = stlV_UCC.Node_Delete();

            if (TLV_Res == false)
            {
                MessageBox.Show(stlV_UCC.EMessage);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //using (Ftp Ftpclient = new Ftp())
            //{
               // client.Connect(Servercon.FTPAdr,21);
               // client.Login(Servercon.FTPUsername, Servercon.FTPPassword);

               // // Upload the 'test.zip' file to the current folder on the server 
               //// client.Upload("test.zip", @"c:\test.zip");
               // string[] SelFilePath;
               // string[] UpFilePath;
               // string[] SelFile;
               // OpenFileDialog OFDUpfile = new OpenFileDialog();
               // OFDUpfile.InitialDirectory = @"c:";
               // OFDUpfile.Multiselect = true;
               // OFDUpfile.ShowDialog();

               // SelFilePath = OFDUpfile.FileNames;
               // UpFilePath = SelFilePath;
               // if (!client.FolderExists("test2"))
               //     client.CreateFolder("test2");
               // // Upload the 'index.html' file to the specified folder on the server 

               // for (int i = 0; i < SelFilePath.Length; i++)
               // {
               //     UpFilePath[i].Replace("\\", "+");
               //     SelFile = UpFilePath[i].Split('+');
               //     client.Upload(@"test2/"+SelFile[SelFile.Length-1], @SelFilePath[i]);
               // }
               // // Download the 'test.zip' file from the current folder on the server 
               // //client.Download("test.zip", @"c:\test2.zip");

               // // Download the 'index.html' file from the specified folder on the server 
               // client.Download(@"test2/ubi.xml", @"d:\UBI2.xml");              
               // // upload in memory text 
               // //const string message = "Hello from Ftp.dll";
               // //byte[] data = Encoding.Default.GetBytes(message);
               // //client.Upload("message.txt", data);

               // client.Close();
               
            //}
        }       
    }
}
