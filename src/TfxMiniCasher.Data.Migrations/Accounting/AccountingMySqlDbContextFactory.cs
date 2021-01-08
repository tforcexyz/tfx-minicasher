using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Xyz.TForce.MiniCasher.Data.Repositories.Accounting;

namespace Xyz.TForce.MiniCasher.Data.Migrations.Accounting
{

  public class AccountingMySqlDbContextFactory : IDesignTimeDbContextFactory<AccountingMySqlDbContext>
  {

    public AccountingMySqlDbContext CreateDbContext(string[] args)
    {
      DbContextOptionsBuilder<AccountingDbContext> optionsBuilder = new DbContextOptionsBuilder<AccountingDbContext>();
      string connstr = "Server=myServerAddress;Port=1234;Database=myDataBase;Uid=myUsername;Pwd=myPassword;";
      _ = optionsBuilder.UseMySql(connstr, options =>
      {
        _ = options.MigrationsAssembly(GetType().Assembly.FullName);
      });
      return new AccountingMySqlDbContext(optionsBuilder.Options);
    }
  }
}
