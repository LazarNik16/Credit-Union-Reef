using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CUReef
{
    public class DBManager
    {

        private SqlConnection connection;
        private SqlCommand cmd;
        private DataTable dt;

        public DBManager()
        {
            connection = new SqlConnection(@"Server=LAZAR-DESKTOP\SQLEXPRESS;Database=DBReef;Trusted_Connection=True;");
            //cmd = new SqlCommand("", connection);
            dt = new DataTable();

        }//end of DBManager constructor 

        public DataTable executeDataTable(string sqlStatement)
        {
            connection.Open();
            cmd.CommandText = sqlStatement;
            dt.Clear();
            dt.Load(cmd.ExecuteReader());
            connection.Close();

            return dt.Copy();

        }//end of executeDataTable function

        public void executeQuery(string sqlStatement, string fname, string lname, long ssn, long phone, DOB dob)
        {
            try
            {
                connection.Open();
                Console.Write($"Connected to the DB\n");

                cmd = new SqlCommand(sqlStatement, connection);
                cmd.Parameters.Add("@Fname")





                int num =cmd.ExecuteNonQuery();

                Console.WriteLine(num + " Record Added to the database");
                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error code: " + e);
            }
        }

    }//end of DBManager class
}//end of namespaceCUREEF
