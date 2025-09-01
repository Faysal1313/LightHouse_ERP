namespace f1.account.report_account
{
    partial class frm_rpt_report_acc_statment_vcs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_rpt_report_acc_statment_vcs));
            this.lbl_code_vcs = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.combo_vcs = new System.Windows.Forms.ComboBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dt_piker = new System.Windows.Forms.DateTimePicker();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // lbl_code_vcs
            // 
            this.lbl_code_vcs.AutoSize = true;
            this.lbl_code_vcs.Location = new System.Drawing.Point(21, 9);
            this.lbl_code_vcs.Name = "lbl_code_vcs";
            this.lbl_code_vcs.Size = new System.Drawing.Size(13, 13);
            this.lbl_code_vcs.TabIndex = 147;
            this.lbl_code_vcs.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 146;
            this.label1.Text = "حساب عميل او مورد";
            // 
            // combo_vcs
            // 
            this.combo_vcs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_vcs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_vcs.FormattingEnabled = true;
            this.combo_vcs.Location = new System.Drawing.Point(68, 6);
            this.combo_vcs.Name = "combo_vcs";
            this.combo_vcs.Size = new System.Drawing.Size(121, 21);
            this.combo_vcs.TabIndex = 145;
            this.combo_vcs.SelectedIndexChanged += new System.EventHandler(this.combo_gl_SelectedIndexChanged);
            this.combo_vcs.Click += new System.EventHandler(this.combo_vcs_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(12, 36);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(37, 34);
            this.simpleButton1.TabIndex = 142;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // dt_piker
            // 
            this.dt_piker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dt_piker.CustomFormat = "yyyy/MM/dd";
            this.dt_piker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_piker.Location = new System.Drawing.Point(95, 40);
            this.dt_piker.Name = "dt_piker";
            this.dt_piker.Size = new System.Drawing.Size(94, 20);
            this.dt_piker.TabIndex = 149;
            this.dt_piker.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Location = new System.Drawing.Point(202, 40);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(38, 13);
            this.labelControl4.TabIndex = 148;
            this.labelControl4.Text = "من تاريخ";
            // 
            // frm_rpt_report_acc_statment_vcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 110);
            this.Controls.Add(this.dt_piker);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.lbl_code_vcs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combo_vcs);
            this.Controls.Add(this.simpleButton1);
            this.Name = "frm_rpt_report_acc_statment_vcs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كشف حساب مورد او عميل";
            this.Load += new System.EventHandler(this.frm_rpt_report_acc_statment_vcs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_code_vcs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_vcs;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.DateTimePicker dt_piker;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}