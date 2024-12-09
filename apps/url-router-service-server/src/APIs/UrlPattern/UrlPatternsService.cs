using UrlRouterService.Infrastructure;

namespace UrlRouterService.APIs;

public class UrlPatternsService : UrlPatternsServiceBase
{
    public UrlPatternsService(UrlRouterServiceDbContext context)
        : base(context) { }
}
