namespace Microsoft.Extensions.DependencyInjection;

using Basille.AspNetCore.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection.Extensions;

public static class ProblemDetailExtensions
{
	public static IServiceCollection AddProblemDetails(this IServiceCollection services)
	{
		services.TryAddTransient<IProblemDetailFactory, ProblemDetailFactory>();
		services.TryAddTransient<IDetailIdGenerator, DefaultDetailIdGenerator>();
		services.AddSingleton(new ProblemDetailsOptions());

		return services;
	}

	public static IApplicationBuilder UseProblemDetails(this IApplicationBuilder app)
		=> app.UseMiddleware<ProblemDetailsMiddleware>();
}