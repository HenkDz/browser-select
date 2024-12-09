using UrlRouterService.Infrastructure;

namespace UrlRouterService.APIs;

public class BrowsersService : BrowsersServiceBase
{
    public BrowsersService(UrlRouterServiceDbContext context)
        : base(context) { }
}
