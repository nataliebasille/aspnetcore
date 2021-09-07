using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Basille.AspNetCore.RequestHandling;

[ApiController]
public abstract class RequestHandler
    : ControllerBase, IRequestHandler
{
    public abstract Task<ActionResult> HandleAsync();
}

[ApiController]
public abstract class RequestHandler<TRequest>
    : ControllerBase, IRequestHandler<TRequest>
{
    public abstract Task<ActionResult> HandleAsync(TRequest request);
}

[ApiController]
public abstract class RequestHandler<TRequest, TResponse>
    : ControllerBase, IRequestHandler<TRequest, TResponse>
{
    public abstract Task<ActionResult<TResponse>> HandleAsync(TRequest request);
}
