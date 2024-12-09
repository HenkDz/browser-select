using Microsoft.AspNetCore.Mvc;

namespace UrlRouterService.APIs;

[ApiController()]
public class UrlPatternsController : UrlPatternsControllerBase
{
    public UrlPatternsController(IUrlPatternsService service)
        : base(service) { }
}
