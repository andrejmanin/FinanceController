using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database;


public class FCDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<CurrencyRecord> CurrencyRecords { get; set; }
    public DbSet<Limit> Limits { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    public FCDbContext(DbContextOptions<FCDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasKey(u => u.UserId);
        
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
        
        modelBuilder.Entity<Wallet>()
            .HasKey(w => w.WalletId);
        
        modelBuilder.Entity<Currency>()
            .HasKey(c => c.CurrencyId);
        
        modelBuilder.Entity<Currency>()
            .HasIndex(c => c.CurrencyName)
            .IsUnique();
        
        modelBuilder.Entity<CurrencyRecord>()
            .HasKey(c => c.CurrencyRecordId);
        
        modelBuilder.Entity<Asset>()
            .HasKey(a => a.AssetId);
        
        modelBuilder.Entity<Asset>()
            .HasIndex(a => a.AssetName)
            .IsUnique();
        
        modelBuilder.Entity<Destination>()
            .HasKey(a => a.DestinationId);
        
        modelBuilder.Entity<Destination>()
            .HasIndex(a => a.DestinationName)
            .IsUnique();
        
        modelBuilder.Entity<Transaction>()
            .HasKey(t => t.TransactionId);
        
        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Category)
            .WithMany(c => c.Transactions)
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Category>()
            .HasKey(c => c.CategoryId);
        
        modelBuilder.Entity<Category>()
            .HasIndex(c => c.CategoryName)
            .IsUnique();
        
        modelBuilder.Entity<Limit>()
            .HasKey(l => l.AssetId);
        
        modelBuilder.Entity<User>()
            .HasOne(u => u.Wallet)
            .WithOne(w => w.User)
            .HasForeignKey<Wallet>(w => w.UserId);
        
        modelBuilder.Entity<Wallet>()
            .HasIndex(w => w.UserId)
            .IsUnique();
        
        modelBuilder.Entity<Wallet>()
            .HasMany(w => w.Assets)
            .WithOne(a => a.Wallet)
            .HasForeignKey(a => a.WalletId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Asset>()
            .HasOne(a => a.Currency)
            .WithMany(c => c.Assets)
            .HasForeignKey(a => a.CurrencyId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Asset>()
            .HasMany(a => a.Transactions)
            .WithOne(t => t.Asset)
            .HasForeignKey(t => t.AssetId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Asset>()
            .HasOne(a => a.Limit)
            .WithOne(l => l.Asset)
            .HasForeignKey<Limit>(l => l.AssetId);
        
        modelBuilder.Entity<CurrencyRecord>()
            .HasOne(cr => cr.Currency)
            .WithMany(c => c.CurrencyRecords)
            .HasForeignKey(cr => cr.CurrencyId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Destination)
            .WithMany(d => d.Transactions)
            .HasForeignKey(t => t.DestinationId)
            .OnDelete(DeleteBehavior.Restrict);
        
        
        modelBuilder.Entity<Asset>()
            .Property(a => a.Balance)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Currency>()
            .Property(c => c.BuyPrice)
            .HasPrecision(18, 4);

        modelBuilder.Entity<Currency>()
            .Property(c => c.SellPrice)
            .HasPrecision(18, 4);

        modelBuilder.Entity<Transaction>()
            .Property(t => t.Amount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Limit>()
            .Property(l => l.OnlineTransactionLimit)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Limit>()
            .Property(l => l.WithdrawalLimit)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Limit>()
            .Property(l => l.TransferLimit)
            .HasPrecision(18, 2);
    }
    
}