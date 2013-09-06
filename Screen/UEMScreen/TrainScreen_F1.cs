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


namespace UEMScreen
{
    public partial class TrainScreen_F1 : IronPanel.InformationPanel
    {
        #region Screen Initialize
        //IronControls.FunctionManager watch = new IronControls.FunctionManager("Watch");

       // ExtMonitor f = null;   // for external screen        

        int[] diHandle = new int[200];

        // alarm 구현
        //int[] alarmHandle = new int[200];

        ////온도 설정form
        TempSet Temp_Set;// = new TempSet();

        public TrainScreen_F1()
        {
            InitializeComponent();
        }
        #endregion



        #region Start and stop panel

        public override void StartPanel(string name)
        {
            //base.StartPanel(name);
            ironSANClient1.ProjectPath = this.ProjectPath;
            ironSANClient1.Connect();

            //opcClient1.Connect();  // KEPWARE
            opcClient2.Connect();  // OPC-HUB
            adsClient1.Connect();   //TwinCAT

            //f = new ExtMonitor(ProjectPath);
            //f.Show();

            //온도 설정form
            Temp_Set = new TempSet();

            //AlarmTagEventConfig();
            //TagEventConfig();
            

            //FLASH CONTROL
            //flashBox1.SetMovie(ProjectPath + "Flash\\Top_lamp.swf");
            //flashBox1.Subscribe();


            DateTime bdt = DateTime.Today; // periodic logging time init.
            //CreateMDB("C:\\Dropbox\\UBI-PROJECTS\\test.mdb");
            //CreateMDBTables();

            //flashBox1.SetMovie(ProjectPath + "\\Flash\\Top_Lamp.swf");
            //flashBox1.Subscribe();

            //fbElevator1.Subscribe();
        }

        public override void StopPanel()
        {
            //flashBox1.Unsubscribe();
            //fbElevator1.Unsubscribe();

            //AlarmTagEventFree();
            //TagEventFree();

            ironSANClient1.Disconnect();
            //opcClient1.Disconnect();
            opcClient2.Disconnect();
            adsClient1.Disconnect();
        }

        public override void ShowPanel(string user, int level)
        {
            opcClient2.ItemUpdate = true;
        }

        public override void HidePanel()
        {
            opcClient2.ItemUpdate = false;
        }

        #endregion

        #region Signal Event and Callback(Handler) Config. 

        private void TagEventConfig()
        {
            //diHandle[0] = opcClient2.Subscribe("PLC-XGK:M00904", CommLib.UpdateMode.OnChange, 1000, Callback_TagEvent);   // Fire1 image
            //diHandle[1] = opcClient2.Subscribe("PLC-XGK:M00910", CommLib.UpdateMode.OnChange, 1000, Callback_TagEvent);  // Fire2 image
            //diHandle[2] = opcClient2.Subscribe("PLC-XGK:M00915", CommLib.UpdateMode.OnChange, 1000, Callback_TagEvent);  // Fire3 image

            //diHandle[3] = opcClient2.Subscribe("PLC-XGK:M00551", CommLib.UpdateMode.OnChange, 1000, Callback_TagEvent);  // scrap weight send bit
            //diHandle[4] = opcClient2.Subscribe("PLC-XGK:M00651", CommLib.UpdateMode.OnChange, 1000, Callback_TagEvent);  // Ingot weight send bit

            //diHandle[5] = opcClient1.Subscribe("Channel1.EEMS-M1.R2002", CommLib.UpdateMode.OnChange, 1000, Callback_TagEvent);  // Ingot weight1 send Data
            //diHandle[5] = opcClient2.Subscribe("PLC-XGK:D00624", CommLib.UpdateMode.OnChange, 1000, Callback_TagEvent);  // Ingot weight1 send Data
            //diHandle[6] = opcClient2.Subscribe("PLC-XGK:D00623", CommLib.UpdateMode.OnChange, 1000, Callback_TagEvent);  // Ingot weight2 send Data
            //diHandle[7] = opcClient2.Subscribe("PLC-XGK:D00622", CommLib.UpdateMode.OnChange, 1000, Callback_TagEvent);  // Ingot weight3 send Data
            //diHandle[8] = opcClient2.Subscribe("PLC-XGK:D00621", CommLib.UpdateMode.OnChange, 1000, Callback_TagEvent);  // Ingot weight4 send Data
        }

        private void TagEventFree()
        {
            //opcClient2.Unsubscribe(diHandle[0]);    // Fire1 image
            //opcClient2.Unsubscribe(diHandle[1]);    // Fire1 image
            //opcClient2.Unsubscribe(diHandle[2]);    // Fire1 image

            //opcClient2.Unsubscribe(diHandle[3]);    // scrap weight send bit
            //opcClient2.Unsubscribe(diHandle[4]);    // Ingot weight send bit

            //opcClient2.Unsubscribe(diHandle[5]);    // Ingot weight1 send Data
            //opcClient2.Unsubscribe(diHandle[6]);    // Ingot weight2 send Data
            //opcClient2.Unsubscribe(diHandle[7]);    // Ingot weight3 send Data
            //opcClient2.Unsubscribe(diHandle[8]);    // Ingot weight4 send Data

        }

        private void Callback_TagEvent(int notificationID, object[] value)
        {

            try
            {
                //double data = double.Parse(value[0].ToString());

                //if (notificationID == diHandle[5])  // scrap weight send bit
                //{
                //    if (data < 1)
                //    {
                //        analogBox9.Visible = false;
                //        imageOnOffUnknownAndTimer7.Visible = false;
                //    }
                //    else
                //    {
                //        analogBox9.Visible = true;
                //        imageOnOffUnknownAndTimer7.Visible = true;
                //    }

                //}
                //else if (notificationID == diHandle[6])  // scrap weight send bit
                //{
                //    if (data < 1)
                //    {
                //        analogBox10.Visible = false;
                //        imageOnOffUnknownAndTimer8.Visible = false;
                //    }
                //    else
                //    {
                //        analogBox10.Visible = true;
                //        imageOnOffUnknownAndTimer8.Visible = true;
                //    }

                //} 
                //else if (notificationID == diHandle[7])  // scrap weight send bit
                //{
                //    if (data < 1)
                //    {
                //        analogBox11.Visible = false;
                //        imageOnOffUnknownAndTimer9.Visible = false;
                //    }
                //    else
                //    {
                //        analogBox11.Visible = true;
                //        imageOnOffUnknownAndTimer9.Visible = true;
                //    }

                //}
                //else if (notificationID == diHandle[8])  // scrap weight send bit
                //{
                //    if (data < 1)
                //    {
                //        analogBox12.Visible = false;
                //        imageOnOffUnknownAndTimer10.Visible = false;
                //    }
                //    else
                //    {
                //        analogBox12.Visible = true;
                //        imageOnOffUnknownAndTimer10.Visible = true;
                //    }
                //}

                //if (notificationID == diHandle[0])  // Fire1 image
                //{
                //    if (data) pB_Fire1.Visible = true;
                //    else pB_Fire1.Visible = false;
                //}
                //else if (notificationID == diHandle[1])  // Fire2 image
                //{
                //    if (data) pB_Fire2.Visible = true;
                //    else pB_Fire2.Visible = false;
                //}
                //else if (notificationID == diHandle[2])  // Fire3 image
                //{
                //    if (data) pB_Fire3.Visible = true;
                //    else pB_Fire3.Visible = false;
                //}
                //else                

                //if (notificationID == diHandle[3])  // scrap weight send bit
                //{
                //    int id514 = Convert.ToInt16(opcClient2.ReadAny("PLC-XGK:D00514"));
                //    int id625 = Convert.ToInt16(opcClient2.ReadAny("PLC-XGK:D00625"));


                //    MDB_ExecuteNonQuery("INSERT INTO LOG_SCRAP_MEAS (시스템시간, 작업일자, 작업시간, 이름, 계량기값, 단위사용량, 적산사용량)  VALUES ( '"
                //        + ndt.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + wdt.ToString("yyyy-MM-dd") + "', '" + wdt.ToString("yyyy-MM-dd HH:mm:ss") + "', '시험계량S',"
                //        + id514 + "," + id514 + "," + id514 + ")");
                //    MDB_ExecuteNonQuery("INSERT INTO LOG_INGOT_MEAS (시스템시간, 작업일자, 작업시간, 이름, 계량기값, 단위사용량, 적산사용량)  VALUES ( '"
                //        + ndt.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + wdt.ToString("yyyy-MM-dd") + "', '" + wdt.ToString("yyyy-MM-dd HH:mm:ss") + "', '시험계량I',"
                //        + id625 + "," + id625 + "," + id625 + ")");
                //}
                //else if (notificationID == diHandle[4]) // Ingot weight send bit
                //{
                //}

                


            }
            catch
            {
            }
        }

        // ALARM CONTROL
        //private void AlarmTagEventConfig()
        //{
        //    // Digital OnChange alarm
        //    alarmHandle[0] = opcClient2.Subscribe("PLC-XGK:M00500", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[1] = opcClient2.Subscribe("PLC-XGK:M00501", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[2] = opcClient2.Subscribe("PLC-XGK:M00502", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[3] = opcClient2.Subscribe("PLC-XGK:M00503", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[4] = opcClient2.Subscribe("PLC-XGK:M00504", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);

        //    alarmHandle[5] = opcClient2.Subscribe("PLC-XGK:M00505", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[6] = opcClient2.Subscribe("PLC-XGK:M00506", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[7] = opcClient2.Subscribe("PLC-XGK:M00507", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[8] = opcClient2.Subscribe("PLC-XGK:M00508", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[9] = opcClient2.Subscribe("PLC-XGK:M00509", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);

        //    alarmHandle[10] = opcClient2.Subscribe("PLC-XGK:M0050A", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[11] = opcClient2.Subscribe("PLC-XGK:M0050B", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[12] = opcClient2.Subscribe("PLC-XGK:M0050C", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[13] = opcClient2.Subscribe("PLC-XGK:M0050D", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[14] = opcClient2.Subscribe("PLC-XGK:M0050E", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);

        //    alarmHandle[15] = opcClient2.Subscribe("PLC-XGK:M0050F", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[16] = opcClient2.Subscribe("PLC-XGK:M00510", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[17] = opcClient2.Subscribe("PLC-XGK:M00511", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[18] = opcClient2.Subscribe("PLC-XGK:M00512", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    //alarmHandle[19] = opcClient2.Subscribe("PLC-XGK:M00513", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);

        //    alarmHandle[20] = opcClient2.Subscribe("PLC-XGK:M00514", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[21] = opcClient2.Subscribe("PLC-XGK:M00515", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[22] = opcClient2.Subscribe("PLC-XGK:M00516", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    //alarmHandle[23] = opcClient2.Subscribe("PLC-XGK:M00517", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[24] = opcClient2.Subscribe("PLC-XGK:M00518", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);

        //    alarmHandle[25] = opcClient2.Subscribe("PLC-XGK:M00519", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[26] = opcClient2.Subscribe("PLC-XGK:M0051A", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[27] = opcClient2.Subscribe("PLC-XGK:M0051B", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[28] = opcClient2.Subscribe("PLC-XGK:M0051C", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[29] = opcClient2.Subscribe("PLC-XGK:M0051D", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);

        //    alarmHandle[30] = opcClient2.Subscribe("PLC-XGK:M0051E", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[31] = opcClient2.Subscribe("PLC-XGK:M0051F", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[32] = opcClient2.Subscribe("PLC-XGK:M00520", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[33] = opcClient2.Subscribe("PLC-XGK:M00521", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[34] = opcClient2.Subscribe("PLC-XGK:M00522", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);

        //    alarmHandle[35] = opcClient2.Subscribe("PLC-XGK:M00523", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[36] = opcClient2.Subscribe("PLC-XGK:M00524", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[37] = opcClient2.Subscribe("PLC-XGK:M00525", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    //alarmHandle[38] = opcClient2.Subscribe("PLC-XGK:M00526", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[39] = opcClient2.Subscribe("PLC-XGK:M00527", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);

        //    alarmHandle[40] = opcClient2.Subscribe("PLC-XGK:M00528", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[41] = opcClient2.Subscribe("PLC-XGK:M00529", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[42] = opcClient2.Subscribe("PLC-XGK:M0052A", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[43] = opcClient2.Subscribe("PLC-XGK:M0052B", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[44] = opcClient2.Subscribe("PLC-XGK:M0052C", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);

        //    alarmHandle[45] = opcClient2.Subscribe("PLC-XGK:M0052D", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[46] = opcClient2.Subscribe("PLC-XGK:M0052E", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[47] = opcClient2.Subscribe("PLC-XGK:M0052F", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[48] = opcClient2.Subscribe("PLC-XGK:M00530", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[49] = opcClient2.Subscribe("PLC-XGK:M00531", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);

        //    alarmHandle[50] = opcClient2.Subscribe("PLC-XGK:M00532", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[51] = opcClient2.Subscribe("PLC-XGK:M00533", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    alarmHandle[52] = opcClient2.Subscribe("PLC-XGK:M00534", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);

        //    alarmHandle[53] = opcClient2.Subscribe("PLC-XGK:M00539", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
        //    // Watch alarm ??
        //    //handle[100] = opcClient1.Subscribe("PLC-XGK:D00625", CommLib.UpdateMode.Cyclic, 60000, CallBack);
        //}

        //private void AlarmTagEventFree()
        //{
            
        //    opcClient2.Unsubscribe(alarmHandle[0]);
        //    opcClient2.Unsubscribe(alarmHandle[1]);
        //    opcClient2.Unsubscribe(alarmHandle[2]);
        //    opcClient2.Unsubscribe(alarmHandle[3]);
        //    opcClient2.Unsubscribe(alarmHandle[4]);
        //    opcClient2.Unsubscribe(alarmHandle[5]);
        //    opcClient2.Unsubscribe(alarmHandle[6]);
        //    opcClient2.Unsubscribe(alarmHandle[7]);
        //    opcClient2.Unsubscribe(alarmHandle[8]);
        //    opcClient2.Unsubscribe(alarmHandle[9]);
        //    opcClient2.Unsubscribe(alarmHandle[10]);
        //    opcClient2.Unsubscribe(alarmHandle[11]);
        //    opcClient2.Unsubscribe(alarmHandle[12]);
        //    opcClient2.Unsubscribe(alarmHandle[13]);
        //    opcClient2.Unsubscribe(alarmHandle[14]);
        //    opcClient2.Unsubscribe(alarmHandle[15]);
        //    opcClient2.Unsubscribe(alarmHandle[16]);
        //    opcClient2.Unsubscribe(alarmHandle[17]);
        //    opcClient2.Unsubscribe(alarmHandle[18]);
        //    //opcClient1.Unsubscribe(alarmHandle[19]);
        //    opcClient2.Unsubscribe(alarmHandle[20]);
        //    opcClient2.Unsubscribe(alarmHandle[21]);
        //    opcClient2.Unsubscribe(alarmHandle[22]);
        //    //opcClient1.Unsubscribe(alarmHandle[23]);
        //    opcClient2.Unsubscribe(alarmHandle[24]);
        //    opcClient2.Unsubscribe(alarmHandle[25]);
        //    opcClient2.Unsubscribe(alarmHandle[26]);
        //    opcClient2.Unsubscribe(alarmHandle[27]);
        //    opcClient2.Unsubscribe(alarmHandle[28]);
        //    opcClient2.Unsubscribe(alarmHandle[29]);
        //    opcClient2.Unsubscribe(alarmHandle[30]);
        //    opcClient2.Unsubscribe(alarmHandle[31]);
        //    opcClient2.Unsubscribe(alarmHandle[32]);
        //    opcClient2.Unsubscribe(alarmHandle[33]);
        //    opcClient2.Unsubscribe(alarmHandle[34]);
        //    opcClient2.Unsubscribe(alarmHandle[35]);
        //    opcClient2.Unsubscribe(alarmHandle[36]);
        //    opcClient2.Unsubscribe(alarmHandle[37]);
        //    //opcClient1.Unsubscribe(alarmHandle[38]);
        //    opcClient2.Unsubscribe(alarmHandle[39]);
        //    opcClient2.Unsubscribe(alarmHandle[40]);
        //    opcClient2.Unsubscribe(alarmHandle[41]);
        //    opcClient2.Unsubscribe(alarmHandle[42]);
        //    opcClient2.Unsubscribe(alarmHandle[43]);
        //    opcClient2.Unsubscribe(alarmHandle[44]);
        //    opcClient2.Unsubscribe(alarmHandle[45]);
        //    opcClient2.Unsubscribe(alarmHandle[46]);
        //    opcClient2.Unsubscribe(alarmHandle[47]);
        //    opcClient2.Unsubscribe(alarmHandle[48]);
        //    opcClient2.Unsubscribe(alarmHandle[49]);
        //    opcClient2.Unsubscribe(alarmHandle[50]);
        //    opcClient2.Unsubscribe(alarmHandle[51]);
        //    opcClient2.Unsubscribe(alarmHandle[52]);
        //    opcClient2.Unsubscribe(alarmHandle[53]);
           

        //    //opcClient2.Unsubscribe(alarmHandle[100]);
        //}

        // alarm 구현
        //private void CallBack_AlarmTagEvent(int notificationID, object[] value)
        //{
        //    try
        //    {
        //        bool data = (bool)value[0];

        //        if (     notificationID == alarmHandle[0] && data) FireAlarm(1000, false);
        //        else if (notificationID == alarmHandle[1] && data) FireAlarm(1001, false);
        //        else if (notificationID == alarmHandle[2] && data) FireAlarm(1002, false);
        //        else if (notificationID == alarmHandle[3] && data) FireAlarm(1003, false);
        //        else if (notificationID == alarmHandle[4] && data) FireAlarm(1004, false);

        //        else if (notificationID == alarmHandle[5] && data) FireAlarm(1005, false);
        //        else if (notificationID == alarmHandle[6] && data) FireAlarm(1006, false);
        //        else if (notificationID == alarmHandle[7] && data) FireAlarm(1007, false);
        //        else if (notificationID == alarmHandle[8] && data) FireAlarm(1008, false);
        //        else if (notificationID == alarmHandle[9] && data) FireAlarm(1009, false);

        //        else if (notificationID == alarmHandle[10] && data) FireAlarm(1010, false);
        //        else if (notificationID == alarmHandle[11] && data) FireAlarm(1011, false);
        //        else if (notificationID == alarmHandle[12] && data) FireAlarm(1012, false);
        //        else if (notificationID == alarmHandle[13] && data) FireAlarm(1013, false);
        //        else if (notificationID == alarmHandle[14] && data) FireAlarm(1014, false);

        //        else if (notificationID == alarmHandle[15] && data) FireAlarm(1015, false);
        //        else if (notificationID == alarmHandle[16] && data) FireAlarm(1016, false);
        //        else if (notificationID == alarmHandle[17] && data) FireAlarm(1017, false);
        //        else if (notificationID == alarmHandle[18] && data) FireAlarm(1018, false);
        //        //else if (notificationID == alarmHandle[19] && data) FireAlarm(1019, false);

        //        else if (notificationID == alarmHandle[20] && data) FireAlarm(1020, false);
        //        else if (notificationID == alarmHandle[21] && data) FireAlarm(1021, false);
        //        else if (notificationID == alarmHandle[22] && data) FireAlarm(1022, false);
        //        //else if (notificationID == alarmHandle[23] && data) FireAlarm(1023, false);
        //        else if (notificationID == alarmHandle[24] && data) FireAlarm(1024, false);

        //        else if (notificationID == alarmHandle[25] && data) FireAlarm(1025, false);
        //        else if (notificationID == alarmHandle[26] && data) FireAlarm(1026, false);
        //        else if (notificationID == alarmHandle[27] && data) FireAlarm(1027, false);
        //        else if (notificationID == alarmHandle[28] && data) FireAlarm(1028, false);
        //        else if (notificationID == alarmHandle[29] && data) FireAlarm(1029, false);

        //        else if (notificationID == alarmHandle[30] && data) FireAlarm(1030, false);
        //        else if (notificationID == alarmHandle[31] && data) FireAlarm(1031, false);
        //        else if (notificationID == alarmHandle[32] && data) FireAlarm(1032, false);
        //        else if (notificationID == alarmHandle[33] && data) FireAlarm(1033, false);
        //        else if (notificationID == alarmHandle[34] && data) FireAlarm(1034, false);

        //        else if (notificationID == alarmHandle[35] && data) FireAlarm(1035, false);
        //        else if (notificationID == alarmHandle[36] && data) FireAlarm(1036, false);
        //        else if (notificationID == alarmHandle[37] && data) FireAlarm(1037, false);
        //        //else if (notificationID == alarmHandle[38] && data) FireAlarm(1038, false);
        //        else if (notificationID == alarmHandle[39] && data) FireAlarm(1039, false);

        //        else if (notificationID == alarmHandle[40] && data) FireAlarm(1040, false);
        //        else if (notificationID == alarmHandle[41] && data) FireAlarm(1041, false);
        //        else if (notificationID == alarmHandle[42] && data) FireAlarm(1042, false);
        //        else if (notificationID == alarmHandle[43] && data) FireAlarm(1043, false);
        //        else if (notificationID == alarmHandle[44] && data) FireAlarm(1044, false);

        //        else if (notificationID == alarmHandle[45] && data) FireAlarm(1045, false);
        //        else if (notificationID == alarmHandle[46] && data) FireAlarm(1046, false);
        //        else if (notificationID == alarmHandle[47] && data) FireAlarm(1047, false);
        //        else if (notificationID == alarmHandle[48] && data) FireAlarm(1048, false);
        //        else if (notificationID == alarmHandle[49] && data) FireAlarm(1049, false);

        //        else if (notificationID == alarmHandle[50] && data) FireAlarm(1050, false);
        //        else if (notificationID == alarmHandle[51] && data) FireAlarm(1051, false);
        //        else if (notificationID == alarmHandle[52] && data) FireAlarm(1052, false);
        //        else if (notificationID == alarmHandle[53] && data) FireAlarm(1053, false);
        //        //else if (notificationID == alarmHandle[48] && data) FireAlarm(0000, false);

        //        else if (notificationID == alarmHandle[0] && (!data)) ClearAlarm(1000, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[1] && (!data)) ClearAlarm(1001, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[2] && (!data)) ClearAlarm(1002, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[3] && (!data)) ClearAlarm(1003, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[4] && (!data)) ClearAlarm(1004, IronPanel._AlarmStatus.Confirm);

        //        else if (notificationID == alarmHandle[5] && (!data)) ClearAlarm(1005, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[6] && (!data)) ClearAlarm(1006, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[7] && (!data)) ClearAlarm(1007, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[8] && (!data)) ClearAlarm(1008, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[9] && (!data)) ClearAlarm(1009, IronPanel._AlarmStatus.Confirm);

        //        else if (notificationID == alarmHandle[10] && (!data)) ClearAlarm(1010, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[11] && (!data)) ClearAlarm(1011, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[12] && (!data)) ClearAlarm(1012, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[13] && (!data)) ClearAlarm(1013, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[14] && (!data)) ClearAlarm(1014, IronPanel._AlarmStatus.Confirm);

        //        else if (notificationID == alarmHandle[15] && (!data)) ClearAlarm(1015, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[16] && (!data)) ClearAlarm(1016, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[17] && (!data)) ClearAlarm(1017, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[18] && (!data)) ClearAlarm(1018, IronPanel._AlarmStatus.Confirm);
        //        //else if (notificationID == alarmHandle[19] && (!data)) ClearAlarm(1019, IronPanel._AlarmStatus.Confirm);

        //        else if (notificationID == alarmHandle[20] && (!data)) ClearAlarm(1020, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[21] && (!data)) ClearAlarm(1021, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[22] && (!data)) ClearAlarm(1022, IronPanel._AlarmStatus.Confirm);
        //        //else if (notificationID == alarmHandle[23] && (!data)) ClearAlarm(1023, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[24] && (!data)) ClearAlarm(1024, IronPanel._AlarmStatus.Confirm);

        //        else if (notificationID == alarmHandle[25] && (!data)) ClearAlarm(1025, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[26] && (!data)) ClearAlarm(1026, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[27] && (!data)) ClearAlarm(1027, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[28] && (!data)) ClearAlarm(1028, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[29] && (!data)) ClearAlarm(1029, IronPanel._AlarmStatus.Confirm);

        //        else if (notificationID == alarmHandle[30] && (!data)) ClearAlarm(1030, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[31] && (!data)) ClearAlarm(1031, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[32] && (!data)) ClearAlarm(1032, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[33] && (!data)) ClearAlarm(1033, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[34] && (!data)) ClearAlarm(1034, IronPanel._AlarmStatus.Confirm);

        //        else if (notificationID == alarmHandle[35] && (!data)) ClearAlarm(1035, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[36] && (!data)) ClearAlarm(1036, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[37] && (!data)) ClearAlarm(1037, IronPanel._AlarmStatus.Confirm);
        //        //else if (notificationID == alarmHandle[38] && (!data)) ClearAlarm(1038, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[39] && (!data)) ClearAlarm(1039, IronPanel._AlarmStatus.Confirm);

        //        else if (notificationID == alarmHandle[40] && (!data)) ClearAlarm(1040, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[41] && (!data)) ClearAlarm(1041, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[42] && (!data)) ClearAlarm(1042, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[43] && (!data)) ClearAlarm(1043, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[44] && (!data)) ClearAlarm(1044, IronPanel._AlarmStatus.Confirm);

        //        else if (notificationID == alarmHandle[45] && (!data)) ClearAlarm(1045, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[46] && (!data)) ClearAlarm(1046, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[47] && (!data)) ClearAlarm(1047, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[48] && (!data)) ClearAlarm(1048, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[49] && (!data)) ClearAlarm(1049, IronPanel._AlarmStatus.Confirm);

        //        else if (notificationID == alarmHandle[50] && (!data)) ClearAlarm(1050, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[51] && (!data)) ClearAlarm(1051, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[52] && (!data)) ClearAlarm(1052, IronPanel._AlarmStatus.Confirm);
        //        else if (notificationID == alarmHandle[53] && (!data)) ClearAlarm(1053, IronPanel._AlarmStatus.Confirm);
        //        //else if (notificationID == alarmHandle[48] && (!data)) ClearAlarm(0000, IronPanel._AlarmStatus.Confirm);

               
            
        //    }
        //    catch
        //    {
        //    }
        //}

        //public void CallBack(int notificationID, object[] values)
        //{
        //    if (notificationID == alarmHandle[0])
        //    {
        //        try
        //        {
        //            bool data = bool.Parse(values[0].ToString());

        //            if (data)
        //            {
        //            }
        //        }
        //        catch
        //        {
                    
        //        }
        //    }
        //    else if (notificationID == alarmHandle[1])
        //    {
        //        DateTime n = (DateTime)values[1];

        //        listBox1.Items.Add(values[1].ToString() + ":" + values[0].ToString());
        //    }
        //}

        #endregion

        #region Timer handler
        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (CheckAlarm(100) != IronPanel._AlarmStatus.Alarm && ironSANClient1.ReadAny("DI.TestDriver.DI1") == "1")
            //{
            //    FireAlarm(100, false);
            //}

            //if (ironSANClient1.ReadAny("AO.TestDriver.AO01") == "0")   
            
            //i++;

            //for (int j = 1; j <= 30; j++)
            //{
            //    ironSANClient1.WriteData("AO.TestDriver.AO" + j.ToString("D2"), i % 100);
            //}
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
        
        #endregion

        #region Database handling routine
        

        public static bool MDB_ExecuteNonQuery( string strSQL)
        {
            string fullFilename = "C:\\Dropbox\\UBI-PROJECTS\\test.mdb";
            bool ret = false;

            // 만들어진 데이터베이스 오픈 
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename);
            try
            {
                conn.Open();
                OleDbCommand comm = new OleDbCommand(strSQL, conn);
                comm.ExecuteNonQuery();
                comm = null;
                ret = true;
            }
            catch (Exception) //(Exception ex)
            {
                //MessageBox.Show("Can not open connection ! ");
                ret = false;
            }
            finally
            {
                conn.Close();
                conn = null;
            }
            return ret;
        }

        public static bool CreateMDBTables()
        {
            // CREATE TABLE
            string strSQL = "CREATE TABLE  LOG_GAS (  번호 int identity, 시스템시간 varchar(20), 작업일자 varchar(20), 작업시간 varchar(20), 이름 varchar(20), 계량기값 int, 단위사용량 int, 적산사용량 int, " + "CONSTRAINT LOG_GAS_PrimaryKey PRIMARY KEY (번호))";
            MDB_ExecuteNonQuery( strSQL);

            strSQL = "CREATE TABLE  LOG_ELECTRIC (    번호 int identity, 시스템시간 varchar(20), 작업일자 varchar(20), 작업시간 varchar(20), 이름 varchar(20), 계량기값 int, 단위사용량 int, 적산사용량 int, " + "CONSTRAINT LOG_ELECTRIC_PrimaryKey PRIMARY KEY (번호))";
            MDB_ExecuteNonQuery( strSQL);

            strSQL = "CREATE TABLE  LOG_SCRAP_MEAS (  번호 int identity, 시스템시간 varchar(20), 작업일자 varchar(20), 작업시간 varchar(20), 이름 varchar(20), 계량기값 int, 단위사용량 int, 적산사용량 int, " + "CONSTRAINT LOG_SCRAP_MEAS_PrimaryKey PRIMARY KEY (번호))";
            MDB_ExecuteNonQuery( strSQL);

            strSQL = "CREATE TABLE  LOG_SCRAP_PUT (   번호 int identity, 시스템시간 varchar(20), 작업일자 varchar(20), 작업시간 varchar(20), 이름 varchar(20), 계량기값 int, 단위사용량 int, 적산사용량 int, " + "CONSTRAINT LOG_SCRAP_PUT_PrimaryKey PRIMARY KEY (번호))";
            MDB_ExecuteNonQuery( strSQL);

            strSQL = "CREATE TABLE  LOG_INGOT_MEAS (  번호 int identity, 시스템시간 varchar(20), 작업일자 varchar(20), 작업시간 varchar(20), 이름 varchar(20), 계량기값 int, 단위사용량 int, 적산사용량 int, " + "CONSTRAINT LOG_INGOT_MEAS_PrimaryKey PRIMARY KEY (번호))";
            MDB_ExecuteNonQuery( strSQL);

            strSQL = "CREATE TABLE  LOG_INGOT_PUT (   번호 int identity, 시스템시간 varchar(20), 작업일자 varchar(20), 작업시간 varchar(20), 이름 varchar(20), 계량기값 int, 단위사용량 int, 적산사용량 int, " + "CONSTRAINT LOG_INGOT_PUT_PrimaryKey PRIMARY KEY (번호))";
            MDB_ExecuteNonQuery( strSQL);

            return true;
        }

        public static bool CreateMDB(string fullFilename)
        {
            bool succeeded = false;
            try
            {
                ADOX._Catalog PostDB = new ADOX.Catalog();
                PostDB.Create("Provider=Microsoft.Jet.OLEDB.4.0;" +
                    "Data Source=" + fullFilename + ";" +
                    "Jet OLEDB:Engine Type=5");
                PostDB = null;
                succeeded = true;

            }
            catch (Exception)// ex)
            {
                //MessageBox.Show("Could not create database file: " + fullFilename + "\n\n" + ex.Message, "Database Creation Error");
                succeeded = false;
            }
            return succeeded;
        }

        public static bool CreateTable(string fullFilename, string tablename)
        {
            string strSQL = "CREATE TABLE " + tablename + " " + "(번호 int identity, 시간 varchar(20), 이름 varchar(10), 누적값 varchar(8), " + "CONSTRAINT " + tablename + "_PrimaryKey PRIMARY KEY (번호))";
            //"(생산일시 int identity, 펄스카운트 varchar(10), 적산가스 varchar(10), " +
            //"CONSTRAINT " + tablename + "_PrimaryKey PRIMARY KEY (생산일시))";
            //"(번호 int identity, 이름 varchar(10), 누적값 varchar(8), " +
            //"CONSTRAINT PostListTB_PrimaryKey PRIMARY KEY (번호))";

            return MDB_ExecuteNonQuery( strSQL);
        }
        public static bool DropTable(string fullFilename, string tablename)
        {
            string strSQL = "DROP TABLE " + tablename;
            return MDB_ExecuteNonQuery( strSQL);
        }
        public static bool InsertData(string fullFilename, string tablename)
        {
            DateTime dtCurrTime = DateTime.Now;
            string strDT = dtCurrTime.ToString("yyyy-MM-dd HH:mm:ss");

            //strSQL = "INSERT INTO " + tablename + "(번호, 시간, 이름, 누적값) " + //" (생산일시, 펄스카운트, 적산가스) " +
            //         " VALUES ( 1, '" + strDT + "', '1000', '10000')";

            string strSQL = "INSERT INTO " + tablename + "(시간, 이름, 누적값) " + //" (생산일시, 펄스카운트, 적산가스) " +
                        " VALUES ( '" + strDT + "', '1000', '10000')";

            return MDB_ExecuteNonQuery( strSQL);
        }

        #endregion

        #region Working time and periodic data logging
        
        DateTime ndt;                  // 시스템   현재시간
        DateTime rdt;                  // 작업기준 설정시간
        DateTime wdt;                  // 일작업   경과시간
        DateTime bdt;                  // 직전에 저장했던 분 : Periodic Data[분단위] 저장시점 구분용, 분이 변경됨을 확인하기 위한 용도 

        private void timer_work_data_Tick(object sender, EventArgs e)
        {

            int nyear, nmonth, nday, nhour, nmin, nsec;  // 실제 현재시간을 분리한 값

            ndt = DateTime.Now;

            nyear = ndt.Year;
            nmonth = ndt.Month;
            nday = ndt.Day;
            nhour = ndt.Hour;
            nmin = ndt.Minute;
            nsec = ndt.Second;

            string ref_time = "10:30:00";
            rdt = DateTime.Parse(nyear.ToString() + "-" + nmonth.ToString() + "-" + nday.ToString() +
                                  " " + ref_time);

            TimeSpan ts = ndt - rdt;  // 시간차를 구함
            TimeSpan tts = rdt - rdt;  // 0시간 기준값을 만들어줌.

            DateTime zerotime = DateTime.Today;
            
            wdt = zerotime.Add(ts);

            // 분이 경과했으면 Periodic Data[분단위] 저장
            if(ndt.Minute != bdt.Minute) 
            {
                Log_Per_Minute(ndt.ToString("yyyy-MM-dd HH:mm:ss"), wdt.ToString("yyyy-MM-dd"), wdt.ToString("yyyy-MM-dd HH:mm:ss"));
                bdt = ndt;
            }

        }

        public void Log_Per_Minute(string sysTime, string workDay, string workElapsedTime)
        {

            UInt32 id01000;
            UInt32 id00180;

            try
            {
                id01000 = Convert.ToUInt32(opcClient2.ReadAny("PLC-XGK:D01000"));
                id00180 = Convert.ToUInt32(opcClient2.ReadAny("PLC-XGK:D00180"));
            }
            catch
            {
                //ksyu PLC None TEST
                id01000 = 0;
                id00180 = 0;
            }

            MDB_ExecuteNonQuery("INSERT INTO LOG_GAS      (시스템시간, 작업일자, 작업시간, 이름, 계량기값, 단위사용량, 적산사용량)  VALUES ( '"
                + ndt.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + wdt.ToString("yyyy-MM-dd") + "', '" + wdt.ToString("yyyy-MM-dd HH:mm:ss") + "', '적산GAS-S',"
                + id01000 + "," + id01000 + "," + id01000 + ")");
            MDB_ExecuteNonQuery("INSERT INTO LOG_ELECTRIC (시스템시간, 작업일자, 작업시간, 이름, 계량기값, 단위사용량, 적산사용량)  VALUES ( '"
                + ndt.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + wdt.ToString("yyyy-MM-dd") + "', '" + wdt.ToString("yyyy-MM-dd HH:mm:ss") + "', '적산전력-S',"
                + id00180 + "," + id00180 + "," + id00180 + ")");
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            //watch.Start(); //watch alarm
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            //digitalBox1.WriteData();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            //digitalBox1.UpdateData();
        }

        /* 삭제검토 중***/
        private void analogBox1_Load(object sender, EventArgs e)
        {

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
        /***/

        private void button1_Click_1(object sender, EventArgs e)
        {
            //CreateMDB("C:\\Dropbox\\UBI-PROJECTS\\test.mdb");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //// CREATE TABLE
            //string strSQL = "CREATE TABLE  LOG_GAS (번호 int identity, 시스템시간 varchar(20), 작업일자 varchar(20), 작업시간 varchar(20), 이름 varchar(10), 계량기값 varchar(20), 단위사용량 varchar(20), 적산사용량 varchar(20), " + "CONSTRAINT LOG_GAS_PrimaryKey PRIMARY KEY (번호))";
            //MDB_ExecuteNonQuery( strSQL);

            //strSQL = "CREATE TABLE  LOG_ELECTRIC (  번호 int identity, 시스템시간 varchar(20), 작업일자 varchar(20), 작업시간 varchar(20), 이름 varchar(10), 계량기값 varchar(20), 단위사용량 varchar(20), 적산사용량 varchar(20), " + "CONSTRAINT LOG_ELECTRIC_PrimaryKey PRIMARY KEY (번호))";
            //MDB_ExecuteNonQuery( strSQL);
        }

        /* 삭제검토 중***/
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ledOnly4_Load(object sender, EventArgs e)
        {

        }

        private void TrainScreen_Load(object sender, EventArgs e)
        {

        }
        /*****/

        private void button3_Click(object sender, EventArgs e)
        {
            //MDB_ExecuteNonQuery( "DROP TABLE LOG_GAS");
            //MDB_ExecuteNonQuery( "DROP TABLE LOG_ELECTRIC");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //DateTime dtCurrTime = DateTime.Now;
            //string strDT = dtCurrTime.ToString("yyyy-MM-dd HH:mm:ss");

            //MDB_ExecuteNonQuery( "INSERT INTO LOG_GAS      (시스템시간, 작업일자, 작업시간, 이름, 계량기값, 단위사용량, 적산사용량)  VALUES ( '" + strDT + "', '" + strDT + "', '" + strDT + "', '1000', '10000','1000','10000')");
            //MDB_ExecuteNonQuery( "INSERT INTO LOG_ELECTRIC (시스템시간, 작업일자, 작업시간, 이름, 계량기값, 단위사용량, 적산사용량)  VALUES ( '" + strDT + "', '" + strDT + "', '" + strDT + "', '1000', '10000','1000','10000')");
        }  

        /* 삭제검토 중***/
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ledOnly3_Load_1(object sender, EventArgs e)
        {

        }

        private void timer_simulation_Tick(object sender, EventArgs e)
        {
          //opcClient2.WriteData("PLC-XGK:D00186", Convert.ToUInt16(opcClient2.ReadAny("PLC-XGK:D00186")) +1);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            // GAS FLOW 화면으로 메뉴이동하기 : 네비게이션
            MoveScreen(1, 0);
        }

        private void imageOnOffUnknownAndTimer24_Load(object sender, EventArgs e)
        {
            //MoveScreen(2, 0);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Temp_Set.Tag = "PLC-XGK:M00021";
            Temp_Set.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Temp_Set.Tag = "PLC-XGK:M00020";
            Temp_Set.Show();
        }


        /***/
        
    }
}
