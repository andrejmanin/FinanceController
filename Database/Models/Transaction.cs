using System.ComponentModel.DataAnnotations;

namespace Database.Models;

public class Transaction
{
    [Key]
    public int TransactionId { get; set; }
    public decimal Amount { get; set; }
    public string Direction { get; set; } = null!;
    public string State { get; set; } = null!;
    public DateTime Date { get; set; }
    
    public int AssetId { get; set; }
    public Asset Asset { get; set; } = null!;
    
    public int DestinationId { get; set; }
    public Destination Destination { get; set; } = null!;
    
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}