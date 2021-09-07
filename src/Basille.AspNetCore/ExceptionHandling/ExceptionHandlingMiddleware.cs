namespace Basille.AspNetCore.ExceptionHandling;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Basille.AspNetCore.ProblemDetails;
using System;
using System.Text.Json;
using System.Diagnostics;
using System.Linq;

public record ExceptionHandlingMiddlewareOptions(ILoggerFactory LoggerFactory)
{
	public bool ShowTrace { get; init; } = false;
}

public static class ExceptionHandlingMiddleware
{
	public static IApplicationBuilder UseExceptionLogger(this IApplicationBuilder app, ExceptionHandlingMiddlewareOptions options)
	{
		return app.UseExceptionHandler(onError =>
		{
			onError.Run(async context =>
			{
				IErrorIdGenerator errorIdGenerator = app.ApplicationServices.GetService<IErrorIdGenerator>();

				if (errorIdGenerator == null)
					throw new InvalidOperationException($"To use exception logger, add a dependency for {typeof(IDetailIdGenerator)} or use AddExceptionLogger when registering your services");

				var logger = options.LoggerFactory.CreateLogger("Basille.AspNetCore.ExceptionHandling");

				var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
				if (contextFeature != null)
				{
					string referenceId = errorIdGenerator.NextID();
					logger.LogError(contextFeature.Error, $"Unhandled exception.  Reference ID: {referenceId}");

					UnhandledExceptionProblemDetail problem = new()
					{
						ReferenceID = referenceId,
						Instance = context.Request.Path
					};

					if (options.ShowTrace)
                    {
						problem = problem with
						{
							Message = contextFeature.Error.Message,
							Raw = contextFeature.Error.ToString(),
							StackFrames = new StackTrace(contextFeature.Error, true).GetFrames().Select(x => new UnhandledExceptionProblemDetail.StackFrame
							{
								Filename = x.GetFileName(),
								LineNumber = x.GetFileLineNumber(),
								Method = x.GetMethod().Name
							})
							.ToArray(),
						};
                    }

					await context.Response.WriteAsync(JsonSerializer.Serialize(problem, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					}));
				}
			});
		});
	}
}
