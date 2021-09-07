namespace Microsoft.Extensions.DependencyInjection;

using Basille.AspNetCore.RequestHandling;
using Microsoft.AspNetCore.Mvc;

public static class UrlGeneratorExtensions
{
    public static string MvcUrl<TController>(this IUrlGenerator generator, string action = "index", object routeValues = null)
        where TController : Controller
    {
        string controllerName = typeof(TController).Name;

        return generator.GenerateUrl(action, controllerName.Substring(0, controllerName.Length - 10), routeValues);
    }
}