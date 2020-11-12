using Xyz.TForce.DependencyInjection;
using Xyz.TForce.MiniCasher.Application.Contracts.Accounting;

namespace Xyz.TForce.MiniCasher.Application.Logic.Accounting
{

  [AutoInject(ServiceTypes = new[] { typeof(IReportAppService) }, LifetimeScope = LifetimeScope.Scoped)]
  public class ReportAppService : IReportAppService
  {
  }
}
