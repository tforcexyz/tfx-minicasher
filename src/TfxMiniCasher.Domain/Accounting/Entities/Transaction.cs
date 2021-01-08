using System;
using Xyz.TForce.Archetypes.DomainDrivenDevelopment;
using Xyz.TForce.Cryptography;
using Xyz.TForce.MiniCasher.Domain.Accounting.DTOs;
using Xyz.TForce.MiniCasher.Domain.Accounting.Models;

namespace Xyz.TForce.MiniCasher.Domain.Accounting.Entities
{

  public class Transaction
  {

    public Guid TransactionId { get; set; }

    public string TransactionCode { get; set; }

    public string TransactionName { get; set; }

    public Guid DebitAccountId { get; set; }

    public Guid CreditAccountId { get; set; }

    public decimal TransactionAmount { get; set; }

    public TimeUnit IssuedTime { get; set; }

    public static Transaction Create(TransactionCreateArgs args)
    {
      Transaction transaction = new Transaction
      {
        TransactionId = Guid.NewGuid(),
        TransactionCode = RandomExpress.RandomizeString(16),
        TransactionName = args.TransactionName,
        DebitAccountId = args.DebitAccountId,
        CreditAccountId = args.CreditAccountId,
        TransactionAmount = args.TransactionAmount,
        IssuedTime = TimeUnit.FromDate(args.IssuedTime)
      };
      return transaction;
    }

    public static Guid Delete(TransactionDeleteArgs args)
    {
      return args.TransactionId;
    }

    public static Transaction Load(TransactionDTO dto)
    {
      Transaction transaction = new Transaction
      {
        TransactionId = dto.TransactionId,
        TransactionCode = dto.TransactionCode,
        TransactionName = dto.TransactionName,
        DebitAccountId = dto.DebitAccountId,
        CreditAccountId = dto.CreditAccountId,
        TransactionAmount = dto.TransactionAmount,
        IssuedTime = dto.IssuedTime
      };
      return transaction;
    }

    public void Modify(TransactionModifyArgs args)
    {
      TransactionName = args.TransactionName;
      DebitAccountId = args.DebitAccountId;
      CreditAccountId = args.CreditAccountId;
      TransactionAmount = args.TransactionAmount;
      IssuedTime = TimeUnit.FromDate(args.IssuedTime);
    }
  }
}
