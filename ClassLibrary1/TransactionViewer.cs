using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using Spectre.Console;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace ClassLibrary1
{
    sealed public class TransactionViewer
    {
        private List<Transaction>? _transactions;

        public void ShowAll(List<Transaction> transactions)
        {
            _transactions = new List<Transaction>(transactions);


            if (_transactions == null || _transactions.Count == 0)
            {
                Console.WriteLine("No transactions to display.");
                return;
            }

            RenderTable(_transactions);
        }


        private void RenderTable(IEnumerable<Transaction> transactions)
        {

            var table = new Table();

            // Add some columns
            table.AddColumn("Date");
            table.AddColumn(new TableColumn("[green]Description[/]").Centered());
            table.AddColumn("Amount");
            table.AddColumn("Category");

            foreach (var transaction in _transactions)

            {

                // Add each transaction to the table
                table.AddRow(transaction.Date.ToShortDateString(),
                             $"[yellow]{Markup.Escape(transaction.Description ?? "No Description")}[/]", // Handle null description
                             decimal.TryParse(transaction.Amount, out var amount)
                                ? amount.ToString("C", CultureInfo.CurrentCulture)
                                : "Invalid Amount", // Safely parse and format amount
                             transaction.SubDescription ?? "Uncategorized"); // Handle null category
            }

            // Render the table to the console
            AnsiConsole.Write(table);
        }
        
    }

}

