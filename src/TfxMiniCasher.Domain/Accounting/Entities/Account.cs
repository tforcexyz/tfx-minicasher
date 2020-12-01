using System;
using Xyz.TForce.Archetypes.DomainDrivenDevelopment;
using Xyz.TForce.MiniCasher.Domain.Accounting.DTOs;
using Xyz.TForce.MiniCasher.Domain.Accounting.Models;
using Xyz.TForce.MiniCasher.Domain.Accounting.Types;

namespace Xyz.TForce.MiniCasher.Domain.Accounting.Entities
{

  public class Account : BaseEntity, IAggregateRoot
  {

    internal Account()
    {
    }

    public Guid AccountId { get; private set; }

    public string AccountCode { get; set; }

    public string AccountName { get; set; }

    public string AccountDescription { get; set; }

    public Guid? ParentAccountId { get; set; }

    public DebitCredit DebitOrCredit { get; set; }

    public bool IsHidden { get; set; }

    public static Account Create(AccountCreateArgs args)
    {
      Account account = new Account
      {
        AccountId = Guid.NewGuid(),
        AccountCode = args.AccountCode,
        AccountName = args.AccountName,
        AccountDescription = args.AccountDescription,
        ParentAccountId = args.ParentAccountId,
        DebitOrCredit = args.DebitOrCredit,
        IsHidden = args.IsHidden
      };
      return account;
    }

    public static Guid Delete(AccountDeleteArgs args)
    {
      return args.AccountId;
    }

    public static Account Load(AccountDTO dto)
    {
      Account account = new Account
      {
        AccountId = dto.AccountId,
        AccountCode = dto.AccountCode,
        AccountName = dto.AccountName,
        AccountDescription = dto.AccountDescription,
        ParentAccountId = dto.ParentAccountId,
        DebitOrCredit = dto.DebitOrCredit,
        IsHidden = dto.IsHidden
      };
      return account;
    }

    public void Modify(AccountModifyArgs args)
    {
      AccountCode = args.AccountCode;
      AccountName = args.AccountName;
      AccountDescription = args.AccountDescription;
      ParentAccountId = args.ParentAccountId;
      DebitOrCredit = args.DebitOrCredit;
      IsHidden = args.IsHidden;
    }
  }
}
