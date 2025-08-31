namespace f1.sales.sales_report.sale_forms
{
    partial class frm_rbt_sales_invoice_profit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_rbt_sales_invoice_profit));
            this.combo_wars = new System.Windows.Forms.ComboBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_id_sale_invoice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_id_sale = new System.Windows.Forms.ComboBox();
            this.lbl_code_vcs = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.combo_vcs = new System.Windows.Forms.ComboBox();
            this.dt_piker = new System.Windows.Forms.DateTimePicker();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // combo_wars
            // 
            this.combo_wars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_wars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_wars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combo_wars.FormattingEnabled = true;
            this.combo_wars.Location = new System.Drawing.Point(272, 66);
            this.combo_wars.Name = "combo_wars";
            this.combo_wars.Size = new System.Drawing.Size(89, 21);
            this.combo_wars.TabIndex = 123;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Location = new System.Drawing.Point(388, 74);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 13);
            this.labelControl3.TabIndex = 122;
            this.labelControl3.Text = "رقم المخزن";
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(42, 66);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(40, 39);
            this.simpleButton1.TabIndex = 121;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // lbl_id_sale_invoice
            // 
            this.lbl_id_sale_invoice.AutoSize = true;
            this.lbl_id_sale_invoice.Location = new System.Drawing.Point(200, 12);
            this.lbl_id_sale_invoice.Name = "lbl_id_sale_invoice";
            this.lbl_id_sale_invoice.Size = new System.Drawing.Size(13, 13);
            this.lbl_id_sale_invoice.TabIndex = 120;
            this.lbl_id_sale_invoice.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 119;
            this.label2.Text = " #رقم الفاتوره";
            // 
            // combo_id_sale
            // 
            this.combo_id_sale.FormattingEnabled = true;
            this.combo_id_sale.Location = new System.Drawing.Point(230, 9);
            this.combo_id_sale.Name = "combo_id_sale";
            this.combo_id_sale.Size = new System.Drawing.Size(121, 21);
            this.combo_id_sale.TabIndex = 118;
            // 
            // lbl_code_vcs
            // 
            this.lbl_code_vcs.AutoSize = true;
            this.lbl_code_vcs.Location = new System.Drawing.Point(170, 40);
            this.lbl_code_vcs.Name = "lbl_code_vcs";
            this.lbl_code_vcs.Size = new System.Drawing.Size(13, 13);
            this.lbl_code_vcs.TabIndex = 150;
            this.lbl_code_vcs.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(339, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 149;
            this.label1.Text = "حساب عميل او مورد";
            // 
            // combo_vcs
            // 
            this.combo_vcs.FormattingEnabled = true;
            this.combo_vcs.Location = new System.Drawing.Point(211, 40);
            this.combo_vcs.Name = "combo_vcs";
            this.combo_vcs.Size = new System.Drawing.Size(121, 21);
            this.combo_vcs.TabIndex = 148;
            this.combo_vcs.SelectedIndexChanged += new System.EventHandler(this.combo_vcs_SelectedIndexChanged);
            // 
            // dt_piker
            // 
            this.dt_piker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dt_piker.CustomFormat = "yyyy/MM/dd";
            this.dt_piker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_piker.Location = new System.Drawing.Point(13, 12);
            this.dt_piker.Name = "dt_piker";
            this.dt_piker.Size = new System.Drawing.Size(94, 20);
            this.dt_piker.TabIndex = 152;
            this.dt_piker.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Location = new System.Drawing.Point(120, 12);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 13);
            this.labelControl4.TabIndex = 151;
            this.labelControl4.Text = "تاريخ \r\n";
            // 
            // frm_rbt_sales_invoice_profit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 110);
            this.Controls.Add(this.dt_piker);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.lbl_code_vcs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combo_vcs);
            this.Controls.Add(this.combo_wars);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.lbl_id_sale_invoice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combo_id_sale);
            this.Name = "frm_rbt_sales_invoice_profit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_rbt_sales_invoice_profit";
            this.Load += new System.EventHandler(this.frm_rbt_sales_invoice_profit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combo_wars;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label lbl_id_sale_invoice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_id_sale;
        private System.Windows.Forms.Label lbl_code_vcs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_vcs;
        private System.Windows.Forms.DateTimePicker dt_piker;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}