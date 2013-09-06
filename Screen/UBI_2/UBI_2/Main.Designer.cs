namespace UBI_2
{
    partial class Main
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
            this.label양식 = new System.Windows.Forms.Label();
            this.Input_bt = new System.Windows.Forms.Button();
            this.DeleteP_bt = new System.Windows.Forms.Button();
            this.Node_DeleteP_bt = new System.Windows.Forms.Button();
            this.Node_In_bt = new System.Windows.Forms.Button();
            this.DataImport_bt = new System.Windows.Forms.Button();
            this.PSearch_bt = new System.Windows.Forms.Button();
            this.CSearch_bt = new System.Windows.Forms.Button();
            this.Node_DeleteC_bt = new System.Windows.Forms.Button();
            this.DeleteC_bt = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.stlV_UCC = new TLV_OBJ.STLV_UC();
            this.stlV_UCP = new TLV_OBJ.STLV_UC();
            this.SuspendLayout();
            // 
            // label양식
            // 
            this.label양식.Location = new System.Drawing.Point(38, 42);
            this.label양식.Name = "label양식";
            this.label양식.Size = new System.Drawing.Size(1162, 23);
            this.label양식.TabIndex = 242;
            this.label양식.Text = "정보관리대장 ";
            this.label양식.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Input_bt
            // 
            this.Input_bt.Location = new System.Drawing.Point(33, 773);
            this.Input_bt.Name = "Input_bt";
            this.Input_bt.Size = new System.Drawing.Size(110, 36);
            this.Input_bt.TabIndex = 258;
            this.Input_bt.Text = "입력";
            this.Input_bt.UseVisualStyleBackColor = true;
            this.Input_bt.Click += new System.EventHandler(this.Input_bt_Click);
            // 
            // DeleteP_bt
            // 
            this.DeleteP_bt.Location = new System.Drawing.Point(381, 773);
            this.DeleteP_bt.Name = "DeleteP_bt";
            this.DeleteP_bt.Size = new System.Drawing.Size(110, 36);
            this.DeleteP_bt.TabIndex = 259;
            this.DeleteP_bt.Text = "삭제";
            this.DeleteP_bt.UseVisualStyleBackColor = true;
            this.DeleteP_bt.Click += new System.EventHandler(this.DeleteP_bt_Click);
            // 
            // Node_DeleteP_bt
            // 
            this.Node_DeleteP_bt.Location = new System.Drawing.Point(497, 773);
            this.Node_DeleteP_bt.Name = "Node_DeleteP_bt";
            this.Node_DeleteP_bt.Size = new System.Drawing.Size(110, 36);
            this.Node_DeleteP_bt.TabIndex = 260;
            this.Node_DeleteP_bt.Text = "노드 삭제";
            this.Node_DeleteP_bt.UseVisualStyleBackColor = true;
            this.Node_DeleteP_bt.Click += new System.EventHandler(this.Node_DeleteP_bt_Click);
            // 
            // Node_In_bt
            // 
            this.Node_In_bt.Location = new System.Drawing.Point(149, 773);
            this.Node_In_bt.Name = "Node_In_bt";
            this.Node_In_bt.Size = new System.Drawing.Size(110, 36);
            this.Node_In_bt.TabIndex = 261;
            this.Node_In_bt.Text = "삽입";
            this.Node_In_bt.UseVisualStyleBackColor = true;
            this.Node_In_bt.Click += new System.EventHandler(this.Node_In_bt_Click);
            // 
            // DataImport_bt
            // 
            this.DataImport_bt.Location = new System.Drawing.Point(1156, 786);
            this.DataImport_bt.Name = "DataImport_bt";
            this.DataImport_bt.Size = new System.Drawing.Size(110, 36);
            this.DataImport_bt.TabIndex = 262;
            this.DataImport_bt.Text = "Data Import";
            this.DataImport_bt.UseVisualStyleBackColor = true;
            this.DataImport_bt.Click += new System.EventHandler(this.DataImport_bt_Click);
            // 
            // PSearch_bt
            // 
            this.PSearch_bt.Location = new System.Drawing.Point(265, 773);
            this.PSearch_bt.Name = "PSearch_bt";
            this.PSearch_bt.Size = new System.Drawing.Size(110, 36);
            this.PSearch_bt.TabIndex = 263;
            this.PSearch_bt.Text = "검색";
            this.PSearch_bt.UseVisualStyleBackColor = true;
            this.PSearch_bt.Click += new System.EventHandler(this.PSearch_bt_Click);
            // 
            // CSearch_bt
            // 
            this.CSearch_bt.Location = new System.Drawing.Point(852, 773);
            this.CSearch_bt.Name = "CSearch_bt";
            this.CSearch_bt.Size = new System.Drawing.Size(110, 36);
            this.CSearch_bt.TabIndex = 264;
            this.CSearch_bt.Text = "검색";
            this.CSearch_bt.UseVisualStyleBackColor = true;
            this.CSearch_bt.Click += new System.EventHandler(this.CSearch_bt_Click);
            // 
            // Node_DeleteC_bt
            // 
            this.Node_DeleteC_bt.Location = new System.Drawing.Point(1084, 773);
            this.Node_DeleteC_bt.Name = "Node_DeleteC_bt";
            this.Node_DeleteC_bt.Size = new System.Drawing.Size(110, 36);
            this.Node_DeleteC_bt.TabIndex = 268;
            this.Node_DeleteC_bt.Text = "노드 삭제";
            this.Node_DeleteC_bt.UseVisualStyleBackColor = true;
            this.Node_DeleteC_bt.Click += new System.EventHandler(this.Node_DeleteC_bt_Click);
            // 
            // DeleteC_bt
            // 
            this.DeleteC_bt.Location = new System.Drawing.Point(968, 773);
            this.DeleteC_bt.Name = "DeleteC_bt";
            this.DeleteC_bt.Size = new System.Drawing.Size(110, 36);
            this.DeleteC_bt.TabIndex = 267;
            this.DeleteC_bt.Text = "삭제";
            this.DeleteC_bt.UseVisualStyleBackColor = true;
            this.DeleteC_bt.Click += new System.EventHandler(this.DeleteC_bt_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1208, 756);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 24);
            this.button1.TabIndex = 269;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // stlV_UCC
            // 
            this.stlV_UCC.Location = new System.Drawing.Point(613, 100);
            this.stlV_UCC.Name = "stlV_UCC";
            this.stlV_UCC.Size = new System.Drawing.Size(581, 664);
            this.stlV_UCC.TabIndex = 266;
            // 
            // stlV_UCP
            // 
            this.stlV_UCP.Location = new System.Drawing.Point(33, 100);
            this.stlV_UCP.Name = "stlV_UCP";
            this.stlV_UCP.Size = new System.Drawing.Size(574, 667);
            this.stlV_UCP.TabIndex = 265;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 821);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Node_DeleteC_bt);
            this.Controls.Add(this.DeleteC_bt);
            this.Controls.Add(this.stlV_UCC);
            this.Controls.Add(this.stlV_UCP);
            this.Controls.Add(this.CSearch_bt);
            this.Controls.Add(this.PSearch_bt);
            this.Controls.Add(this.DataImport_bt);
            this.Controls.Add(this.Node_In_bt);
            this.Controls.Add(this.Node_DeleteP_bt);
            this.Controls.Add(this.DeleteP_bt);
            this.Controls.Add(this.Input_bt);
            this.Controls.Add(this.label양식);
            this.Name = "Main";
            this.Text = "정보";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label양식;
        private System.Windows.Forms.Button Input_bt;
        private System.Windows.Forms.Button DeleteP_bt;
        private System.Windows.Forms.Button Node_DeleteP_bt;
        private System.Windows.Forms.Button Node_In_bt;
        private System.Windows.Forms.Button DataImport_bt;
        private System.Windows.Forms.Button PSearch_bt;
        private System.Windows.Forms.Button CSearch_bt;
        private TLV_OBJ.STLV_UC stlV_UCP;
        private TLV_OBJ.STLV_UC stlV_UCC;
        private System.Windows.Forms.Button Node_DeleteC_bt;
        private System.Windows.Forms.Button DeleteC_bt;
        private System.Windows.Forms.Button button1;
        
       

    }
}

