namespace f1
{
    partial class frm_send_email
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_send_email));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txt_from_email = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_TO = new System.Windows.Forms.TextBox();
            this.txt_subject = new System.Windows.Forms.TextBox();
            this.txt_message_bode = new System.Windows.Forms.TextBox();
            this.txt_attach = new System.Windows.Forms.TextBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_send = new DevExpress.XtraEditors.SimpleButton();
            this.combo_email = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(38, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Email ID";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(255, 38);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Password";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 74);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(12, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "To";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(8, 113);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Subject";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(8, 163);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(69, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Message Body";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(8, 326);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(32, 13);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Attach";
            // 
            // txt_from_email
            // 
            this.txt_from_email.Location = new System.Drawing.Point(52, 35);
            this.txt_from_email.Name = "txt_from_email";
            this.txt_from_email.Size = new System.Drawing.Size(190, 20);
            this.txt_from_email.TabIndex = 6;
            this.txt_from_email.Text = "m.faysal.ajeal13@gmail.com";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(307, 35);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(139, 20);
            this.txt_password.TabIndex = 7;
            this.txt_password.Text = "asdfghjkl_13";
            // 
            // txt_TO
            // 
            this.txt_TO.Location = new System.Drawing.Point(52, 74);
            this.txt_TO.Name = "txt_TO";
            this.txt_TO.Size = new System.Drawing.Size(132, 20);
            this.txt_TO.TabIndex = 8;
            this.txt_TO.Text = "faysal131313";
            // 
            // txt_subject
            // 
            this.txt_subject.Location = new System.Drawing.Point(52, 110);
            this.txt_subject.Name = "txt_subject";
            this.txt_subject.Size = new System.Drawing.Size(394, 20);
            this.txt_subject.TabIndex = 9;
            this.txt_subject.Text = "hi";
            // 
            // txt_message_bode
            // 
            this.txt_message_bode.Location = new System.Drawing.Point(52, 182);
            this.txt_message_bode.Multiline = true;
            this.txt_message_bode.Name = "txt_message_bode";
            this.txt_message_bode.Size = new System.Drawing.Size(394, 129);
            this.txt_message_bode.TabIndex = 10;
            this.txt_message_bode.Text = "hi test";
            // 
            // txt_attach
            // 
            this.txt_attach.Location = new System.Drawing.Point(46, 323);
            this.txt_attach.Name = "txt_attach";
            this.txt_attach.Size = new System.Drawing.Size(352, 20);
            this.txt_attach.TabIndex = 11;
            this.txt_attach.Text = "D:\\light houes\\vendor.png";
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.simpleButton1.Location = new System.Drawing.Point(404, 321);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(41, 23);
            this.simpleButton1.TabIndex = 12;
            this.simpleButton1.Text = "...";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btn_send
            // 
            this.btn_send.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btn_send.Image = ((System.Drawing.Image)(resources.GetObject("btn_send.Image")));
            this.btn_send.Location = new System.Drawing.Point(184, 367);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(89, 30);
            this.btn_send.TabIndex = 13;
            this.btn_send.Text = "Send";
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // combo_email
            // 
            this.combo_email.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_email.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_email.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combo_email.FormattingEnabled = true;
            this.combo_email.Items.AddRange(new object[] {
            "@gmail.com",
            "@hotmail.com",
            "@yahoo.com"});
            this.combo_email.Location = new System.Drawing.Point(190, 74);
            this.combo_email.Name = "combo_email";
            this.combo_email.Size = new System.Drawing.Size(101, 21);
            this.combo_email.TabIndex = 14;
            // 
            // frm_send_email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 420);
            this.Controls.Add(this.combo_email);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txt_attach);
            this.Controls.Add(this.txt_message_bode);
            this.Controls.Add(this.txt_subject);
            this.Controls.Add(this.txt_TO);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_from_email);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "frm_send_email";
            this.Text = "frm_send_email";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.TextBox txt_from_email;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_TO;
        private System.Windows.Forms.TextBox txt_subject;
        private System.Windows.Forms.TextBox txt_message_bode;
        private System.Windows.Forms.TextBox txt_attach;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btn_send;
        private System.Windows.Forms.ComboBox combo_email;
    }
}