using System;
using Xyz.TForce.Data;

namespace Xyz.TForce.MiniCasher.Data.Repositories.Accounting.Entities
{

  public class Option : BaseEntity, IEntityMetadata, IEntityConcurrency
  {

    public Guid OptionId { get; set; }

    public string OptionCode { get; set; }

    public string OptionName { get; set; }

    public string OptionDescription { get; set; }

    public string OptionGroup { get; set; }

    public string LanguageCode { get; set; }

    public long MetaCreatedTimeCode { get; set; }

    public long MetaModifiedTimeCode { get; set; }

    public bool MetaIsDeleted { get; set; }

    public byte[] MetaRowVersion { get; set; }
  }
}
