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
using Xyz.TForce.Reflection;

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

    public async Task<AccountFindResult> FindAsync(AccountFindArgs args)
    {
      AccountFindResult logicResult = new AccountFindResult();
      try
      {
        AccountDTO result = await _context.Set<Account>().Where(x => x.AccountId == args.AccountId)
          .Select(x => x.ToDTO())
          .FirstOrDefaultAsync()
          .ConfigureAwait(false);
        logicResult.Result = result;
      }
      catch (Exception ex)
      {
        logicResult.Exception = ex;
      }
      return logicResult;
    }

    public async Task<AccountInsertResult> InsertAsync(AccountInsertArgs args)
    {
      AccountInsertResult logicResult = new AccountInsertResult();
      try
      {
        Account entity = args.Account.ToEntity();
        entity.MetaCreatedTimeCode = DateTime.UtcNow.ToSuperEpochUtc();
        entity.MetaModifiedTimeCode = DateTime.UtcNow.ToSuperEpochUtc();
        _ = _context.Add(entity);
        _ = await _context.SaveChangesAsync()
          .ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        logicResult.Exception = ex;
      }
      return logicResult;
    }

    public async Task<AccountRemoveResult> RemoveAsync(AccountRemoveArgs args)
    {
      AccountRemoveResult logicResult = new AccountRemoveResult();
      try
      {
        Account existingAccount = await _context.Set<Account>().Where(x => x.AccountId == args.AccountId)
          .FirstAsync()
          .ConfigureAwait(false);
        _context.Entry(existingAccount).State = EntityState.Deleted;
        _ = await _context.SaveChangesAsync()
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
            ParentAccountId = x.ParentAccountId,
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

    public async Task<AccountUpdateResult> UpdateAsync(AccountUpdateArgs args)
    {
      AccountUpdateResult logicResult = new AccountUpdateResult();
      try
      {
        Account account = args.Account.ToEntity();
        Account existingAccount = await _context.Set<Account>().Where(x => x.AccountId == account.AccountId)
          .FirstAsync()
          .ConfigureAwait(false);
        account.Id = existingAccount.Id;
        account.AccountId = existingAccount.AccountId;
        account.MetaCreatedTimeCode = existingAccount.MetaCreatedTimeCode;
        account.MetaIsDeleted = existingAccount.MetaIsDeleted;
        account.MetaRowVersion = existingAccount.MetaRowVersion;
        MappingExpress.CopyProperties(account, existingAccount);
        existingAccount.MetaModifiedTimeCode = DateTime.UtcNow.ToSuperEpochUtc();
        _ = await _context.SaveChangesAsync()
          .ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        logicResult.Exception = ex;
      }
      return logicResult;
    }

    private Expression<Func<Account, bool>> CreatePredicate(AccountSelectArgs args)
    {
      _ = args;
      Expression<Func<Account, bool>> predicate = PredicateBuilder.New<Account>(true);
      predicate = predicate.And(x => !x.MetaIsDeleted);
      return predicate;
    }
  }
}
