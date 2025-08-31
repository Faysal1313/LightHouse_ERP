
using System.Data;
using System.Data.SqlClient;

namespace f1.Classes
{
    internal class SqlHelper
    {
        private SqlConnection cn;

        public bool IsConnection
        {
            get
            {
                if (this.cn.State == ConnectionState.Closed)
                    this.cn.Open();
                return true;
            }
        }

        public SqlHelper(string connectionString)
        {
           
            this.cn = new SqlConnection(connectionString);
        }
    }
}
