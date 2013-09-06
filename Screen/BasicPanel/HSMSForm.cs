using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace BasicPanel
{
	public partial class HSMSForm : Form
	{
        private string configFile = null;
		private IniConfig ini = null;

		public HSMSForm(string f)
		{
			InitializeComponent();

			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            configFile = f;

            ini = new IniConfig(configFile);

			string iniT3 = ini.Read("XPRO-XE CONFIG : TIMEOUT", "T3");
			string iniT5 = ini.Read("XPRO-XE CONFIG : TIMEOUT", "T5");
			string iniT6 = ini.Read("XPRO-XE CONFIG : TIMEOUT", "T6");
			string iniT7 = ini.Read("XPRO-XE CONFIG : TIMEOUT", "T7");
			string iniT8 = ini.Read("XPRO-XE CONFIG : TIMEOUT", "T8");

			if (iniT3.Length > 0)
			{
				int t3 = int.Parse(iniT3) / 1000;
				textBox_T3.Text = t3.ToString();
			}
			
			if (iniT5.Length > 0)
			{
				int t5 = int.Parse(iniT5) / 1000;
				textBox_T5.Text = t5.ToString();
			}

			if (iniT6.Length > 0)
			{
				int t6 = int.Parse(iniT6) / 1000;
				textBox_T6.Text = t6.ToString();
			}

			if (iniT7.Length > 0)
			{
				int t7 = int.Parse(iniT7) / 1000;
				textBox_T7.Text = t7.ToString();
			}

			if (iniT8.Length > 0)
			{
				int t8 = int.Parse(iniT8) / 1000;
				textBox_T8.Text = t8.ToString();
			}

			string iniMode = ini.Read("XPRO-XE CONFIG : HSMS", "MODE");

			if (iniMode.Length > 0)
			{
				textBox_Mode.Text = int.Parse(iniMode) == 0 ? "Passive" : "Active";
			}

			textBox_Port.Text = ini.Read("XPRO-XE CONFIG : HSMS", "PORT");
			textBox_ip.Text = ini.Read("XPRO-XE CONFIG : HSMS", "ADDRESS");
			textBox_deviceID.Text = ini.Read("XPRO-XE CONFIG : SECS", "DEVICE ID");

			button_s5.Text = ini.Read("REPLY MSG", "S5");
			button_s6.Text = ini.Read("REPLY MSG", "S6");
			button_s10.Text = ini.Read("REPLY MSG", "S10");
		}

		public bool S5Reply
		{
			get
			{
				if (button_s5.Text == "Yes")
					return true;

				return false;
			}
		}

		public bool S6Reply
		{
			get
			{
				if (button_s6.Text == "Yes")
					return true;

				return false;
			}
		}

		public bool S10Reply
		{
			get
			{
				if (button_s10.Text == "Yes")
					return true;

				return false;
			}
		}

		private void button_close_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void button_save_Click(object sender, EventArgs e)
		{
			if (textBox_T3.Text.Length > 0)
			{
				int t3 = int.Parse(textBox_T3.Text) * 1000;
				ini.Write("XPRO-XE CONFIG : TIMEOUT", "T3", t3.ToString());
			}

			if (textBox_T5.Text.Length > 0)
			{
				int t5 = int.Parse(textBox_T5.Text) * 1000;
				ini.Write("XPRO-XE CONFIG : TIMEOUT", "T5", t5.ToString());
			}

			if (textBox_T6.Text.Length > 0)
			{
				int t6 = int.Parse(textBox_T6.Text) * 1000;
				ini.Write("XPRO-XE CONFIG : TIMEOUT", "T6", t6.ToString());
			}

			if (textBox_T7.Text.Length > 0)
			{
				int t7 = int.Parse(textBox_T7.Text) * 1000;
				ini.Write("XPRO-XE CONFIG : TIMEOUT", "T7", t7.ToString());
			}

			if (textBox_T8.Text.Length > 0)
			{
				int t8 = int.Parse(textBox_T8.Text) * 1000;
				ini.Write("XPRO-XE CONFIG : TIMEOUT", "T8", t8.ToString());
			}

			if (textBox_Mode.Text.Length > 0)
				ini.Write("XPRO-XE CONFIG : HSMS", "MODE", textBox_Mode.Text == "Passive" ? "0" : "1");

			ini.Write("XPRO-XE CONFIG : HSMS", "PORT", textBox_Port.Text);
			ini.Write("XPRO-XE CONFIG : HSMS", "ADDRESS", textBox_ip.Text);
			ini.Write("XPRO-XE CONFIG : SECS", "DEVICE ID", textBox_deviceID.Text);

			ini.Write("REPLY MSG", "S5", button_s5.Text);
			ini.Write("REPLY MSG", "S6", button_s6.Text);
			ini.Write("REPLY MSG", "S10", button_s10.Text);

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void textBox_num_Click(object sender, EventArgs e)
		{
            InputControls.NumericTextBox box = sender as InputControls.NumericTextBox;

			InputControls.Numpad pad = new InputControls.Numpad();

            pad.Minimum = box.Minimum;
            pad.Maximum = box.Maximum;
            pad.Text = box.Text;
            pad.Integer = true;

			if (pad.ShowDialog() == DialogResult.OK)
			{
				box.Text = pad.Text;
			}
		}

		private void textBox_Mode_Click(object sender, EventArgs e)
		{
			InputControls.SelectEnum select = new InputControls.SelectEnum();

			List<string> mode = new List<string>();

			mode.Add("Passive");
			mode.Add("Active");

			select.Question = "Select Mode";
			select.Command = mode;

			if (select.ShowDialog() == DialogResult.OK)
			{
				textBox_Mode.Text = select.SelectCommand;
			}
		}

		private void textBox_ip_Click(object sender, EventArgs e)
		{
			InputControls.Keyboard board = new InputControls.Keyboard();

			while (board.ShowDialog() == DialogResult.OK)
			{
                string ip = board.Text;

				string[] addr = ip.Split(new Char[] {'.'});

				if (addr.Length == 4)
				{
					bool ipCheck = true;

					foreach (string num in addr)
					{
						if (int.Parse(num) < 0 || int.Parse(num) > 255)
						{
							ipCheck = false;
						}
					}

					if (ipCheck == true)
					{
                        textBox_ip.Text = board.Text;
						break;
					}
				}

				InputControls.SelectBox dlg = new InputControls.SelectBox();

				dlg.Question = "Invalid IP Address.";
				dlg.LeftCommand = "";
				dlg.RightCommand = "OK";

				dlg.ShowDialog();
			}
		}

		private void button_Stream_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;

			if (button.Text == "Yes")
				button.Text = "No";
			else
				button.Text = "Yes";
        }
	}
}