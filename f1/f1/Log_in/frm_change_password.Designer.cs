namespace f1.Log_in
{
    partial class frm_change_password
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
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_pass1 = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_pass2 = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txt_pass1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_pass2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_exit.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_exit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_exit.Location = new System.Drawing.Point(191, 233);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(130, 54);
            this.btn_exit.TabIndex = 86;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Save.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Save.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Save.Location = new System.Drawing.Point(41, 233);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(130, 54);
            this.btn_Save.TabIndex = 85;
            this.btn_Save.Text = "save";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(-1, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(396, 51);
            this.label1.TabIndex = 95;
            this.label1.Text = "Change Password";
            // 
            // txt_pass1
            // 
            this.txt_pass1.EditValue = "";
            this.txt_pass1.Location = new System.Drawing.Point(138, 117);
            this.txt_pass1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_pass1.Name = "txt_pass1";
            this.txt_pass1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_pass1.Properties.Appearance.Options.UseFont = true;
            this.txt_pass1.Properties.PasswordChar = '*';
            this.txt_pass1.Size = new System.Drawing.Size(223, 28);
            this.txt_pass1.TabIndex = 99;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(8, 121);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 21);
            this.label3.TabIndex = 96;
            this.label3.Text = "New PassWord:";
            // 
            // txt_pass2
            // 
            this.txt_pass2.EditValue = "";
            this.txt_pass2.Location = new System.Drawing.Point(138, 170);
            this.txt_pass2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_pass2.Name = "txt_pass2";
            this.txt_pass2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_pass2.Properties.Appearance.Options.UseFont = true;
            this.txt_pass2.Properties.PasswordChar = '*';
            this.txt_pass2.Size = new System.Drawing.Size(223, 28);
            this.txt_pass2.TabIndex = 101;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(8, 174);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 21);
            this.label4.TabIndex = 100;
            this.label4.Text = "New Password:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label7.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label7.Location = new System.Drawing.Point(-9, 66);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(370, 21);
            this.label7.TabIndex = 122;
            this.label7.Text = "________________________________________";
            // 
            // frm_change_password
            // 
            this.Appearance.BackColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 303);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_pass2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_pass1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_change_password";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_change_password";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.txt_pass1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_pass2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txt_pass1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txt_pass2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
    }
}