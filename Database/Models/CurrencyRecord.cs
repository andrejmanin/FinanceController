using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Database.Models;

public class CurrencyRecord
{
    [Key]
    public int CurrencyRecordId { get; set; }
    public DateTime Date { get; set; }
    public decimal BuyPrice { get; set; }
    public decimal SellPrice { get; set; }
    
    public int CurrencyId { get; set; }
    public Currency Currency { get; set; } = null!;
}