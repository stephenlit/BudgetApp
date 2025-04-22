using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using ConsoleTables;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace BudgetApp
{
    class Menu
    {
        public bool ShowMenu()
        {
            var parser = new CSVParser();
            List<Transaction> transactions = new List<Transaction>();
            // Initialize the CSVParser and parse the CSV file
            transactions = parser.ParseCSV();

            while (true)
            {
                Console.WriteLine("1. Show all transactions");
                Console.WriteLine("2. Show transactions by category");
                Console.WriteLine("3. Show transactions by date");
                Console.WriteLine("4. Show transactions by amount");
                Console.WriteLine("5. Show transactions by description");

                Console.WriteLine("0. To exit application");
                Console.WriteLine("\n");

                string? input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("No input detected. Please try again.");
                    Console.ReadKey();
                    continue;
                }
                var transactionService = new TransactionService();

                switch (input)
                {
                    case "1":

                        transactionService.DisplayTransactions(transactions);
                        break;

                    case "2":

                        transactionService.CategorizeTransactions(transactions);
                        break;

                    case "3":
                        // TODO: Implement logic for showing transactions by date
                        break;

                    case "4":
                        // TODO: Implement logic for showing transactions by amount (high to low)
                        break;

                    case "5":
                        // TODO: Implement logic for showing transactions by description
                        break;

                    case "0":
                        Console.WriteLine("Exiting application...");
                        return false;

                    default:
                        Console.WriteLine("Invalid input. Please select a valid option.");
                        break; // Ensure control does not fall out of the switch
                }
            }
        }
    }
}
