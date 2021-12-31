using System;
using System.Collections.Generic;
using System.Text;

namespace CUReef
{
    public class CheckingTransaction
    {
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public int CheckingAcctID { get; set; }

        DBManager dbm = new DBManager();

        public CheckingTransaction (decimal amount, decimal balance, int checkingAcctID)
        {
            Amount = amount;
            Balance = balance;
            CheckingAcctID = checkingAcctID;

        }//end of the CheckingTransaction constructor
        public override string ToString()
        {
            string str = $"The client is adding {Amount} to his account. The balance is {Balance}";
            return str;
        }
        public void openCheckingAccount()
        {
            string openCkAccount = "INSERT INTO CheckingTransactions (CkTransAmount, CkTransBalance, CKAcctID) VALUES (@CkTransAmount, @CkTransBalance, @CkAcctID)";
            dbm.OpenNewAccount(openCkAccount, this);
        }
        public int getCheckingAccount()
        {
            string ckAcctPK = "SELECT Balance FROM CheckingAccount WHERE CkAcctID = @CheckingAcctID";

            
            return 0;
        }

    }//end of CheckingTransaction
}//end of namespace CUReef
