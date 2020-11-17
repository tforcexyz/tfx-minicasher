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

  [AutoInject(ServiceTypes = new[] { typeof(IRequestHandler<AccountGetByIdCommand, AccountGetByIdResult>) }, LifetimeScope = LifetimeScope.Transient)]
  public class AccountGetByIdCommandHandler : ICommandHandler<AccountGetByIdCommand, AccountGetByIdResult>
  {

    private readonly IAccountRepository _accountRepository;

    public AccountGetByIdCommandHandler(IAccountRepository accountRepository)
    {
      _accountRepository = accountRepository;
    }

    public async Task<AccountGetByIdResult> Handle(AccountGetByIdCommand command, CancellationToken cancellationToken)
    {
      AccountGetByIdResult logicResult = new AccountGetByIdResult();
      try
      {
        AccountFindArgs accountFindArgs = new AccountFindArgs
        {
          AccountId = command.Args.AccountId
        };
        AccountFindResult accountFindResult = await _accountRepository.FindAsync(accountFindArgs)
          .ConfigureAwait(false);
        accountFindResult.EnsureSuccess();
        logicResult.Result = accountFindResult.Result;
      }
      catch (Exception ex)
      {
        logicResult.Exception = ex;
      }
      return logicResult;
    }
  }
}
