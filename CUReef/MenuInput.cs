using System;
using System.Configuration;

namespace CUReef
{
    public class MenuInput
    {
        public static void openCheckingAccount()
        {
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
            decimal addingBalance;

            Console.WriteLine("Enter the Client First Name:");
            fname = Console.ReadLine();

            //while (string.IsNullOrEmpty(fname))
            //{
            //    Console.WriteLine("Client must have a first name:");
            //    fname = Console.ReadLine();
            //}

            Console.WriteLine("Enter the client Last Name:");
            lname = Console.ReadLine();

            //while (string.IsNullOrEmpty(lname))
            
            //{
            //    Console.WriteLine("Client must have a last name:");
            //    lname = Console.ReadLine();
            //}

            Console.WriteLine("Enter the client Social Security Number (just digits, no hyphens):");
            ssn = Convert.ToInt64(Console.ReadLine());

            //while (!validateSSN(ssn))
            //{
            //    Console.WriteLine("The client SSN must be valid");
            //    ssn = Convert.ToInt64(Console.ReadLine());
            //}

            Console.WriteLine("Enter the client Phone Number (just digits, no hyphens):");
            phone = Convert.ToInt64(Console.ReadLine());

            //while(!validatePhone(phone))
            //{
            //    Console.WriteLine("The clinet phone number must be valid");
            //    phone = Convert.ToInt64(Console.ReadLine());
            //}

            Console.WriteLine("Enter the client Street Number:");
            strNumber = Console.ReadLine();

            //while (string.IsNullOrEmpty(strNumber))
            //{
            //    Console.WriteLine("Provide a valid Street number");
            //    strNumber = Console.ReadLine();
            //}

            Console.WriteLine("Enter the Street Name");
            strName = Console.ReadLine();

            //while (string.IsNullOrEmpty(strName))
            //{
            //    Console.WriteLine("Please provide a Streen Name");
            //    strName = Console.ReadLine();
            //}

            Console.WriteLine("Enter the Apartment number (or press enter to skip):");
            aptNumber = Console.ReadLine();

            Console.WriteLine("Enter the City:");
            city = Console.ReadLine();

            //while (string.IsNullOrEmpty(city))
            //{
            //    Console.WriteLine("Please provide a City");
            //    city = Console.ReadLine();
            //}

            Console.WriteLine("Enter the State (only the state two character code)");
            state = Console.ReadLine().ToUpper();

            //while (state.Length > 0 && state.Length != 2)
            //{
            //    Console.WriteLine("Please provide a state, with two digits");
            //    state = Console.ReadLine().ToUpper();
            //}

            Console.WriteLine("Enter the Zip Code:");
            zipCode = Convert.ToInt32(Console.ReadLine());

            //while (zipCode < 00501 || zipCode > 99950)
            //{
            //    Console.WriteLine("Provide a valid zip code for USA:");
            //    zipCode = Convert.ToInt32(Console.ReadLine());
            //}

            Console.WriteLine("Ehter the Month of Birth for the client (numbric):");
            monthOfBirth = Convert.ToInt32(Console.ReadLine());

            //while (monthOfBirth < 1 || monthOfBirth > 12)
            //{
            //    Console.WriteLine("Provide a valid month number, between 1 and 12");
            //    monthOfBirth = Convert.ToInt32(Console.ReadLine());
            //}

            Console.WriteLine("Ehter the Day of Birth for the client:");
            dayOfBirth = Convert.ToInt32(Console.ReadLine());

            //if (monthOfBirth == 1 || monthOfBirth == 3 || monthOfBirth == 5 || monthOfBirth == 7 || monthOfBirth == 8 || monthOfBirth == 10 || monthOfBirth == 12)
            //{
            //    while (dayOfBirth < 1 && dayOfBirth >31)
            //    {
            //        Console.WriteLine("Provide a valid day for that month (between 1 and 31)");
            //        dayOfBirth = Convert.ToInt32(Console.ReadLine());
            //    }
            //}
            //else if (monthOfBirth == 4 || monthOfBirth == 6 || monthOfBirth == 9 || monthOfBirth == 11)
            //{
            //    while (dayOfBirth < 1 && dayOfBirth > 30)
            //    {
            //        Console.WriteLine("Provide a valid day for that month (betweet 1 and 30");
            //        dayOfBirth = Convert.ToInt32(Console.ReadLine());
            //    }
            //}
            //else
            //{
            //    while (dayOfBirth < 1 && dayOfBirth > 29)
            //    {
            //        Console.WriteLine("Fevruary has 29 days the most, provide a valid entry from 1 to 29");
            //        dayOfBirth = Convert.ToInt32(Console.ReadLine());
            //    }
            //}

            Console.WriteLine("Ehter the Year of Birth for the client:");
            yearOfBirth = Convert.ToInt32(Console.ReadLine());

            var current = DateTime.Now;
            int elgForAcct = current.Year - 16;

            //while (yearOfBirth < 1920 || !(yearOfBirth < elgForAcct))
            //{
            //    Console.WriteLine("Check if you enter the year correctly, or the client is not eligible for an account");
            //    yearOfBirth = Convert.ToInt32(Console.ReadLine());
            //}


            var dob = new DOB(yearOfBirth, monthOfBirth, dayOfBirth);
            var client = new Client(fname, lname, ssn, phone, dob);
            var clientID = client.addClientToDatabase();
            var checkingPK = client.createCheckingAccount();
            var address = new Address(strNumber, strName, aptNumber, city, state, zipCode, clientID);
            address.addAddressToDatabase();
            addingBalance = addBalance();
            var ckAcctTransaction = new CheckingTransaction(addingBalance, addingBalance, checkingPK);
            ckAcctTransaction.openCheckingAccount();
            
            
            
        }//end of openCheckingAccount()
        public static bool validateSSN(long ssn)
        {
            long ssnMin = 111111111;
            long ssnMax = 999999999;

            LongValidator validate = new LongValidator(ssnMin, ssnMax, false);

            try
            {
                validate.Validate(ssn);
                return true;
            }
            catch
            {
                return false;
            }
        }//end of validateSSN
        public static bool validatePhone(long phone)
        {
            long ssnMin = 1111111111;
            long ssnMax = 9999999999;

            LongValidator validate = new LongValidator(ssnMin, ssnMax, false);

            try
            {
                validate.Validate(phone);
                return true;
            }
            catch
            {
                return false;
            }
        }//end of validatePhone()
        public static decimal addBalance()
        {
            Console.WriteLine("Add balance to the account amaount: ");
            decimal addBalance = Convert.ToDecimal(Console.ReadLine());
            return addBalance;

        }//end of the add AddBalance function
    }//end of class MenuInput
}//end of namespace
