using System.ComponentModel.DataAnnotations;

namespace Database.Models;

public class Asset
{
    [Key, Required]
    public int AssetId { get; set; }
    
    public string AssetName { get; set; } = null!;
    [Required]
    public decimal Balance { get; set; }
    public string State { get; set; } = null!;
    public DateTime? ExpirationDate { get; set; }
    
    public int CurrencyId { get; set; }
    public Currency Currency { get; set; } = null!;

    public Limit? Limit { get; set; }
    public List<Transaction>? Transactions { get; set; }
    
    public int WalletId { get; set; }
    public Wallet Wallet { get; set; } = null!;

}