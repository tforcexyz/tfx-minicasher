using Xyz.TForce.Archetypes.DomainDrivenDevelopment;
using DomainDTOs = Xyz.TForce.MiniCasher.Domain.Accounting.DTOs;
using DomainEntities = Xyz.TForce.MiniCasher.Domain.Accounting.Entities;

namespace Xyz.TForce.MiniCasher.Data.Repositories.Accounting.Entities
{

  public static class TransactionConverter
  {

    public static DomainDTOs.TransactionDTO ToDTO(this Transaction entity)
    {
      DomainDTOs.TransactionDTO convertedEntity = new DomainDTOs.TransactionDTO
      {
        TransactionId = entity.TransactionId,
        TransactionCode = entity.TransactionCode,
        TransactionName = entity.TransactionName,
        DebitAccountId = entity.DebitAccountId,
        CreditAccountId = entity.CreditAccountId,
        TransactionAmount = entity.TransactionAmount,
        IssuedTime = TimeUnit.FromTimeCode(entity.IssuedTimeCode)
      };
      return convertedEntity;
    }

    public static Transaction ToEntity(this DomainEntities.Transaction entity)
    {
      Transaction convertedEntity = new Transaction
      {
        TransactionId = entity.TransactionId,
        TransactionCode = entity.TransactionCode,
        TransactionName = entity.TransactionName,
        DebitAccountId = entity.DebitAccountId,
        CreditAccountId = entity.CreditAccountId,
        TransactionAmount = entity.TransactionAmount,
        IssuedTimeCode = entity.IssuedTime.TimeCode
      };
      return convertedEntity;
    }
  }
}
