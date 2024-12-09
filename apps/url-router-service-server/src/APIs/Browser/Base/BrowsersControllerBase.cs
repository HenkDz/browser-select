using Microsoft.AspNetCore.Mvc;
using UrlRouterService.APIs;
using UrlRouterService.APIs.Common;
using UrlRouterService.APIs.Dtos;
using UrlRouterService.APIs.Errors;

namespace UrlRouterService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class BrowsersControllerBase : ControllerBase
{
    protected readonly IBrowsersService _service;

    public BrowsersControllerBase(IBrowsersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Browser
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Browser>> CreateBrowser(BrowserCreateInput input)
    {
        var browser = await _service.CreateBrowser(input);

        return CreatedAtAction(nameof(Browser), new { id = browser.Id }, browser);
    }

    /// <summary>
    /// Delete one Browser
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteBrowser([FromRoute()] BrowserWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteBrowser(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Browsers
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Browser>>> Browsers(
        [FromQuery()] BrowserFindManyArgs filter
    )
    {
        return Ok(await _service.Browsers(filter));
    }

    /// <summary>
    /// Meta data about Browser records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> BrowsersMeta(
        [FromQuery()] BrowserFindManyArgs filter
    )
    {
        return Ok(await _service.BrowsersMeta(filter));
    }

    /// <summary>
    /// Get one Browser
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Browser>> Browser([FromRoute()] BrowserWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Browser(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Browser
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateBrowser(
        [FromRoute()] BrowserWhereUniqueInput uniqueId,
        [FromQuery()] BrowserUpdateInput browserUpdateDto
    )
    {
        try
        {
            await _service.UpdateBrowser(uniqueId, browserUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
