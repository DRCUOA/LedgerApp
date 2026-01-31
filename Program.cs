//ledge console app
using LedgerApp.Models;

var transactions = new List<Transaction>();

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

      Console.WriteLine("Added:");
      Console.WriteLine($"{tx.Date:dd-MM-dd} | {tx.Description} | {tx.Amount}");
      break;
    default:
      Console.WriteLine("Unknown command");
      break;
    }
  }
