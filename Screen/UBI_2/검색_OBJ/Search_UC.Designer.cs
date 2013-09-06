namespace 검색_OBJ
{
    partial class Search_UC
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
            this.DT월 = new System.Windows.Forms.DateTimePicker();
            this.CB일 = new System.Windows.Forms.CheckBox();
            this.CB월 = new System.Windows.Forms.CheckBox();
            this.PNBar = new System.Windows.Forms.Panel();
            this.검색GB = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DTE일 = new System.Windows.Forms.DateTimePicker();
            this.DTS일 = new System.Windows.Forms.DateTimePicker();
            this.TB작성자 = new System.Windows.Forms.TextBox();
            this.CB작성자 = new System.Windows.Forms.CheckBox();
            this.검색GB.SuspendLayout();
            this.SuspendLayout();
            // 
            // DT월
            // 
            this.DT월.Location = new System.Drawing.Point(119, 64);
            this.DT월.Name = "DT월";
            this.DT월.Size = new System.Drawing.Size(177, 21);
            this.DT월.TabIndex = 8;
            // 
            // CB일
            // 
            this.CB일.AutoSize = true;
            this.CB일.Location = new System.Drawing.Point(10, 99);
            this.CB일.Name = "CB일";
            this.CB일.Size = new System.Drawing.Size(94, 16);
            this.CB일.TabIndex = 7;
            this.CB일.Text = "작성기간(일)";
            this.CB일.UseVisualStyleBackColor = true;
            // 
            // CB월
            // 
            this.CB월.AutoSize = true;
            this.CB월.Location = new System.Drawing.Point(9, 67);
            this.CB월.Name = "CB월";
            this.CB월.Size = new System.Drawing.Size(94, 16);
            this.CB월.TabIndex = 6;
            this.CB월.Text = "작성기간(월)";
            this.CB월.UseVisualStyleBackColor = true;
            // 
            // PNBar
            // 
            this.PNBar.BackColor = System.Drawing.Color.Silver;
            this.PNBar.Location = new System.Drawing.Point(10, 47);
            this.PNBar.Name = "PNBar";
            this.PNBar.Size = new System.Drawing.Size(497, 11);
            this.PNBar.TabIndex = 2;
            // 
            // 검색GB
            // 
            this.검색GB.Controls.Add(this.label1);
            this.검색GB.Controls.Add(this.DTE일);
            this.검색GB.Controls.Add(this.DTS일);
            this.검색GB.Controls.Add(this.DT월);
            this.검색GB.Controls.Add(this.CB일);
            this.검색GB.Controls.Add(this.CB월);
            this.검색GB.Controls.Add(this.PNBar);
            this.검색GB.Controls.Add(this.TB작성자);
            this.검색GB.Controls.Add(this.CB작성자);
            this.검색GB.Location = new System.Drawing.Point(0, 0);
            this.검색GB.Name = "검색GB";
            this.검색GB.Size = new System.Drawing.Size(520, 130);
            this.검색GB.TabIndex = 1;
            this.검색GB.TabStop = false;
            this.검색GB.Text = "검색";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "~";
            // 
            // DTE일
            // 
            this.DTE일.Location = new System.Drawing.Point(322, 96);
            this.DTE일.Name = "DTE일";
            this.DTE일.Size = new System.Drawing.Size(177, 21);
            this.DTE일.TabIndex = 10;
            // 
            // DTS일
            // 
            this.DTS일.Location = new System.Drawing.Point(119, 94);
            this.DTS일.Name = "DTS일";
            this.DTS일.Size = new System.Drawing.Size(177, 21);
            this.DTS일.TabIndex = 9;
            // 
            // TB작성자
            // 
            this.TB작성자.Location = new System.Drawing.Point(119, 16);
            this.TB작성자.Name = "TB작성자";
            this.TB작성자.Size = new System.Drawing.Size(152, 21);
            this.TB작성자.TabIndex = 1;
            // 
            // CB작성자
            // 
            this.CB작성자.AutoSize = true;
            this.CB작성자.Location = new System.Drawing.Point(10, 18);
            this.CB작성자.Name = "CB작성자";
            this.CB작성자.Size = new System.Drawing.Size(92, 16);
            this.CB작성자.TabIndex = 0;
            this.CB작성자.Text = "작    성    자";
            this.CB작성자.UseVisualStyleBackColor = true;
            // 
            // Where_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.검색GB);
            this.Name = "Where_Search";
            this.Size = new System.Drawing.Size(529, 136);
            this.검색GB.ResumeLayout(false);
            this.검색GB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DT월;
        private System.Windows.Forms.CheckBox CB일;
        private System.Windows.Forms.CheckBox CB월;
        private System.Windows.Forms.Panel PNBar;
        private System.Windows.Forms.GroupBox 검색GB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTE일;
        private System.Windows.Forms.DateTimePicker DTS일;
        private System.Windows.Forms.TextBox TB작성자;
        private System.Windows.Forms.CheckBox CB작성자;
    }
}
