using System;
using Xyz.TForce.MiniCasher.Domain.Accounting.Types;

namespace Xyz.TForce.MiniCasher.Domain.Accounting.DTOs
{

  public class AccountDTO
  {

    public Guid AccountId { get; set; }

    public string AccountCode { get; set; }

    public string AccountName { get; set; }

    public string AccountDescription { get; set; }

    public Guid? ParentAccountId { get; set; }

    public DebitCredit DebitOrCredit { get; set; }

    public bool IsHidden { get; set; }
  }
}
