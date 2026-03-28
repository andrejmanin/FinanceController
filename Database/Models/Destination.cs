using System.ComponentModel.DataAnnotations;

namespace Database.Models;

public class Destination
{
    [Key, Required]
    public int DestinationId { get; set; }
    public string Name { get; set; } = null!;
    public string? Location { get; set; }
    public string Type { get; set; } = null!;

    public List<Transaction> Transactions { get; set; } = new();
}