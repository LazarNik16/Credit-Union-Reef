using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CUReef
{
    public class Client
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public long SSN { get; set; }
        public long Phone { get; set; }
        public string Dob { get; set;  }

        DBManager dbm = new DBManager();
        int clientPK;
        int checkingAcctID = 0;
        int savingAcctID = 0;
        int loanAcctId = 0;

        public Client(string fname, string lname, long ssn, long phone, DOB dob)
        {
            Fname = fname;
            Lname = lname;
            SSN = ssn;
            Phone = phone;
            Dob = dob.ToString();
        }

        //Displaying the data input for the client before writing to the DB
        public override string ToString()
        {
            string str = $"Client info: \nName: {Fname} {Lname} \nSSN: {SSN} \nPhone number:{Phone} \nDate of birth:{Dob.ToString()}\n";
            return str;
            
        }//end on ToString method
        public int addClientToDatabase()
        {
            
            string addClient = "INSERT INTO Clients (Fname, Lname, SSN, DOB, Phone) VALUES (@Fname, @Lname, @SSN, @dob, @Phone) SELECT CAST(SCOPE_IDENTITY() as INT)";
            clientPK = dbm.addClient(addClient, this);

            return clientPK;
            
        }//end of addClientToDatabase function
        public int createCheckingAccount()
        {

            string addCheckingAccount = "INSERT INTO CheckingAccounts (ClientID) VALUES (@ClientID) SELECT CAST(SCOPE_IDENTITY() as INT)";
            checkingAcctID = dbm.addCheckingAccount(addCheckingAccount, clientPK);

            return checkingAcctID;

        }//end of createCheckingAccount function
        public int createSavingsAccount(double intRate)
        {

            string addSavingsAccount = "INSERT INTO SavingsAccounts (ClientID, InterestRate) VALUES (@CLientID, @InterestRate) SELECT CAST(SCOPE_IDENTITY() as INT)";
            savingAcctID = dbm.addSavingsAccount(addSavingsAccount, clientPK, intRate);

            return savingAcctID;

        }//end of createSavingsAccount function
        public int createLoan(double intRate)
        {

            string addLoanAcct = "INSERT INTO Loans (ClientID, LoanIntRate) VALUES (@ClientID, @LoanIntRate) SELECT CAST(SCOPE_IDENTITY() as INT)";
            loanAcctId = dbm.addNewLoan(addLoanAcct, clientPK, intRate);

            return loanAcctId;

        }//end of createLoan function
    }//end of Client Class
}//end of CUReef namespace
