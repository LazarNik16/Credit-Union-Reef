using System;
using System.Collections.Generic;
using System.Text;

namespace CUReef
{
    public class SearchTransactions
    {
        static DBManager dbm = new DBManager();
        public static void searchCheckingAccount(int acct)
        {
            
            string srcChAcct = "SELECT * FROM CheckingAccounts WHERE CkAcctID = @CkAcctID";
            dbm.searchCkAccount(srcChAcct, acct);

        }//end of searchCheckingAccount
        public static void searchSavingAccount(int acct)
        {
            string srcSvAcct = "SELECT * FROM SavingsAccounts WHERE SvgAcctID = @SvgAcctID";
            dbm.searchSvgAccount(srcSvAcct, acct);

        }//end of search savings account
        public static void serachLoan(int acct)
        {
            string srcLoan = "SELECT * FROM Loans WHERE LoanID = @LoanID";
            dbm.searchLoanNumber(srcLoan, acct);

        }//end of serach loan function
        public static void searchFname(string fname)
        {
            int clientid;

            string srcFname = "SELECT * FROM Clients WHERE Fname = @Fname";
            clientid = dbm.searchClientFname(srcFname, fname);
            checkAccounts(clientid);
            
        }//end of searchfname function
        public static void searchLname(string lname)
        {
            int clientid;

            string srcLname = "SELECT * FROM Clients WHERE Lname = @Lname";
            clientid = dbm.searchClientLname(srcLname, lname);
            checkAccounts(clientid);

        }//end of searchLname function
        public static void searchPhone(long phone)
        {
            int clientid;

            string srcPhone = "SELECT * FROM Clients WHERE Phone = @Phone";
            clientid = dbm.searchClientByPhone(srcPhone, phone);

        }//end of searchPhone function
        public static void searchCkAccoutonAcctId(int clientId)
        {
            string srcAcct = "SELECT * FROM CheckingAccounts WHERE ClientID = @ClientID";
            dbm.searchCkAccountOnClientId(srcAcct, clientId);

        }// end ofsearchCkAccoutonAcctId function
        public static void searchSvAccountId(int clientId)
        {
            string srcAcct = "SELECT * FROM SavingsAccounts WHERE ClientID = @ClientID";
            dbm.searchSvgAccountOnClientId(srcAcct, clientId);

        }//end of searchSvAccountId function
        public static void searchLoanId(int clientId)
        {
            string srcLoan = "SELECT * FROM Loans WHERE ClientID = @ClientID";
            dbm.searchLoanOnClientId(srcLoan, clientId);

        }//end of searchLoanId function
        public static void checkAccounts(int clientid)
        {
            searchCkAccoutonAcctId(clientid);
            searchSvAccountId(clientid);
            searchLoanId(clientid);

        }//end of checkAccounts function
    }//end of SearchTransactions class
}//end of CUReef namespace
