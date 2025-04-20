using System;
using System.Collections.Generic;
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

                switch (input)
                {
                    case "1":
                        Console.WriteLine(transactions.Count);
                        if (transactions == null || transactions.Count == 0)
                        {
                            Console.WriteLine("No transactions available to display.");
                        }
                        else
                        {
                            var viewer = new TransactionViewer();
                            viewer.ShowAll(transactions);
                        }

                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadKey();
                        break;

                    case "2":
                        if (transactions != null)
                        {
                            Dictionary<string, decimal> groupedAndTotaled = TransactionCategorizer.CategorizeTransactions(transactions);

                            Console.WriteLine("Grouped Transaction Totals from CSV File:");
                            var table = new ConsoleTable("Sub-Description", "Total Amount");
                            foreach (var item in groupedAndTotaled)
                            {
                                table.AddRow(item.Key, item.Value);
                            }
                            table.Write(Format.Default);
                            Console.WriteLine();
                        }
                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadLine();
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
