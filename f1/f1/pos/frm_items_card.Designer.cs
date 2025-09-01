namespace f1.pos
{
    partial class frm_items_card
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_items_card));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_del = new DevExpress.XtraEditors.SimpleButton();
            this.btn_search_items = new DevExpress.XtraEditors.SimpleButton();
            this.combo_code_items = new System.Windows.Forms.ComboBox();
            this.combo_name_items = new System.Windows.Forms.ComboBox();
            this.lbl_code_items = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_serchinv = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_bal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvc = new System.Windows.Forms.DataGridView();
            this.no3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doc_id = new System.Windows.Forms.DataGridViewLinkColumn();
            this.imp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bal_c = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tot_c = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_unite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty_c = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.combo_wars = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_imp = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_exp = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.btn_printer = new DevExpress.XtraEditors.SimpleButton();
            this.compo_unite = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvc)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_del
            // 
            this.btn_del.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_del.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btn_del.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_del.ImageOptions.Image")));
            this.btn_del.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_del.Location = new System.Drawing.Point(392, 18);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(22, 25);
            this.btn_del.TabIndex = 208;
            this.btn_del.Click += new System.EventHandler(this.Btn_del_Click);
            // 
            // btn_search_items
            // 
            this.btn_search_items.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_search_items.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_search_items.ImageOptions.Image")));
            this.btn_search_items.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_search_items.Location = new System.Drawing.Point(743, 18);
            this.btn_search_items.Name = "btn_search_items";
            this.btn_search_items.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_search_items.Size = new System.Drawing.Size(22, 25);
            this.btn_search_items.TabIndex = 206;
            this.btn_search_items.ToolTip = "بحث رقم الوردية";
            this.btn_search_items.Click += new System.EventHandler(this.Btn_search_items_Click);
            // 
            // combo_code_items
            // 
            this.combo_code_items.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_code_items.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_code_items.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_code_items.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.combo_code_items.FormattingEnabled = true;
            this.combo_code_items.Location = new System.Drawing.Point(420, 8);
            this.combo_code_items.Name = "combo_code_items";
            this.combo_code_items.Size = new System.Drawing.Size(317, 21);
            this.combo_code_items.TabIndex = 205;
            this.combo_code_items.SelectedIndexChanged += new System.EventHandler(this.Combo_code_items_SelectedIndexChanged);
            this.combo_code_items.TextChanged += new System.EventHandler(this.combo_code_items_TextChanged);
            // 
            // combo_name_items
            // 
            this.combo_name_items.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_name_items.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_name_items.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_name_items.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.combo_name_items.FormattingEnabled = true;
            this.combo_name_items.Location = new System.Drawing.Point(420, 35);
            this.combo_name_items.Name = "combo_name_items";
            this.combo_name_items.Size = new System.Drawing.Size(317, 21);
            this.combo_name_items.TabIndex = 204;
            this.combo_name_items.SelectedIndexChanged += new System.EventHandler(this.Combo_name_items_SelectedIndexChanged);
            // 
            // lbl_code_items
            // 
            this.lbl_code_items.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_code_items.AutoSize = true;
            this.lbl_code_items.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_code_items.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lbl_code_items.ForeColor = System.Drawing.Color.Blue;
            this.lbl_code_items.Location = new System.Drawing.Point(775, 5);
            this.lbl_code_items.Name = "lbl_code_items";
            this.lbl_code_items.Size = new System.Drawing.Size(79, 17);
            this.lbl_code_items.TabIndex = 203;
            this.lbl_code_items.Text = "كود الصنف";
            this.lbl_code_items.Click += new System.EventHandler(this.lbl_code_items_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(770, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 202;
            this.label2.Text = "اسم الصنف";
            // 
            // btn_serchinv
            // 
            this.btn_serchinv.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_serchinv.Appearance.Options.UseFont = true;
            this.btn_serchinv.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_serchinv.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_serchinv.ImageOptions.SvgImage")));
            this.btn_serchinv.Location = new System.Drawing.Point(89, 18);
            this.btn_serchinv.Name = "btn_serchinv";
            this.btn_serchinv.Size = new System.Drawing.Size(98, 38);
            this.btn_serchinv.TabIndex = 210;
            this.btn_serchinv.Text = "بحث";
            this.btn_serchinv.Click += new System.EventHandler(this.Btn_serchinv_Click);
            // 
            // lbl_bal
            // 
            this.lbl_bal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_bal.AutoSize = true;
            this.lbl_bal.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lbl_bal.ForeColor = System.Drawing.Color.Red;
            this.lbl_bal.Location = new System.Drawing.Point(157, 115);
            this.lbl_bal.Name = "lbl_bal";
            this.lbl_bal.Size = new System.Drawing.Size(17, 17);
            this.lbl_bal.TabIndex = 217;
            this.lbl_bal.Text = "0";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(216, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 17);
            this.label8.TabIndex = 218;
            this.label8.Text = "الرصيد";
            // 
            // dgvc
            // 
            this.dgvc.AllowUserToAddRows = false;
            this.dgvc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvc.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no3,
            this.doc_id,
            this.imp,
            this.exp,
            this.bal_c,
            this.item_price,
            this.tot_c,
            this.dataGridViewTextBoxColumn9,
            this.Column6,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.name_unite,
            this.qty_c,
            this.no,
            this.Column5});
            this.dgvc.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvc.Location = new System.Drawing.Point(2, 147);
            this.dgvc.Name = "dgvc";
            this.dgvc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvc.Size = new System.Drawing.Size(868, 366);
            this.dgvc.TabIndex = 219;
            this.dgvc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvc_CellClick);
            this.dgvc.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.Dgvc_RowsAdded);
            // 
            // no3
            // 
            this.no3.FillWeight = 40.96023F;
            this.no3.HeaderText = "م";
            this.no3.Name = "no3";
            // 
            // doc_id
            // 
            this.doc_id.DataPropertyName = "no_inv";
            this.doc_id.FillWeight = 89.65739F;
            this.doc_id.HeaderText = "رقم السند";
            this.doc_id.Name = "doc_id";
            this.doc_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.doc_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // imp
            // 
            this.imp.HeaderText = "وارد";
            this.imp.Name = "imp";
            // 
            // exp
            // 
            this.exp.HeaderText = "صادر";
            this.exp.Name = "exp";
            // 
            // bal_c
            // 
            this.bal_c.HeaderText = "رصيد";
            this.bal_c.Name = "bal_c";
            // 
            // item_price
            // 
            this.item_price.DataPropertyName = "item_price";
            this.item_price.FillWeight = 89.65739F;
            this.item_price.HeaderText = "سعر ";
            this.item_price.Name = "item_price";
            // 
            // tot_c
            // 
            this.tot_c.DataPropertyName = "incloud_taxes";
            this.tot_c.FillWeight = 89.65739F;
            this.tot_c.HeaderText = "اجمالي";
            this.tot_c.Name = "tot_c";
            this.tot_c.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "date";
            this.dataGridViewTextBoxColumn9.HeaderText = "تاريخ";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "time";
            this.Column6.HeaderText = "الوقت";
            this.Column6.Name = "Column6";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "vcs_code";
            this.Column1.HeaderText = "كود المورد";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "vcs_name";
            this.Column2.HeaderText = "اسم المورد";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "code_items";
            this.Column3.HeaderText = "كود الصنف";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "name_items";
            this.Column4.HeaderText = "اسم الصنف";
            this.Column4.Name = "Column4";
            this.Column4.Visible = false;
            // 
            // name_unite
            // 
            this.name_unite.DataPropertyName = "name_unite";
            this.name_unite.HeaderText = "name_unite";
            this.name_unite.Name = "name_unite";
            this.name_unite.Visible = false;
            // 
            // qty_c
            // 
            this.qty_c.DataPropertyName = "qty";
            this.qty_c.FillWeight = 114.006F;
            this.qty_c.HeaderText = "الكمية";
            this.qty_c.Name = "qty_c";
            this.qty_c.Visible = false;
            // 
            // no
            // 
            this.no.DataPropertyName = "no";
            this.no.FillWeight = 50F;
            this.no.HeaderText = "رقم السطر";
            this.no.Name = "no";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "nam_doc";
            this.Column5.HeaderText = "اسم السند";
            this.Column5.Name = "Column5";
            // 
            // date1
            // 
            this.date1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.date1.CustomFormat = "yyyy/MM/dd";
            this.date1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.date1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date1.Location = new System.Drawing.Point(220, 18);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(94, 20);
            this.date1.TabIndex = 223;
            this.date1.Value = new System.DateTime(2020, 1, 6, 0, 0, 0, 0);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(320, 44);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(61, 17);
            this.labelControl4.TabIndex = 222;
            this.labelControl4.Text = "تاريخ الي";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(320, 18);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(56, 17);
            this.labelControl3.TabIndex = 221;
            this.labelControl3.Text = "تاريخ من";
            // 
            // date2
            // 
            this.date2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.date2.CustomFormat = "yyyy/MM/dd";
            this.date2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.date2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date2.Location = new System.Drawing.Point(220, 44);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(94, 20);
            this.date2.TabIndex = 224;
            this.date2.Value = new System.DateTime(2020, 1, 6, 0, 0, 0, 0);
            // 
            // combo_wars
            // 
            this.combo_wars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_wars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_wars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combo_wars.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.combo_wars.FormattingEnabled = true;
            this.combo_wars.Location = new System.Drawing.Point(657, 73);
            this.combo_wars.Name = "combo_wars";
            this.combo_wars.Size = new System.Drawing.Size(108, 24);
            this.combo_wars.TabIndex = 226;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(792, 81);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 17);
            this.labelControl1.TabIndex = 225;
            this.labelControl1.Text = "رقم المخزن";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(614, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 228;
            this.label1.Text = "الوارد";
            // 
            // lbl_imp
            // 
            this.lbl_imp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_imp.AutoSize = true;
            this.lbl_imp.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lbl_imp.ForeColor = System.Drawing.Color.Red;
            this.lbl_imp.Location = new System.Drawing.Point(550, 115);
            this.lbl_imp.Name = "lbl_imp";
            this.lbl_imp.Size = new System.Drawing.Size(17, 17);
            this.lbl_imp.TabIndex = 227;
            this.lbl_imp.Text = "0";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(406, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 230;
            this.label5.Text = "الصادر";
            // 
            // lbl_exp
            // 
            this.lbl_exp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_exp.AutoSize = true;
            this.lbl_exp.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lbl_exp.ForeColor = System.Drawing.Color.Red;
            this.lbl_exp.Location = new System.Drawing.Point(347, 115);
            this.lbl_exp.Name = "lbl_exp";
            this.lbl_exp.Size = new System.Drawing.Size(17, 17);
            this.lbl_exp.TabIndex = 229;
            this.lbl_exp.Text = "0";
            // 
            // lbl_name
            // 
            this.lbl_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lbl_name.ForeColor = System.Drawing.Color.Red;
            this.lbl_name.Location = new System.Drawing.Point(307, 81);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(17, 17);
            this.lbl_name.TabIndex = 231;
            this.lbl_name.Text = "_";
            // 
            // btn_printer
            // 
            this.btn_printer.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_printer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_printer.ImageOptions.Image")));
            this.btn_printer.Location = new System.Drawing.Point(26, 18);
            this.btn_printer.Name = "btn_printer";
            this.btn_printer.Size = new System.Drawing.Size(37, 34);
            this.btn_printer.TabIndex = 267;
            this.btn_printer.Text = "simpleButton2";
            this.btn_printer.Click += new System.EventHandler(this.btn_printer_Click);
            // 
            // compo_unite
            // 
            this.compo_unite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.compo_unite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.compo_unite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.compo_unite.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.compo_unite.FormattingEnabled = true;
            this.compo_unite.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.compo_unite.Location = new System.Drawing.Point(543, 73);
            this.compo_unite.Name = "compo_unite";
            this.compo_unite.Size = new System.Drawing.Size(89, 24);
            this.compo_unite.TabIndex = 268;
            // 
            // frm_items_card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 525);
            this.Controls.Add(this.compo_unite);
            this.Controls.Add(this.btn_printer);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_exp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_imp);
            this.Controls.Add(this.combo_wars);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.date1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.dgvc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl_bal);
            this.Controls.Add(this.btn_serchinv);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.btn_search_items);
            this.Controls.Add(this.combo_code_items);
            this.Controls.Add(this.combo_name_items);
            this.Controls.Add(this.lbl_code_items);
            this.Controls.Add(this.label2);
            this.Name = "frm_items_card";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كرتة الصنف";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_items_card_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_del;
        private DevExpress.XtraEditors.SimpleButton btn_search_items;
        private System.Windows.Forms.Label lbl_code_items;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_bal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvc;
        private System.Windows.Forms.DateTimePicker date1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.DateTimePicker date2;
        public System.Windows.Forms.ComboBox combo_code_items;
        public System.Windows.Forms.ComboBox combo_name_items;
        public DevExpress.XtraEditors.SimpleButton btn_serchinv;
        private System.Windows.Forms.ComboBox combo_wars;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_imp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_exp;
        private System.Windows.Forms.DataGridViewTextBoxColumn no3;
        private System.Windows.Forms.DataGridViewLinkColumn doc_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn imp;
        private System.Windows.Forms.DataGridViewTextBoxColumn exp;
        private System.Windows.Forms.DataGridViewTextBoxColumn bal_c;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn tot_c;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_unite;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty_c;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label lbl_name;
        private DevExpress.XtraEditors.SimpleButton btn_printer;
        private System.Windows.Forms.ComboBox compo_unite;
    }
}