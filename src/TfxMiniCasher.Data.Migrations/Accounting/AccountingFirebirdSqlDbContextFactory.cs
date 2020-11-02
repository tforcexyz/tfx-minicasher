using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Xyz.TForce.MiniCasher.Data.Repositories.Accounting;

namespace Xyz.TForce.MiniCasher.Data.Migrations.Accounting
{

  public class AccountingFirebirdSqlDbContextFactory : IDesignTimeDbContextFactory<AccountingFirebirdSqlDbContext>
  {

    public AccountingFirebirdSqlDbContext CreateDbContext(string[] args)
    {
      DbContextOptionsBuilder<AccountingDbContext> optionsBuilder = new DbContextOptionsBuilder<AccountingDbContext>();
      string connstr = "localhost";
      _ = optionsBuilder.UseFirebird(connstr, options =>
      {
        _ = options.MigrationsAssembly(GetType().Assembly.FullName);
      });
      return new AccountingFirebirdSqlDbContext(optionsBuilder.Options);
    }
  }
}
