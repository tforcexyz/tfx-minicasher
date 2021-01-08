using System;
using Xyz.TForce.MiniCasher.Domain.Accounting.DTOs;
using Xyz.TForce.MiniCasher.Domain.Accounting.Types;

namespace Xyz.TForce.MiniCasher.WebApi.Accounting.Models.Views
{

  public class AccountView
  {

    public AccountView(AccountDTO dto)
    {
      Id = dto.AccountId;
      Code = dto.AccountCode;
      Name = dto.AccountName;
      Description = dto.AccountDescription;
      ParentId = dto.ParentAccountId;
      DebitOrCredit = dto.DebitOrCredit;
      IsHidden = dto.IsHidden;
    }

    public Guid Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public Guid? ParentId { get; set; }

    public DebitCredit DebitOrCredit { get; set; }

    public bool IsHidden { get; set; }
  }
}
