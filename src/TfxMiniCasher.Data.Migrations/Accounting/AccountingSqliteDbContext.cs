using Microsoft.EntityFrameworkCore;
using Xyz.TForce.MiniCasher.Data.Repositories.Accounting;

namespace Xyz.TForce.MiniCasher.Data.Migrations.Accounting
{

  public class AccountingSqliteDbContext : AccountingDbContext
  {

    public AccountingSqliteDbContext(DbContextOptions<AccountingDbContext> options)
        : base(options)
    {
    }
  }
}
