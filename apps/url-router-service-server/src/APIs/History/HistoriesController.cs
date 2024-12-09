using Microsoft.AspNetCore.Mvc;

namespace UrlRouterService.APIs;

[ApiController()]
public class HistoriesController : HistoriesControllerBase
{
    public HistoriesController(IHistoriesService service)
        : base(service) { }
}
