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

  [AutoInject(ServiceTypes = new[] { typeof(IRequestHandler<TransactionCreateCommand, TransactionCreateResult>) }, LifetimeScope = LifetimeScope.Transient)]
  public class TransactionCreateCommandHandler : ICommandHandler<TransactionCreateCommand, TransactionCreateResult>
  {

    private readonly ITransactionRepository _transactionRepository;

    public TransactionCreateCommandHandler(ITransactionRepository transactionRepository)
    {
      _transactionRepository = transactionRepository;
    }

    public async Task<TransactionCreateResult> Handle(TransactionCreateCommand command, CancellationToken cancellationToken)
    {
      TransactionCreateResult logicResult = new TransactionCreateResult();
      try
      {
        Transaction transaction = Transaction.Create(command.Args);
        TransactionInsertArgs transactionInsertArgs = new TransactionInsertArgs
        {
          Transaction = transaction
        };
        TransactionInsertResult transactionInsertResult = await _transactionRepository.InsertAsync(transactionInsertArgs)
          .ConfigureAwait(false);
        transactionInsertResult.EnsureSuccess();
        logicResult.Result = transactionInsertResult.Result;
      }
      catch (Exception ex)
      {
        logicResult.Exception = ex;
      }
      return logicResult;
    }
  }
}
