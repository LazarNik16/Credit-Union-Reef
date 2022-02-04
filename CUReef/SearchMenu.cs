using System;
using System.Collections.Generic;
using System.Text;

namespace CUReef
{
    class SearchMenu
    {
        public static void searchAccounts()
        {
            int acct;
            
            Console.Clear();
            Console.WriteLine("Select the accouont type:\n");
            Console.WriteLine("1. Checking Account");
            Console.WriteLine("2. Savings Account");
            Console.WriteLine("3. Loan Number");
            Console.WriteLine("4. Return to the previous Menu");

            acct = Convert.ToInt32(Console.ReadLine());

            switch(acct)
            {
                case 1:
                    int ckAcct;
                    Console.WriteLine("Set the checking account number for search: ");
                    ckAcct = Convert.ToInt32(Console.ReadLine());
                    SearchTransactions.searchCheckingAccount(ckAcct);
                    break;
                case 2:
                    int svAcct;
                    Console.WriteLine("Set the savings account number for search: ");
                    svAcct = Convert.ToInt32(Console.ReadLine());
                    SearchTransactions.searchSavingAccount(svAcct);
                    break;
                case 3:
                    int lnAcct;
                    Console.WriteLine("Set the loan number for search");
                    lnAcct = Convert.ToInt32(Console.ReadLine());
                    SearchTransactions.serachLoan(lnAcct);
                    break;
                case 4:
                    Menus.serachMenu();
                    break;
                default:
                    searchAccounts();
                    break;
            }

        }//end of searchAccounts function
        public static void searchClient()
        {
            int selection;

            Console.Clear();
            Console.WriteLine("Search client Manu\n");
            Console.WriteLine("1. Search client by First name");
            Console.WriteLine("2. Search client by Last name");
            Console.WriteLine("3. Search client by Phone number");
            Console.WriteLine("4. Return to the previous Menu");

            selection = Convert.ToInt32(Console.ReadLine());

            switch(selection)
            {
                case 1:
                    string fname;
                    Console.WriteLine("Set the client name for search: ");
                    fname = Console.ReadLine().Trim();
                    SearchTransactions.searchFname(fname);
                    break;
                case 2:
                    string lname;
                    Console.WriteLine("Set the client last name for search: ");
                    lname = Console.ReadLine().Trim();
                    SearchTransactions.searchLname(lname);
                    break;
                case 3:
                    long number;
                    Console.WriteLine("Set the clinet number for search ");
                    number = Convert.ToInt64(Console.ReadLine());
                    SearchTransactions.searchPhone(number);
                    break;
                case 4:
                    Menus.serachMenu();
                    break;
                default:
                    searchClient();
                    break;
            }

        }//end of searcgClient function
    }//end of SearchMenu Class
}//end of CUreef namespace
