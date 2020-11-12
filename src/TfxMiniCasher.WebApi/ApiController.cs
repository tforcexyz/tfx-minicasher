using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace Xyz.TForce.MiniCasher.WebApi
{

  public abstract class ApiController : Controller
  {

    protected ILifetimeScope Factory { get; private set; }

    protected ApiController(IContainer container)
    {
      Factory = container.BeginLifetimeScope();
    }

    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
      if (disposing)
      {
        Factory.Dispose();
      }
    }
  }
}
