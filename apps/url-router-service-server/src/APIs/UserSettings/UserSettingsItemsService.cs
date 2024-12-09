using UrlRouterService.Infrastructure;

namespace UrlRouterService.APIs;

public class UserSettingsItemsService : UserSettingsItemsServiceBase
{
    public UserSettingsItemsService(UrlRouterServiceDbContext context)
        : base(context) { }
}
