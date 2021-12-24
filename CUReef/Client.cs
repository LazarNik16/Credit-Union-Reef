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
        public string Dob { get; }
        Address address { get; set; }

        public Client() { }
        public Client(string fname, string lname, long ssn, long phone, DOB dob, Address address)
        {
            Fname = fname;
            Lname = lname;
            SSN = ssn;
            Phone = phone;
            this.Dob = dob.ToString();
            this.address = address;
        }

        //Displaying the data input for the client before writing to the DB
        public override string ToString()
        {
            string str = $"Client info: \nName: {Fname} {Lname} \nSSN: {SSN} \nPhone number:{Phone} \nDate of birth:{Dob.ToString()} \nAddress: {address.ToString()}";
            addClientToDatabase();
            return str;
            

        }//end on to String moethod
        public void addClientToDatabase()
        {
            string addClient = "INSERT INTO Clients (Fname, Lname, SSN, DOB, Phone) VALUES (@Fname, @Lname, @SSN, @dob, @Phone) SELECT SCOPE_IDENTITY()";
            var dbm = new DBManager();
            dbm.addClient(addClient, this);
        }

    }
}
