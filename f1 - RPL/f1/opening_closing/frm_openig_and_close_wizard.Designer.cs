namespace f1.opening_closing
{
    partial class frm_openig_and_close_wizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_openig_and_close_wizard));
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.btn_open_qty_inv = new DevExpress.XtraEditors.SimpleButton();
            this.btn_cus_ven_bal = new DevExpress.XtraEditors.SimpleButton();
            this.btn_open_finaly = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.Controls.Add(this.welcomeWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage1);
            this.wizardControl1.Controls.Add(this.completionWizardPage1);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wizardPage1,
            this.completionWizardPage1});
            this.wizardControl1.Size = new System.Drawing.Size(627, 384);
            this.wizardControl1.FinishClick += new System.ComponentModel.CancelEventHandler(this.wizardControl1_FinishClick);
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.IntroductionText = "مرحب بك لعمل \r\n القيد الافتتاحي برجاء اتباع الخطوات\r\n";
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(410, 251);
            this.welcomeWizardPage1.Text = "Welcome Opening Entry";
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.simpleButton3);
            this.wizardPage1.Controls.Add(this.simpleButton2);
            this.wizardPage1.Controls.Add(this.simpleButton1);
            this.wizardPage1.Controls.Add(this.btn_open_finaly);
            this.wizardPage1.Controls.Add(this.btn_cus_ven_bal);
            this.wizardPage1.Controls.Add(this.btn_open_qty_inv);
            this.wizardPage1.DescriptionText = "من فضلك ادخل البيانات المطلوبه";
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(595, 239);
            this.wizardPage1.Text = "القيود الافتتاحيه";
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.FinishText = "من فضلك اضغط علي زر انهاء للتاكد من سلامه القيد الافتتاحي و لاستكمال العمليه\r\n\r\n";
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.Size = new System.Drawing.Size(410, 251);
            this.completionWizardPage1.Text = "Completing [pleas click Finsh ]";
            // 
            // btn_open_qty_inv
            // 
            this.btn_open_qty_inv.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_open_qty_inv.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btn_open_qty_inv.Image = global::f1.Properties.Resources.inv10;
            this.btn_open_qty_inv.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_open_qty_inv.Location = new System.Drawing.Point(56, 28);
            this.btn_open_qty_inv.Name = "btn_open_qty_inv";
            this.btn_open_qty_inv.Size = new System.Drawing.Size(200, 41);
            this.btn_open_qty_inv.TabIndex = 166;
            this.btn_open_qty_inv.Text = "كميات و تكاليف المخزون";
            this.btn_open_qty_inv.Click += new System.EventHandler(this.btn_open_qty_inv_Click);
            // 
            // btn_cus_ven_bal
            // 
            this.btn_cus_ven_bal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_cus_ven_bal.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btn_cus_ven_bal.Image = global::f1.Properties.Resources.p15;
            this.btn_cus_ven_bal.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_cus_ven_bal.Location = new System.Drawing.Point(56, 75);
            this.btn_cus_ven_bal.Name = "btn_cus_ven_bal";
            this.btn_cus_ven_bal.Size = new System.Drawing.Size(200, 41);
            this.btn_cus_ven_bal.TabIndex = 167;
            this.btn_cus_ven_bal.Text = "رصيد العملاء و الموريدن";
            this.btn_cus_ven_bal.Click += new System.EventHandler(this.btn_cus_ven_bal_Click);
            // 
            // btn_open_finaly
            // 
            this.btn_open_finaly.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_open_finaly.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btn_open_finaly.Image = global::f1.Properties.Resources.acc8;
            this.btn_open_finaly.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_open_finaly.Location = new System.Drawing.Point(56, 122);
            this.btn_open_finaly.Name = "btn_open_finaly";
            this.btn_open_finaly.Size = new System.Drawing.Size(200, 41);
            this.btn_open_finaly.TabIndex = 168;
            this.btn_open_finaly.Text = "القيد الافتتاحي";
            this.btn_open_finaly.Click += new System.EventHandler(this.btn_open_finaly_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButton1.Location = new System.Drawing.Point(262, 28);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(38, 41);
            this.simpleButton1.TabIndex = 169;
            this.simpleButton1.Text = "كميات و تكاليف المخزون";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButton2.Location = new System.Drawing.Point(262, 75);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(38, 41);
            this.simpleButton2.TabIndex = 170;
            this.simpleButton2.Text = "كميات و تكاليف المخزون";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.simpleButton3.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.simpleButton3.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.Image")));
            this.simpleButton3.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButton3.Location = new System.Drawing.Point(262, 122);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(38, 41);
            this.simpleButton3.TabIndex = 171;
            this.simpleButton3.Text = "كميات و تكاليف المخزون";
            // 
            // frm_openig_and_close_wizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 384);
            this.Controls.Add(this.wizardControl1);
            this.Name = "frm_openig_and_close_wizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_openig_and_close_wizard";
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.wizardPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btn_open_finaly;
        private DevExpress.XtraEditors.SimpleButton btn_cus_ven_bal;
        private DevExpress.XtraEditors.SimpleButton btn_open_qty_inv;
    }
}