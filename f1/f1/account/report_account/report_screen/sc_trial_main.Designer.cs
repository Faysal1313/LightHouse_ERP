
namespace f1.account.report_account.report_screen
{
    partial class sc_trial_main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sc_trial_main));
            this.btn_3 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_2 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_1 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btn_3
            // 
            this.btn_3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_3.Appearance.Options.UseFont = true;
            this.btn_3.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_3.ImageOptions.Image")));
            this.btn_3.Location = new System.Drawing.Point(12, 138);
            this.btn_3.Name = "btn_3";
            this.btn_3.Size = new System.Drawing.Size(192, 32);
            this.btn_3.TabIndex = 152;
            this.btn_3.Text = "ميزان مراجعة بمركز تكلفة";
            this.btn_3.Click += new System.EventHandler(this.btn_3_Click);
            // 
            // btn_2
            // 
            this.btn_2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_2.Appearance.Options.UseFont = true;
            this.btn_2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_2.ImageOptions.Image")));
            this.btn_2.Location = new System.Drawing.Point(12, 75);
            this.btn_2.Name = "btn_2";
            this.btn_2.Size = new System.Drawing.Size(192, 32);
            this.btn_2.TabIndex = 151;
            this.btn_2.Text = "ميزان مراجعة مطول";
            this.btn_2.Click += new System.EventHandler(this.btn_2_Click);
            // 
            // btn_1
            // 
            this.btn_1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_1.Appearance.Options.UseFont = true;
            this.btn_1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_1.ImageOptions.Image")));
            this.btn_1.Location = new System.Drawing.Point(12, 12);
            this.btn_1.Name = "btn_1";
            this.btn_1.Size = new System.Drawing.Size(192, 32);
            this.btn_1.TabIndex = 150;
            this.btn_1.Text = "ميزان مراجعة مختصر";
            this.btn_1.Click += new System.EventHandler(this.btn_1_Click);
            // 
            // sc_trial_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 207);
            this.Controls.Add(this.btn_3);
            this.Controls.Add(this.btn_2);
            this.Controls.Add(this.btn_1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "sc_trial_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "موازين مراجعة عامة";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_1;
        private DevExpress.XtraEditors.SimpleButton btn_2;
        private DevExpress.XtraEditors.SimpleButton btn_3;
    }
}