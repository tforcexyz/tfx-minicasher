using System;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Xyz.TForce.MiniCasher.Application.Contracts.Accounting.Commands;
using Xyz.TForce.MiniCasher.Domain.Accounting.Models;
using Xyz.TForce.MiniCasher.WebApi.Accounting.Models;
using Xyz.TForce.MiniCasher.WebApi.Accounting.Models.Views;

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
    [Route("")]
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

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<AccountDeleteResponse>> Delete(Guid id)
    {
      AccountDeleteArgs accountDeleteArgs = new AccountDeleteArgs
      {
        AccountId = id
      };
      IMediator mediator = Factory.Resolve<IMediator>();
      AccountDeleteResult accountDeleteResult = await mediator.Send(new AccountDeleteCommand(accountDeleteArgs));
      accountDeleteResult.EnsureSuccess();
      AccountDeleteResponse response = new AccountDeleteResponse
      {
        IsSuccess = true
      };
      return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<AccountGetResponse>> Get(Guid id)
    {
      AccountGetByIdArgs accountGetByIdArgs = new AccountGetByIdArgs
      {
        AccountId = id
      };
      IMediator mediator = Factory.Resolve<IMediator>();
      AccountGetByIdResult accountGetByIdResult = await mediator.Send(new AccountGetByIdCommand(accountGetByIdArgs));
      accountGetByIdResult.EnsureSuccess();
      if (accountGetByIdResult.Result == null)
      {
        return NoContent();
      }
      AccountGetResponse response = new AccountGetResponse
      {
        Account = new AccountView(accountGetByIdResult.Result)
      };
      return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<AccountModifyResponse>> Modify(Guid id, [FromBody] AccountModifyRequest request)
    {
      request.EnsureValidation();
      AccountModifyArgs accountModifyArgs = new AccountModifyArgs
      {
        AccountId = id,
        AccountCode = request.Code,
        AccountName = request.Name,
        AccountDescription = request.Description,
        ParentAccountId = request.ParentId,
        DebitOrCredit = request.DebitOrCredit,
        IsHidden = request.IsHidden
      };
      IMediator mediator = Factory.Resolve<IMediator>();
      AccountModifyResult accountModifyResult = await mediator.Send(new AccountModifyCommand(accountModifyArgs));
      accountModifyResult.EnsureSuccess();
      AccountModifyResponse response = new AccountModifyResponse
      {
        IsSuccess = true
      };
      return Ok(response);
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<AccountSearchResponse>> Search([FromQuery] AccountSearchRequest request)
    {
      request.EnsureValidation();
      AccountSearchArgs accountSearchArgs = new AccountSearchArgs();
      IMediator mediator = Factory.Resolve<IMediator>();
      AccountSearchResult accountCreateResult = await mediator.Send(new AccountSearchCommand(accountSearchArgs));
      accountCreateResult.EnsureSuccess();
      AccountSearchResponse response = new AccountSearchResponse
      {
        Accounts = accountCreateResult.Results
          .Select(x => { return new AccountLiteView(x); })
          .ToArray()
      };
      return Ok(response);
    }
  }
}
