using Xyz.TForce.Archetypes.DomainDrivenDevelopment;

namespace Xyz.TForce.MiniCasher.WebApi.Accounting.Models
{

  public class TransactionSearchRequest : ValidatableParameters
  {

    public override bool Validate()
    {
      return true;
    }
  }
}
