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

        public CheckingTransaction() { }
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

        }//end of the ToString function
        public void openCheckingAccount()
        {
            string openCkAccount = "INSERT INTO CheckingTransactions (CkTransAmount, CkTransBalance, CKAcctID) VALUES (@CkTransAmount, @CkTransBalance, @CkAcctID)";
            dbm.OpenNewAccount(openCkAccount, this);

        }//end of openCheckingAccount
        public decimal getCheckingAccountBalance(int ckAcctPK)
        {
            string balanceAccount = "SELECT CkTransBalance FROM CheckingTransactions WHERE CkTransDate = (SELECT MAX(CkTransDate) FROM CheckingTransactions WHERE CkAcctID = @CkAcctID)";
            Balance = dbm.GetCheckingBalance(balanceAccount, ckAcctPK);

            return Balance;
            
        }//end of getCheckingBalance
        public void addFundToAccount(decimal adding, int acctID)
        {
            decimal balance = getCheckingAccountBalance(acctID);
            decimal newBalance = adding + balance;

            string addBalance = "INSERT INTO CheckingTransactions (CkTransAmount, CkTransBalance, CKAcctID) VALUES (@CkTransAmount, @CkTransBalance, @CkAcctID)";
            dbm.addFundsToCheckingAccount(addBalance, adding, newBalance, acctID);

        }//end of add funds to account
        public decimal closeCkAccount(int acctID)
        {
            decimal balance = getCheckingAccountBalance(acctID);
            decimal removeBalance = Decimal.Negate(balance);

            string closeAcct = "UPDATE CheckingAccounts SET EditDate = getdate(), IsClosed = 1 WHERE CkAcctID = @CkAcctID";
            addFundToAccount(removeBalance, acctID);
            
            dbm.closeCheckingAccount(closeAcct, removeBalance, acctID);
            return balance;

        }//end of closeCkAccont function0
    }//end of CheckingTransaction
}//end of namespace CUReef
