using Microsoft.EntityFrameworkCore;
using Xyz.TForce.MiniCasher.Data.Contracts.Accounting;

namespace Xyz.TForce.MiniCasher.Data.Repositories.Accounting
{

  public class AccountRepository : IAccountRepository
  {

    private readonly DbContext _context;

    public AccountRepository(AccountingDbContext context)
    {
      _context = context;
    }
  }
}
