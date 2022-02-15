using System;
using System.Collections.Generic;
using System.Text;

namespace CUReef
{
    public class LoanTransaction
    {
        public decimal Amount { get; set;}
        public decimal Balance { get; set;}
        public int LoanID { get; set;}

        DBManager dbm = new DBManager();

        public LoanTransaction() { }

        public LoanTransaction(decimal amount, decimal balance, int loanId)
        {
            Amount = amount;
            Balance = balance;
            LoanID = loanId;

        }//end of LoanTransaction counstructor

        public void openALoan()
        {
            string openloan = "INSERT INTO LoanTransactions (LoanTransAmount, LoanTransBalance, LoanID) VALUES (@LoanTransAmount, @LoanTransBalance, @LoanID)";
            dbm.openNewLoan(openloan, this);

        }//end of openALoan function
        public decimal[] optstandingBalance(int acctID)
        {
            decimal [] numbers = new decimal[2];

            string checkBalance = "SELECT LoanTransBalance FROM LoanTransactions WHERE LoanTransDate = (SELECT MAX(LoanTransDate) FROM LoanTransactions WHERE LoanID = @LoanID)";
            Balance = dbm.getLoanBalance(checkBalance, acctID);

            decimal suggestedPayment;
            string checkRatePayment = "SELECT LoanPayment from Loans WHERE LoanID = @LoanID";
            suggestedPayment = dbm.suggestedLoanPayment(checkRatePayment, acctID);
            numbers[0] = Balance;
            numbers[1] = suggestedPayment;

            return numbers;

        }//end of outstandingBalance
        public void payLoan(int acct, decimal payment, decimal balance)
        {
            string payAdHoc = "INSERT INTO LoanTransactions (LoanTransAmount, LoanTransBalance, LoanID) VALUES (@LoanTransAmount, @LoanTransBalance, @LoanID)";
            dbm.payLoanAdHoc(payAdHoc, payment, balance, acct);

        }//end of payLoan function
        public void closeLoanAccount(int acctID)
        {
            string closeLoanAcct = "UPDATE Loans SET EditDate = getdate(), IsClosed = 1 WHERE LoanID = @LoanID";
            dbm.closeLoan(closeLoanAcct, acctID);

        }//end of closeLoanAccount function
    }//end of LoanTransaction Class
}//end of CUReef Namespace
