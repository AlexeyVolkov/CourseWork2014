using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace DBLibrary
{
    public class Class1
    {
    }
    public class ManagerClass
    {
        string connectionString = "";
        public string ConsStr
        {
            get
            {
                return connectionString;
            }
            set
            {
                connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + value + ";Integrated Security=True;Connect Timeout=30;User Instance=True";
            }
        }
        public ManagerClass(string dbpath)
        {
            ConsStr = dbpath;
        }
        public string ExecSQL(string query)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConsStr))
                {
                    conn.Open();
                    using (SqlCommand c = new SqlCommand(query))
                    {
                        c.Connection = conn;
                        c.ExecuteNonQuery();
                    }
                }
                return "Execution completed sucsessful";
            }
            catch (Exception exp)
            {
                return "Excecution error: " + exp.Message;
            }
        }
    }
}
