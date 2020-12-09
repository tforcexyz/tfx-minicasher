using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Xyz.TForce.Archetypes.DomainDrivenDevelopment;
using Xyz.TForce.DependencyInjection;
using Xyz.TForce.MiniCasher.Data.Contracts.Accounting;
using Xyz.TForce.MiniCasher.Data.Contracts.Accounting.Models;
using Xyz.TForce.MiniCasher.Data.Repositories.Accounting.Entities;
using Xyz.TForce.MiniCasher.Domain.Accounting.DTOs;
using Xyz.TForce.Reflection;

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

    public async Task<TransactionFindResult> FindAsync(TransactionFindArgs args)
    {
      TransactionFindResult logicResult = new TransactionFindResult();
      try
      {
        TransactionDTO result = await _context.Set<Transaction>().Where(x => x.TransactionId == args.TransactionId)
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

    public async Task<TransactionInsertResult> InsertAsync(TransactionInsertArgs args)
    {
      TransactionInsertResult logicResult = new TransactionInsertResult();
      try
      {
        Transaction entity = args.Transaction.ToEntity();
        entity.MetaCreatedTimeCode = DateTime.UtcNow.ToSuperEpochUtc();
        entity.MetaModifiedTimeCode = DateTime.UtcNow.ToSuperEpochUtc();
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

    public async Task<TransactionRemoveResult> RemoveAsync(TransactionRemoveArgs args)
    {
      TransactionRemoveResult logicResult = new TransactionRemoveResult();
      try
      {
        Transaction existingAccount = await _context.Set<Transaction>().Where(x => x.TransactionId == args.TransactionId)
          .FirstAsync()
          .ConfigureAwait(false);
        _context.Entry(existingAccount).State = EntityState.Deleted;
        await _context.SaveChangesAsync()
          .ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        logicResult.Exception = ex;
      }
      return logicResult;
    }

    public async Task<TransactionSelectResult> SelectAsync(TransactionSelectArgs args)
    {
      TransactionSelectResult logicResult = new TransactionSelectResult();
      try
      {
        Expression<Func<Transaction, bool>> predicate = CreatePredicate(args);
        TransactionDTO[] results = await _context.Set<Transaction>().Where(predicate)
          .Select(x => new TransactionDTO
          {
            TransactionId = x.TransactionId,
            TransactionCode = x.TransactionCode,
            TransactionName = x.TransactionName,
            CreditAccountId = x.CreditAccountId,
            DebitAccountId = x.DebitAccountId,
            TransactionAmount = x.TransactionAmount,
            IssuedTime = TimeUnit.FromTimeCode(x.IssuedTimeCode)
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

    public async Task<TransactionUpdateResult> UpdateAsync(TransactionUpdateArgs args)
    {
      TransactionUpdateResult logicResult = new TransactionUpdateResult();
      try
      {
        Transaction newEntity = args.Transaction.ToEntity();
        Transaction existingEntity = await _context.Set<Transaction>().Where(x => x.TransactionId == newEntity.TransactionId)
          .FirstAsync()
          .ConfigureAwait(false);
        newEntity.Id = existingEntity.Id;
        newEntity.MetaCreatedTimeCode = existingEntity.MetaCreatedTimeCode;
        newEntity.MetaIsDeleted = existingEntity.MetaIsDeleted;
        newEntity.MetaRowVersion = existingEntity.MetaRowVersion;
        MappingExpress.CopyProperties(newEntity, existingEntity);
        existingEntity.MetaModifiedTimeCode = DateTime.UtcNow.ToSuperEpochUtc();
        await _context.SaveChangesAsync()
          .ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        logicResult.Exception = ex;
      }
      return logicResult;
    }

    private Expression<Func<Transaction, bool>> CreatePredicate(TransactionSelectArgs args)
    {
      Expression<Func<Transaction, bool>> predicate = PredicateBuilder.New<Transaction>(true);
      predicate = predicate.And(x => !x.MetaIsDeleted);
      return predicate;
    }
  }
}
