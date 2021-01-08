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

  [AutoInject(ServiceTypes = new[] { typeof(IRequestHandler<TransactionSearchCommand, TransactionSearchResult>) }, LifetimeScope = LifetimeScope.Transient)]
  public class TransactionSearchCommandHandler : ICommandHandler<TransactionSearchCommand, TransactionSearchResult>
  {

    private readonly ITransactionRepository _transactionRepository;

    public TransactionSearchCommandHandler(ITransactionRepository transactionRepository)
    {
      _transactionRepository = transactionRepository;
    }

    public async Task<TransactionSearchResult> Handle(TransactionSearchCommand command, CancellationToken cancellationToken)
    {
      TransactionSearchResult logicResult = new TransactionSearchResult();
      try
      {
        TransactionSelectArgs transactionSelectArgs = new TransactionSelectArgs();
        TransactionSelectResult transactionSelectResult = await _transactionRepository.SelectAsync(transactionSelectArgs)
          .ConfigureAwait(false);
        transactionSelectResult.EnsureSuccess();
        logicResult.Results = transactionSelectResult.Results;
      }
      catch (Exception ex)
      {
        logicResult.Exception = ex;
      }
      return logicResult;
    }
  }
}
