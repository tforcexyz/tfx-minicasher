using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Xyz.TForce.Archetypes.DomainDrivenDevelopment;
using Xyz.TForce.DependencyInjection;
using Xyz.TForce.MiniCasher.Application.Contracts.Accounting.Commands;
using Xyz.TForce.MiniCasher.Data.Contracts.Accounting;
using Xyz.TForce.MiniCasher.Data.Contracts.Accounting.Models;
using Xyz.TForce.MiniCasher.Domain.Accounting.Entities;
using Xyz.TForce.MiniCasher.Domain.Accounting.Models;

namespace Xyz.TForce.MiniCasher.Application.Logic.Accounting
{

  [AutoInject(ServiceTypes = new[] { typeof(IRequestHandler<TransactionModifyCommand, TransactionModifyResult>) }, LifetimeScope = LifetimeScope.Transient)]
  public class TransactionModifyCommandHandler : ICommandHandler<TransactionModifyCommand, TransactionModifyResult>
  {

    private readonly ITransactionRepository _transactionRepository;

    public TransactionModifyCommandHandler(ITransactionRepository transactionRepository)
    {
      _transactionRepository = transactionRepository;
    }

    public async Task<TransactionModifyResult> Handle(TransactionModifyCommand command, CancellationToken cancellationToken)
    {
      TransactionModifyResult logicResult = new TransactionModifyResult();
      try
      {
        TransactionFindArgs transactionFindArgs = new TransactionFindArgs
        {
          TransactionId = command.Args.TransactionId
        };
        TransactionFindResult transactionFindResult = await _transactionRepository.FindAsync(transactionFindArgs)
          .ConfigureAwait(false);
        transactionFindResult.EnsureSuccess();

        Transaction transaction = Transaction.Load(transactionFindResult.Result);
        transaction.Modify(command.Args);
        TransactionUpdateArgs transactionUpdateArgs = new TransactionUpdateArgs
        {
          Transaction = transaction
        };
        TransactionUpdateResult transactionUpdateResult = await _transactionRepository.UpdateAsync(transactionUpdateArgs)
          .ConfigureAwait(false);
        transactionUpdateResult.EnsureSuccess();
        logicResult.Result = transactionUpdateResult.Result;
      }
      catch (Exception ex)
      {
        logicResult.Exception = ex;
      }
      return logicResult;
    }
  }
}
