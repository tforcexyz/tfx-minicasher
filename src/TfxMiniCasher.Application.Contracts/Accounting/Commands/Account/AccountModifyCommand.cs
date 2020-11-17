using Xyz.TForce.Archetypes.DomainDrivenDevelopment;
using Xyz.TForce.MiniCasher.Domain.Accounting.Models;

namespace Xyz.TForce.MiniCasher.Application.Contracts.Accounting.Commands
{

  public class AccountModifyCommand : BaseCommand<AccountModifyResult>
  {

    public AccountModifyCommand(AccountModifyArgs args)
    {
      Args = args;
    }

    public AccountModifyArgs Args { get; set; }
  }
}
