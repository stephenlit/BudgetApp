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
