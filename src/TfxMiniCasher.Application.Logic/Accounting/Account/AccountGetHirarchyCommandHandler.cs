using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Xyz.TForce.Archetypes.DomainDrivenDevelopment;
using Xyz.TForce.DependencyInjection;
using Xyz.TForce.MiniCasher.Application.Contracts.Accounting.Commands;
using Xyz.TForce.MiniCasher.Data.Contracts.Accounting;
using Xyz.TForce.MiniCasher.Data.Contracts.Accounting.Models;
using Xyz.TForce.MiniCasher.Domain.Accounting.DTOs;
using Xyz.TForce.MiniCasher.Domain.Accounting.Models;

namespace Xyz.TForce.MiniCasher.Application.Logic.Accounting
{

  [AutoInject(ServiceTypes = new[] { typeof(IRequestHandler<AccountGetHierarchyCommand, AccountGetHierarchyResult>) }, LifetimeScope = LifetimeScope.Transient)]
  public class AccountGetHirarchyCommandHandler : ICommandHandler<AccountGetHierarchyCommand, AccountGetHierarchyResult>
  {

    private readonly IAccountRepository _accountRepository;

    public AccountGetHirarchyCommandHandler(IAccountRepository accountRepository)
    {
      _accountRepository = accountRepository;
    }

    public async Task<AccountGetHierarchyResult> Handle(AccountGetHierarchyCommand command, CancellationToken cancellationToken)
    {
      AccountGetHierarchyResult logicResult = new AccountGetHierarchyResult();
      try
      {
        AccountSelectArgs accountSelectArgs = new AccountSelectArgs();
        AccountSelectResult accountSelectResult = await _accountRepository.SelectAsync(accountSelectArgs)
          .ConfigureAwait(false);
        accountSelectResult.EnsureSuccess();
        IDictionary<Guid, AccountDTO> accountDictionary = new Dictionary<Guid, AccountDTO>
        {
          { Guid.Empty, new AccountDTO() }
        };
        IDictionary<Guid, ICollection<Guid>> accountChildDictionary = new Dictionary<Guid, ICollection<Guid>>();
        foreach (AccountDTO account in accountSelectResult.Results)
        {
          accountDictionary[account.AccountId] = account;
          Guid parentAccountId = account.ParentAccountId ?? Guid.Empty;
          {
            if (accountChildDictionary.ContainsKey(parentAccountId))
            {
              accountChildDictionary[parentAccountId].Add(account.AccountId);
            }
            else
            {
              accountChildDictionary[parentAccountId] = new List<Guid> { account.AccountId };
            }
          }
        }
        AccountDTO rootAccount = GetChildAccounts(Guid.Empty, accountDictionary, accountChildDictionary);
        logicResult.Results = rootAccount.ChildAccounts
          .ToArray();
      }
      catch (Exception ex)
      {
        logicResult.Exception = ex;
      }
      return logicResult;
    }

    private AccountDTO GetChildAccounts(Guid accountId, IDictionary<Guid, AccountDTO> accountDictionary, IDictionary<Guid, ICollection<Guid>> accountChildDictionary)
    {
      if (accountDictionary.ContainsKey(accountId))
      {
        AccountDTO account = accountDictionary[accountId];
        if (accountChildDictionary.ContainsKey(accountId))
        {
          AccountDTO[] childAccounts = accountChildDictionary[accountId]
            .Where(childAccountId => { return accountDictionary.ContainsKey(childAccountId); })
            .Select(childAccountId =>
            {
              return GetChildAccounts(childAccountId, accountDictionary, accountChildDictionary);
            })
            .ToArray();
          account.ChildAccounts = childAccounts;
        }
        return account;
      }
      return default(AccountDTO);
    }
  }
}
