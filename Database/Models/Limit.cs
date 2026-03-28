namespace Database.Models;

public class Limit
{
    public int AssetId { get; set; }
    public Asset Asset { get; set; } = null!;
    
    public decimal OnlineTransactionLimit { get; set; }
    public decimal WithdrawalLimit { get; set; }
    public decimal TransferLimit { get; set; }
    
}