namespace f1.pos
{
    partial class frm_settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_settings));
            this.btn_permission = new DevExpress.XtraEditors.SimpleButton();
            this.btn_expenses_employee = new DevExpress.XtraEditors.SimpleButton();
            this.btn_desgin_report = new DevExpress.XtraEditors.SimpleButton();
            this.btn_backup = new DevExpress.XtraEditors.SimpleButton();
            this.btn_pos_settings = new DevExpress.XtraEditors.SimpleButton();
            this.btn_info_comp = new DevExpress.XtraEditors.SimpleButton();
            this.btn_emp = new DevExpress.XtraEditors.SimpleButton();
            this.btn_opening_bal = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btn_permission
            // 
            this.btn_permission.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_permission.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_permission.ImageOptions.SvgImage")));
            this.btn_permission.Location = new System.Drawing.Point(12, 190);
            this.btn_permission.Name = "btn_permission";
            this.btn_permission.Size = new System.Drawing.Size(171, 34);
            this.btn_permission.TabIndex = 12;
            this.btn_permission.Text = "صلاحيات المستخدمين";
            this.btn_permission.Click += new System.EventHandler(this.btn_permission_Click);
            // 
            // btn_expenses_employee
            // 
            this.btn_expenses_employee.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.btn_expenses_employee.Appearance.Options.UseFont = true;
            this.btn_expenses_employee.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_expenses_employee.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_expenses_employee.ImageOptions.Image")));
            this.btn_expenses_employee.Location = new System.Drawing.Point(9, 107);
            this.btn_expenses_employee.Name = "btn_expenses_employee";
            this.btn_expenses_employee.Size = new System.Drawing.Size(171, 34);
            this.btn_expenses_employee.TabIndex = 13;
            this.btn_expenses_employee.Text = "شاشة إضافة مصاريف محددة للكاشير";
            this.btn_expenses_employee.ToolTip = "شاشة إضافة مصاريف محددة للكاشير";
            this.btn_expenses_employee.Click += new System.EventHandler(this.btn_expenses_employee_Click);
            // 
            // btn_desgin_report
            // 
            this.btn_desgin_report.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_desgin_report.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_desgin_report.ImageOptions.Image")));
            this.btn_desgin_report.Location = new System.Drawing.Point(12, 331);
            this.btn_desgin_report.Name = "btn_desgin_report";
            this.btn_desgin_report.Size = new System.Drawing.Size(171, 34);
            this.btn_desgin_report.TabIndex = 11;
            this.btn_desgin_report.Text = "تصميم تقارير";
            this.btn_desgin_report.Click += new System.EventHandler(this.Btn_desgin_report_Click);
            // 
            // btn_backup
            // 
            this.btn_backup.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_backup.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_backup.ImageOptions.Image")));
            this.btn_backup.Location = new System.Drawing.Point(12, 284);
            this.btn_backup.Name = "btn_backup";
            this.btn_backup.Size = new System.Drawing.Size(171, 34);
            this.btn_backup.TabIndex = 10;
            this.btn_backup.Text = "عمل نسخه إحتياطية";
            this.btn_backup.Click += new System.EventHandler(this.Btn_backup_Click);
            // 
            // btn_pos_settings
            // 
            this.btn_pos_settings.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_pos_settings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_pos_settings.ImageOptions.Image")));
            this.btn_pos_settings.Location = new System.Drawing.Point(12, 237);
            this.btn_pos_settings.Name = "btn_pos_settings";
            this.btn_pos_settings.Size = new System.Drawing.Size(171, 34);
            this.btn_pos_settings.TabIndex = 9;
            this.btn_pos_settings.Text = "إعدادات ملف الخزن";
            this.btn_pos_settings.Click += new System.EventHandler(this.Btn_pos_settings_Click);
            // 
            // btn_info_comp
            // 
            this.btn_info_comp.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_info_comp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_info_comp.ImageOptions.Image")));
            this.btn_info_comp.Location = new System.Drawing.Point(12, 59);
            this.btn_info_comp.Name = "btn_info_comp";
            this.btn_info_comp.Size = new System.Drawing.Size(171, 34);
            this.btn_info_comp.TabIndex = 8;
            this.btn_info_comp.Text = "معلومات الشركة";
            this.btn_info_comp.Click += new System.EventHandler(this.Btn_info_comp_Click);
            // 
            // btn_emp
            // 
            this.btn_emp.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_emp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_emp.ImageOptions.Image")));
            this.btn_emp.Location = new System.Drawing.Point(12, 12);
            this.btn_emp.Name = "btn_emp";
            this.btn_emp.Size = new System.Drawing.Size(171, 34);
            this.btn_emp.TabIndex = 7;
            this.btn_emp.Text = "تكويد موظف";
            this.btn_emp.Click += new System.EventHandler(this.Btn_emp_Click);
            // 
            // btn_opening_bal
            // 
            this.btn_opening_bal.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btn_opening_bal.Appearance.Options.UseFont = true;
            this.btn_opening_bal.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_opening_bal.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_opening_bal.ImageOptions.SvgImage")));
            this.btn_opening_bal.Location = new System.Drawing.Point(9, 152);
            this.btn_opening_bal.Name = "btn_opening_bal";
            this.btn_opening_bal.Size = new System.Drawing.Size(171, 34);
            this.btn_opening_bal.TabIndex = 14;
            this.btn_opening_bal.Text = "ارصدة افتتاحية";
            this.btn_opening_bal.ToolTip = "شاشة إضافة مصاريف محددة للكاشير";
            this.btn_opening_bal.Click += new System.EventHandler(this.btn_opening_bal_Click);
            // 
            // frm_settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 370);
            this.Controls.Add(this.btn_opening_bal);
            this.Controls.Add(this.btn_expenses_employee);
            this.Controls.Add(this.btn_permission);
            this.Controls.Add(this.btn_desgin_report);
            this.Controls.Add(this.btn_backup);
            this.Controls.Add(this.btn_pos_settings);
            this.Controls.Add(this.btn_info_comp);
            this.Controls.Add(this.btn_emp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الاعدادات";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_emp;
        private DevExpress.XtraEditors.SimpleButton btn_info_comp;
        private DevExpress.XtraEditors.SimpleButton btn_pos_settings;
        private DevExpress.XtraEditors.SimpleButton btn_backup;
        private DevExpress.XtraEditors.SimpleButton btn_desgin_report;
        private DevExpress.XtraEditors.SimpleButton btn_permission;
        private DevExpress.XtraEditors.SimpleButton btn_expenses_employee;
        private DevExpress.XtraEditors.SimpleButton btn_opening_bal;
    }
}