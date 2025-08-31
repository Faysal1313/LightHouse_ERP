
namespace f1.account.report_account.report_screen
{
    partial class sc_statment_gl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sc_statment_gl));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doc_id = new System.Windows.Forms.DataGridViewLinkColumn();
            this.imp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bal_c = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tot_c = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdcustomer = new System.Windows.Forms.RadioButton();
            this.rdvendor = new System.Windows.Forms.RadioButton();
            this.rd_account = new System.Windows.Forms.RadioButton();
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txt_f_currance = new System.Windows.Forms.TextBox();
            this.btn_currance = new DevExpress.XtraEditors.SimpleButton();
            this.combo_currance = new System.Windows.Forms.ComboBox();
            this.lbl_currance = new DevExpress.XtraEditors.LabelControl();
            this.lbl_code = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.combo = new System.Windows.Forms.ComboBox();
            this.btn_get_Data = new DevExpress.XtraEditors.SimpleButton();
            this.btn_printer = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.doc_id,
            this.imp,
            this.Column2,
            this.exp,
            this.bal_c,
            this.item_price,
            this.tot_c,
            this.dataGridViewTextBoxColumn9,
            this.Column6,
            this.Column3,
            this.Column1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv.Location = new System.Drawing.Point(2, 87);
            this.dgv.Name = "dgv";
            this.dgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.RowHeadersWidth = 21;
            this.dgv.Size = new System.Drawing.Size(831, 366);
            this.dgv.TabIndex = 220;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_RowsAdded);
            this.dgv.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgv_RowsRemoved);
            // 
            // no
            // 
            this.no.FillWeight = 40.96023F;
            this.no.HeaderText = "م";
            this.no.Name = "no";
            // 
            // doc_id
            // 
            this.doc_id.DataPropertyName = "no_inv";
            this.doc_id.FillWeight = 89.65739F;
            this.doc_id.HeaderText = "رقم القيد";
            this.doc_id.Name = "doc_id";
            this.doc_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.doc_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // imp
            // 
            this.imp.HeaderText = "رقم السند";
            this.imp.Name = "imp";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "vcs_name";
            this.Column2.HeaderText = "الشرح";
            this.Column2.Name = "Column2";
            // 
            // exp
            // 
            this.exp.HeaderText = "كود الحساب";
            this.exp.Name = "exp";
            // 
            // bal_c
            // 
            this.bal_c.HeaderText = "اسم الحساب";
            this.bal_c.Name = "bal_c";
            // 
            // item_price
            // 
            this.item_price.DataPropertyName = "item_price";
            this.item_price.FillWeight = 89.65739F;
            this.item_price.HeaderText = "رصيد افتتاحي";
            this.item_price.Name = "item_price";
            // 
            // tot_c
            // 
            this.tot_c.DataPropertyName = "incloud_taxes";
            this.tot_c.FillWeight = 89.65739F;
            this.tot_c.HeaderText = "مدين";
            this.tot_c.Name = "tot_c";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "date";
            this.dataGridViewTextBoxColumn9.HeaderText = "دائن";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "time";
            this.Column6.HeaderText = "الرصيد";
            this.Column6.Name = "Column6";
            this.Column6.Visible = false;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "الرصيد";
            this.Column3.Name = "Column3";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "vcs_code";
            this.Column1.HeaderText = "التاريخ";
            this.Column1.Name = "Column1";
            // 
            // rdcustomer
            // 
            this.rdcustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdcustomer.AutoSize = true;
            this.rdcustomer.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.rdcustomer.Location = new System.Drawing.Point(765, 11);
            this.rdcustomer.Name = "rdcustomer";
            this.rdcustomer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdcustomer.Size = new System.Drawing.Size(61, 21);
            this.rdcustomer.TabIndex = 223;
            this.rdcustomer.Text = "عملاء";
            this.rdcustomer.UseVisualStyleBackColor = true;
            this.rdcustomer.CheckedChanged += new System.EventHandler(this.rdcustomer_CheckedChanged);
            // 
            // rdvendor
            // 
            this.rdvendor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdvendor.AutoSize = true;
            this.rdvendor.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.rdvendor.Location = new System.Drawing.Point(684, 10);
            this.rdvendor.Name = "rdvendor";
            this.rdvendor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdvendor.Size = new System.Drawing.Size(73, 21);
            this.rdvendor.TabIndex = 222;
            this.rdvendor.Text = "موردين\r\n";
            this.rdvendor.UseVisualStyleBackColor = true;
            this.rdvendor.CheckedChanged += new System.EventHandler(this.rdvendor_CheckedChanged);
            // 
            // rd_account
            // 
            this.rd_account.AutoSize = true;
            this.rd_account.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.rd_account.Location = new System.Drawing.Point(603, 9);
            this.rd_account.Name = "rd_account";
            this.rd_account.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rd_account.Size = new System.Drawing.Size(71, 21);
            this.rd_account.TabIndex = 221;
            this.rd_account.TabStop = true;
            this.rd_account.Text = "حساب";
            this.rd_account.UseVisualStyleBackColor = true;
            this.rd_account.CheckedChanged += new System.EventHandler(this.rd_account_CheckedChanged);
            // 
            // date2
            // 
            this.date2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.date2.CustomFormat = "yyyy/MM/dd";
            this.date2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.date2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date2.Location = new System.Drawing.Point(240, 9);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(101, 24);
            this.date2.TabIndex = 227;
            this.date2.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(346, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 17);
            this.labelControl1.TabIndex = 226;
            this.labelControl1.Text = "الي تاريخ";
            // 
            // date1
            // 
            this.date1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.date1.CustomFormat = "yyyy/MM/dd";
            this.date1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.date1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date1.Location = new System.Drawing.Point(417, 9);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(102, 24);
            this.date1.TabIndex = 225;
            this.date1.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(525, 13);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 17);
            this.labelControl4.TabIndex = 224;
            this.labelControl4.Text = " من تاريخ";
            // 
            // txt_f_currance
            // 
            this.txt_f_currance.Location = new System.Drawing.Point(45, 11);
            this.txt_f_currance.Name = "txt_f_currance";
            this.txt_f_currance.Size = new System.Drawing.Size(54, 20);
            this.txt_f_currance.TabIndex = 231;
            this.txt_f_currance.Visible = false;
            // 
            // btn_currance
            // 
            this.btn_currance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_currance.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btn_currance.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_currance.ImageOptions.Image")));
            this.btn_currance.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_currance.Location = new System.Drawing.Point(12, 9);
            this.btn_currance.Name = "btn_currance";
            this.btn_currance.Size = new System.Drawing.Size(22, 25);
            this.btn_currance.TabIndex = 228;
            this.btn_currance.Visible = false;
            // 
            // combo_currance
            // 
            this.combo_currance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.combo_currance.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_currance.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_currance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_currance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combo_currance.FormattingEnabled = true;
            this.combo_currance.Items.AddRange(new object[] {
            "asd",
            "asd",
            "asd",
            "asd",
            "as",
            "d"});
            this.combo_currance.Location = new System.Drawing.Point(105, 11);
            this.combo_currance.Name = "combo_currance";
            this.combo_currance.Size = new System.Drawing.Size(87, 21);
            this.combo_currance.TabIndex = 230;
            this.combo_currance.Visible = false;
            // 
            // lbl_currance
            // 
            this.lbl_currance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_currance.Location = new System.Drawing.Point(197, 15);
            this.lbl_currance.Name = "lbl_currance";
            this.lbl_currance.Size = new System.Drawing.Size(29, 13);
            this.lbl_currance.TabIndex = 229;
            this.lbl_currance.Text = "العمله";
            this.lbl_currance.Visible = false;
            // 
            // lbl_code
            // 
            this.lbl_code.AutoSize = true;
            this.lbl_code.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_code.Location = new System.Drawing.Point(374, 50);
            this.lbl_code.Name = "lbl_code";
            this.lbl_code.Size = new System.Drawing.Size(17, 17);
            this.lbl_code.TabIndex = 234;
            this.lbl_code.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(741, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 233;
            this.label1.Text = "اسم الحساب";
            // 
            // combo
            // 
            this.combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.combo.FormattingEnabled = true;
            this.combo.Location = new System.Drawing.Point(462, 47);
            this.combo.Name = "combo";
            this.combo.Size = new System.Drawing.Size(269, 24);
            this.combo.TabIndex = 232;
            this.combo.SelectedIndexChanged += new System.EventHandler(this.combo_SelectedIndexChanged);
            // 
            // btn_get_Data
            // 
            this.btn_get_Data.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_get_Data.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_get_Data.ImageOptions.Image")));
            this.btn_get_Data.Location = new System.Drawing.Point(131, 46);
            this.btn_get_Data.Name = "btn_get_Data";
            this.btn_get_Data.Size = new System.Drawing.Size(37, 34);
            this.btn_get_Data.TabIndex = 235;
            this.btn_get_Data.Text = "simpleButton1";
            this.btn_get_Data.Click += new System.EventHandler(this.btn_get_Data_Click);
            // 
            // btn_printer
            // 
            this.btn_printer.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_printer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_printer.ImageOptions.Image")));
            this.btn_printer.Location = new System.Drawing.Point(62, 47);
            this.btn_printer.Name = "btn_printer";
            this.btn_printer.Size = new System.Drawing.Size(37, 34);
            this.btn_printer.TabIndex = 236;
            this.btn_printer.Text = "simpleButton2";
            this.btn_printer.Click += new System.EventHandler(this.btn_printer_Click);
            // 
            // sc_statment_gl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 455);
            this.Controls.Add(this.btn_printer);
            this.Controls.Add(this.btn_get_Data);
            this.Controls.Add(this.lbl_code);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combo);
            this.Controls.Add(this.txt_f_currance);
            this.Controls.Add(this.btn_currance);
            this.Controls.Add(this.combo_currance);
            this.Controls.Add(this.lbl_currance);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.date1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.rdcustomer);
            this.Controls.Add(this.rdvendor);
            this.Controls.Add(this.rd_account);
            this.Controls.Add(this.dgv);
            this.Name = "sc_statment_gl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كشف حساب او عمبل او مورد";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        public System.Windows.Forms.RadioButton rdvendor;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.TextBox txt_f_currance;
        private DevExpress.XtraEditors.SimpleButton btn_currance;
        private System.Windows.Forms.ComboBox combo_currance;
        private DevExpress.XtraEditors.LabelControl lbl_currance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo;
        private DevExpress.XtraEditors.SimpleButton btn_printer;
        public System.Windows.Forms.DateTimePicker date2;
        public System.Windows.Forms.DateTimePicker date1;
        public System.Windows.Forms.Label lbl_code;
        public DevExpress.XtraEditors.SimpleButton btn_get_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewLinkColumn doc_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn imp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn exp;
        private System.Windows.Forms.DataGridViewTextBoxColumn bal_c;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn tot_c;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        public System.Windows.Forms.RadioButton rdcustomer;
        public System.Windows.Forms.RadioButton rd_account;
    }
}