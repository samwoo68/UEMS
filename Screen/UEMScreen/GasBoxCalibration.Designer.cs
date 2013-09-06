namespace UEMScreen
{
    partial class GasBoxCalibration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GasBoxCalibration));
            this.adsClient1 = new TwinCATAdapter.ADSClient();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.digitalBox2 = new IronControls.DigitalBox();
            this.analogBox2 = new IronControls.AnalogBox();
            this.analogBox1 = new IronControls.AnalogBox();
            this.analogBox3 = new IronControls.AnalogBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // adsClient1
            // 
            this.adsClient1.ADSPort = TwinCATAdapter.ADSPorts.TASK1;
            this.adsClient1.AMSNetID = "192.168.10.221.1.1";
            this.adsClient1.SynchronizingObject = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.analogBox3);
            this.panel1.Location = new System.Drawing.Point(29, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 882);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.analogBox2);
            this.panel2.Controls.Add(this.analogBox1);
            this.panel2.Location = new System.Drawing.Point(208, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(152, 882);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(384, 21);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(152, 882);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(561, 21);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(152, 882);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(743, 21);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(152, 882);
            this.panel5.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(921, 21);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(152, 882);
            this.panel6.TabIndex = 1;
            // 
            // digitalBox2
            // 
            this.digitalBox2.AccessMode = IronControls.AccessModes.DirectMode;
            this.digitalBox2.BackColor = System.Drawing.Color.Orange;
            this.digitalBox2.BoxName = "설정";
            this.digitalBox2.CommComponent = this.adsClient1;
            this.digitalBox2.Data = -1;
            this.digitalBox2.Description = "Digital IO";
            this.digitalBox2.FirstTag = "PLC-XGK:M00020";
            this.digitalBox2.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.digitalBox2.LeftisOn = true;
            this.digitalBox2.Location = new System.Drawing.Point(1183, 97);
            this.digitalBox2.Mode = IronControls._Mode.NAME_DISPLAY;
            this.digitalBox2.Name = "digitalBox2";
            this.digitalBox2.OffColor = System.Drawing.SystemColors.Control;
            this.digitalBox2.OffValue = "Off";
            this.digitalBox2.OnColor = System.Drawing.Color.Lime;
            this.digitalBox2.OnValue = "On";
            this.digitalBox2.SecondTag = "";
            this.digitalBox2.SetData = -1;
            this.digitalBox2.Size = new System.Drawing.Size(67, 35);
            this.digitalBox2.TabIndex = 58;
            this.digitalBox2.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("digitalBox2.Tags")));
            this.digitalBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.digitalBox2.Toggle = false;
            this.digitalBox2.Type = IronControls.IOType.OUTPUT;
            this.digitalBox2.UpdateMode = CommLib.UpdateMode.OnChange;
            this.digitalBox2.UpdateTime = 500;
            this.digitalBox2.Visible = false;
            // 
            // analogBox2
            // 
            this.analogBox2.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox2.BackColor = System.Drawing.Color.Orange;
            this.analogBox2.BoxName = "";
            this.analogBox2.CommComponent = this.adsClient1;
            this.analogBox2.Data = 0D;
            this.analogBox2.DecimalPlace = 0;
            this.analogBox2.Description = "Analog IO";
            this.analogBox2.Exponent = false;
            this.analogBox2.FirstTag = "PLC-XGK:D00317";
            this.analogBox2.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox2.ForeColor = System.Drawing.Color.Blue;
            this.analogBox2.Gain = 0D;
            this.analogBox2.GroupSeparator = false;
            this.analogBox2.Location = new System.Drawing.Point(3, 45);
            this.analogBox2.Max = 800D;
            this.analogBox2.Min = 0D;
            this.analogBox2.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox2.Name = "analogBox2";
            this.analogBox2.Offset = 0D;
            this.analogBox2.Round = false;
            this.analogBox2.SecondTag = "";
            this.analogBox2.Size = new System.Drawing.Size(136, 36);
            this.analogBox2.TabIndex = 59;
            this.analogBox2.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox2.Tags")));
            this.analogBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox2.Type = IronControls.IOType.OUTPUT;
            this.analogBox2.Unit = "";
            this.analogBox2.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox2.UpdateTime = 500;
            // 
            // analogBox1
            // 
            this.analogBox1.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox1.BackColor = System.Drawing.Color.Orange;
            this.analogBox1.BoxName = "";
            this.analogBox1.CommComponent = this.adsClient1;
            this.analogBox1.Data = 0D;
            this.analogBox1.DecimalPlace = 0;
            this.analogBox1.Description = "Analog IO";
            this.analogBox1.Exponent = false;
            this.analogBox1.FirstTag = "PLC-XGK:D00317";
            this.analogBox1.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox1.ForeColor = System.Drawing.Color.Blue;
            this.analogBox1.Gain = 0D;
            this.analogBox1.GroupSeparator = false;
            this.analogBox1.Location = new System.Drawing.Point(3, 3);
            this.analogBox1.Max = 800D;
            this.analogBox1.Min = 0D;
            this.analogBox1.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox1.Name = "analogBox1";
            this.analogBox1.Offset = 0D;
            this.analogBox1.Round = false;
            this.analogBox1.SecondTag = "";
            this.analogBox1.Size = new System.Drawing.Size(136, 36);
            this.analogBox1.TabIndex = 60;
            this.analogBox1.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox1.Tags")));
            this.analogBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox1.Type = IronControls.IOType.INPUT;
            this.analogBox1.Unit = "";
            this.analogBox1.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox1.UpdateTime = 500;
            // 
            // analogBox3
            // 
            this.analogBox3.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox3.BackColor = System.Drawing.Color.Orange;
            this.analogBox3.BoxName = "";
            this.analogBox3.CommComponent = this.adsClient1;
            this.analogBox3.Data = 0D;
            this.analogBox3.DecimalPlace = 0;
            this.analogBox3.Description = "Analog IO";
            this.analogBox3.Exponent = false;
            this.analogBox3.FirstTag = "Task 1.Outputs.GAS S1 Flowrate Set_1";
            this.analogBox3.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox3.ForeColor = System.Drawing.Color.Blue;
            this.analogBox3.Gain = 0D;
            this.analogBox3.GroupSeparator = false;
            this.analogBox3.Location = new System.Drawing.Point(3, 26);
            this.analogBox3.Max = 800D;
            this.analogBox3.Min = 0D;
            this.analogBox3.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox3.Name = "analogBox3";
            this.analogBox3.Offset = 0D;
            this.analogBox3.Round = false;
            this.analogBox3.SecondTag = "";
            this.analogBox3.Size = new System.Drawing.Size(136, 36);
            this.analogBox3.TabIndex = 60;
            this.analogBox3.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox3.Tags")));
            this.analogBox3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox3.Type = IronControls.IOType.OUTPUT;
            this.analogBox3.Unit = "";
            this.analogBox3.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox3.UpdateTime = 500;
            // 
            // GasBoxCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1840, 915);
            this.Controls.Add(this.digitalBox2);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "GasBoxCalibration";
            this.ProjectPath = "C:\\UEMS-R1";
            this.Resolution = IronPanel._Resolution.HD1080;
            this.Text = "GAXBOXTest";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TwinCATAdapter.ADSClient adsClient1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private IronControls.DigitalBox digitalBox2;
        private IronControls.AnalogBox analogBox2;
        private IronControls.AnalogBox analogBox1;
        private IronControls.AnalogBox analogBox3;
    }
}