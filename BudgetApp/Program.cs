using ClassLibrary1;

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
            var categorizedTransactions = categorizer.CategorizeTransactions();

            // Display the categorized transactions
            Console.WriteLine("Categorized Transactions:");
            foreach (var category in categorizedTransactions)
            {
                Console.WriteLine($"Category: {category.Key}");
                foreach (var transaction in category.Value)
                {
                    Console.WriteLine($"  - {transaction.Description} | Amount: {transaction.Amount}");
                }
            }

            // Display the parsed transactions
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"Date: {transaction.Date.ToShortDateString()} | Description: {transaction.Description} | Sub Description: {transaction.SubDescription} | Amount: {transaction.Amount:C}");
            }
            Console.ReadKey();
        }

    }
    // Note: Make sure to handle exceptions and errors in a real-world application. This is a basic example.
    // You might want to add error handling for file not found, parsing errors, etc.
}
