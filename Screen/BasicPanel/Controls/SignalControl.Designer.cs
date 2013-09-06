namespace BasicPanel
{
    partial class SignalControl
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
            this.components = new System.ComponentModel.Container();
            this.timer_blink = new System.Windows.Forms.Timer(this.components);
            this.pictureBox_red = new System.Windows.Forms.PictureBox();
            this.pictureBox_yellow = new System.Windows.Forms.PictureBox();
            this.pictureBox_blue = new System.Windows.Forms.PictureBox();
            this.timer_red = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_yellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_blue)).BeginInit();
            this.SuspendLayout();
            // 
            // timer_blink
            // 
            this.timer_blink.Interval = 500;
            this.timer_blink.Tick += new System.EventHandler(this.timer_blink_Tick);
            // 
            // pictureBox_red
            // 
            this.pictureBox_red.BackgroundImage = global::BasicPanel.Properties.Resources.SignalTower_red;
            this.pictureBox_red.Location = new System.Drawing.Point(5, 4);
            this.pictureBox_red.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_red.Name = "pictureBox_red";
            this.pictureBox_red.Size = new System.Drawing.Size(47, 20);
            this.pictureBox_red.TabIndex = 0;
            this.pictureBox_red.TabStop = false;
            this.pictureBox_red.Visible = false;
            // 
            // pictureBox_yellow
            // 
            this.pictureBox_yellow.BackgroundImage = global::BasicPanel.Properties.Resources.SignalTower_yellow;
            this.pictureBox_yellow.Location = new System.Drawing.Point(5, 23);
            this.pictureBox_yellow.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_yellow.Name = "pictureBox_yellow";
            this.pictureBox_yellow.Size = new System.Drawing.Size(47, 20);
            this.pictureBox_yellow.TabIndex = 1;
            this.pictureBox_yellow.TabStop = false;
            this.pictureBox_yellow.Visible = false;
            // 
            // pictureBox_blue
            // 
            this.pictureBox_blue.BackgroundImage = global::BasicPanel.Properties.Resources.SignalTower_blue;
            this.pictureBox_blue.Location = new System.Drawing.Point(5, 43);
            this.pictureBox_blue.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_blue.Name = "pictureBox_blue";
            this.pictureBox_blue.Size = new System.Drawing.Size(47, 20);
            this.pictureBox_blue.TabIndex = 2;
            this.pictureBox_blue.TabStop = false;
            this.pictureBox_blue.Visible = false;
            // 
            // timer_red
            // 
            this.timer_red.Interval = 500;
            this.timer_red.Tick += new System.EventHandler(this.timer_red_Tick);
            // 
            // SignalControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::BasicPanel.Properties.Resources.SignalTower;
            this.Controls.Add(this.pictureBox_blue);
            this.Controls.Add(this.pictureBox_yellow);
            this.Controls.Add(this.pictureBox_red);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SignalControl";
            this.Size = new System.Drawing.Size(59, 72);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_yellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_blue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer_blink;
        private System.Windows.Forms.PictureBox pictureBox_red;
        private System.Windows.Forms.PictureBox pictureBox_yellow;
        private System.Windows.Forms.PictureBox pictureBox_blue;
        private System.Windows.Forms.Timer timer_red;
    }
}
