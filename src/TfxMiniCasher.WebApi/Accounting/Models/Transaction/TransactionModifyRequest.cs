using System;
using Xyz.TForce.Archetypes.DomainDrivenDevelopment;

namespace Xyz.TForce.MiniCasher.WebApi.Accounting.Models
{

  public class TransactionModifyRequest : ValidatableParameters
  {

    public string Name { get; set; }

    public Guid DebitAccountId { get; set; }

    public Guid CreditAccountId { get; set; }

    public decimal Amount { get; set; }

    public DateTime IssuedTime { get; set; }

    public override bool Validate()
    {
      return true;
    }
  }
}
