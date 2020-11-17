using Xyz.TForce.Archetypes.DomainDrivenDevelopment;
using Xyz.TForce.MiniCasher.Domain.Accounting.Models;

namespace Xyz.TForce.MiniCasher.Application.Contracts.Accounting.Commands
{

  public class AccountDeleteCommand : BaseCommand<AccountDeleteResult>
  {

    public AccountDeleteCommand(AccountDeleteArgs args)
    {
      Args = args;
    }

    public AccountDeleteArgs Args { get; set; }
  }
}
