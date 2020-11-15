using Xyz.TForce.Archetypes.DomainDrivenDevelopment;
using Xyz.TForce.MiniCasher.Domain.Accounting.Models;

namespace Xyz.TForce.MiniCasher.Application.Contracts.Accounting.Commands
{

  public class AccountSearchCommand : BaseCommand<AccountSearchResult>
  {

    public AccountSearchCommand(AccountSearchArgs args)
    {
      Args = args;
    }

    public AccountSearchArgs Args { get; set; }
  }
}
