using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace Xyz.TForce.MiniCasher.WebApi.Accounting.Controllers
{

  public class AccountController : Controller
  {

    private readonly IContainer _container;

    public AccountController(IContainer container)
    {
      _container = container;
    }
  }
}
