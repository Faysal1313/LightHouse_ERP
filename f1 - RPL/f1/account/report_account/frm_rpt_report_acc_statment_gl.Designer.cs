
namespace f1.account.report_account
{
    partial class frm_rpt_report_acc_statment_gl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_rpt_report_acc_statment_gl));
            this.dt_piker2 = new System.Windows.Forms.DateTimePicker();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dt_piker = new System.Windows.Forms.DateTimePicker();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_code_vcs = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.combo_vcs = new System.Windows.Forms.ComboBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // dt_piker2
            // 
            this.dt_piker2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dt_piker2.CustomFormat = "yyyy/MM/dd";
            this.dt_piker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_piker2.Location = new System.Drawing.Point(165, 75);
            this.dt_piker2.Name = "dt_piker2";
            this.dt_piker2.Size = new System.Drawing.Size(94, 20);
            this.dt_piker2.TabIndex = 159;
            this.dt_piker2.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dt_piker2.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(269, 75);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 13);
            this.labelControl1.TabIndex = 158;
            this.labelControl1.Text = "الي تاريخ";
            this.labelControl1.Visible = false;
            // 
            // dt_piker
            // 
            this.dt_piker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dt_piker.CustomFormat = "yyyy/MM/dd";
            this.dt_piker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_piker.Location = new System.Drawing.Point(165, 45);
            this.dt_piker.Name = "dt_piker";
            this.dt_piker.Size = new System.Drawing.Size(94, 20);
            this.dt_piker.TabIndex = 157;
            this.dt_piker.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Location = new System.Drawing.Point(272, 45);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 13);
            this.labelControl4.TabIndex = 156;
            this.labelControl4.Text = " تاريخ";
            // 
            // lbl_code_vcs
            // 
            this.lbl_code_vcs.AutoSize = true;
            this.lbl_code_vcs.Location = new System.Drawing.Point(30, 0);
            this.lbl_code_vcs.Name = "lbl_code_vcs";
            this.lbl_code_vcs.Size = new System.Drawing.Size(13, 13);
            this.lbl_code_vcs.TabIndex = 155;
            this.lbl_code_vcs.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 154;
            this.label1.Text = "اسم الحساب";
            // 
            // combo_vcs
            // 
            this.combo_vcs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_vcs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_vcs.FormattingEnabled = true;
            this.combo_vcs.Location = new System.Drawing.Point(82, 11);
            this.combo_vcs.Name = "combo_vcs";
            this.combo_vcs.Size = new System.Drawing.Size(269, 21);
            this.combo_vcs.TabIndex = 153;
            this.combo_vcs.SelectedIndexChanged += new System.EventHandler(this.combo_vcs_SelectedIndexChanged);
            this.combo_vcs.Click += new System.EventHandler(this.combo_vcs_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(82, 41);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(37, 34);
            this.simpleButton1.TabIndex = 152;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frm_rpt_report_acc_statment_gl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 107);
            this.Controls.Add(this.dt_piker2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dt_piker);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.lbl_code_vcs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combo_vcs);
            this.Controls.Add(this.simpleButton1);
            this.Name = "frm_rpt_report_acc_statment_gl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كشف حساب ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dt_piker2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.DateTimePicker dt_piker;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.Label lbl_code_vcs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_vcs;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}