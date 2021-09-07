namespace Microsoft.Extensions.DependencyInjection;

using Basille.AspNetCore.ExceptionHandling;
using Microsoft.Extensions.DependencyInjection.Extensions;

public static class ExceptionLoggingServiceProviders
{
	public static IServiceCollection AddExceptionLogging(this IServiceCollection services)
	{
		services.TryAddTransient<IErrorIdGenerator, DefaultErrorIdGenerator>();
		return services;
	}
}
