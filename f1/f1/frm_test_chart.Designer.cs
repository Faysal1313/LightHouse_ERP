namespace f1
{
    partial class frm_test_chart
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.dtt = new f1.dtt();
            this.dttBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dttBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // chartControl1
            // 
            this.chartControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.chartControl1.DataSource = this.dttBindingSource;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            series1.ArgumentDataMember = "entry.depit";
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
            series1.Name = "Series 1";
            series1.ValueDataMembersSerializable = "entry.dates";
            series1.ValueScaleType = DevExpress.XtraCharts.ScaleType.DateTime;
            series2.ArgumentDataMember = "entry.credit";
            series2.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
            series2.Name = "Series 2";
            series2.ValueDataMembersSerializable = "entry.dates";
            series2.ValueScaleType = DevExpress.XtraCharts.ScaleType.DateTime;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.chartControl1.Size = new System.Drawing.Size(732, 437);
            this.chartControl1.TabIndex = 0;
            // 
            // dtt
            // 
            this.dtt.DataSetName = "dtt";
            this.dtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dttBindingSource
            // 
            this.dttBindingSource.DataSource = this.dtt;
            this.dttBindingSource.Position = 0;
            // 
            // frm_test_chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 437);
            this.Controls.Add(this.chartControl1);
            this.Name = "frm_test_chart";
            this.Text = "frm_test_chart";
            this.Load += new System.EventHandler(this.frm_test_chart_Load);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dttBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.BindingSource dttBindingSource;
        private dtt dtt;
    }
}