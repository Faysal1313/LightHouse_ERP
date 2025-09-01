using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net.Mail;
using System.Net;

namespace f1
{
    public partial class frm_send_email : DevExpress.XtraEditors.XtraForm
    {
        public frm_send_email()
        {
            InitializeComponent();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                string pass = txt_password.Text;
                string email_from = txt_from_email.Text;
                string email_to_ = txt_TO.Text + combo_email.Text;
                if (combo_email.Text== "@gmail.com")
                {
                    string smtp = "smtp.gmail.com";
                    int port = 587;

                    SmtpClient clint = new SmtpClient(smtp, port);

                    clint.Credentials = new System.Net.NetworkCredential(email_from, pass);
                    clint.EnableSsl = true;
                    MailMessage message = new MailMessage(email_from, email_to_, txt_subject.Text, txt_message_bode.Text);
                    message.Attachments.Add(new Attachment(txt_attach.Text));
                    message.IsBodyHtml = false;
                    clint.Send(message);
                    MessageBox.Show("Mail sent....");
                }
                else if (combo_email.Text == "@hotmail.com")
                {
                    string smtp = "smtp.mail.yahoo.com";
                    int port = 587;

                    SmtpClient clint = new SmtpClient(smtp, port);

                    clint.Credentials = new System.Net.NetworkCredential(email_from, pass);
                    clint.EnableSsl = true;
                    MailMessage message = new MailMessage(email_from, email_to_, txt_subject.Text, txt_message_bode.Text);
                    message.Attachments.Add(new Attachment(txt_attach.Text));
                    message.IsBodyHtml = false;
                    clint.Send(message);
                    MessageBox.Show("Mail sent....");
                }
                else if (combo_email.Text == "@yahoo.com")
                {
                    string smtp = "smtp.mail.live.com";
                    int port = 587;

                    SmtpClient clint = new SmtpClient(smtp, port);

                    clint.Credentials = new System.Net.NetworkCredential(email_from, pass);
                    clint.EnableSsl = true;
                    MailMessage message = new MailMessage(email_from, email_to_, txt_subject.Text, txt_message_bode.Text);
                    message.Attachments.Add(new Attachment(txt_attach.Text));
                    message.IsBodyHtml = false;
                    clint.Send(message);
                    MessageBox.Show("Mail sent....");
                }
//                SmtpClient clint = new SmtpClient("smtp.gmail.com", 587);
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}