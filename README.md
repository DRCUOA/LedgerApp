# LedgerApp

A simple console-based ledger application for tracking transactions.

## Description

LedgerApp is a .NET console application that allows you to add and track financial transactions. It provides an interactive command-line interface for managing your ledger entries.

## Requirements

- .NET 10.0 SDK or later

## Getting Started

### Build the Application

```bash
dotnet build
```

### Run the Application

```bash
dotnet run
```

## Usage

Once the application starts, you'll see a prompt:

```
> Ledger 
```

### Commands

- **`add <description> <amount>`** - Add a new transaction to the ledger
  - Example: `add Groceries 45.50`
  - The transaction will be added with today's date

- **`q`** - Quit the application

### Example Session

```
> Ledger add Groceries 45.50
Added:
31-01-2026 | Groceries | 45.50
> Ledger add Gas 30.00
Added:
31-01-2026 | Gas | 30.00
> Ledger q
```

## Project Structure

- `Program.cs` - Main application entry point and command loop
- `Models/Transaction.cs` - Transaction model with Date, Description, and Amount

## Notes

- Transactions are stored in memory and will be lost when the application exits
- All amounts are stored as decimal values
- Transaction dates default to the current date
