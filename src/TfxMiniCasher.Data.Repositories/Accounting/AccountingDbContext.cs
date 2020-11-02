using Microsoft.EntityFrameworkCore;
using Xyz.TForce.DependencyInjection;
using Xyz.TForce.MiniCasher.Data.Repositories.Accounting.Entities.Specifications;

namespace Xyz.TForce.MiniCasher.Data.Repositories.Accounting
{

  [AutoInject(LifetimeScope = LifetimeScope.Singleton)]
  public class AccountingDbContext : DbContext
  {

    public AccountingDbContext(DbContextOptions<AccountingDbContext> options)
      : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      _ = modelBuilder.ApplyConfiguration(new AccountEntitySpecification());
      _ = modelBuilder.ApplyConfiguration(new OptionEntitySpecification());
      _ = modelBuilder.ApplyConfiguration(new TransactionEntitySpecification());
    }
  }
}
