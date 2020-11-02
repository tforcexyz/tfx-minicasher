using Microsoft.EntityFrameworkCore;
using Xyz.TForce.MiniCasher.Data.Repositories.Accounting;

namespace Xyz.TForce.MiniCasher.Data.Migrations.Accounting
{

  public class AccountingPostgreSqlDbContext : AccountingDbContext
  {

    public AccountingPostgreSqlDbContext(DbContextOptions<AccountingDbContext> options)
        : base(options)
    {
    }
  }
}
