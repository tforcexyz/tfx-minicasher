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

  [AutoInject(ServiceTypes = new[] { typeof(IRequestHandler<AccountCreateCommand, AccountCreateResult>) }, LifetimeScope = LifetimeScope.Transient)]
  public class AccountCreateCommandHandler : ICommandHandler<AccountCreateCommand, AccountCreateResult>
  {

    private readonly IAccountRepository _accountRepository;

    public AccountCreateCommandHandler(IAccountRepository accountRepository)
    {
      _accountRepository = accountRepository;
    }

    public async Task<AccountCreateResult> Handle(AccountCreateCommand command, CancellationToken cancellationToken)
    {
      AccountCreateResult logicResult = new AccountCreateResult();
      try
      {
        Account account = Account.Create(command.Args);
        AccountInsertArgs accountInsertArgs = new AccountInsertArgs
        {
          Account = account
        };
        AccountInsertResult accountInsertResult = await _accountRepository.InsertAsync(accountInsertArgs)
          .ConfigureAwait(false);
        accountInsertResult.EnsureSuccess();
        logicResult.Result = accountInsertResult.Result;
      }
      catch (Exception ex)
      {
        logicResult.Exception = ex;
      }
      return logicResult;
    }
  }
}
