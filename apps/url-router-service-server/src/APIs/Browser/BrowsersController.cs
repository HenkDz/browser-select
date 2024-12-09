using Microsoft.AspNetCore.Mvc;

namespace UrlRouterService.APIs;

[ApiController()]
public class BrowsersController : BrowsersControllerBase
{
    public BrowsersController(IBrowsersService service)
        : base(service) { }
}
