namespace OperationScreen
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ironSANClient1 = new IronSANAdapter.IronSANClient();
            this.digitalBox1 = new IronControls.DigitalBox();
            this.SuspendLayout();
            // 
            // ironSANClient1
            // 
            this.ironSANClient1.ProjectPath = "";
            this.ironSANClient1.ScriptEnable = false;
            this.ironSANClient1.SynchronizingObject = this;
            // 
            // digitalBox1
            // 
            this.digitalBox1.AccessMode = IronControls.AccessModes.DirectMode;
            this.digitalBox1.BoxName = "";
            this.digitalBox1.CommComponent = this.ironSANClient1;
            this.digitalBox1.Data = -1;
            this.digitalBox1.Description = "Digital IO";
            this.digitalBox1.FirstTag = "DI.TestDriver.DI1";
            this.digitalBox1.font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.digitalBox1.LeftisOn = true;
            this.digitalBox1.Location = new System.Drawing.Point(168, 258);
            this.digitalBox1.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.digitalBox1.Name = "digitalBox1";
            this.digitalBox1.OffColor = System.Drawing.SystemColors.Control;
            this.digitalBox1.OffValue = "Off";
            this.digitalBox1.OnColor = System.Drawing.Color.Lime;
            this.digitalBox1.OnValue = "On";
            this.digitalBox1.SecondTag = "";
            this.digitalBox1.SetData = -1;
            this.digitalBox1.Size = new System.Drawing.Size(244, 78);
            this.digitalBox1.TabIndex = 0;
            this.digitalBox1.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("digitalBox1.Tags")));
            this.digitalBox1.Type = IronControls.IOType.OUTPUT;
            this.digitalBox1.UpdateMode = CommLib.UpdateMode.OnChange;
            this.digitalBox1.UpdateTime = 500;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 469);
            this.Controls.Add(this.digitalBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private IronSANAdapter.IronSANClient ironSANClient1;
        private IronControls.DigitalBox digitalBox1;
    }
}