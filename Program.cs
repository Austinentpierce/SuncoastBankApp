using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using System.Globalization;
using System.IO;
using CsvHelper.Configuration;


namespace SuncoastBankApp
{
    class Transaction
    {
        public string AccountType { get; set; }
        public string TransactionType { get; set; }
        public int Amount { get; set; }
    }

    class Program
    {
        static int PromptForInteger(string prompt)
        {

            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that is not an option");
                Console.WriteLine();
                return 0;
            }

        }



        static void Main(string[] args)
        {
            var transactions = new List<Transaction>();

            if (File.Exists("transactions.csv"))
            {
                var fileReader = new StreamReader("transactions.csv");
                var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);

                transactions = csvReader.GetRecords<Transaction>().ToList();
                fileReader.Close();
            }

            //new Transaction { TransactionType = "Deposit", Amount = 500, AccountType = "Checking" };
            //new Transaction { TransactionType = "Deposit", Amount = 4000, AccountType = "Savings" };
            //new Transaction { TransactionType = "Withdraw", Amount = 375, AccountType = "Checking" };
            //new Transaction { TransactionType = "Withdraw", Amount = 2350, AccountType = "Savings" };

            var keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("Menu Choices");
                Console.WriteLine();
                Console.WriteLine("[D]eposit");
                Console.WriteLine("[W]ithdraw");
                Console.WriteLine("[B]alance");
                Console.WriteLine("[H]istory");
                Console.WriteLine("[Q]uit");

                var choice = Console.ReadLine().ToUpper();
                if (choice == "D")
                {
                    var transaction = new Transaction();
                    Console.WriteLine();
                    Console.WriteLine("Which account would you like to deposit to: ");
                    Console.WriteLine("[C]hecking");
                    Console.WriteLine("[S]avings");
                    var checkingOrSavings = Console.ReadLine().ToUpper();
                    if (checkingOrSavings == "C")
                    {
                        transaction.AccountType = "Checking";
                        Console.WriteLine();
                        transaction.Amount = PromptForInteger("How much would you like to deposit to your checking? ");
                        transaction.TransactionType = "Deposit";
                        transactions.Add(transaction);
                    }
                    else
                    if (checkingOrSavings == "S")
                    {
                        transaction.AccountType = "Savings";
                        Console.WriteLine();
                        transaction.Amount = PromptForInteger("How much would you like to deposit to your savings? ");
                        transaction.TransactionType = "Deposit";
                        transactions.Add(transaction);
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection");
                    }
                }

                else
                if (choice == "W")
                {
                    var transaction = new Transaction();
                    Console.WriteLine();
                    Console.WriteLine("Which account would you like to choose from: ");
                    Console.WriteLine("[C]hecking");
                    Console.WriteLine("[S]avings");
                    var checkingOrSavings = Console.ReadLine().ToUpper();
                    if (checkingOrSavings == "C")
                    {
                        Console.WriteLine();
                        transaction.Amount = PromptForInteger("What amount would you like to withdraw from your checking account? ");
                        var accountTotal = transactions.Where(transaction => transaction.TransactionType == "Checking").Sum(transaction => transaction.Amount);
                        if (transaction.Amount > accountTotal)
                        {
                            Console.WriteLine("Not enough money in account");
                            Console.WriteLine();
                        }
                        else
                        {
                            transaction.AccountType = "Checking";
                            transaction.TransactionType = "Withdraw";
                            transactions.Add(transaction);
                        }
                    }
                    else
                    if (checkingOrSavings == "S")
                    {
                        Console.WriteLine();
                        transaction.Amount = PromptForInteger("How much would you like to withdraw from your savings? ");
                        var accountTotal = transactions.Where(transaction => transaction.TransactionType == "Savings").Sum(transaction => transaction.Amount);
                        if (transaction.Amount > accountTotal)
                        {
                            Console.WriteLine("Not enough money in account");
                            Console.WriteLine();
                        }
                        else
                        {
                            transaction.AccountType = "Savings";
                            transaction.TransactionType = "Withdraw";
                            transactions.Add(transaction);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection");
                    }
                }
                else
                if (choice == "B")
                {
                    Console.WriteLine();
                    Console.WriteLine("Which account would you like to see the balance of:\n[C]hecking\n[S]avings ");
                    var checkingOrSavings = Console.ReadLine().ToUpper();
                    if (checkingOrSavings == "C")
                    {
                        var checkingBalance = 0;
                        foreach (var transaction in transactions)
                        {
                            if (transaction.AccountType == "Checking" && transaction.TransactionType == "Deposit")
                            {
                                checkingBalance += transaction.Amount;
                            }
                            if (transaction.AccountType == "Checking" && transaction.TransactionType == "Withdraw")
                            {
                                checkingBalance -= transaction.Amount;
                            }
                        }
                        Console.WriteLine($"Checking balance is {checkingBalance}");
                    }
                    if (checkingOrSavings == "S")
                    {
                        var savingsBalance = 0;
                        foreach (var transaction in transactions)
                        {
                            if (transaction.AccountType == "Savings" && transaction.TransactionType == "Deposit")
                            {
                                savingsBalance += transaction.Amount;
                            }
                            if (transaction.AccountType == "Savings" && transaction.TransactionType == "Withdraw")
                            {
                                savingsBalance -= transaction.Amount;
                            }
                        }
                        Console.WriteLine($"Savings balance is {savingsBalance}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection");
                    }

                }
                else
                if (choice == "H")
                {
                    Console.WriteLine();
                    Console.WriteLine("WHich account would you like to show the transactions of:\n[C]hecking\n[S]avings ");
                    var checkingOrSavings = Console.ReadLine().ToUpper();
                    if (checkingOrSavings == "C")
                    {
                        var checkingTransactions = transactions.Where(transaction => transaction.AccountType == "Checking");
                        foreach (var checkingTransaction in checkingTransactions)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{checkingTransaction.TransactionType} of {checkingTransaction.Amount}");
                        }
                    }
                    else
                    if (checkingOrSavings == "S")
                    {
                        var savingsTransactions = transactions.Where(transaction => transaction.AccountType == "Savings");
                        foreach (var savingsTransaction in savingsTransactions)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{savingsTransaction.TransactionType} of {savingsTransaction.Amount}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection");
                    }
                }
                else
                if (choice == "Q")
                {
                    keepGoing = false;
                }
                else
                {
                    Console.WriteLine("Invalid Selection");
                }
                var fileWriter = new StreamWriter("transactions.csv");

                var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);

                csvWriter.WriteRecords(transactions);

                fileWriter.Close();
            }

        }
    }



}
