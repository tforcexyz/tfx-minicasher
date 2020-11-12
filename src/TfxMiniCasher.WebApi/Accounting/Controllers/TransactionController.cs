using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace Xyz.TForce.MiniCasher.WebApi.Accounting.Controllers
{

  public class TransactionController : ApiController
  {

    public TransactionController(IContainer container)
      : base(container)
    {
    }
  }
}
