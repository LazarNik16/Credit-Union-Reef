using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CUReef
{
    class SavingsMenu
    {
        public static void createSavingsAccount()
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

            Console.WriteLine("Set the initial balance for this savings account: ");
            balance = Convert.ToDecimal(Console.ReadLine());

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
                              $"Interest rate: {interestRate}");


            var dob = new DOB(yearOfBirth, monthOfBirth, dayOfBirth);
            var client = new Client(fname, lname, ssn, phone, dob);
            var clientID = client.addClientToDatabase();
            var checkingPK = client.createSavingsAccount(interestRate);
            var address = new Address(strNumber, strName, aptNumber, city, state, zipCode, clientID);
            address.addAddressToDatabase();
            var svgAcctTransaction = new SavingsTransaction(balance, balance, checkingPK);
            svgAcctTransaction.openSavingsAccount();

        }//end of createSavingsAccount function
        public static void checkSavingsBalance()
        {
            var savingsAccount = new SavingsTransaction();
            int acctId = MenuInput.CheckBalance();
            decimal bal = savingsAccount.getSavingsAccountBalance(acctId);

            Console.WriteLine($"The Account number: {acctId} has a balance of {bal}");

        }//end of checkSavingsBalance function
        public static void addBalanceSavings()
        {
            (int acctID, decimal addBal) = MenuInput.addBalance();

            var savingsAccount = new SavingsTransaction();
            savingsAccount.addFundstoSavingsAccount(addBal, acctID);
            decimal balance = savingsAccount.getSavingsAccountBalance(acctID);

            Console.WriteLine($"You are adding ${addBal} to account number: {acctID}, the new balance of this account is {balance}");

        }//end of addBalanceSavings function
        public static void removeBalanceSavings()
        {
            (int acctID, decimal removeBal) = MenuInput.removeBalance();

            var svgAcct = new SavingsTransaction();
            svgAcct.addFundstoSavingsAccount(removeBal, acctID);
            decimal tempBal = svgAcct.getSavingsAccountBalance(acctID);

            Console.WriteLine($"The new balance of the account number {acctID} is: ${tempBal}");

        }//end of removeBalanceSavings function
        public static void closeSavingsAccount()
        {
            int acctID = MenuInput.closeAccount();
            var svgAccount = new SavingsTransaction();
            var balance = svgAccount.closeSavingsAccount(acctID);

            Console.WriteLine($"The Account with number: {acctID} has been closed.\nPlease pay the client the remaining balance of: ${balance}");

        }//end of close savings account
    }//end of SavingsMenu Class
}//end of CUReef Namespace