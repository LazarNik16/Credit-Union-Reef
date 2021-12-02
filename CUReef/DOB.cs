using System;
using System.Collections.Generic;
using System.Text;

namespace CUReef
{
    public class DOB
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public DateTime getDOB()
        {
            var birthdate = new DateTime(Day, Month, Year);
            return birthdate;
        }
        
    }
}
