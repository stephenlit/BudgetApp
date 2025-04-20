using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class TransactionCategorizer
    {
        private List<Transaction> _transactions;

        public TransactionCategorizer(List<Transaction> transactions)
        {
            _transactions = transactions;
        }

        public static Dictionary<string, decimal> CategorizeTransactions(List<Transaction> transactions)
        {
            //Group the transactions by SubDescription
            var groupedTransactions = transactions.GroupBy(t => t.SubDescription ?? "Unknown");
            //System.Console.WriteLine(groupedTransactions.Count() + " unique sub-descriptions found.");

            //Cereate ad dictionary to store the unique sub-descriptions and their total amounts
            var groupedTotals = new Dictionary<string, decimal>();

            //Iterate through each group
            foreach (var group in groupedTransactions)
            {
                //The key of the group is the sub-description
                string subDescription = group.Key;
                // System.Console.WriteLine(subDescription + " found.");

                //Calculate the total amount for all transaction in this group
                decimal totalAmount = group.Sum(t => decimal.Parse(t.Amount ?? "0"));

                //Add the sub-description and total amount to the dictionary
                groupedTotals.Add(subDescription, totalAmount);
            }
            System.Console.WriteLine(groupedTotals.Count + " unique sub-descriptions found.");

            return groupedTotals;

            // // Group transactions by sub-description and sum their amounts
            // var categorizedTransactions = transactions
            //     .GroupBy(t => t.SubDescription ?? "Unknown")
            //     .ToDictionary(group => group.Key, group => group.Sum(t => decimal.Parse(t.Amount ?? "0")));

            // return categorizedTransactions;
        }
        //{
        //     // Group transactions using LINQ
        //     var groupedTransactions = _transactions
        //         .GroupBy(t => t.SubDescription)
        //         .ToDictionary(group => group.Key ?? "Unknown", group => group.ToList());

        //     return groupedTransactions;
        // }


    }
}
