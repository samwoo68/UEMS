using System;
using System.Collections.Generic;
using System.Text;

namespace BasicPanel
{
	[SerializableAttribute]
	class AlarmData
	{
		private List<ushort> alarmEnable;

		public AlarmData()
		{
			alarmEnable = new List<ushort>();
		}

		public List<ushort> AlarmEnable
		{
			set
			{
				alarmEnable = value;
			}
			get
			{
				return alarmEnable;
			}
		}
	}
}
