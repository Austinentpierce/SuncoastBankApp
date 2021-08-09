using System;
using System.Collections.Generic;
using System.Linq;

namespace SuncoastBankApp
{
    class Transaction
    {
        public int Amount { get; set; }
        public string Type { get; set; }
        public DateTime TimeStamp { get; set; }
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
        new Transaction {Type = "Deposit", Amount = 100, Account = "Checking" },
        new Transaction {Type = "Deposit", Amount = 4000, Account = "Saving" },
        new Transaction {Type = "Withdraw", Amount = 500, Account = "Checking" },
      };


        }
    }



}
