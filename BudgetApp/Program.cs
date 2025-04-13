using ClassLibrary1;
using ConsoleTables;

namespace BudgetApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Provide the correct path to your CSV file
            var filePath = "bank_statement.csv"; // Make sure this file is in the correct location

            // Initialize the CSVParser and parse the CSV file
            var parser = new CSVParser();
            var transactions = parser.ParseCSV(filePath);

            // Initialize the TransactionCategorizer and categorize the transactions
            var categorizer = new TransactionCategorizer(transactions);
            var groupedTransactions = categorizer.GroupTransactions();
            // Display the grouped transactions in a table format
            var table = new ConsoleTable("Sub-description", "Total Amount");
            foreach (var transaction in groupedTransactions)
            {
                table.AddRow(transaction.SubDescription, transaction.Amount);
            }
            table.Write(Format.Alternative);
            Console.WriteLine();
            // Display the total amount of all transactions
            var totalAmount = transactions.Sum(t => decimal.Parse(t.Amount ?? "0"));
            Console.WriteLine($"Total Amount: {totalAmount:C}");
            // Display the total number of transactions
            var totalTransactions = transactions.Count;
            Console.WriteLine($"Total Transactions: {totalTransactions}");
            // Display the average amount of transactions
            var averageAmount = totalTransactions > 0 ? totalAmount / totalTransactions : 0;
            Console.WriteLine($"Average Amount: {averageAmount:C}");
            // Display the highest transaction amount
            var highestTransaction = transactions.Max(t => decimal.Parse(t.Amount ?? "0"));
            Console.WriteLine($"Highest Transaction: {highestTransaction:C}");
        }
    }
}

