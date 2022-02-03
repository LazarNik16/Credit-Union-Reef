using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CUReef
{
    public class CheckingMenu
    {
        public static void createCheckingAccount()
        {

               Queue qtwo = MenuInput.openAccount();
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

            yearOfBirth = (int)qtwo.Dequeue();
            monthOfBirth = (int)qtwo.Dequeue();
            dayOfBirth = (int)qtwo.Dequeue();
            fname = (string)qtwo.Dequeue();
            lname = (string)qtwo.Dequeue();
            ssn = (long)qtwo.Dequeue();
            phone = (long)qtwo.Dequeue();
            strNumber = (string)qtwo.Dequeue();
            strName = (string)qtwo.Dequeue();
            aptNumber = (string)qtwo.Dequeue();
            city = (string)qtwo.Dequeue();
            state = (string)qtwo.Dequeue();
            zipCode = (int)qtwo.Dequeue();

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
            var checkingPK = client.createCheckingAccount();
            var address = new Address(strNumber, strName, aptNumber, city, state, zipCode, clientID);
            address.addAddressToDatabase();
            balance = 0.0m;
            var svgTransaction = new SavingsTransaction(balance, balance, checkingPK);
            svgTransaction.openSavingsAccount();

        }//end of openCheckingAccount function
        public static void checkCheckingBalance()
        {

            var checkingAccount = new CheckingTransaction();
            int acct = MenuInput.CheckBalance();
            decimal bal = checkingAccount.getCheckingAccountBalance(acct);

            Console.WriteLine($"The Account number: {acct} has a balance of {bal}");

        }//end of checkCheckingAccountBalance function
        public static void addBalanceChecking()
        {

            (int acctID, decimal addBal) = MenuInput.addBalance();

            var checkingAccount = new CheckingTransaction();
            checkingAccount.addFundToAccount(addBal, acctID);

            var cktrans = new CheckingTransaction();

            decimal balance = cktrans.getCheckingAccountBalance(acctID);

            Console.WriteLine($"You are adding {addBal} to the account number: {acctID}, the new balance of the account is {balance}");

        }//end of addBalanceChecking function 
        public static void removeBalanceChecking()
        {

            (int acctID, decimal removeBal) = MenuInput.removeBalance();

            var checkingAccount = new CheckingTransaction();
            checkingAccount.addFundToAccount(removeBal, acctID);
            decimal tempBal = checkingAccount.getCheckingAccountBalance(acctID);
            Console.WriteLine($"The new balance on the account number: {acctID} is: ${tempBal}");

        }//end of the removeBalanceChecking function
        public static void closeCheckingAccount()
        {
            
            var acctID = MenuInput.closeAccount();
            var checkingAccount = new CheckingTransaction();
            var balance = checkingAccount.closeCkAccount(acctID);
            
            Console.WriteLine($"The Account with number: {acctID} has been closed.\nPlease pay the client the remaining balance: ${balance}");

        }//end of the closeCheckingAccount function
    }//end of CheckingMenu Class
 }//end of CUReef Namespace



       