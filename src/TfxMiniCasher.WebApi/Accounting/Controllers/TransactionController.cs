using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace Xyz.TForce.MiniCasher.WebApi.Accounting.Controllers
{

  public class TransactionController : Controller
  {

    private readonly IContainer _container;

    public TransactionController(IContainer container)
    {
      _container = container;
    }
  }
}
