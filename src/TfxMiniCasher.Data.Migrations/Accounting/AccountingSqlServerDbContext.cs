using Microsoft.EntityFrameworkCore;
using Xyz.TForce.MiniCasher.Data.Repositories.Accounting;

namespace Xyz.TForce.MiniCasher.Data.Migrations.Accounting
{

  public class AccountingSqlServerDbContext : AccountingDbContext
  {

    public AccountingSqlServerDbContext(DbContextOptions<AccountingDbContext> options)
        : base(options)
    {
    }
  }
}
