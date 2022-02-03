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
    }//end of SearchTransactions class
}//end of CUReef namespace
