using Microsoft.EntityFrameworkCore;
using Xyz.TForce.DependencyInjection;
using Xyz.TForce.MiniCasher.Data.Contracts.Accounting;

namespace Xyz.TForce.MiniCasher.Data.Repositories.Accounting
{

  [AutoInject(ServiceTypes = new[] { typeof(IOptionRepository) }, LifetimeScope = LifetimeScope.Scoped)]
  public class OptionRepository : IOptionRepository
  {

    private readonly DbContext _context;

    public OptionRepository(AccountingDbContext context)
    {
      _context = context;
    }
  }
}
