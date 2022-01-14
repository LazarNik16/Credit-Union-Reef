using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CUReef
{
    class SavingsMenu
    {
        public static void createSavingsAccount()
        {
            Queue qthree = MenuInput.openAccount();

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
            double interestRate;

            yearOfBirth = (int)qthree.Dequeue();
            monthOfBirth = (int)qthree.Dequeue();
            dayOfBirth = (int)qthree.Dequeue();
            fname = (string)qthree.Dequeue();
            lname = (string)qthree.Dequeue();
            ssn = (long)qthree.Dequeue();
            phone = (long)qthree.Dequeue();
            strNumber = (string)qthree.Dequeue();
            strName = (string)qthree.Dequeue();
            aptNumber = (string)qthree.Dequeue();
            city = (string)qthree.Dequeue();
            state = (string)qthree.Dequeue();
            zipCode = (int)qthree.Dequeue();



        }//end of createSavingsAccount function
    }//end of SavingsMenu Class
}//end of CUReef Namespace
