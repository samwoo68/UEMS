﻿namespace BasicPanel
{
    partial class TimeControl
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
            this.timer_disp = new System.Windows.Forms.Timer(this.components);
            this.label_time = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer_disp
            // 
            this.timer_disp.Enabled = true;
            this.timer_disp.Interval = 1000;
            this.timer_disp.Tick += new System.EventHandler(this.timer_disp_Tick);
            // 
            // label_time
            // 
            this.label_time.BackColor = System.Drawing.Color.Transparent;
            this.label_time.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_time.Location = new System.Drawing.Point(1, 45);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(173, 16);
            this.label_time.TabIndex = 7;
            this.label_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::BasicPanel.Properties.Resources.DateTime;
            this.Controls.Add(this.label_time);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TimeControl";
            this.Size = new System.Drawing.Size(178, 72);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer_disp;
        private System.Windows.Forms.Label label_time;
    }
}
