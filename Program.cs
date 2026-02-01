//ledge console app
using LedgerApp.Models;
using System.Linq;
using LedgerApp.Services;

var store = new LedgerStore();
var transactions = store.Load();

while (true) { 
  Console.WriteLine("> Ledger ");
  var input = Console.ReadLine();

  if (string.IsNullOrWhiteSpace(input)) continue;

  input = input.Trim();
  input = input.ToLowerInvariant();

  if (input.Equals("q", StringComparison.OrdinalIgnoreCase)) break;

  var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
  var command = parts[0];

  switch (command) {
    case "add":
      {
        if (parts.Length < 3) {
          Console.WriteLine("Usage: add <description> <amount>");
          break;
        }

        var description = parts[1];

        if (!decimal.TryParse(parts[2], out var amount)) 
        {
          Console.WriteLine("Invalid amount");
          break;
        }

        var tx = new Transaction
        {
          Date = DateTime.Today,
          Description = description,
          Amount = amount
        };

        transactions.Add(tx);
        store.Save(transactions);
        
        Console.WriteLine("Added:");
        Console.WriteLine($"{tx.Date:dd-MM-dd} | {tx.Description} | {tx.Amount}");
        break;
      }

    case "list":
      {
        if (transactions.Count == 0) {
          Console.WriteLine("No transactions found");
          break;
        }

        foreach (var tx in transactions) 
        {
          Console.WriteLine(
            $"{tx.Date:dd-MM-yyyy} | {tx.Description, -15} | {tx.Amount, 10}"
          );
        }

        break;
      }

    case "balance":
      {
        var total = transactions.Sum(t => t.Amount);
        Console.WriteLine($"Balance: {total}");
        break;
      }


    default:
      Console.WriteLine("Unknown command");
      break;
    }
  }
