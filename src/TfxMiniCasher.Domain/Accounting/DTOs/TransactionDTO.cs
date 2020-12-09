using System;
using Xyz.TForce.Archetypes.DomainDrivenDevelopment;

namespace Xyz.TForce.MiniCasher.Domain.Accounting.DTOs
{

  public class TransactionDTO
  {

    public Guid TransactionId { get; set; }

    public string TransactionCode { get; set; }

    public string TransactionName { get; set; }

    public Guid DebitAccountId { get; set; }

    public Guid CreditAccountId { get; set; }

    public decimal TransactionAmount { get; set; }

    public TimeUnit IssuedTime { get; set; }
  }
}
