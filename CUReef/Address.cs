using System;
using System.Collections.Generic;
using System.Text;

namespace CUReef
{
    public class Address
    {
        public int StreetNum { get; set; }
        public string StreetName { get; set; }
        public string AptNum { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        public Address(int strNum, string strName, string aptNum, string city, string state, int zipCode)
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
            if (AptNum == null)
            {
                return $"{StreetNum} {StreetName}\n {City}, {State} {ZipCode}";
            }
            else
            {
                return $"{StreetNum} {StreetName}\n Apt. {AptNum}\n {City}, {State} {ZipCode}";
            }
            
        }
    }
}
