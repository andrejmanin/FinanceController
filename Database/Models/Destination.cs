using System.ComponentModel.DataAnnotations;

namespace Database.Models;

public class Destination
{
    [Key, Required]
    public int DestinationId { get; set; }
    [MaxLength(25)]
    public string DestinationName { get; set; } = null!;
    [MaxLength(75)]
    public string? Location { get; set; }
    
    public List<Transaction> Transactions { get; set; } = new();
}