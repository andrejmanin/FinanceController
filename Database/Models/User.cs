using System.ComponentModel.DataAnnotations;

namespace Database.Models;

public class User
{
    [Key, Required]
    public int UserId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public int Age { get; set; }
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;

    public Wallet? Wallet { get; set; }
}