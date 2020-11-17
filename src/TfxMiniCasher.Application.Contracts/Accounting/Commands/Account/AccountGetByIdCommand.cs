using Xyz.TForce.Archetypes.DomainDrivenDevelopment;
using Xyz.TForce.MiniCasher.Domain.Accounting.Models;

namespace Xyz.TForce.MiniCasher.Application.Contracts.Accounting.Commands
{

  public class AccountGetByIdCommand : BaseCommand<AccountGetByIdResult>
  {

    public AccountGetByIdCommand(AccountGetByIdArgs args)
    {
      Args = args;
    }

    public AccountGetByIdArgs Args { get; set; }
  }
}
