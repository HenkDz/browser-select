using Microsoft.AspNetCore.Mvc;

namespace UrlRouterService.APIs;

[ApiController()]
public class UserSettingsItemsController : UserSettingsItemsControllerBase
{
    public UserSettingsItemsController(IUserSettingsItemsService service)
        : base(service) { }
}
