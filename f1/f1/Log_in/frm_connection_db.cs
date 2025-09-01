using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using f1.Properties;
using f1.Classes;
using System.IO;
using System.Data.SqlClient;

namespace f1.Log_in
{
    public partial class frm_connection_db : DevExpress.XtraEditors.XtraForm
    {
        public frm_connection_db()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            f1.Properties.Settings.Default.server = this.txt_server.Text;
            Settings.Default.sql_name = this.txt_user_Sql.Text;
            Settings.Default.sql_pass = this.txt_pass_sql.Text;
            Settings.Default.db_base = this.combo_db.Text;
            Settings.Default.Save();

            string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", new object[4]
      {
        (object) this.txt_server.Text,
        (object) this.combo_db.Text,
        (object) this.txt_user_Sql.Text,
        (object) this.txt_pass_sql.Text
      });
            try
            {
                if (new SqlHelper(connectionString).IsConnection)
                {
                    new AppSetting().SaveConnectionString("cn", connectionString);
                    int num = (int)MessageBox.Show("Your connection string has been successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                db.log_error(string.Concat((object)ex));
            }
            Application.Exit();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.txt_server.Text = Settings.Default.server;
            this.txt_user_Sql.Text = Settings.Default.sql_name;
            this.txt_pass_sql.Text = Settings.Default.sql_pass;
            this.combo_db.Text = Settings.Default.db_base;
        }

        private void Label6_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", new object[4]
      {
        (object) this.txt_server.Text,
        (object) this.combo_db.Text,
        (object) this.txt_user_Sql.Text,
        (object) this.txt_pass_sql.Text
      });
            try
            {
                if (!new SqlHelper(connectionString).IsConnection)
                    return;
                int num = (int)MessageBox.Show("Test connection succeeded.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                db.log_error(string.Concat((object)ex));
            }
        }
        public static string strdb = "";
        private void Combo_db_SelectedIndexChanged(object sender, EventArgs e)
        {
            frm_connection_db.strdb = combo_db.Text;
            
        }
        private void load_db()
        {
            StreamReader streamReader = new StreamReader("data.txt");
            for (string str = streamReader.ReadLine(); str != null; str = streamReader.ReadLine())
                this.combo_db.Items.Add((object)str);
            streamReader.Close();

        }

        private void Frm_connection_db_Load(object sender, EventArgs e)
        {
            load_db();
            txt_server.Text = Settings.Default.server;
            txt_user_Sql.Text = Settings.Default.sql_name;
            txt_pass_sql.Text = Settings.Default.sql_pass;
            combo_db.Text = Settings.Default.db_base;
        }
        public static string dbnamer;
        public static string ipr;
        public static string sql_passr;
        public static string sql_userr;
        public static string DBxxr;
        public static SqlConnection connr;
        public static SqlCommand cmdr;
        public void con()
        {
            dbnamer = "master";
            ipr = txt_server.Text;
            sql_passr = txt_pass_sql.Text;
            sql_userr = txt_user_Sql.Text;
            DBxxr = "Data Source=" + ipr + " ;Initial Catalog=" + dbnamer + " ;Integrated Security=False ; USER ID='" + sql_userr + "' ; Password='" + sql_passr + "'";
            connr = new SqlConnection(DBxxr);
            cmdr = new SqlCommand("", connr);
        }
        public  static void Open(ref string error)
        {
            
            try
            {
                if (connr.State != ConnectionState.Closed)
                {
                    error = "فشل الاتصال";
                    return;

                }
                connr.Open();
            }
            catch (Exception ex)
            {
                error = "فشل الاتصال";
               // MessageBox.Show(ex.Message + "  \n  من فضلك اغلف البرنامج وافتحه تاني و اختار الداتا بيز الصح  \n", "خطاء");
            }
        }
        public static void Open()
        {
            
            try
            {
                if (connr.State != ConnectionState.Closed)
                {
                    return;

                }
                connr.Open();
            }
            catch (Exception ex)
            {
            }
        }
        public static DataTable GetData(string select)
        {
            DataTable dataTable = new DataTable();
            cmdr.CommandText = select;
            dataTable.Load(cmdr.ExecuteReader());
            return dataTable;
        }
        public static void Run(string SQL)
        {
            cmdr.CommandText = SQL;
            cmdr.ExecuteNonQuery();
        }
        private void lbl_restor_Click(object sender, EventArgs e)
        {
            string error = "";
            con();
            Open(ref error);
            if (error!="")
            {
                MessageBox.Show(error);
                return;
            }
            frm_restore f = new frm_restore();
            f.ShowDialog();
        }
    }
}