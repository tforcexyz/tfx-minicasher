using Xyz.TForce.Archetypes.DomainDrivenDevelopment;

namespace Xyz.TForce.MiniCasher.WebApi.Accounting.Models
{

  public class AccountGetRequest : ValidatableParameters
  {

    public override bool Validate()
    {
      return true;
    }
  }
}
