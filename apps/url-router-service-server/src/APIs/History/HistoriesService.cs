using UrlRouterService.Infrastructure;

namespace UrlRouterService.APIs;

public class HistoriesService : HistoriesServiceBase
{
    public HistoriesService(UrlRouterServiceDbContext context)
        : base(context) { }
}
