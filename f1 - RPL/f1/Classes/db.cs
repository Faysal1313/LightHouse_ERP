
using f1.Log_in;
using f1.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace f1
{
    class db
    {
        public static string dbname;
        public static string ip;
        public static string sql_pass;
        public static string sql_user;
        public static string DBxx;
        public static SqlConnection conn;
        public static SqlCommand cmd;

        static db()
        {
            db.dbname = frm_login.strdb;
            db.ip = Settings.Default.server;
            db.sql_pass = Settings.Default.sql_pass;
            db.sql_user = Settings.Default.sql_name;
            db.DBxx = "Data Source=" + db.ip + " ;Initial Catalog=" + db.dbname + " ;Integrated Security=False ; USER ID='" + db.sql_user + "' ; Password='" + db.sql_pass + "'";
            db.conn = new SqlConnection(db.DBxx);
            db.cmd = new SqlCommand("", db.conn);
        }



        public static void Open()
        {
            try
            {
                if (db.conn.State != ConnectionState.Closed)
                    return;
                db.conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "       \n  من فضلك اغلف البرنامج وافتحه تاني و اختار الداتا بيز الصح  \n", "خطاء");
                db.log_error(string.Concat(ex));
            }
        }

        public static void Close()
        {
            if (db.conn.State != ConnectionState.Open)
                return;
            db.conn.Close();
        }

        public static DataTable GetData(string select)

        {
            DataTable dataTable = new DataTable();
            db.cmd.CommandText = select;
            dataTable.Load(cmd.ExecuteReader());
            return dataTable;
        }
        public static DataTable GetData2(string select)

        {
            DataTable dataTable = new DataTable();
            db.cmd.CommandText = select;
            dataTable.Load(cmd.ExecuteReader());
            return dataTable;
        }
        public static DataTable GetData_for_log(string select)
        {
            DataTable dataTable = new DataTable();
            db.cmd.CommandText = select;
            dataTable.Load(cmd.ExecuteReader());
            return dataTable;
        }

        public static void GetData_DGV(string select, DataTable tb)
        {
            try
            {
                db.cmd.CommandText = select;
                tb.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.log_error(string.Concat(ex));
            }
        }

        public static void Run(string SQL)
        {
            db.cmd.CommandText = SQL;
            db.cmd.ExecuteNonQuery();
            db.log_error(SQL ?? "");
        }
        public static void action_insert(string action_descrpion, string number_record)
        {
            Run("insert into action(emp_code,user_name,action,[state],[date],[time],number_record)values('" + v.usercode + "','" + v.usercode + "','   " + action_descrpion + "  ','insert',getdate(),CAST(GETDATE() AS TIME),'" + number_record + "')");
        }
        public static void action_delete(string action_descrpion, string number_record)
        {
            Run("insert into action(emp_code,user_name,action,[state],[date],[time],number_record)values('" + v.usercode + "','" + v.usercode + "','   " + action_descrpion + "  ','delete',getdate(),CAST(GETDATE() AS TIME),'" + number_record + "')");
        }
        public static void wright(string txt)
        {
            StreamWriter streamWriter = new StreamWriter("data.txt", true);
            streamWriter.WriteLine(txt);
            streamWriter.Close();
        }
        public static void create_txt_inEinv(string NameFile,string txt)
        {
            try
            {
                if (File.Exists(NameFile+ ".txt")) File.Delete(NameFile+ ".txt");
                FileStream fs = File.Create(@"Einvoice\" + NameFile + ".txt");
                fs.Close();
                StreamWriter streamWriter = new StreamWriter(@"Einvoice\" + NameFile + ".txt",true);
                streamWriter.WriteLine(txt);
                streamWriter.Close();
            }
            catch (Exception)
            {


            }
        }
        public static void log_error(string error)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<<" + DateTime.Now + ">> \n \t" + error + "\n \t");
            File.AppendAllText("log.txt", (stringBuilder).ToString());
        }


    }
}
