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

  [AutoInject(ServiceTypes = new[] { typeof(IRequestHandler<TransactionDeleteCommand, TransactionDeleteResult>) }, LifetimeScope = LifetimeScope.Transient)]
  public class TransactionDeleteCommandHandler : ICommandHandler<TransactionDeleteCommand, TransactionDeleteResult>
  {

    private readonly ITransactionRepository _transactionRepository;

    public TransactionDeleteCommandHandler(ITransactionRepository transactionRepository)
    {
      _transactionRepository = transactionRepository;
    }

    public async Task<TransactionDeleteResult> Handle(TransactionDeleteCommand command, CancellationToken cancellationToken)
    {
      TransactionDeleteResult logicResult = new TransactionDeleteResult();
      try
      {
        Guid transactionId = Transaction.Delete(command.Args);
        TransactionRemoveArgs transactionRemoveArgs = new TransactionRemoveArgs
        {
          TransactionId = transactionId
        };
        TransactionRemoveResult transactionRemoveResult = await _transactionRepository.RemoveAsync(transactionRemoveArgs)
          .ConfigureAwait(false);
        transactionRemoveResult.EnsureSuccess();
        logicResult.Result = transactionRemoveResult.Result;
      }
      catch (Exception ex)
      {
        logicResult.Exception = ex;
      }
      return logicResult;
    }
  }
}
