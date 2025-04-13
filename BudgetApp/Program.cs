using ClassLibrary1;
using ConsoleTables;

namespace BudgetApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Initialize the CSVParser and parse the CSV file
            var parser = new CSVParser();
            var transactions = parser.ParseCSV();
            //System.Console.WriteLine(transactions.Count + " transactions loaded from CSV file.");

            if (transactions != null)
            {
                Dictionary<string, decimal> groupedAndTotaled = TransactionCategorizer.CategorizeTransactions(transactions);
                System.Console.WriteLine(groupedAndTotaled.Count + " unique sub-descriptions found.");

                System.Console.WriteLine("Grouped Transaction Totals from CSV File:");
                var table = new ConsoleTable("Sub-Description", "Total Amount");
                foreach (var item in groupedAndTotaled)
                {
                    table.AddRow(item.Key, item.Value);
                }
                table.Write(Format.Default);
                System.Console.WriteLine();
            }

        }
    }
}

