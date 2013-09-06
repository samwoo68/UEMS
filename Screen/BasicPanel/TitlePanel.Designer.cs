namespace BasicPanel
{
    partial class TitlePanel
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TitlePanel));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.loginControl = new BasicPanel.LoginControl();
            this.alarmControl = new BasicPanel.AlarmControl();
            this.signalControl = new BasicPanel.SignalControl();
            this.equipStatusControl = new BasicPanel.EquipStatusControl();
            this.hostControl = new BasicPanel.HostControl();
            this.timeControl = new BasicPanel.TimeControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::BasicPanel.Properties.Resources.에너지_효율관리_시스템_레드_;
            this.pictureBox1.Location = new System.Drawing.Point(634, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(457, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BasicPanel.Properties.Resources.세아메카닉스_로고3;
            this.pictureBox2.Location = new System.Drawing.Point(3, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(420, 69);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("굴림", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(696, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(544, 48);
            this.label2.TabIndex = 175;
            this.label2.Text = "에너지 효율관리 시스템";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::BasicPanel.Properties.Resources.시계제거;
            this.pictureBox4.Location = new System.Drawing.Point(1757, 16);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(69, 69);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 177;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::BasicPanel.Properties.Resources.시계제거;
            this.pictureBox3.Location = new System.Drawing.Point(1742, 16);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(175, 69);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 178;
            this.pictureBox3.TabStop = false;
            // 
            // loginControl
            // 
            this.loginControl.Authority = "";
            this.loginControl.BackColor = System.Drawing.Color.Transparent;
            this.loginControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loginControl.BackgroundImage")));
            this.loginControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loginControl.Location = new System.Drawing.Point(1378, 13);
            this.loginControl.Name = "loginControl";
            this.loginControl.Size = new System.Drawing.Size(78, 29);
            this.loginControl.TabIndex = 5;
            this.loginControl.UserID = "";
            this.loginControl.LoginClick += new System.EventHandler(this.loginControl_LoginClick);
            // 
            // alarmControl
            // 
            this.alarmControl.AlarmStatus = false;
            this.alarmControl.BackColor = System.Drawing.Color.Transparent;
            this.alarmControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("alarmControl.BackgroundImage")));
            this.alarmControl.ButtonEnabled = false;
            this.alarmControl.Location = new System.Drawing.Point(1459, 16);
            this.alarmControl.Margin = new System.Windows.Forms.Padding(0);
            this.alarmControl.Name = "alarmControl";
            this.alarmControl.Size = new System.Drawing.Size(141, 72);
            this.alarmControl.TabIndex = 4;
            this.alarmControl.ButtonClick += new System.EventHandler(this.alarmControl_ButtonClick);
            // 
            // signalControl
            // 
            this.signalControl.BackColor = System.Drawing.Color.Transparent;
            this.signalControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("signalControl.BackgroundImage")));
            this.signalControl.BlueStatus = BasicPanel.SignalStatus.Off;
            this.signalControl.Location = new System.Drawing.Point(1600, 16);
            this.signalControl.Margin = new System.Windows.Forms.Padding(0);
            this.signalControl.Name = "signalControl";
            this.signalControl.RedStatus = BasicPanel.SignalStatus.Off;
            this.signalControl.Size = new System.Drawing.Size(59, 72);
            this.signalControl.TabIndex = 3;
            this.signalControl.YellowStatus = BasicPanel.SignalStatus.Off;
            // 
            // equipStatusControl
            // 
            this.equipStatusControl.AlarmStatus = false;
            this.equipStatusControl.BackColor = System.Drawing.Color.Transparent;
            this.equipStatusControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("equipStatusControl.BackgroundImage")));
            this.equipStatusControl.ButtonEnabled = false;
            this.equipStatusControl.EquipStatus = "";
            this.equipStatusControl.Location = new System.Drawing.Point(33, 16);
            this.equipStatusControl.Margin = new System.Windows.Forms.Padding(0);
            this.equipStatusControl.Name = "equipStatusControl";
            this.equipStatusControl.Size = new System.Drawing.Size(66, 72);
            this.equipStatusControl.TabIndex = 1;
            // 
            // hostControl
            // 
            this.hostControl.BackColor = System.Drawing.Color.Transparent;
            this.hostControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hostControl.BackgroundImage")));
            this.hostControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hostControl.ButtonEnabled = false;
            this.hostControl.Communication = "";
            this.hostControl.Connection = false;
            this.hostControl.Control = "";
            this.hostControl.Location = new System.Drawing.Point(12, 16);
            this.hostControl.Margin = new System.Windows.Forms.Padding(0);
            this.hostControl.Name = "hostControl";
            this.hostControl.Size = new System.Drawing.Size(53, 72);
            this.hostControl.TabIndex = 0;
            this.hostControl.ButtonClick += new System.EventHandler(this.hostControl_ButtonClick);
            // 
            // timeControl
            // 
            this.timeControl.BackColor = System.Drawing.Color.Transparent;
            this.timeControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("timeControl.BackgroundImage")));
            this.timeControl.Location = new System.Drawing.Point(1742, 16);
            this.timeControl.Margin = new System.Windows.Forms.Padding(0);
            this.timeControl.Name = "timeControl";
            this.timeControl.Size = new System.Drawing.Size(178, 72);
            this.timeControl.TabIndex = 2;
            // 
            // TitlePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.loginControl);
            this.Controls.Add(this.alarmControl);
            this.Controls.Add(this.signalControl);
            this.Controls.Add(this.equipStatusControl);
            this.Controls.Add(this.hostControl);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.timeControl);
            this.Name = "TitlePanel";
            this.ProjectPath = "";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HostControl hostControl;
        private EquipStatusControl equipStatusControl;
        private TimeControl timeControl;
        private SignalControl signalControl;
        private AlarmControl alarmControl;
        private LoginControl loginControl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}
