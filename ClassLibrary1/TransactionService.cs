using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClassLibrary1;
using ConsoleTables;

namespace ClassLibrary1
{
    public class TransactionService
    {
        public void ProcessTransactions(List<Transaction> transactions)
        {
            // Logic for processing transactions
        }

        public void DisplayTransactions(List<Transaction> transactions)
        {
            // Logic for displaying transactions
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
        }

        public void CategorizeTransactions(List<Transaction> transactions)
        {
            // Logic for categorizing transactions
            if (transactions != null && transactions.Any())
            {
                var categorizer = new TransactionCategorizer(transactions);
                var groupedAndTotaled = categorizer.Categorize();

                Console.WriteLine("Grouped Transaction Totals from CSV File:");
                var table = new ConsoleTable("Sub-Description", "Total Amount");

                foreach (var item in groupedAndTotaled)
                {
                    table.AddRow(item.Key, item.Value.ToString("C", CultureInfo.CurrentCulture));
                }

                table.Write(Format.Default);
            }
            else
            {
                Console.WriteLine("No transactions available to categorize.");
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}