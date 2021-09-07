namespace Basille.AspNetCore.RequestHandling;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public interface IRequestHandler
{
	Task<ActionResult> HandleAsync();
}

public interface IRequestHandler<in TRequest>
{
	Task<ActionResult> HandleAsync(TRequest request);
}

public interface IRequestHandler<in TRequest, TResult>
{
	Task<ActionResult<TResult>> HandleAsync(TRequest request);
}