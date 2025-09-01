namespace f1.hr.report_hr
{
    partial class frm_rpt_Action
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_rpt_Action));
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_num = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_items = new System.Windows.Forms.ComboBox();
            this.dt_piker = new System.Windows.Forms.DateTimePicker();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(116, 85);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(39, 34);
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // lbl_num
            // 
            this.lbl_num.AutoSize = true;
            this.lbl_num.Location = new System.Drawing.Point(25, 34);
            this.lbl_num.Name = "lbl_num";
            this.lbl_num.Size = new System.Drawing.Size(13, 13);
            this.lbl_num.TabIndex = 13;
            this.lbl_num.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "اسم المستنخدم";
            // 
            // combo_items
            // 
            this.combo_items.FormattingEnabled = true;
            this.combo_items.Location = new System.Drawing.Point(62, 25);
            this.combo_items.Name = "combo_items";
            this.combo_items.Size = new System.Drawing.Size(121, 21);
            this.combo_items.TabIndex = 11;
            this.combo_items.SelectedIndexChanged += new System.EventHandler(this.combo_items_SelectedIndexChanged);
            // 
            // dt_piker
            // 
            this.dt_piker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dt_piker.CustomFormat = "yyyy/MM/dd";
            this.dt_piker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_piker.Location = new System.Drawing.Point(89, 52);
            this.dt_piker.Name = "dt_piker";
            this.dt_piker.Size = new System.Drawing.Size(94, 20);
            this.dt_piker.TabIndex = 140;
            this.dt_piker.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Location = new System.Drawing.Point(196, 52);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 13);
            this.labelControl4.TabIndex = 139;
            this.labelControl4.Text = "تاريخ \r\n";
            // 
            // frm_rpt_Action
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.dt_piker);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.lbl_num);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combo_items);
            this.Controls.Add(this.simpleButton1);
            this.Name = "frm_rpt_Action";
            this.Text = "frm_rpt_Action";
            this.Load += new System.EventHandler(this.frm_rpt_Action_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label lbl_num;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_items;
        private System.Windows.Forms.DateTimePicker dt_piker;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}