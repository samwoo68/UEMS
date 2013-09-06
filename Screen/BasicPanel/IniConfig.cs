using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace BasicPanel
{
	public class IniConfig
	{
		[DllImport("kernel32")]
		public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);
		[DllImport("kernel32")]
		public static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

		private string m_ConfigurationFile = null;

		internal IniConfig()
		{
		}

		internal IniConfig(string configurationFile)
		{
			m_ConfigurationFile = configurationFile;
		}

		public string ConfigurationFile
		{
			get
			{
				return m_ConfigurationFile;
			}
			set
			{
				m_ConfigurationFile = value;
			}
		}

		public void Write(string section, string key, string value)
		{
			try
			{
				if (section == null)
					throw new ArgumentException();

				if (key == null)
					throw new ArgumentException();

				if (value == null)
					throw new ArgumentException();

				if (m_ConfigurationFile == null)
					throw new ArgumentException();

				WritePrivateProfileString(section, key, (string)value, m_ConfigurationFile);
			}
			catch
			{
				//MessageBox.Show(e.Message);
			}
		}

		public string Read(string section, string key)
		{
			StringBuilder ReturnString = new StringBuilder();

			try
			{
				if (section == null)
					throw new ArgumentException();

				if (key == null)
					throw new ArgumentException();

				if (m_ConfigurationFile == null)
					throw new ArgumentException();

				GetPrivateProfileString(section, key, string.Empty, ReturnString, 256, m_ConfigurationFile);

				if (ReturnString != null)
					return ReturnString.ToString();
			}
			catch
			{
				//MessageBox.Show(e.Message);
			}

			return string.Empty;
		}
	}
}