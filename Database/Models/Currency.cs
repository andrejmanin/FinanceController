using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Database.Models;

public class Currency
{
    [Key]
    public int CurrencyId { get; set; }
    
    [MaxLength(5)]
    public string CurrencyName { get; set; } = null!;
    [MaxLength(5)]
    public string DependentName { get; set; } = null!;
    public decimal BuyPrice { get; set; }
    public decimal SellPrice { get; set; }

    public List<Transaction> Transactions { get; set; } = new();
    public List<Asset> Assets { get; set; } = new();
    public List<CurrencyRecord> CurrencyRecords { get; set; } = new();
}