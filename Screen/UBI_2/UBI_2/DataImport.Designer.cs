namespace UBI_2
{
    partial class DataImport
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
            this.Part_Imp_Info_bt = new System.Windows.Forms.Button();
            this.PartTree_Imp_Info_bt = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.CodeConvert_bt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Part_Imp_Info_bt
            // 
            this.Part_Imp_Info_bt.Enabled = false;
            this.Part_Imp_Info_bt.Location = new System.Drawing.Point(12, 12);
            this.Part_Imp_Info_bt.Name = "Part_Imp_Info_bt";
            this.Part_Imp_Info_bt.Size = new System.Drawing.Size(239, 58);
            this.Part_Imp_Info_bt.TabIndex = 0;
            this.Part_Imp_Info_bt.Text = "부품정보 -> 정보";
            this.Part_Imp_Info_bt.UseVisualStyleBackColor = true;
            this.Part_Imp_Info_bt.Click += new System.EventHandler(this.Part_Imp_Info_bt_Click);
            // 
            // PartTree_Imp_Info_bt
            // 
            this.PartTree_Imp_Info_bt.Enabled = false;
            this.PartTree_Imp_Info_bt.Location = new System.Drawing.Point(12, 76);
            this.PartTree_Imp_Info_bt.Name = "PartTree_Imp_Info_bt";
            this.PartTree_Imp_Info_bt.Size = new System.Drawing.Size(239, 58);
            this.PartTree_Imp_Info_bt.TabIndex = 1;
            this.PartTree_Imp_Info_bt.Text = "부품트리 -> 정보Info";
            this.PartTree_Imp_Info_bt.UseVisualStyleBackColor = true;
            this.PartTree_Imp_Info_bt.Click += new System.EventHandler(this.PartTree_Imp_Info_bt_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(12, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(239, 58);
            this.button1.TabIndex = 2;
            this.button1.Text = "부품정보 <- 부품";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CodeConvert_bt
            // 
            this.CodeConvert_bt.Location = new System.Drawing.Point(12, 204);
            this.CodeConvert_bt.Name = "CodeConvert_bt";
            this.CodeConvert_bt.Size = new System.Drawing.Size(239, 58);
            this.CodeConvert_bt.TabIndex = 3;
            this.CodeConvert_bt.Text = "정보 Code 변환";
            this.CodeConvert_bt.UseVisualStyleBackColor = true;
            this.CodeConvert_bt.Click += new System.EventHandler(this.CodeConvert_bt_Click);
            // 
            // DataImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 345);
            this.Controls.Add(this.CodeConvert_bt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PartTree_Imp_Info_bt);
            this.Controls.Add(this.Part_Imp_Info_bt);
            this.Name = "DataImport";
            this.Text = "DataImport";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Part_Imp_Info_bt;
        private System.Windows.Forms.Button PartTree_Imp_Info_bt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button CodeConvert_bt;
    }
}