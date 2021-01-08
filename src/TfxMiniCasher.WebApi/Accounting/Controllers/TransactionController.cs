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

  [Route("api/accounting/transaction")]
  public class TransactionController : ApiController
  {

    public TransactionController(IContainer container)
      : base(container)
    {
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<TransactionCreateResponse>> Create([FromBody] TransactionCreateRequest request)
    {
      request.EnsureValidation();
      TransactionCreateArgs transactionCreateArgs = new TransactionCreateArgs
      {
        TransactionName = request.Name,
        DebitAccountId = request.DebitAccountId,
        CreditAccountId = request.CreditAccountId,
        TransactionAmount = request.Amount,
        IssuedTime = request.IssuedTime
      };
      IMediator mediator = Factory.Resolve<IMediator>();
      TransactionCreateResult transactionCreateResult = await mediator.Send(new TransactionCreateCommand(transactionCreateArgs));
      transactionCreateResult.EnsureSuccess();
      TransactionCreateResponse response = new TransactionCreateResponse
      {
        IsSuccess = true
      };
      return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<TransactionDeleteResponse>> Delete(Guid id)
    {
      TransactionDeleteArgs transactionDeleteArgs = new TransactionDeleteArgs
      {
        TransactionId = id
      };
      IMediator mediator = Factory.Resolve<IMediator>();
      TransactionDeleteResult transactionDeleteResult = await mediator.Send(new TransactionDeleteCommand(transactionDeleteArgs));
      transactionDeleteResult.EnsureSuccess();
      TransactionDeleteResponse response = new TransactionDeleteResponse
      {
        IsSuccess = true
      };
      return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<TransactionGetResponse>> Get(Guid id)
    {
      TransactionGetByIdArgs transactionGetByIdArgs = new TransactionGetByIdArgs
      {
        TransactionId = id
      };
      IMediator mediator = Factory.Resolve<IMediator>();
      TransactionGetByIdResult transactionGetByIdResult = await mediator.Send(new TransactionGetByIdCommand(transactionGetByIdArgs));
      transactionGetByIdResult.EnsureSuccess();
      if (transactionGetByIdResult.Result == null)
      {
        return NoContent();
      }
      TransactionGetResponse response = new TransactionGetResponse
      {
        Transaction = new TransactionView(transactionGetByIdResult.Result)
      };
      return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<TransactionModifyResponse>> Modify(Guid id, [FromBody] TransactionModifyRequest request)
    {
      request.EnsureValidation();
      TransactionModifyArgs transactionModifyArgs = new TransactionModifyArgs
      {
        TransactionId = id,
        TransactionName = request.Name,
        DebitAccountId = request.DebitAccountId,
        CreditAccountId = request.CreditAccountId,
        TransactionAmount = request.Amount,
        IssuedTime = request.IssuedTime
      };
      IMediator mediator = Factory.Resolve<IMediator>();
      TransactionModifyResult transactionModifyResult = await mediator.Send(new TransactionModifyCommand(transactionModifyArgs));
      transactionModifyResult.EnsureSuccess();
      TransactionModifyResponse response = new TransactionModifyResponse
      {
        IsSuccess = true
      };
      return Ok(response);
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<TransactionSearchResponse>> Search([FromQuery] TransactionSearchRequest request)
    {
      request.EnsureValidation();
      TransactionSearchArgs transactionSearchArgs = new TransactionSearchArgs();
      IMediator mediator = Factory.Resolve<IMediator>();
      TransactionSearchResult transactionSearchResult = await mediator.Send(new TransactionSearchCommand(transactionSearchArgs));
      transactionSearchResult.EnsureSuccess();
      TransactionSearchResponse response = new TransactionSearchResponse
      {
        Transactions = transactionSearchResult.Results
          .Select(x => { return new TransactionLiteView(x); })
          .ToArray()
      };
      return Ok(response);
    }
  }
}
