using System;
using System.Collections.Generic;
using System.Text;

namespace CUReef
{
    public class SavingsTransaction
    {
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public int SavingsAcctID { get; set; }

        DBManager dbm = new DBManager();

        public SavingsTransaction() { }

        public SavingsTransaction(decimal amount, decimal balance, int savingsAcctID)
        {
            Amount = amount;
            Balance = balance;
            SavingsAcctID = savingsAcctID;

        }//end of SavingsAccount constructor
        public void openSavingsAccount()
        {
            string openSvgAccount = "INSERT INTO SavingsTransactions (SvgTransAmount, SvgTransBalance, SvgAcctID) VALUES (@SvgTransAmount, @SvgTransBalance, @SvgAcctID)";
            dbm.openNewSavingsAccount(openSvgAccount, this);

        }//emd pf p[emSavingsAccount function
        public decimal getSavingsAccountBalance(int acctID)
        {
            string balanceAccount = "SELECT SvgTransBalance FROM SavingsTransactions WHERE SvgTransDate = (SELECT MAX(SvgTransDate) FROM SavingsTransactions WHERE SvgAcctID = @SvgAcctID)";
            Balance = dbm.getSavingsBalance(balanceAccount, acctID);

            return Balance;

        }//end of getSavingsAccountBalance function
        public void addFundstoSavingsAccount(decimal amount, int acctID)
        {
            decimal balance = getSavingsAccountBalance(acctID);
            decimal newBalance = amount + balance;

            string addingBalance = "INSERT INTO SavingsTransactions (SvgTransAmount, SvgTransBalance, SvgAcctID) VALUES (@SvgTransAmount, @SvgTransBalance, @SvgAcctID)";
            dbm.addFundsToSavingsAccount(addingBalance, amount, newBalance, acctID);

        }//end of addFundstoSavingsAccount function
        public decimal closeSavingsAccount(int acctId)
        {
            decimal bal = getSavingsAccountBalance(acctId);
            decimal removeBalance = Decimal.Negate(bal);

            string closeAcct = "UPDATE SavingsAccounts SET EditDate = getdate(), IsClosed = 1 WHERE SvgAcctID = @SvgAcctID";
            addFundstoSavingsAccount(removeBalance, acctId);

            dbm.closeSavingsAcct(closeAcct, acctId);
            return bal;

        }//end of closeSavingsAccount function        
    }//end of SavingsTransaction Class
}//end of CUReef Namespace