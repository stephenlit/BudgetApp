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

        public Dictionary<string, List<Transaction>> CategorizeTransactions()
        {
            // Group transactions using LINQ
            var groupedTransactions = _transactions
                .GroupBy(t => t.SubDescription)
                .ToDictionary(group => group.Key ?? "Unknown", group => group.ToList());

            return groupedTransactions;
        }


    }
}
