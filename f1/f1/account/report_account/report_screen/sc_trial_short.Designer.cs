
namespace f1.account.report_account.report_screen
{
    partial class sc_trial_short
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sc_trial_short));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.txt_f_currance = new System.Windows.Forms.TextBox();
            this.btn_currance = new DevExpress.XtraEditors.SimpleButton();
            this.combo_currance = new System.Windows.Forms.ComboBox();
            this.lbl_currance = new DevExpress.XtraEditors.LabelControl();
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btn_printer = new DevExpress.XtraEditors.SimpleButton();
            this.btn_get_Data = new DevExpress.XtraEditors.SimpleButton();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doc_id = new System.Windows.Forms.DataGridViewLinkColumn();
            this.imp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dep_bal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cr_bal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_tot = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.doc_id,
            this.imp,
            this.Column1,
            this.Column2,
            this.dep_bal,
            this.cr_bal,
            this.dep,
            this.cr,
            this.Column3});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgv.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv.Location = new System.Drawing.Point(2, 65);
            this.dgv.Name = "dgv";
            this.dgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv.RowHeadersWidth = 21;
            this.dgv.Size = new System.Drawing.Size(931, 429);
            this.dgv.TabIndex = 221;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_RowsAdded);
            this.dgv.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgv_RowsRemoved);
            // 
            // txt_f_currance
            // 
            this.txt_f_currance.Location = new System.Drawing.Point(260, 0);
            this.txt_f_currance.Name = "txt_f_currance";
            this.txt_f_currance.Size = new System.Drawing.Size(54, 20);
            this.txt_f_currance.TabIndex = 239;
            this.txt_f_currance.Visible = false;
            // 
            // btn_currance
            // 
            this.btn_currance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_currance.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btn_currance.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_currance.ImageOptions.Image")));
            this.btn_currance.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_currance.Location = new System.Drawing.Point(227, -2);
            this.btn_currance.Name = "btn_currance";
            this.btn_currance.Size = new System.Drawing.Size(22, 25);
            this.btn_currance.TabIndex = 236;
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
            this.combo_currance.Location = new System.Drawing.Point(320, 0);
            this.combo_currance.Name = "combo_currance";
            this.combo_currance.Size = new System.Drawing.Size(87, 21);
            this.combo_currance.TabIndex = 238;
            this.combo_currance.Visible = false;
            // 
            // lbl_currance
            // 
            this.lbl_currance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_currance.Location = new System.Drawing.Point(412, 4);
            this.lbl_currance.Name = "lbl_currance";
            this.lbl_currance.Size = new System.Drawing.Size(29, 13);
            this.lbl_currance.TabIndex = 237;
            this.lbl_currance.Text = "العمله";
            this.lbl_currance.Visible = false;
            // 
            // date2
            // 
            this.date2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.date2.CustomFormat = "yyyy/MM/dd";
            this.date2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.date2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date2.Location = new System.Drawing.Point(515, 3);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(106, 24);
            this.date2.TabIndex = 235;
            this.date2.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(637, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 17);
            this.labelControl1.TabIndex = 234;
            this.labelControl1.Text = "الي تاريخ";
            // 
            // date1
            // 
            this.date1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.date1.CustomFormat = "yyyy/MM/dd";
            this.date1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.date1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date1.Location = new System.Drawing.Point(712, 3);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(101, 24);
            this.date1.TabIndex = 233;
            this.date1.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(819, 6);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(56, 17);
            this.labelControl4.TabIndex = 232;
            this.labelControl4.Text = "من تاريخ";
            // 
            // btn_printer
            // 
            this.btn_printer.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_printer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_printer.ImageOptions.Image")));
            this.btn_printer.Location = new System.Drawing.Point(29, 1);
            this.btn_printer.Name = "btn_printer";
            this.btn_printer.Size = new System.Drawing.Size(37, 34);
            this.btn_printer.TabIndex = 241;
            this.btn_printer.Text = "simpleButton2";
            this.btn_printer.Click += new System.EventHandler(this.btn_printer_Click);
            // 
            // btn_get_Data
            // 
            this.btn_get_Data.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_get_Data.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_get_Data.ImageOptions.Image")));
            this.btn_get_Data.Location = new System.Drawing.Point(98, 0);
            this.btn_get_Data.Name = "btn_get_Data";
            this.btn_get_Data.Size = new System.Drawing.Size(37, 34);
            this.btn_get_Data.TabIndex = 240;
            this.btn_get_Data.Text = "simpleButton1";
            this.btn_get_Data.Click += new System.EventHandler(this.btn_get_Data_Click);
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
            this.imp.HeaderText = "اسم الحساب";
            this.imp.Name = "imp";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "نوع الحساب";
            this.Column2.Name = "Column2";
            // 
            // dep_bal
            // 
            this.dep_bal.DataPropertyName = "vcs_name";
            this.dep_bal.HeaderText = "الحركة المدينة";
            this.dep_bal.Name = "dep_bal";
            // 
            // cr_bal
            // 
            this.cr_bal.HeaderText = "الحركة الدائنة";
            this.cr_bal.Name = "cr_bal";
            // 
            // dep
            // 
            this.dep.HeaderText = "رصيد مدين";
            this.dep.Name = "dep";
            // 
            // cr
            // 
            this.cr.DataPropertyName = "item_price";
            this.cr.FillWeight = 89.65739F;
            this.cr.HeaderText = "رصيد دائن";
            this.cr.Name = "cr";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "رصيد";
            this.Column3.Name = "Column3";
            // 
            // lbl_tot
            // 
            this.lbl_tot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_tot.Location = new System.Drawing.Point(60, 46);
            this.lbl_tot.Name = "lbl_tot";
            this.lbl_tot.Size = new System.Drawing.Size(6, 13);
            this.lbl_tot.TabIndex = 243;
            this.lbl_tot.Text = "0";
            // 
            // sc_trial_short
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 496);
            this.Controls.Add(this.lbl_tot);
            this.Controls.Add(this.btn_printer);
            this.Controls.Add(this.btn_get_Data);
            this.Controls.Add(this.txt_f_currance);
            this.Controls.Add(this.btn_currance);
            this.Controls.Add(this.combo_currance);
            this.Controls.Add(this.lbl_currance);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.date1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.dgv);
            this.Name = "sc_trial_short";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ميزان مراجعة مختصر";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox txt_f_currance;
        private DevExpress.XtraEditors.SimpleButton btn_currance;
        private System.Windows.Forms.ComboBox combo_currance;
        private DevExpress.XtraEditors.LabelControl lbl_currance;
        private System.Windows.Forms.DateTimePicker date2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.DateTimePicker date1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btn_printer;
        private DevExpress.XtraEditors.SimpleButton btn_get_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewLinkColumn doc_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn imp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dep_bal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cr_bal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dep;
        private System.Windows.Forms.DataGridViewTextBoxColumn cr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private DevExpress.XtraEditors.LabelControl lbl_tot;
    }
}