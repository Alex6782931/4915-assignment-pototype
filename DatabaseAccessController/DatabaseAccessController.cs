using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DatabaseAccessController
{
    public class DatabaseController
    {
        private String connectionString { get; set; }

        public DatabaseController(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public DataTable GetData(String sqlCmd)
        {
            // Create the connection (and be sure to dispose it at the end)
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    // Open the connection to the database. 
                    // This is the first critical step in the process.
                    conn.Open();
                    MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, conn);
                    DataTable dt = new DataTable();
                    adr.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                    //log the error 
                }
            }
        }

    }

}
