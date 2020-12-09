using Xyz.TForce.Archetypes.DomainDrivenDevelopment;
using Xyz.TForce.MiniCasher.Domain.Accounting.Models;

namespace Xyz.TForce.MiniCasher.Application.Contracts.Accounting.Commands
{

  public class TransactionGetByIdCommand : BaseCommand<TransactionGetByIdResult>
  {

    public TransactionGetByIdCommand(TransactionGetByIdArgs args)
    {
      Args = args;
    }

    public TransactionGetByIdArgs Args { get; set; }
  }
}
