using Autofac;

namespace Xyz.TForce.MiniCasher.WebApi.Accounting.Controllers
{

  public class OptionController : ApiController
  {

    public OptionController(IContainer container)
      : base(container)
    {
    }
  }
}
