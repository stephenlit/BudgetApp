using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;

namespace ClassLibrary1
{
    public class CSVParser
    {
        string filePath = string.Empty;

        public List<Transaction> ParseCSV()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = true,
                PrepareHeaderForMatch = args => args.Header.Replace(" ", "").Replace("-", ""),
            };


            Console.WriteLine("Drag and drop file or enter file path:");
            string? inputFilePath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputFilePath))
            {
                throw new ArgumentException("File path cannot be null or empty.");
            }

            filePath = inputFilePath.Trim();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                // Read the CSV file and map it to the Transaction class
                var records = csv.GetRecords<Transaction>().ToList();
                return records;
            }
        }
    }
}
