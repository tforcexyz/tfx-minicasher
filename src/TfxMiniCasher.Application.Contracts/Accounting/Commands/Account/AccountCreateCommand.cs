using Xyz.TForce.Archetypes.DomainDrivenDevelopment;
using Xyz.TForce.MiniCasher.Domain.Accounting.Models;

namespace Xyz.TForce.MiniCasher.Application.Contracts.Accounting.Commands
{

  public class AccountCreateCommand : BaseCommand<AccountCreateResult>
  {

    public AccountCreateCommand(AccountCreateArgs args)
    {
      Args = args;
    }

    public AccountCreateArgs Args { get; set; }
  }
}
