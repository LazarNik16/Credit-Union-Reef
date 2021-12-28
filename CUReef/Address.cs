﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CUReef
{
    public class Address
    {
        public string StreetNum { get; set; }
        public string StreetName { get; set; }
        public string AptNum { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        public Address () { }
        public Address(string strNum, string strName, string aptNum, string city, string state, int zipCode)
        {
            StreetNum = strNum;
            StreetName = strName;
            AptNum = aptNum;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
        public override string ToString()
        {
            //addAddressToDatabase();

            if (AptNum == null)
            {
                return $"{StreetNum} {StreetName}\n {City}, {State} {ZipCode}";
            }
            else
            {
                return $"{StreetNum} {StreetName}\n Apt. {AptNum}\n {City}, {State} {ZipCode}";
            }
            
        }
        public void addAddressToDatabase()
        {
            string addAddress = "INSERT INTO Addresses (StrNumber, StrName, AptNumber, City, USState, ZipCode, ClientID) VALUES (@StrNumber, @StrName, @AptNumber, @City, @USState, @ZipCode, @ClientID) SELECT CAST(SCOPE_IDENTITY() as INT)";
            var dbm = new DBManager();
            dbm.addAddress(addAddress, this);
        }
    }
}
