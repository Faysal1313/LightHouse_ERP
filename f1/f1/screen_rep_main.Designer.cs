namespace f1
{
    partial class screen_rep_main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(screen_rep_main));
            this.dt_piker1 = new System.Windows.Forms.DateTimePicker();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dt_piker2 = new System.Windows.Forms.DateTimePicker();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_type_items = new DevExpress.XtraEditors.LabelControl();
            this.combo_code = new System.Windows.Forms.ComboBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.combo_name = new System.Windows.Forms.ComboBox();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // dt_piker1
            // 
            this.dt_piker1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dt_piker1.CustomFormat = "yyyy/MM/dd";
            this.dt_piker1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.dt_piker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_piker1.Location = new System.Drawing.Point(364, 11);
            this.dt_piker1.Margin = new System.Windows.Forms.Padding(4);
            this.dt_piker1.Name = "dt_piker1";
            this.dt_piker1.Size = new System.Drawing.Size(123, 26);
            this.dt_piker1.TabIndex = 176;
            this.dt_piker1.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(509, 19);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 18);
            this.labelControl1.TabIndex = 175;
            this.labelControl1.Text = "من تاريخ";
            // 
            // dt_piker2
            // 
            this.dt_piker2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dt_piker2.CustomFormat = "yyyy/MM/dd";
            this.dt_piker2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.dt_piker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_piker2.Location = new System.Drawing.Point(85, 11);
            this.dt_piker2.Margin = new System.Windows.Forms.Padding(4);
            this.dt_piker2.Name = "dt_piker2";
            this.dt_piker2.Size = new System.Drawing.Size(127, 26);
            this.dt_piker2.TabIndex = 174;
            this.dt_piker2.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(233, 19);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(68, 18);
            this.labelControl4.TabIndex = 173;
            this.labelControl4.Text = " الي تاريخ";
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(333, 192);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(43, 42);
            this.simpleButton1.TabIndex = 171;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // lbl_type_items
            // 
            this.lbl_type_items.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_type_items.Appearance.Options.UseFont = true;
            this.lbl_type_items.Location = new System.Drawing.Point(48, 73);
            this.lbl_type_items.Margin = new System.Windows.Forms.Padding(4);
            this.lbl_type_items.Name = "lbl_type_items";
            this.lbl_type_items.Size = new System.Drawing.Size(11, 21);
            this.lbl_type_items.TabIndex = 183;
            this.lbl_type_items.Text = "1";
            this.lbl_type_items.Visible = false;
            // 
            // combo_code
            // 
            this.combo_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_code.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.combo_code.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.combo_code.FormattingEnabled = true;
            this.combo_code.Location = new System.Drawing.Point(111, 94);
            this.combo_code.Margin = new System.Windows.Forms.Padding(4);
            this.combo_code.Name = "combo_code";
            this.combo_code.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.combo_code.Size = new System.Drawing.Size(355, 29);
            this.combo_code.TabIndex = 182;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(538, 150);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(55, 21);
            this.labelControl2.TabIndex = 181;
            this.labelControl2.Text = ":الاسم";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(538, 98);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(46, 21);
            this.labelControl10.TabIndex = 179;
            this.labelControl10.Text = ":الكود";
            // 
            // combo_name
            // 
            this.combo_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_name.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.combo_name.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.combo_name.FormattingEnabled = true;
            this.combo_name.Location = new System.Drawing.Point(111, 141);
            this.combo_name.Margin = new System.Windows.Forms.Padding(4);
            this.combo_name.Name = "combo_name";
            this.combo_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.combo_name.Size = new System.Drawing.Size(355, 29);
            this.combo_name.TabIndex = 180;
            this.combo_name.SelectedIndexChanged += new System.EventHandler(this.combo_name_SelectedIndexChanged);
            // 
            // simpleButton2
            // 
            this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.simpleButton2.Location = new System.Drawing.Point(208, 192);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(43, 42);
            this.simpleButton2.TabIndex = 184;
            this.simpleButton2.Text = "simpleButton2";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // screen_rep_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 249);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.lbl_type_items);
            this.Controls.Add(this.combo_code);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.combo_name);
            this.Controls.Add(this.dt_piker1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dt_piker2);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.simpleButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "screen_rep_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "screen_rep_main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.screen_rep_main_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dt_piker1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.DateTimePicker dt_piker2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl lbl_type_items;
        private System.Windows.Forms.ComboBox combo_code;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private System.Windows.Forms.ComboBox combo_name;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}