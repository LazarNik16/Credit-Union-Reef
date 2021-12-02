using System;
using System.Collections.Generic;
using System.Text;

namespace CUReef
{
    class Address
    {
        public int StreetNum { get; set; }
        public string StreetName { get; set; }
        public string AptNum { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        public override string ToString()
        {
            if (AptNum == null)
            {
                return $"The full client address is:\n {StreetNum} {StreetName}\n {City}, {State} {ZipCode}";
            }
            else
            {
                return $"The full client address is:\n {StreetNum} {StreetName}\n {AptNum}\n {City}, {State} {ZipCode}";
            }
            
        }
    }
}
