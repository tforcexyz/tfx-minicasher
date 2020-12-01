using System;
using Xyz.TForce.MiniCasher.Domain.Accounting.DTOs;
using Xyz.TForce.MiniCasher.Domain.Accounting.Types;

namespace Xyz.TForce.MiniCasher.WebApi.Accounting.Models.Views
{

  public class AccountLiteView
  {

    public AccountLiteView(AccountDTO dto)
    {
      Id = dto.AccountId;
      Code = dto.AccountCode;
      Name = dto.AccountName;
      DebitOrCredit = dto.DebitOrCredit;
      ParentId = dto.ParentAccountId;
    }

    public Guid Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public DebitCredit DebitOrCredit { get; set; }

    public Guid? ParentId { get; set; }
  }
}
