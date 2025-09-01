
namespace f1.account.report_account
{
    partial class frm_rpt_costcenter_statment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_rpt_costcenter_statment));
            this.dt_piker2 = new System.Windows.Forms.DateTimePicker();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dt_piker = new System.Windows.Forms.DateTimePicker();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_costcenter = new System.Windows.Forms.Label();
            this.combo_costcenter = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dt_piker2
            // 
            this.dt_piker2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dt_piker2.CustomFormat = "yyyy/MM/dd";
            this.dt_piker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_piker2.Location = new System.Drawing.Point(161, 76);
            this.dt_piker2.Name = "dt_piker2";
            this.dt_piker2.Size = new System.Drawing.Size(94, 20);
            this.dt_piker2.TabIndex = 167;
            this.dt_piker2.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(265, 76);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 13);
            this.labelControl1.TabIndex = 166;
            this.labelControl1.Text = "الي تاريخ";
            // 
            // dt_piker
            // 
            this.dt_piker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dt_piker.CustomFormat = "yyyy/MM/dd";
            this.dt_piker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_piker.Location = new System.Drawing.Point(161, 46);
            this.dt_piker.Name = "dt_piker";
            this.dt_piker.Size = new System.Drawing.Size(94, 20);
            this.dt_piker.TabIndex = 165;
            this.dt_piker.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Location = new System.Drawing.Point(268, 46);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 13);
            this.labelControl4.TabIndex = 164;
            this.labelControl4.Text = " تاريخ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 162;
            this.label1.Text = "اسم مركز التكلفة";
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(78, 42);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(37, 34);
            this.simpleButton1.TabIndex = 160;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // lbl_costcenter
            // 
            this.lbl_costcenter.AutoSize = true;
            this.lbl_costcenter.Location = new System.Drawing.Point(105, 12);
            this.lbl_costcenter.Name = "lbl_costcenter";
            this.lbl_costcenter.Size = new System.Drawing.Size(54, 13);
            this.lbl_costcenter.TabIndex = 170;
            this.lbl_costcenter.Text = "costcener";
            // 
            // combo_costcenter
            // 
            this.combo_costcenter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.combo_costcenter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_costcenter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_costcenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_costcenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combo_costcenter.FormattingEnabled = true;
            this.combo_costcenter.Items.AddRange(new object[] {
            "asd",
            "asd",
            "asd",
            "asd",
            "as",
            "d"});
            this.combo_costcenter.Location = new System.Drawing.Point(212, 9);
            this.combo_costcenter.Name = "combo_costcenter";
            this.combo_costcenter.Size = new System.Drawing.Size(102, 21);
            this.combo_costcenter.TabIndex = 168;
            this.combo_costcenter.SelectedIndexChanged += new System.EventHandler(this.combo_costcenter_SelectedIndexChanged);
            // 
            // frm_rpt_costcenter_statment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 109);
            this.Controls.Add(this.lbl_costcenter);
            this.Controls.Add(this.combo_costcenter);
            this.Controls.Add(this.dt_piker2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dt_piker);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.simpleButton1);
            this.Name = "frm_rpt_costcenter_statment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مركز تكلفة";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dt_piker2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.DateTimePicker dt_piker;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label lbl_costcenter;
        private System.Windows.Forms.ComboBox combo_costcenter;
    }
}