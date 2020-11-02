using Microsoft.EntityFrameworkCore;
using Xyz.TForce.MiniCasher.Data.Repositories.Accounting;

namespace Xyz.TForce.MiniCasher.Data.Migrations.Accounting
{

  public class AccountingFirebirdSqlDbContext : AccountingDbContext
  {

    public AccountingFirebirdSqlDbContext(DbContextOptions<AccountingDbContext> options)
        : base(options)
    {
    }
  }
}
