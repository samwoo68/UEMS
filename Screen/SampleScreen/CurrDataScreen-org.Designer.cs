namespace SampleScreen
{
    partial class CurrDataScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrDataScreen));
            this.ironSANClient1 = new IronSANAdapter.IronSANClient();
            this.opcClient1 = new OPCAdapter.OPCClient();
            this.opcClient2 = new OPCAdapter.OPCClient();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.analogBox26 = new IronControls.AnalogBox();
            this.analogBox27 = new IronControls.AnalogBox();
            this.analogBox30 = new IronControls.AnalogBox();
            this.analogBox31 = new IronControls.AnalogBox();
            this.analogBox16 = new IronControls.AnalogBox();
            this.analogBox17 = new IronControls.AnalogBox();
            this.analogBox20 = new IronControls.AnalogBox();
            this.analogBox21 = new IronControls.AnalogBox();
            this.analogBox22 = new IronControls.AnalogBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.pictureBox28 = new System.Windows.Forms.PictureBox();
            this.analogBox2 = new IronControls.AnalogBox();
            this.analogBox1 = new IronControls.AnalogBox();
            this.analogBox10 = new IronControls.AnalogBox();
            this.analogBox7 = new IronControls.AnalogBox();
            this.analogBox13 = new IronControls.AnalogBox();
            this.analogBox19 = new IronControls.AnalogBox();
            this.analogBox24 = new IronControls.AnalogBox();
            this.analogBox18 = new IronControls.AnalogBox();
            this.analogBox11 = new IronControls.AnalogBox();
            this.analogBox8 = new IronControls.AnalogBox();
            this.analogBox5 = new IronControls.AnalogBox();
            this.analogBox3 = new IronControls.AnalogBox();
            this.analogBox15 = new IronControls.AnalogBox();
            this.analogBox14 = new IronControls.AnalogBox();
            this.analogBox12 = new IronControls.AnalogBox();
            this.analogBox9 = new IronControls.AnalogBox();
            this.analogBox6 = new IronControls.AnalogBox();
            this.analogBox4 = new IronControls.AnalogBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.analogBox37 = new IronControls.AnalogBox();
            this.analogBox36 = new IronControls.AnalogBox();
            this.label21 = new System.Windows.Forms.Label();
            this.analogBox35 = new IronControls.AnalogBox();
            this.label19 = new System.Windows.Forms.Label();
            this.analogBox34 = new IronControls.AnalogBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.analogBox33 = new IronControls.AnalogBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.analogBox32 = new IronControls.AnalogBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.analogBox23 = new IronControls.AnalogBox();
            this.analogBox25 = new IronControls.AnalogBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.analogBox29 = new IronControls.AnalogBox();
            this.analogBox28 = new IronControls.AnalogBox();
            this.label20 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox28)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ironSANClient1
            // 
            this.ironSANClient1.ProjectPath = "c:\\EEMS-R1\\";
            this.ironSANClient1.ScriptEnable = false;
            this.ironSANClient1.SynchronizingObject = this;
            // 
            // opcClient1
            // 
            this.opcClient1.Group = "MyGroup";
            this.opcClient1.Server = "KEPware.KEPServerEX.V5";
            this.opcClient1.SynchronizingObject = this;
            this.opcClient1.Topic = "";
            // 
            // opcClient2
            // 
            this.opcClient2.Group = "MyGroup";
            this.opcClient2.Server = "Intellution.LSEOPC";
            this.opcClient2.SynchronizingObject = this;
            this.opcClient2.Topic = "";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(586, 130);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 130;
            this.button13.Text = "계량#4";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(444, 130);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 129;
            this.button12.Text = "계량#3";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(307, 130);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 128;
            this.button11.Text = "계량#2";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(162, 130);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 127;
            this.button10.Text = "계량#1";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(48, 188);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 126;
            this.button9.Text = "인고트중량";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(48, 70);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 124;
            this.button7.Text = "스크랩";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(162, 382);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 123;
            this.button4.Text = "SV";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(307, 382);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 122;
            this.button5.Text = "PV";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(162, 254);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 120;
            this.button3.Text = "SV";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(307, 254);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 119;
            this.button2.Text = "PV";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(48, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 118;
            this.button1.Text = "용탕온도";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // analogBox26
            // 
            this.analogBox26.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox26.BoxName = "";
            this.analogBox26.CommComponent = this.opcClient2;
            this.analogBox26.Data = 0D;
            this.analogBox26.DecimalPlace = 0;
            this.analogBox26.Description = "Analog IO";
            this.analogBox26.Exponent = false;
            this.analogBox26.FirstTag = "PLC-XGK:D00311";
            this.analogBox26.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox26.Gain = 0D;
            this.analogBox26.GroupSeparator = false;
            this.analogBox26.Location = new System.Drawing.Point(139, 421);
            this.analogBox26.Max = 10000;
            this.analogBox26.Min = -10000;
            this.analogBox26.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox26.Name = "analogBox26";
            this.analogBox26.Offset = 0D;
            this.analogBox26.Round = false;
            this.analogBox26.SecondTag = "";
            this.analogBox26.Size = new System.Drawing.Size(123, 56);
            this.analogBox26.TabIndex = 142;
            this.analogBox26.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox26.Tags")));
            this.analogBox26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox26.Type = IronControls.IOType.INPUT;
            this.analogBox26.Unit = "";
            this.analogBox26.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox26.UpdateTime = 500;
            // 
            // analogBox27
            // 
            this.analogBox27.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox27.BoxName = "";
            this.analogBox27.CommComponent = this.opcClient2;
            this.analogBox27.Data = 0D;
            this.analogBox27.DecimalPlace = 0;
            this.analogBox27.Description = "Analog IO";
            this.analogBox27.Exponent = false;
            this.analogBox27.FirstTag = "PLC-XGK:D00310";
            this.analogBox27.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox27.Gain = 0D;
            this.analogBox27.GroupSeparator = false;
            this.analogBox27.Location = new System.Drawing.Point(281, 421);
            this.analogBox27.Max = 10000;
            this.analogBox27.Min = -10000;
            this.analogBox27.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox27.Name = "analogBox27";
            this.analogBox27.Offset = 0D;
            this.analogBox27.Round = false;
            this.analogBox27.SecondTag = "";
            this.analogBox27.Size = new System.Drawing.Size(123, 56);
            this.analogBox27.TabIndex = 143;
            this.analogBox27.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox27.Tags")));
            this.analogBox27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox27.Type = IronControls.IOType.INPUT;
            this.analogBox27.Unit = "";
            this.analogBox27.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox27.UpdateTime = 500;
            // 
            // analogBox30
            // 
            this.analogBox30.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox30.BoxName = "";
            this.analogBox30.CommComponent = this.opcClient2;
            this.analogBox30.Data = 0D;
            this.analogBox30.DecimalPlace = 0;
            this.analogBox30.Description = "Analog IO";
            this.analogBox30.Exponent = false;
            this.analogBox30.FirstTag = "PLC-XGK:D00300";
            this.analogBox30.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox30.Gain = 0D;
            this.analogBox30.GroupSeparator = false;
            this.analogBox30.Location = new System.Drawing.Point(281, 296);
            this.analogBox30.Max = 10000;
            this.analogBox30.Min = -10000;
            this.analogBox30.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox30.Name = "analogBox30";
            this.analogBox30.Offset = 0D;
            this.analogBox30.Round = false;
            this.analogBox30.SecondTag = "";
            this.analogBox30.Size = new System.Drawing.Size(123, 56);
            this.analogBox30.TabIndex = 146;
            this.analogBox30.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox30.Tags")));
            this.analogBox30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox30.Type = IronControls.IOType.INPUT;
            this.analogBox30.Unit = "";
            this.analogBox30.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox30.UpdateTime = 500;
            // 
            // analogBox31
            // 
            this.analogBox31.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox31.BoxName = "";
            this.analogBox31.CommComponent = this.opcClient2;
            this.analogBox31.Data = 0D;
            this.analogBox31.DecimalPlace = 0;
            this.analogBox31.Description = "Analog IO";
            this.analogBox31.Exponent = false;
            this.analogBox31.FirstTag = "PLC-XGK:D00301";
            this.analogBox31.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox31.Gain = 0D;
            this.analogBox31.GroupSeparator = false;
            this.analogBox31.Location = new System.Drawing.Point(139, 296);
            this.analogBox31.Max = 10000;
            this.analogBox31.Min = -10000;
            this.analogBox31.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox31.Name = "analogBox31";
            this.analogBox31.Offset = 0D;
            this.analogBox31.Round = false;
            this.analogBox31.SecondTag = "";
            this.analogBox31.Size = new System.Drawing.Size(123, 56);
            this.analogBox31.TabIndex = 145;
            this.analogBox31.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox31.Tags")));
            this.analogBox31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox31.Type = IronControls.IOType.INPUT;
            this.analogBox31.Unit = "";
            this.analogBox31.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox31.UpdateTime = 500;
            // 
            // analogBox16
            // 
            this.analogBox16.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox16.BoxName = "";
            this.analogBox16.CommComponent = this.opcClient2;
            this.analogBox16.Data = 0D;
            this.analogBox16.DecimalPlace = 0;
            this.analogBox16.Description = "Analog IO";
            this.analogBox16.Exponent = false;
            this.analogBox16.FirstTag = "PLC-XGK:D00623";
            this.analogBox16.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox16.Gain = 0D;
            this.analogBox16.GroupSeparator = false;
            this.analogBox16.Location = new System.Drawing.Point(281, 173);
            this.analogBox16.Max = 10000;
            this.analogBox16.Min = -10000;
            this.analogBox16.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox16.Name = "analogBox16";
            this.analogBox16.Offset = 0D;
            this.analogBox16.Round = false;
            this.analogBox16.SecondTag = "";
            this.analogBox16.Size = new System.Drawing.Size(123, 56);
            this.analogBox16.TabIndex = 150;
            this.analogBox16.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox16.Tags")));
            this.analogBox16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox16.Type = IronControls.IOType.INPUT;
            this.analogBox16.Unit = "";
            this.analogBox16.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox16.UpdateTime = 500;
            // 
            // analogBox17
            // 
            this.analogBox17.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox17.BoxName = "";
            this.analogBox17.CommComponent = this.opcClient2;
            this.analogBox17.Data = 0D;
            this.analogBox17.DecimalPlace = 0;
            this.analogBox17.Description = "Analog IO";
            this.analogBox17.Exponent = false;
            this.analogBox17.FirstTag = "PLC-XGK:D00624";
            this.analogBox17.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox17.Gain = 0D;
            this.analogBox17.GroupSeparator = false;
            this.analogBox17.Location = new System.Drawing.Point(139, 173);
            this.analogBox17.Max = 10000;
            this.analogBox17.Min = -10000;
            this.analogBox17.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox17.Name = "analogBox17";
            this.analogBox17.Offset = 0D;
            this.analogBox17.Round = false;
            this.analogBox17.SecondTag = "";
            this.analogBox17.Size = new System.Drawing.Size(123, 56);
            this.analogBox17.TabIndex = 149;
            this.analogBox17.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox17.Tags")));
            this.analogBox17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox17.Type = IronControls.IOType.INPUT;
            this.analogBox17.Unit = "";
            this.analogBox17.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox17.UpdateTime = 500;
            // 
            // analogBox20
            // 
            this.analogBox20.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox20.BoxName = "";
            this.analogBox20.CommComponent = this.opcClient2;
            this.analogBox20.Data = 0D;
            this.analogBox20.DecimalPlace = 0;
            this.analogBox20.Description = "Analog IO";
            this.analogBox20.Exponent = false;
            this.analogBox20.FirstTag = "PLC-XGK:D00621";
            this.analogBox20.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox20.Gain = 0D;
            this.analogBox20.GroupSeparator = false;
            this.analogBox20.Location = new System.Drawing.Point(565, 173);
            this.analogBox20.Max = 10000;
            this.analogBox20.Min = -10000;
            this.analogBox20.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox20.Name = "analogBox20";
            this.analogBox20.Offset = 0D;
            this.analogBox20.Round = false;
            this.analogBox20.SecondTag = "";
            this.analogBox20.Size = new System.Drawing.Size(123, 56);
            this.analogBox20.TabIndex = 152;
            this.analogBox20.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox20.Tags")));
            this.analogBox20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox20.Type = IronControls.IOType.INPUT;
            this.analogBox20.Unit = "";
            this.analogBox20.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox20.UpdateTime = 500;
            // 
            // analogBox21
            // 
            this.analogBox21.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox21.BoxName = "";
            this.analogBox21.CommComponent = this.opcClient2;
            this.analogBox21.Data = 0D;
            this.analogBox21.DecimalPlace = 0;
            this.analogBox21.Description = "Analog IO";
            this.analogBox21.Exponent = false;
            this.analogBox21.FirstTag = "PLC-XGK:D00622";
            this.analogBox21.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox21.Gain = 0D;
            this.analogBox21.GroupSeparator = false;
            this.analogBox21.Location = new System.Drawing.Point(422, 173);
            this.analogBox21.Max = 10000;
            this.analogBox21.Min = -10000;
            this.analogBox21.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox21.Name = "analogBox21";
            this.analogBox21.Offset = 0D;
            this.analogBox21.Round = false;
            this.analogBox21.SecondTag = "";
            this.analogBox21.Size = new System.Drawing.Size(123, 56);
            this.analogBox21.TabIndex = 151;
            this.analogBox21.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox21.Tags")));
            this.analogBox21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox21.Type = IronControls.IOType.INPUT;
            this.analogBox21.Unit = "";
            this.analogBox21.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox21.UpdateTime = 500;
            // 
            // analogBox22
            // 
            this.analogBox22.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox22.BoxName = "";
            this.analogBox22.CommComponent = this.opcClient2;
            this.analogBox22.Data = 0D;
            this.analogBox22.DecimalPlace = 0;
            this.analogBox22.Description = "Analog IO";
            this.analogBox22.Exponent = false;
            this.analogBox22.FirstTag = "PLC-XGK:D00513";
            this.analogBox22.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox22.Gain = 0D;
            this.analogBox22.GroupSeparator = false;
            this.analogBox22.Location = new System.Drawing.Point(141, 53);
            this.analogBox22.Max = 10000;
            this.analogBox22.Min = -10000;
            this.analogBox22.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox22.Name = "analogBox22";
            this.analogBox22.Offset = 0D;
            this.analogBox22.Round = false;
            this.analogBox22.SecondTag = "";
            this.analogBox22.Size = new System.Drawing.Size(123, 56);
            this.analogBox22.TabIndex = 154;
            this.analogBox22.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox22.Tags")));
            this.analogBox22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox22.Type = IronControls.IOType.INPUT;
            this.analogBox22.Unit = "";
            this.analogBox22.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox22.UpdateTime = 500;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.analogBox22);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.button10);
            this.panel2.Controls.Add(this.analogBox20);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.analogBox21);
            this.panel2.Controls.Add(this.analogBox30);
            this.panel2.Controls.Add(this.analogBox16);
            this.panel2.Controls.Add(this.analogBox31);
            this.panel2.Controls.Add(this.analogBox17);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.analogBox27);
            this.panel2.Controls.Add(this.button11);
            this.panel2.Controls.Add(this.analogBox26);
            this.panel2.Controls.Add(this.button12);
            this.panel2.Controls.Add(this.button13);
            this.panel2.Controls.Add(this.button14);
            this.panel2.Location = new System.Drawing.Point(1043, 155);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(716, 516);
            this.panel2.TabIndex = 132;
            this.panel2.Visible = false;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(162, 13);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 155;
            this.button8.Text = "계량";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(48, 440);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 121;
            this.button14.Text = "타워온도";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // pictureBox28
            // 
            this.pictureBox28.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox28.Image = global::SampleScreen.Properties.Resources.생산현황_타이틀;
            this.pictureBox28.Location = new System.Drawing.Point(557, 25);
            this.pictureBox28.Name = "pictureBox28";
            this.pictureBox28.Size = new System.Drawing.Size(643, 122);
            this.pictureBox28.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox28.TabIndex = 173;
            this.pictureBox28.TabStop = false;
            // 
            // analogBox2
            // 
            this.analogBox2.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox2.BackColor = System.Drawing.Color.White;
            this.analogBox2.BoxName = "";
            this.analogBox2.CommComponent = this.ironSANClient1;
            this.analogBox2.Data = 0D;
            this.analogBox2.DecimalPlace = 1;
            this.analogBox2.Description = "Analog IO";
            this.analogBox2.Exponent = false;
            this.analogBox2.FirstTag = "AO.EEMS-R1.Ingot_Per_Hour";
            this.analogBox2.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox2.Gain = 1D;
            this.analogBox2.GroupSeparator = false;
            this.analogBox2.Location = new System.Drawing.Point(316, 221);
            this.analogBox2.Max = 999999999;
            this.analogBox2.Min = 0;
            this.analogBox2.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox2.Name = "analogBox2";
            this.analogBox2.Offset = 0D;
            this.analogBox2.Round = false;
            this.analogBox2.SecondTag = "";
            this.analogBox2.Size = new System.Drawing.Size(200, 88);
            this.analogBox2.TabIndex = 133;
            this.analogBox2.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox2.Tags")));
            this.analogBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox2.Type = IronControls.IOType.INPUT;
            this.analogBox2.Unit = "";
            this.analogBox2.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox2.UpdateTime = 500;
            // 
            // analogBox1
            // 
            this.analogBox1.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox1.BackColor = System.Drawing.Color.White;
            this.analogBox1.BoxName = "";
            this.analogBox1.CommComponent = this.ironSANClient1;
            this.analogBox1.Data = 0D;
            this.analogBox1.DecimalPlace = 1;
            this.analogBox1.Description = "Analog IO";
            this.analogBox1.Exponent = false;
            this.analogBox1.FirstTag = "AO.EEMS-R1.Scrap_Per_Hour";
            this.analogBox1.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox1.Gain = 1D;
            this.analogBox1.GroupSeparator = false;
            this.analogBox1.Location = new System.Drawing.Point(316, 116);
            this.analogBox1.Max = 999999999;
            this.analogBox1.Min = 0;
            this.analogBox1.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox1.Name = "analogBox1";
            this.analogBox1.Offset = 0D;
            this.analogBox1.Round = false;
            this.analogBox1.SecondTag = "";
            this.analogBox1.Size = new System.Drawing.Size(200, 88);
            this.analogBox1.TabIndex = 132;
            this.analogBox1.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox1.Tags")));
            this.analogBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox1.Type = IronControls.IOType.INPUT;
            this.analogBox1.Unit = "";
            this.analogBox1.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox1.UpdateTime = 500;
            // 
            // analogBox10
            // 
            this.analogBox10.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox10.BackColor = System.Drawing.Color.White;
            this.analogBox10.BoxName = "";
            this.analogBox10.CommComponent = this.ironSANClient1;
            this.analogBox10.Data = 0D;
            this.analogBox10.DecimalPlace = 1;
            this.analogBox10.Description = "Analog IO";
            this.analogBox10.Exponent = false;
            this.analogBox10.FirstTag = "AO.EEMS-R1.Gas_Per_Hour";
            this.analogBox10.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox10.ForeColor = System.Drawing.Color.ForestGreen;
            this.analogBox10.Gain = 1D;
            this.analogBox10.GroupSeparator = false;
            this.analogBox10.Location = new System.Drawing.Point(316, 531);
            this.analogBox10.Max = 999999999;
            this.analogBox10.Min = 0;
            this.analogBox10.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox10.Name = "analogBox10";
            this.analogBox10.Offset = 0D;
            this.analogBox10.Round = false;
            this.analogBox10.SecondTag = "";
            this.analogBox10.Size = new System.Drawing.Size(282, 88);
            this.analogBox10.TabIndex = 141;
            this.analogBox10.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox10.Tags")));
            this.analogBox10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox10.Type = IronControls.IOType.INPUT;
            this.analogBox10.Unit = "";
            this.analogBox10.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox10.UpdateTime = 500;
            // 
            // analogBox7
            // 
            this.analogBox7.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox7.BackColor = System.Drawing.Color.White;
            this.analogBox7.BoxName = "";
            this.analogBox7.CommComponent = this.ironSANClient1;
            this.analogBox7.Data = 0D;
            this.analogBox7.DecimalPlace = 1;
            this.analogBox7.Description = "Analog IO";
            this.analogBox7.Exponent = false;
            this.analogBox7.FirstTag = "AO.EEMS-R1.Watt_Per_Hour";
            this.analogBox7.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox7.ForeColor = System.Drawing.Color.Red;
            this.analogBox7.Gain = 1D;
            this.analogBox7.GroupSeparator = false;
            this.analogBox7.Location = new System.Drawing.Point(316, 429);
            this.analogBox7.Max = 999999999;
            this.analogBox7.Min = 0;
            this.analogBox7.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox7.Name = "analogBox7";
            this.analogBox7.Offset = 0D;
            this.analogBox7.Round = false;
            this.analogBox7.SecondTag = "";
            this.analogBox7.Size = new System.Drawing.Size(282, 89);
            this.analogBox7.TabIndex = 138;
            this.analogBox7.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox7.Tags")));
            this.analogBox7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox7.Type = IronControls.IOType.INPUT;
            this.analogBox7.Unit = "";
            this.analogBox7.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox7.UpdateTime = 500;
            // 
            // analogBox13
            // 
            this.analogBox13.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox13.BackColor = System.Drawing.Color.White;
            this.analogBox13.BoxName = "";
            this.analogBox13.CommComponent = this.ironSANClient1;
            this.analogBox13.Data = 0D;
            this.analogBox13.DecimalPlace = 1;
            this.analogBox13.Description = "Analog IO";
            this.analogBox13.Exponent = false;
            this.analogBox13.FirstTag = "AO.EEMS-R1.m3Ton_Per_Hour";
            this.analogBox13.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox13.ForeColor = System.Drawing.Color.ForestGreen;
            this.analogBox13.Gain = 1D;
            this.analogBox13.GroupSeparator = false;
            this.analogBox13.Location = new System.Drawing.Point(316, 634);
            this.analogBox13.Max = 999999999;
            this.analogBox13.Min = 0;
            this.analogBox13.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox13.Name = "analogBox13";
            this.analogBox13.Offset = 0D;
            this.analogBox13.Round = false;
            this.analogBox13.SecondTag = "";
            this.analogBox13.Size = new System.Drawing.Size(282, 86);
            this.analogBox13.TabIndex = 144;
            this.analogBox13.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox13.Tags")));
            this.analogBox13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox13.Type = IronControls.IOType.INPUT;
            this.analogBox13.Unit = "";
            this.analogBox13.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox13.UpdateTime = 500;
            // 
            // analogBox19
            // 
            this.analogBox19.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox19.BackColor = System.Drawing.Color.White;
            this.analogBox19.BoxName = "";
            this.analogBox19.CommComponent = this.ironSANClient1;
            this.analogBox19.Data = 0D;
            this.analogBox19.DecimalPlace = 1;
            this.analogBox19.Description = "Analog IO";
            this.analogBox19.Exponent = false;
            this.analogBox19.FirstTag = "AO.EEMS-R1.Put_All_Per_Hour";
            this.analogBox19.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox19.Gain = 1D;
            this.analogBox19.GroupSeparator = false;
            this.analogBox19.Location = new System.Drawing.Point(316, 327);
            this.analogBox19.Max = 999999999;
            this.analogBox19.Min = 0;
            this.analogBox19.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox19.Name = "analogBox19";
            this.analogBox19.Offset = 0D;
            this.analogBox19.Round = false;
            this.analogBox19.SecondTag = "";
            this.analogBox19.Size = new System.Drawing.Size(282, 88);
            this.analogBox19.TabIndex = 172;
            this.analogBox19.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox19.Tags")));
            this.analogBox19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox19.Type = IronControls.IOType.INPUT;
            this.analogBox19.Unit = "";
            this.analogBox19.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox19.UpdateTime = 500;
            // 
            // analogBox24
            // 
            this.analogBox24.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox24.BackColor = System.Drawing.Color.White;
            this.analogBox24.BoxName = "";
            this.analogBox24.CommComponent = this.ironSANClient1;
            this.analogBox24.Data = 0D;
            this.analogBox24.DecimalPlace = 1;
            this.analogBox24.Description = "Analog IO";
            this.analogBox24.Exponent = false;
            this.analogBox24.FirstTag = "AO.EEMS-R1.Ingot_Per_Day";
            this.analogBox24.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox24.Gain = 1D;
            this.analogBox24.GroupSeparator = false;
            this.analogBox24.Location = new System.Drawing.Point(794, 223);
            this.analogBox24.Max = 999999999;
            this.analogBox24.Min = 0;
            this.analogBox24.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox24.Name = "analogBox24";
            this.analogBox24.Offset = 0D;
            this.analogBox24.Round = false;
            this.analogBox24.SecondTag = "";
            this.analogBox24.Size = new System.Drawing.Size(200, 87);
            this.analogBox24.TabIndex = 180;
            this.analogBox24.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox24.Tags")));
            this.analogBox24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox24.Type = IronControls.IOType.INPUT;
            this.analogBox24.Unit = "";
            this.analogBox24.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox24.UpdateTime = 500;
            // 
            // analogBox18
            // 
            this.analogBox18.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox18.BackColor = System.Drawing.Color.White;
            this.analogBox18.BoxName = "";
            this.analogBox18.CommComponent = this.ironSANClient1;
            this.analogBox18.Data = 0D;
            this.analogBox18.DecimalPlace = 1;
            this.analogBox18.Description = "Analog IO";
            this.analogBox18.Exponent = false;
            this.analogBox18.FirstTag = "AO.EEMS-R1.Scrap_Per_Day";
            this.analogBox18.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox18.Gain = 1D;
            this.analogBox18.GroupSeparator = false;
            this.analogBox18.Location = new System.Drawing.Point(794, 116);
            this.analogBox18.Max = 999999999;
            this.analogBox18.Min = 0;
            this.analogBox18.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox18.Name = "analogBox18";
            this.analogBox18.Offset = 0D;
            this.analogBox18.Round = false;
            this.analogBox18.SecondTag = "";
            this.analogBox18.Size = new System.Drawing.Size(200, 88);
            this.analogBox18.TabIndex = 179;
            this.analogBox18.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox18.Tags")));
            this.analogBox18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox18.Type = IronControls.IOType.INPUT;
            this.analogBox18.Unit = "";
            this.analogBox18.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox18.UpdateTime = 500;
            // 
            // analogBox11
            // 
            this.analogBox11.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox11.BackColor = System.Drawing.Color.White;
            this.analogBox11.BoxName = "";
            this.analogBox11.CommComponent = this.ironSANClient1;
            this.analogBox11.Data = 0D;
            this.analogBox11.DecimalPlace = 1;
            this.analogBox11.Description = "Analog IO";
            this.analogBox11.Exponent = false;
            this.analogBox11.FirstTag = "AO.EEMS-R1.Gas_Per_Day";
            this.analogBox11.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox11.ForeColor = System.Drawing.Color.ForestGreen;
            this.analogBox11.Gain = 1D;
            this.analogBox11.GroupSeparator = false;
            this.analogBox11.Location = new System.Drawing.Point(794, 531);
            this.analogBox11.Max = 999999999;
            this.analogBox11.Min = 0;
            this.analogBox11.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox11.Name = "analogBox11";
            this.analogBox11.Offset = 0D;
            this.analogBox11.Round = false;
            this.analogBox11.SecondTag = "";
            this.analogBox11.Size = new System.Drawing.Size(277, 88);
            this.analogBox11.TabIndex = 182;
            this.analogBox11.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox11.Tags")));
            this.analogBox11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox11.Type = IronControls.IOType.INPUT;
            this.analogBox11.Unit = "";
            this.analogBox11.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox11.UpdateTime = 500;
            // 
            // analogBox8
            // 
            this.analogBox8.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox8.BackColor = System.Drawing.Color.White;
            this.analogBox8.BoxName = "";
            this.analogBox8.CommComponent = this.ironSANClient1;
            this.analogBox8.Data = 0D;
            this.analogBox8.DecimalPlace = 1;
            this.analogBox8.Description = "Analog IO";
            this.analogBox8.Exponent = false;
            this.analogBox8.FirstTag = "AO.EEMS-R1.Watt_Per_Day";
            this.analogBox8.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox8.ForeColor = System.Drawing.Color.Red;
            this.analogBox8.Gain = 1D;
            this.analogBox8.GroupSeparator = false;
            this.analogBox8.Location = new System.Drawing.Point(794, 430);
            this.analogBox8.Max = 999999999;
            this.analogBox8.Min = 0;
            this.analogBox8.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox8.Name = "analogBox8";
            this.analogBox8.Offset = 0D;
            this.analogBox8.Round = false;
            this.analogBox8.SecondTag = "";
            this.analogBox8.Size = new System.Drawing.Size(277, 87);
            this.analogBox8.TabIndex = 181;
            this.analogBox8.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox8.Tags")));
            this.analogBox8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox8.Type = IronControls.IOType.INPUT;
            this.analogBox8.Unit = "";
            this.analogBox8.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox8.UpdateTime = 500;
            // 
            // analogBox5
            // 
            this.analogBox5.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox5.BackColor = System.Drawing.Color.White;
            this.analogBox5.BoxName = "";
            this.analogBox5.CommComponent = this.ironSANClient1;
            this.analogBox5.Data = 0D;
            this.analogBox5.DecimalPlace = 1;
            this.analogBox5.Description = "Analog IO";
            this.analogBox5.Exponent = false;
            this.analogBox5.FirstTag = "AO.EEMS-R1.m3Ton_Per_Day";
            this.analogBox5.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox5.ForeColor = System.Drawing.Color.ForestGreen;
            this.analogBox5.Gain = 1D;
            this.analogBox5.GroupSeparator = false;
            this.analogBox5.Location = new System.Drawing.Point(794, 637);
            this.analogBox5.Max = 999999999;
            this.analogBox5.Min = 0;
            this.analogBox5.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox5.Name = "analogBox5";
            this.analogBox5.Offset = 0D;
            this.analogBox5.Round = false;
            this.analogBox5.SecondTag = "";
            this.analogBox5.Size = new System.Drawing.Size(277, 82);
            this.analogBox5.TabIndex = 183;
            this.analogBox5.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox5.Tags")));
            this.analogBox5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox5.Type = IronControls.IOType.INPUT;
            this.analogBox5.Unit = "";
            this.analogBox5.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox5.UpdateTime = 500;
            // 
            // analogBox3
            // 
            this.analogBox3.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox3.BackColor = System.Drawing.Color.White;
            this.analogBox3.BoxName = "";
            this.analogBox3.CommComponent = this.ironSANClient1;
            this.analogBox3.Data = 0D;
            this.analogBox3.DecimalPlace = 1;
            this.analogBox3.Description = "Analog IO";
            this.analogBox3.Exponent = false;
            this.analogBox3.FirstTag = "AO.EEMS-R1.Put_All_Per_Day";
            this.analogBox3.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox3.Gain = 1D;
            this.analogBox3.GroupSeparator = false;
            this.analogBox3.Location = new System.Drawing.Point(794, 327);
            this.analogBox3.Max = 999999999;
            this.analogBox3.Min = 0;
            this.analogBox3.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox3.Name = "analogBox3";
            this.analogBox3.Offset = 0D;
            this.analogBox3.Round = false;
            this.analogBox3.SecondTag = "";
            this.analogBox3.Size = new System.Drawing.Size(277, 87);
            this.analogBox3.TabIndex = 184;
            this.analogBox3.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox3.Tags")));
            this.analogBox3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox3.Type = IronControls.IOType.INPUT;
            this.analogBox3.Unit = "";
            this.analogBox3.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox3.UpdateTime = 500;
            // 
            // analogBox15
            // 
            this.analogBox15.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox15.BackColor = System.Drawing.Color.White;
            this.analogBox15.BoxName = "";
            this.analogBox15.CommComponent = this.ironSANClient1;
            this.analogBox15.Data = 0D;
            this.analogBox15.DecimalPlace = 1;
            this.analogBox15.Description = "Analog IO";
            this.analogBox15.Exponent = false;
            this.analogBox15.FirstTag = "AO.EEMS-R1.Ingot_Per_Month";
            this.analogBox15.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox15.Gain = 1D;
            this.analogBox15.GroupSeparator = false;
            this.analogBox15.Location = new System.Drawing.Point(1269, 222);
            this.analogBox15.Max = 999999999;
            this.analogBox15.Min = 0;
            this.analogBox15.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox15.Name = "analogBox15";
            this.analogBox15.Offset = 0D;
            this.analogBox15.Round = false;
            this.analogBox15.SecondTag = "";
            this.analogBox15.Size = new System.Drawing.Size(200, 86);
            this.analogBox15.TabIndex = 186;
            this.analogBox15.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox15.Tags")));
            this.analogBox15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox15.Type = IronControls.IOType.INPUT;
            this.analogBox15.Unit = "";
            this.analogBox15.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox15.UpdateTime = 500;
            // 
            // analogBox14
            // 
            this.analogBox14.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox14.BackColor = System.Drawing.Color.White;
            this.analogBox14.BoxName = "";
            this.analogBox14.CommComponent = this.ironSANClient1;
            this.analogBox14.Data = 0D;
            this.analogBox14.DecimalPlace = 1;
            this.analogBox14.Description = "Analog IO";
            this.analogBox14.Exponent = false;
            this.analogBox14.FirstTag = "AO.EEMS-R1.Scrap_Per_Month";
            this.analogBox14.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox14.Gain = 1D;
            this.analogBox14.GroupSeparator = false;
            this.analogBox14.Location = new System.Drawing.Point(1269, 116);
            this.analogBox14.Max = 999999999;
            this.analogBox14.Min = 0;
            this.analogBox14.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox14.Name = "analogBox14";
            this.analogBox14.Offset = 0D;
            this.analogBox14.Round = false;
            this.analogBox14.SecondTag = "";
            this.analogBox14.Size = new System.Drawing.Size(200, 88);
            this.analogBox14.TabIndex = 185;
            this.analogBox14.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox14.Tags")));
            this.analogBox14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox14.Type = IronControls.IOType.INPUT;
            this.analogBox14.Unit = "";
            this.analogBox14.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox14.UpdateTime = 500;
            // 
            // analogBox12
            // 
            this.analogBox12.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox12.BackColor = System.Drawing.Color.White;
            this.analogBox12.BoxName = "";
            this.analogBox12.CommComponent = this.ironSANClient1;
            this.analogBox12.Data = 0D;
            this.analogBox12.DecimalPlace = 1;
            this.analogBox12.Description = "Analog IO";
            this.analogBox12.Exponent = false;
            this.analogBox12.FirstTag = "AO.EEMS-R1.Gas_Per_Month";
            this.analogBox12.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox12.ForeColor = System.Drawing.Color.ForestGreen;
            this.analogBox12.Gain = 1D;
            this.analogBox12.GroupSeparator = false;
            this.analogBox12.Location = new System.Drawing.Point(1269, 533);
            this.analogBox12.Max = 999999999;
            this.analogBox12.Min = 0;
            this.analogBox12.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox12.Name = "analogBox12";
            this.analogBox12.Offset = 0D;
            this.analogBox12.Round = false;
            this.analogBox12.SecondTag = "";
            this.analogBox12.Size = new System.Drawing.Size(276, 86);
            this.analogBox12.TabIndex = 188;
            this.analogBox12.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox12.Tags")));
            this.analogBox12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox12.Type = IronControls.IOType.INPUT;
            this.analogBox12.Unit = "";
            this.analogBox12.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox12.UpdateTime = 500;
            // 
            // analogBox9
            // 
            this.analogBox9.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox9.BackColor = System.Drawing.Color.White;
            this.analogBox9.BoxName = "";
            this.analogBox9.CommComponent = this.ironSANClient1;
            this.analogBox9.Data = 0D;
            this.analogBox9.DecimalPlace = 1;
            this.analogBox9.Description = "Analog IO";
            this.analogBox9.Exponent = false;
            this.analogBox9.FirstTag = "AO.EEMS-R1.Watt_Per_Month";
            this.analogBox9.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox9.ForeColor = System.Drawing.Color.Red;
            this.analogBox9.Gain = 1D;
            this.analogBox9.GroupSeparator = false;
            this.analogBox9.Location = new System.Drawing.Point(1269, 430);
            this.analogBox9.Max = 999999999;
            this.analogBox9.Min = 0;
            this.analogBox9.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox9.Name = "analogBox9";
            this.analogBox9.Offset = 0D;
            this.analogBox9.Round = false;
            this.analogBox9.SecondTag = "";
            this.analogBox9.Size = new System.Drawing.Size(276, 86);
            this.analogBox9.TabIndex = 187;
            this.analogBox9.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox9.Tags")));
            this.analogBox9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox9.Type = IronControls.IOType.INPUT;
            this.analogBox9.Unit = "";
            this.analogBox9.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox9.UpdateTime = 500;
            // 
            // analogBox6
            // 
            this.analogBox6.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox6.BackColor = System.Drawing.Color.White;
            this.analogBox6.BoxName = "";
            this.analogBox6.CommComponent = this.ironSANClient1;
            this.analogBox6.Data = 0D;
            this.analogBox6.DecimalPlace = 1;
            this.analogBox6.Description = "Analog IO";
            this.analogBox6.Exponent = false;
            this.analogBox6.FirstTag = "AO.EEMS-R1.m3Ton_Per_Month";
            this.analogBox6.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox6.ForeColor = System.Drawing.Color.ForestGreen;
            this.analogBox6.Gain = 1D;
            this.analogBox6.GroupSeparator = false;
            this.analogBox6.Location = new System.Drawing.Point(1269, 635);
            this.analogBox6.Max = 999999999;
            this.analogBox6.Min = 0;
            this.analogBox6.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox6.Name = "analogBox6";
            this.analogBox6.Offset = 0D;
            this.analogBox6.Round = false;
            this.analogBox6.SecondTag = "";
            this.analogBox6.Size = new System.Drawing.Size(276, 85);
            this.analogBox6.TabIndex = 189;
            this.analogBox6.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox6.Tags")));
            this.analogBox6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox6.Type = IronControls.IOType.INPUT;
            this.analogBox6.Unit = "";
            this.analogBox6.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox6.UpdateTime = 500;
            // 
            // analogBox4
            // 
            this.analogBox4.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox4.BackColor = System.Drawing.Color.White;
            this.analogBox4.BoxName = "";
            this.analogBox4.CommComponent = this.ironSANClient1;
            this.analogBox4.Data = 0D;
            this.analogBox4.DecimalPlace = 1;
            this.analogBox4.Description = "Analog IO";
            this.analogBox4.Exponent = false;
            this.analogBox4.FirstTag = "AO.EEMS-R1.Put_All_Per_Month";
            this.analogBox4.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox4.Gain = 1D;
            this.analogBox4.GroupSeparator = false;
            this.analogBox4.Location = new System.Drawing.Point(1269, 329);
            this.analogBox4.Max = 999999999;
            this.analogBox4.Min = 0;
            this.analogBox4.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox4.Name = "analogBox4";
            this.analogBox4.Offset = 0D;
            this.analogBox4.Round = false;
            this.analogBox4.SecondTag = "";
            this.analogBox4.Size = new System.Drawing.Size(276, 86);
            this.analogBox4.TabIndex = 190;
            this.analogBox4.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox4.Tags")));
            this.analogBox4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox4.Type = IronControls.IOType.INPUT;
            this.analogBox4.Unit = "";
            this.analogBox4.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox4.UpdateTime = 500;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::SampleScreen.Properties.Resources.생산현황단위제거;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.analogBox37);
            this.panel1.Controls.Add(this.analogBox36);
            this.panel1.Controls.Add(this.analogBox15);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.analogBox14);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.analogBox35);
            this.panel1.Controls.Add(this.analogBox24);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.analogBox18);
            this.panel1.Controls.Add(this.analogBox34);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.analogBox2);
            this.panel1.Controls.Add(this.analogBox33);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.analogBox32);
            this.panel1.Controls.Add(this.analogBox1);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.analogBox4);
            this.panel1.Controls.Add(this.analogBox6);
            this.panel1.Controls.Add(this.analogBox9);
            this.panel1.Controls.Add(this.analogBox12);
            this.panel1.Controls.Add(this.analogBox3);
            this.panel1.Controls.Add(this.analogBox5);
            this.panel1.Controls.Add(this.analogBox8);
            this.panel1.Controls.Add(this.analogBox11);
            this.panel1.Controls.Add(this.analogBox19);
            this.panel1.Controls.Add(this.analogBox13);
            this.panel1.Controls.Add(this.analogBox7);
            this.panel1.Controls.Add(this.analogBox10);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(55, 161);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1737, 735);
            this.panel1.TabIndex = 172;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label23.Location = new System.Drawing.Point(1679, 216);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(44, 101);
            this.label23.TabIndex = 221;
            this.label23.Text = "%";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label24.Location = new System.Drawing.Point(1679, 114);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(44, 93);
            this.label24.TabIndex = 220;
            this.label24.Text = "%";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label22.Location = new System.Drawing.Point(1206, 221);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(44, 93);
            this.label22.TabIndex = 219;
            this.label22.Text = "%";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // analogBox37
            // 
            this.analogBox37.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox37.BackColor = System.Drawing.Color.White;
            this.analogBox37.BoxName = "";
            this.analogBox37.CommComponent = this.ironSANClient1;
            this.analogBox37.Data = 0D;
            this.analogBox37.DecimalPlace = 1;
            this.analogBox37.Description = "Analog IO";
            this.analogBox37.Exponent = false;
            this.analogBox37.FirstTag = "AO.EEMS-R1.Ingot_Per_MonthPe";
            this.analogBox37.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox37.ForeColor = System.Drawing.Color.Teal;
            this.analogBox37.Gain = 1D;
            this.analogBox37.GroupSeparator = false;
            this.analogBox37.Location = new System.Drawing.Point(1532, 220);
            this.analogBox37.Max = 999999999;
            this.analogBox37.Min = 0;
            this.analogBox37.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox37.Name = "analogBox37";
            this.analogBox37.Offset = 0D;
            this.analogBox37.Round = false;
            this.analogBox37.SecondTag = "";
            this.analogBox37.Size = new System.Drawing.Size(147, 88);
            this.analogBox37.TabIndex = 218;
            this.analogBox37.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox37.Tags")));
            this.analogBox37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox37.Type = IronControls.IOType.INPUT;
            this.analogBox37.Unit = "";
            this.analogBox37.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox37.UpdateTime = 500;
            // 
            // analogBox36
            // 
            this.analogBox36.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox36.BackColor = System.Drawing.Color.White;
            this.analogBox36.BoxName = "";
            this.analogBox36.CommComponent = this.ironSANClient1;
            this.analogBox36.Data = 0D;
            this.analogBox36.DecimalPlace = 1;
            this.analogBox36.Description = "Analog IO";
            this.analogBox36.Exponent = false;
            this.analogBox36.FirstTag = "AO.EEMS-R1.Scrap_Per_MonthPe";
            this.analogBox36.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox36.ForeColor = System.Drawing.Color.Teal;
            this.analogBox36.Gain = 1D;
            this.analogBox36.GroupSeparator = false;
            this.analogBox36.Location = new System.Drawing.Point(1532, 116);
            this.analogBox36.Max = 999999999;
            this.analogBox36.Min = 0;
            this.analogBox36.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox36.Name = "analogBox36";
            this.analogBox36.Offset = 0D;
            this.analogBox36.Round = false;
            this.analogBox36.SecondTag = "";
            this.analogBox36.Size = new System.Drawing.Size(147, 88);
            this.analogBox36.TabIndex = 217;
            this.analogBox36.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox36.Tags")));
            this.analogBox36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox36.Type = IronControls.IOType.INPUT;
            this.analogBox36.Unit = "";
            this.analogBox36.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox36.UpdateTime = 500;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label21.Location = new System.Drawing.Point(1465, 220);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(80, 90);
            this.label21.TabIndex = 216;
            this.label21.Text = "Kg";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // analogBox35
            // 
            this.analogBox35.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox35.BackColor = System.Drawing.Color.White;
            this.analogBox35.BoxName = "";
            this.analogBox35.CommComponent = this.ironSANClient1;
            this.analogBox35.Data = 0D;
            this.analogBox35.DecimalPlace = 1;
            this.analogBox35.Description = "Analog IO";
            this.analogBox35.Exponent = false;
            this.analogBox35.FirstTag = "AO.EEMS-R1.Ingot_Per_DayPe";
            this.analogBox35.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox35.ForeColor = System.Drawing.Color.Teal;
            this.analogBox35.Gain = 1D;
            this.analogBox35.GroupSeparator = false;
            this.analogBox35.Location = new System.Drawing.Point(1058, 221);
            this.analogBox35.Max = 999999999;
            this.analogBox35.Min = 0;
            this.analogBox35.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox35.Name = "analogBox35";
            this.analogBox35.Offset = 0D;
            this.analogBox35.Round = false;
            this.analogBox35.SecondTag = "";
            this.analogBox35.Size = new System.Drawing.Size(147, 88);
            this.analogBox35.TabIndex = 214;
            this.analogBox35.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox35.Tags")));
            this.analogBox35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox35.Type = IronControls.IOType.INPUT;
            this.analogBox35.Unit = "";
            this.analogBox35.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox35.UpdateTime = 500;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.Location = new System.Drawing.Point(986, 221);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 90);
            this.label19.TabIndex = 213;
            this.label19.Text = "Kg";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // analogBox34
            // 
            this.analogBox34.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox34.BackColor = System.Drawing.Color.White;
            this.analogBox34.BoxName = "";
            this.analogBox34.CommComponent = this.ironSANClient1;
            this.analogBox34.Data = 0D;
            this.analogBox34.DecimalPlace = 1;
            this.analogBox34.Description = "Analog IO";
            this.analogBox34.Exponent = false;
            this.analogBox34.FirstTag = "AO.EEMS-R1.Scrap_Per_DayPe";
            this.analogBox34.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox34.ForeColor = System.Drawing.Color.Teal;
            this.analogBox34.Gain = 1D;
            this.analogBox34.GroupSeparator = false;
            this.analogBox34.Location = new System.Drawing.Point(1058, 116);
            this.analogBox34.Max = 999999999;
            this.analogBox34.Min = 0;
            this.analogBox34.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox34.Name = "analogBox34";
            this.analogBox34.Offset = 0D;
            this.analogBox34.Round = false;
            this.analogBox34.SecondTag = "";
            this.analogBox34.Size = new System.Drawing.Size(147, 88);
            this.analogBox34.TabIndex = 210;
            this.analogBox34.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox34.Tags")));
            this.analogBox34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox34.Type = IronControls.IOType.INPUT;
            this.analogBox34.Unit = "";
            this.analogBox34.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox34.UpdateTime = 500;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label18.Location = new System.Drawing.Point(1207, 115);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 93);
            this.label18.TabIndex = 212;
            this.label18.Text = "%";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.Location = new System.Drawing.Point(991, 114);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 90);
            this.label17.TabIndex = 211;
            this.label17.Text = "Kg";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // analogBox33
            // 
            this.analogBox33.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox33.BackColor = System.Drawing.Color.White;
            this.analogBox33.BoxName = "";
            this.analogBox33.CommComponent = this.ironSANClient1;
            this.analogBox33.Data = 0D;
            this.analogBox33.DecimalPlace = 1;
            this.analogBox33.Description = "Analog IO";
            this.analogBox33.Exponent = false;
            this.analogBox33.FirstTag = "AO.EEMS-R1.Ingot_Per_HourPe";
            this.analogBox33.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox33.ForeColor = System.Drawing.Color.Teal;
            this.analogBox33.Gain = 1D;
            this.analogBox33.GroupSeparator = false;
            this.analogBox33.Location = new System.Drawing.Point(583, 221);
            this.analogBox33.Max = 999999999;
            this.analogBox33.Min = 0;
            this.analogBox33.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox33.Name = "analogBox33";
            this.analogBox33.Offset = 0D;
            this.analogBox33.Round = false;
            this.analogBox33.SecondTag = "";
            this.analogBox33.Size = new System.Drawing.Size(147, 88);
            this.analogBox33.TabIndex = 207;
            this.analogBox33.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox33.Tags")));
            this.analogBox33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox33.Type = IronControls.IOType.INPUT;
            this.analogBox33.Unit = "";
            this.analogBox33.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox33.UpdateTime = 500;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.Location = new System.Drawing.Point(509, 216);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 101);
            this.label16.TabIndex = 209;
            this.label16.Text = "Kg";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.Location = new System.Drawing.Point(733, 216);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 101);
            this.label15.TabIndex = 208;
            this.label15.Text = "%";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // analogBox32
            // 
            this.analogBox32.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox32.BackColor = System.Drawing.Color.White;
            this.analogBox32.BoxName = "";
            this.analogBox32.CommComponent = this.ironSANClient1;
            this.analogBox32.Data = 0D;
            this.analogBox32.DecimalPlace = 1;
            this.analogBox32.Description = "Analog IO";
            this.analogBox32.Exponent = false;
            this.analogBox32.FirstTag = "AO.EEMS-R1.Scrap_Per_HourPe";
            this.analogBox32.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox32.ForeColor = System.Drawing.Color.Teal;
            this.analogBox32.Gain = 1D;
            this.analogBox32.GroupSeparator = false;
            this.analogBox32.Location = new System.Drawing.Point(583, 116);
            this.analogBox32.Max = 999999999;
            this.analogBox32.Min = 0;
            this.analogBox32.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox32.Name = "analogBox32";
            this.analogBox32.Offset = 0D;
            this.analogBox32.Round = false;
            this.analogBox32.SecondTag = "";
            this.analogBox32.Size = new System.Drawing.Size(147, 88);
            this.analogBox32.TabIndex = 191;
            this.analogBox32.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox32.Tags")));
            this.analogBox32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox32.Type = IronControls.IOType.INPUT;
            this.analogBox32.Unit = "";
            this.analogBox32.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox32.UpdateTime = 500;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(733, 114);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 93);
            this.label14.TabIndex = 206;
            this.label14.Text = "%";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(509, 117);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 90);
            this.label13.TabIndex = 205;
            this.label13.Text = "Kg";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(1547, 326);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(175, 90);
            this.label12.TabIndex = 204;
            this.label12.Text = "Kg";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(1074, 326);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(175, 90);
            this.label11.TabIndex = 203;
            this.label11.Text = "Kg";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(601, 326);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(175, 90);
            this.label10.TabIndex = 202;
            this.label10.Text = "Kg";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(1547, 429);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(175, 90);
            this.label9.TabIndex = 201;
            this.label9.Text = "Kw";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(1074, 429);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(175, 90);
            this.label8.TabIndex = 200;
            this.label8.Text = "Kw";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(601, 429);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 90);
            this.label1.TabIndex = 199;
            this.label1.Text = "Kw";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(1547, 531);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 90);
            this.label7.TabIndex = 198;
            this.label7.Text = "㎥";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(1074, 531);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 90);
            this.label6.TabIndex = 197;
            this.label6.Text = "㎥";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(601, 531);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 90);
            this.label5.TabIndex = 196;
            this.label5.Text = "㎥";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(1547, 633);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 90);
            this.label4.TabIndex = 195;
            this.label4.Text = "㎥/Ton";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(1074, 633);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 90);
            this.label3.TabIndex = 194;
            this.label3.Text = "㎥/Ton";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(601, 633);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 90);
            this.label2.TabIndex = 193;
            this.label2.Text = "㎥/Ton";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Yellow;
            this.textBox1.Font = new System.Drawing.Font("굴림체", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.ForeColor = System.Drawing.Color.Navy;
            this.textBox1.Location = new System.Drawing.Point(1389, 83);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 73);
            this.textBox1.TabIndex = 177;
            this.textBox1.Text = "보온실\r\n온도";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // analogBox23
            // 
            this.analogBox23.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox23.BackColor = System.Drawing.Color.White;
            this.analogBox23.BoxName = "";
            this.analogBox23.CommComponent = this.opcClient2;
            this.analogBox23.Data = 0D;
            this.analogBox23.DecimalPlace = 0;
            this.analogBox23.Description = "Analog IO";
            this.analogBox23.Exponent = false;
            this.analogBox23.FirstTag = "PLC-XGK:D00300";
            this.analogBox23.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox23.ForeColor = System.Drawing.Color.Red;
            this.analogBox23.Gain = 0D;
            this.analogBox23.GroupSeparator = false;
            this.analogBox23.Location = new System.Drawing.Point(1531, 84);
            this.analogBox23.Max = 10000;
            this.analogBox23.Min = 0;
            this.analogBox23.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox23.Name = "analogBox23";
            this.analogBox23.Offset = 0D;
            this.analogBox23.Round = false;
            this.analogBox23.SecondTag = "";
            this.analogBox23.Size = new System.Drawing.Size(255, 73);
            this.analogBox23.TabIndex = 175;
            this.analogBox23.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox23.Tags")));
            this.analogBox23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox23.Type = IronControls.IOType.INPUT;
            this.analogBox23.Unit = "";
            this.analogBox23.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox23.UpdateTime = 500;
            // 
            // analogBox25
            // 
            this.analogBox25.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox25.BackColor = System.Drawing.Color.White;
            this.analogBox25.BoxName = "";
            this.analogBox25.CommComponent = this.opcClient2;
            this.analogBox25.Data = 0D;
            this.analogBox25.DecimalPlace = 0;
            this.analogBox25.Description = "Analog IO";
            this.analogBox25.Exponent = false;
            this.analogBox25.FirstTag = "PLC-XGK:D00310";
            this.analogBox25.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox25.ForeColor = System.Drawing.Color.Red;
            this.analogBox25.Gain = 0D;
            this.analogBox25.GroupSeparator = false;
            this.analogBox25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.analogBox25.Location = new System.Drawing.Point(1531, 7);
            this.analogBox25.Max = 10000;
            this.analogBox25.Min = 0;
            this.analogBox25.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox25.Name = "analogBox25";
            this.analogBox25.Offset = 0D;
            this.analogBox25.Round = false;
            this.analogBox25.SecondTag = "";
            this.analogBox25.Size = new System.Drawing.Size(255, 73);
            this.analogBox25.TabIndex = 174;
            this.analogBox25.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox25.Tags")));
            this.analogBox25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox25.Type = IronControls.IOType.INPUT;
            this.analogBox25.Unit = "";
            this.analogBox25.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox25.UpdateTime = 500;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Yellow;
            this.textBox2.Font = new System.Drawing.Font("굴림체", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox2.ForeColor = System.Drawing.Color.Navy;
            this.textBox2.Location = new System.Drawing.Point(1389, 7);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(130, 73);
            this.textBox2.TabIndex = 179;
            this.textBox2.Text = "타워\r\n온도";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Silver;
            this.panel7.Location = new System.Drawing.Point(1384, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(141, 158);
            this.panel7.TabIndex = 181;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel8.Location = new System.Drawing.Point(1526, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(265, 160);
            this.panel8.TabIndex = 182;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Yellow;
            this.textBox3.Font = new System.Drawing.Font("굴림체", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox3.ForeColor = System.Drawing.Color.Navy;
            this.textBox3.Location = new System.Drawing.Point(64, 8);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(130, 73);
            this.textBox3.TabIndex = 186;
            this.textBox3.Text = "스크랩 무게";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Yellow;
            this.textBox4.Font = new System.Drawing.Font("굴림체", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox4.ForeColor = System.Drawing.Color.Navy;
            this.textBox4.Location = new System.Drawing.Point(64, 84);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(130, 73);
            this.textBox4.TabIndex = 185;
            this.textBox4.Text = "인고트 무게";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Location = new System.Drawing.Point(59, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(141, 158);
            this.panel3.TabIndex = 187;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.analogBox29);
            this.panel4.Controls.Add(this.analogBox28);
            this.panel4.Location = new System.Drawing.Point(201, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(265, 160);
            this.panel4.TabIndex = 188;
            // 
            // analogBox29
            // 
            this.analogBox29.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox29.BackColor = System.Drawing.Color.White;
            this.analogBox29.BoxName = "";
            this.analogBox29.CommComponent = this.opcClient2;
            this.analogBox29.Data = 0D;
            this.analogBox29.DecimalPlace = 1;
            this.analogBox29.Description = "Analog IO";
            this.analogBox29.Exponent = false;
            this.analogBox29.FirstTag = "PLC-XGK:D00624";
            this.analogBox29.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox29.Gain = 0.1D;
            this.analogBox29.GroupSeparator = false;
            this.analogBox29.Location = new System.Drawing.Point(5, 80);
            this.analogBox29.Max = 999999999;
            this.analogBox29.Min = 0;
            this.analogBox29.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox29.Name = "analogBox29";
            this.analogBox29.Offset = 0D;
            this.analogBox29.Round = false;
            this.analogBox29.SecondTag = "";
            this.analogBox29.Size = new System.Drawing.Size(254, 73);
            this.analogBox29.TabIndex = 191;
            this.analogBox29.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox29.Tags")));
            this.analogBox29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox29.Type = IronControls.IOType.INPUT;
            this.analogBox29.Unit = "";
            this.analogBox29.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox29.UpdateTime = 500;
            // 
            // analogBox28
            // 
            this.analogBox28.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox28.BackColor = System.Drawing.Color.White;
            this.analogBox28.BoxName = "";
            this.analogBox28.CommComponent = this.opcClient2;
            this.analogBox28.Data = 0D;
            this.analogBox28.DecimalPlace = 1;
            this.analogBox28.Description = "Analog IO";
            this.analogBox28.Exponent = false;
            this.analogBox28.FirstTag = "PLC-XGK:D00513";
            this.analogBox28.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox28.Gain = 0.1D;
            this.analogBox28.GroupSeparator = false;
            this.analogBox28.Location = new System.Drawing.Point(5, 4);
            this.analogBox28.Max = 999999999;
            this.analogBox28.Min = 0;
            this.analogBox28.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox28.Name = "analogBox28";
            this.analogBox28.Offset = 0D;
            this.analogBox28.Round = false;
            this.analogBox28.SecondTag = "";
            this.analogBox28.Size = new System.Drawing.Size(254, 73);
            this.analogBox28.TabIndex = 191;
            this.analogBox28.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox28.Tags")));
            this.analogBox28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox28.Type = IronControls.IOType.INPUT;
            this.analogBox28.Unit = "";
            this.analogBox28.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox28.UpdateTime = 500;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("휴먼모음T", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label20.Location = new System.Drawing.Point(1465, 115);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 90);
            this.label20.TabIndex = 215;
            this.label20.Text = "Kg";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CurrDataScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
            this.ClientSize = new System.Drawing.Size(1840, 915);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.analogBox23);
            this.Controls.Add(this.analogBox25);
            this.Controls.Add(this.pictureBox28);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel2);
            this.Name = "CurrDataScreen";
            this.Resolution = IronPanel._Resolution.HD1080;
            this.Text = "CurrDataDisplay";
            this.Load += new System.EventHandler(this.CurrDataScreen_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox28)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IronSANAdapter.IronSANClient ironSANClient1;
        private OPCAdapter.OPCClient opcClient1;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button8;
        private IronControls.AnalogBox analogBox22;
        private IronControls.AnalogBox analogBox20;
        private IronControls.AnalogBox analogBox21;
        private IronControls.AnalogBox analogBox30;
        private IronControls.AnalogBox analogBox16;
        private IronControls.AnalogBox analogBox31;
        private IronControls.AnalogBox analogBox17;
        private IronControls.AnalogBox analogBox27;
        private IronControls.AnalogBox analogBox26;
        private System.Windows.Forms.Button button14;
        private OPCAdapter.OPCClient opcClient2;
        private System.Windows.Forms.PictureBox pictureBox28;
        private System.Windows.Forms.Panel panel1;
        private IronControls.AnalogBox analogBox4;
        private IronControls.AnalogBox analogBox6;
        private IronControls.AnalogBox analogBox9;
        private IronControls.AnalogBox analogBox12;
        private IronControls.AnalogBox analogBox14;
        private IronControls.AnalogBox analogBox15;
        private IronControls.AnalogBox analogBox3;
        private IronControls.AnalogBox analogBox5;
        private IronControls.AnalogBox analogBox8;
        private IronControls.AnalogBox analogBox11;
        private IronControls.AnalogBox analogBox18;
        private IronControls.AnalogBox analogBox24;
        private IronControls.AnalogBox analogBox19;
        private IronControls.AnalogBox analogBox13;
        private IronControls.AnalogBox analogBox7;
        private IronControls.AnalogBox analogBox10;
        private IronControls.AnalogBox analogBox1;
        private IronControls.AnalogBox analogBox2;
        private System.Windows.Forms.TextBox textBox1;
        private IronControls.AnalogBox analogBox23;
        private IronControls.AnalogBox analogBox25;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private IronControls.AnalogBox analogBox29;
        private IronControls.AnalogBox analogBox28;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private IronControls.AnalogBox analogBox32;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label22;
        private IronControls.AnalogBox analogBox37;
        private IronControls.AnalogBox analogBox36;
        private System.Windows.Forms.Label label21;
        private IronControls.AnalogBox analogBox35;
        private System.Windows.Forms.Label label19;
        private IronControls.AnalogBox analogBox34;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private IronControls.AnalogBox analogBox33;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label20;

    }
}