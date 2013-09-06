using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BasicPanel
{
	public partial class TerminalForm : Form
	{
		public event EventHandler RecognizeMessage = null;

		public TerminalForm()
		{
			InitializeComponent();

			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		}

		public string Message
		{
			set
			{
				richTextBox_message.Text = value;
			}
		}

		private void button_ok_Click(object sender, EventArgs e)
		{
			if (RecognizeMessage != null)
				RecognizeMessage(sender, e);

			this.DialogResult = DialogResult.OK;
			this.Hide();
		}
	}
}