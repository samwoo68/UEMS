using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;
using System.Threading;
using System.Collections.Concurrent;

namespace BasicPanel
{
	public partial class GEMForm : IronPanel.GEMForm
	{
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetLocalTime(ref SYSTEMTIME systemTime);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern void GetLocalTime(out SYSTEMTIME systemTime);
        [DllImport("kernel32.dll")]
        private static extern int GetLastError();


        bool processing = false;

        SECSII msg = null;
        HSMSForm hsmsParam = null;

        string configFile = "";
		//string downloadPPID = "";

		TerminalForm terminal = null;

		bool enableState = false;
		bool communicationState = false;
		string controlState = "OFF-LINE";
		bool spooling = false;

		List<int> allAlarms;

        static ConcurrentDictionary<int, TraceStruct> traceDic;
        static ConcurrentDictionary<int, double> traceCurTime;
        static ConcurrentDictionary<int, int> traceCount;

        Thread traceThread = null;
        static volatile bool _shouldStop = false;


        static ConcurrentDictionary<int, string> notificationIDDic;
        static ConcurrentDictionary<string, string> SVValueDic;

		public event EventHandler HostStateChanged = null;
		
		public enum ConnectState { CONNECTED, NOT_CONNECTED };
		public enum EnableState { ENABLE, DISABLE };
		public enum CommunicationState { WAIT_CRA, WAIT_DELAY, WAIT_CR_FROM_HOST, COMMUNICATING };
		public enum ControlState { EQUIP_OFFLINE, HOST_OFFLINE, ATTEMP_ONLINE, ON_LINE, LOCAL, REMOTE };

        public GEMForm()
		{
			InitializeComponent();

			msg = new SECSII(this);;

			allAlarms = new List<int>();
            traceDic = new ConcurrentDictionary<int, TraceStruct>();
            traceCurTime = new ConcurrentDictionary<int, double>();
            traceCount = new ConcurrentDictionary<int, int>();
            notificationIDDic = new ConcurrentDictionary<int, string>();
            SVValueDic = new ConcurrentDictionary<string, string>();
		}

		public void Initialize(string f)
        {
            configFile = f;

            hsmsParam = new HSMSForm(configFile);
            
            msg.S5Reply = hsmsParam.S5Reply;
            msg.S6Reply = hsmsParam.S6Reply;
            msg.S10Reply = hsmsParam.S10Reply;

            SECSControl.SecsConfigFile = configFile;
            SECSControl.StartXPro();

            string estime = GetECV("EstablishTimeout");

            if (estime != null && estime.Length > 0)
                timer_commDelay.Interval = int.Parse(estime) * 1000;

            traceThread = new Thread(TraceThreadProc);
            traceThread.IsBackground = true;
            traceThread.Start(this);

			GetStatusVariable();
			GetEquipmentConstant();
			GetAlarmType();
			GetCEID();

			if (GetECV("InitCommState") == "1")
			{
				ChangeEnable(EnableState.ENABLE);

				InitControlState();
			}
			else
				ChangeEnable(EnableState.DISABLE);
		}
        
        public void StopThread()
        {
            _shouldStop = true;

            traceThread.Join();
        }

        public void UpdateValue(int notificationID, object[] values)
        {
            string name  = notificationIDDic[notificationID];

            if (SVValueDic.ContainsKey(name))
            {
                SVValueDic[name] = values[0].ToString();
            }
            else
            {
                SVValueDic.TryAdd(name, values[0].ToString());
            }
        }

		private void GetStatusVariable()
		{
			this.variableDictionaryTableAdapter.Fill(this.variableDataSet.VariableDictionary);
			//this.equipmentConstantTableAdapter.Fill(this.variableDataSet.EquipmentConstant);

			msg.ClearVariableDic();

            DataRow[] rows = variableDataSet.VariableDictionary.Select("Dictionary = 'SV'", "VID");

            foreach (VariableDataSet.VariableDictionaryRow row in rows)
			{
				if (!row.IsDictionaryNull())
				{
                    string dic = row.IsDictionaryNull() ? "" : row.Dictionary;
					string name = row.IsNameNull() ? "" : row.Name;
					string type = row.IsTypeNull() ? "" : row.Type;
					string unit = row.IsUnitNull() ? "" : row.Unit;
					string io = row.IsIONull() ? "" : row.IO;

					msg.AddVariableDic(row.VID, dic, name, type, unit, io);

                    if (!row.IsIONull() && row.IO.IndexOf('.') != -1)
                    {
                        if (!SVValueDic.ContainsKey(name))
                        {
                            //int id = adsClient.Subscribe(row.IO, IronControls.UpdateMode.OnChange, 30, UpdateValue);

                            //notificationIDDic.TryAdd(id, name);
                            //SVValueDic.TryAdd(name, "");
                        }
                    }
				}
			}
		}

		private void GetEquipmentConstant()
		{
			this.equipmentConstantTableAdapter.Fill(this.variableDataSet.EquipmentConstant);

			msg.ClearECVDictionary();

            DataRow[] rows = variableDataSet.EquipmentConstant.Select("", "ECID");

            foreach (VariableDataSet.EquipmentConstantRow row in rows)
			{
				string name = row.IsECNAMENull() ? "" : row.ECNAME;
				string type = row.IsFormatNull() ? "" : row.Format;
				string unit = row.IsUnitNull() ? "" : row.Unit;
				string def = row.IsDefaultNull() ? "" : row.Default;
				string min = row.IsMinNull() ? "" : row.Min;
				string max = row.IsMaxNull() ? "" : row.Max;

				msg.AddECVDictionary(row.ECID, row.Bytes, name, type, unit, def, min, max);
			}
		}

		private void GetAlarmType()
		{
            //this.exceptionConditionTableAdapter.Fill(this.alarmDataSet.ExceptionCondition);

            //msg.ClearAlarmType();
            //allAlarms.Clear();

            //DataRow[] rows = alarmDataSet.ExceptionCondition.Select("", "ExceptionConditionID");

            //foreach (AlarmDataSet.ExceptionConditionRow row in rows)
            //{
            //    SECSII.AlarmType type = new SECSII.AlarmType();

            //    type.ALID = row.ExceptionConditionID;
				
            //    if (row.IsExAlarmCodeNull())
            //        type.ALCD = 0;
            //    else
            //        type.ALCD = row.ExAlarmCode;

            //    if (row.IsExMessageNull())
            //        type.ALTX = row.ExMessage;
            //    else
            //        type.ALTX = row.ExMessage;

            //    //if (!row.IsExEnabledNull() && row.ExEnabled == true)
            //    //	msg.AddAlarmEnable((ushort)row.ExceptionConditionID);

            //    msg.AddAlarmType(row.ExceptionConditionID, type);
            //    allAlarms.Add(row.ExceptionConditionID);
            //}
		}

		private void GetCEID()
		{
			this.collectionEventTableAdapter.Fill(this.variableDataSet.CollectionEvent);

			msg.ClearCEIDList();

            DataRow[] rows = variableDataSet.CollectionEvent.Select("", "CEID");

            foreach (VariableDataSet.CollectionEventRow row in rows)
			{
				if (row.Enable == true)
					msg.AddCEIDList(row.CEID);
			}
		}

        public string GetECV(string name)
        {
            string filter = "ECNAME = '" + name + "'";

            DataRow[] rows = variableDataSet.EquipmentConstant.Select(filter);

            if (rows.Length == 1)
            {
                VariableDataSet.EquipmentConstantRow row = (VariableDataSet.EquipmentConstantRow)rows[0];

                if (row.IsDefaultNull())
                    return "";
                else
                    return row.Default;
            }

            return "";
        }

        public bool SetECV(string name, string value)
        {
            string filter = "ECNAME = '" + name + "'";

            DataRow[] rows = variableDataSet.EquipmentConstant.Select(filter);

            if (rows.Length == 1)
            {
                VariableDataSet.EquipmentConstantRow row = (VariableDataSet.EquipmentConstantRow)rows[0];

                row.Default = value;

                try
                {
                    equipmentConstantTableAdapter.Update(row);
                }
                catch
                {
                    //MessageBox.Show(ex.Message);
                    return false;
                }

                return true;
            }

            return false;
        }

        public string GetVariable(string type, string name)
        {
            if (SVValueDic.ContainsKey(name))
            {
                return SVValueDic[name];
            }

            string filter = "Dictionary = '" + type + "' AND Name = '" + name + "'";

            DataRow[] rows = variableDataSet.VariableDictionary.Select(filter);

            if (rows.Length == 1)
            {
                VariableDataSet.VariableDictionaryRow row = (VariableDataSet.VariableDictionaryRow)rows[0];

                if (row.IsIONull())
                {
                    return "";
                }
                else
                {
                    //if ((type == "SV" || type == "DV") && row.IO.IndexOf('.') != -1)
                    //    return adsClient.ReadAny(row.IO).ToString();
                    //else
                    //    return row.IO;
                }
            }

            return "";
        }

        public bool SetVariable(string type, string name, string value)
        {
            string filter = "Dictionary = '" + type + "' AND Name = '" + name + "'";

            DataRow[] rows = variableDataSet.VariableDictionary.Select(filter);

            if (rows.Length == 1)
            {
                VariableDataSet.VariableDictionaryRow row = (VariableDataSet.VariableDictionaryRow)rows[0];

                row.IO = value;

                try
                {
                    variableDictionaryTableAdapter.Update(row);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
                
                return true;
            }

            return false;
        }

		public bool Connect
		{
			get
			{
				return textBox_Connection.Text == "CONNECTED";
			}
		}

		public string Communication
		{
			get
			{
				return textBox_communication.Text;
			}
		}

		public string Control
		{
			get
			{
				if (controlState.IndexOf("OFF-LINE") < controlState.Length)
					return textBox_online.Text;
				else
					return textBox_remote.Text;
			}
		}

		private void SendMsg(string msg)
		{
			if (enableState && communicationState && (controlState == "LOCAL" || controlState == "REMOTE"))
			{
				SECSControl.SendSecsMsg(msg);
			}
			else
			{
				int nStream = int.Parse(msg.Substring(msg.IndexOf('S') + 1, 1));
				int nFunction = int.Parse(msg.Substring(msg.IndexOf('F') + 1, 1));

				if (nFunction != 0 && nFunction % 2 == 0)
				{
					SECSControl.ResetSystemByte(nStream, nFunction - 1);
				}				
			}
		}

		private void FACtrl_OnSecsMsg(object sender, AxXPRO_XELib._DXPRO_XEEvents_OnSecsMsgEvent e)
		{
			if (enableState == false)
			{
				if (e.nFunction % 2 == 1)
					SECSControl.ResetSystemByte(e.nStream, e.nFunction);

				return;
			}


			if (textBox_communication.Text == "WAIT DELAY" && !(e.nStream == 1 && e.nFunction == 13))
			{
				ChangeCommunication(CommunicationState.WAIT_CRA);

				if (e.nFunction % 2 == 1)
					SECSControl.ResetSystemByte(e.nStream, e.nFunction);

				return;
			}
			
			if (communicationState == false && !((e.nStream == 1 && (e.nFunction == 13 || e.nFunction == 14))))
			{
				if (e.nFunction % 2 == 1)
					SECSControl.ResetSystemByte(e.nStream, e.nFunction);

				return;
			}
			else if (!(controlState == "LOCAL" || controlState == "REMOTE") && 
				e.nFunction % 2 == 1 && !((e.nStream == 1 && (e.nFunction == 13 || e.nFunction == 17)) || e.nStream == 9))
			{
				SECSControl.SetSystemByte(SECSControl.GetSystemByte((short)e.nStream, (short)e.nFunction));
				SECSControl.SendSecsMsg("<S" + e.nStream.ToString() + "F0,E>");
				return;
			}

            lock (this)
            {
                switch (e.nStream)
                {
                    #region S1
                    case 1:
                        switch (e.nFunction)
                        {
                            case 0:
                                ChangeControl(ControlState.EQUIP_OFFLINE);
                                SECSControl.SendSecsMsg(msg.S9F5(e.strHeader));
                                break;
                            case 1:
                                SendMsg(msg.S1F2());
                                break;
                            case 2:
                                {
                                    if (!CheckItemFormat(SECSControl.GetOneMsg(1, 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg(1, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    int list = int.Parse(SECSControl.GetOneMsg(1, 0, 0));

                                    if (list == 0)
                                    {
                                        string subOnline = GetECV("OnLineSubState");

                                        if (subOnline == "4")
                                            ChangeControl(ControlState.LOCAL);
                                        else if (subOnline == "5")
                                            ChangeControl(ControlState.REMOTE);
                                    }

                                    if (SECSControl.GetOneMsg(2, 0, 0).Length > 0)
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F11(e.strHeader));
                                        return;
                                    }
                                }
                                break;
                            case 3:
                                {
                                    if (!CheckItemFormat(SECSControl.GetOneMsg(1, 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg(1, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    short list = short.Parse(SECSControl.GetOneMsg(1, 0, 0));
                                    List<int> svid = new List<int>();

                                    if (list == 0)
                                    {
                                        if (SECSControl.GetOneMsg(2, 0, 0).Length > 0)
                                        {
                                            SECSControl.SendSecsMsg(msg.S9F11(e.strHeader));
                                            return;
                                        }

                                        SendMsg(msg.S1F4(null));
                                    }
                                    else
                                    {
                                        for (short i = 2; i <= list + 1; i++)
                                        {
                                            svid.Add(int.Parse(SECSControl.GetOneMsg(i, 0, 0)));
                                        }

                                        if (SECSControl.GetOneMsg((short)(list + 2), 0, 0).Length > 0)
                                        {
                                            SECSControl.SendSecsMsg(msg.S9F11(e.strHeader));
                                            return;
                                        }

                                        SendMsg(msg.S1F4(svid));
                                    }
                                }
                                break;
                            case 11:
                                {
                                    if (!CheckItemFormat(SECSControl.GetOneMsg(1, 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg(1, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    short list = short.Parse(SECSControl.GetOneMsg(1, 0, 0));
                                    List<int> svid = new List<int>();

                                    if (list == 0)
                                    {
                                        if (SECSControl.GetOneMsg(2, 0, 0).Length > 0)
                                        {
                                            SECSControl.SendSecsMsg(msg.S9F11(e.strHeader));
                                            return;
                                        }

                                        SendMsg(msg.S1F12(null));
                                    }
                                    else
                                    {
                                        for (short i = 2; i <= list + 1; i++)
                                        {
                                            svid.Add(int.Parse(SECSControl.GetOneMsg(i, 0, 0)));
                                        }

                                        if (SECSControl.GetOneMsg((short)(list + 2), 0, 0).Length > 0)
                                        {
                                            SECSControl.SendSecsMsg(msg.S9F11(e.strHeader));
                                            return;
                                        }

                                        SendMsg(msg.S1F12(svid));
                                    }
                                }
                                break;
                            case 13:
                                {
                                    if (!CheckItemFormat(SECSControl.GetOneMsg(1, 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg(1, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    if (SECSControl.GetOneMsg(2, 0, 0).Length > 0)
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F11(e.strHeader));
                                        return;
                                    }

                                    if (textBox_communication.Text == "COMMUNICATING")
                                    {
                                        SECSControl.SendSecsMsg(msg.S1F14(SECSII.COMMACK.Accepted));
                                    }
                                    else if (textBox_communication.Text == "WAIT CRA")
                                    {
                                        SECSControl.SendSecsMsg(msg.S1F14(SECSII.COMMACK.Accepted));
                                    }
                                    else
                                    {
                                        SECSControl.SendSecsMsg(msg.S1F14(SECSII.COMMACK.Accepted));
                                        ChangeCommunication(CommunicationState.COMMUNICATING);
                                    }
                                }
                                break;
                            case 14:
                                if (textBox_communication.Text == "WAIT CRA")
                                {
                                    if (!CheckItemFormat(SECSControl.GetOneMsg(1, 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg(1, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    if (!CheckItemFormat(SECSControl.GetOneMsg(2, 1, 0), "BIN") || !CheckItemData("BIN", SECSControl.GetOneMsg(2, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    if (!CheckItemFormat(SECSControl.GetOneMsg(3, 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg(3, 0, 0)) ||
                                        SECSControl.GetOneMsg(3, 0, 0) != "0")
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    if (SECSControl.GetOneMsg(4, 0, 0).Length > 0)
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F11(e.strHeader));
                                        return;
                                    }

                                    string bin = SECSControl.GetOneMsg(2, 0, 0);

                                    if (SECSControl.GetBinToInt(bin) == 0)
                                        ChangeCommunication(CommunicationState.COMMUNICATING);
                                    else
                                        ChangeCommunication(CommunicationState.WAIT_DELAY);
                                }
                                break;
                            case 15:
                                {
                                    if (SECSControl.GetOneMsg(1, 0, 0).Length > 0)
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F11(e.strHeader));
                                        return;
                                    }

                                    SendMsg(msg.S1F16());
                                    ChangeControl(ControlState.HOST_OFFLINE);
                                }
                                break;
                            case 17:
                                {
                                    if (SECSControl.GetOneMsg(1, 0, 0).Length > 0)
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F11(e.strHeader));
                                        return;
                                    }

                                    if (controlState == "HOST_OFF-LINE")
                                    {
                                        SECSControl.SendSecsMsg(msg.S1F18(SECSII.ONLACK.Accepted));
                                        ChangeControl(ControlState.LOCAL);
                                    }
                                    else if (controlState == "LOCAL" || controlState == "REMOTE")
                                    {
                                        SECSControl.SendSecsMsg(msg.S1F18(SECSII.ONLACK.AlreadyONLINE));
                                    }
                                    else
                                    {
                                        SECSControl.SendSecsMsg("<S1F0,E>");
                                    }
                                }
                                break;
                            default:
                                SECSControl.SendSecsMsg(msg.S9F5(e.strHeader));
                                break;
                        }
                        break;
                    #endregion

                    #region S2
                    case 2:
                        switch (e.nFunction)
                        {
                            case 13:
                                {
                                    if (!CheckItemFormat(SECSControl.GetOneMsg(1, 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg(1, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    short list = short.Parse(SECSControl.GetOneMsg(1, 0, 0));
                                    List<int> ECID = new List<int>();

                                    if (list == 0)
                                    {
                                        if (SECSControl.GetOneMsg(2, 0, 0).Length > 0)
                                        {
                                            SECSControl.SendSecsMsg(msg.S9F11(e.strHeader));
                                            return;
                                        }

                                        SendMsg(msg.S2F14(null));
                                    }
                                    else
                                    {
                                        for (short i = 2; i <= list + 1; i++)
                                        {
                                            if (!CheckItemFormat(SECSControl.GetOneMsg(i, 1, 0), "U2") || !CheckItemData("U2", SECSControl.GetOneMsg(i, 0, 0)))
                                            {
                                                SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                                return;
                                            }

                                            ECID.Add(int.Parse(SECSControl.GetOneMsg(i, 0, 0)));
                                        }

                                        if (SECSControl.GetOneMsg((short)(list + 2), 0, 0).Length > 0)
                                        {
                                            SECSControl.SendSecsMsg(msg.S9F11(e.strHeader));
                                            return;
                                        }

                                        SendMsg(msg.S2F14(ECID));
                                    }
                                }
                                break;
                            case 15:
                                {
                                    if (!CheckItemFormat(SECSControl.GetOneMsg(1, 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg(1, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    short list = short.Parse(SECSControl.GetOneMsg(1, 0, 0));

                                    if (SECSControl.GetOneMsg((short)(list * 3 + 2), 0, 0).Length > 0)
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F11(e.strHeader));
                                        return;
                                    }

                                    for (short i = 2; i < list * 3 + 2; i += 3)
                                    {
                                        if (!CheckItemFormat(SECSControl.GetOneMsg(i, 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg(i, 0, 0)))
                                        {
                                            SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                            return;
                                        }

                                        short sublist = short.Parse(SECSControl.GetOneMsg(i, 0, 0));

                                        if (sublist == 2)
                                        {
                                            if (!CheckItemFormat(SECSControl.GetOneMsg((short)(i + 1), 1, 0), "U2") || !CheckItemData("U2", SECSControl.GetOneMsg((short)(i + 1), 0, 0)))
                                            {
                                                SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                                return;
                                            }

                                            short ECID = short.Parse(SECSControl.GetOneMsg((short)(i + 1), 0, 0));
                                            string ECV = SECSControl.GetOneMsg((short)(i + 2), 0, 0);

                                            SECSII.VariableType var = msg.GetECV(ECID);

                                            if (var.vid == ECID)
                                            {
                                                if (var.type == "BIN" && ECV.Length == 2)
                                                {
                                                    byte value = new byte();
                                                    value |= byte.Parse((IronControls.Utility.ASCIItoBinary(ECV[0]) << 4).ToString());
                                                    value |= byte.Parse(IronControls.Utility.ASCIItoBinary(ECV[1]).ToString());

                                                    int min = 0;
                                                    int max = 0;

                                                    if (var.min.Length > 0)
                                                        min = int.Parse(var.min);

                                                    if (var.max.Length > 0)
                                                        max = int.Parse(var.min);

                                                    if (value < min || value > max)
                                                    {
                                                        SendMsg(msg.S2F16(3));
                                                        return;
                                                    }
                                                }
                                                else if (var.type == "BOOL")
                                                {
                                                }
                                                else if (var.type != "A")
                                                {
                                                    int value = 0;

                                                    if (ECV.Length > 0)
                                                        value = int.Parse(ECV);

                                                    int min = 0;
                                                    int max = 0;

                                                    if (var.min.Length > 0)
                                                        min = int.Parse(var.min);

                                                    if (var.max.Length > 0)
                                                        max = int.Parse(var.min);

                                                    if (value < min || value > max)
                                                    {
                                                        SendMsg(msg.S2F16(3));
                                                        return;
                                                    }
                                                }
                                                else
                                                {
                                                    SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                                    return;
                                                }

                                                SetECV("" + var.name, ECV);
                                            }
                                            else
                                            {
                                                SendMsg(msg.S2F16(1));
                                                return;
                                            }
                                        }
                                    }

                                    SendMsg(msg.S2F16(0));
                                }
                                break;
                            case 17:
                                {
                                    if (SECSControl.GetOneMsg(1, 0, 0).Length > 0)
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F11(e.strHeader));
                                        return;
                                    }

                                    SendMsg(msg.S2F18());
                                }
                                break;
                            case 21:
                                {
                                    if (!CheckItemFormat(SECSControl.GetOneMsg(1, 1, 0), "A") || !CheckItemData("A", SECSControl.GetOneMsg(1, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    int RCMD = int.Parse(SECSControl.GetOneMsg(1, 0, 0));
                                    byte CDMA = 0;

                                    switch (RCMD)
                                    {
                                        case 20:
                                            MessageBox.Show("PP-SELECT");
                                            break;
                                        case 21:
                                            MessageBox.Show("START");
                                            break;
                                        case 22:
                                            MessageBox.Show("STOP");
                                            break;
                                        case 23:
                                            MessageBox.Show("ABORT");
                                            break;
                                        default:
                                            CDMA = 1;
                                            break;
                                    }

                                    if (SECSControl.GetOneMsg(2, 0, 0).Length > 0)
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F11(e.strHeader));
                                        return;
                                    }

                                    SendMsg(msg.S2F22(CDMA));
                                }
                                break;
                            case 23:
                                {
                                    if (!CheckItemFormat(SECSControl.GetOneMsg(1, 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg(1, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    int trid = int.Parse(SECSControl.GetOneMsg(2, 0, 0));
                                    string dsper = SECSControl.GetOneMsg(3, 0, 0);
                                    int totsmp = int.Parse(SECSControl.GetOneMsg(4, 0, 0));
                                    int repgsz = int.Parse(SECSControl.GetOneMsg(5, 0, 0));

                                    short list = short.Parse(SECSControl.GetOneMsg(6, 0, 0));
                                    List<int> svid = new List<int>();

                                    for (short i = 7; i <= list + 6; i++)
                                    {
                                        svid.Add(int.Parse(SECSControl.GetOneMsg(i, 0, 0)));
                                    }

                                    if (traceDic.ContainsKey(trid))
                                    {
                                        TraceStruct oldTrace;
                                        double oldCurTime;
                                        int oldCount;

                                        if (!traceDic.TryRemove(trid, out oldTrace))
                                        {
                                            SendMsg(msg.S2F24(4));
                                            return;
                                        }

                                        if (!traceCurTime.TryRemove(trid, out oldCurTime))
                                        {
                                            SendMsg(msg.S2F24(4));
                                            return;
                                        }

                                        if (!traceCount.TryRemove(trid, out oldCount))
                                        {
                                            SendMsg(msg.S2F24(4));
                                            return;
                                        }
                                    }

                                    TimeSpan t = new TimeSpan(0,
                                                              int.Parse(dsper.Substring(0, 2)),
                                                              int.Parse(dsper.Substring(2, 2)),
                                                              int.Parse(dsper.Substring(4, 2)),
                                                              int.Parse(dsper.Substring(6, 2)) * 10);

                                    TraceStruct data = new TraceStruct();

                                    data.id = trid;
                                    data.time = t.TotalMilliseconds;
                                    data.totsmp = totsmp;
                                    data.svid = svid;

                                    if (!traceDic.TryAdd(trid, data))
                                    {
                                        SendMsg(msg.S2F24(4));
                                        return;
                                    }

                                    if (!traceCurTime.TryAdd(trid, 0))
                                    {
                                        SendMsg(msg.S2F24(4));
                                        return;
                                    }

                                    if (!traceCount.TryAdd(trid, 0))
                                    {
                                        SendMsg(msg.S2F24(4));
                                        return;
                                    }

                                    SendMsg(msg.S2F24(0));
                                }
                                break;
                            case 29:
                                {
                                    if (!CheckItemFormat(SECSControl.GetOneMsg(1, 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg(1, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    short list = short.Parse(SECSControl.GetOneMsg(1, 0, 0));
                                    List<int> ECID = new List<int>();

                                    if (SECSControl.GetOneMsg((short)(list + 2), 0, 0).Length > 0)
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F11(e.strHeader));
                                        return;
                                    }

                                    if (list == 0)
                                    {
                                        SendMsg(msg.S2F30(null));
                                    }
                                    else
                                    {
                                        for (short i = 2; i <= list + 1; i++)
                                        {
                                            if (!CheckItemFormat(SECSControl.GetOneMsg(i, 1, 0), "U2") || !CheckItemData("U2", SECSControl.GetOneMsg(i, 0, 0)))
                                            {
                                                SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                                return;
                                            }

                                            ECID.Add(int.Parse(SECSControl.GetOneMsg(i, 0, 0)));
                                        }

                                        SendMsg(msg.S2F30(ECID));
                                    }
                                }
                                break;
                            case 31:
                                {
                                    if (!CheckItemFormat(SECSControl.GetOneMsg(1, 1, 0), "A") || !CheckItemData("A", SECSControl.GetOneMsg(1, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    if (SECSControl.GetOneMsg(2, 0, 0).Length > 0)
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F11(e.strHeader));
                                        return;
                                    }

                                    string TIME = SECSControl.GetOneMsg(1, 0, 0);
                                    int TIACK = 0;

                                    if (TIME.Length == 12)
                                    {
                                        SYSTEMTIME st = new SYSTEMTIME();

                                        GetLocalTime(out st);

                                        st.Year = short.Parse("20" + TIME.Substring(0, 2));
                                        st.Month = short.Parse(TIME.Substring(2, 2));
                                        st.Day = short.Parse(TIME.Substring(4, 2));
                                        st.Hour = short.Parse(TIME.Substring(6, 2));
                                        st.Minute = short.Parse(TIME.Substring(8, 2));
                                        st.Second = short.Parse(TIME.Substring(10, 2));
                                        st.Milliseconds = 0;

                                        if (!SetLocalTime(ref st))
                                        {
                                            TIACK = 1;
                                        }
                                    }
                                    else if (TIME.Length == 16)
                                    {
                                        SYSTEMTIME st = new SYSTEMTIME();

                                        GetLocalTime(out st);

                                        st.Year = short.Parse(TIME.Substring(0, 4));
                                        st.Month = short.Parse(TIME.Substring(4, 2));
                                        st.Day = short.Parse(TIME.Substring(6, 2));
                                        st.Hour = short.Parse(TIME.Substring(8, 2));
                                        st.Minute = short.Parse(TIME.Substring(10, 2));
                                        st.Second = short.Parse(TIME.Substring(12, 2));
                                        st.Milliseconds = (short)(int.Parse(TIME.Substring(14, 2)) * 10);

                                        if (!SetLocalTime(ref st))
                                        {
                                            TIACK = 1;
                                        }
                                    }
                                    else
                                    {
                                        TIACK = 1;
                                    }

                                    SendMsg(msg.S2F32(TIACK));
                                }

                                break;
                            case 33:
                                {
                                    if (!CheckItemFormat(SECSControl.GetOneMsg(1, 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg(1, 0, 0)) ||
                                        SECSControl.GetOneMsg(1, 0, 0) != "2")
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    if (!CheckItemFormat(SECSControl.GetOneMsg(2, 1, 0), "U2") || !CheckItemData("U2", SECSControl.GetOneMsg(2, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    msg.DATAID = int.Parse(SECSControl.GetOneMsg(2, 0, 0));


                                    if (!CheckItemFormat(SECSControl.GetOneMsg(3, 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg(3, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    short list = short.Parse(SECSControl.GetOneMsg(3, 0, 0));
                                    short nextLine = 4;

                                    if (list == 0)
                                    {
                                        msg.ClearReportID();
                                    }
                                    else
                                    {
                                        Dictionary<int, List<int>> reportIdDic = new Dictionary<int, List<int>>();

                                        for (int i = 0; i < list; i++)
                                        {
                                            if (!CheckItemFormat(SECSControl.GetOneMsg((short)(nextLine + 1), 1, 0), "U2") || !CheckItemData("U2", SECSControl.GetOneMsg((short)(nextLine + 1), 0, 0)) ||
                                                !CheckItemFormat(SECSControl.GetOneMsg((short)(nextLine + 2), 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg((short)(nextLine + 2), 0, 0)))
                                            {
                                                SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                                return;
                                            }

                                            int RPTID = int.Parse(SECSControl.GetOneMsg((short)(nextLine + 1), 0, 0));
                                            short subList = short.Parse(SECSControl.GetOneMsg((short)(nextLine + 2), 0, 0));

                                            List<int> vids = new List<int>();

                                            for (short j = (short)(nextLine + 3); j < nextLine + 3 + subList; j++)
                                            {
                                                if (!CheckItemFormat(SECSControl.GetOneMsg(j, 1, 0), "U2") || !CheckItemData("U2", SECSControl.GetOneMsg(j, 0, 0)))
                                                {
                                                    SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                                    return;
                                                }

                                                int VID = int.Parse(SECSControl.GetOneMsg(j, 0, 0));

                                                if (msg.ContainVariableDic(VID))
                                                {
                                                    vids.Add(VID);
                                                }
                                                else
                                                {
                                                    SendMsg(msg.S2F34(4));
                                                    return;
                                                }
                                            }

                                            if (vids.Count > 0)
                                            {
                                                if (reportIdDic.ContainsKey(RPTID) || msg.ContainReportID(RPTID))
                                                {
                                                    SendMsg(msg.S2F34(3));
                                                    return;
                                                }
                                            }

                                            reportIdDic.Add(RPTID, vids);

                                            nextLine += (short)(subList + 3);
                                        }

                                        foreach (int RPTID in reportIdDic.Keys)
                                        {
                                            if (reportIdDic[RPTID].Count == 0)
                                                msg.RemoveReportID(RPTID);
                                            else
                                                msg.AddReportID(RPTID, reportIdDic[RPTID]);
                                        }
                                    }

                                    msg.SerializeEvent();
                                    SendMsg(msg.S2F34(0));
                                }
                                break;
                            case 35:
                                {
                                    if (!CheckItemFormat(SECSControl.GetOneMsg(1, 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg(1, 0, 0)) ||
                                        SECSControl.GetOneMsg(1, 0, 0) != "2")
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    if (!CheckItemFormat(SECSControl.GetOneMsg(2, 1, 0), "U2") || !CheckItemData("U2", SECSControl.GetOneMsg(2, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    msg.DATAID = int.Parse(SECSControl.GetOneMsg(2, 0, 0));


                                    if (!CheckItemFormat(SECSControl.GetOneMsg(3, 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg(3, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    short list = short.Parse(SECSControl.GetOneMsg(3, 0, 0));
                                    short nextLine = 4;

                                    Dictionary<int, List<int>> eventLink = new Dictionary<int, List<int>>();

                                    for (int i = 0; i < list; i++)
                                    {
                                        if (!CheckItemFormat(SECSControl.GetOneMsg((short)(nextLine + 1), 1, 0), "U2") || !CheckItemData("U2", SECSControl.GetOneMsg((short)(nextLine + 1), 0, 0)) ||
                                            !CheckItemFormat(SECSControl.GetOneMsg((short)(nextLine + 2), 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg((short)(nextLine + 2), 0, 0)))
                                        {
                                            SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                            return;
                                        }

                                        int CEID = int.Parse(SECSControl.GetOneMsg((short)(nextLine + 1), 0, 0));
                                        short subList = short.Parse(SECSControl.GetOneMsg((short)(nextLine + 2), 0, 0));
                                        List<int> reportId = new List<int>();

                                        try
                                        {
                                            for (short j = (short)(nextLine + 3); j < nextLine + 3 + subList; j++)
                                            {
                                                if (!CheckItemFormat(SECSControl.GetOneMsg(j, 1, 0), "U2") || !CheckItemData("U2", SECSControl.GetOneMsg(j, 0, 0)))
                                                {
                                                    SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                                    return;
                                                }

                                                int id = int.Parse(SECSControl.GetOneMsg(j, 0, 0));

                                                if (msg.ContainReportID(id))
                                                {
                                                    reportId.Add(id);
                                                }
                                                else
                                                {
                                                    SendMsg(msg.S2F36(5));
                                                    return;
                                                }
                                            }


                                            if (reportId.Count > 0)
                                            {
                                                if (eventLink.ContainsKey(CEID) || msg.ContainLinkEvent(CEID))
                                                {
                                                    SendMsg(msg.S2F36(3));
                                                    return;
                                                }
                                            }

                                            if (!msg.ContainCEID(CEID))
                                            {
                                                SendMsg(msg.S2F36(4));
                                                return;
                                            }

                                            eventLink.Add(CEID, reportId);

                                            nextLine += (short)(subList + 3);
                                        }
                                        catch (Exception ex)
                                        {
                                            //NETXPF.Win32.API.OutputDebugString(ex.Message);
                                        }
                                    }

                                    foreach (int CEID in eventLink.Keys)
                                    {
                                        if (eventLink[CEID].Count == 0)
                                            msg.RemoveLinkEvent(CEID);
                                        else
                                            msg.AddLinkEvnet(CEID, eventLink[CEID]);
                                    }

                                    msg.SerializeEvent();
                                    SendMsg(msg.S2F36(0));
                                }
                                break;
                            case 37:
                                {
                                    if (!CheckItemFormat(SECSControl.GetOneMsg(1, 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg(1, 0, 0)) ||
                                        SECSControl.GetOneMsg(1, 0, 0) != "2")
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    if (!CheckItemFormat(SECSControl.GetOneMsg(2, 1, 0), "BOOL") || !CheckItemData("BOOL", SECSControl.GetOneMsg(2, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    bool CEED = bool.Parse(SECSControl.GetOneMsg(2, 0, 0));


                                    if (!CheckItemFormat(SECSControl.GetOneMsg(3, 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg(3, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    short list = short.Parse(SECSControl.GetOneMsg(3, 0, 0));

                                    if (list == 0)
                                    {
                                        if (CEED == true)
                                            msg.AllCEIDEnable();
                                        else
                                            msg.AllCEIDDisble();
                                    }
                                    else
                                    {
                                        List<int> eventReport = new List<int>();

                                        for (short i = 4; i < list + 4; i++)
                                        {
                                            if (!CheckItemFormat(SECSControl.GetOneMsg(i, 1, 0), "U2") || !CheckItemData("U2", SECSControl.GetOneMsg(i, 0, 0)))
                                            {
                                                SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                                return;
                                            }

                                            int CEID = int.Parse(SECSControl.GetOneMsg(i, 0, 0));

                                            if (!msg.ContainCEID(CEID))
                                            {
                                                SendMsg(msg.S2F38(1));
                                                return;
                                            }

                                            eventReport.Add(CEID);
                                        }

                                        foreach (int CEID in eventReport)
                                        {
                                            if (CEED == true)
                                                msg.AddEventReport(CEID);
                                            else
                                                msg.RemoveEventReport(CEID);
                                        }
                                    }

                                    msg.SerializeEvent();
                                    SendMsg(msg.S2F38(0));
                                }
                                break;
                            case 41:
                                {
                                    if (!CheckItemFormat(SECSControl.GetOneMsg(2, 1, 0), "A") || !CheckItemData("A", SECSControl.GetOneMsg(2, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    string RCMD = SECSControl.GetOneMsg(2, 0, 0);
                                    int HCACK = 0;
                                    string subMsg = "";
                                    Dictionary<string, string> cpDic = new Dictionary<string, string>();
                                    Dictionary<string, string> ppidDic = new Dictionary<string, string>();

                                    if (RCMD == "LOCAL")
                                    {
                                        ChangeControl(ControlState.LOCAL);
                                        subMsg = "<L,0>";
                                    }
                                    else if (RCMD == "REMOTE")
                                    {
                                        ChangeControl(ControlState.REMOTE);
                                        subMsg = "<L,0>";
                                    }
                                    else if (RCMD == "PP-SELECT")
                                    {
                                        if (!CheckItemFormat(SECSControl.GetOneMsg(3, 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg(3, 0, 0)))
                                        {
                                            SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                            return;
                                        }

                                        int list = int.Parse(SECSControl.GetOneMsg(3, 0, 0));

                                        subMsg += "<L," + list.ToString();

                                        for (short i = 0; i < list * 3; i += 3)
                                        {
                                            int subList = int.Parse(SECSControl.GetOneMsg((short)(i + 4), 0, 0));
                                            string CPNAME = SECSControl.GetOneMsg((short)(i + 5), 0, 1);
                                            string CPVAL = SECSControl.GetOneMsg((short)(i + 6), 0, 1);

                                            if (!CheckItemFormat(SECSControl.GetOneMsg((short)(i + 4), 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg((short)(i + 4), 0, 0)) ||
                                                SECSControl.GetOneMsg((short)(i + 4), 0, 0) != "2")
                                            {
                                                SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                                return;
                                            }

                                            if (!CheckItemFormat(SECSControl.GetOneMsg((short)(i + 5), 1, 0), "A") || !CheckItemData("A", SECSControl.GetOneMsg((short)(i + 5), 0, 0)))
                                            {
                                                SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                                return;
                                            }

                                            if (CPNAME == "COUNT")
                                            {
                                                if (!CheckItemFormat(SECSControl.GetOneMsg((short)(i + 6), 1, 0), "U2") || !CheckItemData("U2", SECSControl.GetOneMsg((short)(i + 6), 0, 0)))
                                                {
                                                    SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                if (!CheckItemFormat(SECSControl.GetOneMsg((short)(i + 6), 1, 0), "A") || !CheckItemData("A", SECSControl.GetOneMsg((short)(i + 6), 0, 0)))
                                                {
                                                    SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                                    return;
                                                }
                                            }


                                            subMsg += "<L,2";
                                            subMsg += "<A[" + CPNAME.Length.ToString() + "]," + CPNAME + ">";



                                            switch (CPNAME)
                                            {
                                                case "LOTID":
                                                    cpDic.Add(CPNAME, CPVAL);
                                                    subMsg += "<BIN[1],00>";
                                                    break;
                                                case "PPID":
                                                    string[] split = CPVAL.Split(new char[] { ' ' });

                                                    if (split.Length != 2)
                                                    {
                                                        subMsg += "<BIN[1],03>";
                                                        HCACK = 3;
                                                    }
                                                    else
                                                    {
                                                        FileInfo file = new FileInfo(".\\Recipe\\" + split[0] + "\\" + split[1] + ".rcp");

                                                        if (!file.Exists)
                                                        {
                                                            //Recipe is nothing.
                                                            subMsg += "<BIN[1],02>";
                                                            HCACK = 3;
                                                        }
                                                        else if (processing)
                                                        {
                                                            subMsg += "<BIN[1],04>";
                                                            HCACK = 3;
                                                        }
                                                        else
                                                        {
                                                            cpDic.Add(CPNAME, ".\\Recipe\\" + split[0] + "\\" + split[1] + ".rcp");
                                                            ppidDic.Add(CPNAME, CPVAL);
                                                            subMsg += "<BIN[1],00>";
                                                        }
                                                    }
                                                    break;
                                                default:
                                                    subMsg += "<BIN[1],01>";
                                                    HCACK = 3;
                                                    break;
                                            }

                                            subMsg += ">";
                                        }

                                        subMsg += ">";
                                    }
                                    else
                                    {
                                        HCACK = 1;
                                        subMsg = "<L,0>";
                                    }


                                    if (HCACK == 0)
                                    {
                                        foreach (string name in cpDic.Keys)
                                        {
                                            switch (name)
                                            {
                                                case "PPID":
                                                    {
                                                        //if (UtilFunc.LoadRecipe(cpDic[name]))
                                                        //{
                                                        //    UtilFunc.DownloadRecipeData("Spin.iRcp");
                                                        //    SetVariable("SV", "PPExecName", ppidDic[name]);
                                                        //}
                                                        //RaiseEvent(401);
                                                    }
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                    }

                                    SendMsg(msg.S2F42(HCACK, subMsg));
                                }
                                break;
                            default:
                                SECSControl.SendSecsMsg(msg.S9F5(e.strHeader));
                                break;
                        }
                        break;
                    #endregion

                    #region S5
                    case 5:
                        switch (e.nFunction)
                        {
                            case 2:
                                break;
                            case 3:
                                {
                                    if (!CheckItemFormat(SECSControl.GetOneMsg(2, 1, 0), "BIN") || !CheckItemData("BIN", SECSControl.GetOneMsg(2, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    if (!CheckItemFormat(SECSControl.GetOneMsg(3, 1, 0), "U2") || !CheckItemData("U2", SECSControl.GetOneMsg(3, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    byte ALED = byte.Parse(SECSControl.GetOneMsg(2, 0, 0));
                                    ALED = (byte)(((ALED / 10) << 4) + ALED % 10);

                                    string ALID = SECSControl.GetOneMsg(3, 0, 0);

                                    if (ALID.Length == 0)
                                    {
                                        bool alarmEnable = false;

                                        if ((ALED & 0x80) > 0)
                                            alarmEnable = true;

                                        //foreach (AlarmDataSet.ExceptionConditionRow row in alarmDataSet.ExceptionCondition.Select("", "ExceptionConditionID"))
                                        //{
                                        //    row.ExEnabled = alarmEnable;

                                        //    if (alarmEnable)
                                        //        msg.AddAlarmEnable((ushort)row.ExceptionConditionID);
                                        //    else
                                        //        msg.RemoveAlarmEnable((ushort)row.ExceptionConditionID);
                                        //}

                                        //exceptionConditionTableAdapter.Update(alarmDataSet);

                                        SendMsg(msg.S5F4(0));
                                    }
                                    else
                                    {
                                        ushort id = ushort.Parse(ALID);
                                        //AlarmDataSet.ExceptionConditionRow row = (AlarmDataSet.ExceptionConditionRow)alarmDataSet.ExceptionCondition.Rows.Find(id);

                                        //if (row != null)
                                        //{
                                        //    if ((ALED & 0x80) > 0)
                                        //    {
                                        //        row.ExEnabled = true;
                                        //        msg.AddAlarmEnable(id);
                                        //    }
                                        //    else
                                        //    {
                                        //        row.ExEnabled = false;
                                        //        msg.RemoveAlarmEnable(id);
                                        //    }

                                        //    exceptionConditionTableAdapter.Update(row);
                                        //    SendMsg(msg.S5F4(0));
                                        //}
                                        //else
                                        //{
                                        //    SendMsg(msg.S5F4(1));
                                        //}
                                    }

                                    msg.SerializeAlarm();
                                }
                                break;
                            case 5:
                                {
                                    string item = (SECSControl.GetCompleteMsg());
                                    string value = "";

                                    if (item.Length > 11 && item.LastIndexOf('>') == item.Length - 1)
                                    {
                                        value = item.Substring(11, item.Length - 12);
                                        item = item.Substring(8, item.Length - 9);
                                    }


                                    if (!CheckItemFormat(item, "U2") || !CheckItemData("U2", value))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    string[] items = value.Split(new char[] { ',' });

                                    List<int> alids = new List<int>();

                                    for (int index = 0; index < items.Length; index++)
                                    {
                                        if (items[index].Length > 0)
                                            alids.Add(int.Parse(items[index].Trim()));
                                    }

                                    SendMsg(msg.S5F6(alids));
                                }
                                break;
                            case 7:
                                SendMsg(msg.S5F8());
                                break;
                            default:
                                SECSControl.SendSecsMsg(msg.S9F5(e.strHeader));
                                break;
                        }
                        break;
                    #endregion

                    #region S6
                    case 6:
                        switch (e.nFunction)
                        {
                            case 2:
                                break;
                            case 12:
                                break;
                            case 15:
                                {
                                    if (!CheckItemFormat(SECSControl.GetOneMsg(1, 1, 0), "U2") || !CheckItemData("U2", SECSControl.GetOneMsg(1, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    int CEID = int.Parse(SECSControl.GetOneMsg(1, 0, 0));

                                    SendMsg(msg.S6F16(CEID));
                                }
                                break;
                            case 19:
                                {
                                    if (!CheckItemFormat(SECSControl.GetOneMsg(1, 1, 0), "U2") || !CheckItemData("U2", SECSControl.GetOneMsg(1, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    int RPTID = int.Parse(SECSControl.GetOneMsg(1, 0, 0));

                                    SendMsg(msg.S6F20(RPTID));
                                }
                                break;
                            default:
                                SECSControl.SendSecsMsg(msg.S9F5(e.strHeader));
                                break;
                        }
                        break;
                    #endregion

                    #region S7
                    case 7:
                        switch (e.nFunction)
                        {
                            //case 1:
                            //    {
                            //        if (!CheckItemFormat(FACtrl.GetOneMsg(1, 1, 0), "L") || !CheckItemData("L", FACtrl.GetOneMsg(1, 0, 0)) ||
                            //            FACtrl.GetOneMsg(1, 0, 0) != "2")
                            //        {
                            //            FACtrl.SendSecsMsg(msg.S9F7(e.strHeader));
                            //            return;
                            //        }

                            //        if (!CheckItemFormat(FACtrl.GetOneMsg(2, 1, 0), "A") || !CheckItemData("A", FACtrl.GetOneMsg(2, 0, 0)))
                            //        {
                            //            FACtrl.SendSecsMsg(msg.S9F7(e.strHeader));
                            //            return;
                            //        }

                            //        if (!CheckItemFormat(FACtrl.GetOneMsg(3, 1, 0), "U4") || !CheckItemData("U4", FACtrl.GetOneMsg(3, 0, 0)))
                            //        {
                            //            FACtrl.SendSecsMsg(msg.S9F7(e.strHeader));
                            //            return;
                            //        }

                            //        string PPID = FACtrl.GetOneMsg(2, 0, 1);
                            //        long LENGTH = long.Parse(FACtrl.GetOneMsg(3, 0, 1));

                            //        string[] split = PPID.Split(new char[] { ',' });

                            //        if (split.Length != 2)
                            //        {
                            //            SendMsg(msg.S7F2(3));
                            //        }
                            //        else
                            //        {
                            //            DirectoryInfo dir = new DirectoryInfo(".\\Recipe\\" + split[0]);

                            //            FileInfo[] files = dir.GetFiles(split[1] + ".rcp");

                            //            if (files.Length > 0)
                            //                SendMsg(msg.S7F2(1));
                            //            else
                            //                SendMsg(msg.S7F2(0));
                            //        }
                            //    }
                            //    break;
                            //case 2:
                            //    break;
                            //case 3:
                            //    {
                            //        if (!CheckItemFormat(FACtrl.GetOneMsg(1, 1, 0), "L") || !CheckItemData("L", FACtrl.GetOneMsg(1, 0, 0)) ||
                            //            FACtrl.GetOneMsg(1, 0, 0) != "2")
                            //        {
                            //            FACtrl.SendSecsMsg(msg.S9F7(e.strHeader));
                            //            return;
                            //        }

                            //        if (!CheckItemFormat(FACtrl.GetOneMsg(2, 1, 0), "A") || !CheckItemData("A", FACtrl.GetOneMsg(2, 0, 0)))
                            //        {
                            //            FACtrl.SendSecsMsg(msg.S9F7(e.strHeader));
                            //            return;
                            //        }

                            //        if (!CheckItemFormat(FACtrl.GetOneMsg(3, 1, 0), "A") || !CheckItemData("A", FACtrl.GetOneMsg(3, 0, 0)))
                            //        {
                            //            FACtrl.SendSecsMsg(msg.S9F7(e.strHeader));
                            //            return;
                            //        }


                            //        string PPID = FACtrl.GetOneMsg(2, 0, 1);
                            //        string PPBODY = FACtrl.GetOneMsg(3, 0, 1);

                            //        string[] split = PPID.Split(new char[] { ' ' });

                            //        if (split.Length != 2)
                            //        {
                            //            SendMsg(msg.S7F4(4));
                            //        }
                            //        else
                            //        {
                            //            DirectoryInfo dir = new DirectoryInfo(".\\Recipe\\" + split[0]);

                            //            if (dir.Exists == false)
                            //                dir.Create();

                            //            FileInfo[] files = dir.GetFiles(split[1] + ".rcp");

                            //            try
                            //            {
                            //                using (FileStream fs = new FileStream(".\\Recipe\\" + split[0] + "\\" + split[1] + ".rcp", FileMode.Create))
                            //                {
                            //                    BinaryWriter write = new BinaryWriter(fs);

                            //                    string[] str = PPBODY.Split(new char[] { ' ' });

                            //                    foreach (string s in str)
                            //                    {
                            //                        if (s.Length == 2)
                            //                        {
                            //                            byte by = new byte();
                            //                            by |= byte.Parse((UtilFunc.ASCIItoBinary(s[0]) << 4).ToString());
                            //                            by |= byte.Parse(UtilFunc.ASCIItoBinary(s[1]).ToString());

                            //                            write.Write(by);
                            //                        }
                            //                        else
                            //                        {
                            //                            SendMsg(msg.S7F4(5));
                            //                            return;
                            //                        }
                            //                    }

                            //                    write.Close();
                            //                }

                            //                //Recipe_Editor.ppDownloaded = true;
                            //                SendMsg(msg.S7F4(0));
                            //            }
                            //            catch (Exception ex)
                            //            {
                            //                MainFrame.OutputDebugString(ex.Message);
                            //                break;
                            //            }
                            //        }
                            //    }
                            //    break;
                            //case 4:
                            //    {
                            //        if (!CheckItemFormat(FACtrl.GetOneMsg(1, 1, 0), "BIN") || !CheckItemData("BIN", FACtrl.GetOneMsg(1, 0, 0)))
                            //        {
                            //            FACtrl.SendSecsMsg(msg.S9F7(e.strHeader));
                            //            return;
                            //        }

                            //        string s = FACtrl.GetOneMsg(1, 0, 0);
                            //        byte ACKC7 = new byte();

                            //        ACKC7 |= byte.Parse((UtilFunc.ASCIItoBinary(s[0]) << 4).ToString());
                            //        ACKC7 |= byte.Parse(UtilFunc.ASCIItoBinary(s[1]).ToString());

                            //        if (ACKC7 != 0)
                            //        {
                            //            InputControls.SelectBox dlg = new InputControls.SelectBox();

                            //            dlg.Question = "Recipe Upload Fail.(ACKC7 :" + ACKC7.ToString() + ")";
                            //            dlg.LeftCommand = "";
                            //            dlg.RightCommand = "OK";
                            //            dlg.Owner = this;
                            //            dlg.StartPosition = FormStartPosition.CenterScreen;

                            //            dlg.Show();
                            //        }
                            //    }
                            //    break;
                            //case 5:
                            //    {
                            //        if (!CheckItemFormat(FACtrl.GetOneMsg(1, 1, 0), "A") || !CheckItemData("A", FACtrl.GetOneMsg(1, 0, 0)))
                            //        {
                            //            FACtrl.SendSecsMsg(msg.S9F7(e.strHeader));
                            //            return;
                            //        }

                            //        string PPID = FACtrl.GetOneMsg(1, 0, 1);

                            //        SendMsg(msg.S7F6(PPID));
                            //    }
                            //    break;
                            //case 6:
                            //    {
                            //        if (!CheckItemFormat(FACtrl.GetOneMsg(1, 1, 0), "L") || !CheckItemData("L", FACtrl.GetOneMsg(1, 0, 0)))
                            //        {
                            //            FACtrl.SendSecsMsg(msg.S9F7(e.strHeader));
                            //            return;
                            //        }

                            //        int list = int.Parse(FACtrl.GetOneMsg(1, 0, 0));

                            //        if (list != 2)
                            //        {
                            //            InputControls.SelectBox dlg = new InputControls.SelectBox();

                            //            dlg.Question = "Recipe Download Fail.";
                            //            dlg.LeftCommand = "";
                            //            dlg.RightCommand = "OK";
                            //            dlg.Owner = this;
                            //            dlg.StartPosition = FormStartPosition.CenterScreen;

                            //            dlg.Show();
                            //            return;
                            //        }


                            //        if (!CheckItemFormat(FACtrl.GetOneMsg(2, 1, 0), "A") || !CheckItemData("A", FACtrl.GetOneMsg(2, 0, 0)))
                            //        {
                            //            FACtrl.SendSecsMsg(msg.S9F7(e.strHeader));
                            //            return;
                            //        }

                            //        if (!CheckItemFormat(FACtrl.GetOneMsg(3, 1, 0), "BIN") || !CheckItemData("BIN", FACtrl.GetOneMsg(3, 0, 0)))
                            //        {
                            //            FACtrl.SendSecsMsg(msg.S9F7(e.strHeader));
                            //            return;
                            //        }

                            //        string PPID = FACtrl.GetOneMsg(2, 0, 1);
                            //        string PPBODY = FACtrl.GetOneMsg(3, 0, 1);

                            //        if (downloadPPID != PPID)
                            //        {
                            //            InputControls.SelectBox dlg = new InputControls.SelectBox();

                            //            dlg.Question = "Invalid Download Recipe.(" + PPID + ")";
                            //            dlg.LeftCommand = "";
                            //            dlg.RightCommand = "OK";
                            //            dlg.Owner = this;
                            //            dlg.StartPosition = FormStartPosition.CenterScreen;

                            //            dlg.Show();
                            //            return;
                            //        }

                            //        string[] split = PPID.Split(new char[] { ' ' });

                            //        if (split.Length != 2)
                            //        {
                            //            SendMsg(msg.S7F4(4));
                            //        }
                            //        else
                            //        {
                            //            DirectoryInfo dir = new DirectoryInfo(".\\Recipe\\" + split[0]);

                            //            if (dir.Exists == false)
                            //                dir.Create();

                            //            FileInfo[] files = dir.GetFiles(split[1] + ".rcp");

                            //            try
                            //            {
                            //                using (FileStream fs = new FileStream(".\\Recipe\\" + split[0] + "\\" + split[1] + ".rcp", FileMode.Create))
                            //                {
                            //                    BinaryWriter write = new BinaryWriter(fs);

                            //                    string[] str = PPBODY.Split(new char[] { ' ' });

                            //                    foreach (string s in str)
                            //                    {
                            //                        if (s.Length == 2)
                            //                        {
                            //                            byte by = new byte();
                            //                            by |= byte.Parse((UtilFunc.ASCIItoBinary(s[0]) << 4).ToString());
                            //                            by |= byte.Parse(UtilFunc.ASCIItoBinary(s[1]).ToString());

                            //                            write.Write(by);
                            //                        }
                            //                        else
                            //                        {
                            //                            SendMsg(msg.S7F4(5));
                            //                            return;
                            //                        }
                            //                    }

                            //                    write.Close();
                            //                }

                            //                //Recipe_Editor.ppDownloaded = true;
                            //            }
                            //            catch (Exception ex)
                            //            {
                            //                MainFrame.OutputDebugString(ex.Message);
                            //                break;
                            //            }
                            //        }
                            //    }
                            //    break;
                            //case 17:
                            //    {
                            //        if (!CheckItemFormat(FACtrl.GetOneMsg(1, 1, 0), "L") || !CheckItemData("L", FACtrl.GetOneMsg(1, 0, 0)))
                            //        {
                            //            FACtrl.SendSecsMsg(msg.S9F7(e.strHeader));
                            //            return;
                            //        }

                            //        int list = int.Parse(FACtrl.GetOneMsg(1, 0, 0));

                            //        if (list == 0)
                            //        {
                            //            //List<string> groups = GetGroupList("Spin1");

                            //            //foreach (string group in groups)
                            //            //{
                            //            //    List<string> recipes = GetRecipeList(group);

                            //            //    foreach (string recipe in recipes)
                            //            //    {
                            //            //        File.Delete(".\\Recipe\\" + group + "\\" + recipe + ".rcp");
                            //            //        File.Delete(".\\Recipe\\" + group + "\\" + recipe + ".data");
                            //            //    }

                            //            //    Directory.Delete(".\\Recipe\\" + group);
                            //            //}
                            //        }
                            //        else
                            //        {
                            //            for (short i = 2; i < list + 2; i++)
                            //            {
                            //                if (!CheckItemFormat(FACtrl.GetOneMsg(i, 1, 0), "A") || !CheckItemData("A", FACtrl.GetOneMsg(i, 0, 0)))
                            //                {
                            //                    FACtrl.SendSecsMsg(msg.S9F7(e.strHeader));
                            //                    return;
                            //                }

                            //                string PPID = FACtrl.GetOneMsg(i, 0, 1);

                            //                string[] split = PPID.Split(new char[] { ' ' });

                            //                if (split.Length == 2)
                            //                {
                            //                    List<string> recipes = GetRecipeList(split[0]);

                            //                    if (recipes.Contains(split[1]))
                            //                    {
                            //                        File.Delete(".\\Recipe\\" + split[0] + "\\" + split[1] + ".rcp");
                            //                    }
                            //                    else
                            //                    {
                            //                        SendMsg(msg.S7F18(4));
                            //                        return;
                            //                    }
                            //                }
                            //                else
                            //                {
                            //                    SendMsg(msg.S7F18(4));
                            //                    return;
                            //                }
                            //            }
                            //        }

                            //        SendMsg(msg.S7F18(0));
                            //    }
                            //    break;
                            case 19:
                                {
                                    List<string> recipes = new List<string>();

                                    List<string> groups = GetGroupList("PM1");

                                    foreach (string group in groups)
                                    {
                                        List<string> subs = GetRecipeList("PM1\\" + group);

                                        foreach (string recipe in subs)
                                        {
                                            recipes.Add("PM1 " + group + " " + recipe);
                                        }
                                    }

                                    SendMsg(msg.S7F20(recipes));
                                }
                                break;
                            //case 25:
                            //    {
                            //        if (!CheckItemFormat(FACtrl.GetOneMsg(1, 1, 0), "A") || !CheckItemData("A", FACtrl.GetOneMsg(1, 0, 0)))
                            //        {
                            //            FACtrl.SendSecsMsg(msg.S9F7(e.strHeader));
                            //            return;
                            //        }

                            //        string PPID = FACtrl.GetOneMsg(1, 0, 1);
                            //        List<string> ppids = GetRecipeList();

                            //        SendMsg(msg.S7F26(PPID, ppids));
                            //    }
                            //    break;
                            default:
                                SECSControl.SendSecsMsg(msg.S9F5(e.strHeader));
                                break;
                        }
                        break;
                    #endregion

                    #region S10
                    case 10:
                        switch (e.nFunction)
                        {
                            case 2:
                                {
                                    if (!CheckItemFormat(SECSControl.GetOneMsg(1, 1, 0), "BIN") || !CheckItemData("BIN", SECSControl.GetOneMsg(1, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    string s = SECSControl.GetOneMsg(1, 0, 0);
                                    byte ACKC10 = new byte();

                                    ACKC10 |= byte.Parse((IronControls.Utility.ASCIItoBinary(s[0]) << 4).ToString());
                                    ACKC10 |= byte.Parse(IronControls.Utility.ASCIItoBinary(s[1]).ToString());
                                }
                                break;
                            case 3:
                                {
                                    if (!CheckItemFormat(SECSControl.GetOneMsg(1, 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg(1, 0, 0)) ||
                                        SECSControl.GetOneMsg(1, 0, 0) != "2")
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    if (!CheckItemFormat(SECSControl.GetOneMsg(2, 1, 0), "BIN") || !CheckItemData("BIN", SECSControl.GetOneMsg(2, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    if (!CheckItemFormat(SECSControl.GetOneMsg(3, 1, 0), "A") || !CheckItemData("A", SECSControl.GetOneMsg(3, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    string s = SECSControl.GetOneMsg(2, 0, 0);
                                    byte TID = new byte();

                                    TID |= byte.Parse((IronControls.Utility.ASCIItoBinary(s[0]) << 4).ToString());
                                    TID |= byte.Parse(IronControls.Utility.ASCIItoBinary(s[1]).ToString());


                                    string text = SECSControl.GetOneMsg(3, 0, 0);

                                    if (terminal == null)
                                    {
                                        terminal = new TerminalForm();
                                        terminal.RecognizeMessage += RecognizeMessage;
                                    }

                                    if (text.Length > 0)
                                    {
                                        terminal.Message = text;
                                        terminal.Show();
                                    }
                                    else
                                    {
                                        terminal.Hide();
                                    }

                                    SendMsg(msg.S10F4(0));
                                }
                                break;

                            case 5:
                                {
                                    if (!CheckItemFormat(SECSControl.GetOneMsg(1, 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg(1, 0, 0)) ||
                                        SECSControl.GetOneMsg(1, 0, 0) != "2")
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    if (!CheckItemFormat(SECSControl.GetOneMsg(2, 1, 0), "BIN") || !CheckItemData("BIN", SECSControl.GetOneMsg(2, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    if (!CheckItemFormat(SECSControl.GetOneMsg(3, 1, 0), "L") || !CheckItemData("L", SECSControl.GetOneMsg(3, 0, 0)))
                                    {
                                        SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                        return;
                                    }

                                    string s = SECSControl.GetOneMsg(2, 0, 0);
                                    byte TID = new byte();

                                    TID |= byte.Parse((IronControls.Utility.ASCIItoBinary(s[0]) << 4).ToString());
                                    TID |= byte.Parse(IronControls.Utility.ASCIItoBinary(s[1]).ToString());

                                    short list = short.Parse(SECSControl.GetOneMsg(3, 0, 0));

                                    List<string> text = new List<string>();
                                    string disMsg = "";

                                    for (short i = 4; i < list + 4; i++)
                                    {
                                        if (!CheckItemFormat(SECSControl.GetOneMsg(i, 1, 0), "A") || !CheckItemData("A", SECSControl.GetOneMsg(i, 0, 0)))
                                        {
                                            SECSControl.SendSecsMsg(msg.S9F7(e.strHeader));
                                            return;
                                        }

                                        text.Add(SECSControl.GetOneMsg(i, 0, 0));
                                    }

                                    foreach (string str in text)
                                    {
                                        disMsg += str + "\n";
                                    }

                                    if (terminal == null)
                                    {
                                        terminal = new TerminalForm();
                                        terminal.RecognizeMessage += RecognizeMessage;
                                    }

                                    if (disMsg.Length > 0)
                                    {
                                        terminal.Message = disMsg;
                                        terminal.Show();
                                    }
                                    else
                                    {
                                        terminal.Hide();
                                    }

                                    SendMsg(msg.S10F6(0));
                                }
                                break;
                            default:
                                SECSControl.SendSecsMsg(msg.S9F5(e.strHeader));
                                break;
                        }
                        break;
                    #endregion

                    #region S14
                    case 14:
                        switch (e.nFunction)
                        {
                            case 1:
                                {
                                    SendMsg(msg.S14F2());
                                }
                                break;
                            case 3:
                                {
                                    SendMsg(msg.S14F4());
                                }
                                break;
                            case 9:
                                {
                                    SendMsg(msg.S14F10());
                                }
                                break;
                            case 11:
                                {
                                    SendMsg(msg.S14F12());
                                }
                                break;
                            default:
                                SECSControl.SendSecsMsg(msg.S9F5(e.strHeader));
                                break;
                        }
                        break;
                    #endregion

                    #region S16
                    case 16:
                        switch (e.nFunction)
                        {
                            case 5:
                                {
                                    SendMsg(msg.S16F6());
                                }
                                break;
                            case 11:
                                {
                                    SendMsg(msg.S16F12());
                                }
                                break;
                            case 13:
                                {
                                    SendMsg(msg.S16F14());
                                }
                                break;
                            case 15:
                                {
                                    SendMsg(msg.S16F16());
                                }
                                break;
                            case 17:
                                {
                                    SendMsg(msg.S16F18());
                                }
                                break;
                            case 19:
                                {
                                    SendMsg(msg.S16F20());
                                }
                                break;
                            case 21:
                                {
                                    SendMsg(msg.S16F22());
                                }
                                break;
                            case 23:
                                {
                                    SendMsg(msg.S16F24());
                                }
                                break;
                            case 25:
                                {
                                    SendMsg(msg.S16F26());
                                }
                                break;
                            case 27:
                                {
                                    SendMsg(msg.S16F28());
                                }
                                break;
                            default:
                                SECSControl.SendSecsMsg(msg.S9F5(e.strHeader));
                                break;
                        }
                        break;
                    #endregion

                    #region S18
                    case 18:
                        switch (e.nFunction)
                        {
                            case 5:
                                {
                                    SendMsg(msg.S18F6());
                                }
                                break;
                            case 7:
                                {
                                    SendMsg(msg.S18F8());
                                }
                                break;
                            case 9:
                                {
                                    SendMsg(msg.S18F10());
                                }
                                break;
                            case 11:
                                {
                                    SendMsg(msg.S18F12());
                                }
                                break;
                            case 13:
                                {
                                    SendMsg(msg.S18F14());
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion
                }
            }
		}

		private void FACtrl_OnSecsTimeOut(object sender, AxXPRO_XELib._DXPRO_XEEvents_OnSecsTimeOutEvent e)
		{
			if (e.nTimer == 3)
			{
				string SHEAD = "00 00 ";
				SHEAD += string.Format("{0:X}{1:X}", ((0x80 | e.nStream) >> 4) & 0xf, (0x80 | e.nStream) & 0xf)+ " ";
				SHEAD += string.Format("{0:X}{1:X}", (e.nFunction >> 4) & 0xf, e.nFunction & 0xf)+ " ";
				SHEAD += "00 00 ";
				SHEAD += string.Format("{0:X}{1:X}", ((e.nSystemByte >> 24) >> 4) & 0xf, (e.nSystemByte >> 24) & 0xf) + " ";
				SHEAD += string.Format("{0:X}{1:X}", ((e.nSystemByte >> 16) >> 4) & 0xf, (e.nSystemByte >> 16) & 0xf) + " ";
				SHEAD += string.Format("{0:X}{1:X}", ((e.nSystemByte >> 8) >> 4) & 0xf, (e.nSystemByte >> 8) & 0xf) + " ";
				SHEAD += string.Format("{0:X}{1:X}", (e.nSystemByte >> 4) & 0xf, e.nSystemByte & 0xf) + " ";

				SendMsg(msg.S9F9(SHEAD));

				switch (e.nStream)
				{
					case 1:
						switch (e.nFunction)
						{
							case 1:
								{
									button_online.Enabled = true;

									string subOnlineFail = GetECV("OnLineFailed");

									if (subOnlineFail == "1")
										ChangeControl(ControlState.EQUIP_OFFLINE);
									else if (subOnlineFail == "2")
										ChangeControl(ControlState.HOST_OFFLINE);
								}
								break;
							case 13:
								if (textBox_communication.Text != "COMMUNICATING")
								{
									ChangeCommunication(CommunicationState.WAIT_DELAY);
								}
								break;
							default:
								break;
						}
						break;
					case 7:
						switch (e.nFunction)
						{
							case 3:
								{
                                    MessageBox.Show("Recipe Upload Fail.(T3 Timeout)");
								}
								break;
							case 5:
								{
                                    MessageBox.Show("Recipe Download Fail.(T3 Timeout)");
								}
								break;
							default:
								break;
						}
						break;
					default:
						break;
				}
			}
		}

		private void FACtrl_OnDisconnected(object sender, EventArgs e)
		{
			ChangeConnect(ConnectState.NOT_CONNECTED);
		}

		private void FACtrl_OnSelected(object sender, EventArgs e)
		{
			ChangeConnect(ConnectState.CONNECTED);
		}

		private void button_close_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void button_parameter_Click(object sender, EventArgs e)
		{
			if (hsmsParam == null)
				return;

			if (hsmsParam.ShowDialog() == DialogResult.OK)
			{
				SECSControl.SecsConfigFile = configFile;

				msg.S5Reply = hsmsParam.S5Reply;
				msg.S6Reply = hsmsParam.S6Reply;
				msg.S10Reply = hsmsParam.S10Reply;

				SECSControl.StopXPro();

				ChangeConnect(ConnectState.NOT_CONNECTED);

				SECSControl.StartXPro();
			}
		}

		private void button_enable_Click(object sender, EventArgs e)
		{
            if (button_enable.Text == "Enable")
            {
                ChangeEnable(EnableState.ENABLE);
                SetECV("InitCommState", "1");
            }
            else
            {
                ChangeEnable(EnableState.DISABLE);
                SetECV("InitCommState", "0");
            }
		}

		private void timer_commDelay_Tick(object sender, EventArgs e)
		{
			ChangeCommunication(CommunicationState.WAIT_CRA);			
		}

		private void button_online_Click(object sender, EventArgs e)
		{
			if (button_online.Text == "ON-LINE")
			{
				if (enableState == false || communicationState == false)
				{
					string subOnlineFail = GetECV("OnLineFailed");

					if (subOnlineFail == "1")
						ChangeControl(ControlState.EQUIP_OFFLINE);
					else if (subOnlineFail == "2")
						ChangeControl(ControlState.HOST_OFFLINE);
				}
				else
					ChangeControl(ControlState.ATTEMP_ONLINE);
			}
			else
			{
				ChangeControl(ControlState.EQUIP_OFFLINE);
			}
		}

		private void button_remote_Click(object sender, EventArgs e)
		{
			if (button_remote.Text == "REMOTE")
				ChangeControl(ControlState.REMOTE);
			else
				ChangeControl(ControlState.LOCAL);
		}

		private void ChangeConnect(ConnectState state)
		{
			if (state == ConnectState.CONNECTED)
			{
				textBox_Connection.Text = "CONNECTED";
				textBox_Control.Text = "SELECTED";

                if (timer_commDelay.Enabled == false)
				{
					if (GetECV("InitCommState") == "1")
						ChangeEnable(EnableState.ENABLE);
					else
						ChangeEnable(EnableState.DISABLE);
				}

			}
			else if (state == ConnectState.NOT_CONNECTED)
			{
				communicationState = false;

				textBox_Connection.Text = "NOT CONNECTED";
				textBox_Control.Text = "";
				textBox_communication.Text = "NOT COMMUNICATING";
			}

			if (HostStateChanged != null)
				HostStateChanged(this, EventArgs.Empty);
		}

		private void ChangeEnable(EnableState state)
		{
			if (state == EnableState.ENABLE)
			{
				if (enableState == false)
					InitControlState();

				enableState = true;
				textBox_enable.Text = "ENABLED";
				button_online.Enabled = true;
				textBox_communication.Text = "";
				button_enable.Text = "Disable";

				timer_S1F13.Enabled = true;
			}
			else if (state == EnableState.DISABLE)
			{
				SetVariable("SV", "CommunicationState", "1");
				enableState = false;
				textBox_enable.Text = "DISABLED";
				textBox_communication.Text = "";
				timer_commDelay.Enabled = false;
				button_enable.Text = "Enable";
				button_online.Text = "ON-LINE";
				button_remote.Text = "REMOTE";
				button_online.Enabled = false;
				button_remote.Enabled = false;
				textBox_online.Text = "";
				textBox_remote.Text = "";
			}

			if (HostStateChanged != null)
				HostStateChanged(this, EventArgs.Empty);
		}

		private void ChangeCommunication(CommunicationState state)
		{
			if (state == CommunicationState.WAIT_CRA)
			{
				SetVariable("SV", "CommunicationState", "2");

				if (textBox_Control.Text == "SELECTED")
				{
					communicationState = false;
					timer_commDelay.Enabled = false;
					textBox_communication.Text = "WAIT CRA";
					SECSControl.SendSecsMsg(msg.S1F13());
				}
				else
				{
					ChangeCommunication(CommunicationState.WAIT_DELAY);
				}
			}
			else if (state == CommunicationState.WAIT_DELAY)
			{
				SetVariable("SV", "CommunicationState", "2");

				communicationState = false;
				textBox_communication.Text = "WAIT DELAY";
				timer_commDelay.Enabled = true;
			}
			else if (state == CommunicationState.WAIT_CR_FROM_HOST)
			{
				SetVariable("SV", "CommunicationState", "2");

				communicationState = false;
				textBox_communication.Text = "";
			}
			else if (state == CommunicationState.COMMUNICATING)
			{
				SetVariable("SV", "CommunicationState", "3");

				communicationState = true;
				textBox_communication.Text = "COMMUNICATING";
				timer_commDelay.Enabled = false;
				
				if (spooling)
				{
					spooling = false;
				}
			}

			if (HostStateChanged != null)
				HostStateChanged(this, EventArgs.Empty);
		}

		private void InitControlState()
		{
			string initControl = GetECV("InitControlState");

			if (initControl == "1")
			{
				string subOffLine = GetECV("OffLineSubState");

				if (enableState == false || communicationState == false)
				{
					string subOnlineFail = GetECV("OnLineFailed");

					if (subOnlineFail == "1")
						ChangeControl(ControlState.EQUIP_OFFLINE);
					else if (subOnlineFail == "2")
						ChangeControl(ControlState.HOST_OFFLINE);
				}
				else
				{
					if (subOffLine == "1")
						ChangeControl(ControlState.EQUIP_OFFLINE);
					else if (subOffLine == "2")
						ChangeControl(ControlState.ATTEMP_ONLINE);
					else if (subOffLine == "3")
						ChangeControl(ControlState.HOST_OFFLINE);
				}
			}
			else if (initControl == "2")
			{
                string subOnLine = GetECV("OnLineSubState");

				if (subOnLine == "4")
					ChangeControl(ControlState.LOCAL);
				else
					ChangeControl(ControlState.REMOTE);
			}
		}

		private void ChangeControl(ControlState state)
		{
			if (state == ControlState.EQUIP_OFFLINE)
			{
				SetVariable("SV", "ControlState", "1");
				if (textBox_online.Text.IndexOf("OFF-LINE") == -1)
					RaiseEvent(100);

				controlState = "EQUIP_OFF-LINE";
				textBox_online.Text = "EQUIP_OFF-LINE";
				button_online.Text = "ON-LINE";

				button_remote.Text = "REMOTE";
				textBox_remote.Text = "";
				button_online.Enabled = true;
				button_remote.Enabled = false;
				
			}
			else if (state == ControlState.ATTEMP_ONLINE)
			{
				SetVariable("SV", "ControlState", "2");
				button_online.Enabled = false;
				textBox_online.Text = "ATTEMP_ON-LINE";
				SECSControl.SendSecsMsg(msg.S1F1());				
			}
			else if (state == ControlState.HOST_OFFLINE)
			{
				SetVariable("SV", "ControlState", "3");

				if (textBox_online.Text.IndexOf("OFF-LINE") == -1)
					RaiseEvent(100);

				controlState = "HOST_OFF-LINE";
				textBox_online.Text = "HOST_OFF-LINE";
				button_online.Text = "OFF-LINE";

				button_remote.Text = "REMOTE";
				textBox_remote.Text = "";
				button_online.Enabled = true;
				button_remote.Enabled = false;				
			}
			else if (state == ControlState.LOCAL)
			{
				SetVariable("SV", "ControlState", "4");
				button_remote.Enabled = true;
				button_online.Enabled = true;
				controlState = "LOCAL";
				textBox_online.Text = "ON-LINE";
				textBox_remote.Text = "LOCAL";
				button_online.Text = "OFF-LINE";
				button_remote.Text = "REMOTE";

				RaiseEvent(101);				
			}
			else if (state == ControlState.REMOTE)
			{
				SetVariable("SV", "ControlState", "5");
				button_remote.Enabled = true;
				button_online.Enabled = true;
				controlState = "REMOTE";
				textBox_online.Text = "ON-LINE";
				textBox_remote.Text = "REMOTE";
				button_online.Text = "OFF-LINE";
				button_remote.Text = "LOCAL";

				RaiseEvent(102);				
			}

			if (HostStateChanged != null)
				HostStateChanged(this, EventArgs.Empty);
		}

        private void button_clear_Click(object sender, EventArgs e)
        {
            richTextBox_Msg.Text = "";
        }

		private void button_send_Click(object sender, EventArgs e)
		{
			string msg = "<S10F1,E,";

			if (hsmsParam.S10Reply)
				msg += "R,";

			msg += "<L,2";
			msg += "<BIN[1],00>";
			msg += "<A[" + richTextBox_Msg.Text.Length.ToString() + "]," + richTextBox_Msg.Text + ">>";
			msg += ">";

			SendMsg(msg);
		}

		public void RaiseAlarm(int ALID)
		{
            //if (BasicPanel.Util_Exception.change)
            //{
            //    GetAlarmType();
            //    BasicPanel.Util_Exception.change = false;
            //}

			if (msg.CheckAlarmEnable((ushort)ALID))
			{
				SendMsg(msg.S5F1(ALID, true));
				msg.AddAlarmSet((ushort)ALID);
				RaiseEvent(300);
			}
		}

		public void ClearAlarm(int ALID)
		{
            //if (BasicPanel.Util_Exception.change)
            //{
            //    GetAlarmType();
            //    BasicPanel.Util_Exception.change = false;
            //}

			if (msg.CheckAlarmEnable((ushort)ALID))
			{
				SendMsg(msg.S5F1(ALID, false));
				msg.RemoveAlarmSet((ushort)ALID);
				RaiseEvent(301);
			}
		}

        public void RaiseEvent(int CEID)
		{
			if (msg.CheckEventReport(CEID))
				SendMsg(msg.S6F11(CEID));
		}

		private void RecognizeMessage(object sender, EventArgs e)
		{
			RaiseEvent(600);
		}

		private List<string> GetGroupList(string pm)
		{
			List<string> groups = new List<string>();

			DirectoryInfo dir = new DirectoryInfo(".\\Recipe\\" + pm);

			if (dir.Exists == true)
			{
				foreach (DirectoryInfo group in dir.GetDirectories())
				{
					groups.Add(group.Name.ToString());
				}
			}

			return groups;
		}

		private List<string> GetRecipeList(string group)
		{
			List<string> list = new List<string>();

            DirectoryInfo dir = new DirectoryInfo(".\\Recipe\\" + group);

			if (dir.Exists == false)
				dir.Create();

			FileInfo[] files = dir.GetFiles("*.rcp");

			foreach (FileInfo file in files)
			{
				string filename = file.Name.ToString();

				int index = filename.IndexOf(".rcp");

				filename = filename.Substring(0, index);

				list.Add(filename);
			}

			return list;
		}

		private void GemForm_Load(object sender, EventArgs e)
		{
            //adsClient.Connect();

            //if (BasicPanel.Util_Exception.change)
            //{
            //    GetAlarmType();
            //    BasicPanel.Util_Exception.change = false;
            //}
		}

		private void timer_S1F13_Tick(object sender, EventArgs e)
		{
			ChangeCommunication(CommunicationState.WAIT_CRA);
			timer_S1F13.Enabled = false;
		}

		private void timer_change_Tick(object sender, EventArgs e)
		{
            //if (Config_EquipConstant.ecvChanged)
            //{
            //    RaiseEvent(103);
            //    Config_EquipConstant.ecvChanged = false;
            //}

            //if (Recipe_Editor.ppChanged)
            //{
            //    RaiseEvent(400);
            //    Recipe_Editor.ppChanged = false;
            //}

            //if (Recipe_Editor.uploadRecipe.Length > 0)
            //{
            //    SendMsg(msg.S7F3(Recipe_Editor.uploadRecipe));
            //    Recipe_Editor.uploadRecipe = "";
            //}

            //if (Recipe_Editor.downloadRecipe.Length > 0)
            //{
            //    SendMsg(msg.S7F5(Recipe_Editor.downloadRecipe));
            //    downloadPPID = Recipe_Editor.downloadRecipe;
            //    Recipe_Editor.downloadRecipe = "";
            //}
		}

		public bool CheckItemFormat(string smlLine, string type)
		{
			if (smlLine.Length == 0)
				return false;

			string line = smlLine.Substring(smlLine.IndexOf('<') + 1).Trim();

			if (line.Length < type.Length)
				return false;

			if (line.Substring(0, type.Length) != type)
				return false;

			return true;
		}

		public bool CheckItemData(string type, string value)
		{
			string[] split = value.Split(new char[] { ' ', ',' });

			try
			{
				switch (type)
				{
					case "L":
						{
							long num = long.Parse(value);

							if (num < 0)
								return false;
						}
						break;
					case "A":
						break;
					case "U1":
						{
							foreach (string u1 in split)
							{
                                if (u1.Length > 0)
                                {
                                    int num = int.Parse(u1);

                                    if (num < 0 || num > 0xff)
                                        return false;
                                }
							}
						}
						break;
					case "U2":
						{
							foreach (string u2 in split)
							{
                                if (u2.Length > 0)
                                {
                                    int num = int.Parse(u2);

                                    if (num < 0 || num > 0xffff)
                                        return false;
                                }
							}
						}
						break;
					case "U4":
						{
							foreach (string u4 in split)
							{
                                if (u4.Length > 0)
                                {
                                    long num = long.Parse(u4);

                                    if (num < 0 || num > 0xffffffff)
                                        return false;
                                }
							}
						}
						break;
					case "U8":
						{
							foreach (string u8 in split)
							{
                                if (u8.Length > 0)
                                {
                                    ulong num = ulong.Parse(u8);

                                    if (!(num >= 0 && num <= 0xffffffffffffffff))
                                        return false;
                                }
							}
						}
						break;
					case "BIN":
						{
							foreach (string bin in split)
							{
								if (bin.Length != 2)
									return false;

								for (int i = 0; i < 2; i++)
								{
                                    int num = IronControls.Utility.ASCIItoBinary(bin[i]);

									if (num < 0 || num > 0xf)
										return false;
								}
							}
						}
						break;
					case "BOOL":
						{
							foreach (string sbool in split)
							{
								if (!(sbool == "TRUE" || sbool == "FALSE"))
									return false;
							}
						}
						break;
					case "I1":
						{
							foreach (string i1 in split)
							{
								long num = long.Parse(i1);

								if (!(num < -0x80 && num > 0x7f))
									return false;
							}
						}
						break;
					case "I2":
						{
							foreach (string i2 in split)
							{
                                if (i2.Length > 0)
                                {
                                    long num = long.Parse(i2);

                                    if (!(num < -0x8000 && num > 0x7fff))
                                        return false;
                                }
							}
						}
						break;
					case "I4":
						{
							foreach (string i4 in split)
							{
                                if (i4.Length > 0)
                                {
                                    long num = long.Parse(i4);

                                    if (!(num < -0x80000000 && num > 0x7fffffff))
                                        return false;
                                }
							}
						}
						break;
					case "I8":
						{
							foreach (string i8 in split)
							{
                                if (i8.Length > 0)
                                {
                                    long num = long.Parse(i8);

                                    if (!(num >= -0x7fffffffffffffff && num <= 0x7fffffffffffffff))
                                        return false;
                                }
							}
						}
						break;
					case "F4":
						break;
					case "F8":
						break;
					case "JIS-8":
						break;
					default:
						return false;
                }
            }
			catch
			{
				return false;
			}

			return true;
		}

        static void TraceThreadProc(object data)
        {
            GEMForm form = (GEMForm)data;

            DateTime start = DateTime.Now;
            DateTime end;
            TimeSpan t;

            while (!_shouldStop)
            {
                foreach (int key in traceDic.Keys)
                {
                    traceCurTime[key] = traceCurTime[key] + 10;

                    if (traceCurTime[key] >= traceDic[key].time)
                    {
                        traceCurTime[key] = 0;

                        if (traceCount[key] < traceDic[key].totsmp)
                        {
                            lock (form)
                            {
                                form.SendMsg(form.msg.S6F1(traceDic[key], ++traceCount[key]));
                            }
                        }
                    }
                }

                end = DateTime.Now;

                t = end - start;

                int sleep = (10 - t.Milliseconds) / (int)1;

                if (sleep > 0)
                    Thread.Sleep(sleep);

                start = DateTime.Now;
            }
        }
	}
}