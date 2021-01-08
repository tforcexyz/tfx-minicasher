using Xyz.TForce.Archetypes.DomainDrivenDevelopment;
using Xyz.TForce.MiniCasher.Domain.Accounting.Models;

namespace Xyz.TForce.MiniCasher.Application.Contracts.Accounting.Commands
{

  public class TransactionModifyCommand : BaseCommand<TransactionModifyResult>
  {

    public TransactionModifyCommand(TransactionModifyArgs args)
    {
      Args = args;
    }

    public TransactionModifyArgs Args { get; set; }
  }
}
