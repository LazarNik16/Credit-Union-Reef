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
        int pkCheckingAccount = 0;
        int pkSavingsaccount = 0;
        decimal acctBalance = 0;

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
                cmd.ExecuteScalar();
                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error code: " + e);
            }
        }//end of the addAddress function
        public int addCheckingAccount(string addCheckingAccount, int clientPK)
        {
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
        public decimal GetCheckingBalance(string balanceAccount, int acctPk)
        {
            try
            {
                cmd = new SqlCommand(balanceAccount, this.connection);

                cmd.Parameters.AddWithValue("@CkAcctID", acctPk);

                connection.Open();
                acctBalance = Convert.ToDecimal(cmd.ExecuteScalar());
                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }
            return acctBalance;
            
        }//end of the getCheckingBalance function
        public void addFundsToCheckingAccount(string addBalance, decimal adding, decimal newBalance, int acctID)
        {
            try
            {
                cmd = new SqlCommand(addBalance, this.connection);

                cmd.Parameters.AddWithValue("@CkTransAmount", adding);
                cmd.Parameters.AddWithValue("@CkTransBalance", newBalance);
                cmd.Parameters.AddWithValue("@CkAcctID", acctID);

                connection.Open();
                cmd.ExecuteScalar();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }
        }//end of addFundsToCheckingAccount function
        public void closeCheckingAccount(string closeAcct, decimal balance, int acctID)
        {

            try
            {
                cmd = new SqlCommand(closeAcct, this.connection);

                cmd.Parameters.AddWithValue("@CkAcctID", acctID);
                cmd.Parameters.AddWithValue("@CkTransAmount", balance);
                cmd.Parameters.AddWithValue("@CkTransBalance", 0);

                connection.Open();
                cmd.ExecuteScalar();
                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }
        }//end of close checking account
        public int addSavingsAccount(string addSavingsAccount, int clientPK, double interestRate)
        {
            try
            {
                cmd = new SqlCommand(addSavingsAccount, this.connection);

                cmd.Parameters.AddWithValue("@ClientID", clientPK);
                cmd.Parameters.AddWithValue("@InterestRate", interestRate);

                connection.Open();
                pkSavingsaccount = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }

            return pkSavingsaccount;

        }//end of addSavingsAccount
    }//end of DBManager class
}//end of namespace CUREEF
