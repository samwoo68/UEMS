using System;
using System.Collections.Generic;
using System.Text;

namespace BasicPanel
{
	[SerializableAttribute]
	class EventData
	{
		private Dictionary<int, List<int>> reportID;
		private Dictionary<int, List<int>> linkEvent;
		private List<int> eventReport;

		public EventData()
		{
			reportID = new Dictionary<int, List<int>>();
			linkEvent = new Dictionary<int, List<int>>();
			eventReport = new List<int>();
		}

		public Dictionary<int, List<int>> ReportID
		{
			set
			{
				reportID = value;
			}
			get
			{
				return reportID;
			}
		}

		public Dictionary<int, List<int>> LinkEvent
		{
			set
			{
				linkEvent = value;
			}
			get
			{
				return linkEvent;
			}
		}

		public List<int> EventReport
		{
			set
			{
				eventReport = value;
			}
			get
			{
				return eventReport;
			}
		}
	}
}
