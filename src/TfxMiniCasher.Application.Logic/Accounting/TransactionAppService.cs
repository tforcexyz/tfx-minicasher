using Xyz.TForce.DependencyInjection;
using Xyz.TForce.MiniCasher.Application.Contracts.Accounting;

namespace Xyz.TForce.MiniCasher.Application.Logic.Accounting
{

  [AutoInject(ServiceTypes = new[] { typeof(ITransactionAppService) }, LifetimeScope = LifetimeScope.Scoped)]
  public class TransactionAppService : ITransactionAppService
  {
  }
}
