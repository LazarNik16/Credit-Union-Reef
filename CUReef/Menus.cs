using System;
using System.Collections.Generic;
using System.Text;

namespace CUReef
{
    public class Menus
    {
        public static void mainMenu()
        {
            Console.WriteLine("Welcome Team Member!!");
            Console.WriteLine("Please select from the following optins\n");
            Console.WriteLine("1. Checking Account");
            Console.WriteLine("2. Savings Account");
            Console.WriteLine("3. Loan Menu");
            Console.WriteLine("4. Serach a Client\n");
            readInput();

        }//end of mainMenu()
        public static void readInput()
        {
            string readMenu;
            int selection;
            readMenu = Console.ReadLine();

            if (readMenu == null || !int.TryParse(readMenu, out selection))
            {
                Console.Clear();
                Console.WriteLine("Please provide valid input to select from the Main Menu\n\n");
                mainMenu();
                readInput();
            }
            else
            {
                if (selection == 1)
                {
                    Console.Clear();
                    menuChecking();
                }
                else if (selection == 2)
                {
                    Console.Clear();
                    menuSavings();
                }
                else if (selection == 3)
                {
                    Console.Clear();
                    menuLoan();
                }
                else if (selection == 4)
                {
                    Console.Clear();
                    serachMenu();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please provide valid selection from the Main Menu\n\n");
                    mainMenu();
                    readInput();
                }
            }
        }//end of readInput()
        public static void menuChecking()
        {
            Console.WriteLine("Checking Account Menu");
            Console.WriteLine("Please select from the following optins\n");
            Console.WriteLine("1. Open a New Checking Account");
            Console.WriteLine("2. Check Balance");
            Console.WriteLine("3. Add Fund to the Account");
            Console.WriteLine("4. Withdrawal from the balance");
            Console.WriteLine("5. Close an Account");
            Console.WriteLine("6. Return to the Main Menu");
            readCheckingInput();

        }//end of menuChecking()
        static void readCheckingInput()
        {
            string readCheckingMenu;
            int selectionChecking;
            readCheckingMenu = Console.ReadLine();

            if (readCheckingMenu == null || !int.TryParse(readCheckingMenu, out selectionChecking))
            {
                Console.Clear();
                Console.WriteLine("Please provide valid input to select from the Checking Menu\n\n");
                menuChecking();
                readCheckingInput();
            }
            else
            {
                selectionChecking = Int16.Parse(readCheckingMenu);

                    if (selectionChecking == 1)
                    {
                        CheckingMenu.createCheckingAccount();
                    }
                    else if (selectionChecking == 2)
                    {
                        CheckingMenu.checkCheckingBalance();
                    }
                    else if (selectionChecking == 3)
                    {
                        CheckingMenu.addBalanceChecking();
                }
                    else if (selectionChecking == 4)
                    {
                        CheckingMenu.removeBalanceChecking();
                    }
                    else if (selectionChecking == 5)
                    {
                        CheckingMenu.closeCheckingAccount();
                    }
                    else if (selectionChecking == 6)
                    {
                        Console.Clear();
                        mainMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Please provide a valid selection from the Checking Menu\n\n");
                        menuChecking();
                    }
            }
        }//end of readCheckingInput()
        public static void menuSavings()
        {
            Console.WriteLine("Savings Account Menu\n");
            Console.WriteLine("Please select from the following optins\n");
            Console.WriteLine("1. Open a new Saving account");
            Console.WriteLine("2. Check Balance");
            Console.WriteLine("3. Add funds to the Account");
            Console.WriteLine("4. Withdrawal from the Account");
            Console.WriteLine("5. Close the Savings account");
            Console.WriteLine("6. Return to the Main Menu");
            readSavingsInput();

        }//end of menuSavings()
        public static void readSavingsInput()
        {
            string readSavingsMenu;
            int selectionSavings;
            readSavingsMenu = Console.ReadLine();

            if (readSavingsMenu == null || !int.TryParse(readSavingsMenu, out selectionSavings))
            {
                Console.Clear();
                Console.WriteLine("Please provide valid input to select from the Savings Menu\n\n");
                menuSavings();
            }
            else
            {
                selectionSavings = Int16.Parse(readSavingsMenu);

                if (selectionSavings == 1)
                {
                    SavingsMenu.createSavingsAccount();
                }
                else if (selectionSavings == 2)
                {

                }
                else if (selectionSavings == 3)
                {

                }
                else if (selectionSavings == 4)
                {

                }
                else if (selectionSavings == 5)
                {

                }
                else if (selectionSavings == 6)
                {
                    Console.Clear();
                    mainMenu();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please provide valid selection from the Savings Menu\n\n");
                    menuSavings();
                }
            }
        }//end of readSavingsInput()
        public static void menuLoan()
        {
            Console.WriteLine("Loan Menu");
            Console.WriteLine("Please select from the following optins\n");
            Console.WriteLine("1. Open a new Loan");
            Console.WriteLine("2. Make a payment to a Loan");
            Console.WriteLine("3. Close a loan");
            Console.WriteLine("4. Return to the Main Menu");
            readLoanInput();

        }//end of menuLoan()
        public static void readLoanInput()
        {
            string readLoanMenu;
            int selectionLoan;
            readLoanMenu = Console.ReadLine();

            if (readLoanMenu == null || !int.TryParse(readLoanMenu, out selectionLoan))
            {
                Console.Clear();
                Console.WriteLine("Please provide valid input to select from the Loan Menu\n\n");
                menuLoan();
            }
            else
            {
                selectionLoan = Int16.Parse(readLoanMenu);

                if (selectionLoan == 1)
                {

                }
                else if (selectionLoan == 2)
                {

                }
                else if (selectionLoan == 3)
                {

                }
                else if (selectionLoan == 4)
                {
                    Console.Clear();
                    mainMenu();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please provide valid selection from the Loan Menu\n\n");
                    menuLoan();
                }
            }

        }//end of readLoanInput()
        public static void serachMenu()
        {
            Console.WriteLine("Welcome to the search menu");
            Console.WriteLine("Please select from the following optins\n");
            Console.WriteLine("1. Search by Account number");
            Console.WriteLine("2. Serach by Client");
            Console.WriteLine("3. Return to the Main Menu");
            readSerachInput();

        }//end of searchMenu()
        public static void readSerachInput()
        {
            string readSearchMenu;
            int selectionSerach;
            readSearchMenu = Console.ReadLine();

            if (readSearchMenu == null || !int.TryParse(readSearchMenu, out selectionSerach))
            {
                Console.Clear();
                Console.WriteLine("Please provide valid input to select from the Search Menu\n\n");
                serachMenu();
            }
            else
            {
                selectionSerach = Int16.Parse(readSearchMenu);

                if (selectionSerach == 1)
                {

                }
                else if (selectionSerach == 2)
                {

                }
                else if (selectionSerach == 3)
                {
                    Console.Clear();
                    mainMenu();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please provide a valid selection from the Search Menu\n\n");
                    serachMenu();
                }
            }
        }//end of readSerachInput()
    }//end of class Menus
}//end of namespace CUReef
