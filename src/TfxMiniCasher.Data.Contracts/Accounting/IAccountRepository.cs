using System.Threading.Tasks;
using Xyz.TForce.MiniCasher.Data.Contracts.Accounting.Models;

namespace Xyz.TForce.MiniCasher.Data.Contracts.Accounting
{

  public interface IAccountRepository
  {

    Task<AccountFindResult> FindAsync(AccountFindArgs args);

    Task<AccountInsertResult> InsertAsync(AccountInsertArgs args);

    Task<AccountSelectResult> SelectAsync(AccountSelectArgs args);

    Task<AccountUpdateResult> UpdateAsync(AccountUpdateArgs args);
  }
}
