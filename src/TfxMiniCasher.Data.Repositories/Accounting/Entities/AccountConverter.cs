using Xyz.TForce.MiniCasher.Data.Repositories.Accounting.Types;
using DomainEntities = Xyz.TForce.MiniCasher.Domain.Accounting.Entities;

namespace Xyz.TForce.MiniCasher.Data.Repositories.Accounting.Entities
{

  public static class AccountConverter
  {

    public static Account ToEntity(this DomainEntities.Account entity)
    {
      Account convertedEntity = new Account
      {
        AccountId = entity.AccountId,
        AccountCode = entity.AccountCode,
        AccountName = entity.AccountName,
        AccountDescription = entity.AccountDescription,
        ParentAccountId = entity.ParentAccountId,
        DebitOrCredit = entity.DebitOrCredit.ToType(),
        IsHidden = entity.IsHidden,
      };
      return convertedEntity;
    }
  }
}
