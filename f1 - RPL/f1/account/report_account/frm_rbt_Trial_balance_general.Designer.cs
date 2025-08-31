namespace f1.account.report_account
{
    partial class frm_rbt_Trial_balance_general
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_rbt_Trial_balance_general));
            this.dt_piker = new System.Windows.Forms.DateTimePicker();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.rdcustomer = new System.Windows.Forms.RadioButton();
            this.rdvendor = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // dt_piker
            // 
            this.dt_piker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dt_piker.CustomFormat = "yyyy/MM/dd";
            this.dt_piker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_piker.Location = new System.Drawing.Point(89, 12);
            this.dt_piker.Name = "dt_piker";
            this.dt_piker.Size = new System.Drawing.Size(94, 20);
            this.dt_piker.TabIndex = 123;
            this.dt_piker.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Location = new System.Drawing.Point(196, 12);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(49, 13);
            this.labelControl4.TabIndex = 122;
            this.labelControl4.Text = "تاريخ ميزان\r\n";
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(25, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(39, 34);
            this.simpleButton1.TabIndex = 118;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // rdcustomer
            // 
            this.rdcustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdcustomer.AutoSize = true;
            this.rdcustomer.Location = new System.Drawing.Point(178, 54);
            this.rdcustomer.Name = "rdcustomer";
            this.rdcustomer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdcustomer.Size = new System.Drawing.Size(58, 17);
            this.rdcustomer.TabIndex = 149;
            this.rdcustomer.Text = "المطول";
            this.rdcustomer.UseVisualStyleBackColor = true;
            // 
            // rdvendor
            // 
            this.rdvendor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdvendor.AutoSize = true;
            this.rdvendor.Location = new System.Drawing.Point(66, 53);
            this.rdvendor.Name = "rdvendor";
            this.rdvendor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdvendor.Size = new System.Drawing.Size(55, 17);
            this.rdvendor.TabIndex = 148;
            this.rdvendor.Text = "القصير";
            this.rdvendor.UseVisualStyleBackColor = true;
            // 
            // frm_rbt_Trial_balance_general
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 90);
            this.Controls.Add(this.rdcustomer);
            this.Controls.Add(this.rdvendor);
            this.Controls.Add(this.dt_piker);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.simpleButton1);
            this.Name = "frm_rbt_Trial_balance_general";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ميزان مراجعة عام";
            this.Load += new System.EventHandler(this.frm_rbt_Trial_balance_general_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.DateTimePicker dt_piker;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.RadioButton rdcustomer;
        private System.Windows.Forms.RadioButton rdvendor;
    }
}