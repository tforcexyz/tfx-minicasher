using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace Xyz.TForce.MiniCasher.WebApi.Accounting.Controllers
{

  public class OptionController : Controller
  {

    private readonly IContainer _container;

    public OptionController(IContainer container)
    {
      _container = container;
    }
  }
}
