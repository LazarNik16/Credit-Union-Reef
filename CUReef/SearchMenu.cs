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

        }//end of searcgClient function
    }//end of SearchMenu Class
}//end of CUreef namespace
