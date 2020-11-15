using System;
using System.Linq;
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

  [AutoInject(ServiceTypes = new[] { typeof(IRequestHandler<AccountSearchCommand, AccountSearchResult>) }, LifetimeScope = LifetimeScope.Transient)]
  public class AccountSearchCommandHandler : ICommandHandler<AccountSearchCommand, AccountSearchResult>
  {

    private readonly IAccountRepository _accountRepository;

    public AccountSearchCommandHandler(IAccountRepository accountRepository)
    {
      _accountRepository = accountRepository;
    }

    public async Task<AccountSearchResult> Handle(AccountSearchCommand command, CancellationToken cancellationToken)
    {
      AccountSearchResult logicResult = new AccountSearchResult();
      try
      {
        AccountSelectArgs accountSelectArgs = new AccountSelectArgs();
        AccountSelectResult accountSelectResult = await _accountRepository.SelectAsync(accountSelectArgs)
          .ConfigureAwait(false);
        accountSelectResult.EnsureSuccess();
        logicResult.Results = accountSelectResult.Results;
      }
      catch (Exception ex)
      {
        logicResult.Exception = ex;
      }
      return logicResult;
    }
  }
}
