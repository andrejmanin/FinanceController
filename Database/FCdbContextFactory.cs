namespace Database;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class FCdbContextFactory : IDesignTimeDbContextFactory<FCDbContext>
{
    public FCDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FCDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=127.0.0.1,14333;Database=FinanceAssistant;User Id=sa;Password=Qwerty123@;Encrypt=True;TrustServerCertificate=True;");
        return new FCDbContext(optionsBuilder.Options);
    }
}