using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace ClassLibrary1
{
    public class Transaction
    {
        [Name("Filter")]
        public string? Filter { get; set; }

        [Name("Date")]
        public DateTime Date { get; set; }

        [Name("Description")]
        public string? Description { get; set; }

        [Name("Sub-description")]
        public string? SubDescription { get; set; }

        [Name("Type of Transaction")]
        public string? TypeOfTransaction { get; set; }

        [Name("Amount")]
        public string? Amount { get; set; }

        [Name("Balance")]
        public string? Balance { get; set; }
    }
}
