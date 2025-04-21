using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class TransactionCategorizer
    {
        private readonly List<Transaction> _transactions;

        public TransactionCategorizer(List<Transaction> transactions)
        {
            _transactions = new List<Transaction>(transactions);
        }

        public Dictionary<string, decimal> Categorize()
        {
            //Group the transactions by SubDescription
            var groupedTransactions = _transactions.GroupBy(t => t.SubDescription ?? "Unknown");

            //Cereate ad dictionary to store the unique sub-descriptions and their total amounts
            var groupedTotals = new Dictionary<string, decimal>();

            //Iterate through each group
            foreach (var group in groupedTransactions)
            {
                //The key of the group is the sub-description
                string subDescription = group.Key;

                //Calculate the total amount for all transaction in this group
                decimal totalAmount = group.Sum(t => decimal.TryParse(t.Amount, out var amt) ? amt : 0);

                //Add the sub-description and total amount to the dictionary
                groupedTotals.Add(subDescription, totalAmount);
            }
            System.Console.WriteLine(groupedTotals.Count + " unique sub-descriptions found.");

            return groupedTotals;
        }
    }
}
