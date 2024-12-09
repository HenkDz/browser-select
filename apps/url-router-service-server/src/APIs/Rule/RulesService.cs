using UrlRouterService.Infrastructure;

namespace UrlRouterService.APIs;

public class RulesService : RulesServiceBase
{
    public RulesService(UrlRouterServiceDbContext context)
        : base(context) { }
}
