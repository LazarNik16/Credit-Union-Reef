using System;
using System.Collections.Generic;
using System.Text;

namespace CUReef
{
    class SavingsTransaction
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
            string openCkAccount = "INSERT INTO SavingsTransactions (CkTransAmount, CkTransBalance, CKAcctID) VALUES (@CkTransAmount, @CkTransBalance, @CkAcctID)";
            dbm.OpenNewAccount(openCkAccount, this);

        }//end of SavingsTransaction Class
    }//end of CUReef Namespace
