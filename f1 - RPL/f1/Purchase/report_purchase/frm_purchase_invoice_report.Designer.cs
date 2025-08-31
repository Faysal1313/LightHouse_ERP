namespace f1.Purchase.report_purchase
{
    partial class frm_purchase_invoice_report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_purchase_invoice_report));
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.combo_vcs = new System.Windows.Forms.ComboBox();
            this.combo_items = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_code_vcs = new System.Windows.Forms.Label();
            this.rdo_vendor = new System.Windows.Forms.RadioButton();
            this.rdo_customer = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.combo_name = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_to_items = new System.Windows.Forms.TextBox();
            this.txt_from_items = new System.Windows.Forms.TextBox();
            this.dt1 = new System.Windows.Forms.DateTimePicker();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dt2 = new System.Windows.Forms.DateTimePicker();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btn_del = new DevExpress.XtraEditors.SimpleButton();
            this.btn_add1 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_add2 = new DevExpress.XtraEditors.SimpleButton();
            this.ch_all = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ch_all.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(130, 317);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(36, 34);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // combo_vcs
            // 
            this.combo_vcs.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.combo_vcs.FormattingEnabled = true;
            this.combo_vcs.Location = new System.Drawing.Point(130, 43);
            this.combo_vcs.Name = "combo_vcs";
            this.combo_vcs.Size = new System.Drawing.Size(178, 24);
            this.combo_vcs.TabIndex = 1;
            this.combo_vcs.SelectedIndexChanged += new System.EventHandler(this.combo_vcs_SelectedIndexChanged);
            // 
            // combo_items
            // 
            this.combo_items.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.combo_items.FormattingEnabled = true;
            this.combo_items.Location = new System.Drawing.Point(50, 126);
            this.combo_items.Name = "combo_items";
            this.combo_items.Size = new System.Drawing.Size(258, 24);
            this.combo_items.TabIndex = 2;
            this.combo_items.SelectedIndexChanged += new System.EventHandler(this.combo_items_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(314, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "موردين  او عملاء";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(314, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "بحث كود الصنف";
            // 
            // lbl_code_vcs
            // 
            this.lbl_code_vcs.AutoSize = true;
            this.lbl_code_vcs.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_code_vcs.Location = new System.Drawing.Point(127, 67);
            this.lbl_code_vcs.Name = "lbl_code_vcs";
            this.lbl_code_vcs.Size = new System.Drawing.Size(17, 17);
            this.lbl_code_vcs.TabIndex = 5;
            this.lbl_code_vcs.Text = "0";
            // 
            // rdo_vendor
            // 
            this.rdo_vendor.AutoSize = true;
            this.rdo_vendor.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.rdo_vendor.Location = new System.Drawing.Point(203, -1);
            this.rdo_vendor.Name = "rdo_vendor";
            this.rdo_vendor.Size = new System.Drawing.Size(73, 21);
            this.rdo_vendor.TabIndex = 7;
            this.rdo_vendor.TabStop = true;
            this.rdo_vendor.Text = "موردين";
            this.rdo_vendor.UseVisualStyleBackColor = true;
            // 
            // rdo_customer
            // 
            this.rdo_customer.AutoSize = true;
            this.rdo_customer.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.rdo_customer.Location = new System.Drawing.Point(74, -1);
            this.rdo_customer.Name = "rdo_customer";
            this.rdo_customer.Size = new System.Drawing.Size(61, 21);
            this.rdo_customer.TabIndex = 8;
            this.rdo_customer.TabStop = true;
            this.rdo_customer.Text = "عملاء";
            this.rdo_customer.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(314, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "يحث اسم الصنف";
            // 
            // combo_name
            // 
            this.combo_name.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.combo_name.FormattingEnabled = true;
            this.combo_name.Location = new System.Drawing.Point(50, 157);
            this.combo_name.Name = "combo_name";
            this.combo_name.Size = new System.Drawing.Size(258, 24);
            this.combo_name.TabIndex = 10;
            this.combo_name.SelectedIndexChanged += new System.EventHandler(this.combo_name_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(257, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "من كود الصنف";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(76, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "الي كود الصنف";
            // 
            // txt_to_items
            // 
            this.txt_to_items.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txt_to_items.Location = new System.Drawing.Point(236, 282);
            this.txt_to_items.Name = "txt_to_items";
            this.txt_to_items.Size = new System.Drawing.Size(100, 24);
            this.txt_to_items.TabIndex = 13;
            // 
            // txt_from_items
            // 
            this.txt_from_items.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txt_from_items.Location = new System.Drawing.Point(30, 284);
            this.txt_from_items.Name = "txt_from_items";
            this.txt_from_items.Size = new System.Drawing.Size(100, 24);
            this.txt_from_items.TabIndex = 14;
            // 
            // dt1
            // 
            this.dt1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dt1.CustomFormat = "yyyy/MM/dd";
            this.dt1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.dt1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt1.Location = new System.Drawing.Point(203, 86);
            this.dt1.Name = "dt1";
            this.dt1.Size = new System.Drawing.Size(105, 24);
            this.dt1.TabIndex = 118;
            this.dt1.Value = new System.DateTime(2020, 1, 6, 0, 0, 0, 0);
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(342, 86);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(56, 17);
            this.labelControl4.TabIndex = 117;
            this.labelControl4.Text = "من تاريخ";
            // 
            // dt2
            // 
            this.dt2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dt2.CustomFormat = "yyyy/MM/dd";
            this.dt2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.dt2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt2.Location = new System.Drawing.Point(12, 86);
            this.dt2.Name = "dt2";
            this.dt2.Size = new System.Drawing.Size(109, 24);
            this.dt2.TabIndex = 120;
            this.dt2.Value = new System.DateTime(2020, 1, 6, 0, 0, 0, 0);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(127, 87);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 17);
            this.labelControl1.TabIndex = 119;
            this.labelControl1.Text = "الي التاريخ";
            // 
            // btn_del
            // 
            this.btn_del.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_del.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_del.Appearance.Options.UseFont = true;
            this.btn_del.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btn_del.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_del.ImageOptions.Image")));
            this.btn_del.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_del.Location = new System.Drawing.Point(12, 137);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(22, 25);
            this.btn_del.TabIndex = 202;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_add1
            // 
            this.btn_add1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_add1.Appearance.Options.UseFont = true;
            this.btn_add1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btn_add1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add1.ImageOptions.Image")));
            this.btn_add1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_add1.Location = new System.Drawing.Point(146, 281);
            this.btn_add1.Name = "btn_add1";
            this.btn_add1.Size = new System.Drawing.Size(22, 25);
            this.btn_add1.TabIndex = 201;
            this.btn_add1.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_add2
            // 
            this.btn_add2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_add2.Appearance.Options.UseFont = true;
            this.btn_add2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btn_add2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add2.ImageOptions.Image")));
            this.btn_add2.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_add2.Location = new System.Drawing.Point(2, 284);
            this.btn_add2.Name = "btn_add2";
            this.btn_add2.Size = new System.Drawing.Size(22, 25);
            this.btn_add2.TabIndex = 203;
            this.btn_add2.Click += new System.EventHandler(this.btn_add2_Click);
            // 
            // ch_all
            // 
            this.ch_all.Location = new System.Drawing.Point(12, 43);
            this.ch_all.Name = "ch_all";
            this.ch_all.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ch_all.Properties.Appearance.Options.UseFont = true;
            this.ch_all.Properties.Caption = "إظهار الكل";
            this.ch_all.Size = new System.Drawing.Size(88, 21);
            this.ch_all.TabIndex = 204;
            this.ch_all.CheckedChanged += new System.EventHandler(this.ch_all_CheckedChanged);
            // 
            // frm_purchase_invoice_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 363);
            this.Controls.Add(this.ch_all);
            this.Controls.Add(this.btn_add2);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.btn_add1);
            this.Controls.Add(this.dt2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dt1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txt_from_items);
            this.Controls.Add(this.txt_to_items);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.combo_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rdo_customer);
            this.Controls.Add(this.rdo_vendor);
            this.Controls.Add(this.lbl_code_vcs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combo_items);
            this.Controls.Add(this.combo_vcs);
            this.Controls.Add(this.simpleButton1);
            this.Name = "frm_purchase_invoice_report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة الفواتير";
            this.Load += new System.EventHandler(this.frm_purchase_invoice_report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ch_all.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.ComboBox combo_vcs;
        private System.Windows.Forms.ComboBox combo_items;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_code_vcs;
        private System.Windows.Forms.RadioButton rdo_vendor;
        private System.Windows.Forms.RadioButton rdo_customer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox combo_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_to_items;
        private System.Windows.Forms.TextBox txt_from_items;
        private System.Windows.Forms.DateTimePicker dt1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.DateTimePicker dt2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_del;
        private DevExpress.XtraEditors.SimpleButton btn_add1;
        private DevExpress.XtraEditors.SimpleButton btn_add2;
        private DevExpress.XtraEditors.CheckEdit ch_all;
    }
}