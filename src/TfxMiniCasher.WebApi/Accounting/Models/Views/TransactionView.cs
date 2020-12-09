using System;
using Xyz.TForce.MiniCasher.Domain.Accounting.DTOs;

namespace Xyz.TForce.MiniCasher.WebApi.Accounting.Models.Views
{

  public class TransactionView
  {

    public TransactionView(TransactionDTO dto)
    {
      Id = dto.TransactionId;
      Code = dto.TransactionCode;
      Name = dto.TransactionName;
      DebitAccount = new AccountLiteView
      {
        Id = dto.DebitAccountId
      };
      CreditAccount = new AccountLiteView
      {
        Id = dto.CreditAccountId
      };
      Amount = dto.TransactionAmount;
      IssuedTime = dto.IssuedTime.Time;
    }

    public Guid Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public AccountLiteView DebitAccount { get; set; }

    public AccountLiteView CreditAccount { get; set; }

    public decimal Amount { get; set; }

    public DateTime IssuedTime { get; set; }
  }
}
