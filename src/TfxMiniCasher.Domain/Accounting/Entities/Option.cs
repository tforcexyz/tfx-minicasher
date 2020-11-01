using Xyz.TForce.Archetypes.DomainDrivenDevelopment;

namespace Xyz.TForce.MiniCasher.Domain.Accounting.Entities
{

  public class Option : BaseEntity, IAggregateRoot
  {

    public long OptionId { get; set; }

    public string OptionCode { get; set; }

    public string OptionName { get; set; }

    public string OptionDescription { get; set; }

    public string OptionGroup { get; set; }

    public string LanguageCode { get; set; }
  }
}
