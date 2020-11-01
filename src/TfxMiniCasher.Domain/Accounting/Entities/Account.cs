using Xyz.TForce.Archetypes.DomainDrivenDevelopment;

namespace Xyz.TForce.MiniCasher.Domain.Accounting.Entities
{

  public class Account : BaseEntity, IAggregateRoot
  {

    public long AccountId { get; set; }

    public string AccountCode { get; set; }

    public string AccountName { get; set; }

    public string AccountDescription { get; set; }

    public string ParentAccountCode { get; set; }

    public bool IsHidden { get; set; }
  }
}
