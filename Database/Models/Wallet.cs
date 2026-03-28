using System.ComponentModel.DataAnnotations;

namespace Database.Models;

public class Wallet
{
    [Key, Required]
    public int WalletId { get; set; }
    [Key, Required]
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public List<Asset> Assets { get; set; } = new();
}