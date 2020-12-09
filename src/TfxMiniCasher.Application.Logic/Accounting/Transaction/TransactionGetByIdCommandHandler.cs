using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Xyz.TForce.Archetypes.DomainDrivenDevelopment;
using Xyz.TForce.DependencyInjection;
using Xyz.TForce.MiniCasher.Application.Contracts.Accounting.Commands;
using Xyz.TForce.MiniCasher.Data.Contracts.Accounting;
using Xyz.TForce.MiniCasher.Data.Contracts.Accounting.Models;
using Xyz.TForce.MiniCasher.Domain.Accounting.Models;

namespace Xyz.TForce.MiniCasher.Application.Logic.Accounting
{

  [AutoInject(ServiceTypes = new[] { typeof(IRequestHandler<TransactionGetByIdCommand, TransactionGetByIdResult>) }, LifetimeScope = LifetimeScope.Transient)]
  public class TransactionGetByIdCommandHandler : ICommandHandler<TransactionGetByIdCommand, TransactionGetByIdResult>
  {

    private readonly ITransactionRepository _transactionRepository;

    public TransactionGetByIdCommandHandler(ITransactionRepository transactionRepository)
    {
      _transactionRepository = transactionRepository;
    }

    public async Task<TransactionGetByIdResult> Handle(TransactionGetByIdCommand command, CancellationToken cancellationToken)
    {
      TransactionGetByIdResult logicResult = new TransactionGetByIdResult();
      try
      {
        TransactionFindArgs transactionFindArgs = new TransactionFindArgs
        {
          TransactionId = command.Args.TransactionId
        };
        TransactionFindResult transactionFindResult = await _transactionRepository.FindAsync(transactionFindArgs)
          .ConfigureAwait(false);
        transactionFindResult.EnsureSuccess();
        logicResult.Result = transactionFindResult.Result;
      }
      catch (Exception ex)
      {
        logicResult.Exception = ex;
      }
      return logicResult;
    }
  }
}
