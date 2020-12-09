using Xyz.TForce.Archetypes.DomainDrivenDevelopment;
using Xyz.TForce.MiniCasher.Domain.Accounting.Models;

namespace Xyz.TForce.MiniCasher.Application.Contracts.Accounting.Commands
{

  public class TransactionDeleteCommand : BaseCommand<TransactionDeleteResult>
  {

    public TransactionDeleteCommand(TransactionDeleteArgs args)
    {
      Args = args;
    }

    public TransactionDeleteArgs Args { get; set; }
  }
}
