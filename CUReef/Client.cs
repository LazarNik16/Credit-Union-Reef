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

        DOB dob { get; set; }
        Address address { get; set; }

        public Client(string fname, string lname, long ssn, long phone, DOB dob, Address address)
        {
            Fname = fname;
            Lname = lname;
            SSN = ssn;
            Phone = phone;
            this.dob = dob;
            this.address = address;
        }

        //Displaying the data input for the client before writing to the DB
        public override string ToString()
        {
            string obj = $"Client info: \nName: {Fname} {Lname} \nSSN: {SSN} \nPhone number:{Phone} \nDate of birth:{dob.ToString()} \nAddress: {address.ToString()}";
            addClientToDB();
            return obj;
            

        }//end on to String moethod
        public void addClientToDB()
        {
            Client client = new Client(Fname, Lname, SSN, Phone, dob, address);

            string addClient = "INSERT INTO Clients (Fname, Lname, SSN, DOB, Phone) VALUES (@Fname, @Lname, @SSN, @dob, @Phone)"; 
            DBManager dbm = new DBManager();
            dbm.executeQuery(addClient, client);

        }

    }
}
