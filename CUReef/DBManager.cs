using System;
using System.Data;
using System.Data.SqlClient;

namespace CUReef
{
    public class DBManager
    {

        private SqlConnection connection;
        private SqlCommand cmd;
        int pkClients;
        int pkAddress;

        public DBManager()
        {
            connection = new SqlConnection(@"Server=LAZAR-DESKTOP\SQLEXPRESS;Database=DBReef;Trusted_Connection=True;");

        }//end of DBManager constructor 

        public void addClient(string sqlStatement, Client client)
        {
            try
            {
                cmd = new SqlCommand(sqlStatement, this.connection);
                
                cmd.Parameters.AddWithValue("@Fname", client.Fname);
                cmd.Parameters.AddWithValue("@Lname", client.Lname);
                cmd.Parameters.AddWithValue("@SSN", client.SSN);
                cmd.Parameters.AddWithValue("@DOB", client.Dob);
                cmd.Parameters.AddWithValue("@Phone", client.Phone);

                connection.Open();
                pkClients = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();


                Console.WriteLine("The PK of the new entry is "+ pkClients);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error code: " + e);
            }
        }//end of addClientToDB function
        public void addAddress(string strAddAddress, Address address)
        {
            try
            {
                cmd = new SqlCommand(strAddAddress, this.connection);
                Console.WriteLine("The PK of the CLient Table is " + pkClients + " From the AddAddress function");

                cmd.Parameters.AddWithValue("@StrNumber", address.StreetNum);
                cmd.Parameters.AddWithValue("@StrName", address.StreetName);
                cmd.Parameters.AddWithValue("@AptNumber", address.AptNum);
                cmd.Parameters.AddWithValue("@City", address.City);
                cmd.Parameters.AddWithValue("@USState", address.State);
                cmd.Parameters.AddWithValue("@ZipCode", address.ZipCode);
                cmd.Parameters.AddWithValue("@ClientID", pkClients);

                connection.Open();             
                pkAddress = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();

                Console.WriteLine("The PK of the address is: " + pkAddress);

            }
            catch (Exception e)
            {
                Console.WriteLine("Error code: " + e);
            }
        }
        public int getPkClient()
        {

            int pkCl;

            return pkCl;
        }

    }//end of DBManager class
}//end of namespaceCUREEF
