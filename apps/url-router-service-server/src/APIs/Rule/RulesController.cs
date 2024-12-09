using Microsoft.AspNetCore.Mvc;

namespace UrlRouterService.APIs;

[ApiController()]
public class RulesController : RulesControllerBase
{
    public RulesController(IRulesService service)
        : base(service) { }
}
