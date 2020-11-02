using Microsoft.EntityFrameworkCore;
using Xyz.TForce.MiniCasher.Data.Repositories.Accounting;

namespace Xyz.TForce.MiniCasher.Data.Migrations.Accounting
{

  public class AccountingMySqlDbContext : AccountingDbContext
  {

    public AccountingMySqlDbContext(DbContextOptions<AccountingDbContext> options)
        : base(options)
    {
    }
  }
}
