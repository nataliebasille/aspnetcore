namespace Basille.AspNetCore.ProblemDetails;

using Microsoft.AspNetCore.Http;
using System;

public class ProblemDetailsOptions
{
	public Func<HttpContext, bool> IsProblem { get; set; } = context => context.Response.StatusCode >= 400 && context.Response.StatusCode < 600;
}
