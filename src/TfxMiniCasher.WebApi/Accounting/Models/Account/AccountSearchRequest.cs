using Xyz.TForce.Archetypes.DomainDrivenDevelopment;

namespace Xyz.TForce.MiniCasher.WebApi.Accounting.Models
{

  public class AccountSearchRequest : ValidatableParameters
  {

    public override bool Validate()
    {
      return true;
    }
  }
}
