using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CUReef
{
    class LoanMenu
    {
        public static void createNewLoan()
        {

            Queue qthree = MenuInput.openAccount();
            int yearOfBirth = (int)qthree.Dequeue();
            int monthOfBirth = (int)qthree.Dequeue();
            int dayOfBirth = (int)qthree.Dequeue();
            string fname = (string)qthree.Dequeue();
            string lname = (string)qthree.Dequeue();
            long ssn = (long)qthree.Dequeue();
            long phone = (long)qthree.Dequeue();
            string strNumber = (string)qthree.Dequeue();
            string strName = (string)qthree.Dequeue();
            string aptNumber = (string)qthree.Dequeue();
            string city = (string)qthree.Dequeue();
            string state = (string)qthree.Dequeue();
            int zipCode = (int)qthree.Dequeue();
            

            decimal loanAmt = loanAmount();
            double intrRate = loanInterestRate();
            int length = loanLength();
            decimal monthlyPmt = loanMontlyPayment(loanAmt, intrRate, length);

            Console.WriteLine($"Printing in order\n" +
                              $"Year of Birth: {yearOfBirth}\n" +
                              $"Month of Birth: {monthOfBirth}\n" +
                              $"Day of Birth: {dayOfBirth}\n" +
                              $"First name: {fname}\n" +
                              $"Last name: {lname}\n " +
                              $"Social security Number: {ssn}\n" +
                              $"Phone number: {phone}\n" +
                              $"Street Number: {strNumber}\n" +
                              $"Street nmae: {strName}\n" +
                              $"Apartment number: {aptNumber}\n" +
                              $"Coty: {city}\n" +
                              $"State: {state}\n" +
                              $"zip code: {zipCode}");

            var dob = new DOB(yearOfBirth, monthOfBirth, dayOfBirth);
            var client = new Client(fname, lname, ssn, phone, dob);
            var clientID = client.addClientToDatabase();
            var loanPK = client.createLoan(intrRate, loanAmt, length, monthlyPmt);
            var address = new Address(strNumber, strName, aptNumber, city, state, zipCode, clientID);
            address.addAddressToDatabase();
            var loan = new LoanTransaction(loanAmt, loanAmt, loanPK);
            loan.openALoan();

        }//end of createNewLoan function
        public static void makeALoanPayment()
        {
            decimal[] numbers;
            var loanNumber = new LoanTransaction();
            int loanAcctNum = MenuInput.CheckBalance();
            numbers = loanNumber.optstandingBalance(loanAcctNum);

            howMuchYouPay(numbers[0], numbers[1], loanAcctNum);

        }//end of makeALoanPayment function
        public static void closeLoan()
        {
            decimal[] loanNumbers;
            var acctID = MenuInput.closeAccount();
            var lnNum = new LoanTransaction();
            loanNumbers = lnNum.optstandingBalance(acctID);
            decimal closeBalance = Decimal.Negate(loanNumbers[0]);

            Console.WriteLine($"The outstanding balance for account number {acctID} is ${loanNumbers[0]}");
            lnNum.payLoan(acctID, closeBalance, 0);
            lnNum.closeLoanAccount(acctID);
            Console.WriteLine($"Loan number {acctID} is closed!!");

        }//end of closeLoan function
        public static void howMuchYouPay(decimal loanBalance, decimal suggPayment, int loanAcctNum)
        {
            decimal payment;
            Console.WriteLine($"The outstanding balance on the loan is: {loanBalance}\n");
            Console.WriteLine($"The suggested payment amouont is: {suggPayment}\n\n");
            Console.WriteLine("How much do you want to pay?: ");
            payment = Convert.ToDecimal(Console.ReadLine());

            decimal tempBal = loanBalance - payment;
            decimal invPayment = Decimal.Negate(payment);

            var loanTrans = new LoanTransaction();
            loanTrans.payLoan(loanAcctNum, invPayment, tempBal);

            Console.WriteLine($"A payment of amount ${payment} was applied to the loan.\nThe new Loan balance for accout number {loanAcctNum} is : ${tempBal}");

        }//end of howMuchYouPay function
        public static decimal loanAmount()
        {
            Console.WriteLine("Set the loan amount: ");
            decimal loanAmount = Convert.ToDecimal(Console.ReadLine());

            return loanAmount;

        }//end of loan amount function
        public static double loanInterestRate()
        {
            Console.WriteLine("Set the anual interest rate for this loan: ");
            double interestRate = Convert.ToDouble(Console.ReadLine());

            return interestRate;

        }//end of loanInterest function
        public static int loanLength()
        {
            Console.WriteLine("Set the loan length in years: ");
            int loanLength = Convert.ToInt32(Console.ReadLine());

            return loanLength;

        }//end of loanLength function
        public static decimal loanMontlyPayment(decimal loanAmt, double intrRate, int length)
        {
            double r = intrRate/1200;
            double f = Math.Pow(1 + r, length);

            return (loanAmt * (decimal)(r * f / (-1 + f)));

        }//end of oanMontlyPayment function
    }//end of LoanMenu Class
}//end of CUReef Namespace