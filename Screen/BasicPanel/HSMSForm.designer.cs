namespace BasicPanel
{
	partial class HSMSForm
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.button_close = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.textBox_Mode = new System.Windows.Forms.TextBox();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.button_s5 = new System.Windows.Forms.Button();
            this.button_s6 = new System.Windows.Forms.Button();
            this.button_s10 = new System.Windows.Forms.Button();
            this.textBox_T3 = new InputControls.NumericTextBox();
            this.textBox_T5 = new InputControls.NumericTextBox();
            this.textBox_T6 = new InputControls.NumericTextBox();
            this.textBox_T7 = new InputControls.NumericTextBox();
            this.textBox_T8 = new InputControls.NumericTextBox();
            this.textBox_Port = new InputControls.NumericTextBox();
            this.textBox_deviceID = new InputControls.NumericTextBox();
            this.SuspendLayout();
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(302, 460);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(90, 35);
            this.button_close.TabIndex = 2;
            this.button_close.TabStop = false;
            this.button_close.Text = "Close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(206, 460);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(90, 35);
            this.button_save.TabIndex = 3;
            this.button_save.TabStop = false;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // textBox_Mode
            // 
            this.textBox_Mode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_Mode.Location = new System.Drawing.Point(210, 305);
            this.textBox_Mode.Name = "textBox_Mode";
            this.textBox_Mode.ReadOnly = true;
            this.textBox_Mode.Size = new System.Drawing.Size(163, 26);
            this.textBox_Mode.TabIndex = 15;
            this.textBox_Mode.TabStop = false;
            this.textBox_Mode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Mode.Click += new System.EventHandler(this.textBox_Mode_Click);
            // 
            // textBox_ip
            // 
            this.textBox_ip.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_ip.Location = new System.Drawing.Point(210, 377);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.ReadOnly = true;
            this.textBox_ip.Size = new System.Drawing.Size(163, 26);
            this.textBox_ip.TabIndex = 17;
            this.textBox_ip.TabStop = false;
            this.textBox_ip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_ip.Click += new System.EventHandler(this.textBox_ip_Click);
            // 
            // button_s5
            // 
            this.button_s5.Location = new System.Drawing.Point(229, 41);
            this.button_s5.Name = "button_s5";
            this.button_s5.Size = new System.Drawing.Size(120, 23);
            this.button_s5.TabIndex = 19;
            this.button_s5.Text = "Yes";
            this.button_s5.UseVisualStyleBackColor = true;
            this.button_s5.Click += new System.EventHandler(this.button_Stream_Click);
            // 
            // button_s6
            // 
            this.button_s6.Location = new System.Drawing.Point(229, 64);
            this.button_s6.Name = "button_s6";
            this.button_s6.Size = new System.Drawing.Size(120, 23);
            this.button_s6.TabIndex = 20;
            this.button_s6.Text = "Yes";
            this.button_s6.UseVisualStyleBackColor = true;
            this.button_s6.Click += new System.EventHandler(this.button_Stream_Click);
            // 
            // button_s10
            // 
            this.button_s10.Location = new System.Drawing.Point(229, 87);
            this.button_s10.Name = "button_s10";
            this.button_s10.Size = new System.Drawing.Size(120, 23);
            this.button_s10.TabIndex = 21;
            this.button_s10.Text = "Yes";
            this.button_s10.UseVisualStyleBackColor = true;
            this.button_s10.Click += new System.EventHandler(this.button_Stream_Click);
            // 
            // textBox_T3
            // 
            this.textBox_T3.AllowSpace = false;
            this.textBox_T3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_T3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_T3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_T3.Integer = false;
            this.textBox_T3.LimitRange = true;
            this.textBox_T3.Location = new System.Drawing.Point(210, 125);
            this.textBox_T3.Maximum = 120;
            this.textBox_T3.Minimum = 0;
            this.textBox_T3.MouseEvent = true;
            this.textBox_T3.Name = "textBox_T3";
            this.textBox_T3.Size = new System.Drawing.Size(120, 26);
            this.textBox_T3.TabIndex = 22;
            this.textBox_T3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_T3.Click += new System.EventHandler(this.textBox_num_Click);
            // 
            // textBox_T5
            // 
            this.textBox_T5.AllowSpace = false;
            this.textBox_T5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_T5.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_T5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_T5.Integer = false;
            this.textBox_T5.LimitRange = true;
            this.textBox_T5.Location = new System.Drawing.Point(210, 161);
            this.textBox_T5.Maximum = 240;
            this.textBox_T5.Minimum = 0;
            this.textBox_T5.MouseEvent = true;
            this.textBox_T5.Name = "textBox_T5";
            this.textBox_T5.Size = new System.Drawing.Size(120, 26);
            this.textBox_T5.TabIndex = 23;
            this.textBox_T5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_T5.Click += new System.EventHandler(this.textBox_num_Click);
            // 
            // textBox_T6
            // 
            this.textBox_T6.AllowSpace = false;
            this.textBox_T6.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_T6.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_T6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_T6.Integer = false;
            this.textBox_T6.LimitRange = true;
            this.textBox_T6.Location = new System.Drawing.Point(210, 197);
            this.textBox_T6.Maximum = 240;
            this.textBox_T6.Minimum = 0;
            this.textBox_T6.MouseEvent = true;
            this.textBox_T6.Name = "textBox_T6";
            this.textBox_T6.Size = new System.Drawing.Size(120, 26);
            this.textBox_T6.TabIndex = 24;
            this.textBox_T6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_T6.Click += new System.EventHandler(this.textBox_num_Click);
            // 
            // textBox_T7
            // 
            this.textBox_T7.AllowSpace = false;
            this.textBox_T7.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_T7.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_T7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_T7.Integer = false;
            this.textBox_T7.LimitRange = true;
            this.textBox_T7.Location = new System.Drawing.Point(210, 233);
            this.textBox_T7.Maximum = 240;
            this.textBox_T7.Minimum = 0;
            this.textBox_T7.MouseEvent = true;
            this.textBox_T7.Name = "textBox_T7";
            this.textBox_T7.Size = new System.Drawing.Size(120, 26);
            this.textBox_T7.TabIndex = 25;
            this.textBox_T7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_T7.Click += new System.EventHandler(this.textBox_num_Click);
            // 
            // textBox_T8
            // 
            this.textBox_T8.AllowSpace = false;
            this.textBox_T8.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_T8.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_T8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_T8.Integer = false;
            this.textBox_T8.LimitRange = true;
            this.textBox_T8.Location = new System.Drawing.Point(210, 269);
            this.textBox_T8.Maximum = 120;
            this.textBox_T8.Minimum = 0;
            this.textBox_T8.MouseEvent = true;
            this.textBox_T8.Name = "textBox_T8";
            this.textBox_T8.Size = new System.Drawing.Size(120, 26);
            this.textBox_T8.TabIndex = 26;
            this.textBox_T8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_T8.Click += new System.EventHandler(this.textBox_num_Click);
            // 
            // textBox_Port
            // 
            this.textBox_Port.AllowSpace = false;
            this.textBox_Port.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_Port.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_Port.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Port.Integer = false;
            this.textBox_Port.LimitRange = true;
            this.textBox_Port.Location = new System.Drawing.Point(210, 341);
            this.textBox_Port.Maximum = 32767;
            this.textBox_Port.Minimum = 1024;
            this.textBox_Port.MouseEvent = true;
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(163, 26);
            this.textBox_Port.TabIndex = 27;
            this.textBox_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Port.Click += new System.EventHandler(this.textBox_num_Click);
            // 
            // textBox_deviceID
            // 
            this.textBox_deviceID.AllowSpace = false;
            this.textBox_deviceID.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_deviceID.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_deviceID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_deviceID.Integer = false;
            this.textBox_deviceID.LimitRange = true;
            this.textBox_deviceID.Location = new System.Drawing.Point(210, 413);
            this.textBox_deviceID.Maximum = 32767;
            this.textBox_deviceID.Minimum = 0;
            this.textBox_deviceID.MouseEvent = true;
            this.textBox_deviceID.Name = "textBox_deviceID";
            this.textBox_deviceID.Size = new System.Drawing.Size(163, 26);
            this.textBox_deviceID.TabIndex = 28;
            this.textBox_deviceID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_deviceID.Click += new System.EventHandler(this.textBox_num_Click);
            // 
            // HSMSForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::BasicPanel.Properties.Resources.HSMSForm;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(402, 505);
            this.ControlBox = false;
            this.Controls.Add(this.button_s10);
            this.Controls.Add(this.button_s6);
            this.Controls.Add(this.button_s5);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.textBox_Mode);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.textBox_T3);
            this.Controls.Add(this.textBox_T5);
            this.Controls.Add(this.textBox_T6);
            this.Controls.Add(this.textBox_T7);
            this.Controls.Add(this.textBox_T8);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_deviceID);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "HSMSForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HSMS Parameter";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.TextBox textBox_Mode;
        private System.Windows.Forms.TextBox textBox_ip;
		private System.Windows.Forms.Button button_s5;
		private System.Windows.Forms.Button button_s6;
		private System.Windows.Forms.Button button_s10;
        private InputControls.NumericTextBox textBox_T3;
        private InputControls.NumericTextBox textBox_T5;
        private InputControls.NumericTextBox textBox_T6;
        private InputControls.NumericTextBox textBox_T7;
        private InputControls.NumericTextBox textBox_T8;
        private InputControls.NumericTextBox textBox_Port;
        private InputControls.NumericTextBox textBox_deviceID;
	}
}