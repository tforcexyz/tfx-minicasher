using System;
using Xyz.TForce.Archetypes.DomainDrivenDevelopment;
using Xyz.TForce.MiniCasher.Domain.Accounting.Types;

namespace Xyz.TForce.MiniCasher.WebApi.Accounting.Models
{

  public class AccountModifyRequest : ValidatableParameters
  {

    public string Code { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public Guid? ParentId { get; set; }

    public DebitCredit DebitOrCredit { get; set; }

    public bool IsHidden { get; set; }

    public override bool Validate()
    {
      return true;
    }
  }
}
