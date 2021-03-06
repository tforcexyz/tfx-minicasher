using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Xyz.TForce.MiniCasher.Data.Repositories.Accounting;

namespace Xyz.TForce.MiniCasher.Data.Migrations.Accounting
{

  public class AccountingPostgreSqlDbContextFactory : IDesignTimeDbContextFactory<AccountingPostgreSqlDbContext>
  {

    public AccountingPostgreSqlDbContext CreateDbContext(string[] args)
    {
      DbContextOptionsBuilder<AccountingDbContext> optionsBuilder = new DbContextOptionsBuilder<AccountingDbContext>();
      string connstr = "localhost";
      _ = optionsBuilder.UseNpgsql(connstr, options =>
      {
        _ = options.MigrationsAssembly(GetType().Assembly.FullName);
      });
      return new AccountingPostgreSqlDbContext(optionsBuilder.Options);
    }
  }
}
