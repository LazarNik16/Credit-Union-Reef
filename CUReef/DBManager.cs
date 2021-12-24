using System;
using System.Data;
using System.Data.SqlClient;

namespace CUReef
{
    public class DBManager
    {

        private SqlConnection connection;
        private SqlCommand cmd;
        string pkClients;
        string pkAddress;

        public DBManager()
        {
            connection = new SqlConnection(@"Server=LAZAR-DESKTOP\SQLEXPRESS;Database=DBReef;Trusted_Connection=True;");

        }//end of DBManager constructor 

        public void addClient(string sqlStatement, Client client)
        {
            try
            {
                
                cmd = new SqlCommand(sqlStatement, this.connection);

                connection.Open();

                cmd.Parameters.AddWithValue("@Fname", client.Fname);
                cmd.Parameters.AddWithValue("@Lname", client.Lname);
                cmd.Parameters.AddWithValue("@SSN", client.SSN);
                cmd.Parameters.AddWithValue("@DOB", client.Dob);
                cmd.Parameters.AddWithValue("@Phone", client.Phone);

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                pkClients = reader[0].ToString();

                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error code: " + e);
            }
        }//end of addClientToDB function
        public void addAddress(string stmAddAddress, Address address)
        {
            try
            {
                cmd = new SqlCommand(stmAddAddress, this.connection);

                connection.Open();

                cmd.Parameters.AddWithValue("StrNumber", address.StreetNum);
                cmd.Parameters.AddWithValue("StrName", address.StreetName);
                cmd.Parameters.AddWithValue("AptNumber", address.AptNum);
                cmd.Parameters.AddWithValue("City", address.City);
                cmd.Parameters.AddWithValue("State", address.State);
                cmd.Parameters.AddWithValue("ZipCode", address.ZipCode);
                cmd.Parameters.AddWithValue("ClientID", Int32.Parse(pkClients));

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                pkAddress = reader[0].ToString();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error code: " + e);
            }
        }

    }//end of DBManager class
}//end of namespaceCUREEF
