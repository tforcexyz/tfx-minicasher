using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Xyz.TForce.MiniCasher.Data.Repositories.Accounting;

namespace Xyz.TForce.MiniCasher.Data.Migrations.Accounting
{

  public class AccountingSqliteDbContextFactory : IDesignTimeDbContextFactory<AccountingSqliteDbContext>
  {

    public AccountingSqliteDbContext CreateDbContext(string[] args)
    {
      DbContextOptionsBuilder<AccountingDbContext> optionsBuilder = new DbContextOptionsBuilder<AccountingDbContext>();
      string connstr = "localhost";
      _ = optionsBuilder.UseSqlite(connstr, options =>
      {
        _ = options.MigrationsAssembly(GetType().Assembly.FullName);
      });
      return new AccountingSqliteDbContext(optionsBuilder.Options);
    }
  }
}
