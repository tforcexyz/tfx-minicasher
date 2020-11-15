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

  [AutoInject(ServiceTypes = new[] { typeof(IRequestHandler<AccountModifyCommand, AccountModifyResult>) }, LifetimeScope = LifetimeScope.Transient)]
  public class AccountModifyCommandHandler : ICommandHandler<AccountModifyCommand, AccountModifyResult>
  {

    private readonly IAccountRepository _accountRepository;

    public AccountModifyCommandHandler(IAccountRepository accountRepository)
    {
      _accountRepository = accountRepository;
    }

    public async Task<AccountModifyResult> Handle(AccountModifyCommand command, CancellationToken cancellationToken)
    {
      AccountModifyResult logicResult = new AccountModifyResult();
      try
      {
        Account account = Account.Modify(command.Args);
        AccountUpdateArgs accountUpdateArgs = new AccountUpdateArgs
        {
          Account = account
        };
        AccountUpdateResult accountUpdateResult = await _accountRepository.UpdateAsync(accountUpdateArgs)
          .ConfigureAwait(false);
        accountUpdateResult.EnsureSuccess();
        logicResult.Result = accountUpdateResult.Result;
      }
      catch (Exception ex)
      {
        logicResult.Exception = ex;
      }
      return logicResult;
    }
  }
}
