
namespace f1
{
    partial class frm_search
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
            this.Date1 = new System.Windows.Forms.DateTimePicker();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.combo_name = new System.Windows.Forms.ComboBox();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.lbl_date1 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_date2 = new DevExpress.XtraEditors.LabelControl();
            this.Date2 = new System.Windows.Forms.DateTimePicker();
            this.combo_code = new System.Windows.Forms.ComboBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.chk_rest = new System.Windows.Forms.CheckBox();
            this.lbl_type_items = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.combo_type_items = new System.Windows.Forms.ComboBox();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Date1
            // 
            this.Date1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Date1.CalendarFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Date1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Date1.CustomFormat = "yyyy/MM/dd";
            this.Date1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Date1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Date1.Location = new System.Drawing.Point(615, 107);
            this.Date1.Name = "Date1";
            this.Date1.Size = new System.Drawing.Size(119, 24);
            this.Date1.TabIndex = 129;
            this.Date1.Value = new System.DateTime(2020, 1, 6, 0, 0, 0, 0);
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(751, 30);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(38, 17);
            this.labelControl10.TabIndex = 130;
            this.labelControl10.Text = ":الكود";
            // 
            // combo_name
            // 
            this.combo_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_name.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.combo_name.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.combo_name.FormattingEnabled = true;
            this.combo_name.Location = new System.Drawing.Point(12, 65);
            this.combo_name.Name = "combo_name";
            this.combo_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.combo_name.Size = new System.Drawing.Size(722, 24);
            this.combo_name.TabIndex = 131;
            this.combo_name.TextChanged += new System.EventHandler(this.combo_name_TextChanged);
            // 
            // txt_code
            // 
            this.txt_code.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txt_code.Location = new System.Drawing.Point(12, 140);
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new System.Drawing.Size(722, 24);
            this.txt_code.TabIndex = 128;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(751, 72);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 17);
            this.labelControl1.TabIndex = 133;
            this.labelControl1.Text = ":الاسم";
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txt_name.Location = new System.Drawing.Point(12, 170);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(722, 24);
            this.txt_name.TabIndex = 132;
            // 
            // lbl_date1
            // 
            this.lbl_date1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_date1.Appearance.Options.UseFont = true;
            this.lbl_date1.Location = new System.Drawing.Point(751, 113);
            this.lbl_date1.Name = "lbl_date1";
            this.lbl_date1.Size = new System.Drawing.Size(61, 17);
            this.lbl_date1.TabIndex = 134;
            this.lbl_date1.Text = ":من تاريخ";
            // 
            // lbl_date2
            // 
            this.lbl_date2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_date2.Appearance.Options.UseFont = true;
            this.lbl_date2.Location = new System.Drawing.Point(528, 113);
            this.lbl_date2.Name = "lbl_date2";
            this.lbl_date2.Size = new System.Drawing.Size(66, 17);
            this.lbl_date2.TabIndex = 136;
            this.lbl_date2.Text = ":الي تاريخ";
            // 
            // Date2
            // 
            this.Date2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Date2.CalendarFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Date2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Date2.CustomFormat = "yyyy/MM/dd";
            this.Date2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Date2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Date2.Location = new System.Drawing.Point(389, 107);
            this.Date2.Name = "Date2";
            this.Date2.Size = new System.Drawing.Size(119, 24);
            this.Date2.TabIndex = 135;
            this.Date2.Value = new System.DateTime(2020, 1, 6, 0, 0, 0, 0);
            // 
            // combo_code
            // 
            this.combo_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_code.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.combo_code.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.combo_code.FormattingEnabled = true;
            this.combo_code.Location = new System.Drawing.Point(12, 27);
            this.combo_code.Name = "combo_code";
            this.combo_code.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.combo_code.Size = new System.Drawing.Size(722, 24);
            this.combo_code.TabIndex = 137;
            this.combo_code.TextChanged += new System.EventHandler(this.combo_code_TextChanged);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
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
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgv.Location = new System.Drawing.Point(12, 209);
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
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(821, 244);
            this.dgv.TabIndex = 138;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_RowsAdded);
            this.dgv.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgv_RowsRemoved);
            // 
            // chk_rest
            // 
            this.chk_rest.AutoSize = true;
            this.chk_rest.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chk_rest.Location = new System.Drawing.Point(245, 108);
            this.chk_rest.Name = "chk_rest";
            this.chk_rest.Size = new System.Drawing.Size(127, 21);
            this.chk_rest.TabIndex = 139;
            this.chk_rest.Text = "اصناف المطاعم";
            this.chk_rest.UseVisualStyleBackColor = true;
            // 
            // lbl_type_items
            // 
            this.lbl_type_items.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_type_items.Appearance.Options.UseFont = true;
            this.lbl_type_items.Location = new System.Drawing.Point(27, 5);
            this.lbl_type_items.Name = "lbl_type_items";
            this.lbl_type_items.Size = new System.Drawing.Size(8, 16);
            this.lbl_type_items.TabIndex = 142;
            this.lbl_type_items.Text = "1";
            this.lbl_type_items.Visible = false;
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Location = new System.Drawing.Point(148, 107);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(70, 17);
            this.labelControl15.TabIndex = 141;
            this.labelControl15.Text = "نوع الصنف";
            this.labelControl15.Visible = false;
            // 
            // combo_type_items
            // 
            this.combo_type_items.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_type_items.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combo_type_items.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.combo_type_items.FormattingEnabled = true;
            this.combo_type_items.Items.AddRange(new object[] {
            "مخزون",
            "خدمي"});
            this.combo_type_items.Location = new System.Drawing.Point(12, 105);
            this.combo_type_items.Name = "combo_type_items";
            this.combo_type_items.Size = new System.Drawing.Size(121, 24);
            this.combo_type_items.TabIndex = 140;
            this.combo_type_items.Visible = false;
            this.combo_type_items.SelectedIndexChanged += new System.EventHandler(this.combo_type_items_SelectedIndexChanged);
            // 
            // no
            // 
            this.no.HeaderText = "Column1";
            this.no.Name = "no";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Column7";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Column8";
            this.Column8.Name = "Column8";
            // 
            // frm_search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 470);
            this.Controls.Add(this.lbl_type_items);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.combo_type_items);
            this.Controls.Add(this.chk_rest);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.combo_code);
            this.Controls.Add(this.lbl_date2);
            this.Controls.Add(this.Date2);
            this.Controls.Add(this.lbl_date1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.Date1);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.combo_name);
            this.Controls.Add(this.txt_code);
            this.Name = "frm_search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بحث";
            this.Load += new System.EventHandler(this.frm_search_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker Date1;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private System.Windows.Forms.ComboBox combo_name;
        private System.Windows.Forms.TextBox txt_code;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox txt_name;
        private DevExpress.XtraEditors.LabelControl lbl_date1;
        private DevExpress.XtraEditors.LabelControl lbl_date2;
        private System.Windows.Forms.DateTimePicker Date2;
        private System.Windows.Forms.ComboBox combo_code;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.CheckBox chk_rest;
        private DevExpress.XtraEditors.LabelControl lbl_type_items;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private System.Windows.Forms.ComboBox combo_type_items;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}