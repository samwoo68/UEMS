namespace SampleControls
{
    partial class Trend
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
            this.scatterGraph = new NationalInstruments.UI.WindowsForms.ScatterGraph();
            this.scatterPlot1 = new NationalInstruments.UI.ScatterPlot();
            this.xAxis1 = new NationalInstruments.UI.XAxis();
            this.yAxis1 = new NationalInstruments.UI.YAxis();
            this.scatterPlot2 = new NationalInstruments.UI.ScatterPlot();
            this.scatterPlot3 = new NationalInstruments.UI.ScatterPlot();
            this.scatterPlot4 = new NationalInstruments.UI.ScatterPlot();
            this.scatterPlot5 = new NationalInstruments.UI.ScatterPlot();
            this.scatterPlot6 = new NationalInstruments.UI.ScatterPlot();
            this.scatterPlot7 = new NationalInstruments.UI.ScatterPlot();
            this.scatterPlot8 = new NationalInstruments.UI.ScatterPlot();
            this.scatterPlot9 = new NationalInstruments.UI.ScatterPlot();
            this.scatterPlot10 = new NationalInstruments.UI.ScatterPlot();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button_print = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.propertyEditor2 = new NationalInstruments.UI.WindowsForms.PropertyEditor();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.propertyEditor1 = new NationalInstruments.UI.WindowsForms.PropertyEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.scatterGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scatterGraph
            // 
            this.scatterGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scatterGraph.InteractionMode = ((NationalInstruments.UI.GraphInteractionModes)((((((((NationalInstruments.UI.GraphInteractionModes.ZoomX | NationalInstruments.UI.GraphInteractionModes.ZoomY) 
            | NationalInstruments.UI.GraphInteractionModes.ZoomAroundPoint) 
            | NationalInstruments.UI.GraphInteractionModes.PanX) 
            | NationalInstruments.UI.GraphInteractionModes.PanY) 
            | NationalInstruments.UI.GraphInteractionModes.DragCursor) 
            | NationalInstruments.UI.GraphInteractionModes.DragAnnotationCaption) 
            | NationalInstruments.UI.GraphInteractionModes.EditRange)));
            this.scatterGraph.Location = new System.Drawing.Point(0, 0);
            this.scatterGraph.Name = "scatterGraph";
            this.scatterGraph.Plots.AddRange(new NationalInstruments.UI.ScatterPlot[] {
            this.scatterPlot1,
            this.scatterPlot2,
            this.scatterPlot3,
            this.scatterPlot4,
            this.scatterPlot5,
            this.scatterPlot6,
            this.scatterPlot7,
            this.scatterPlot8,
            this.scatterPlot9,
            this.scatterPlot10});
            this.scatterGraph.Size = new System.Drawing.Size(698, 431);
            this.scatterGraph.TabIndex = 0;
            this.scatterGraph.UseColorGenerator = true;
            this.scatterGraph.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis1});
            this.scatterGraph.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis1});
            this.scatterGraph.ZoomAnimation = false;
            // 
            // scatterPlot1
            // 
            this.scatterPlot1.LineColor = System.Drawing.Color.Lime;
            this.scatterPlot1.LineColorPrecedence = NationalInstruments.UI.ColorPrecedence.UserDefinedColor;
            this.scatterPlot1.ToolTipsEnabled = true;
            this.scatterPlot1.XAxis = this.xAxis1;
            this.scatterPlot1.YAxis = this.yAxis1;
            // 
            // xAxis1
            // 
            this.xAxis1.Caption = "Time";
            this.xAxis1.MajorDivisions.LabelFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.DateTime, "HH:mm:ss");
            this.xAxis1.Mode = NationalInstruments.UI.AxisMode.Fixed;
            this.xAxis1.Range = new NationalInstruments.UI.Range(100D, 150D);
            // 
            // yAxis1
            // 
            this.yAxis1.Mode = NationalInstruments.UI.AxisMode.Fixed;
            // 
            // scatterPlot2
            // 
            this.scatterPlot2.XAxis = this.xAxis1;
            this.scatterPlot2.YAxis = this.yAxis1;
            // 
            // scatterPlot3
            // 
            this.scatterPlot3.XAxis = this.xAxis1;
            this.scatterPlot3.YAxis = this.yAxis1;
            // 
            // scatterPlot4
            // 
            this.scatterPlot4.XAxis = this.xAxis1;
            this.scatterPlot4.YAxis = this.yAxis1;
            // 
            // scatterPlot5
            // 
            this.scatterPlot5.XAxis = this.xAxis1;
            this.scatterPlot5.YAxis = this.yAxis1;
            // 
            // scatterPlot6
            // 
            this.scatterPlot6.XAxis = this.xAxis1;
            this.scatterPlot6.YAxis = this.yAxis1;
            // 
            // scatterPlot7
            // 
            this.scatterPlot7.XAxis = this.xAxis1;
            this.scatterPlot7.YAxis = this.yAxis1;
            // 
            // scatterPlot8
            // 
            this.scatterPlot8.XAxis = this.xAxis1;
            this.scatterPlot8.YAxis = this.yAxis1;
            // 
            // scatterPlot9
            // 
            this.scatterPlot9.XAxis = this.xAxis1;
            this.scatterPlot9.YAxis = this.yAxis1;
            // 
            // scatterPlot10
            // 
            this.scatterPlot10.XAxis = this.xAxis1;
            this.scatterPlot10.YAxis = this.yAxis1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button_print);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.propertyEditor2);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.propertyEditor1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.scatterGraph);
            this.splitContainer1.Size = new System.Drawing.Size(698, 476);
            this.splitContainer1.SplitterDistance = 41;
            this.splitContainer1.TabIndex = 0;
            // 
            // button_print
            // 
            this.button_print.Location = new System.Drawing.Point(3, 10);
            this.button_print.Name = "button_print";
            this.button_print.Size = new System.Drawing.Size(75, 23);
            this.button_print.TabIndex = 26;
            this.button_print.Text = "print";
            this.button_print.UseVisualStyleBackColor = true;
            this.button_print.Click += new System.EventHandler(this.button_print_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "Capacity";
            // 
            // propertyEditor2
            // 
            this.propertyEditor2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.propertyEditor2.Location = new System.Drawing.Point(303, 12);
            this.propertyEditor2.Name = "propertyEditor2";
            this.propertyEditor2.Size = new System.Drawing.Size(47, 21);
            this.propertyEditor2.Source = new NationalInstruments.UI.PropertyEditorSource(this.scatterPlot1, "HistoryCapacity");
            this.propertyEditor2.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dateTimePicker1.CustomFormat = "HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(606, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(89, 21);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.Value = new System.DateTime(1753, 1, 1, 0, 1, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(526, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time Period";
            // 
            // propertyEditor1
            // 
            this.propertyEditor1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.propertyEditor1.Location = new System.Drawing.Point(446, 12);
            this.propertyEditor1.Name = "propertyEditor1";
            this.propertyEditor1.Size = new System.Drawing.Size(74, 21);
            this.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.yAxis1, "Range");
            this.propertyEditor1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(356, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Y-Axis Range";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Trend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "Trend";
            this.Size = new System.Drawing.Size(698, 476);
            this.UpdateMode = CommLib.UpdateMode.Cyclic;
            ((System.ComponentModel.ISupportInitialize)(this.scatterGraph)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NationalInstruments.UI.WindowsForms.ScatterGraph scatterGraph;
        private NationalInstruments.UI.ScatterPlot scatterPlot1;
        private NationalInstruments.UI.XAxis xAxis1;
        private NationalInstruments.UI.YAxis yAxis1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private NationalInstruments.UI.WindowsForms.PropertyEditor propertyEditor1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private NationalInstruments.UI.WindowsForms.PropertyEditor propertyEditor2;
        private NationalInstruments.UI.ScatterPlot scatterPlot2;
        private NationalInstruments.UI.ScatterPlot scatterPlot3;
        private NationalInstruments.UI.ScatterPlot scatterPlot4;
        private NationalInstruments.UI.ScatterPlot scatterPlot5;
        private NationalInstruments.UI.ScatterPlot scatterPlot6;
        private NationalInstruments.UI.ScatterPlot scatterPlot7;
        private NationalInstruments.UI.ScatterPlot scatterPlot8;
        private NationalInstruments.UI.ScatterPlot scatterPlot9;
        private NationalInstruments.UI.ScatterPlot scatterPlot10;
        private System.Windows.Forms.Button button_print;
        private System.Windows.Forms.Timer timer1;
    }
}
