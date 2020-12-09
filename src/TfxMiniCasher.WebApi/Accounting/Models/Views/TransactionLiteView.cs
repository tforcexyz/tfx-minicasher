using System;
using Xyz.TForce.MiniCasher.Domain.Accounting.DTOs;

namespace Xyz.TForce.MiniCasher.WebApi.Accounting.Models.Views
{

  public class TransactionLiteView
  {

    public TransactionLiteView(TransactionDTO dto)
    {
      Id = dto.TransactionId;
      Code = dto.TransactionCode;
      Name = dto.TransactionName;
      DebitAccountId = dto.DebitAccountId;
      CreditAccountId = dto.CreditAccountId;
      Amount = dto.TransactionAmount;
      IssuedTime = dto.IssuedTime.Time;
    }

    public Guid Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public Guid DebitAccountId { get; set; }

    public Guid CreditAccountId { get; set; }

    public decimal Amount { get; set; }

    public DateTime IssuedTime { get; set; }
  }
}
