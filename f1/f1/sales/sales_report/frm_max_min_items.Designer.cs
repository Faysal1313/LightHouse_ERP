namespace f1.sales.sales_report
{
    partial class frm_max_min_items
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_max_min_items));
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.btn_del_inv = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.combo_code = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_items_name = new System.Windows.Forms.ComboBox();
            this.d1 = new System.Windows.Forms.DateTimePicker();
            this.d2 = new System.Windows.Forms.DateTimePicker();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.combo_wars = new System.Windows.Forms.ComboBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(12, 186);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(41, 34);
            this.simpleButton1.TabIndex = 18;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(344, 194);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(39, 17);
            this.labelControl1.TabIndex = 120;
            this.labelControl1.Text = "الحاله";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.radioButton1.Location = new System.Drawing.Point(214, 194);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButton1.Size = new System.Drawing.Size(95, 21);
            this.radioButton1.TabIndex = 121;
            this.radioButton1.Text = "الاكثر مبيعا";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.radioButton2.Location = new System.Drawing.Point(83, 194);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButton2.Size = new System.Drawing.Size(125, 21);
            this.radioButton2.TabIndex = 122;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "الاصناف الراكده";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // btn_del_inv
            // 
            this.btn_del_inv.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_del_inv.Appearance.Options.UseFont = true;
            this.btn_del_inv.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_del_inv.ImageOptions.Image")));
            this.btn_del_inv.Location = new System.Drawing.Point(76, 3);
            this.btn_del_inv.Name = "btn_del_inv";
            this.btn_del_inv.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_del_inv.Size = new System.Drawing.Size(24, 32);
            this.btn_del_inv.TabIndex = 172;
            this.btn_del_inv.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(312, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 171;
            this.label3.Text = "كود الصنف";
            this.label3.Visible = false;
            // 
            // combo_code
            // 
            this.combo_code.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_code.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_code.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.combo_code.FormattingEnabled = true;
            this.combo_code.Location = new System.Drawing.Point(106, 12);
            this.combo_code.Name = "combo_code";
            this.combo_code.Size = new System.Drawing.Size(200, 24);
            this.combo_code.TabIndex = 170;
            this.combo_code.Visible = false;
            this.combo_code.SelectedIndexChanged += new System.EventHandler(this.combo_code_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(312, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 169;
            this.label2.Text = "اسم الصنف";
            this.label2.Visible = false;
            // 
            // combo_items_name
            // 
            this.combo_items_name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_items_name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_items_name.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.combo_items_name.FormattingEnabled = true;
            this.combo_items_name.Location = new System.Drawing.Point(106, 44);
            this.combo_items_name.Name = "combo_items_name";
            this.combo_items_name.Size = new System.Drawing.Size(200, 24);
            this.combo_items_name.TabIndex = 168;
            this.combo_items_name.Visible = false;
            this.combo_items_name.SelectedIndexChanged += new System.EventHandler(this.combo_items_name_SelectedIndexChanged);
            // 
            // d1
            // 
            this.d1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.d1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.d1.CustomFormat = "yyyy/MM/dd";
            this.d1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.d1.Location = new System.Drawing.Point(232, 87);
            this.d1.Name = "d1";
            this.d1.Size = new System.Drawing.Size(77, 20);
            this.d1.TabIndex = 219;
            this.d1.Value = new System.DateTime(2020, 1, 6, 0, 0, 0, 0);
            // 
            // d2
            // 
            this.d2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.d2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.d2.CustomFormat = "yyyy/MM/dd";
            this.d2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.d2.Location = new System.Drawing.Point(58, 87);
            this.d2.Name = "d2";
            this.d2.Size = new System.Drawing.Size(77, 20);
            this.d2.TabIndex = 220;
            this.d2.Value = new System.DateTime(2020, 1, 6, 0, 0, 0, 0);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(315, 87);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 17);
            this.labelControl2.TabIndex = 217;
            this.labelControl2.Text = "تاريخ من";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(141, 87);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(61, 17);
            this.labelControl4.TabIndex = 218;
            this.labelControl4.Text = "تاريخ الي";
            // 
            // combo_wars
            // 
            this.combo_wars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_wars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_wars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combo_wars.FormattingEnabled = true;
            this.combo_wars.Location = new System.Drawing.Point(190, 130);
            this.combo_wars.Name = "combo_wars";
            this.combo_wars.Size = new System.Drawing.Size(89, 21);
            this.combo_wars.TabIndex = 222;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(305, 131);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 17);
            this.labelControl3.TabIndex = 221;
            this.labelControl3.Text = "رقم المخزن";
            // 
            // frm_max_min_items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 236);
            this.Controls.Add(this.combo_wars);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.d1);
            this.Controls.Add(this.d2);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btn_del_inv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.combo_code);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combo_items_name);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.simpleButton1);
            this.Name = "frm_max_min_items";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_max_min_items";
            this.Load += new System.EventHandler(this.frm_max_min_items_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private DevExpress.XtraEditors.SimpleButton btn_del_inv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox combo_code;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_items_name;
        private System.Windows.Forms.DateTimePicker d1;
        private System.Windows.Forms.DateTimePicker d2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.ComboBox combo_wars;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}