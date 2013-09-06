using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;
using System.Collections.Specialized;

using System.Data.OleDb;

using System.IO;                // 파일 첨부
using System.Configuration;
using ADOX;

namespace SampleScreen
{
    public struct ConfigData
    {
        public string type;
        public double dData;
        public int nData;
        public string sDtata;
    }

    public partial class ConfigScreen : IronPanel.InformationPanel
    {
        List<ConfigData> values = new List<ConfigData>();
        int[] diHandle = new int[200];

        int[] alarmHandle = new int[200];

        public ConfigScreen()
        {
            InitializeComponent();
        }

        public override void StartPanel(string name)
        {
            ironSANClient1.ProjectPath = this.ProjectPath;
            ironSANClient1.Connect();
            opcClient2.Connect();

            //기본설정값을 읽어 온 후에 다른 DB나 연산이나 타이머를 시작해야 한다.
            this.ReadXML();   // config data load  

            string db_pathrootname;
            string db_filename_Header = "DATALOG-EEMS-M1";
            string fullFilename;
            ndt = DateTime.Now;
            db_pathrootname = ironSANClient1.ReadAny("SO.EEMS-R1.Path_Log").ToString().Trim();
            fullFilename = db_pathrootname + "\\" + ndt.ToString("yyyy") + "\\" + db_filename_Header + "-" + ndt.ToString("yyyy") + "-" + ndt.ToString("MM") + ".mdb";
            CreateMDB(fullFilename);
            CreateMDBTables(fullFilename);

            // 정확하게 1분 전의 데이타를 얻어야 분당 데이터를 얻을 수 있어서 정확한 1분 전 시각을 알아야 한다.
            ndt = DateTime.Now;
            bdt = ndt - TimeSpan.FromMinutes(1);

            // 타이머는 반드시 기본설정 로딩 후에 실행되어야 한다.
            timer_work_data.Enabled = true;

            AlarmTagEventConfig();

            TagEventConfig();
        }


        public override void StopPanel()
        {
            AlarmTagEventFree();

            TagEventFree();           

            ironSANClient1.Disconnect();
            opcClient2.Disconnect();
        }

        public override void ShowPanel(string user, int level)
        {
            //this.Enabled = user == "Admin";
        }
        
        public override void HidePanel()
        {
            base.HidePanel();
        }

        #region Alarm Event and Callback(Handler) Config.

        // ALARM CONTROL
        private void AlarmTagEventConfig()
        {
            // Digital OnChange alarm
            alarmHandle[0] = opcClient2.Subscribe("PLC-XGK:M00500", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[1] = opcClient2.Subscribe("PLC-XGK:M00501", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[2] = opcClient2.Subscribe("PLC-XGK:M00502", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[3] = opcClient2.Subscribe("PLC-XGK:M00503", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[4] = opcClient2.Subscribe("PLC-XGK:M00504", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);

            alarmHandle[5] = opcClient2.Subscribe("PLC-XGK:M00505", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[6] = opcClient2.Subscribe("PLC-XGK:M00506", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[7] = opcClient2.Subscribe("PLC-XGK:M00507", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[8] = opcClient2.Subscribe("PLC-XGK:M00508", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[9] = opcClient2.Subscribe("PLC-XGK:M00509", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);

            alarmHandle[10] = opcClient2.Subscribe("PLC-XGK:M0050A", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[11] = opcClient2.Subscribe("PLC-XGK:M0050B", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[12] = opcClient2.Subscribe("PLC-XGK:M0050C", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[13] = opcClient2.Subscribe("PLC-XGK:M0050D", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[14] = opcClient2.Subscribe("PLC-XGK:M0050E", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);

            alarmHandle[15] = opcClient2.Subscribe("PLC-XGK:M0050F", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[16] = opcClient2.Subscribe("PLC-XGK:M00510", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[17] = opcClient2.Subscribe("PLC-XGK:M00511", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[18] = opcClient2.Subscribe("PLC-XGK:M00512", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            //alarmHandle[19] = opcClient2.Subscribe("PLC-XGK:M00513", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);

            alarmHandle[20] = opcClient2.Subscribe("PLC-XGK:M00514", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[21] = opcClient2.Subscribe("PLC-XGK:M00515", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[22] = opcClient2.Subscribe("PLC-XGK:M00516", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            //alarmHandle[23] = opcClient2.Subscribe("PLC-XGK:M00517", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[24] = opcClient2.Subscribe("PLC-XGK:M00518", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);

            alarmHandle[25] = opcClient2.Subscribe("PLC-XGK:M00519", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[26] = opcClient2.Subscribe("PLC-XGK:M0051A", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[27] = opcClient2.Subscribe("PLC-XGK:M0051B", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[28] = opcClient2.Subscribe("PLC-XGK:M0051C", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[29] = opcClient2.Subscribe("PLC-XGK:M0051D", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);

            alarmHandle[30] = opcClient2.Subscribe("PLC-XGK:M0051E", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[31] = opcClient2.Subscribe("PLC-XGK:M0051F", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[32] = opcClient2.Subscribe("PLC-XGK:M00520", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[33] = opcClient2.Subscribe("PLC-XGK:M00521", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[34] = opcClient2.Subscribe("PLC-XGK:M00522", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);

            alarmHandle[35] = opcClient2.Subscribe("PLC-XGK:M00523", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[36] = opcClient2.Subscribe("PLC-XGK:M00524", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[37] = opcClient2.Subscribe("PLC-XGK:M00525", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            //alarmHandle[38] = opcClient2.Subscribe("PLC-XGK:M00526", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[39] = opcClient2.Subscribe("PLC-XGK:M00527", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);

            alarmHandle[40] = opcClient2.Subscribe("PLC-XGK:M00528", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[41] = opcClient2.Subscribe("PLC-XGK:M00529", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[42] = opcClient2.Subscribe("PLC-XGK:M0052A", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[43] = opcClient2.Subscribe("PLC-XGK:M0052B", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[44] = opcClient2.Subscribe("PLC-XGK:M0052C", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);

            alarmHandle[45] = opcClient2.Subscribe("PLC-XGK:M0052D", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[46] = opcClient2.Subscribe("PLC-XGK:M0052E", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[47] = opcClient2.Subscribe("PLC-XGK:M0052F", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[48] = opcClient2.Subscribe("PLC-XGK:M00530", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[49] = opcClient2.Subscribe("PLC-XGK:M00531", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);

            alarmHandle[50] = opcClient2.Subscribe("PLC-XGK:M00532", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[51] = opcClient2.Subscribe("PLC-XGK:M00533", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[52] = opcClient2.Subscribe("PLC-XGK:M00534", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);
            alarmHandle[53] = opcClient2.Subscribe("PLC-XGK:M00539", CommLib.UpdateMode.OnChange, 1000, CallBack_AlarmTagEvent);

            // Watch alarm ??
            //handle[100] = opcClient1.Subscribe("PLC-XGK:D00625", CommLib.UpdateMode.Cyclic, 60000, CallBack);
        }

        private void AlarmTagEventFree()
        {

            opcClient2.Unsubscribe(alarmHandle[0]);
            opcClient2.Unsubscribe(alarmHandle[1]);
            opcClient2.Unsubscribe(alarmHandle[2]);
            opcClient2.Unsubscribe(alarmHandle[3]);
            opcClient2.Unsubscribe(alarmHandle[4]);
            opcClient2.Unsubscribe(alarmHandle[5]);
            opcClient2.Unsubscribe(alarmHandle[6]);
            opcClient2.Unsubscribe(alarmHandle[7]);
            opcClient2.Unsubscribe(alarmHandle[8]);
            opcClient2.Unsubscribe(alarmHandle[9]);
            opcClient2.Unsubscribe(alarmHandle[10]);
            opcClient2.Unsubscribe(alarmHandle[11]);
            opcClient2.Unsubscribe(alarmHandle[12]);
            opcClient2.Unsubscribe(alarmHandle[13]);
            opcClient2.Unsubscribe(alarmHandle[14]);
            opcClient2.Unsubscribe(alarmHandle[15]);
            opcClient2.Unsubscribe(alarmHandle[16]);
            opcClient2.Unsubscribe(alarmHandle[17]);
            opcClient2.Unsubscribe(alarmHandle[18]);
            //opcClient2.Unsubscribe(alarmHandle[19]);
            opcClient2.Unsubscribe(alarmHandle[20]);
            opcClient2.Unsubscribe(alarmHandle[21]);
            opcClient2.Unsubscribe(alarmHandle[22]);
            //opcClient2.Unsubscribe(alarmHandle[23]);
            opcClient2.Unsubscribe(alarmHandle[24]);
            opcClient2.Unsubscribe(alarmHandle[25]);
            opcClient2.Unsubscribe(alarmHandle[26]);
            opcClient2.Unsubscribe(alarmHandle[27]);
            opcClient2.Unsubscribe(alarmHandle[28]);
            opcClient2.Unsubscribe(alarmHandle[29]);
            opcClient2.Unsubscribe(alarmHandle[30]);
            opcClient2.Unsubscribe(alarmHandle[31]);
            opcClient2.Unsubscribe(alarmHandle[32]);
            opcClient2.Unsubscribe(alarmHandle[33]);
            opcClient2.Unsubscribe(alarmHandle[34]);
            opcClient2.Unsubscribe(alarmHandle[35]);
            opcClient2.Unsubscribe(alarmHandle[36]);
            opcClient2.Unsubscribe(alarmHandle[37]);
            //opcClient2.Unsubscribe(alarmHandle[38]);
            opcClient2.Unsubscribe(alarmHandle[39]);
            opcClient2.Unsubscribe(alarmHandle[40]);
            opcClient2.Unsubscribe(alarmHandle[41]);
            opcClient2.Unsubscribe(alarmHandle[42]);
            opcClient2.Unsubscribe(alarmHandle[43]);
            opcClient2.Unsubscribe(alarmHandle[44]);
            opcClient2.Unsubscribe(alarmHandle[45]);
            opcClient2.Unsubscribe(alarmHandle[46]);
            opcClient2.Unsubscribe(alarmHandle[47]);
            opcClient2.Unsubscribe(alarmHandle[48]);
            opcClient2.Unsubscribe(alarmHandle[49]);
            opcClient2.Unsubscribe(alarmHandle[50]);
            opcClient2.Unsubscribe(alarmHandle[51]);
            opcClient2.Unsubscribe(alarmHandle[52]);
            opcClient2.Unsubscribe(alarmHandle[53]);


            //opcClient2.Unsubscribe(alarmHandle[100]);
        }

        // alarm 구현
        private void CallBack_AlarmTagEvent(int notificationID, object[] value)
        {
            try
            {
                bool data = bool.Parse(value[0].ToString());

                if (notificationID == alarmHandle[0] && data) FireAlarm(1000, false);
                else if (notificationID == alarmHandle[1] && data) FireAlarm(1001, false);
                else if (notificationID == alarmHandle[2] && data) FireAlarm(1002, false);
                else if (notificationID == alarmHandle[3] && data) FireAlarm(1003, false);
                else if (notificationID == alarmHandle[4] && data) FireAlarm(1004, false);

                else if (notificationID == alarmHandle[5] && data) FireAlarm(1005, false);
                else if (notificationID == alarmHandle[6] && data) FireAlarm(1006, false);
                else if (notificationID == alarmHandle[7] && data) FireAlarm(1007, false);
                else if (notificationID == alarmHandle[8] && data) FireAlarm(1008, false);
                else if (notificationID == alarmHandle[9] && data) FireAlarm(1009, false);

                else if (notificationID == alarmHandle[10] && data) FireAlarm(1010, false);
                else if (notificationID == alarmHandle[11] && data) FireAlarm(1011, false);
                else if (notificationID == alarmHandle[12] && data) FireAlarm(1012, false);
                else if (notificationID == alarmHandle[13] && data) FireAlarm(1013, false);
                else if (notificationID == alarmHandle[14] && data) FireAlarm(1014, false);

                else if (notificationID == alarmHandle[15] && data) FireAlarm(1015, false);
                else if (notificationID == alarmHandle[16] && data) FireAlarm(1016, false);
                else if (notificationID == alarmHandle[17] && data) FireAlarm(1017, false);
                else if (notificationID == alarmHandle[18] && data) FireAlarm(1018, false);
                //else if (notificationID == alarmHandle[19] && data) FireAlarm(1019, false);

                else if (notificationID == alarmHandle[20] && data) FireAlarm(1020, false);
                else if (notificationID == alarmHandle[21] && data) FireAlarm(1021, false);
                else if (notificationID == alarmHandle[22] && data) FireAlarm(1022, false);
                //else if (notificationID == alarmHandle[23] && data) FireAlarm(1023, false);
                else if (notificationID == alarmHandle[24] && data) FireAlarm(1024, false);

                else if (notificationID == alarmHandle[25] && data) FireAlarm(1025, false);
                else if (notificationID == alarmHandle[26] && data) FireAlarm(1026, false);
                else if (notificationID == alarmHandle[27] && data) FireAlarm(1027, false);
                else if (notificationID == alarmHandle[28] && data) FireAlarm(1028, false);
                else if (notificationID == alarmHandle[29] && data) FireAlarm(1029, false);

                else if (notificationID == alarmHandle[30] && data) FireAlarm(1030, false);
                else if (notificationID == alarmHandle[31] && data) FireAlarm(1031, false);
                else if (notificationID == alarmHandle[32] && data) FireAlarm(1032, false);
                else if (notificationID == alarmHandle[33] && data) FireAlarm(1033, false);
                else if (notificationID == alarmHandle[34] && data) FireAlarm(1034, false);

                else if (notificationID == alarmHandle[35] && data) FireAlarm(1035, false);
                else if (notificationID == alarmHandle[36] && data) FireAlarm(1036, false);
                else if (notificationID == alarmHandle[37] && data) FireAlarm(1037, false);
                //else if (notificationID == alarmHandle[38] && data) FireAlarm(1038, false);
                else if (notificationID == alarmHandle[39] && data) FireAlarm(1039, false);

                else if (notificationID == alarmHandle[40] && data) FireAlarm(1040, false);
                else if (notificationID == alarmHandle[41] && data) FireAlarm(1041, false);
                else if (notificationID == alarmHandle[42] && data) FireAlarm(1042, false);
                else if (notificationID == alarmHandle[43] && data) FireAlarm(1043, false);
                else if (notificationID == alarmHandle[44] && data) FireAlarm(1044, false);

                else if (notificationID == alarmHandle[45] && data) FireAlarm(1045, false);
                else if (notificationID == alarmHandle[46] && data) FireAlarm(1046, false);
                else if (notificationID == alarmHandle[47] && data) FireAlarm(1047, false);
                else if (notificationID == alarmHandle[48] && data) FireAlarm(1048, false);
                else if (notificationID == alarmHandle[49] && data) FireAlarm(1049, false);

                else if (notificationID == alarmHandle[50] && data) FireAlarm(1050, false);
                else if (notificationID == alarmHandle[51] && data) FireAlarm(1051, false);
                else if (notificationID == alarmHandle[52] && data) FireAlarm(1052, false);
                else if (notificationID == alarmHandle[53] && data) FireAlarm(1053, false);
                //else if (notificationID == alarmHandle[48] && data) FireAlarm(0000, false);

                else if (notificationID == alarmHandle[0] && (!data)) ClearAlarm(1000, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[1] && (!data)) ClearAlarm(1001, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[2] && (!data)) ClearAlarm(1002, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[3] && (!data)) ClearAlarm(1003, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[4] && (!data)) ClearAlarm(1004, IronPanel._AlarmStatus.Confirm);

                else if (notificationID == alarmHandle[5] && (!data)) ClearAlarm(1005, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[6] && (!data)) ClearAlarm(1006, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[7] && (!data)) ClearAlarm(1007, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[8] && (!data)) ClearAlarm(1008, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[9] && (!data)) ClearAlarm(1009, IronPanel._AlarmStatus.Confirm);

                else if (notificationID == alarmHandle[10] && (!data)) ClearAlarm(1010, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[11] && (!data)) ClearAlarm(1011, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[12] && (!data)) ClearAlarm(1012, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[13] && (!data)) ClearAlarm(1013, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[14] && (!data)) ClearAlarm(1014, IronPanel._AlarmStatus.Confirm);

                else if (notificationID == alarmHandle[15] && (!data)) ClearAlarm(1015, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[16] && (!data)) ClearAlarm(1016, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[17] && (!data)) ClearAlarm(1017, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[18] && (!data)) ClearAlarm(1018, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[19] && (!data)) ClearAlarm(1019, IronPanel._AlarmStatus.Confirm);

                else if (notificationID == alarmHandle[20] && (!data)) ClearAlarm(1020, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[21] && (!data)) ClearAlarm(1021, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[22] && (!data)) ClearAlarm(1022, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[23] && (!data)) ClearAlarm(1023, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[24] && (!data)) ClearAlarm(1024, IronPanel._AlarmStatus.Confirm);

                else if (notificationID == alarmHandle[25] && (!data)) ClearAlarm(1025, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[26] && (!data)) ClearAlarm(1026, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[27] && (!data)) ClearAlarm(1027, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[28] && (!data)) ClearAlarm(1028, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[29] && (!data)) ClearAlarm(1029, IronPanel._AlarmStatus.Confirm);

                else if (notificationID == alarmHandle[30] && (!data)) ClearAlarm(1030, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[31] && (!data)) ClearAlarm(1031, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[32] && (!data)) ClearAlarm(1032, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[33] && (!data)) ClearAlarm(1033, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[34] && (!data)) ClearAlarm(1034, IronPanel._AlarmStatus.Confirm);

                else if (notificationID == alarmHandle[35] && (!data)) ClearAlarm(1035, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[36] && (!data)) ClearAlarm(1036, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[37] && (!data)) ClearAlarm(1037, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[38] && (!data)) ClearAlarm(1038, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[39] && (!data)) ClearAlarm(1039, IronPanel._AlarmStatus.Confirm);

                else if (notificationID == alarmHandle[40] && (!data)) ClearAlarm(1040, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[41] && (!data)) ClearAlarm(1041, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[42] && (!data)) ClearAlarm(1042, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[43] && (!data)) ClearAlarm(1043, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[44] && (!data)) ClearAlarm(1044, IronPanel._AlarmStatus.Confirm);

                else if (notificationID == alarmHandle[45] && (!data)) ClearAlarm(1045, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[46] && (!data)) ClearAlarm(1046, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[47] && (!data)) ClearAlarm(1047, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[48] && (!data)) ClearAlarm(1048, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[49] && (!data)) ClearAlarm(1049, IronPanel._AlarmStatus.Confirm);

                else if (notificationID == alarmHandle[50] && (!data)) ClearAlarm(1050, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[51] && (!data)) ClearAlarm(1051, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[52] && (!data)) ClearAlarm(1052, IronPanel._AlarmStatus.Confirm);
                else if (notificationID == alarmHandle[53] && (!data)) ClearAlarm(1053, IronPanel._AlarmStatus.Confirm);
                //else if (notificationID == alarmHandle[48] && (!data)) ClearAlarm(0000, IronPanel._AlarmStatus.Confirm);


            }
            catch
            {
            }
        }

        #endregion

        #region scrap/Ingot Event and Callback(Handler) Config.

        private void TagEventConfig()
        {
            //diHandle[0] = opcClient2.Subscribe("PLC-XGK:M00530", CommLib.UpdateMode.OnChange, 1000, Callback_TagEvent);  // scrap weight send bit
            //diHandle[1] = opcClient2.Subscribe("PLC-XGK:M00630", CommLib.UpdateMode.OnChange, 1000, Callback_TagEvent);  // Ingot weight send bit
            diHandle[0] = opcClient2.Subscribe("PLC-XGK:M0055A", CommLib.UpdateMode.OnChange, 1000, Callback_TagEvent);  // scrap weight send bit
            diHandle[1] = opcClient2.Subscribe("PLC-XGK:M0065A", CommLib.UpdateMode.OnChange, 1000, Callback_TagEvent);  // Ingot weight send bit

            
        }

        private void TagEventFree()
        {
            opcClient2.Unsubscribe(diHandle[0]);    // scrap weight send bit
            opcClient2.Unsubscribe(diHandle[1]);    // Ingot weight send bit

        }

        private void Callback_TagEvent(int notificationID, object[] value)
        {
            string db_pathrootname;
            string db_filename_Header = "DATALOG-EEMS-M1";
            string fullFilename;

            db_pathrootname = ironSANClient1.ReadAny("SO.EEMS-R1.Path_Log").ToString().Trim();
            fullFilename = db_pathrootname + "\\" + ndt.ToString("yyyy") + "\\" + db_filename_Header + "-" + ndt.ToString("yyyy") + "-" + ndt.ToString("MM") + ".mdb";

            try
            {
                bool data = bool.Parse(value[0].ToString());

                if (notificationID == diHandle[0])  // scrap weight send bit
                {
                    if (data)
                    {
                        long scrap_meas = Convert.ToInt32(opcClient2.ReadAny("PLC-XGK:D00514").ToString().Trim());

                        double d_scrap_factor = Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.scrap_per_kg").ToString().Trim()); // PLC 가스값을 실제값으로 환산하는 팩터

                        // 환산된 계량당 스크랩량 
                        double d_scrap_per_min;
                        if (scrap_meas != 0.0) d_scrap_per_min = scrap_meas * d_scrap_factor;
                        else d_scrap_per_min = 0.0;

                        //MDB_ExecuteNonQuery( fullFilename, "INSERT INTO LOG_SCRAP_MEAS (시스템시간, 작업일자, 작업시간, 이름, 계량기값, 단위사용량, 적산사용량)  VALUES ( '"
                        //    + ndt.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + wdt.ToString("yyyy-MM-dd") + "', '" + wdt.ToString("yyyy-MM-dd HH:mm:ss") + "', '시험계량S',"
                        //    + scrap_meas + "," + d_scrap_per_min.ToString("0.0").Trim() + "," + "0.0" + ")");

                        MDB_ExecuteNonQuery(fullFilename, "INSERT INTO LOG_FULLDATA (시스템시간, 작업일자, 작업시간, 스크랩, 스크랩_PLC, 스크랩사용량, 적산스크랩량)  VALUES ( '"
                           + ndt.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + wdt.ToString("yyyy-MM-dd") + "', '" + wdt.ToString("yyyy-MM-dd HH:mm:ss") + "', '시험계량S',"
                           + scrap_meas + "," + d_scrap_per_min.ToString("0.0").Trim() + "," + "0.0" + ")");

                        //dOrigin = Convert.ToDouble(ds1.Tables[0].Rows[0][0]);
                        //dFactor = 0.1; //Convert.ToDouble(ironSANClient1.ReadAny("").ToString().Trim());                

                        //if (scrap_meas == 0.0) ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per", 0.0);
                        //else ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per", d_scrap_per_min);
                    }
                    
                }
                else if (notificationID == diHandle[1]) // Ingot weight send bit
                {
                    if (data)
                    {
                        long ingot_meas = Convert.ToInt32(opcClient2.ReadAny("PLC-XGK:D00625").ToString().Trim());

                        double d_ingot_factor = Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.ingot_per_kg").ToString().Trim()); // PLC 인고트을 실제값으로 환산하는 팩터

                        // 환산된 계량당 스크랩량 
                        double d_ingot_per_min;
                        if (ingot_meas != 0.0) d_ingot_per_min = ingot_meas * d_ingot_factor;
                        else d_ingot_per_min = 0.0;
                        
                        //MDB_ExecuteNonQuery( fullFilename, "INSERT INTO LOG_INGOT_MEAS (시스템시간, 작업일자, 작업시간, 이름, 계량기값, 단위사용량, 적산사용량)  VALUES ( '"
                        //+ ndt.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + wdt.ToString("yyyy-MM-dd") + "', '" + wdt.ToString("yyyy-MM-dd HH:mm:ss") + "', '시험계량I',"
                        //+ ingot_meas + "," + d_ingot_per_min.ToString("0.0") + "," + "0.0" + ")");

                        MDB_ExecuteNonQuery(fullFilename, "INSERT INTO LOG_FULLDATA (시스템시간, 작업일자, 작업시간, 인고트, 인고트_PLC, 인고트사용량, 적산인고트량)  VALUES ( '"
                        + ndt.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + wdt.ToString("yyyy-MM-dd") + "', '" + wdt.ToString("yyyy-MM-dd HH:mm:ss") + "', '시험계량I',"
                        + ingot_meas + "," + d_ingot_per_min.ToString("0.0") + "," + "0.0" + ")");

                        //if (ingot_meas == 0.0) ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per", 0.0);
                        //else ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per", d_ingot_per_min);
                    }
                }

                CurrentData_Update();
                //    " 번호 int identity, 시스템시간 varchar(20), 작업일자 varchar(20), 작업시간 varchar(20), " +
                //    " 전력 varchar(20), 전력_PLC double, 전력사용량 double, 적산전력량 double, " +
                //    " 가스 varchar(20), 가스_PLC double, 가스사용량 double, 적산가스량 double, " +
                //    " 인고트 varchar(20), 인고트_PLC double, 인고트사용량 double, 적산인고트량 double, " +
                //    " 스크랩 varchar(20), 스크랩_PLC double, 스크랩사용량 double, 적산스크랩량 double, " +
                    //" CONSTRAINT LOG_FULLDATA_PrimaryKey PRIMARY KEY (번호))";
            }
            catch
            {
            }
        }
        #endregion

        #region XML Read and write

        //IronControls.SerializableDictionary<string, double> values = null;


        private void CreateXML()
        {
        }

        private void WriteXML()
        {


            try
            {
                string Path_filename = this.ProjectPath + "\\Config\\Config.xml";
      

                // 생성할 XML 파일 경로와 이름, 인코딩 방식을 설정합니다.
                XmlTextWriter textWriter = new XmlTextWriter(Path_filename, Encoding.UTF8);

                // 들여쓰기 설정
                textWriter.Formatting = Formatting.Indented;

                // 문서에 쓰기를 시작합니다.
                textWriter.WriteStartDocument();
                textWriter.WriteStartElement("root");


                string tagname;

                tagname = "SO.EEMS-R1.Path_Log";
                textWriter.WriteStartElement("Item");
                textWriter.WriteStartElement("Key");
                textWriter.WriteStartElement("string");
                textWriter.WriteString(tagname);
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("Value");
                textWriter.WriteStartElement("string");
                textWriter.WriteString(ironSANClient1.ReadAny(tagname).ToString().Trim());
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                ////tagname = "AO.EEMS-R1.pulse_per_gas_m3";
                tagname = "AO.EEMS-R1.pulse_per_gas";
                textWriter.WriteStartElement("Item");
                textWriter.WriteStartElement("Key");
                textWriter.WriteStartElement("string");
                textWriter.WriteString(tagname);
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("Value");
                textWriter.WriteStartElement("double");
                textWriter.WriteString(ironSANClient1.ReadAny(tagname).ToString().Trim());
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                tagname = "AO.EEMS-R1.gas_per_KRW";
                textWriter.WriteStartElement("Item");
                textWriter.WriteStartElement("Key");
                textWriter.WriteStartElement("string");
                textWriter.WriteString(tagname);
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("Value");
                textWriter.WriteStartElement("double");
                textWriter.WriteString(ironSANClient1.ReadAny(tagname).ToString().Trim());
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                tagname = "AO.EEMS-R1.ingot_per_kg";
                textWriter.WriteStartElement("Item");
                textWriter.WriteStartElement("Key");
                textWriter.WriteStartElement("string");
                textWriter.WriteString(tagname);
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("Value");
                textWriter.WriteStartElement("double");
                textWriter.WriteString(ironSANClient1.ReadAny(tagname).ToString().Trim());
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                tagname = "AO.EEMS-R1.scrap_per_kg";
                textWriter.WriteStartElement("Item");
                textWriter.WriteStartElement("Key");
                textWriter.WriteStartElement("string");
                textWriter.WriteString(tagname);
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("Value");
                textWriter.WriteStartElement("double");
                textWriter.WriteString(ironSANClient1.ReadAny(tagname).ToString().Trim());
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                tagname = "AO.EEMS-R1.plc_watt_per_pc_watt";
                textWriter.WriteStartElement("Item");
                textWriter.WriteStartElement("Key");
                textWriter.WriteStartElement("string");
                textWriter.WriteString(tagname);
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("Value");
                textWriter.WriteStartElement("double");
                textWriter.WriteString(ironSANClient1.ReadAny(tagname).ToString().Trim());
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                tagname = "AO.EEMS-R1.pc_watt_per_KRW";
                textWriter.WriteStartElement("Item");
                textWriter.WriteStartElement("Key");
                textWriter.WriteStartElement("string");
                textWriter.WriteString(tagname);
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("Value");
                textWriter.WriteStartElement("double");
                textWriter.WriteString(ironSANClient1.ReadAny(tagname).ToString().Trim());
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                tagname = "AO.EEMS-R1.tower_temp_factor";
                textWriter.WriteStartElement("Item");
                textWriter.WriteStartElement("Key");
                textWriter.WriteStartElement("string");
                textWriter.WriteString(tagname);
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("Value");
                textWriter.WriteStartElement("double");
                textWriter.WriteString(ironSANClient1.ReadAny(tagname).ToString().Trim());
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                tagname = "AO.EEMS-R1.furnace_temp_factor";
                textWriter.WriteStartElement("Item");
                textWriter.WriteStartElement("Key");
                textWriter.WriteStartElement("string");
                textWriter.WriteString(tagname);
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("Value");
                textWriter.WriteStartElement("double");
                textWriter.WriteString(ironSANClient1.ReadAny(tagname).ToString().Trim());
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                tagname = "AO.EEMS-R1.Num_Of_Workgroups";
                textWriter.WriteStartElement("Item");
                textWriter.WriteStartElement("Key");
                textWriter.WriteStartElement("string");
                textWriter.WriteString(tagname);
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("Value");
                textWriter.WriteStartElement("int16");
                textWriter.WriteString(ironSANClient1.ReadAny(tagname).ToString().Trim());
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                tagname = "AO.EEMS-R1.PLC_Max_Gas";
                textWriter.WriteStartElement("Item");
                textWriter.WriteStartElement("Key");
                textWriter.WriteStartElement("string");
                textWriter.WriteString(tagname);
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("Value");
                textWriter.WriteStartElement("int32");
                textWriter.WriteString(ironSANClient1.ReadAny(tagname).ToString().Trim());
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                tagname = "AO.EEMS-R1.PLC_Max_Watt";
                textWriter.WriteStartElement("Item");
                textWriter.WriteStartElement("Key");
                textWriter.WriteStartElement("string");
                textWriter.WriteString(tagname);
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("Value");
                textWriter.WriteStartElement("int32");
                textWriter.WriteString(ironSANClient1.ReadAny(tagname).ToString().Trim());
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                tagname = "SO.EEMS-R1.ReferenceTime_Workday";
                textWriter.WriteStartElement("Item");
                textWriter.WriteStartElement("Key");
                textWriter.WriteStartElement("string");
                textWriter.WriteString(tagname);
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("Value");
                textWriter.WriteStartElement("string");
                textWriter.WriteString(ironSANClient1.ReadAny(tagname).ToString().Trim());
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                   
                 textWriter.WriteEndElement();

                textWriter.WriteEndDocument();
                textWriter.Close();
            }
            catch(Exception)
            {
            }
        }

        private void ReadXML()
        {
            try
            {

                //values = (IronControls.SerializableDictionary<string, double>)IronControls.Utility.DeserializeXML(ProjectPath + "\\Config\\Config.xml", typeof(IronControls.SerializableDictionary<string, double>));

                //if (values != null)
                //{
                //    foreach (string key in values.Keys)
                //    {
                //        ironSANClient1.WriteData(key, values[key]);
                //    }
                //}


                XmlDocument xmldoc = new XmlDocument();

                xmldoc.Load(this.ProjectPath + "\\Config\\Config.xml");
                XmlElement root = xmldoc.DocumentElement;

                // 노드 요소들
                XmlNodeList nodes = root.ChildNodes;

                // 노드 요소의 값을 읽어 옵니다.
                foreach (XmlNode node in nodes)
                {
                    //node.ChildNodes[0].InnerText; //Item Name , here is tagname
                    //node.ChildNodes[1].LastChild.Name; // Item Type , here is tagtype
                    //node.ChildNodes[1].LastChild.InnerText; // Item value , here is tagvalue

                    string tagname = node.ChildNodes[0].InnerText;

                    switch (node.ChildNodes[1].LastChild.Name)
                    {
                        case "string":
                            ironSANClient1.WriteData(tagname, node.ChildNodes[1].LastChild.InnerText);
                            break;
                        case "double":
                            ironSANClient1.WriteData(tagname, Convert.ToDouble(node.ChildNodes[1].LastChild.InnerText));
                            break;
                        case "int32":
                            ironSANClient1.WriteData(tagname, Convert.ToInt32(node.ChildNodes[1].LastChild.InnerText));
                            break;
                        case "int16":
                            ironSANClient1.WriteData(tagname, Convert.ToInt16(node.ChildNodes[1].LastChild.InnerText));
                            break;
                        default:
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void analogBox_DataChanged(object sender, IronControls.ValueArgs e)
        {
            bt_save.Enabled = true;
        }

        private void analogBox_DataUpdated(object sender, IronControls.ValueArgs e)
        {
            //IronControls.AnalogBox box = sender as IronControls.AnalogBox;

            //if (values.ContainsKey(box.FirstTag))
            //{
            //    values[box.FirstTag] = double.Parse(e.newValue);
            //}
            //else
            //{
            //    values.Add(box.FirstTag, double.Parse(e.newValue));
            //}
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            this.WriteXML();

            //if (values != null)
            //{
            //    ConfigData x = new ConfigData();

            //    x.type = "String";
            //    x.sDtata = "Test";

            //    values.Add(x);

            //    IronControls.Utility.SerializeXML(ProjectPath + "\\Config\\", "Config.xml", typeof(List<ConfigData>), values);
            //}
        }

        private void bt_readXML_Click(object sender, EventArgs e)
        {
            this.ReadXML();
        }

        #endregion

        #region Database handling routine

        public static bool MDB_ExecuteNonQuery(string fullFilename, string strSQL)
        {
            //string db_pathrootname = ironSANClient1.ReadAny("SO.EEMS-R1.Path_Log").ToString().Trim();
            //string db_pathyearname = "2013";
            //string db_pathmonthname = "03";
            //string db_filename_Header = "DATALOG-EEMS-M1";
            //string fullFilename = db_pathrootname + "\\" + db_pathyearname + "\\" + db_pathmonthname + "\\" + db_filename_Header + ".mdb"; 
            //string fullFilename = "E:\\LOG_DATA\\2013\\DATALOG-EEMS-M1-201303.mdb";
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

        public static bool CreateMDBTables(string fullFilename)
        {
            try
            {
                bool QuyResult = false;

                // CREATE TABLE
                string strSQL = "CREATE TABLE  LOG_GAS (  번호 int identity, 시스템시간 varchar(20), 작업일자 varchar(20), 작업시간 varchar(20), 이름 varchar(20), 계량기값 int, 단위사용량 int, 적산사용량 int, " + "CONSTRAINT LOG_GAS_PrimaryKey PRIMARY KEY (번호))";
                QuyResult = MDB_ExecuteNonQuery(fullFilename, strSQL);

                if (QuyResult == false)
                {
                    return false;
                }

                strSQL = "CREATE TABLE  LOG_ELECTRIC (    번호 int identity, 시스템시간 varchar(20), 작업일자 varchar(20), 작업시간 varchar(20), 이름 varchar(20), 계량기값 int, 단위사용량 int, 적산사용량 int, " + "CONSTRAINT LOG_ELECTRIC_PrimaryKey PRIMARY KEY (번호))";
                QuyResult = MDB_ExecuteNonQuery(fullFilename, strSQL);

                if (QuyResult == false)
                {
                    return false;
                }

                strSQL = "CREATE TABLE  LOG_SCRAP_MEAS (  번호 int identity, 시스템시간 varchar(20), 작업일자 varchar(20), 작업시간 varchar(20), 이름 varchar(20), 계량기값 int, 단위사용량 int, 적산사용량 int, " + "CONSTRAINT LOG_SCRAP_MEAS_PrimaryKey PRIMARY KEY (번호))";
                QuyResult = MDB_ExecuteNonQuery(fullFilename, strSQL);

                if (QuyResult == false)
                {
                    return false;
                }

                strSQL = "CREATE TABLE  LOG_SCRAP_PUT (   번호 int identity, 시스템시간 varchar(20), 작업일자 varchar(20), 작업시간 varchar(20), 이름 varchar(20), 계량기값 int, 단위사용량 int, 적산사용량 int, " + "CONSTRAINT LOG_SCRAP_PUT_PrimaryKey PRIMARY KEY (번호))";
                QuyResult = MDB_ExecuteNonQuery(fullFilename, strSQL);

                if (QuyResult == false)
                {
                    return false;
                }

                strSQL = "CREATE TABLE  LOG_INGOT_MEAS (  번호 int identity, 시스템시간 varchar(20), 작업일자 varchar(20), 작업시간 varchar(20), 이름 varchar(20), 계량기값 int, 단위사용량 int, 적산사용량 int, " + "CONSTRAINT LOG_INGOT_MEAS_PrimaryKey PRIMARY KEY (번호))";
                QuyResult = MDB_ExecuteNonQuery(fullFilename, strSQL);

                if (QuyResult == false)
                {
                    return false;
                }

                strSQL = "CREATE TABLE  LOG_INGOT_PUT (   번호 int identity, 시스템시간 varchar(20), 작업일자 varchar(20), 작업시간 varchar(20), 이름 varchar(20), 계량기값 int, 단위사용량 int, 적산사용량 int, " + "CONSTRAINT LOG_INGOT_PUT_PrimaryKey PRIMARY KEY (번호))";
                QuyResult = MDB_ExecuteNonQuery(fullFilename, strSQL);

                if (QuyResult == false)
                {
                    return false;
                }

                strSQL = "CREATE TABLE  LOG_FULLDATA (  " +
                    " 번호 int identity, 시스템시간 varchar(20), 작업일자 varchar(20), 작업시간 varchar(20), " +
                    " 전력 varchar(20), 전력_PLC double, 전력사용량 double, 적산전력량 double, " +
                    " 가스 varchar(20), 가스_PLC double, 가스사용량 double, 적산가스량 double, " +
                    " 인고트 varchar(20), 인고트_PLC double, 인고트사용량 double, 적산인고트량 double, " +
                    " 스크랩 varchar(20), 스크랩_PLC double, 스크랩사용량 double, 적산스크랩량 double, " +
                    " 타워온도 varchar(20), 타워온도설정값_PLC int, 타워온도설정값 double, 타워온도_PLC int, 타워온도값 double," +
                    " 용탕온도 varchar(20), 용탕온도설정값_PLC int, 용탕온도설정값 double, 용탕온도_PLC int, 용탕온도값 double,"+
                    " CONSTRAINT LOG_FULLDATA_PrimaryKey PRIMARY KEY (번호))";

                QuyResult = MDB_ExecuteNonQuery(fullFilename, strSQL);

                if (QuyResult == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool CreateMDB(string fullFilename)
        {
            bool succeeded = false;
            try
            {
                int DFPoint = fullFilename.LastIndexOf('\\');
                string DirectoryPath = fullFilename.Remove(DFPoint);

                if (!Directory.Exists(DirectoryPath))
                {
                    Directory.CreateDirectory(DirectoryPath);
                }

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

            return MDB_ExecuteNonQuery(fullFilename, strSQL);
        }
        public static bool DropTable(string fullFilename, string tablename)
        {
            string strSQL = "DROP TABLE " + tablename;
            return MDB_ExecuteNonQuery(fullFilename, strSQL); 
        }

        public static bool InsertData(string fullFilename, string tablename)
        {
            DateTime dtCurrTime = DateTime.Now;
            string strDT = dtCurrTime.ToString("yyyy-MM-dd HH:mm:ss");

            //strSQL = "INSERT INTO " + tablename + "(번호, 시간, 이름, 누적값) " + //" (생산일시, 펄스카운트, 적산가스) " +
            //         " VALUES ( 1, '" + strDT + "', '1000', '10000')";

            string strSQL = "INSERT INTO " + tablename + "(시간, 이름, 누적값) " + //" (생산일시, 펄스카운트, 적산가스) " +
                        " VALUES ( '" + strDT + "', '1000', '10000')";

            return MDB_ExecuteNonQuery(fullFilename, strSQL);
        }

        #endregion

        #region Working time and periodic data logging

        DateTime ndt;                  // 시스템   현재시간
        DateTime rdt;                  // 작업기준 설정시간
        DateTime wdt;                  // 일작업   경과시간
        DateTime bdt;                  // 직전에 저장했던 분 : Periodic Data[분단위] 저장시점 구분용, 분이 변경됨을 확인하기 위한 용도 

        DateTime Lastcheckdt = DateTime.MinValue;
        int LogDelPeriod = -1;
        bool LogDelEnable = true;

        public void DeleteLog(string path, int val)
        {
            DirectoryInfo di = new DirectoryInfo(path);
           
            if (di.Exists == false) return;
            
            DateTime FileDate = new DateTime();
            DateTime DelFileDate = new DateTime();
          
            foreach( DirectoryInfo diy in di.GetDirectories())
            {
                foreach (FileInfo fi in diy.GetFiles())
                {
                    string FileName = fi.Name;
                    string FileNameDate = FileName.Substring(16, 7)+"-01";
                    FileDate = DateTime.Parse(FileNameDate);
                    DelFileDate = FileDate.AddMonths(val).AddHours(-6);

                    if (DateTime.Now > DelFileDate)
                    {
                        fi.Delete();
                    }
                }
                if (diy.GetFiles().Length == 0)
                {
                    diy.Delete();
                }
            }
            
        }

        private void CreteLogMaInfoXML(string Path_filename)
        {
            try
            {              
                
                // 생성할 XML 파일 경로와 이름, 인코딩 방식을 설정합니다.
                XmlTextWriter textWriter = new XmlTextWriter(Path_filename, Encoding.UTF8);

                // 들여쓰기 설정
                textWriter.Formatting = Formatting.Indented;

                // 문서에 쓰기를 시작합니다.
                textWriter.WriteStartDocument();
                textWriter.WriteStartElement("root");

                textWriter.WriteStartElement("Item");

                textWriter.WriteStartElement("Period");
                textWriter.WriteStartElement("string");
                textWriter.WriteString("12");
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("LastCheckDate");
                textWriter.WriteStartElement("string");
                textWriter.WriteString(DateTime.Now.ToString("yyyy/MM"));
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("Enable");
                textWriter.WriteStartElement("string");
                textWriter.WriteString("true");
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteEndElement();  

                textWriter.WriteEndElement();

                textWriter.WriteEndDocument();
                textWriter.Close();
            }
            catch (Exception)
            {
            }
        }

        private void SaveLogMaInfoXML(string Path_filename)
        {
            try
            {               

                // 생성할 XML 파일 경로와 이름, 인코딩 방식을 설정합니다.
                XmlTextWriter textWriter = new XmlTextWriter(Path_filename, Encoding.UTF8);

                // 들여쓰기 설정
                textWriter.Formatting = Formatting.Indented;

                // 문서에 쓰기를 시작합니다.
                textWriter.WriteStartDocument();
                textWriter.WriteStartElement("root");

                textWriter.WriteStartElement("Item");

                textWriter.WriteStartElement("Period");
                textWriter.WriteStartElement("string");
                textWriter.WriteString(LogDelPeriod.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("LastCheckDate");
                textWriter.WriteStartElement("string");
                textWriter.WriteString(DateTime.Now.ToString("yyyy/MM"));
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("Enable");
                textWriter.WriteStartElement("string");
                textWriter.WriteString("true");
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteEndElement();

                textWriter.WriteEndElement();

                textWriter.WriteEndDocument();
                textWriter.Close();
            }
            catch (Exception)
            {
            }
        }

        private void ReadLogMaInfoXML(string Path_filename)
        {
            try
            {               

                XmlDocument xmldoc = new XmlDocument();

                xmldoc.Load(Path_filename);
                XmlElement root = xmldoc.DocumentElement;

                // 노드 요소들
                XmlNodeList nodes = root.ChildNodes;

                int ItemCount = nodes.Count;               

                // 노드 요소의 값을 읽어 옵니다.
                foreach (XmlNode node in nodes)
                {
                    LogDelPeriod = int.Parse(node.ChildNodes[0].InnerText);
                    Lastcheckdt = DateTime.Parse(node.ChildNodes[1].InnerText);
                    LogDelEnable = bool.Parse(node.ChildNodes[2].InnerText);  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void timer_work_data_Tick(object sender, EventArgs e)
        {
            string db_pathrootname;
            string db_filename_Header = "DATALOG-EEMS-M1";
            string fullFilename;
            

            int nyear, nmonth, nday, nhour, nmin, nsec;  // 실제 현재시간을 분리한 값


            
            ndt = DateTime.Now;

            nyear = ndt.Year;
            nmonth = ndt.Month;
            nday = ndt.Day;
            nhour = ndt.Hour;
            nmin = ndt.Minute;
            nsec = ndt.Second;

            string LogCongifPath = this.ProjectPath + "\\Config\\LogMaInfo.xml";

            string ref_time = ironSANClient1.ReadAny("SO.EEMS-R1.ReferenceTime_Workday").ToString().Trim();

            rdt = DateTime.Parse(nyear.ToString() + "-" + nmonth.ToString() + "-" + nday.ToString() +
                                  " " + ref_time);

            TimeSpan ts = ndt - rdt;  // 시간차를 구함
            TimeSpan tts = rdt - rdt;  // 0시간 기준값을 만들어줌.

            DateTime zerotime = DateTime.Today;

            wdt = zerotime.Add(ts);


            db_pathrootname = ironSANClient1.ReadAny("SO.EEMS-R1.Path_Log").ToString().Trim();
            fullFilename = db_pathrootname + "\\" + ndt.ToString("yyyy") + "\\" + db_filename_Header + "-" + ndt.ToString("yyyy") + "-" + ndt.ToString("MM") + ".mdb";

            // 년도가 경과했으면 새로운 연도의 폴더를 만든다.
            if (ndt.Year != bdt.Year)
            {
                // 현재디렉토리를 로그폴더로 지정
                System.IO.Directory.SetCurrentDirectory(ironSANClient1.ReadAny("SO.EEMS-R1.Path_Log").ToString().Trim());

                string strNewYearFolder = ndt.ToString("yyyy");

                if (!System.IO.Directory.Exists(strNewYearFolder))
                {
                    System.IO.Directory.CreateDirectory(strNewYearFolder);
                }
            }           

            // 월이 경과했으며 새로운 월의 DB와 tables를 만든다.
            if (ndt.Month != bdt.Month || !File.Exists(fullFilename))
            {
                CreateMDB(fullFilename);
                CreateMDBTables(fullFilename);

                if (!File.Exists(LogCongifPath))
                {
                    CreteLogMaInfoXML(LogCongifPath);
                }

                ReadLogMaInfoXML(LogCongifPath);

                if (Lastcheckdt != DateTime.MinValue && LogDelPeriod > 0)
                {
                    if (Lastcheckdt.Year <= DateTime.Now.Year && Lastcheckdt.Month < DateTime.Now.Month)
                    DeleteLog(db_pathrootname, LogDelPeriod);

                    SaveLogMaInfoXML(LogCongifPath);

                }               

            }

            // 일이 경과했으면 새로운 ..
            // 시간이 경과했으면 새로운 ..
            // 분이 경과했으면 Periodic Data[분단위] 저장
            if (ndt.Minute != bdt.Minute)
            {
                Log_Per_Minute(fullFilename, ndt.ToString("yyyy-MM-dd HH:mm:ss"), wdt.ToString("yyyy-MM-dd"), wdt.ToString("yyyy-MM-dd HH:mm:ss"));
                CurrentData_Update();
                bdt = ndt;               
            }

        }

        public void Log_Per_Minute(string fullFilename, string sysTime, string workDay, string workElapsedTime)
        {

            string strQuery;
            string tablename;

            // 1분 전 데이타
            double acc_electric_before = 0.0;
            double acc_gas_before = 0.0;

            string db_filename_Header = "DATALOG-EEMS-M1";
            string BFfullFilename;

            string db_pathrootname = ironSANClient1.ReadAny("SO.EEMS-R1.Path_Log").ToString().Trim();
                      

            BFfullFilename = db_pathrootname + "\\" + ndt.AddMonths(-1).ToString("yyyy") + "\\" + db_filename_Header + "-" + ndt.AddMonths(-1).ToString("yyyy") + "-" + ndt.AddMonths(-1).ToString("MM") + ".mdb";


            try
            {
                
                //tablename = "LOG_ELECTRIC";
                //strQuery = "SELECT 계량기값 FROM " + tablename + " WHERE 시스템시간 LIKE '" + bdt.ToString("yyyy-MM-dd HH:mm") + "%'";
                tablename = "LOG_FULLDATA";
                strQuery = "SELECT 전력_PLC, 가스_PLC FROM " + tablename + " WHERE 시스템시간 LIKE '" + bdt.ToString("yyyy-MM-dd HH:mm") + "%'";
                DataSet ds3 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

                if (Convert.ToUInt16(ds3.Tables[0].Rows.Count) > 0)
                {
                    acc_electric_before = Convert.ToDouble(ds3.Tables[0].Rows[0][0]);
                    acc_gas_before = Convert.ToDouble(ds3.Tables[0].Rows[0][1]);
                }
                else
                {
                    // 직전의 데이타가 없다면 저장된 마지막 데이타를 가져오기 
                    strQuery = "SELECT MAX(시스템시간) FROM " + tablename;// +" GROUP BY Format(시스템시간,'yyyy-MM-dd HH:mm')";
                    DataSet ds1 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

                    if (Convert.ToUInt16(ds1.Tables[0].Rows.Count) > 0)
                    {
                        strQuery = "SELECT 전력_PLC, 가스_PLC FROM " + tablename + " WHERE 시스템시간 ='" + ds1.Tables[0].Rows[0][0] + "' ";
                          
                        DataSet ds2 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

                        if (Convert.ToUInt16(ds2.Tables[0].Rows.Count) > 0)
                        {
                            acc_electric_before = Convert.ToDouble(ds2.Tables[0].Rows[0][0]);
                            acc_gas_before = Convert.ToDouble(ds2.Tables[0].Rows[0][1]);
                        }
                        else
                        {
                            //이전 달 마지막 시간 데이타 가져오기
                            if (File.Exists(BFfullFilename))
                            {
                                strQuery = "SELECT MAX(시스템시간) FROM " + tablename;// +" GROUP BY Format(시스템시간,'yyyy-MM-dd HH:mm')";
                                DataSet bfds1 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + BFfullFilename, strQuery, tablename);

                                if (Convert.ToUInt16(bfds1.Tables.Count) > 0)
                                {
                                    if (Convert.ToUInt16(bfds1.Tables[0].Rows.Count) > 0)
                                    {
                                        strQuery = "SELECT 전력_PLC, 가스_PLC FROM " + tablename + " WHERE 시스템시간 ='" + bfds1.Tables[0].Rows[0][0] + "' ";

                                        DataSet bfds2 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + BFfullFilename, strQuery, tablename);

                                        if (Convert.ToUInt16(bfds2.Tables[0].Rows.Count) > 0)
                                        {
                                            acc_electric_before = Convert.ToDouble(bfds2.Tables[0].Rows[0][0]);
                                            acc_gas_before = Convert.ToDouble(bfds2.Tables[0].Rows[0][1]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                long acc_gas;
                long acc_electric;
                long plc_temp_tower;
                long plc_temp_tower_set;
                long plc_temp_furnace;
                long plc_temp_furnace_set;
                try
                {
                    acc_gas = Convert.ToInt32(opcClient2.ReadAny("PLC-XGK:D01000").ToString().Trim());
                    acc_electric = Convert.ToInt32(opcClient2.ReadAny("PLC-XGK:D00186").ToString().Trim());
                    plc_temp_tower = Convert.ToInt32(opcClient2.ReadAny("PLC-XGK:D00310").ToString().Trim());
                    plc_temp_tower_set = Convert.ToInt32(opcClient2.ReadAny("PLC-XGK:D00317").ToString().Trim());
                    plc_temp_furnace = Convert.ToInt32(opcClient2.ReadAny("PLC-XGK:D00300").ToString().Trim());
                    plc_temp_furnace_set = Convert.ToInt32(opcClient2.ReadAny("PLC-XGK:D00307").ToString().Trim());
                }
                catch
                {
                    //ksyu None TEST
                    acc_gas = 0;
                    acc_electric = 0;
                    plc_temp_tower = 0;
                    plc_temp_tower_set = 0;
                    plc_temp_furnace = 0;
                    plc_temp_furnace_set = 0;
                    return;
                }

                double d_pulse_factor = Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.pulse_per_gas").ToString().Trim()); // PLC 가스값을 실제값으로 환산하는 팩터
                double d_watt_factor = Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.plc_watt_per_pc_watt").ToString().Trim());  // PLC 전력값을 실제값으로 환산하는 팩터
                double d_temp_tower = Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.tower_temp_factor").ToString().Trim()); // PLC 온도를 소수점 환산하는 팩터
                double d_temp_furnace = Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.furnace_temp_factor").ToString().Trim());  // PLC 온도를 소수점 환산하는 팩터
                double d_temp_tower_set = Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.tower_temp_factor_set").ToString().Trim()); // PLC 온도를 소수점 환산하는 팩터
                double d_temp_furnace_set = Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.furnace_temp_factor_set").ToString().Trim());  // PLC 온도를 소수점 환산하는 팩터
               
                
                // 환산된 적산가스량
                double d_gasflow_acc = (double)acc_gas * d_pulse_factor;
                // 환산된 적산전력량
                double d_watt_acc = (double)acc_electric * d_watt_factor;               

                // 환산된 분당 사용전력량 : 계산식 변경해야 함.
                double d_watt_per_min;
                double gap_electric = acc_electric - acc_electric_before;

                if (gap_electric < 0)
                {
                    double d_watt_max_value = Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.PLC_Max_Watt").ToString().Trim()); // PLC 전력 최대값
                    gap_electric = acc_electric + (d_watt_max_value - acc_electric_before);
                }

                if (gap_electric != 0.0) d_watt_per_min = gap_electric * d_watt_factor;
                else d_watt_per_min = 0.0;

                // 환산된 분당 사용가스량 : 계산식 변경해야 함.
                double d_gasflow_per_min;
                double gap_gasflow = acc_gas - acc_gas_before;

                if (gap_gasflow < 0)
                {
                    double d_pulse_max_value = Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.PLC_Max_Gas").ToString().Trim()); // PLC 가스  최대값
                    gap_gasflow = acc_gas + (d_pulse_max_value - acc_gas_before);
                }


                if (gap_gasflow != 0.0) d_gasflow_per_min = gap_gasflow * d_pulse_factor;
                else d_gasflow_per_min = 0.0;

               

                // 환산된 타워온도 Set
                double temp_tower_Set;
                if (plc_temp_tower_set > 0 && d_temp_tower > 0.00) temp_tower_Set = plc_temp_tower_set * d_temp_tower;
                else temp_tower_Set = 0.0;
                // 환산된 용탕온도 Set
                double temp_furnace_Set;
                if (plc_temp_furnace_set > 0 && d_temp_furnace > 0.00) temp_furnace_Set = plc_temp_furnace_set * d_temp_furnace;
                else temp_furnace_Set = 0.0;

                // 환산된 타워온도 
                double temp_tower_real;
                if (plc_temp_tower > 0 && d_temp_tower > 0.00) temp_tower_real = plc_temp_tower * d_temp_tower;
                else temp_tower_real = 0.0;
                // 환산된 용탕온도
                double temp_furnace_real;
                if (plc_temp_furnace > 0 && d_temp_furnace > 0.00) temp_furnace_real = plc_temp_furnace * d_temp_furnace;
                else temp_furnace_real = 0.0;

                string str_d_gasflow_per_min = d_gasflow_per_min.ToString("0.0").Trim();
                string str_d_gasflow_acc = d_gasflow_acc.ToString("0.0").Trim();
                string str_d_watt_per_min = d_watt_per_min.ToString("0.0").Trim();
                string str_d_watt_acc = d_watt_acc.ToString("0.0").Trim();


                //MDB_ExecuteNonQuery(fullFilename, "INSERT INTO LOG_GAS      (시스템시간, 작업일자, 작업시간, 이름, 계량기값, 단위사용량, 적산사용량)  VALUES ( '"
                //    + ndt.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + wdt.ToString("yyyy-MM-dd") + "', '" + wdt.ToString("yyyy-MM-dd HH:mm:ss") + "', '적산GAS-S',"
                //    + acc_gas + "," + str_d_gasflow_per_min + "," + str_d_gasflow_acc + ")");
                //MDB_ExecuteNonQuery(fullFilename, "INSERT INTO LOG_ELECTRIC (시스템시간, 작업일자, 작업시간, 이름, 계량기값, 단위사용량, 적산사용량)  VALUES ( '"
                //    + ndt.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + wdt.ToString("yyyy-MM-dd") + "', '" + wdt.ToString("yyyy-MM-dd HH:mm:ss") + "', '적산전력-S',"
                //    + acc_electric + "," + str_d_watt_per_min + "," + str_d_watt_acc + ")");

                MDB_ExecuteNonQuery(fullFilename, "INSERT INTO LOG_FULLDATA (" +
                    " 시스템시간, 작업일자, 작업시간"+
                    ", 전력, 전력_PLC, 전력사용량, 적산전력량" +
                    ", 가스, 가스_PLC, 가스사용량, 적산가스량" +
                    ", 인고트, 인고트_PLC, 인고트사용량, 적산인고트량" +
                    ", 스크랩, 스크랩_PLC, 스크랩사용량, 적산스크랩량" +
                    ", 타워온도, 타워온도설정값_PLC, 타워온도설정값, 타워온도_PLC, 타워온도값" +
                    ", 용탕온도, 용탕온도설정값_PLC, 용탕온도설정값, 용탕온도_PLC, 용탕온도값" +
                    " )  VALUES ( '"
                    + ndt.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + wdt.ToString("yyyy-MM-dd") + "', '" + wdt.ToString("yyyy-MM-dd HH:mm:ss") +
                    //"', '적산전력-S'," + acc_electric + "," + d_watt_per_min.ToString("{0:0.0}").Trim() + "," + d_watt_acc.ToString("{0:0.0}").Trim() +
                    //", '적산GAS-S'," + acc_gas + "," + d_gasflow_per_min.ToString("{0:0.0}").Trim() + "," + d_gasflow_acc.ToString("{0:0.0}").Trim() + 
                    "', '적산전력-S'," + acc_electric + "," + d_watt_per_min + "," + d_watt_acc +
                    ", '적산GAS-S'," + acc_gas + "," + d_gasflow_per_min + "," + d_gasflow_acc + 
                    ", '인고트', 0, 0.0 , 0.0" +
                    ", '스크랩', 0, 0.0 , 0.0" +
                    ", '타워온도', " + plc_temp_tower_set + ", " + temp_tower_Set + ", " + plc_temp_tower + ", " + temp_tower_real +
                    ", '용탕온도', " + plc_temp_furnace_set + ", " + temp_furnace_Set + ", " + plc_temp_furnace + ", " + temp_furnace_real + 
                    " )" );

                //" 번호 int identity, 시스템시간 varchar(20), 작업일자 varchar(20), 작업시간 varchar(20), " +
                //" 전력 varchar(20), 전력_PLC double, 전력사용량 double, 적산전력량 double, " +
                //" 가스 varchar(20), 가스_PLC double, 가스사용량 double, 적산가스량 double, " +
                //" 인고트 varchar(20), 인고트_PLC double, 인고트사용량 double, 적산인고트량 double, " +
                //" 스크랩 varchar(20), 스크랩_PLC double, 스크랩사용량 double, 적산스크랩량 double, " +
                //" CONSTRAINT LOG_FULLDATA_PrimaryKey PRIMARY KEY (번호))";
            }
            catch (Exception)
            {
            }
        }

        public void CurrentData_Update()
        {
            string db_pathrootname;
            string db_filename_Header = "DATALOG-EEMS-M1";
            string fullFilename;

            string strQuery;
            string tablename;
            double dOrigin;
            double dFactor;

            double ScrValue = 0;
            double IgtValue = 0;

            double FullValue = 0;

            double SWePer = 0;
            double IWePer = 0;

            try
            {

                db_pathrootname = ironSANClient1.ReadAny("SO.EEMS-R1.Path_Log").ToString().Trim();
                fullFilename = db_pathrootname + "\\" + ndt.ToString("yyyy") + "\\" + db_filename_Header + "-" + ndt.ToString("yyyy") + "-" + ndt.ToString("MM") + ".mdb";


                //this.dataGridView1.DataSource = ds1.Tables[tablename];

                ScrValue = 0;
                IgtValue = 0;

                FullValue = 0;

                SWePer = 0;
                IWePer = 0;

                // 현재 시간값 업데이트
                tablename = "LOG_FULLDATA";
                strQuery = "SELECT SUM(스크랩_PLC) AS 분당투입량 FROM " + tablename + " WHERE 작업시간 LIKE '" +
                    wdt.ToString("yyyy-MM-dd HH") + "%' GROUP BY Format(작업시간,'yyyy-MM-dd HH') ";
                DataSet ds1 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

                if (Convert.ToUInt16(ds1.Tables[0].Rows.Count) > 0)
                {
                    dOrigin = Convert.ToDouble(ds1.Tables[0].Rows[0][0]);
                    dFactor = 0.1; //Convert.ToDouble(ironSANClient1.ReadAny("").ToString().Trim());                

                    if (dOrigin < 0.01 || dFactor < 0.01)
                    {
                        ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_Hour", 0.0);
                        ScrValue = 0;
                    }
                    else
                    {
                        ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_Hour", dOrigin * dFactor);
                        ScrValue = dOrigin * dFactor;
                    }


                }
                else
                {
                    ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_Hour", 0.0);
                    ScrValue = 0;
                }

                tablename = "LOG_FULLDATA";
                strQuery = "SELECT SUM(인고트_PLC) AS 분당투입량 FROM " + tablename + " WHERE 작업시간 LIKE '" +
                    wdt.ToString("yyyy-MM-dd HH") + "%' GROUP BY Format(작업시간,'yyyy-MM-dd HH') ";
                DataSet ds2 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

                if (Convert.ToUInt16(ds2.Tables[0].Rows.Count) > 0)
                {
                    dOrigin = Convert.ToDouble(ds2.Tables[0].Rows[0][0]);
                    dFactor = 0.1;// Convert.ToDouble(ironSANClient1.ReadAny("").ToString().Trim());

                    if (dOrigin < 0.01 || dFactor < 0.01)
                    {
                        ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_Hour", 0.0);
                        IgtValue = 0;
                    }
                    else
                    {
                        ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_Hour", dOrigin * dFactor);
                        IgtValue = dOrigin * dFactor;
                    }

                    // Put_all
                    dOrigin = Convert.ToDouble(ds1.Tables[0].Rows[0][0]) + Convert.ToDouble(ds2.Tables[0].Rows[0][0]);
                    dFactor = 0.1;// Convert.ToDouble(ironSANClient1.ReadAny("").ToString().Trim());

                    if (dOrigin < 0.01 || dFactor < 0.01)
                    {
                        ironSANClient1.WriteData("AO.EEMS-R1.Put_All_Per_Hour", 0.0);
                        FullValue = 0;
                        SWePer = 0;
                        IWePer = 0;
                    }
                    else
                    {
                        ironSANClient1.WriteData("AO.EEMS-R1.Put_All_Per_Hour", dOrigin * dFactor);
                        FullValue = dOrigin * dFactor;
                        SWePer = (ScrValue / FullValue) * 100;
                        IWePer = (IgtValue / FullValue) * 100;
                    }
                    ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_HourPe", SWePer);
                    ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_HourPe", IWePer);
                }
                else
                {
                    ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_Hour", 0.0);
                    IgtValue = 0;
                    ironSANClient1.WriteData("AO.EEMS-R1.Put_All_Per_Hour", 0.0);
                    FullValue = 0;
                    SWePer = 0;
                    IWePer = 0;
                    ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_HourPe", SWePer);
                    ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_HourPe", IWePer);
                }


                tablename = "LOG_FULLDATA";                
                strQuery = "SELECT SUM(전력사용량) AS 분당사용량 FROM " + tablename + " WHERE 작업시간 LIKE '" +
                    wdt.ToString("yyyy-MM-dd HH") + "%' GROUP BY Format(작업시간,'yyyy-MM-dd HH') ";
                DataSet ds3 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

                if (Convert.ToUInt16(ds3.Tables[0].Rows.Count) > 0)
                {
                    dOrigin = Convert.ToDouble(ds3.Tables[0].Rows[0][0]);
                    dFactor = Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.plc_watt_per_pc_watt").ToString().Trim());

                    if (dOrigin < 0.001 || dFactor < 0.001) ironSANClient1.WriteData("AO.EEMS-R1.Watt_Per_Hour", 0.0);
                    else ironSANClient1.WriteData("AO.EEMS-R1.Watt_Per_Hour", dOrigin);
                }
                else
                {
                    ironSANClient1.WriteData("AO.EEMS-R1.Watt_Per_Hour", 0.0);
                }



                tablename = "LOG_FULLDATA";
                strQuery = "SELECT SUM(가스사용량) AS 분당사용량 FROM " + tablename + " WHERE 작업시간 LIKE '" +
                    wdt.ToString("yyyy-MM-dd HH") + "%' GROUP BY Format(작업시간,'yyyy-MM-dd HH') ";
                DataSet ds4 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

                if (Convert.ToUInt16(ds4.Tables[0].Rows.Count) > 0)
                {
                    dOrigin = Convert.ToDouble(ds4.Tables[0].Rows[0][0]);
                    dFactor = 1.0; // Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.pulse_per_gas").ToString().Trim());

                    if (dOrigin < 0.01 || dFactor < 0.01) ironSANClient1.WriteData("AO.EEMS-R1.Gas_Per_Hour", 0.0);
                    else ironSANClient1.WriteData("AO.EEMS-R1.Gas_Per_Hour", dOrigin * dFactor);

                    //m3/ton
                    if (Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.Gas_Per_Hour")) < 0.01 || Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.Put_All_Per_Hour")) < 0.01) dOrigin = 0.0;
                    else dOrigin = Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.Gas_Per_Hour")) / (Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.Put_All_Per_Hour")) / 1000);

                    ironSANClient1.WriteData("AO.EEMS-R1.m3Ton_Per_Hour", dOrigin);
                }
                else
                {
                    ironSANClient1.WriteData("AO.EEMS-R1.Gas_Per_Hour", 0.0);
                    ironSANClient1.WriteData("AO.EEMS-R1.m3Ton_Per_Hour", 0.0);
                }

                ScrValue = 0;
                IgtValue = 0;

                FullValue = 0;

                SWePer = 0;
                IWePer = 0;

                // 현재 일자깂 업데이트
                tablename = "LOG_FULLDATA";
                strQuery = "SELECT SUM(스크랩_PLC) AS 시간당투입량 FROM " + tablename + " WHERE 작업시간 LIKE '" +
                    wdt.ToString("yyyy-MM-dd") + "%' GROUP BY Format(작업시간,'yyyy-MM-dd') ";
                ds1 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

                if (Convert.ToUInt16(ds1.Tables[0].Rows.Count) > 0)
                {
                    dOrigin = Convert.ToDouble(ds1.Tables[0].Rows[0][0]);
                    dFactor = 0.1; //Convert.ToDouble(ironSANClient1.ReadAny("").ToString().Trim());


                    if (dOrigin < 0.01 || dFactor < 0.01)
                    {
                        ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_Day", 0.0);
                        ScrValue = 0;
                    }
                    else
                    {
                        ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_Day", dOrigin * dFactor);
                        ScrValue = dOrigin * dFactor;
                    }
                }
                else
                {
                    ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_Day", 0.0);
                    ScrValue = 0;
                }

                tablename = "LOG_FULLDATA";
                strQuery = "SELECT SUM(인고트_PLC) AS 시간당투입량 FROM " + tablename + " WHERE 작업시간 LIKE '" +
                    wdt.ToString("yyyy-MM-dd") + "%' GROUP BY Format(작업시간,'yyyy-MM-dd') ";
                ds2 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

                if (Convert.ToUInt16(ds2.Tables[0].Rows.Count) > 0)
                {
                    dOrigin = Convert.ToDouble(ds2.Tables[0].Rows[0][0]);
                    dFactor = 0.1;// Convert.ToDouble(ironSANClient1.ReadAny("").ToString().Trim());

                    if (dOrigin < 0.01 || dFactor < 0.01)
                    {
                        ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_Day", 0.0);
                        IgtValue = 0;
                    }
                    else
                    {
                        ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_Day", dOrigin * dFactor);
                        IgtValue = dOrigin * dFactor;
                    }


                    // Put_all
                    dOrigin = Convert.ToDouble(ds1.Tables[0].Rows[0][0]) + Convert.ToDouble(ds2.Tables[0].Rows[0][0]);
                    dFactor = 0.1;// Convert.ToDouble(ironSANClient1.ReadAny("").ToString().Trim());

                    if (dOrigin < 0.01 || dFactor < 0.01)
                    {
                        ironSANClient1.WriteData("AO.EEMS-R1.Put_All_Per_Day", 0.0);

                        FullValue = 0;
                        SWePer = 0;
                        IWePer = 0;
                    }
                    else
                    {
                        ironSANClient1.WriteData("AO.EEMS-R1.Put_All_Per_Day", dOrigin * dFactor);
                        FullValue = dOrigin * dFactor;
                        SWePer = (ScrValue / FullValue) * 100;
                        IWePer = (IgtValue / FullValue) * 100;
                    }


                    ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_DayPe", SWePer);
                    ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_DayPe", IWePer);
                }
                else
                {
                    ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_Day", 0.0);
                    IgtValue = 0;
                    ironSANClient1.WriteData("AO.EEMS-R1.Put_All_Per_Day", 0.0);

                    FullValue = 0;
                    SWePer = 0;
                    IWePer = 0;
                    ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_DayPe", SWePer);
                    ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_DayPe", IWePer);
                }



                tablename = "LOG_FULLDATA";
                strQuery = "SELECT SUM(전력사용량) AS 시간당사용량 FROM " + tablename + " WHERE 작업시간 LIKE '" +
                    wdt.ToString("yyyy-MM-dd") + "%' GROUP BY Format(작업시간,'yyyy-MM-dd') ";
                ds3 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

                if (Convert.ToUInt16(ds3.Tables[0].Rows.Count) > 0)
                {
                    dOrigin = Convert.ToDouble(ds3.Tables[0].Rows[0][0]);
                    dFactor = Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.plc_watt_per_pc_watt").ToString().Trim());

                    if (dOrigin < 0.01 || dFactor < 0.01) ironSANClient1.WriteData("AO.EEMS-R1.Watt_Per_Day", 0.0);
                    else ironSANClient1.WriteData("AO.EEMS-R1.Watt_Per_Day", dOrigin);
                }
                else
                {
                    ironSANClient1.WriteData("AO.EEMS-R1.Watt_Per_Day", 0.0);
                }

                tablename = "LOG_FULLDATA";
                strQuery = "SELECT SUM(가스사용량) AS 시간당사용량 FROM " + tablename + " WHERE 작업시간 LIKE '" +
                    wdt.ToString("yyyy-MM-dd") + "%' GROUP BY Format(작업시간,'yyyy-MM-dd') ";
                ds4 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

                dOrigin = Convert.ToDouble(ds4.Tables[0].Rows[0][0]);
                dFactor = 1.0; // Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.pulse_per_gas").ToString().Trim());

                if (Convert.ToUInt16(ds4.Tables[0].Rows.Count) > 0)
                {
                    if (dOrigin < 0.01 || dFactor < 0.01) ironSANClient1.WriteData("AO.EEMS-R1.Gas_Per_Day", 0.0);
                    else ironSANClient1.WriteData("AO.EEMS-R1.Gas_Per_Day", dOrigin);

                    //m3/ton
                    if (Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.Gas_Per_Day")) < 0.01 || Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.Put_All_Per_Day")) < 0.01) dOrigin = 0.0;
                    else dOrigin = Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.Gas_Per_Day")) / (Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.Put_All_Per_Day")) / 1000);

                    ironSANClient1.WriteData("AO.EEMS-R1.m3Ton_Per_Day", dOrigin);
                }
                else
                {
                    ironSANClient1.WriteData("AO.EEMS-R1.Gas_Per_Day", 0.0);
                    ironSANClient1.WriteData("AO.EEMS-R1.m3Ton_Per_Day", 0.0);
                }

                ScrValue = 0;
                IgtValue = 0;

                FullValue = 0;

                SWePer = 0;
                IWePer = 0;

                // 현재 월값 업데이트
                tablename = "LOG_FULLDATA";
                strQuery = "SELECT SUM(스크랩_PLC) AS 일별투입량 FROM " + tablename + " WHERE 작업시간 LIKE '" +
                    wdt.ToString("yyyy-MM") + "%' GROUP BY Format(작업시간,'yyyy-MM') ";
                ds1 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

                if (Convert.ToUInt16(ds1.Tables[0].Rows.Count) > 0)
                {
                    dOrigin = Convert.ToDouble(ds1.Tables[0].Rows[0][0]);
                    dFactor = 0.1; //Convert.ToDouble(ironSANClient1.ReadAny("").ToString().Trim());

                    if (dOrigin < 0.01 || dFactor < 0.01)
                    {
                        ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_Month", 0.0);
                        ScrValue = 0;
                    }
                    else
                    {
                        ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_Month", dOrigin * dFactor);
                        ScrValue = dOrigin * dFactor;
                    }
                }
                else
                {
                    ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_Month", 0.0);
                    ScrValue = 0;
                }

                tablename = "LOG_FULLDATA";
                strQuery = "SELECT SUM(인고트_PLC) AS 일별투입량 FROM " + tablename + " WHERE 작업시간 LIKE '" +
                    wdt.ToString("yyyy-MM") + "%' GROUP BY Format(작업시간,'yyyy-MM') ";
                ds2 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

                if (Convert.ToUInt16(ds2.Tables[0].Rows.Count) > 0)
                {
                    dOrigin = Convert.ToDouble(ds2.Tables[0].Rows[0][0]);
                    dFactor = 0.1;// Convert.ToDouble(ironSANClient1.ReadAny("").ToString().Trim());

                    if (dOrigin < 0.01 || dFactor < 0.01)
                    {
                        ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_Month", 0.0);
                        IgtValue = 0;
                    }
                    else
                    {
                        ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_Month", dOrigin * dFactor);
                        IgtValue = dOrigin * dFactor;
                    }

                    // Put_all
                    dOrigin = Convert.ToDouble(ds1.Tables[0].Rows[0][0]) + Convert.ToDouble(ds2.Tables[0].Rows[0][0]);
                    dFactor = 0.1;// Convert.ToDouble(ironSANClient1.ReadAny("").ToString().Trim());

                    if (dOrigin < 0.01 || dFactor < 0.01)
                    {
                        ironSANClient1.WriteData("AO.EEMS-R1.Put_All_Per_Month", 0.0);
                        FullValue = 0;
                        SWePer = 0;
                        IWePer = 0;

                    }
                    else
                    {
                        ironSANClient1.WriteData("AO.EEMS-R1.Put_All_Per_Month", dOrigin * dFactor);
                        FullValue = dOrigin * dFactor;
                        SWePer = (ScrValue / FullValue) * 100;
                        IWePer = (IgtValue / FullValue) * 100;
                    }


                    ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_MonthPe", SWePer);
                    ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_MonthPe", IWePer);
                }
                else
                {
                    ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_Month", 0.0);
                    IgtValue = 0;
                    ironSANClient1.WriteData("AO.EEMS-R1.Put_All_Per_Month", 0.0);
                    FullValue = 0;
                    SWePer = 0;
                    IWePer = 0;
                    ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_MonthPe", SWePer);
                    ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_MonthPe", IWePer);
                }


                tablename = "LOG_FULLDATA";
                strQuery = "SELECT SUM(전력사용량) AS 일별사용량 FROM " + tablename + " WHERE 작업시간 LIKE '" +
                    wdt.ToString("yyyy-MM") + "%' GROUP BY Format(작업시간,'yyyy-MM') ";
                ds3 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

                if (Convert.ToUInt16(ds3.Tables[0].Rows.Count) > 0)
                {
                    dOrigin = Convert.ToDouble(ds3.Tables[0].Rows[0][0]);
                    dFactor = Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.plc_watt_per_pc_watt").ToString().Trim());

                    if (dOrigin < 0.01 || dFactor < 0.01)
                    {
                        ironSANClient1.WriteData("AO.EEMS-R1.Watt_Per_Month", 0.0);
                    }
                    else
                    {
                        ironSANClient1.WriteData("AO.EEMS-R1.Watt_Per_Month", dOrigin);
                    }
                }
                else
                {
                    ironSANClient1.WriteData("AO.EEMS-R1.Watt_Per_Month", 0.0);
                }

                tablename = "LOG_FULLDATA";
                strQuery = "SELECT SUM(가스사용량) AS 일별사용량 FROM " + tablename + " WHERE 작업시간 LIKE '" +
                    wdt.ToString("yyyy-MM") + "%' GROUP BY Format(작업시간,'yyyy-MM') ";
                ds4 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename, strQuery, tablename);

                if (Convert.ToUInt16(ds4.Tables[0].Rows.Count) > 0)
                {
                    dOrigin = Convert.ToDouble(ds4.Tables[0].Rows[0][0]);
                    dFactor = 1.0;// Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.pulse_per_gas").ToString().Trim());

                    if (dOrigin < 0.01 || dFactor < 0.01) ironSANClient1.WriteData("AO.EEMS-R1.Gas_Per_Month", 0.0);
                    else ironSANClient1.WriteData("AO.EEMS-R1.Gas_Per_Month", dOrigin);

                    //m3/ton
                    if (Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.Gas_Per_Month")) < 0.01 || Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.Put_All_Per_Month")) < 0.01) dOrigin = 0.0;
                    else dOrigin = Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.Gas_Per_Month")) / (Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.Put_All_Per_Month")) / 1000);

                    ironSANClient1.WriteData("AO.EEMS-R1.m3Ton_Per_Month", dOrigin);
                }
                else
                {
                    ironSANClient1.WriteData("AO.EEMS-R1.Gas_Per_Month", 0.0);
                    ironSANClient1.WriteData("AO.EEMS-R1.m3Ton_Per_Month", 0.0);
                }
                //////////////////////////////////////////////////////////////////////////////
                //ksyu 연간 현황은 사용하지 않으므로 부하 줄이기 위하여 막아놓았음 사용시 주석 해제
                //////////////////////////////////////////////////////////////////////////////

                //// 현재 연도값 업데이트
                ////연도에 맞게 월별 MDB 파일 마다 검색하여 합치도록 변경
                //DataSet Sumds1 = new DataSet();
                //DataSet Sumds2 = new DataSet();
                //DataSet Sumds3 = new DataSet();
                //DataSet Sumds4 = new DataSet();
               
                //string MonthFileName;
                //DateTime StartDate, EndDate;
                
                //StartDate = DateTime.Parse( ndt.ToString("yyyy") + "-1-1");
                //EndDate = StartDate.AddYears(1).AddDays(-1);   

                //tablename = "LOG_FULLDATA";
                //Sumds1.Clear();
                //for (DateTime i = StartDate; i < EndDate; i = i.AddMonths(1))
                //{
                //    MonthFileName = db_pathrootname + "\\" + ndt.ToString("yyyy") + "\\" + db_filename_Header + "-" + i.ToString("yyyy") + "-" + i.ToString("MM") + ".mdb";

                //    if (File.Exists(MonthFileName))
                //    {
                //        ds1.Clear();
                //        strQuery = "SELECT SUM(스크랩_PLC) AS 월별투입량 FROM " + tablename + " WHERE 작업시간 LIKE '" +
                //            wdt.ToString("yyyy") + "%' GROUP BY Format(작업시간,'yyyy') ";
                //        ds1 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MonthFileName, strQuery, tablename);
                       
                //        if (Sumds1.Tables.Count == 0)
                //        {
                //            Sumds1 = ds1.Clone();
                //        }
                //        Sumds1.Tables[0].Merge(ds1.Tables[0]);
                        
                //     }
                //    else
                //    {
                //        continue;
                //    }
                
                //}
                //if (Convert.ToUInt16(Sumds1.Tables[0].Rows.Count) > 0)
                //{
                //    //dOrigin = Convert.ToDouble(ds1.Tables[0].Rows[0][0]);
                //    dOrigin = Convert.ToDouble(Sumds1.Tables[0].Compute("SUM(월별투입량)", "1=1"));
                //    dFactor = 0.1; //Convert.ToDouble(ironSANClient1.ReadAny("").ToString().Trim());

                //    if (dOrigin < 0.01 || dFactor < 0.01)
                //    {
                //        ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_Year", 0.0);
                //        ScrValue = 0;
                //    }
                //    else
                //    {
                //        ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_Year", dOrigin * dFactor);
                //        ScrValue = dOrigin * dFactor;
                //    }
                //}
                //else
                //{
                //    ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_Year", 0.0);
                //    ScrValue = 0;
                //}

                //tablename = "LOG_FULLDATA";
                //Sumds2.Clear();
                //for (DateTime i = StartDate; i < EndDate; i = i.AddMonths(1))
                //{
                //    MonthFileName = db_pathrootname + "\\" + ndt.ToString("yyyy") + "\\" + db_filename_Header + "-" + i.ToString("yyyy") + "-" + i.ToString("MM") + ".mdb";

                //    if (File.Exists(MonthFileName))
                //    {
                //        ds2.Clear();
                //        strQuery = "SELECT SUM(인고트_PLC) AS 월별투입량 FROM " + tablename + " WHERE 작업시간 LIKE '" +
                //            wdt.ToString("yyyy") + "%' GROUP BY Format(작업시간,'yyyy') ";
                //        ds2 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MonthFileName, strQuery, tablename);

                //        if (Sumds2.Tables.Count == 0)
                //        {
                //            Sumds2 = ds2.Clone();
                //        }
                //        Sumds2.Tables[0].Merge(ds2.Tables[0]);

                //    }
                //    else
                //    {
                //        continue;
                //    }

                //}
                //if (Convert.ToUInt16(Sumds2.Tables[0].Rows.Count) > 0)
                //{
                //    //dOrigin = Convert.ToDouble(ds2.Tables[0].Rows[0][0]);
                //    dOrigin = Convert.ToDouble(Sumds2.Tables[0].Compute("SUM(월별투입량)", "1=1"));
                //    dFactor = 0.1;// Convert.ToDouble(ironSANClient1.ReadAny("").ToString().Trim());

                //    if (dOrigin < 0.01 || dFactor < 0.01)
                //    {
                //        ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_Year", 0.0);
                //        IgtValue = 0;
                //    }
                //    else
                //    {
                //        ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_Year", dOrigin * dFactor);
                //        IgtValue = dOrigin * dFactor;
                //    }

                //    // Put_all
                //    dOrigin = Convert.ToDouble(Sumds1.Tables[0].Compute("SUM(월별투입량)", "1=1")) + Convert.ToDouble(Sumds2.Tables[0].Compute("SUM(월별투입량)", "1=1"));
                //    dFactor = 0.1;// Convert.ToDouble(ironSANClient1.ReadAny("").ToString().Trim());

                //    if (dOrigin < 0.01 || dFactor < 0.01)
                //    {
                //        ironSANClient1.WriteData("AO.EEMS-R1.Put_All_Per_Year", 0.0);
                //        FullValue = 0;
                //        SWePer = 0;
                //        IWePer = 0;
                //    }
                //    else
                //    {
                //        ironSANClient1.WriteData("AO.EEMS-R1.Put_All_Per_Year", dOrigin * dFactor);
                //        FullValue = dOrigin * dFactor;
                //        SWePer = (ScrValue / FullValue) * 100;
                //        IWePer = (IgtValue / FullValue) * 100;
                //    }


                //    ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_YearPe", SWePer);
                //    ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_YearPe", IWePer);
                //}
                //else
                //{
                //    ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_Year", 0.0);
                //    IgtValue = 0;
                //    ironSANClient1.WriteData("AO.EEMS-R1.Put_All_Per_Year", 0.0);
                //    FullValue = 0;
                //    SWePer = 0;
                //    IWePer = 0;
                //    ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_YearPe", SWePer);
                //    ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_YearPe", IWePer);

                //}

                //tablename = "LOG_FULLDATA";
                //Sumds3.Clear();
                //for (DateTime i = StartDate; i < EndDate; i = i.AddMonths(1))
                //{
                //    MonthFileName = db_pathrootname + "\\" + ndt.ToString("yyyy") + "\\" + db_filename_Header + "-" + i.ToString("yyyy") + "-" + i.ToString("MM") + ".mdb";

                //    if (File.Exists(MonthFileName))
                //    {
                //        ds3.Clear();
                //        strQuery = "SELECT SUM(전력사용량) AS 월별사용량 FROM " + tablename + " WHERE 작업시간 LIKE '" +
                //                    wdt.ToString("yyyy") + "%' GROUP BY Format(작업시간,'yyyy') ";
                //        ds3 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MonthFileName, strQuery, tablename);
                //        if (Sumds3.Tables.Count == 0)
                //        {
                //            Sumds3 = ds3.Clone();
                //        }
                //        Sumds3.Tables[0].Merge(ds3.Tables[0]);
                        
                //     }
                //    else
                //    {
                //        continue;
                //    }
                //}

                //if (Convert.ToUInt16(Sumds3.Tables[0].Rows.Count) > 0)
                //{
                //    //dOrigin = Convert.ToDouble(ds3.Tables[0].Rows[0][0]);
                //    dOrigin = Convert.ToDouble(Sumds3.Tables[0].Compute("SUM(월별사용량)", "1=1"));
                //    dFactor = Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.plc_watt_per_pc_watt").ToString().Trim());

                //    if (dOrigin < 0.01 || dFactor < 0.01) ironSANClient1.WriteData("AO.EEMS-R1.Watt_Per_Year", 0.0);
                //    else ironSANClient1.WriteData("AO.EEMS-R1.Watt_Per_Year", dOrigin);
                //}
                //else
                //{
                //    ironSANClient1.WriteData("AO.EEMS-R1.Watt_Per_Year", 0.0);
                //}

                //tablename = "LOG_FULLDATA";
                //Sumds4.Clear();
                //for (DateTime i = StartDate; i < EndDate; i = i.AddMonths(1))
                //{
                //    MonthFileName = db_pathrootname + "\\" + ndt.ToString("yyyy") + "\\" + db_filename_Header + "-" + i.ToString("yyyy") + "-" + i.ToString("MM") + ".mdb";

                //    if (File.Exists(MonthFileName))
                //    {
                //        ds4.Clear();
                //        strQuery = "SELECT SUM(가스사용량) AS 월별사용량 FROM " + tablename + " WHERE 작업시간 LIKE '" +
                //                    wdt.ToString("yyyy") + "%' GROUP BY Format(작업시간,'yyyy') ";

                //        ds4 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MonthFileName, strQuery, tablename);
                
                //        if (Sumds4.Tables.Count == 0)
                //        {
                //            Sumds4 = ds4.Clone();
                //        }
                //        Sumds4.Tables[0].Merge(ds4.Tables[0]);

                //   }
                //   else
                //   {
                //       continue;
                //   }
                //}

                //if (Convert.ToUInt16(Sumds4.Tables[0].Rows.Count) > 0)
                //{
                //    //dOrigin = Convert.ToDouble(ds4.Tables[0].Rows[0][0]);
                //    dOrigin = Convert.ToDouble(Sumds4.Tables[0].Compute("SUM(월별사용량)", "1=1"));
                //    dFactor = 1.0; // Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.pulse_per_gas").ToString().Trim());

                //    if (dOrigin < 0.01 || dFactor < 0.01) ironSANClient1.WriteData("AO.EEMS-R1.Gas_Per_Year", 0.0);
                //    else ironSANClient1.WriteData("AO.EEMS-R1.Gas_Per_Year", dOrigin);

                //    //m3/ton
                //    if (Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.Gas_Per_Year")) < 0.01 || Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.Put_All_Per_Year")) < 0.01) dOrigin = 0.0;
                //    else dOrigin = Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.Gas_Per_Year")) / (Convert.ToDouble(ironSANClient1.ReadAny("AO.EEMS-R1.Put_All_Per_Year")) / 1000);

                //    ironSANClient1.WriteData("AO.EEMS-R1.m3Ton_Per_Year", dOrigin);
                //}
                //else
                //{
                //    ironSANClient1.WriteData("AO.EEMS-R1.Gas_Per_Year", 0.0);
                //    ironSANClient1.WriteData("AO.EEMS-R1.m3Ton_Per_Year", 0.0);
                //}
            }
            catch(Exception)
            {
            }
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
        #endregion

        private void bt_PLC_EXEC_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\XG5000\\XG5000.exe");
        }

        private void analogBox5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_HourPe", 52.122);
            ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_HourPe", 47.933);


            ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_DayPe", 53.122);
            ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_DayPe", 46.933);


            ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_MonthPe", 54.122);
            ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_MonthPe", 100.933);


            ironSANClient1.WriteData("AO.EEMS-R1.Scrap_Per_YearPe", 51.122);
            ironSANClient1.WriteData("AO.EEMS-R1.Ingot_Per_YearPe", 100.933);
        }

        #region sample code
        //// /<summary>
        ///// XML 생성
        ///// </summary>
        //private void CreateXML()
        //{
        //    // 생성할 XML 파일 경로와 이름, 인코딩 방식을 설정합니다.
        //    XmlTextWriter textWriter = new XmlTextWriter(@"C:\example.xml", Encoding.UTF8);
 
        //    // 들여쓰기 설정
        //    textWriter.Formatting = Formatting.Indented;
 
        //    // 문서에 쓰기를 시작합니다.
        //    textWriter.WriteStartDocument();
 
        //    // 루트 설정
        //    textWriter.WriteStartElement("root");
 
        //    // 노드와 값 설정
        //    textWriter.WriteStartElement("root_a");
        //    textWriter.WriteString("a");
        //    textWriter.WriteEndElement();
 
        //    // 노드 안에 하위 노드 설정
        //    textWriter.WriteStartElement("root_b");
 
        //    textWriter.WriteStartElement("b");
        //    textWriter.WriteString("b");
        //    textWriter.WriteEndElement();
 
        //    textWriter.WriteStartElement("bb");
        //    textWriter.WriteString("bb");
        //    textWriter.WriteEndElement();
 
        //    textWriter.WriteEndElement();
 
        //    textWriter.WriteStartElement("root_c");
        //    textWriter.WriteString("1");
        //    textWriter.WriteEndElement();
 
        //    textWriter.WriteEndElement();
 
        //    textWriter.WriteEndDocument();
        //    textWriter.Close();
        //}

        //private void bt_saveconfig_Click(object sender, EventArgs e)
        //{

        //}
        #endregion

    }
}
