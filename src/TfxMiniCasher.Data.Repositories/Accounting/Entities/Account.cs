using System;
using Xyz.TForce.Data;
using Xyz.TForce.MiniCasher.Data.Repositories.Accounting.Types;

namespace Xyz.TForce.MiniCasher.Data.Repositories.Accounting.Entities
{

  public class Account : BaseEntity, IEntityMetadata, IEntityConcurrency
  {

    public Guid AccountId { get; set; }

    public string AccountCode { get; set; }

    public string AccountName { get; set; }

    public string AccountDescription { get; set; }

    public Guid ParentAccountId { get; set; }

    public DebitCredit DebitOrCredit { get; set; }

    public bool IsHidden { get; set; }

    public long MetaCreatedTimeCode { get; set; }

    public long MetaModifiedTimeCode { get; set; }

    public bool MetaIsDeleted { get; set; }

    public byte[] MetaRowVersion { get; set; }
  }
}
