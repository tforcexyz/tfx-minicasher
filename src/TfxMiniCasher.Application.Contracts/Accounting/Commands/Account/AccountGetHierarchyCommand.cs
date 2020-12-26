using Xyz.TForce.Archetypes.DomainDrivenDevelopment;
using Xyz.TForce.MiniCasher.Domain.Accounting.Models;

namespace Xyz.TForce.MiniCasher.Application.Contracts.Accounting.Commands
{

  public class AccountGetHierarchyCommand : BaseCommand<AccountGetHierarchyResult>
  {

    public AccountGetHierarchyCommand(AccountGetHierarchyArgs args)
    {
      Args = args;
    }

    public AccountGetHierarchyArgs Args { get; set; }
  }
}
