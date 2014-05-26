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
        private string ConsStr = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Алексей\Documents\SourceTree\CourseWork2014\Files\Database\cars.mdf;Integrated Security=True;Connect Timeout=30";

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
