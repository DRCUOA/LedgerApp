namespace LedgerApp.Models;

public class Transaction
{
  public string Id { get; set; } = Guid.NewGuid().ToString();
  public DateTime Date { get; set; }
  public string Description { get; set; } = "";
  public decimal Amount { get; set; }
}