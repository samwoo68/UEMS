namespace OperationScreen
{
    partial class OperationScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperationScreen));
            this.ironSANClient1 = new IronSANAdapter.IronSANClient();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ledOnly4 = new LedOnly.LedOnly();
            this.opcClient1 = new OPCAdapter.OPCClient();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.ledOnly1 = new LedOnly.LedOnly();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ironSANClient1
            // 
            this.ironSANClient1.ProjectPath = "";
            this.ironSANClient1.ScriptEnable = false;
            this.ironSANClient1.SynchronizingObject = this;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::OperationScreen.Properties.Resources.세아조립;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(105, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1011, 729);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // ledOnly4
            // 
            this.ledOnly4.AccessMode = IronControls.AccessModes.DirectMode;
            this.ledOnly4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ledOnly4.BackColor = System.Drawing.Color.Transparent;
            this.ledOnly4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ledOnly4.CommComponent = this.opcClient1;
            this.ledOnly4.FirstTag = "Channel1.EEMS-R1.M551";
            this.ledOnly4.Location = new System.Drawing.Point(421, 344);
            this.ledOnly4.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.ledOnly4.Name = "ledOnly4";
            this.ledOnly4.SecondTag = "";
            this.ledOnly4.Size = new System.Drawing.Size(40, 39);
            this.ledOnly4.TabIndex = 20;
            this.ledOnly4.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("ledOnly4.Tags")));
            this.ledOnly4.UpdateMode = CommLib.UpdateMode.OnChange;
            this.ledOnly4.UpdateTime = 500;
            this.ledOnly4.Load += new System.EventHandler(this.ledOnly4_Load);
            // 
            // opcClient1
            // 
            this.opcClient1.Group = "MyGroup";
            this.opcClient1.Server = "KEPWare.KEPServerEx.V4";
            this.opcClient1.SynchronizingObject = this;
            this.opcClient1.Topic = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(637, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 49);
            this.button1.TabIndex = 22;
            this.button1.Text = "mdb생성하기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(646, 244);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 55);
            this.button2.TabIndex = 23;
            this.button2.Text = "Table생성하기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(646, 344);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 55);
            this.button3.TabIndex = 24;
            this.button3.Text = "Table삭제하기";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ledOnly1
            // 
            this.ledOnly1.AccessMode = IronControls.AccessModes.DirectMode;
            this.ledOnly1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ledOnly1.BackColor = System.Drawing.Color.Transparent;
            this.ledOnly1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ledOnly1.CommComponent = this.opcClient1;
            this.ledOnly1.FirstTag = "Channel1.EEMS-R1.M551";
            this.ledOnly1.Location = new System.Drawing.Point(495, 344);
            this.ledOnly1.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.ledOnly1.Name = "ledOnly1";
            this.ledOnly1.SecondTag = "";
            this.ledOnly1.Size = new System.Drawing.Size(40, 39);
            this.ledOnly1.TabIndex = 25;
            this.ledOnly1.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("ledOnly1.Tags")));
            this.ledOnly1.UpdateMode = CommLib.UpdateMode.OnChange;
            this.ledOnly1.UpdateTime = 500;
            // 
            // TrainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1200, 859);
            this.Controls.Add(this.ledOnly1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ledOnly4);
            this.Controls.Add(this.pictureBox1);
            this.Name = "TrainScreen";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.TrainScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IronSANAdapter.IronSANClient ironSANClient1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private LedOnly.LedOnly ledOnly4;
        private OPCAdapter.OPCClient opcClient1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private LedOnly.LedOnly ledOnly1;
    }
}