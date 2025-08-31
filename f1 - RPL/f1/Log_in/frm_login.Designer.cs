namespace f1.Log_in
{
    partial class frm_login
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
            this.lbl_connectionString = new System.Windows.Forms.Label();
            this.lbl_changepasword = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_login = new System.Windows.Forms.Button();
            this.lbl_clear = new System.Windows.Forms.Label();
            this.btn_Save_key = new System.Windows.Forms.Button();
            this.txt_incode = new System.Windows.Forms.TextBox();
            this.lbl_hash = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.lbl_db = new System.Windows.Forms.Label();
            this.lbl_user_name = new System.Windows.Forms.Label();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_connectionString
            // 
            this.lbl_connectionString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_connectionString.AutoSize = true;
            this.lbl_connectionString.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_connectionString.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_connectionString.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_connectionString.Location = new System.Drawing.Point(272, 538);
            this.lbl_connectionString.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_connectionString.Name = "lbl_connectionString";
            this.lbl_connectionString.Size = new System.Drawing.Size(141, 17);
            this.lbl_connectionString.TabIndex = 117;
            this.lbl_connectionString.Text = "Connection Setting";
            this.lbl_connectionString.Click += new System.EventHandler(this.Lbl_connectionString_Click);
            // 
            // lbl_changepasword
            // 
            this.lbl_changepasword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_changepasword.AutoSize = true;
            this.lbl_changepasword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_changepasword.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_changepasword.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_changepasword.Location = new System.Drawing.Point(2, 538);
            this.lbl_changepasword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_changepasword.Name = "lbl_changepasword";
            this.lbl_changepasword.Size = new System.Drawing.Size(132, 17);
            this.lbl_changepasword.TabIndex = 116;
            this.lbl_changepasword.Text = "Change Password";
            this.lbl_changepasword.Click += new System.EventHandler(this.Lbl_changepasword_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label8.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label8.Location = new System.Drawing.Point(13, 507);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(370, 21);
            this.label8.TabIndex = 115;
            this.label8.Text = "________________________________________";
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_exit.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_exit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_exit.Location = new System.Drawing.Point(245, 452);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(130, 52);
            this.btn_exit.TabIndex = 114;
            this.btn_exit.Text = "Close";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.Btn_exit_Click);
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_login.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_login.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_login.Location = new System.Drawing.Point(107, 452);
            this.btn_login.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(130, 52);
            this.btn_login.TabIndex = 113;
            this.btn_login.Text = "Log in";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.Btn_login_Click);
            // 
            // lbl_clear
            // 
            this.lbl_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_clear.AutoSize = true;
            this.lbl_clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_clear.Font = new System.Drawing.Font("Tahoma", 7F);
            this.lbl_clear.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_clear.Location = new System.Drawing.Point(343, 566);
            this.lbl_clear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_clear.Name = "lbl_clear";
            this.lbl_clear.Size = new System.Drawing.Size(57, 14);
            this.lbl_clear.TabIndex = 118;
            this.lbl_clear.Text = "Clear Key";
            this.lbl_clear.DoubleClick += new System.EventHandler(this.Lbl_clear_DoubleClick);
            // 
            // btn_Save_key
            // 
            this.btn_Save_key.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Save_key.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Save_key.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btn_Save_key.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Save_key.Location = new System.Drawing.Point(396, 119);
            this.btn_Save_key.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Save_key.Name = "btn_Save_key";
            this.btn_Save_key.Size = new System.Drawing.Size(16, 23);
            this.btn_Save_key.TabIndex = 124;
            this.btn_Save_key.Text = "+";
            this.btn_Save_key.UseVisualStyleBackColor = false;
            this.btn_Save_key.Click += new System.EventHandler(this.Btn_Save_key_Click);
            // 
            // txt_incode
            // 
            this.txt_incode.Location = new System.Drawing.Point(146, 119);
            this.txt_incode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_incode.Name = "txt_incode";
            this.txt_incode.Size = new System.Drawing.Size(242, 24);
            this.txt_incode.TabIndex = 123;
            // 
            // lbl_hash
            // 
            this.lbl_hash.AutoSize = true;
            this.lbl_hash.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lbl_hash.ForeColor = System.Drawing.Color.Red;
            this.lbl_hash.Location = new System.Drawing.Point(145, 80);
            this.lbl_hash.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_hash.Name = "lbl_hash";
            this.lbl_hash.Size = new System.Drawing.Size(19, 21);
            this.lbl_hash.TabIndex = 122;
            this.lbl_hash.Text = "0";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label7.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label7.Location = new System.Drawing.Point(10, 159);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(370, 21);
            this.label7.TabIndex = 121;
            this.label7.Text = "________________________________________";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::f1.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 120;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 40F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(133, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 81);
            this.label1.TabIndex = 119;
            this.label1.Text = "LOG IN";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label5.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label5.Location = new System.Drawing.Point(14, 222);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 21);
            this.label5.TabIndex = 128;
            this.label5.Text = "Data Base:\r\n";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(14, 364);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 21);
            this.label4.TabIndex = 127;
            this.label4.Text = "Password:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(10, 315);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 21);
            this.label3.TabIndex = 125;
            this.label3.Text = "User Name:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(14, 263);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 21);
            this.label2.TabIndex = 126;
            this.label2.Text = "User Code:\r\n";
            // 
            // txt_code
            // 
            this.txt_code.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txt_code.Location = new System.Drawing.Point(110, 263);
            this.txt_code.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new System.Drawing.Size(285, 28);
            this.txt_code.TabIndex = 129;
            this.txt_code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_code_KeyDown);
            this.txt_code.Leave += new System.EventHandler(this.txt_code_Leave);
            // 
            // lbl_db
            // 
            this.lbl_db.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_db.AutoSize = true;
            this.lbl_db.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_db.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbl_db.Location = new System.Drawing.Point(107, 222);
            this.lbl_db.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_db.Name = "lbl_db";
            this.lbl_db.Size = new System.Drawing.Size(21, 21);
            this.lbl_db.TabIndex = 130;
            this.lbl_db.Text = "0";
            // 
            // lbl_user_name
            // 
            this.lbl_user_name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_user_name.AutoSize = true;
            this.lbl_user_name.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lbl_user_name.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbl_user_name.Location = new System.Drawing.Point(102, 315);
            this.lbl_user_name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_user_name.Name = "lbl_user_name";
            this.lbl_user_name.Size = new System.Drawing.Size(19, 21);
            this.lbl_user_name.TabIndex = 131;
            this.lbl_user_name.Text = "0";
            this.lbl_user_name.TextChanged += new System.EventHandler(this.lbl_user_name_TextChanged);
            // 
            // txt_pass
            // 
            this.txt_pass.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txt_pass.Location = new System.Drawing.Point(110, 359);
            this.txt_pass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.PasswordChar = '*';
            this.txt_pass.Size = new System.Drawing.Size(285, 28);
            this.txt_pass.TabIndex = 132;
            this.txt_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_pass_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label6.Location = new System.Drawing.Point(1, 149);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 17);
            this.label6.TabIndex = 133;
            this.label6.Text = "LightHouse ERP system";
            // 
            // frm_login
            // 
            this.Appearance.BackColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 585);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.lbl_user_name);
            this.Controls.Add(this.lbl_db);
            this.Controls.Add(this.txt_code);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Save_key);
            this.Controls.Add(this.txt_incode);
            this.Controls.Add(this.lbl_hash);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_clear);
            this.Controls.Add(this.lbl_connectionString);
            this.Controls.Add(this.lbl_changepasword);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_login";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOG IN LIGHTHOUSE ERP";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Frm_login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_connectionString;
        private System.Windows.Forms.Label lbl_changepasword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label lbl_clear;
        private System.Windows.Forms.Button btn_Save_key;
        private System.Windows.Forms.TextBox txt_incode;
        private System.Windows.Forms.Label lbl_hash;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_db;
        private System.Windows.Forms.Label lbl_user_name;
        private System.Windows.Forms.TextBox txt_pass;
        public System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Label label6;
    }
}