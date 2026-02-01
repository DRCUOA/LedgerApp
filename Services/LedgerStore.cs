using System.Text.Json;
using LedgerApp.Models;

namespace LedgerApp.Services;

public class LedgerStore
{
  private const string FileName = "ledger.json";

  public List<Transaction> Load()
  {
    if (!File.Exists(FileName)) 
      return new List<Transaction>();

    var json = File.ReadAllText(FileName);
    return JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>(); 
  }

  public void Save(List<Transaction> transactions)
  {
    var json = JsonSerializer.Serialize(transactions, new JsonSerializerOptions { WriteIndented = true });

    File.WriteAllText(FileName, json);
  }
}