using System;
using System.Collections.Generic;
using System.Text;

namespace CUReef
{
    class Menus
    {
        public static void mainMenu()
        {
            Console.WriteLine("Welcome!!\n");
            Console.WriteLine("Please select from the following optins");
            Console.WriteLine("1. Checking Account");
            Console.WriteLine("2. Savings Account");
            Console.WriteLine("3. Loan Menu");
            Console.WriteLine("4. Serach a Client\n");

        }//end of mainMenu()
        public static void readInput()
        {
            string readMenu;
            int selection;
            readMenu = Console.ReadLine();

            if (readMenu == null || !int.TryParse(readMenu, out selection))
            {
                Console.WriteLine("Please provide valid input to select from the menu\n\n");
                mainMenu();
                readInput();
            }
            else
            {
                if (selection == 1)
                {
                    menuChecking();
                }
                else if (selection == 2)
                {

                }
                else if (selection == 3)
                {

                }
                else if (selection == 4)
                {

                }
                else
                {
                    Console.WriteLine("Please provide valid input to select from the menu\n\n");
                    mainMenu();
                    readInput();
                }
            }
        }//end of readInput()
        public static void menuChecking()
        {
            Console.WriteLine("Checking Account Menu\n");
            Console.WriteLine("Please select from the following optins\n");
            Console.WriteLine("1. Open a New Checking Account");
            Console.WriteLine("2. Check Balance");
            Console.WriteLine("3. Add Fund to the Balance");
            Console.WriteLine("4. Withdrawal from the balance");
            Console.WriteLine("5. Close an Account");
            Console.WriteLine("6. Return to the Main Menu\n");
            readCheckingInput();

        }//end of menuChecking()
        static void readCheckingInput()
        {
            string readCheckingMenu;
            int selectionChecking;
            readCheckingMenu = Console.ReadLine();

            if (readCheckingMenu == null || !int.TryParse(readCheckingMenu, out selectionChecking))
            {
                Console.WriteLine("Please provide valid input to select from the menu\n\n");
                menuChecking();
                readCheckingInput();
            }

        }
    }
}
