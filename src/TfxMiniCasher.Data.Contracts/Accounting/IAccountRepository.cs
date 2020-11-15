using System.Threading.Tasks;
using Xyz.TForce.MiniCasher.Data.Contracts.Accounting.Models;

namespace Xyz.TForce.MiniCasher.Data.Contracts.Accounting
{

  public interface IAccountRepository
  {

    Task<AccountInsertResult> InsertAsync(AccountInsertArgs args);

    Task<AccountSelectResult> SelectAsync(AccountSelectArgs args);
  }
}
