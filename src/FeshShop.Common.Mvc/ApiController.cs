using FeshShop.Common.Mediator.Contracts.Command;

namespace FeshShop.Common.Mvc;

using Mediator.Contracts.Query;
using Mediator.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public abstract class ApiController(IMediator mediator) : ControllerBase
{
    public const string PathSeparator = "/";
    public const string Id = "{id}";

    protected async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        => await mediator.QueryAsync(query);

    protected async Task<IActionResult> SendAsync<TModel>(TModel model) where TModel : ICommand
    {
        await mediator.SendAsync(model);

        return Accepted();
    }

    protected ActionResult<T> Single<T>(T data)
    {           
        if (data is null) 
            return NotFound();

        return Ok(data);
    }
}