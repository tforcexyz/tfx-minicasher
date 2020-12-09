using System;

namespace Xyz.TForce.MiniCasher.Domain.Accounting.Models
{

  public class TransactionCreateArgs
  {

    public string TransactionName { get; set; }

    public Guid DebitAccountId { get; set; }

    public Guid CreditAccountId { get; set; }

    public decimal TransactionAmount { get; set; }

    public DateTime IssuedTime { get; set; }
  }
}
