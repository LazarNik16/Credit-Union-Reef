﻿using System;
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
        double interestRate = 1.1;

        public Client(string fname, string lname, long ssn, long phone, DOB dob)
        {
            Fname = fname;
            Lname = lname;
            SSN = ssn;
            Phone = phone;
            this.Dob = dob.ToString();
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
            
        }
        public int createCheckingAccount()
        {
            string addCheckingAccount = "INSERT INTO CheckingAccounts (ClientID) VALUES (@ClientID) SELECT CAST(SCOPE_IDENTITY() as INT)";
            checkingAcctID = dbm.addCheckingAccount(addCheckingAccount, clientPK);

            return checkingAcctID;

        }//end of createCheckingAccount function
        public int createSavingsAccount()
        {
            string addSavingsAccount = "INSERT INTO SavingsAccounts (ClientID, InterestRate) VALUES (@CLientID, @InterestRate) SELECT CAST(SCOPE_IDENTITY() AS INT)";
            savingAcctID = dbm.addSavingsAccount(addSavingsAccount, clientPK, interestRate);

            return savingAcctID;
        }
    }//end of Client Class
}//end of CUReef namespace
