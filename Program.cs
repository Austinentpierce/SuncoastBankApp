using System;
using System.Collections.Generic;
using System.Linq;

namespace SuncoastBankApp
{
    class Transaction
    {
        public int Amount { get; set; }
        public string Type { get; set; }
        public string Account { get; set; }

    }

    class Program
    {
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);

            var userInput = Console.ReadLine();

            return userInput;
        }
        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);

            var userInput = Console.ReadLine();
            var userInputAsNumber = int.Parse(userInput);

            return userInputAsNumber;
        }

        static void Main(string[] args)
        {
            var transactions = new List<Transaction>()
          {
          new Transaction {Type = "Deposit", Amount = 500, Account = "Checking" },
          new Transaction {Type = "Deposit", Amount = 4000, Account = "Savings" },
          new Transaction {Type = "Withdrawl", Amount = 375, Account = "Checking" },
          new Transaction {Type = "Withdrawl", Amount = 2350, Account = "Savings"}
          };
            var userHasChosenToQuit = false;
            while (userHasChosenToQuit == false)
            {
                Console.WriteLine("Menu Choices");
                Console.WriteLine();
                Console.WriteLine("Deposit");
                Console.WriteLine("Transfer");
                Console.WriteLine("Withdraw");
                Console.WriteLine("Balance");
                Console.WriteLine("History");
                Console.WriteLine("Quit");

                var choice = PromptForString("Choice : ").ToUpper();
                if (choice == "Deposit")
                {
                    Console.WriteLine($)
                }
            }

        }
    }



}
