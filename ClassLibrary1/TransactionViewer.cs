using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace ClassLibrary1
{
    public class TransactionViewer
    {
        public void ShowAll(List<Transaction> transactions)
        {
            if (transactions == null || transactions.Count == 0)
            {
                Console.WriteLine("No transactions to display.");
                return;
            }

            // Create a table with column names: Date, Description, Amount, Category
            var table = new ConsoleTable("Date", "Description", "Amount", "Category");

            foreach (var transaction in transactions)
            {
                // Make sure each transaction is added correctly to the table
                table.AddRow(transaction.Date.ToShortDateString(),
                             transaction.Description,
                             transaction.Amount,
                             transaction.SubDescription ?? "Uncategorized"); // Handle null category if applicable

            }

            // Write the table to the console
            table.Write(Format.Default);
        }
    }

}

