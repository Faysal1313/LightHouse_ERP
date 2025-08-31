
namespace f1.pos
{
    partial class frm_matrex_search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_matrex_search));
            this.num_qty = new System.Windows.Forms.NumericUpDown();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.code_items_s = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_items_s = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_unite_s = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit1_c = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catmx1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catmx2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catmx3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catmx4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.combo_cat4 = new System.Windows.Forms.ComboBox();
            this.combo_cat3 = new System.Windows.Forms.ComboBox();
            this.combo_cat2 = new System.Windows.Forms.ComboBox();
            this.combo_cat1 = new System.Windows.Forms.ComboBox();
            this.lbl_cat4 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_cat3 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_cat2 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_cat1 = new DevExpress.XtraEditors.LabelControl();
            this.btn_adv_search = new DevExpress.XtraEditors.SimpleButton();
            this.combo_main_items = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.combo_wars = new System.Windows.Forms.ComboBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_sale_price = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.num_qty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_sale_price)).BeginInit();
            this.SuspendLayout();
            // 
            // num_qty
            // 
            this.num_qty.DecimalPlaces = 1;
            this.num_qty.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.num_qty.Hexadecimal = true;
            this.num_qty.Location = new System.Drawing.Point(14, 113);
            this.num_qty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.num_qty.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_qty.Name = "num_qty";
            this.num_qty.Size = new System.Drawing.Size(72, 25);
            this.num_qty.TabIndex = 138;
            this.num_qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_qty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code_items_s,
            this.Column1,
            this.name_items_s,
            this.name_unite_s,
            this.unit1_c,
            this.Column2,
            this.qty,
            this.catmx1,
            this.catmx2,
            this.catmx3,
            this.catmx4});
            this.dgv.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv.Location = new System.Drawing.Point(0, 146);
            this.dgv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1042, 382);
            this.dgv.TabIndex = 137;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_KeyDown);
            // 
            // code_items_s
            // 
            this.code_items_s.DataPropertyName = "code_items";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.code_items_s.DefaultCellStyle = dataGridViewCellStyle2;
            this.code_items_s.FillWeight = 60F;
            this.code_items_s.HeaderText = "كود الصنف";
            this.code_items_s.Name = "code_items_s";
            this.code_items_s.ReadOnly = true;
            this.code_items_s.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.code_items_s.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.code_items_s.ToolTipText = "يمكن الضغط علي كود الصنف لفتح كرتة الصنف";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "main_code";
            this.Column1.FillWeight = 60F;
            this.Column1.HeaderText = "الكود الرئيسي";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // name_items_s
            // 
            this.name_items_s.DataPropertyName = "name_items";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_items_s.DefaultCellStyle = dataGridViewCellStyle3;
            this.name_items_s.FillWeight = 150F;
            this.name_items_s.HeaderText = "اسم الصنف";
            this.name_items_s.Name = "name_items_s";
            this.name_items_s.ReadOnly = true;
            this.name_items_s.ToolTipText = "يمكن الضغط علي كود الصنف لفتح كرتة الصنف";
            // 
            // name_unite_s
            // 
            this.name_unite_s.DataPropertyName = "name_unite";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_unite_s.DefaultCellStyle = dataGridViewCellStyle4;
            this.name_unite_s.FillWeight = 25F;
            this.name_unite_s.HeaderText = "وحده";
            this.name_unite_s.Name = "name_unite_s";
            this.name_unite_s.ReadOnly = true;
            // 
            // unit1_c
            // 
            this.unit1_c.DataPropertyName = "price_sale";
            this.unit1_c.FillWeight = 50F;
            this.unit1_c.HeaderText = "سعر البيع";
            this.unit1_c.Name = "unit1_c";
            this.unit1_c.ReadOnly = true;
            this.unit1_c.ToolTipText = "يمكن التقر علي اخر سعر شراء لتظهر اسعار الشارء من فواتير المشتريات لمعرفة الاسعار" +
    "";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "cost";
            this.Column2.HeaderText = "تكلفة";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // qty
            // 
            this.qty.DataPropertyName = "qty";
            this.qty.HeaderText = "الكمية";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            // 
            // catmx1
            // 
            this.catmx1.DataPropertyName = "cat1";
            this.catmx1.FillWeight = 50F;
            this.catmx1.HeaderText = "1";
            this.catmx1.Name = "catmx1";
            this.catmx1.ReadOnly = true;
            // 
            // catmx2
            // 
            this.catmx2.DataPropertyName = "cat2";
            this.catmx2.FillWeight = 50F;
            this.catmx2.HeaderText = "2";
            this.catmx2.Name = "catmx2";
            this.catmx2.ReadOnly = true;
            this.catmx2.ToolTipText = "لفتح حركة الصنف";
            // 
            // catmx3
            // 
            this.catmx3.DataPropertyName = "cat3";
            this.catmx3.FillWeight = 50F;
            this.catmx3.HeaderText = "3";
            this.catmx3.Name = "catmx3";
            this.catmx3.ReadOnly = true;
            // 
            // catmx4
            // 
            this.catmx4.DataPropertyName = "cat4";
            this.catmx4.FillWeight = 50F;
            this.catmx4.HeaderText = "4";
            this.catmx4.Name = "catmx4";
            this.catmx4.ReadOnly = true;
            // 
            // txt_search
            // 
            this.txt_search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_search.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_search.Location = new System.Drawing.Point(119, 113);
            this.txt_search.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_search.Name = "txt_search";
            this.txt_search.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_search.Size = new System.Drawing.Size(822, 24);
            this.txt_search.TabIndex = 136;
            this.txt_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            this.txt_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_search_KeyDown);
            this.txt_search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_search_KeyPress);
            // 
            // labelControl12
            // 
            this.labelControl12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(964, 120);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(71, 14);
            this.labelControl12.TabIndex = 135;
            this.labelControl12.Text = ":بحث الصنف";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(303, 37);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(59, 14);
            this.labelControl5.TabIndex = 143;
            this.labelControl5.Text = ":بحث سعر";
            // 
            // combo_cat4
            // 
            this.combo_cat4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_cat4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_cat4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_cat4.FormattingEnabled = true;
            this.combo_cat4.Location = new System.Drawing.Point(384, 68);
            this.combo_cat4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.combo_cat4.Name = "combo_cat4";
            this.combo_cat4.Size = new System.Drawing.Size(140, 22);
            this.combo_cat4.TabIndex = 159;
            // 
            // combo_cat3
            // 
            this.combo_cat3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_cat3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_cat3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_cat3.FormattingEnabled = true;
            this.combo_cat3.Location = new System.Drawing.Point(384, 34);
            this.combo_cat3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.combo_cat3.Name = "combo_cat3";
            this.combo_cat3.Size = new System.Drawing.Size(140, 22);
            this.combo_cat3.TabIndex = 158;
            // 
            // combo_cat2
            // 
            this.combo_cat2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_cat2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_cat2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_cat2.FormattingEnabled = true;
            this.combo_cat2.Location = new System.Drawing.Point(761, 66);
            this.combo_cat2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.combo_cat2.Name = "combo_cat2";
            this.combo_cat2.Size = new System.Drawing.Size(140, 22);
            this.combo_cat2.TabIndex = 157;
            // 
            // combo_cat1
            // 
            this.combo_cat1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_cat1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_cat1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_cat1.FormattingEnabled = true;
            this.combo_cat1.Location = new System.Drawing.Point(761, 36);
            this.combo_cat1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.combo_cat1.Name = "combo_cat1";
            this.combo_cat1.Size = new System.Drawing.Size(140, 22);
            this.combo_cat1.TabIndex = 156;
            // 
            // lbl_cat4
            // 
            this.lbl_cat4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_cat4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_cat4.Appearance.Options.UseFont = true;
            this.lbl_cat4.Location = new System.Drawing.Point(544, 71);
            this.lbl_cat4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_cat4.Name = "lbl_cat4";
            this.lbl_cat4.Size = new System.Drawing.Size(56, 14);
            this.lbl_cat4.TabIndex = 155;
            this.lbl_cat4.Text = "المجموعة";
            // 
            // lbl_cat3
            // 
            this.lbl_cat3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_cat3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_cat3.Appearance.Options.UseFont = true;
            this.lbl_cat3.Location = new System.Drawing.Point(544, 37);
            this.lbl_cat3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_cat3.Name = "lbl_cat3";
            this.lbl_cat3.Size = new System.Drawing.Size(44, 14);
            this.lbl_cat3.TabIndex = 154;
            this.lbl_cat3.Text = "الموديل";
            // 
            // lbl_cat2
            // 
            this.lbl_cat2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_cat2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_cat2.Appearance.Options.UseFont = true;
            this.lbl_cat2.Location = new System.Drawing.Point(924, 75);
            this.lbl_cat2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_cat2.Name = "lbl_cat2";
            this.lbl_cat2.Size = new System.Drawing.Size(34, 14);
            this.lbl_cat2.TabIndex = 153;
            this.lbl_cat2.Text = "شركة";
            // 
            // lbl_cat1
            // 
            this.lbl_cat1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_cat1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_cat1.Appearance.Options.UseFont = true;
            this.lbl_cat1.Location = new System.Drawing.Point(924, 37);
            this.lbl_cat1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_cat1.Name = "lbl_cat1";
            this.lbl_cat1.Size = new System.Drawing.Size(19, 14);
            this.lbl_cat1.TabIndex = 152;
            this.lbl_cat1.Text = "نوع";
            // 
            // btn_adv_search
            // 
            this.btn_adv_search.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_adv_search.Appearance.Options.UseFont = true;
            this.btn_adv_search.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_adv_search.ImageOptions.SvgImage")));
            this.btn_adv_search.Location = new System.Drawing.Point(14, 58);
            this.btn_adv_search.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_adv_search.Name = "btn_adv_search";
            this.btn_adv_search.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_adv_search.Size = new System.Drawing.Size(38, 47);
            this.btn_adv_search.TabIndex = 161;
            this.btn_adv_search.Text = "بحث متقدم";
            this.btn_adv_search.ToolTip = "بحث متقدم";
            this.btn_adv_search.ToolTipTitle = "بحث متقدم";
            this.btn_adv_search.Click += new System.EventHandler(this.btn_adv_search_Click);
            // 
            // combo_main_items
            // 
            this.combo_main_items.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_main_items.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_main_items.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_main_items.FormattingEnabled = true;
            this.combo_main_items.Location = new System.Drawing.Point(518, 3);
            this.combo_main_items.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.combo_main_items.Name = "combo_main_items";
            this.combo_main_items.Size = new System.Drawing.Size(140, 22);
            this.combo_main_items.TabIndex = 163;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(678, 6);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(93, 14);
            this.labelControl1.TabIndex = 162;
            this.labelControl1.Text = "الصنف الرئيسي";
            // 
            // combo_wars
            // 
            this.combo_wars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_wars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_wars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combo_wars.FormattingEnabled = true;
            this.combo_wars.Location = new System.Drawing.Point(12, 6);
            this.combo_wars.Name = "combo_wars";
            this.combo_wars.Size = new System.Drawing.Size(89, 22);
            this.combo_wars.TabIndex = 165;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Location = new System.Drawing.Point(128, 14);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 13);
            this.labelControl3.TabIndex = 164;
            this.labelControl3.Text = "رقم المخزن";
            // 
            // txt_sale_price
            // 
            this.txt_sale_price.DecimalPlaces = 1;
            this.txt_sale_price.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txt_sale_price.Location = new System.Drawing.Point(168, 33);
            this.txt_sale_price.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txt_sale_price.Name = "txt_sale_price";
            this.txt_sale_price.Size = new System.Drawing.Size(129, 27);
            this.txt_sale_price.TabIndex = 185;
            this.txt_sale_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_sale_price.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // frm_matrex_search
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 532);
            this.Controls.Add(this.txt_sale_price);
            this.Controls.Add(this.combo_wars);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.combo_main_items);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btn_adv_search);
            this.Controls.Add(this.combo_cat4);
            this.Controls.Add(this.combo_cat3);
            this.Controls.Add(this.combo_cat2);
            this.Controls.Add(this.combo_cat1);
            this.Controls.Add(this.lbl_cat4);
            this.Controls.Add(this.lbl_cat3);
            this.Controls.Add(this.lbl_cat2);
            this.Controls.Add(this.lbl_cat1);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.num_qty);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.labelControl12);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_matrex_search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة البحث في اكثر من حقل";
            this.Load += new System.EventHandler(this.frm_matrex_search_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_qty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_sale_price)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown num_qty;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox txt_search;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.ComboBox combo_cat4;
        private System.Windows.Forms.ComboBox combo_cat3;
        private System.Windows.Forms.ComboBox combo_cat2;
        private System.Windows.Forms.ComboBox combo_cat1;
        private DevExpress.XtraEditors.LabelControl lbl_cat4;
        private DevExpress.XtraEditors.LabelControl lbl_cat3;
        private DevExpress.XtraEditors.LabelControl lbl_cat2;
        private DevExpress.XtraEditors.LabelControl lbl_cat1;
        private DevExpress.XtraEditors.SimpleButton btn_adv_search;
        private System.Windows.Forms.DataGridViewLinkColumn code_items_s;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_items_s;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_unite_s;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit1_c;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn catmx1;
        private System.Windows.Forms.DataGridViewTextBoxColumn catmx2;
        private System.Windows.Forms.DataGridViewTextBoxColumn catmx3;
        private System.Windows.Forms.DataGridViewTextBoxColumn catmx4;
        private System.Windows.Forms.ComboBox combo_main_items;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ComboBox combo_wars;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.NumericUpDown txt_sale_price;
    }
}