using System.ComponentModel.DataAnnotations;

namespace Database.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public int Necessity { get; set; }
    
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();
}