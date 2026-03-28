using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceConsole;

internal partial class Program
{
    public static async Task CreateCurrency(
        string name,
        string dependentName,
        decimal buyPrice,
        decimal sellPrice,
        FCDbContext context)
    {
        var currency = context.Currencies.Add(new Currency
        {
            CurrencyName = name,
            DependentName = dependentName,
            BuyPrice = buyPrice,
            SellPrice = sellPrice
        });
        await context.SaveChangesAsync();
    }
    
    public static async Task CreateAsset(
        string name,
        decimal balance,
        string state,
        int currency,
        int wallet, FCDbContext context)
    {

        var asset = context.Assets.Add(new Asset
        {
            AssetName = name,
            Balance = balance,
            State = state,
            CurrencyId = currency,
            WalletId = wallet
        });
        await context.SaveChangesAsync();
    }
    
    public Task CreateTransaction(
        decimal amount, 
        string direction,
        string state,
        DateTime date,
        int asset,
        int destination
        )
    {
        return Task.CompletedTask;
    }
    
    public static async Task Main(string[] args)
    {
        var factory = new FCdbContextFactory();

        using var db = factory.CreateDbContext(args);

        db.Database.Migrate();

        Console.WriteLine("Database ready.");
        db.SaveChanges();
        Console.WriteLine("Database created.");

        // await CreateAsset("btc", (decimal)0.00001, "open", 1, 1, db);
        await CreateCurrency("US Dollar", "usd", 45, 46, db);
    }
}