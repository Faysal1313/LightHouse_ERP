namespace f1.inventory.printer_items.report_items
{
    partial class frm_rep_items_card
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_rep_items_card));
            this.lbl_num = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_items_name = new System.Windows.Forms.ComboBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_code_vcs = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.combo_vcs = new System.Windows.Forms.ComboBox();
            this.combo_wars = new System.Windows.Forms.ComboBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.combo_unite = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label3 = new System.Windows.Forms.Label();
            this.combo_code_items = new System.Windows.Forms.ComboBox();
            this.btn_del_inv = new DevExpress.XtraEditors.SimpleButton();
            this.d1 = new System.Windows.Forms.DateTimePicker();
            this.d2 = new System.Windows.Forms.DateTimePicker();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // lbl_num
            // 
            this.lbl_num.AutoSize = true;
            this.lbl_num.Location = new System.Drawing.Point(26, 27);
            this.lbl_num.Name = "lbl_num";
            this.lbl_num.Size = new System.Drawing.Size(13, 13);
            this.lbl_num.TabIndex = 10;
            this.lbl_num.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(270, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "اسم الصنف";
            // 
            // combo_items_name
            // 
            this.combo_items_name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_items_name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_items_name.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.combo_items_name.FormattingEnabled = true;
            this.combo_items_name.Location = new System.Drawing.Point(64, 56);
            this.combo_items_name.Name = "combo_items_name";
            this.combo_items_name.Size = new System.Drawing.Size(200, 24);
            this.combo_items_name.TabIndex = 8;
            this.combo_items_name.SelectedIndexChanged += new System.EventHandler(this.combo_items_SelectedIndexChanged);
            this.combo_items_name.Click += new System.EventHandler(this.combo_items_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(34, 228);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(39, 34);
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // lbl_code_vcs
            // 
            this.lbl_code_vcs.AutoSize = true;
            this.lbl_code_vcs.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_code_vcs.Location = new System.Drawing.Point(61, 134);
            this.lbl_code_vcs.Name = "lbl_code_vcs";
            this.lbl_code_vcs.Size = new System.Drawing.Size(15, 14);
            this.lbl_code_vcs.TabIndex = 13;
            this.lbl_code_vcs.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(250, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "موردين  او عملاء";
            // 
            // combo_vcs
            // 
            this.combo_vcs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_vcs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_vcs.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.combo_vcs.FormattingEnabled = true;
            this.combo_vcs.Location = new System.Drawing.Point(64, 99);
            this.combo_vcs.Name = "combo_vcs";
            this.combo_vcs.Size = new System.Drawing.Size(156, 24);
            this.combo_vcs.TabIndex = 11;
            this.combo_vcs.SelectedIndexChanged += new System.EventHandler(this.combo_vcs_SelectedIndexChanged);
            this.combo_vcs.Click += new System.EventHandler(this.combo_vcs_Click);
            // 
            // combo_wars
            // 
            this.combo_wars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_wars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_wars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combo_wars.FormattingEnabled = true;
            this.combo_wars.Location = new System.Drawing.Point(158, 207);
            this.combo_wars.Name = "combo_wars";
            this.combo_wars.Size = new System.Drawing.Size(89, 21);
            this.combo_wars.TabIndex = 115;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(273, 208);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 17);
            this.labelControl3.TabIndex = 114;
            this.labelControl3.Text = "رقم المخزن";
            // 
            // combo_unite
            // 
            this.combo_unite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_unite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_unite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combo_unite.FormattingEnabled = true;
            this.combo_unite.Location = new System.Drawing.Point(158, 234);
            this.combo_unite.Name = "combo_unite";
            this.combo_unite.Size = new System.Drawing.Size(89, 21);
            this.combo_unite.TabIndex = 117;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(273, 235);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(81, 17);
            this.labelControl1.TabIndex = 116;
            this.labelControl1.Text = "وحده الصنف";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(270, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 119;
            this.label3.Text = "كود الصنف";
            // 
            // combo_code_items
            // 
            this.combo_code_items.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_code_items.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_code_items.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.combo_code_items.FormattingEnabled = true;
            this.combo_code_items.Location = new System.Drawing.Point(64, 24);
            this.combo_code_items.Name = "combo_code_items";
            this.combo_code_items.Size = new System.Drawing.Size(200, 24);
            this.combo_code_items.TabIndex = 118;
            this.combo_code_items.SelectedIndexChanged += new System.EventHandler(this.combo_code_SelectedIndexChanged);
            // 
            // btn_del_inv
            // 
            this.btn_del_inv.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_del_inv.Appearance.Options.UseFont = true;
            this.btn_del_inv.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_del_inv.ImageOptions.Image")));
            this.btn_del_inv.Location = new System.Drawing.Point(34, 15);
            this.btn_del_inv.Name = "btn_del_inv";
            this.btn_del_inv.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_del_inv.Size = new System.Drawing.Size(24, 32);
            this.btn_del_inv.TabIndex = 167;
            this.btn_del_inv.Click += new System.EventHandler(this.btn_del_inv_Click);
            // 
            // d1
            // 
            this.d1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.d1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.d1.CustomFormat = "yyyy/MM/dd";
            this.d1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.d1.Location = new System.Drawing.Point(205, 161);
            this.d1.Name = "d1";
            this.d1.Size = new System.Drawing.Size(77, 20);
            this.d1.TabIndex = 215;
            this.d1.Value = new System.DateTime(2020, 1, 6, 0, 0, 0, 0);
            // 
            // d2
            // 
            this.d2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.d2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.d2.CustomFormat = "yyyy/MM/dd";
            this.d2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.d2.Location = new System.Drawing.Point(31, 161);
            this.d2.Name = "d2";
            this.d2.Size = new System.Drawing.Size(77, 20);
            this.d2.TabIndex = 216;
            this.d2.Value = new System.DateTime(2020, 1, 6, 0, 0, 0, 0);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(288, 161);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 17);
            this.labelControl2.TabIndex = 213;
            this.labelControl2.Text = "تاريخ من";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(114, 161);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(61, 17);
            this.labelControl4.TabIndex = 214;
            this.labelControl4.Text = "تاريخ الي";
            // 
            // frm_rep_items_card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 274);
            this.Controls.Add(this.d1);
            this.Controls.Add(this.d2);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btn_del_inv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.combo_code_items);
            this.Controls.Add(this.combo_unite);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.combo_wars);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lbl_code_vcs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combo_vcs);
            this.Controls.Add(this.lbl_num);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combo_items_name);
            this.Controls.Add(this.simpleButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_rep_items_card";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "كرتة صنف";
            this.Load += new System.EventHandler(this.frm_rep_items_card_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_num;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_items_name;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label lbl_code_vcs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_vcs;
        private System.Windows.Forms.ComboBox combo_wars;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.ComboBox combo_unite;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox combo_code_items;
        private DevExpress.XtraEditors.SimpleButton btn_del_inv;
        private System.Windows.Forms.DateTimePicker d1;
        private System.Windows.Forms.DateTimePicker d2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}