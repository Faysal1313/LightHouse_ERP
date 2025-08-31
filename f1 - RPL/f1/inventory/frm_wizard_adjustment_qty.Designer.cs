namespace f1.inventory
{
    partial class frm_wizard_adjustment_qty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_wizard_adjustment_qty));
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.chk_intro = new System.Windows.Forms.CheckBox();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.rdo_adj_with_exp = new System.Windows.Forms.RadioButton();
            this.rdo_adj_without_exp = new System.Windows.Forms.RadioButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.combo_wars = new System.Windows.Forms.ComboBox();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.wizardPage2 = new DevExpress.XtraWizard.WizardPage();
            this.rdo_with_exp_excel = new System.Windows.Forms.RadioButton();
            this.rdo_with_exp_manual = new System.Windows.Forms.RadioButton();
            this.rdo_with_excel = new System.Windows.Forms.RadioButton();
            this.rdo_manual = new System.Windows.Forms.RadioButton();
            this.wizardPage3 = new DevExpress.XtraWizard.WizardPage();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.test_btn = new DevExpress.XtraEditors.SimpleButton();
            this.btn_delete_file = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.welcomeWizardPage1.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            this.wizardPage2.SuspendLayout();
            this.wizardPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.Controls.Add(this.welcomeWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage1);
            this.wizardControl1.Controls.Add(this.completionWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage2);
            this.wizardControl1.Controls.Add(this.wizardPage3);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wizardPage1,
            this.wizardPage2,
            this.wizardPage3,
            this.completionWizardPage1});
            this.wizardControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.wizardControl1.Size = new System.Drawing.Size(801, 419);
            this.wizardControl1.Text = "Wizard Title1111";
            this.wizardControl1.CancelClick += new System.ComponentModel.CancelEventHandler(this.wizardControl1_CancelClick);
            this.wizardControl1.FinishClick += new System.ComponentModel.CancelEventHandler(this.wizardControl1_FinishClick);
            this.wizardControl1.NextClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wizardControl1_NextClick);
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.Controls.Add(this.chk_intro);
            this.welcomeWizardPage1.IntroductionText = "مرحب بك في نظام الجرد لكميات الصنف \r\n\r\nسيتم إقاف حركه المخازن لعمل الجرد\r\n\r\n\r\nملح" +
    "وظه لايمكن الرجوع بعد عمل الجرد او يمكن حفظ الجرد كنسخه ارشيفيه للرجوع لي محضر ا" +
    "لجرد ";
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.welcomeWizardPage1.Size = new System.Drawing.Size(584, 287);
            this.welcomeWizardPage1.Text = "Welcome to the Adjustment Quantity";
            // 
            // chk_intro
            // 
            this.chk_intro.AutoSize = true;
            this.chk_intro.Location = new System.Drawing.Point(179, 164);
            this.chk_intro.Name = "chk_intro";
            this.chk_intro.Size = new System.Drawing.Size(137, 17);
            this.chk_intro.TabIndex = 0;
            this.chk_intro.Text = "برجاء الموافقه لاستكمال";
            this.chk_intro.UseVisualStyleBackColor = true;
            this.chk_intro.CheckedChanged += new System.EventHandler(this.chk_intro_CheckedChanged);
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.rdo_adj_with_exp);
            this.wizardPage1.Controls.Add(this.rdo_adj_without_exp);
            this.wizardPage1.Controls.Add(this.labelControl3);
            this.wizardPage1.Controls.Add(this.combo_wars);
            this.wizardPage1.DescriptionText = "select wares  ";
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(769, 276);
            this.wizardPage1.Text = "select invetrory";
            // 
            // rdo_adj_with_exp
            // 
            this.rdo_adj_with_exp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdo_adj_with_exp.AutoSize = true;
            this.rdo_adj_with_exp.Location = new System.Drawing.Point(312, 118);
            this.rdo_adj_with_exp.Name = "rdo_adj_with_exp";
            this.rdo_adj_with_exp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdo_adj_with_exp.Size = new System.Drawing.Size(138, 17);
            this.rdo_adj_with_exp.TabIndex = 160;
            this.rdo_adj_with_exp.TabStop = true;
            this.rdo_adj_with_exp.Text = "جرد كميات بتاريخ صلاحيه";
            this.rdo_adj_with_exp.UseVisualStyleBackColor = true;
            this.rdo_adj_with_exp.CheckedChanged += new System.EventHandler(this.rdo_adj_with_exp_CheckedChanged);
            // 
            // rdo_adj_without_exp
            // 
            this.rdo_adj_without_exp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdo_adj_without_exp.AutoSize = true;
            this.rdo_adj_without_exp.Location = new System.Drawing.Point(292, 86);
            this.rdo_adj_without_exp.Name = "rdo_adj_without_exp";
            this.rdo_adj_without_exp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdo_adj_without_exp.Size = new System.Drawing.Size(158, 17);
            this.rdo_adj_without_exp.TabIndex = 159;
            this.rdo_adj_without_exp.TabStop = true;
            this.rdo_adj_without_exp.Text = "جرد كميات بدون تاريخ صلاحيه";
            this.rdo_adj_without_exp.UseVisualStyleBackColor = true;
            this.rdo_adj_without_exp.CheckedChanged += new System.EventHandler(this.rdo_adj_without_exp_CheckedChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Location = new System.Drawing.Point(456, 40);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 13);
            this.labelControl3.TabIndex = 158;
            this.labelControl3.Text = "رقم المخزن";
            // 
            // combo_wars
            // 
            this.combo_wars.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_wars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_wars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combo_wars.FormattingEnabled = true;
            this.combo_wars.Location = new System.Drawing.Point(239, 37);
            this.combo_wars.Name = "combo_wars";
            this.combo_wars.Size = new System.Drawing.Size(211, 21);
            this.combo_wars.TabIndex = 157;
            this.combo_wars.SelectedIndexChanged += new System.EventHandler(this.combo_wars_SelectedIndexChanged);
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.FinishText = "You have successfully completed the  Adjstement Quantity";
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.Size = new System.Drawing.Size(584, 287);
            this.completionWizardPage1.Text = "Completing the Adjstement Quantity";
            // 
            // wizardPage2
            // 
            this.wizardPage2.Controls.Add(this.rdo_with_exp_excel);
            this.wizardPage2.Controls.Add(this.rdo_with_exp_manual);
            this.wizardPage2.Controls.Add(this.rdo_with_excel);
            this.wizardPage2.Controls.Add(this.rdo_manual);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(769, 276);
            // 
            // rdo_with_exp_excel
            // 
            this.rdo_with_exp_excel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdo_with_exp_excel.AutoSize = true;
            this.rdo_with_exp_excel.Location = new System.Drawing.Point(296, 74);
            this.rdo_with_exp_excel.Name = "rdo_with_exp_excel";
            this.rdo_with_exp_excel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdo_with_exp_excel.Size = new System.Drawing.Size(151, 17);
            this.rdo_with_exp_excel.TabIndex = 164;
            this.rdo_with_exp_excel.TabStop = true;
            this.rdo_with_exp_excel.Text = "استيراد ملف الجرد بالكسيل";
            this.rdo_with_exp_excel.UseVisualStyleBackColor = true;
            // 
            // rdo_with_exp_manual
            // 
            this.rdo_with_exp_manual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdo_with_exp_manual.AutoSize = true;
            this.rdo_with_exp_manual.Location = new System.Drawing.Point(341, 41);
            this.rdo_with_exp_manual.Name = "rdo_with_exp_manual";
            this.rdo_with_exp_manual.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdo_with_exp_manual.Size = new System.Drawing.Size(106, 17);
            this.rdo_with_exp_manual.TabIndex = 163;
            this.rdo_with_exp_manual.TabStop = true;
            this.rdo_with_exp_manual.Text = "ادخال الجرد يدوي ";
            this.rdo_with_exp_manual.UseVisualStyleBackColor = true;
            // 
            // rdo_with_excel
            // 
            this.rdo_with_excel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdo_with_excel.AutoSize = true;
            this.rdo_with_excel.Location = new System.Drawing.Point(341, 74);
            this.rdo_with_excel.Name = "rdo_with_excel";
            this.rdo_with_excel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdo_with_excel.Size = new System.Drawing.Size(151, 17);
            this.rdo_with_excel.TabIndex = 162;
            this.rdo_with_excel.TabStop = true;
            this.rdo_with_excel.Text = "استيراد ملف الجرد بالكسيل";
            this.rdo_with_excel.UseVisualStyleBackColor = true;
            // 
            // rdo_manual
            // 
            this.rdo_manual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdo_manual.AutoSize = true;
            this.rdo_manual.Location = new System.Drawing.Point(386, 41);
            this.rdo_manual.Name = "rdo_manual";
            this.rdo_manual.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdo_manual.Size = new System.Drawing.Size(106, 17);
            this.rdo_manual.TabIndex = 161;
            this.rdo_manual.TabStop = true;
            this.rdo_manual.Text = "ادخال الجرد يدوي ";
            this.rdo_manual.UseVisualStyleBackColor = true;
            // 
            // wizardPage3
            // 
            this.wizardPage3.Controls.Add(this.labelControl6);
            this.wizardPage3.Controls.Add(this.test_btn);
            this.wizardPage3.Name = "wizardPage3";
            this.wizardPage3.Size = new System.Drawing.Size(769, 276);
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl6.Location = new System.Drawing.Point(202, 107);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(170, 13);
            this.labelControl6.TabIndex = 166;
            this.labelControl6.Text = "برجاء الدخول الي الشاشه لعمل الجرد";
            // 
            // test_btn
            // 
            this.test_btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.test_btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.test_btn.ImageOptions.Image = global::f1.Properties.Resources.inv10;
            this.test_btn.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.test_btn.Location = new System.Drawing.Point(412, 93);
            this.test_btn.Name = "test_btn";
            this.test_btn.Size = new System.Drawing.Size(124, 41);
            this.test_btn.TabIndex = 165;
            this.test_btn.Text = "الجرد";
            this.test_btn.Click += new System.EventHandler(this.test_btn_Click);
            // 
            // btn_delete_file
            // 
            this.btn_delete_file.Caption = "حذف + Delete";
            this.btn_delete_file.Enabled = false;
            this.btn_delete_file.Id = 6;
            this.btn_delete_file.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_delete_file.ImageOptions.Image")));
            this.btn_delete_file.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_delete_file.ImageOptions.LargeImage")));
            this.btn_delete_file.Name = "btn_delete_file";
            // 
            // frm_wizard_adjustment_qty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 419);
            this.Controls.Add(this.wizardControl1);
            this.Name = "frm_wizard_adjustment_qty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_wizard_adjustment_qty";
            this.Load += new System.EventHandler(this.frm_wizard_adjustment_qty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.welcomeWizardPage1.ResumeLayout(false);
            this.welcomeWizardPage1.PerformLayout();
            this.wizardPage1.ResumeLayout(false);
            this.wizardPage1.PerformLayout();
            this.wizardPage2.ResumeLayout(false);
            this.wizardPage2.PerformLayout();
            this.wizardPage3.ResumeLayout(false);
            this.wizardPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public System.Windows.Forms.ComboBox combo_wars;
        private System.Windows.Forms.RadioButton rdo_adj_with_exp;
        private System.Windows.Forms.RadioButton rdo_adj_without_exp;
        private DevExpress.XtraWizard.WizardPage wizardPage2;
        private System.Windows.Forms.RadioButton rdo_with_exp_excel;
        private System.Windows.Forms.RadioButton rdo_with_exp_manual;
        private System.Windows.Forms.RadioButton rdo_with_excel;
        private System.Windows.Forms.RadioButton rdo_manual;
        private DevExpress.XtraBars.BarButtonItem btn_delete_file;
        private DevExpress.XtraWizard.WizardPage wizardPage3;
        private DevExpress.XtraEditors.SimpleButton test_btn;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.CheckBox chk_intro;
    }
}