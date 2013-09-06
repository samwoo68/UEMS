using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb; 

using System.IO;                // 파일 첨부
using System.Configuration;
using ADOX;


namespace OperationScreen
{
    public partial class OperationScreen : IronPanel.InformationPanel
    {
        //IronControls.FunctionManager watch = new IronControls.FunctionManager("Watch");

        int i = 0;

        Form1 f = null;   // for external screen

        int[] handle = new int[10];

        public OperationScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //watch.Start();
        }
        public override void StartPanel(string name)
        {
            //base.StartPanel(name);
            ironSANClient1.ProjectPath = this.ProjectPath;
            ironSANClient1.Connect();

            opcClient1.Connect();
            //adsClient1.Connect();

            f = new Form1(ProjectPath);
            f.Show();


            //handle[0] = opcClient1.Subscribe("io", CommLib.UpdateMode.OnChange, 0, CallBack);
            //handle[1] = opcClient1.Subscribe("Channel1.EEMS-R1.wINGOT", CommLib.UpdateMode.Cyclic, 60000, CallBack);

            //flashBox1.SetMovie(ProjectPath + "Flash\\Top_lamp.swf");
            //flashBox1.Subscribe();
        }

        public override void StopPanel()
        {
            opcClient1.Unsubscribe(handle[0]);
            opcClient1.Unsubscribe(handle[1]);

            ironSANClient1.Disconnect();
            opcClient1.Disconnect();
            //adsClient1.Disconnect();
        }

        public void CallBack(int notificationID, object[] values)
        {
            if (notificationID == handle[0])
            {
                try
                {
                    bool data = bool.Parse(values[0].ToString());

                    if (data)
                    {
                    }
                }
                catch
                {
                    
                }
            }
            else if (notificationID == handle[1])
            {
                DateTime n = (DateTime)values[1];

                //listBox1.Items.Add(values[1].ToString() + ":" + values[0].ToString());
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            //digitalBox1.WriteData();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            //digitalBox1.UpdateData();
        }

        private void analogBox1_Load(object sender, EventArgs e)
        {

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckAlarm(100) != IronPanel._AlarmStatus.Alarm && ironSANClient1.ReadAny("DI.TestDriver.DI1") == "1")
            {
                FireAlarm(100);
            }

            //if (ironSANClient1.ReadAny("AO.TestDriver.AO01") == "0")   
            
            i++;

            for (int j = 1; j <= 30; j++)
            {
                ironSANClient1.WriteData("AO.TestDriver.AO" + j.ToString("D2"), i % 100);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //timer2.Enabled = false;

            //if (ledOnly1.Location.X > 1000)
            //    ledOnly1.Location = new System.Drawing.Point(0, 200);
            //else
            //    ledOnly1.Location = new System.Drawing.Point(ledOnly1.Location.X + ((i / 100) % 100), 200);

            //timer2.Enabled = true;
        }

        public static bool CreateDatabase(string fullFilename)
        {
            bool succeeded = false;
            try
            {
                ADOX._Catalog PostDB = new ADOX.Catalog();
                PostDB.Create("Provider=Microsoft.Jet.OLEDB.4.0;" +
                    "Data Source=" + fullFilename + ";" +
                    "Jet OLEDB:Engine Type=5");
                PostDB = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not create database file: " + fullFilename + "\n\n" + ex.Message, "Database Creation Error");
            }
            return succeeded;
        }

        public static bool CreateTable(string fullFilename)
        {            
            // 만들어진 데이터베이스 오픈 
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename );
            try
            {
                conn.Open();

                //   // 테이블 생성 및 컬럼 생성 
                string strSQL;
                strSQL = "CREATE TABLE PostListTB " +
                        //"(Col_Num int identity, Col_Name varchar(10), Col_Relations varchar(8), " +
                        //"CONSTRAINT PostListTB_PrimaryKey PRIMARY KEY (Col_Name))";

                        "(번호 int identity, 이름 varchar(10), 누적값 varchar(8), " +
                        "CONSTRAINT PostListTB_PrimaryKey PRIMARY KEY (번호))";
                OleDbCommand comm = new OleDbCommand(strSQL, conn);
                comm.ExecuteNonQuery();
                comm = null;
            }
            catch (Exception) //(Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
            finally
            {   
                conn.Close();
                conn = null;
            }
            return true;
        }

        public static bool DropTable(string fullFilename, string tablename)
        {
            // 만들어진 데이터베이스 오픈 
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename);
            try
            {
                conn.Open();

                //   // 테이블 생성 및 컬럼 생성 
                string strSQL;
                strSQL = "DROP TABLE " + tablename;
                OleDbCommand comm = new OleDbCommand(strSQL, conn);
                comm.ExecuteNonQuery();
                comm = null;
            }
            catch (Exception) //(Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
            finally
            {
                conn.Close();
                conn = null;
            }
            return true;
        }


        private void digitalBox3_Load(object sender, EventArgs e)
        {

        }

        private void flashBox1_Load(object sender, EventArgs e)
        {

        }

        private void digitalBox1_Load(object sender, EventArgs e)
        {

        }

        private void digitalBox2_Load(object sender, EventArgs e)
        {

        }

        private void userControl12_Load(object sender, EventArgs e)
        {

        }

        private void ledOnly1_Load(object sender, EventArgs e)
        {

        }

        private void userControl13_Load(object sender, EventArgs e)
        {

        }

        private void ledOnButton1_Load(object sender, EventArgs e)
        {

        }

        private void ledOnly3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CreateDatabase("C:\\Dropbox\\UBI-PROJECTS\\test.mdb");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateTable("C:\\Dropbox\\UBI-PROJECTS\\test.mdb");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ledOnly4_Load(object sender, EventArgs e)
        {

        }

        private void TrainScreen_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DropTable("C:\\Dropbox\\UBI-PROJECTS\\test.mdb", "PostListTB");
        }
    }
}
