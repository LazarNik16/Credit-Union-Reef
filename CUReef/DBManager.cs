using System;
using System.Data;
using System.Data.SqlClient;

namespace CUReef
{
    public class DBManager
    {

        private SqlConnection connection;
        private SqlCommand cmd;
        int pkClients = 0;
        int pkAddress = 0;
        int pkCheckingAccount = 0;

        public DBManager()
        {
            connection = new SqlConnection(@"Server=LAZAR-DESKTOP\SQLEXPRESS;Database=DBReef;Trusted_Connection=True;");

        }//end of DBManager constructor 

        public int addClient(string sqlStatement, Client client)
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

            }
            catch (Exception e)
            {
                Console.WriteLine("Error code: " + e);
            }

            return pkClients;

        }//end of addClientToDB function
        public void addAddress(string strAddAddress, Address address)
        {
            try
            {
                cmd = new SqlCommand(strAddAddress, this.connection);

                cmd.Parameters.AddWithValue("@StrNumber", address.StreetNum);
                cmd.Parameters.AddWithValue("@StrName", address.StreetName);
                cmd.Parameters.AddWithValue("@AptNumber", address.AptNum);
                cmd.Parameters.AddWithValue("@City", address.City);
                cmd.Parameters.AddWithValue("@USState", address.State);
                cmd.Parameters.AddWithValue("@ZipCode", address.ZipCode);
                cmd.Parameters.AddWithValue("@ClientID", address.ClientID);

                connection.Open();             
                pkAddress = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error code: " + e);
            }
        }//end of the addAddress function
        public int addCheckingAccount(string addCheckingAccount, int clientPK)
        {

            //Console.WriteLine("Dali stiga ovde vo addCheckingAccount function - DBManager");

            try
            {
                cmd = new SqlCommand(addCheckingAccount, this.connection);

                cmd.Parameters.AddWithValue("@ClientID", clientPK);

                connection.Open();
                pkCheckingAccount = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error code: " + e);
            }
            return pkCheckingAccount;
        }//end of addCheckingAccount function
        public void OpenNewAccount(string strckAcct, CheckingTransaction cktrans)
        {
            try
            {
                cmd = new SqlCommand(strckAcct, this.connection);

                cmd.Parameters.AddWithValue("@CkTransAmount", cktrans.Amount);
                cmd.Parameters.AddWithValue("@CkTransBalance", cktrans.Balance);
                cmd.Parameters.AddWithValue("@CkAcctID", cktrans.CheckingAcctID);

                connection.Open();
                cmd.ExecuteScalar();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error code: " + e);
            }
        }//end of the openAccount function 

    }//end of DBManager class
}//end of namespaceCUREEF
