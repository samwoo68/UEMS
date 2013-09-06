namespace BasicPanel
{
    partial class AlarmControl
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
            this.SuspendLayout();
            // 
            // timer_blink
            // 
            this.timer_blink.Interval = 500;
            this.timer_blink.Tick += new System.EventHandler(this.timer_blink_Tick);
            // 
            // AlarmControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::BasicPanel.Properties.Resources.Alarm_disable;
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AlarmControl";
            this.Size = new System.Drawing.Size(141, 72);
            this.Click += new System.EventHandler(this.StatusButton_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StatusButton_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StatusButton_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer_blink;
    }
}
