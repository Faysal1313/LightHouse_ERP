namespace f1
{
    partial class frm_type
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_type));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txt_serial_entry = new System.Windows.Forms.TextBox();
            this.txt_code_entry = new System.Windows.Forms.TextBox();
            this.comb_bookname_entry = new System.Windows.Forms.ComboBox();
            this.com = new System.Windows.Forms.ComboBox();
            this.txt_code_book = new System.Windows.Forms.TextBox();
            this.combo_book_name = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lbl_costcenter = new System.Windows.Forms.Label();
            this.lbl_accidcredit = new System.Windows.Forms.Label();
            this.btn_costcenter = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_accid_depit = new System.Windows.Forms.Label();
            this.combo_costcenter = new System.Windows.Forms.ComboBox();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.btn_add_depit = new System.Windows.Forms.Button();
            this.txt_depit_acc = new System.Windows.Forms.TextBox();
            this.txt_credit_acc = new System.Windows.Forms.TextBox();
            this.combofield_credit = new System.Windows.Forms.ComboBox();
            this.combo_depit = new System.Windows.Forms.ComboBox();
            this.btn_add_credit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.combofield_depit = new System.Windows.Forms.ComboBox();
            this.combo_credit = new System.Windows.Forms.ComboBox();
            this.comb_depit_name = new System.Windows.Forms.ComboBox();
            this.comb_credit_name = new System.Windows.Forms.ComboBox();
            this.terms_id_combo = new System.Windows.Forms.ComboBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rootid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rootname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costcenter_term = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.btn_searsh_terms = new DevExpress.XtraEditors.SimpleButton();
            this.chk_taxes = new System.Windows.Forms.CheckBox();
            this.chk_add_vat = new System.Windows.Forms.CheckBox();
            this.vat_rate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txt_serial_entry);
            this.groupControl1.Controls.Add(this.txt_code_entry);
            this.groupControl1.Controls.Add(this.comb_bookname_entry);
            this.groupControl1.Location = new System.Drawing.Point(1, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(200, 181);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "القيود المحاسبيه";
            // 
            // txt_serial_entry
            // 
            this.txt_serial_entry.Location = new System.Drawing.Point(41, 126);
            this.txt_serial_entry.Name = "txt_serial_entry";
            this.txt_serial_entry.Size = new System.Drawing.Size(100, 20);
            this.txt_serial_entry.TabIndex = 1;
            // 
            // txt_code_entry
            // 
            this.txt_code_entry.Location = new System.Drawing.Point(43, 66);
            this.txt_code_entry.Name = "txt_code_entry";
            this.txt_code_entry.Size = new System.Drawing.Size(100, 20);
            this.txt_code_entry.TabIndex = 2;
            // 
            // comb_bookname_entry
            // 
            this.comb_bookname_entry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comb_bookname_entry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comb_bookname_entry.FormattingEnabled = true;
            this.comb_bookname_entry.Location = new System.Drawing.Point(43, 24);
            this.comb_bookname_entry.Name = "comb_bookname_entry";
            this.comb_bookname_entry.Size = new System.Drawing.Size(98, 21);
            this.comb_bookname_entry.TabIndex = 110;
            this.comb_bookname_entry.SelectedIndexChanged += new System.EventHandler(this.comb_bookname_entry_SelectedIndexChanged);
            // 
            // com
            // 
            this.com.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.com.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.com.FormattingEnabled = true;
            this.com.Items.AddRange(new object[] {
            "سند القيد",
            "سند فاتوره مشتريات",
            "سند مردودات مشتريات",
            "سند فاتوره مبيعات",
            "سند مردودات مبيعات",
            "سند قبض ",
            "سند دفع",
            "سند جرد",
            "سند تحويل مخزني",
            "سند امر شغل نقل",
            "سند صرف مخزني",
            "سند توريد مخزني"});
            this.com.Location = new System.Drawing.Point(394, 12);
            this.com.Name = "com";
            this.com.Size = new System.Drawing.Size(313, 21);
            this.com.TabIndex = 97;
            this.com.SelectedIndexChanged += new System.EventHandler(this.com_SelectedIndexChanged);
            // 
            // txt_code_book
            // 
            this.txt_code_book.Location = new System.Drawing.Point(446, 57);
            this.txt_code_book.Name = "txt_code_book";
            this.txt_code_book.Size = new System.Drawing.Size(196, 20);
            this.txt_code_book.TabIndex = 124;
            // 
            // combo_book_name
            // 
            this.combo_book_name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_book_name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_book_name.FormattingEnabled = true;
            this.combo_book_name.Location = new System.Drawing.Point(648, 57);
            this.combo_book_name.Name = "combo_book_name";
            this.combo_book_name.Size = new System.Drawing.Size(205, 21);
            this.combo_book_name.TabIndex = 123;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(918, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 127;
            this.label4.Text = "كود نوع السند";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(925, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 126;
            this.label3.Text = "دفاتر القيود";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.lbl_costcenter);
            this.groupControl2.Controls.Add(this.lbl_accidcredit);
            this.groupControl2.Controls.Add(this.btn_costcenter);
            this.groupControl2.Controls.Add(this.lbl_accid_depit);
            this.groupControl2.Controls.Add(this.combo_costcenter);
            this.groupControl2.Controls.Add(this.labelControl11);
            this.groupControl2.Controls.Add(this.btn_add_depit);
            this.groupControl2.Controls.Add(this.txt_depit_acc);
            this.groupControl2.Controls.Add(this.txt_credit_acc);
            this.groupControl2.Controls.Add(this.combofield_credit);
            this.groupControl2.Controls.Add(this.combo_depit);
            this.groupControl2.Controls.Add(this.btn_add_credit);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.combofield_depit);
            this.groupControl2.Controls.Add(this.combo_credit);
            this.groupControl2.Controls.Add(this.comb_depit_name);
            this.groupControl2.Controls.Add(this.comb_credit_name);
            this.groupControl2.Location = new System.Drawing.Point(221, 127);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(738, 123);
            this.groupControl2.TabIndex = 111;
            this.groupControl2.Text = "...";
            // 
            // lbl_costcenter
            // 
            this.lbl_costcenter.AutoSize = true;
            this.lbl_costcenter.Location = new System.Drawing.Point(11, 107);
            this.lbl_costcenter.Name = "lbl_costcenter";
            this.lbl_costcenter.Size = new System.Drawing.Size(54, 13);
            this.lbl_costcenter.TabIndex = 158;
            this.lbl_costcenter.Text = "costcener";
            this.lbl_costcenter.Visible = false;
            // 
            // lbl_accidcredit
            // 
            this.lbl_accidcredit.AutoSize = true;
            this.lbl_accidcredit.Location = new System.Drawing.Point(362, 99);
            this.lbl_accidcredit.Name = "lbl_accidcredit";
            this.lbl_accidcredit.Size = new System.Drawing.Size(74, 13);
            this.lbl_accidcredit.TabIndex = 129;
            this.lbl_accidcredit.Text = "lbl_accidcredit";
            // 
            // btn_costcenter
            // 
            this.btn_costcenter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_costcenter.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btn_costcenter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_costcenter.ImageOptions.Image")));
            this.btn_costcenter.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_costcenter.Location = new System.Drawing.Point(71, 95);
            this.btn_costcenter.Name = "btn_costcenter";
            this.btn_costcenter.Size = new System.Drawing.Size(22, 25);
            this.btn_costcenter.TabIndex = 157;
            this.btn_costcenter.Click += new System.EventHandler(this.btn_costcenter_Click);
            // 
            // lbl_accid_depit
            // 
            this.lbl_accid_depit.AutoSize = true;
            this.lbl_accid_depit.Location = new System.Drawing.Point(269, 97);
            this.lbl_accid_depit.Name = "lbl_accid_depit";
            this.lbl_accid_depit.Size = new System.Drawing.Size(77, 13);
            this.lbl_accid_depit.TabIndex = 128;
            this.lbl_accid_depit.Text = "lbl_accid_depit";
            // 
            // combo_costcenter
            // 
            this.combo_costcenter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.combo_costcenter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_costcenter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_costcenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_costcenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combo_costcenter.FormattingEnabled = true;
            this.combo_costcenter.Items.AddRange(new object[] {
            "asd",
            "asd",
            "asd",
            "asd",
            "as",
            "d"});
            this.combo_costcenter.Location = new System.Drawing.Point(98, 99);
            this.combo_costcenter.Name = "combo_costcenter";
            this.combo_costcenter.Size = new System.Drawing.Size(102, 21);
            this.combo_costcenter.TabIndex = 156;
            // 
            // labelControl11
            // 
            this.labelControl11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl11.Location = new System.Drawing.Point(210, 102);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(35, 13);
            this.labelControl11.TabIndex = 155;
            this.labelControl11.Text = "م تكلفه";
            // 
            // btn_add_depit
            // 
            this.btn_add_depit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_depit.Location = new System.Drawing.Point(7, 32);
            this.btn_add_depit.Name = "btn_add_depit";
            this.btn_add_depit.Size = new System.Drawing.Size(75, 23);
            this.btn_add_depit.TabIndex = 131;
            this.btn_add_depit.Text = "add depit";
            this.btn_add_depit.UseVisualStyleBackColor = true;
            this.btn_add_depit.Click += new System.EventHandler(this.btn_add_depit_Click);
            // 
            // txt_depit_acc
            // 
            this.txt_depit_acc.Location = new System.Drawing.Point(200, 34);
            this.txt_depit_acc.Name = "txt_depit_acc";
            this.txt_depit_acc.Size = new System.Drawing.Size(159, 20);
            this.txt_depit_acc.TabIndex = 122;
            // 
            // txt_credit_acc
            // 
            this.txt_credit_acc.Location = new System.Drawing.Point(200, 64);
            this.txt_credit_acc.Name = "txt_credit_acc";
            this.txt_credit_acc.Size = new System.Drawing.Size(159, 20);
            this.txt_credit_acc.TabIndex = 123;
            // 
            // combofield_credit
            // 
            this.combofield_credit.FormattingEnabled = true;
            this.combofield_credit.Location = new System.Drawing.Point(98, 61);
            this.combofield_credit.Name = "combofield_credit";
            this.combofield_credit.Size = new System.Drawing.Size(96, 21);
            this.combofield_credit.TabIndex = 133;
            // 
            // combo_depit
            // 
            this.combo_depit.FormattingEnabled = true;
            this.combo_depit.Items.AddRange(new object[] {
            "ثابت"});
            this.combo_depit.Location = new System.Drawing.Point(532, 32);
            this.combo_depit.Name = "combo_depit";
            this.combo_depit.Size = new System.Drawing.Size(96, 21);
            this.combo_depit.TabIndex = 124;
            this.combo_depit.SelectedIndexChanged += new System.EventHandler(this.combo_depit_SelectedIndexChanged);
            // 
            // btn_add_credit
            // 
            this.btn_add_credit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_credit.Location = new System.Drawing.Point(7, 62);
            this.btn_add_credit.Name = "btn_add_credit";
            this.btn_add_credit.Size = new System.Drawing.Size(75, 23);
            this.btn_add_credit.TabIndex = 132;
            this.btn_add_credit.Text = "add credit";
            this.btn_add_credit.UseVisualStyleBackColor = true;
            this.btn_add_credit.Click += new System.EventHandler(this.btn_add_credit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(695, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 125;
            this.label1.Text = "المدين";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(695, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 126;
            this.label2.Text = "الدائن";
            // 
            // combofield_depit
            // 
            this.combofield_depit.FormattingEnabled = true;
            this.combofield_depit.Location = new System.Drawing.Point(98, 34);
            this.combofield_depit.Name = "combofield_depit";
            this.combofield_depit.Size = new System.Drawing.Size(96, 21);
            this.combofield_depit.TabIndex = 130;
            // 
            // combo_credit
            // 
            this.combo_credit.FormattingEnabled = true;
            this.combo_credit.Items.AddRange(new object[] {
            "حساب",
            "مخازن1"});
            this.combo_credit.Location = new System.Drawing.Point(532, 64);
            this.combo_credit.Name = "combo_credit";
            this.combo_credit.Size = new System.Drawing.Size(96, 21);
            this.combo_credit.TabIndex = 127;
            this.combo_credit.SelectedIndexChanged += new System.EventHandler(this.combo_credit_SelectedIndexChanged);
            // 
            // comb_depit_name
            // 
            this.comb_depit_name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comb_depit_name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comb_depit_name.FormattingEnabled = true;
            this.comb_depit_name.Location = new System.Drawing.Point(365, 32);
            this.comb_depit_name.Name = "comb_depit_name";
            this.comb_depit_name.Size = new System.Drawing.Size(154, 21);
            this.comb_depit_name.TabIndex = 128;
            this.comb_depit_name.SelectedIndexChanged += new System.EventHandler(this.comb_depit_name_SelectedIndexChanged);
            // 
            // comb_credit_name
            // 
            this.comb_credit_name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comb_credit_name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comb_credit_name.FormattingEnabled = true;
            this.comb_credit_name.Location = new System.Drawing.Point(365, 64);
            this.comb_credit_name.Name = "comb_credit_name";
            this.comb_credit_name.Size = new System.Drawing.Size(154, 21);
            this.comb_credit_name.TabIndex = 129;
            this.comb_credit_name.SelectedIndexChanged += new System.EventHandler(this.comb_credit_name_SelectedIndexChanged);
            // 
            // terms_id_combo
            // 
            this.terms_id_combo.FormattingEnabled = true;
            this.terms_id_combo.Location = new System.Drawing.Point(562, 104);
            this.terms_id_combo.MaxLength = 20;
            this.terms_id_combo.Name = "terms_id_combo";
            this.terms_id_combo.Size = new System.Drawing.Size(287, 21);
            this.terms_id_combo.TabIndex = 128;
            this.terms_id_combo.SelectedIndexChanged += new System.EventHandler(this.terms_id_combo_SelectedIndexChanged);
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
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.rootid,
            this.rootname,
            this.depit,
            this.credit,
            this.value,
            this.costcenter_term});
            this.dgv.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgv.Location = new System.Drawing.Point(12, 256);
            this.dgv.Name = "dgv";
            this.dgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(970, 212);
            this.dgv.TabIndex = 131;
            // 
            // id
            // 
            this.id.DataPropertyName = "term_id";
            this.id.FillWeight = 116.2617F;
            this.id.HeaderText = "رقم";
            this.id.Name = "id";
            // 
            // rootid
            // 
            this.rootid.DataPropertyName = "rootid";
            this.rootid.FillWeight = 116.2617F;
            this.rootid.HeaderText = "رقم الحساب";
            this.rootid.Name = "rootid";
            // 
            // rootname
            // 
            this.rootname.DataPropertyName = "rootname";
            this.rootname.FillWeight = 116.2617F;
            this.rootname.HeaderText = "اسم الحساب";
            this.rootname.Name = "rootname";
            // 
            // depit
            // 
            this.depit.DataPropertyName = "depit";
            this.depit.FillWeight = 116.2617F;
            this.depit.HeaderText = "مدين";
            this.depit.Name = "depit";
            // 
            // credit
            // 
            this.credit.DataPropertyName = "credit";
            this.credit.FillWeight = 116.2617F;
            this.credit.HeaderText = "دائن";
            this.credit.Name = "credit";
            // 
            // value
            // 
            this.value.FillWeight = 116.2617F;
            this.value.HeaderText = "حق السند";
            this.value.Name = "value";
            // 
            // costcenter_term
            // 
            this.costcenter_term.DataPropertyName = "costcenter_id";
            this.costcenter_term.HeaderText = "م تكلفة";
            this.costcenter_term.Name = "costcenter_term";
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton2.Location = new System.Drawing.Point(52, 3);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton2.Size = new System.Drawing.Size(41, 36);
            this.simpleButton2.TabIndex = 133;
            this.simpleButton2.Click += new System.EventHandler(this._delete_simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton1.Location = new System.Drawing.Point(99, 3);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton1.Size = new System.Drawing.Size(38, 36);
            this.simpleButton1.TabIndex = 132;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this._save_simpleButton1_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.simpleButton3.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton3.Location = new System.Drawing.Point(5, 3);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton3.Size = new System.Drawing.Size(41, 36);
            this.simpleButton3.TabIndex = 134;
            this.simpleButton3.Click += new System.EventHandler(this._new_simpleButton3_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.simpleButton1);
            this.groupControl3.Controls.Add(this.simpleButton3);
            this.groupControl3.Controls.Add(this.simpleButton2);
            this.groupControl3.Location = new System.Drawing.Point(850, 4);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.ShowCaption = false;
            this.groupControl3.Size = new System.Drawing.Size(141, 42);
            this.groupControl3.TabIndex = 135;
            this.groupControl3.Text = "groupControl3";
            // 
            // btn_searsh_terms
            // 
            this.btn_searsh_terms.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_searsh_terms.ImageOptions.Image")));
            this.btn_searsh_terms.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_searsh_terms.Location = new System.Drawing.Point(394, 51);
            this.btn_searsh_terms.Name = "btn_searsh_terms";
            this.btn_searsh_terms.Size = new System.Drawing.Size(36, 32);
            this.btn_searsh_terms.TabIndex = 136;
            this.btn_searsh_terms.Text = "simpleButton4";
            this.btn_searsh_terms.Click += new System.EventHandler(this.btn_searsh_terms_Click);
            // 
            // chk_taxes
            // 
            this.chk_taxes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chk_taxes.AutoSize = true;
            this.chk_taxes.Location = new System.Drawing.Point(81, 198);
            this.chk_taxes.Name = "chk_taxes";
            this.chk_taxes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk_taxes.Size = new System.Drawing.Size(77, 17);
            this.chk_taxes.TabIndex = 137;
            this.chk_taxes.Text = "بدون ضريبه";
            this.chk_taxes.UseVisualStyleBackColor = true;
            // 
            // chk_add_vat
            // 
            this.chk_add_vat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chk_add_vat.AutoSize = true;
            this.chk_add_vat.Location = new System.Drawing.Point(10, 221);
            this.chk_add_vat.Name = "chk_add_vat";
            this.chk_add_vat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk_add_vat.Size = new System.Drawing.Size(148, 17);
            this.chk_add_vat.TabIndex = 138;
            this.chk_add_vat.Text = "بدون ضريبه القيمه المضافه";
            this.chk_add_vat.UseVisualStyleBackColor = true;
            // 
            // vat_rate
            // 
            this.vat_rate.Location = new System.Drawing.Point(164, 208);
            this.vat_rate.Name = "vat_rate";
            this.vat_rate.Size = new System.Drawing.Size(37, 20);
            this.vat_rate.TabIndex = 111;
            this.vat_rate.Text = "0";
            this.vat_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frm_type
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 469);
            this.Controls.Add(this.vat_rate);
            this.Controls.Add(this.chk_add_vat);
            this.Controls.Add(this.chk_taxes);
            this.Controls.Add(this.btn_searsh_terms);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.terms_id_combo);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_code_book);
            this.Controls.Add(this.combo_book_name);
            this.Controls.Add(this.com);
            this.Controls.Add(this.groupControl1);
            this.Name = "frm_type";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "انواع السندات";
            this.Load += new System.EventHandler(this.frm_type_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TextBox txt_serial_entry;
        private System.Windows.Forms.TextBox txt_code_entry;
        private System.Windows.Forms.ComboBox comb_bookname_entry;
        private System.Windows.Forms.ComboBox com;
        private System.Windows.Forms.TextBox txt_code_book;
        private System.Windows.Forms.ComboBox combo_book_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Label lbl_accidcredit;
        private System.Windows.Forms.Label lbl_accid_depit;
        private System.Windows.Forms.Button btn_add_depit;
        private System.Windows.Forms.TextBox txt_depit_acc;
        private System.Windows.Forms.TextBox txt_credit_acc;
        private System.Windows.Forms.ComboBox combofield_credit;
        private System.Windows.Forms.ComboBox combo_depit;
        private System.Windows.Forms.Button btn_add_credit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combofield_depit;
        private System.Windows.Forms.ComboBox combo_credit;
        private System.Windows.Forms.ComboBox comb_depit_name;
        private System.Windows.Forms.ComboBox comb_credit_name;
        private System.Windows.Forms.ComboBox terms_id_combo;
        private System.Windows.Forms.DataGridView dgv;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton btn_searsh_terms;
        private System.Windows.Forms.CheckBox chk_taxes;
        private System.Windows.Forms.CheckBox chk_add_vat;
        private System.Windows.Forms.TextBox vat_rate;
        private System.Windows.Forms.Label lbl_costcenter;
        private DevExpress.XtraEditors.SimpleButton btn_costcenter;
        private System.Windows.Forms.ComboBox combo_costcenter;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn rootid;
        private System.Windows.Forms.DataGridViewTextBoxColumn rootname;
        private System.Windows.Forms.DataGridViewTextBoxColumn depit;
        private System.Windows.Forms.DataGridViewTextBoxColumn credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.DataGridViewTextBoxColumn costcenter_term;
    }
}