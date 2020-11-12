using Microsoft.EntityFrameworkCore;
using Xyz.TForce.DependencyInjection;
using Xyz.TForce.MiniCasher.Data.Contracts.Accounting;

namespace Xyz.TForce.MiniCasher.Data.Repositories.Accounting
{

  [AutoInject(ServiceTypes = new[] { typeof(IAccountRepository) }, LifetimeScope = LifetimeScope.Scoped)]
  public class AccountRepository : IAccountRepository
  {

    private readonly DbContext _context;

    public AccountRepository(AccountingDbContext context)
    {
      _context = context;
    }
  }
}
