using Xyz.TForce.MiniCasher.Domain.Accounting.DTOs;

namespace Xyz.TForce.MiniCasher.WebApi.Accounting.Models.Views
{

  public class AccountView
  {

    public AccountView(AccountDTO dto)
    {
      Code = dto.AccountCode;
      Name = dto.AccountName;
    }

    public string Code { get; set; }

    public string Name { get; set; }
  }
}
