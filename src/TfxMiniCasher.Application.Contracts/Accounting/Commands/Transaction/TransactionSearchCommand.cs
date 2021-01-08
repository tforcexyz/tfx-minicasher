using Xyz.TForce.Archetypes.DomainDrivenDevelopment;
using Xyz.TForce.MiniCasher.Domain.Accounting.Models;

namespace Xyz.TForce.MiniCasher.Application.Contracts.Accounting.Commands
{

  public class TransactionSearchCommand : BaseCommand<TransactionSearchResult>
  {

    public TransactionSearchCommand(TransactionSearchArgs args)
    {
      Args = args;
    }

    public TransactionSearchArgs Args { get; set; }
  }
}
