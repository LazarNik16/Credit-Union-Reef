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
        int pkLoan = 0;
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

                doIt();
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
        public void OpenNewCheckingAccount(string strckAcct, CheckingTransaction cktrans)
        {
            try
            {
                cmd = new SqlCommand(strckAcct, this.connection);

                cmd.Parameters.AddWithValue("@CkTransAmount", cktrans.Amount);
                cmd.Parameters.AddWithValue("@CkTransBalance", cktrans.Balance);
                cmd.Parameters.AddWithValue("@CkAcctID", cktrans.CheckingAcctID);

                doIt();
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

                doIt();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }
        }//end of addFundsToCheckingAccount function
        public void closeCheckingAccount(string closeAcct, int acctID)
        {
            try
            {
                cmd = new SqlCommand(closeAcct, this.connection);

                cmd.Parameters.AddWithValue("@CkAcctID", acctID);

                doIt();
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
        public void openNewSavingsAccount(string openSvgAcct, SavingsTransaction svgTrans)
        {
            try
            {
                cmd = new SqlCommand(openSvgAcct, this.connection);

                cmd.Parameters.AddWithValue("@SvgTransAmount", svgTrans.Amount);
                cmd.Parameters.AddWithValue("@SvgTransBalance", svgTrans.Balance);
                cmd.Parameters.AddWithValue("@SvgAcctID", svgTrans.SavingsAcctID);

                doIt();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error code: " + e);
            }
        }//end of openNewSavingsAccount function 
        public decimal getSavingsBalance(string balacct, int svgAcctId)
        {
            try
            {
                cmd = new SqlCommand(balacct, this.connection);

                cmd.Parameters.AddWithValue("@SvgAcctID", svgAcctId);

                connection.Open();
                acctBalance = Convert.ToDecimal(cmd.ExecuteScalar());
                connection.Close();

            }
            catch( Exception e)
            {
                Console.WriteLine("Error code: " + e);
            }
            return acctBalance;

        }//end of getSavingsBalance function
        public void addFundsToSavingsAccount(string addingBalance, decimal amount, decimal newBalance, int acctID)
        {
            try
            {
                cmd = new SqlCommand(addingBalance, this.connection);

                cmd.Parameters.AddWithValue("@SvgTransAmount",amount);
                cmd.Parameters.AddWithValue("@SvgTransBalance",newBalance);
                cmd.Parameters.AddWithValue("@SvgAcctID", acctID);

                doIt();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error Code " + e);
            }
        }//end of addFundsToSavings function
        public void closeSavingsAcct(string closeAcct, int acctId)
        {
            try
            {
                cmd = new SqlCommand(closeAcct, this.connection);

                cmd.Parameters.AddWithValue("@SvgAcctID", acctId);

                doIt();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error code " + e);
            }
        }//end of closeSavingsAcct function
        public int addNewLoan(string addLoan, int clientPK, double intRate)
        {
            try
            {
                cmd = new SqlCommand(addLoan, this.connection);

                cmd.Parameters.AddWithValue("@ClientID", clientPK);
                cmd.Parameters.AddWithValue("@LoanIntRate", intRate);

                connection.Open();
                pkLoan = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error code " + e);
            }
            return pkLoan;

        }//end of function addNewLoan function
        public void openNewLoan(string openALoan, LoanTransaction loan)
        {
            try
            {
                cmd = new SqlCommand(openALoan, this.connection);

                cmd.Parameters.AddWithValue("@LoanTransAmount",loan.Amount);
                cmd.Parameters.AddWithValue("@LoanTransBalance", loan.Balance);
                cmd.Parameters.AddWithValue("@LoanID",loan.LoanID);

                doIt();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error code " + e);
            }
        }//end of openNewLoan function
        public decimal getLoanBalance(string getBalance, int acctID)
        {
            try
            {
                cmd = new SqlCommand(getBalance, this.connection);

                cmd.Parameters.AddWithValue("@LoanID",acctID);

                connection.Open();
                acctBalance = Convert.ToDecimal(cmd.ExecuteScalar());
                connection.Close();

            }
            catch(Exception e)
            {
                Console.WriteLine("Error code " + e);
            }

            return acctBalance; 

        }//end of getLoanBalance function
        public void payLoanAdHoc(string payAdHoc, decimal payment, decimal balance, int acct)
        {
            try
            {
                cmd = new SqlCommand(payAdHoc, this.connection);

                cmd.Parameters.AddWithValue("@LoanTransAmount", payment);
                cmd.Parameters.AddWithValue("@LoanTransBalance", balance);
                cmd.Parameters.AddWithValue("@LoanID", acct);

                doIt();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error code " + e);
            }
        }//end of payLoanAdHoc function
        public void closeLoan(string closeLoan, int acctID)
        {
            

            try
            {
                cmd = new SqlCommand(closeLoan, this.connection);
                cmd.Parameters.AddWithValue("@LoanID", acctID);

                doIt();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error code " + e);
            }

        }//end of closeLoan function
        public void searchCkAccount(string srCkAcct, int acctID)
        {
            int acct = 0; 

            cmd = new SqlCommand(srCkAcct, this.connection);
            cmd.Parameters.AddWithValue("@CkAcctID",acctID);

            connection.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while(rdr.Read())
                {
                    Console.WriteLine("Accti ID: {0} \nDate Opened: {1} \nDate Modified {2}\n Account closed: {3}", rdr["CkAcctID"], rdr["CreateDate"], rdr["EditDate"], rdr["IsClosed"], rdr["ClientID"]);
                    acct = (int)rdr["ClientID"];
                }
            }
            connection.Close();
            printOwner(acct);

        }//end of searchCkAccount function
        public void searchSvgAccount(string svAcctstr, int acctID)
        {
            int acct = 0;
            cmd = new SqlCommand(svAcctstr, this.connection);
            cmd.Parameters.AddWithValue("@SvgAcctID",acctID);

            connection.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    Console.WriteLine("SavingsAccount ID: {0} \nInterest Rate: {1} \nDate Opened: {2} \nDate Modified: {3} \nIs closed: {4}", rdr["SvgAcctID"], rdr["InterestRate"], rdr["CreateDate"], rdr["EditDate"], rdr["IsClosed"], rdr["ClientID"]);
                    acct = (int)rdr["ClientID"];
                }
            }
            connection.Close();
            printOwner(acct);

        }//end of searchSvgAccount function
        public void searchLoanNumber(string srcLn, int acctId)
        {
            int acct = 0;
            cmd = new SqlCommand(srcLn, this.connection);
            cmd.Parameters.AddWithValue("@LoanID", acctId);

            connection.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    Console.WriteLine("Loan number: {0} \nInterest Rate: {1} \nDate Open: {2} \nEdit Date: {3} \nIS Closed: {4}", rdr["LoanID"], rdr["LoanIntRate"], rdr["CreateDate"], rdr["EditDate"], rdr["IsClosed"], rdr["ClientID"]);
                    acct = (int)rdr["ClientID"];
                }
            }
            connection.Close();
            printOwner(acct);

        }//end of searchLoanNumber function
        public void printOwner(int clientID)
        {
            string getOwner = "SELECT ClientID, Fname, Lname, SSN, DOB FROM Clients WHERE ClientID = @ClientID";

            cmd = new SqlCommand(getOwner, this.connection);
            cmd.Parameters.AddWithValue("@ClientID",clientID);

            connection.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            
            if (rdr.HasRows)
            {
                while(rdr.Read())
                {
                    Console.WriteLine("\nClient id: {0} \nClient Name: {1} \nClient Lastname: {2} \nSSN: {3} \nDate of Birth: {4}", rdr["ClientID"], rdr["Fname"], rdr["Lname"], rdr["SSN"], rdr["DOB"]);
                }
            }
            connection.Close();

        }//end of printOwner function
        public void doIt()
        {
            connection.Open();
            cmd.ExecuteScalar();
            connection.Close();

        }//end of doIt function
    }//end of DBManager class
}//end of namespace CUREEF
