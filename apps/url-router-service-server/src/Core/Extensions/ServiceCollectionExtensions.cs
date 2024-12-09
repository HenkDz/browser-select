using UrlRouterService.APIs;

namespace UrlRouterService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IBrowsersService, BrowsersService>();
        services.AddScoped<IRulesService, RulesService>();
        services.AddScoped<IUrlPatternsService, UrlPatternsService>();
    }
}
