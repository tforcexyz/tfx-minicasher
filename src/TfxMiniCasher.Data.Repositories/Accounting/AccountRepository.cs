using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Xyz.TForce.DependencyInjection;
using Xyz.TForce.MiniCasher.Data.Contracts.Accounting;
using Xyz.TForce.MiniCasher.Data.Contracts.Accounting.Models;
using Xyz.TForce.MiniCasher.Data.Repositories.Accounting.Entities;
using Xyz.TForce.MiniCasher.Data.Repositories.Accounting.Types;
using Xyz.TForce.MiniCasher.Domain.Accounting.DTOs;

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

    public async Task<AccountSelectResult> SelectAsync(AccountSelectArgs args)
    {
      AccountSelectResult logicResult = new AccountSelectResult();
      try
      {
        Expression<Func<Account, bool>> predicate = CreatePredicate(args);
        AccountDTO[] results = await _context.Set<Account>().Where(predicate)
          .Select(x => new AccountDTO
          {
            AccountId = x.AccountId,
            AccountCode = x.AccountCode,
            AccountName = x.AccountName,
            AccountDescription = x.AccountDescription,
            DebitOrCredit = x.DebitOrCredit.ToDomainType(),
            IsHidden = x.IsHidden
          })
          .AsNoTracking()
          .ToArrayAsync()
          .ConfigureAwait(false);
        logicResult.Results = results;
      }
      catch (Exception ex)
      {
        logicResult.Exception = ex;
      }
      return logicResult;
    }

    private Expression<Func<Account, bool>> CreatePredicate(AccountSelectArgs args)
    {
      Expression<Func<Account, bool>> predicate = PredicateBuilder.New<Account>(true);
      predicate = predicate.And(x => !x.MetaIsDeleted);
      return predicate;
    }
  }
}
