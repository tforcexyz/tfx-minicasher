using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xyz.TForce.DependencyInjection;
using Xyz.TForce.MiniCasher.Data.Contracts.Accounting;
using Xyz.TForce.MiniCasher.Data.Contracts.Accounting.Models;
using Xyz.TForce.MiniCasher.Data.Repositories.Accounting.Entities;

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

    public async Task<AccountInsertResult> InsertAsync(AccountInsertArgs args)
    {
      AccountInsertResult logicResult = new AccountInsertResult();
      try
      {
        Account entity = args.Account.ToEntity();
        entity.AccountId = Guid.NewGuid();
        _context.Add(entity);
        await _context.SaveChangesAsync()
          .ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        logicResult.Exception = ex;
      }
      return logicResult;
    }
  }
}
