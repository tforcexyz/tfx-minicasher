using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Xyz.TForce.MiniCasher.Data.Repositories.Accounting;

namespace Xyz.TForce.MiniCasher.Data.Migrations.Accounting
{

  public class AccountingSqlServerDbContextFactory : IDesignTimeDbContextFactory<AccountingSqlServerDbContext>
  {

    public AccountingSqlServerDbContext CreateDbContext(string[] args)
    {
      DbContextOptionsBuilder<AccountingDbContext> optionsBuilder = new DbContextOptionsBuilder<AccountingDbContext>();
      string connstr = "localhost";
      _ = optionsBuilder.UseSqlServer(connstr, options =>
      {
        _ = options.MigrationsAssembly(GetType().Assembly.FullName);
      });
      return new AccountingSqlServerDbContext(optionsBuilder.Options);
    }
  }
}
