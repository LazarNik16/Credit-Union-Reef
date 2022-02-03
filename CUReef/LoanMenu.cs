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
            string fname;
            string lname;
            long ssn;
            long phone;
            string strNumber;
            string strName;
            string aptNumber;
            string city;
            string state;
            int zipCode;
            int monthOfBirth;
            int dayOfBirth;
            int yearOfBirth;
            decimal balance;
            double interestRate;

            Console.WriteLine("Set the interest rate for this savings account: ");
            interestRate = Convert.ToDouble(Console.ReadLine());

            yearOfBirth = (int)qthree.Dequeue();
            monthOfBirth = (int)qthree.Dequeue();
            dayOfBirth = (int)qthree.Dequeue();
            fname = (string)qthree.Dequeue();
            lname = (string)qthree.Dequeue();
            ssn = (long)qthree.Dequeue();
            phone = (long)qthree.Dequeue();
            strNumber = (string)qthree.Dequeue();
            strName = (string)qthree.Dequeue();
            aptNumber = (string)qthree.Dequeue();
            city = (string)qthree.Dequeue();
            state = (string)qthree.Dequeue();
            zipCode = (int)qthree.Dequeue();

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
                              $"zip code: {zipCode}\n" +
                              $"finally. Interest rate: {interestRate}");


            var dob = new DOB(yearOfBirth, monthOfBirth, dayOfBirth);
            var client = new Client(fname, lname, ssn, phone, dob);
            var clientID = client.addClientToDatabase();
            var loanPK = client.createLoan(interestRate);
            var address = new Address(strNumber, strName, aptNumber, city, state, zipCode, clientID);
            address.addAddressToDatabase();
            balance = 0.0m;
            var loan = new LoanTransaction(balance, balance, loanPK);
            loan.openALoan();

        }//end of createNewLoan function
        public static void makeALoanPayment()
        {
            var loanNumber = new LoanTransaction();
            int loanAcctNum = MenuInput.CheckBalance();
            decimal loanBalance = loanNumber.optstandingBalance(loanAcctNum);
            howMuchYouPay(loanBalance, loanAcctNum);

        }//end of makeALoanPayment function
        public static void closeLoan()
        {
            var acctID = MenuInput.closeAccount();
            var lnNum = new LoanTransaction();
            decimal outstBal = lnNum.optstandingBalance(acctID);
            decimal closeBalance = Decimal.Negate(outstBal);

            Console.WriteLine($"The outstanding balance for account number {acctID} is ${outstBal}");
            lnNum.payLoan(acctID, closeBalance, 0);
            lnNum.closeLoanAccount(acctID);
            Console.WriteLine($"Loan number {acctID} is closed!!");

        }//end of closeLoan function
        public static void howMuchYouPay(decimal loanBalance, int loanAcctNum)
        {
            decimal payment;
            Console.WriteLine($"The outstanding balance on the loan is: {loanBalance}");
            Console.WriteLine("How much do you want to pay?: ");
            payment = Convert.ToDecimal(Console.ReadLine());

            decimal tempBal = loanBalance - payment;
            decimal invPayment = Decimal.Negate(payment);

            var loanTrans = new LoanTransaction();
            loanTrans.payLoan(loanAcctNum, invPayment, tempBal);

            Console.WriteLine($"A payment of amount ${payment} was applied to the loan.\nThe new Loan balance for accout number {loanAcctNum} is : ${tempBal}");

        }//end of howMuchYouPay function
    }//end of LoanMenu Class
}//end of CUReef Namespace
