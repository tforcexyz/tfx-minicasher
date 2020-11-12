using Autofac;

namespace Xyz.TForce.MiniCasher.WebApi.Accounting.Controllers
{

  public class AccountController : ApiController
  {

    public AccountController(IContainer container)
      : base(container)
    {
    }
  }
}
