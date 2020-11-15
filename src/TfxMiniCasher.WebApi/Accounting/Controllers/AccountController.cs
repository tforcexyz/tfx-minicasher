using System.Threading.Tasks;
using Autofac;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Xyz.TForce.MiniCasher.Application.Contracts.Accounting.Commands;
using Xyz.TForce.MiniCasher.Domain.Accounting.Models;
using Xyz.TForce.MiniCasher.WebApi.Accounting.Models;

namespace Xyz.TForce.MiniCasher.WebApi.Accounting.Controllers
{

  [Route("api/accounting/account")]
  public class AccountController : ApiController
  {

    public AccountController(IContainer container)
      : base(container)
    {
    }

    [HttpPost]
    public async Task<ActionResult<AccountCreateResponse>> Create([FromBody] AccountCreateRequest request)
    {
      request.EnsureValidation();
      AccountCreateArgs accountCreateArgs = new AccountCreateArgs
      {
        AccountCode = request.Code,
        AccountName = request.Name,
        AccountDescription = request.Description,
        ParentAccountId = request.ParentId,
        DebitOrCredit = request.DebitOrCredit,
        IsHidden = request.IsHidden
      };
      IMediator mediator = Factory.Resolve<IMediator>();
      AccountCreateResult accountCreateResult = await mediator.Send(new AccountCreateCommand(accountCreateArgs));
      accountCreateResult.EnsureSuccess();
      AccountCreateResponse response = new AccountCreateResponse
      {
        IsSuccess = true
      };
      return Ok(response);
    }
  }
}
