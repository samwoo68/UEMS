using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;

namespace BasicPanel
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME
    {
        [MarshalAs(UnmanagedType.U2)]
        public short Year;
        [MarshalAs(UnmanagedType.U2)]
        public short Month;
        [MarshalAs(UnmanagedType.U2)]
        public short DayOfWeek;
        [MarshalAs(UnmanagedType.U2)]
        public short Day;
        [MarshalAs(UnmanagedType.U2)]
        public short Hour;
        [MarshalAs(UnmanagedType.U2)]
        public short Minute;
        [MarshalAs(UnmanagedType.U2)]
        public short Second;
        [MarshalAs(UnmanagedType.U2)]
        public short Milliseconds;
    }

    public struct TraceStruct
    {
        public int id;
        public double time;
        public int totsmp;
        public List<int> svid;
    }

	class SECSII
	{
		public enum COMMACK:int { Accepted , Denied }
		public enum ONLACK:int { Accepted, NotAllowed, AlreadyONLINE }

		public struct VariableType
		{
			public int vid;
            public int size;
            public string dic;
			public string name;
			public string unit;
			public string type;
			public string io;
			public string min;
			public string max;
			public string def;
		}

		Dictionary<int, VariableType> vidDic;
        Dictionary<int, VariableType> svDic;
		Dictionary<int, VariableType> equipConstantDic;

		int dataId = 0;

		EventData eventData;
		AlarmData alarmData;

		public struct AlarmType
		{
			public int ALCD;
			public int ALID;
			public string ALTX;
		}

		private Dictionary<int, AlarmType> alarmDic;
		
		private List<ushort> alarmSet;

		private List<int> ceidList;

		bool s5Reply = false;
		bool s6Reply = false;
		bool s10Reply = false;

		private string configPath = null;

        GEMForm parent = null;

        public SECSII(GEMForm form)
		{
            parent =  form;
			vidDic = new Dictionary<int, VariableType>();
            svDic = new Dictionary<int, VariableType>();
			equipConstantDic = new Dictionary<int, VariableType>();
			alarmDic = new Dictionary<int, AlarmType>();
			alarmSet = new List<ushort>();
			ceidList = new List<int>();

            configPath = ".\\Config\\";

			DeserializeEvent();
			DeserializeAlarm();
		}

		public void SerializeEvent()
		{
			using (Stream stream = new FileStream(configPath + "EventData.dat", FileMode.Create))
			{
				IFormatter formatter = new BinaryFormatter();
				formatter.Serialize(stream, eventData);
			}
		}

		public void DeserializeEvent()
		{
			FileInfo file = new FileInfo(configPath + "EventData.dat");

			if (file.Exists)
			{
				using (Stream stream = new FileStream(configPath + "EventData.dat", FileMode.Open))
				{
					IFormatter formatter = new BinaryFormatter();

					if (stream.Length != 0)
					{
						eventData = (EventData)formatter.Deserialize(stream);
						return;
					}
				}
			}
		
			eventData = new EventData();
		}

		public void SerializeAlarm()
		{
			using (Stream stream = new FileStream(configPath + "AlarmData.dat", FileMode.Create))
			{
				IFormatter formatter = new BinaryFormatter();
				formatter.Serialize(stream, alarmData);
			}
		}

		public void DeserializeAlarm()
		{
			FileInfo file = new FileInfo(configPath + "AlarmData.dat");

			if (file.Exists)
			{
				using (Stream stream = new FileStream(configPath + "AlarmData.dat", FileMode.Open))
				{
					IFormatter formatter = new BinaryFormatter();

					if (stream.Length != 0)
					{
						alarmData = (AlarmData)formatter.Deserialize(stream);
						return;
					}
				}
			}

			alarmData = new AlarmData();
		}

		public int DATAID
		{
			set
			{
				dataId = value;
			}
			get
			{
				return dataId;
			}
		}
		public bool S5Reply
		{
			set
			{
				s5Reply = value;
			}
		}

		public bool S6Reply
		{
			set
			{
				s6Reply = value;
			}
		}

		public bool S10Reply
		{
			set
			{
				s10Reply = value;
			}
		}

		public void AddAlarmSet(ushort alid)
		{
			alarmSet.Add(alid);
		}

		public void RemoveAlarmSet(ushort alid)
		{
			if (alarmSet.Contains(alid))
				alarmSet.Remove(alid);
		}

		public void AddAlarmEnable(ushort alid)
		{
			if (!alarmData.AlarmEnable.Contains(alid))
				alarmData.AlarmEnable.Add(alid);
		}

		public void RemoveAlarmEnable(ushort alid)
		{
			if (alarmData.AlarmEnable.Contains(alid))
				alarmData.AlarmEnable.Remove(alid);
		}

		public void AddCEIDList(int ceid)
		{
			if (!ceidList.Contains(ceid))
				ceidList.Add(ceid);
		}

		public void ClearCEIDList()
		{
			ceidList.Clear();
		}

		public bool ContainCEID(int ceid)
		{
			return ceidList.Contains(ceid);
		}

		public void AddVariableDic(int vid, string dic, string name, string type, string unit, string io)
		{
			VariableType variable = new VariableType();

			variable.vid = vid;
            variable.dic = dic;
			variable.name = name;
			variable.type = type;
			variable.unit = unit;
			variable.io = io;
			variable.min = "";
			variable.max = "";
			variable.def = "";

			vidDic.Add(vid, variable);

            if (dic == "SV")
                svDic.Add(vid, variable);
		}

		public void ClearVariableDic()
		{
			vidDic.Clear();
            svDic.Clear();
		}

		public bool ContainVariableDic(int id)
		{
			return vidDic.ContainsKey(id);
		}

		public void AddECVDictionary(int vid, int size, string name, string type, string unit, string def, string min, string max)
		{
			VariableType variable = new VariableType();

			variable.vid = vid;
			variable.size = size;
			variable.name = name;
			variable.type = type;
			variable.unit = unit;
			variable.min = min;
			variable.max = max;
			variable.def = def;

			equipConstantDic.Add(vid, variable);
		}

		public void ClearECVDictionary()
		{
			equipConstantDic.Clear();
		}

		public void AddReportID(int id, List<int> vids)
		{
			eventData.ReportID.Add(id, vids);
		}

		public void RemoveReportID(int id)
		{
			if (eventData.ReportID.ContainsKey(id))
				eventData.ReportID.Remove(id);

			foreach (int ceid in eventData.LinkEvent.Keys)
			{
				if (eventData.LinkEvent[ceid].Contains(id))
				{
					eventData.LinkEvent[ceid].Remove(id);
				}
			}
		}

		public void ClearReportID()
		{
			eventData.LinkEvent.Clear();
			eventData.ReportID.Clear();
		}

		public bool ContainReportID(int id)
		{
			return eventData.ReportID.ContainsKey(id);
		}

		public void AddLinkEvnet(int ceid, List<int> reportId)
		{
			eventData.LinkEvent.Add(ceid, reportId);
		}

		public void RemoveLinkEvent(int ceid)
		{
			if (eventData.LinkEvent.ContainsKey(ceid))
				eventData.LinkEvent.Remove(ceid);
		}

		public bool ContainLinkEvent(int ceid)
		{
			return eventData.LinkEvent.ContainsKey(ceid);
		}

		public void AddEventReport(int ceid)
		{
			eventData.EventReport.Add(ceid);
		}

		public void AddAlarmType(int alarmId, AlarmType alarmType)
		{
			alarmDic.Add(alarmId, alarmType);
		}

		public void ClearAlarmType()
		{
			alarmDic.Clear();
		}

		public void RemoveEventReport(int ceid)
		{
			if (eventData.EventReport.Contains(ceid))
				eventData.EventReport.Remove(ceid);
		}

		public void AllCEIDEnable()
		{
			eventData.EventReport = ceidList;
		}

		public void AllCEIDDisble()
		{
			eventData.EventReport.Clear();
		}

		public bool ContainEventReport(int ceid)
		{
			return eventData.EventReport.Contains(ceid);
		}

		public VariableType GetECV(short ecid)
		{
			if (equipConstantDic.ContainsKey(ecid))
			{
				return equipConstantDic[ecid];
			}

			return new VariableType();
		}

		public string GetTime(string format)
		{
			string strTime;

			if (format == "0")
			{
				strTime = DateTime.Now.ToString("yyMMddHHmmss");
			}
			else
			{
				DateTime t = DateTime.Now;
				strTime = t.ToString("yyyyMMddHHmmss");
				strTime += string.Format("{0:D}", t.Millisecond / 10);
			}

			return strTime;
		}

		public string GetSVItem(int vid)
		{
			string msg = "";
			string val = "";
            int num = 0;

            if (vidDic.ContainsKey(vid))
            {
                if (vid == 100)
                {
                    msg = "<L," + alarmData.AlarmEnable.Count.ToString();

                    foreach (ushort aid in alarmData.AlarmEnable)
                    {
                        msg += "<U2," + aid.ToString() + ">";
                    }

                    msg += ">";
                }
                else if (vid == 101)
                {
                    msg = "<L," + alarmSet.Count.ToString();

                    foreach (ushort aid in alarmSet)
                    {
                        msg += "<U2," + aid.ToString() + ">";
                    }

                    msg += ">";
                }
                else if (vid == 102)
                {
                    val = GetTime("1");
                    msg = "<A[" + val.Length.ToString() + "]," + val + ">";
                }
                else if (vid == 106)
                {
                    msg = "<L," + eventData.EventReport.Count.ToString();

                    foreach (ushort ceid in eventData.EventReport)
                    {
                        msg += "<U2," + ceid.ToString() + ">";
                    }

                    msg += ">";
                }
                else
                {
                    switch (vidDic[vid].type)
                    {
                        case "BIN":
                            val = parent.GetVariable(vidDic[vid].dic, vidDic[vid].name);

                            if (val.Length > 0)
                                num = int.Parse(val);
                            else
                                num = 0;

                            msg = "<BIN[1]," + string.Format("{0:X}{1:X}", (num >> 4) & 0xf, num & 0xf) + ">";
                            break;
                        case "A":
                            val = parent.GetVariable(vidDic[vid].dic, vidDic[vid].name);
                            msg = "<A[" + val.Length.ToString() + "]," + val + ">";
                            break;
                        case "L":

                            break;
                        default:
                            val = parent.GetVariable(vidDic[vid].dic, vidDic[vid].name);
                            msg = "<" + vidDic[vid].type + "," + val + ">";
                            break;
                    }
                }
            }
            else
            {
                msg = "<L,0>";
            }

			return msg;
		}

		public string GetECVItem(int vid)
		{
			string msg = "";
			string val = "";

            if (equipConstantDic.ContainsKey(vid))
            {
                switch (equipConstantDic[vid].type)
                {
                    case "A":
                        val = parent.GetECV(equipConstantDic[vid].name);
					    msg = "<A[" + val.Length.ToString() + "]," + val + ">";
                        break;
                    default:
                        val = parent.GetECV(equipConstantDic[vid].name);
					    msg = "<" + equipConstantDic[vid].type + "," + val + ">";
                        break;
                }
            }
            else
            {
                msg = "<L,0>";
            }

			return msg;
		}
		
		public bool CheckAlarmEnable(int ALID)
		{
			return alarmData.AlarmEnable.Contains((ushort)ALID) && alarmDic.ContainsKey(ALID);
		}

		public bool CheckceidEnable(int ceid)
		{
			return eventData.EventReport.Contains((ushort)ceid);
		}

		public bool CheckEventReport(int ceid)
		{
			bool check = false;

			if (eventData.EventReport.Contains((ushort)ceid))
			{
			/*	if (eventReport.Contains(ceid))
				{
					if (linkEvent.ContainsKey(ceid))
					{
						List<int> report = linkEvent[ceid];

						foreach (int r in report)
						{
							if (reportID.ContainsKey(r))
							{
								check = true;
							}
							else
							{
								check = false;
								break;
							}
						}
					}
				}*/

				check = true;
			}

			return check;
		}

		public string S1F1()
		{
			return "<S1,F1,E,R>";
		}

		public string S1F2()
		{
			string msg = "<S1F2,E<L,2";

			msg += "<A[6]," + string.Format("{0,-6}", parent.GetVariable("MDLN", "MDLN")) + ">";
            msg += "<A[6]," + string.Format("{0,-6}", parent.GetVariable("SOFTREV", "SOFTREV")) + ">";
			msg += ">>";

			return msg;
		}

		public string S1F4(List<int> svid)
		{
			string msg;

			if (svid == null)
			{
				msg = "<S1F4,E<L," + svDic.Count.ToString();

				foreach (VariableType var in svDic.Values)
				{
					msg += GetSVItem(var.vid);
				}

				msg += ">>";
			}
			else
			{
				msg = "<S1F4,E<L," + svid.Count.ToString();

				foreach (int id in svid)
				{
					if (svDic.ContainsKey(id))
					{
						msg += GetSVItem(id);
					}
					else
					{
						msg += "<L,0>";
					}
				}

				msg += ">>";
			}

			return msg;
		}

		public string S1F12(List<int> svid)
		{
			string msg;

			if (svid == null)
			{
				msg = "<S1F12,E<L," + svDic.Count.ToString();

				foreach (VariableType var in svDic.Values)
				{
					msg += "<L,3";
					msg += "<U2," + var.vid.ToString() + ">";
					msg += "<A[" + var.name.Length.ToString() + "]," + var.name + ">";
					msg += "<A[" + var.unit.Length.ToString() + "]," + var.unit + ">";
					msg += ">";
				}

				msg += ">>";
			}
			else
			{
				msg = "<S1F12,E<L," + svid.Count.ToString();

				foreach (int vid in svid)
				{
					if (svDic.ContainsKey(vid))
					{
						msg += "<L,3";
						msg += "<U2," + svDic[vid].vid.ToString() + ">";
						msg += "<A[" + svDic[vid].name.Length.ToString() + "]," + svDic[vid].name + ">";
						msg += "<A[" + svDic[vid].unit.Length.ToString() + "]," + svDic[vid].unit + ">";
						msg += ">";
					}
					else
					{
						msg += "<L,3";
						msg += "<U2," + vid.ToString() + ">";
						msg += "<A[0],>";
						msg += "<A[o],>";
						msg += ">";
					}
				}

				msg += ">>";
			}

			return msg;
		}

		public string S1F13()
		{
            string MDLN = string.Format("{0, -6}", parent.GetVariable("MDLN", "MDLN"));
            string SOFTREV = string.Format("{0, -6}", parent.GetVariable("SOFTREV", "SOFTREV"));

			string strMsg = "<S1F13,E,R";
			strMsg += "<L,2";
			strMsg += "<A[6]," + MDLN + ">";
			strMsg += "<A[6]," + SOFTREV + ">";
			strMsg += ">>";

			return strMsg;
		}

		public string S1F14(COMMACK commACK)
		{
            string MDLN = string.Format("{0, -6}", parent.GetVariable("MDLN", "MDLN"));
            string SOFTREV = string.Format("{0, -6}", parent.GetVariable("SOFTREV", "SOFTREV"));

			string strMsg = "<S1F14,E";
			strMsg += "<L,2";
			strMsg += "<BIN[1]," + string.Format("{0:X}{1:X}", ((int)commACK >> 4) & 0xf, (int)commACK & 0xf) + ">";
			strMsg += "<L,2";
			strMsg += "<A[6]," + MDLN + ">";
			strMsg += "<A[6]," + SOFTREV + ">";
			strMsg += ">";
			strMsg += ">>";

			return strMsg;
		}

		public string S1F16()
		{
			return "<S1F16,E,<BIN[1],00>>";
		}

		public string S1F18(ONLACK onlACK)
		{
			return "<S1F18,E,<BIN[1]," + string.Format("{0:X}{1:X}", ((int)onlACK >> 4) & 0xf, (int)onlACK & 0xf) + ">>";
		}


		public string S2F14(List<int> ceid)
		{
			string msg;

			if (ceid == null)
			{
				msg = "<S2F14,E<L," + equipConstantDic.Count.ToString();

				foreach (VariableType var in equipConstantDic.Values)
				{
					msg += GetECVItem(var.vid);
				}

				msg += ">>";
			}
			else
			{
				msg = "<S2F14,E<L," + ceid.Count.ToString();

				foreach (int id in ceid)
				{
					if (equipConstantDic.ContainsKey(id))
					{
						msg += GetECVItem(id);
					}
					else
					{
						msg += "<L,0>";
					}
				}

				msg += ">>";
			}

			return msg;
		}

		public string S2F16(int EAC)
		{
			return "<S2F16,E,<BIN[1]," + string.Format("{0:X}{1:X}", (EAC >> 4) & 0xf, EAC & 0xf) + ">>";
		}

		public string S2F17()
		{
			return "<S2F17,E,R>";
		}

		public string S2F18()
		{
			string strTime = GetTime(parent.GetECV("TimeFormat"));

			return "<S2F18,E,<A[" + strTime .Length.ToString()+ "]," + strTime + ">>";
		}

		public string S2F22(byte CMDA)
		{
			return "<S2F2,E<U1," + CMDA.ToString() + ">>";
		}

        public string S2F24(byte TIAACK)
        {
            return "<S2F24,E,<BIN[1]," + string.Format("{0:X}{1:X}", (TIAACK >> 4) & 0xf, TIAACK & 0xf) + ">>";
        }

		public string S2F30(List<int> ecid)
		{
			string msg;

			if (ecid == null)
			{
				msg = "<S2F30,E<L," + equipConstantDic.Count.ToString();

				foreach (VariableType var in equipConstantDic.Values)
				{
					msg += "<L,6";
					msg += "<U2," + var.vid.ToString() + ">";
					msg += "<A[" + var.name.Length.ToString() + "]," + var.name + ">";

					if (var.type == "A")
					{
						msg += "<" + var.type + "[" + var.min.Length.ToString() + "]," + var.min.ToString() + ">";
						msg += "<" + var.type + "[" + var.max.Length.ToString() + "]," + var.max.ToString() + ">";
						msg += "<" + var.type + "[" + var.def.Length.ToString() + "]," + var.def.ToString() + ">";
					}
					else if (var.type == "BIN")
					{
						int min = 0;
						int max = 0;
						int def = 0;

						if (var.min.Length > 0)
							min = int.Parse(var.min.ToString());

						if (var.max.Length > 0)
							max = int.Parse(var.max.ToString());

						if (var.def.Length > 0)
							def = int.Parse(var.def.ToString());

						msg += "<" + var.type + "[" + var.size.ToString() + "]," + string.Format("{0:X}{1:X}", (min >> 4) & 0xf, min & 0xf) + ">";
						msg += "<" + var.type + "[" + var.size.ToString() + "]," + string.Format("{0:X}{1:X}", (max >> 4) & 0xf, max & 0xf) + ">";
						msg += "<" + var.type + "[" + var.size.ToString() + "]," + string.Format("{0:X}{1:X}", (def >> 4) & 0xf, def & 0xf) + ">";
					}
					else if (var.type == "BOOL")
					{
						msg += "<" + var.type + "," + var.min + ">";
						msg += "<" + var.type + "," + var.max + ">";
						msg += "<" + var.type + "," + var.def + ">";
					}
					else
					{
						msg += "<" + var.type + "," + var.min + ">";
						msg += "<" + var.type + "," + var.max + ">";
						msg += "<" + var.type + "," + var.def + ">";
					}

					msg += "<A[" + var.unit.Length.ToString() + "]," + var.unit + ">";
					msg += ">";
				}

				msg += ">>";
			}
			else
			{
				msg = "<S2F30,E<L," + ecid.Count.ToString();

				foreach (int vid in ecid)
				{
					if (equipConstantDic.ContainsKey(vid))
					{
						msg += "<L,6";
						msg += "<U2," + equipConstantDic[vid].vid.ToString() + ">";
						msg += "<A[" + equipConstantDic[vid].name.Length.ToString() + "]," + equipConstantDic[vid].name + ">";
						
						if (equipConstantDic[vid].type == "A")
						{
							msg += "<" + equipConstantDic[vid].type + "[" + equipConstantDic[vid].min.Length.ToString() + "]," + equipConstantDic[vid].min.ToString() + ">";
							msg += "<" + equipConstantDic[vid].type + "[" + equipConstantDic[vid].max.Length.ToString() + "]," + equipConstantDic[vid].max.ToString() + ">";
							msg += "<" + equipConstantDic[vid].type + "[" + equipConstantDic[vid].def.Length.ToString() + "]," + equipConstantDic[vid].def.ToString() + ">";
						}
						else if (equipConstantDic[vid].type == "BIN")
						{
							int min = 0;
							int max = 0;
							int def = 0;

							if (equipConstantDic[vid].min.Length > 0)
								min = int.Parse(equipConstantDic[vid].min.ToString());

							if (equipConstantDic[vid].max.Length > 0)
								max = int.Parse(equipConstantDic[vid].max.ToString());

							if (equipConstantDic[vid].def.Length > 0)
								def = int.Parse(equipConstantDic[vid].def.ToString());

							msg += "<" + equipConstantDic[vid].type + "[" + equipConstantDic[vid].size.ToString() + "]," + string.Format("{0:X}{1:X}", (min >> 4) & 0xf, min & 0xf) + ">";
							msg += "<" + equipConstantDic[vid].type + "[" + equipConstantDic[vid].size.ToString() + "]," + string.Format("{0:X}{1:X}", (max >> 4) & 0xf, max & 0xf) + ">";
							msg += "<" + equipConstantDic[vid].type + "[" + equipConstantDic[vid].size.ToString() + "]," + string.Format("{0:X}{1:X}", (def >> 4) & 0xf, def & 0xf) + ">";
						}
						else if (equipConstantDic[vid].type == "BOOL")
						{
							msg += "<" + equipConstantDic[vid].type + "," + equipConstantDic[vid].min + ">";
							msg += "<" + equipConstantDic[vid].type + "," + equipConstantDic[vid].max + ">";
							msg += "<" + equipConstantDic[vid].type + "," + equipConstantDic[vid].def + ">";
						}
						else
						{
							msg += "<" + equipConstantDic[vid].type + "," + equipConstantDic[vid].min + ">";
							msg += "<" + equipConstantDic[vid].type + "," + equipConstantDic[vid].max + ">";
							msg += "<" + equipConstantDic[vid].type + "," + equipConstantDic[vid].def + ">";
						}

						msg += "<A[" + equipConstantDic[vid].unit.Length.ToString() + "]," + equipConstantDic[vid].unit + ">";
						msg += ">";
					}
					else
					{
						msg += "<L,6";
						msg += "<U2," + vid.ToString() + ">";
						msg += "<A[0],>";
						msg += "<A[0],>";
						msg += "<A[0],>";
						msg += "<A[0],>";
						msg += "<A[o],>";
						msg += ">";
					}
				}

				msg += ">>";
			}

			return msg;
		}

		public string S2F32(int TIACK)
		{
			return "<S2F32,E,<BIN[1]," + string.Format("{0:X}{1:X}", (TIACK >> 4) & 0xf, TIACK & 0xf) + ">>";
		}

		public string S2F34(int DRACK)
		{
			return "<S2F34,E,<BIN[1]," + string.Format("{0:X}{1:X}", (DRACK >> 4) & 0xf, DRACK & 0xf) + ">>";
		}

		public string S2F36(int LRACK)
		{
			return "<S2F36,E,<BIN[1]," + string.Format("{0:X}{1:X}", (LRACK >> 4) & 0xf, LRACK & 0xf) + ">>";
		}

		public string S2F38(int ERACK)
		{
			return "<S2F38,E,<BIN[1]," + string.Format("{0:X}{1:X}", (ERACK >> 4) & 0xf, ERACK & 0xf) + ">>";
		}

		public string S2F42(int HACK, string subMsg)
		{
			string msg = "<S2F42,E";

			msg += "<L,2";
			msg += "<BIN[1]," + string.Format("{0:X}{1:X}", (HACK >> 4) & 0xf, HACK & 0xf) + ">";
			msg += subMsg;
			msg += ">";

			return msg;
		}

		public string S5F1(int ALID, bool alarm)
		{
			string msg = "<S5F1,E,";

			if (s5Reply == true)
				msg += "R,";

			msg += "<L,3";
			
			if (alarm)
			{
				msg += "<BIN[1]," + string.Format("{0:X}{1:X}", ((alarmDic[ALID].ALCD >> 4) & 0xf) | 0x8, alarmDic[ALID].ALCD & 0xf) + ">";
			}
			else
			{
				msg += "<BIN[1]," + string.Format("{0:X}{1:X}", ((alarmDic[ALID].ALCD >> 4) & 0xf) & 0x7, alarmDic[ALID].ALCD & 0xf) + ">";
			}

			msg += "<U2," + ALID.ToString() + ">";
			msg += "<A[" + alarmDic[ALID].ALTX.Length.ToString() + "]," + alarmDic[ALID].ALTX + ">";
			msg += ">";

			msg += ">";

			return msg;
		}

		public string S5F4(int ACK5)
		{
			return "<S5F4,E,<BIN[1]," + string.Format("{0:X}{1:X}", (ACK5 >> 4) & 0xf, ACK5 & 0xf) + ">>";
		}

		public string S5F6(List<int> alids)
		{
			if (alids.Count == 0)
			{
				foreach (int alid in alarmDic.Keys)
					alids.Add(alid);
			}

			string msg = "<S5F6,E,<L,";
			int list = alids.Count;

			string sub = "";
			foreach (int alid in alids)
			{
				sub += "<L,3";

				if (alarmDic.ContainsKey(alid))
				{
					sub += "<BIN[1]," + string.Format("{0:X}{1:X}", (alarmDic[alid].ALCD >> 4) & 0xf, alarmDic[alid].ALCD & 0xf) + ">";
					sub += "<U2," + alid.ToString() + ">";
					sub += "<A[" + alarmDic[alid].ALTX.Length.ToString() + "]," + alarmDic[alid].ALTX + ">";
				}
				else
				{
					sub = "";
					list = 0;
					break;
				}

				sub += ">";
			}

			msg += list.ToString() + sub + ">>";

			return msg;
		}

		public string S5F8()
		{
			string msg = "<S5F8,E,<L," + alarmData.AlarmEnable.Count.ToString();

			foreach (short alid in alarmData.AlarmEnable)
			{
				msg += "<L,3";

				if (alarmDic.ContainsKey(alid))
				{
					msg += "<BIN[1]," + string.Format("{0:X}{1:X}", (alarmDic[alid].ALCD >> 4) & 0xf, alarmDic[alid].ALCD & 0xf) + ">";
					msg += "<U2," + alid.ToString() + ">";
					msg += "<A[" + alarmDic[alid].ALTX.Length.ToString() + "]," + alarmDic[alid].ALTX + ">";
				}
				else
				{
					msg += "<BIN[1],00";
					msg += "<U2," + alid.ToString() + ">";
					string altx = "Unkwon Message";
					msg += "<A[" + altx.Length.ToString() + "]," + altx + ">";
				}
				msg += ">";
			}

			msg += ">>";

			return msg;
		}

        public string S6F1(TraceStruct data, int smpln)
        {
            string msg = "<S6F1,E,";

            if (s6Reply == true)
                msg += "R,";

            msg += "<L,4";
            msg += "<U2," + data.id.ToString() + ">";
            msg += "<U2," + smpln.ToString() + ">";

            string strTime = GetTime(parent.GetECV("TimeFormat"));

            msg += "<A[" + strTime.Length.ToString() + "]," + strTime + ">";

            msg += "<L," + data.svid.Count.ToString();

            foreach (int s in data.svid)
            {
                msg += GetSVItem(s);
            }

            msg += ">";
            msg += ">";

            msg += ">";

            return msg;
        }

		public string S6F11(int ceid)
		{
			string msg = "<S6F11,E,";

			if (s6Reply == true)
				msg += "R,";

			msg += "<L,3";
			msg += "<U2," + dataId.ToString() + ">";
			msg += "<U2," + ceid.ToString() + ">";

			if (eventData.LinkEvent.ContainsKey(ceid))
			{
				msg += "<L," + eventData.LinkEvent[ceid].Count.ToString();

				List<int> report = eventData.LinkEvent[ceid];

				foreach (int r in report)
				{
					msg += "<L,2";
					msg += "<U2," + r.ToString() + ">";

					List<int> svids = eventData.ReportID[r];

					msg += "<L," + svids.Count.ToString();
					foreach (int s in svids)
					{
						msg += GetSVItem(s);
					}
					msg += ">";
					msg += ">";
				}
				msg += ">";
			}
			else
			{
				msg += "<L,0>";
			}

			msg += ">";
			msg += ">";

			return msg;
		}

        public string S6F16(int ceid)
        {
            string msg = "<S6F16,E,";

            msg += "<L,3";
            msg += "<U2," + dataId.ToString() + ">";
            msg += "<U2," + ceid.ToString() + ">";

            if (eventData.LinkEvent.ContainsKey(ceid))
            {
                msg += "<L," + eventData.LinkEvent[ceid].Count.ToString();

                List<int> report = eventData.LinkEvent[ceid];

                foreach (int r in report)
                {
                    msg += "<L,2";
                    msg += "<U2," + r.ToString() + ">";

                    List<int> svids = eventData.ReportID[r];

                    msg += "<L," + svids.Count.ToString();
                    foreach (int s in svids)
                    {
                        msg += GetSVItem(s);
                    }
                    msg += ">";
                    msg += ">";
                }
                msg += ">";
            }
            else
            {
                msg += "<L,0>";
            }

            msg += ">";
            msg += ">";

            return msg;
        }

		public string S6F20(int RPTID)
		{
			string msg = "<S6F20,E";

			if (eventData.ReportID.ContainsKey(RPTID))
			{
				msg += "<L," + eventData.ReportID[RPTID].Count.ToString();

				foreach (int vid in eventData.ReportID[RPTID])
				{
					msg += GetSVItem(vid);
				}

				msg += ">";
			}
			else
			{
				msg += "<L,0>";
			}

			msg += ">";

			return msg;
		}

		public string S7F2(int PPGNT)
		{
			return "<S7F2,E,<BIN[1]," + string.Format("{0:X}{1:X}", (PPGNT >> 4) & 0xf, PPGNT & 0xf) + ">>";
		}

		public string S7F3(string ppid)
		{
			string msg = "<S7F3,E,R<L";

			string[] split = ppid.Split(new char[] { ' ' });

			if (split.Length == 2)
			{
				msg += ",2";
				msg += "<A[" + ppid.Length.ToString() + "]," + ppid + ">";

				using (FileStream fs = new FileStream(".\\Recipe\\" + split[0] + "\\" + split[1] + ".rcp", FileMode.Open, FileAccess.Read))
				{
					BinaryReader read = new BinaryReader(fs);

					msg += "<BIN[" + read.BaseStream.Length.ToString() + "],";

					for (int i = 0; i < read.BaseStream.Length; i++)
					{
						byte by = read.ReadByte();

						msg += string.Format("{0:X}{1:X}", (by >> 4) & 0xf, by & 0xf) + " ";
					}

					msg += ">";
				}
			}

			msg += ">>";

			return msg;
		}

		public string S7F4(int ACK7)
		{
			return "<S7F4,E,<BIN[1]," + string.Format("{0:X}{1:X}", (ACK7 >> 4) & 0xf, ACK7 & 0xf) + ">>";
		}

		public string S7F5(string ppid)
		{
			string msg = "<S7F5,E,R";

			msg += "<A[" + ppid.Length.ToString() + "]," + ppid + ">";

			msg += ">";

			return msg;
		}

		public string S7F6(string ppid)
		{
			string msg = "<S7F6,E<L";

			string[] split = ppid.Split(new char[] { ' ' });

			if (split.Length == 2)
			{
				msg += ",2";
				msg += "<A[" + ppid.Length.ToString() + "]," + ppid + ">";

				using (FileStream fs = new FileStream(".\\Recipe\\" + split[0] + "\\" + split[1] + ".rcp", FileMode.Open, FileAccess.Read))
				{
					BinaryReader read = new BinaryReader(fs);

					msg += "<BIN[" + read.BaseStream.Length.ToString() + "],";

					for (int i = 0; i < read.BaseStream.Length; i++)
					{
						byte by = read.ReadByte();

						msg += string.Format("{0:X}{1:X}", (by >> 4) & 0xf, by & 0xf) + " ";
					}

					msg +=">";
				}
			}

			msg += ">>";

			return msg;
		}

		public string S7F18(int ACK7)
		{
			return "<S7F18,E,<BIN[1]," + string.Format("{0:X}{1:X}", (ACK7 >> 4) & 0xf, ACK7 & 0xf) + ">>";
		}

		public string S7F20(List<string> ppids)
		{
			string msg = "<S7F20,E";

			msg += "<L," + ppids.Count.ToString();

			foreach (string ppid in ppids)
			{
				msg += "<A[" + ppid.Length.ToString() + "]," + ppid + ">";
			}
			msg += ">";

			return msg;
		}

		public string S7F26(string ppid, List<string> ppids)
		{
			string msg = "<S7F26,E";

            //msg += "<L,4";

            //string MDLN = string.Format("{0, -6}", parent.GetVariable("MDLN", "MDLN"));
            //string SOFTREV = string.Format("{0, -6}", parent.GetVariable("SOFTREV", "SOFTREV"));

            //msg += "<A[" + ppid.Length.ToString() + "]," + ppid + ">";
            //msg += "<A[6]," + MDLN + ">";
            //msg += "<A[6]," + SOFTREV + ">";


            //if (ppids.Contains(ppid))
            //{
            //    if (UtilFunc.LoadRecipe(".\\Recipe\\" + ppid + ".rcp"))
            //    {
            //        int ccode = 1;

            //        msg += "<L," + UtilFunc.totalStep.ToString();

            //        for (int i = 0; i < UtilFunc.totalStep; i++)
            //        {
            //            msg += "<U4," + ccode.ToString() + ">";
            //            msg += "<U4," + UtilFunc.rcp[i, 0].ToString() + ">";
            //            msg += "<U4," + UtilFunc.rcp[i, 1].ToString() + ">";
            //            msg += "<U4," + UtilFunc.rcp[i, 2].ToString() + ">";
            //            msg += "<U4," + UtilFunc.rcp[i, 3].ToString() + ">";

            //            ccode++;
            //        }

            //        msg += ">";
            //    }
            //    else
            //    {
            //        msg += "<L,>";
            //    }
            //}
            //else
            //{
            //    msg += "<L,>";
            //}

            //msg += ">";

			return msg;
		}

		public string S9F3(string MHEAD)
		{
			string msg = "<S9F3,E,<BIN[10]," + MHEAD + ">>";

			return msg;
		}

		public string S9F5(string MHEAD)
		{
			string msg = "<S9F5,E,<BIN[10]," + MHEAD + ">>";

			return msg;
		}

		public string S9F7(string MHEAD)
		{
			string msg = "<S9F7,E,<BIN[10]," + MHEAD + ">>";

			return msg;
		}

		public string S9F9(string SHEAD)
		{
			string msg = "<S9F9,E,<BIN[10]," + SHEAD + ">>";

			return msg;
		}

		public string S9F11(string MHEAD)
		{
			string msg = "<S9F11,E,<BIN[10]," + MHEAD + ">>";

			return msg;
		}

		public string S10F4(int ACK10)
		{
			return "<S10F4,E,<BIN[1]," + string.Format("{0:X}{1:X}", (ACK10 >> 4) & 0xf, ACK10 & 0xf) + ">>";
		}

		public string S10F6(int ACK10)
		{
			return "<S10F6,E,<BIN[1]," + string.Format("{0:X}{1:X}", (ACK10 >> 4) & 0xf, ACK10 & 0xf) + ">>";
		}

        public string S14F2()
        {
            string msg = "<S14F2,E,";

            msg += "<L,2";
            msg += "<L,>";
            msg += "<L,2";
            msg += "<U1,0>"; // OBJACK
            msg += "<L,>";
            msg += ">";
            msg += ">";

            msg += ">";

            return msg;
        }

        public string S14F4()
        {
            string msg = "<S14F4,E,";

            msg += "<L,2";
            msg += "<L,>";
            msg += "<L,2";
            msg += "<U1,0>"; // OBJACK
            msg += "<L,>";
            msg += ">";
            msg += ">";

            msg += ">";

            return msg;
        }

        public string S14F10()
        {
            string msg = "<S14F10,E,";

            msg += "<L,3";
            msg += "<A[7],OBJSPEC>"; // OBJSPEC
            msg += "<L,>";
            msg += "<L,2";
            msg += "<U1,0>"; // OBJACK
            msg += "<L,>";
            msg += ">";
            msg += ">";

            msg += ">";

            return msg;
        }

        public string S14F12()
        {
            string msg = "<S14F12,E,";

            msg += "<L,2";
            msg += "<L,>";
            msg += "<L,2";
            msg += "<U1,0>"; // OBJACK
            msg += "<L,>";
            msg += ">";
            msg += ">";

            msg += ">";

            return msg;
        }

        public string S16F6()
        {
            string msg = "<S16F6,E,";

            msg += "<L,2";
            msg += "<A[4],Test>";
            msg += "<L,2";
            msg += "<BOOL,TRUE>";
            msg += "<L,>";
            msg += ">";
            msg += ">>";

            return msg;
        }

        public string S16F7()
        {
            string msg = "<S16F7,E,R";

            msg += "<L,4";

            string strTime = GetTime("1");
            msg += "<A[" + strTime.Length.ToString() + "]," + strTime + ">";
            
            msg += "<A[4],Test>"; //PRJOBID
            msg += "<U1,0>"; //PRJOBMILESTONE
            msg += "<L,2";
            msg += "<BOOL,TRUE>"; //ACKA
            msg += "<L,>";
            msg += ">";
            msg += ">>";

            return msg;
        }

        public string S16F9()
        {
            string msg = "<S16F9,E,R";

            msg += ""; //PREVENTID
            
            string strTime = GetTime("1");
            msg += "<A[" + strTime.Length.ToString() + "]," + strTime + ">";
            
            msg += "<A[4],Test>"; //PRJOBID
            msg += "<L,>";
            msg += ">";

            return msg;
        }

        public string S16F12()
        {
            string msg = "<S16F12,E,";

            msg += "<L,2";
            msg += "<A[4],Test>"; //PRJOBID
            msg += "<L,2";
            msg += "<BOOL,TRUE>"; //ACKA
            msg += "<L,>";
            msg += ">>>";

            return msg;
        }

        public string S16F14()
        {
            string msg = "<S16F14,E,>";

            return msg;
        }

        public string S16F16()
        {
            string msg = "<S16F16,E,";

            msg += "<L,2";
            msg += "<L,1";
            msg += "<A[4],Test>";
            msg += ">";
            msg += "<L,2";
            msg += "<BOOL,TRUE>";
            msg += "<L,>";
            msg += ">";
            msg += ">>";

            return msg;
        }

        public string S16F18()
        {
            string msg = "<S16F18,E,";

            msg += "<L,2";
            msg += "<L,>";
            msg += "<L,2";
            msg += "<BOOL,TRUE>"; // ACKA
            msg += "<L,>";
            msg += ">>>";

            return msg;
        }

        public string S16F20()
        {
            string msg = "<S16F20,E,";

            msg += "<L,>";
            msg += ">";

            return msg;
        }

        public string S16F22()
        {
            string msg = "<S16F22,E,>";

            return msg;
        }

        public string S16F24()
        {
            string msg = "<S16F24,E,";

            msg += "<BOOL,TRUE>"; // ACKA
            msg += "<L,>";
            msg += ">";

            return msg;
        }

        public string S16F26()
        {
            string msg = "<S16F26,E,";

            msg += "<L,2";
            msg += "<L,>";
            msg += "<L,2";
            msg += "<BOOL,TRUE>"; // ACKA
            msg += "<L,>";
            msg += ">>>";

            return msg;
        }

        public string S16F28()
        {
            string msg = "<S16F28,E,";

            msg += "<BOOL,TRUE>"; // ACKA
            msg += "<L,2";
            msg += "<U2,1>"; // ERRCODE
            msg += "<A[4],TEST>"; // ERRTEST
            msg += ">>";

            return msg;
        }

        public string S18F6()
        {
            string msg = "<S18F6,E,";

            msg += "<A[8],TARGETID>"; //TARGETID
            msg += "<A[7],Success>"; //SSACK
            msg += "<A[1],1>"; //DATA
            msg += "<L,>";

            msg += ">";

            return msg;
        }

        public string S18F8()
        {
            string msg = "<S18F8,E,";

            msg += "<A[8],TARGETID>"; //TARGETID
            msg += "<A[7],Success>"; //SSACK
            msg += "<L,>"; //STATUSLIST

            msg += ">";

            return msg;
        }

        public string S18F10()
        {
            string msg = "<S18F10,E,";

            msg += "<A[8],TARGETID>"; //TARGETID
            msg += "<A[7],Success>"; //SSACK
            msg += "<A[3],MID>"; //MID
            msg += "<L,>"; //STATUSLIST

            msg += ">";

            return msg;
        }

        public string S18F12()
        {
            string msg = "<S18F12,E,";

            msg += "<A[8],TARGETID>"; //TARGETID
            msg += "<A[7],Success>"; //SSACK
            msg += "<L,>"; //STATUSLIST

            msg += ">";

            return msg;
        }

        public string S18F14()
        {
            string msg = "<S18F14,E,";

            msg += "<A[8],TARGETID>"; //TARGETID
            msg += "<A[7],Success>"; //SSACK
            msg += "<L,>"; //STATUSLIST

            msg += ">";

            return msg;
        }
	}
}
