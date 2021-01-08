using System.Threading.Tasks;
using Xyz.TForce.MiniCasher.Data.Contracts.Accounting.Models;

namespace Xyz.TForce.MiniCasher.Data.Contracts.Accounting
{

  public interface ITransactionRepository
  {

    Task<TransactionFindResult> FindAsync(TransactionFindArgs args);

    Task<TransactionInsertResult> InsertAsync(TransactionInsertArgs args);

    Task<TransactionRemoveResult> RemoveAsync(TransactionRemoveArgs args);

    Task<TransactionSelectResult> SelectAsync(TransactionSelectArgs args);

    Task<TransactionUpdateResult> UpdateAsync(TransactionUpdateArgs args);
  }
}
