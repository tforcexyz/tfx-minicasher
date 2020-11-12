using Microsoft.EntityFrameworkCore;
using Xyz.TForce.DependencyInjection;
using Xyz.TForce.MiniCasher.Data.Contracts.Accounting;

namespace Xyz.TForce.MiniCasher.Data.Repositories.Accounting
{

  [AutoInject(ServiceTypes = new[] { typeof(ITransactionRepository) }, LifetimeScope = LifetimeScope.Scoped)]
  public class TransactionRepository : ITransactionRepository
  {

    private readonly DbContext _context;

    public TransactionRepository(AccountingDbContext context)
    {
      _context = context;
    }
  }
}
