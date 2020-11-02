using System;
using Xyz.TForce.Data;

namespace Xyz.TForce.MiniCasher.Data.Repositories.Accounting.Entities
{

  public class Transaction : BaseEntity, IEntityMetadata, IEntityConcurrency
  {

    public Guid TransactionId { get; set; }

    public string TransactionCode { get; set; }

    public string TransactionName { get; set; }

    public Guid DebitAccountId { get; set; }

    public Guid CreditAccountId { get; set; }

    public decimal TransactionAmount { get; set; }

    public virtual Account DebitAccount { get; set; }

    public virtual Account CreditAccount { get; set; }

    public long IssuedTimeCode { get; set; }

    public long MetaCreatedTimeCode { get; set; }

    public long MetaModifiedTimeCode { get; set; }

    public bool MetaIsDeleted { get; set; }

    public byte[] MetaRowVersion { get; set; }
  }
}
