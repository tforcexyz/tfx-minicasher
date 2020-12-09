using Xyz.TForce.Archetypes.DomainDrivenDevelopment;
using Xyz.TForce.MiniCasher.Domain.Accounting.Models;

namespace Xyz.TForce.MiniCasher.Application.Contracts.Accounting.Commands
{

  public class TransactionCreateCommand : BaseCommand<TransactionCreateResult>
  {

    public TransactionCreateCommand(TransactionCreateArgs args)
    {
      Args = args;
    }

    public TransactionCreateArgs Args { get; set; }
  }
}
