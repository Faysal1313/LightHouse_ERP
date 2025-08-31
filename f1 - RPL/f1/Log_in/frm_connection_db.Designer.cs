namespace f1.Log_in
{
    partial class frm_connection_db
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
            this.button1 = new System.Windows.Forms.Button();
            this.btn_login = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_pass_sql = new System.Windows.Forms.TextBox();
            this.txt_user_Sql = new System.Windows.Forms.TextBox();
            this.txt_server = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.combo_db = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_restor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(169, 288);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 52);
            this.button1.TabIndex = 37;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_login.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_login.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_login.Location = new System.Drawing.Point(49, 288);
            this.btn_login.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(104, 52);
            this.btn_login.TabIndex = 36;
            this.btn_login.Text = "Save";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 19F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 39);
            this.label1.TabIndex = 38;
            this.label1.Text = "Connection Setting";
            // 
            // txt_pass_sql
            // 
            this.txt_pass_sql.Location = new System.Drawing.Point(149, 239);
            this.txt_pass_sql.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_pass_sql.Name = "txt_pass_sql";
            this.txt_pass_sql.PasswordChar = '*';
            this.txt_pass_sql.Size = new System.Drawing.Size(150, 24);
            this.txt_pass_sql.TabIndex = 44;
            // 
            // txt_user_Sql
            // 
            this.txt_user_Sql.Location = new System.Drawing.Point(149, 204);
            this.txt_user_Sql.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_user_Sql.Name = "txt_user_Sql";
            this.txt_user_Sql.Size = new System.Drawing.Size(150, 24);
            this.txt_user_Sql.TabIndex = 43;
            // 
            // txt_server
            // 
            this.txt_server.Location = new System.Drawing.Point(149, 170);
            this.txt_server.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_server.Name = "txt_server";
            this.txt_server.Size = new System.Drawing.Size(150, 24);
            this.txt_server.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(26, 244);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 41;
            this.label3.Text = "Pass SQL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(26, 209);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 40;
            this.label2.Text = "User SQL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label4.Location = new System.Drawing.Point(26, 174);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 39;
            this.label4.Text = "Server Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label5.Location = new System.Drawing.Point(287, 150);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 17);
            this.label5.TabIndex = 45;
            this.label5.Text = "get";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(2, 127);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(321, 24);
            this.textBox1.TabIndex = 46;
            this.textBox1.Visible = false;
            // 
            // combo_db
            // 
            this.combo_db.FormattingEnabled = true;
            this.combo_db.Location = new System.Drawing.Point(149, 94);
            this.combo_db.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.combo_db.Name = "combo_db";
            this.combo_db.Size = new System.Drawing.Size(160, 24);
            this.combo_db.TabIndex = 47;
            this.combo_db.SelectedIndexChanged += new System.EventHandler(this.Combo_db_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label6.Location = new System.Drawing.Point(14, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 17);
            this.label6.TabIndex = 48;
            this.label6.Text = "test";
            this.label6.Click += new System.EventHandler(this.Label6_Click);
            // 
            // lbl_restor
            // 
            this.lbl_restor.AutoSize = true;
            this.lbl_restor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_restor.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lbl_restor.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_restor.Location = new System.Drawing.Point(14, 87);
            this.lbl_restor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_restor.Name = "lbl_restor";
            this.lbl_restor.Size = new System.Drawing.Size(48, 17);
            this.lbl_restor.TabIndex = 49;
            this.lbl_restor.Text = "Restor";
            this.lbl_restor.Click += new System.EventHandler(this.lbl_restor_Click);
            // 
            // frm_connection_db
            // 
            this.Appearance.BackColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 358);
            this.Controls.Add(this.lbl_restor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.combo_db);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_pass_sql);
            this.Controls.Add(this.txt_user_Sql);
            this.Controls.Add(this.txt_server);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_connection_db";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_connection_db";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Frm_connection_db_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox combo_db;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_restor;
        public System.Windows.Forms.TextBox txt_pass_sql;
        public System.Windows.Forms.TextBox txt_user_Sql;
        public System.Windows.Forms.TextBox txt_server;
    }
}