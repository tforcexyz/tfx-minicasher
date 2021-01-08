using System.Collections.Generic;
using Xyz.TForce.Archetypes.DomainDrivenDevelopment;

namespace Xyz.TForce.MiniCasher.Domain
{

  public class BaseEntity
  {

    public BaseEntity()
    {
      DomainEvents = new List<IDomainEvent>();
    }

    public ICollection<IDomainEvent> DomainEvents { get; private set; }
  }
}
