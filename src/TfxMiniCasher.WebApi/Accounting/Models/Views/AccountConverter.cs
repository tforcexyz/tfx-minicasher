using System.Linq;
using Xyz.TForce.MiniCasher.Domain.Accounting.DTOs;

namespace Xyz.TForce.MiniCasher.WebApi.Accounting.Models.Views
{

  internal static class AccountConverter
  {

    public static AccountHierarchyView ToAccountHierarchy(this AccountDTO dto)
    {
      AccountHierarchyView accountHierarchy = new AccountHierarchyView
      {
        Code = dto.AccountCode,
        Id = dto.AccountId,
        Name = dto.AccountName,
      };
      if (dto.ChildAccounts != null)
      {
        accountHierarchy.Children = dto.ChildAccounts
          .Select(ToAccountHierarchy)
          .ToArray();
      }
      return accountHierarchy;
    }
  }
}
