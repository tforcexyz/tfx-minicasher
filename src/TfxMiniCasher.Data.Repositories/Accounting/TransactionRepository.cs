using Microsoft.EntityFrameworkCore;
using Xyz.TForce.MiniCasher.Data.Contracts.Accounting;

namespace Xyz.TForce.MiniCasher.Data.Repositories.Accounting
{

  public class TransactionRepository : IOptionRepository
  {

    private readonly DbContext _context;

    public TransactionRepository(AccountingDbContext context)
    {
      _context = context;
    }
  }
}
