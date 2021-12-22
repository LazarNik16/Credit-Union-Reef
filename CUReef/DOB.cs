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

        public DOB(int year, int month, int day)
        {
            Year = year; 
            Month = month;
            Day = day;
            
        }
        public override string ToString()
        {
            string obj = $"{Year}-{Month}-{Day}";
            return obj;
        }
    }
}
