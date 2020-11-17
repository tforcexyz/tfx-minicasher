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
using Xyz.TForce.MiniCasher.Domain.Accounting.Entities;
using Xyz.TForce.MiniCasher.Domain.Accounting.Models;

namespace Xyz.TForce.MiniCasher.Application.Logic.Accounting
{

  [AutoInject(ServiceTypes = new[] { typeof(IRequestHandler<AccountDeleteCommand, AccountDeleteResult>) }, LifetimeScope = LifetimeScope.Transient)]
  public class AccountDeleteCommandHandler : ICommandHandler<AccountDeleteCommand, AccountDeleteResult>
  {

    private readonly IAccountRepository _accountRepository;

    public AccountDeleteCommandHandler(IAccountRepository accountRepository)
    {
      _accountRepository = accountRepository;
    }

    public async Task<AccountDeleteResult> Handle(AccountDeleteCommand command, CancellationToken cancellationToken)
    {
      AccountDeleteResult logicResult = new AccountDeleteResult();
      try
      {
        Guid accountId = Account.Delete(command.Args);
        AccountRemoveArgs accountRemoveArgs = new AccountRemoveArgs
        {
          AccountId = accountId
        };
        AccountRemoveResult accountRemoveResult = await _accountRepository.RemoveAsync(accountRemoveArgs)
          .ConfigureAwait(false);
        accountRemoveResult.EnsureSuccess();
        logicResult.Result = accountRemoveResult.Result;
      }
      catch (Exception ex)
      {
        logicResult.Exception = ex;
      }
      return logicResult;
    }
  }
}
