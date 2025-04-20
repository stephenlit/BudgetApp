# BudgetApp

BudgetApp is a console-based application designed to help users manage and analyze their financial transactions. It allows users to parse CSV files containing transaction data and provides various options to view, categorize, and filter the transactions.

## Features

- Parse CSV files containing transaction data.
- Display all transactions in a tabular format.
- Group transactions by category and calculate totals.
- (Planned) Filter transactions by date, amount, or description.

## Installation

1. Clone the repository:
2. Open the solution in Visual Studio 2022.
3. Build the project to restore dependencies.

## Usage

1. Run the application.
2. Follow the menu options to:
   - View all transactions.
   - Group transactions by category.
   - (Planned) Filter transactions by date, amount, or description.

## CSV File Format

The application expects a CSV file with the following headers:
- `Filter`
- `Date`
- `Description`
- `Sub-description`
- `Type of Transaction`
- `Amount`
- `Balance`

Ensure the file is formatted correctly before parsing.

## Technologies Used

- C# 13.0
- .NET 9
- [CsvHelper](https://joshclose.github.io/CsvHelper/) for CSV parsing
- [ConsoleTables](https://github.com/khalidabuhakmeh/ConsoleTables) for tabular display

## Planned Features

- Filter transactions by date range.
- Sort transactions by amount (high to low).
- Search transactions by description.

## Contributing

Contributions are welcome! Feel free to open issues or submit pull requests.

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.
