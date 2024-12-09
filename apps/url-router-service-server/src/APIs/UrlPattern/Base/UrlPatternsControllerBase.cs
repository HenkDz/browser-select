using Microsoft.AspNetCore.Mvc;
using UrlRouterService.APIs;
using UrlRouterService.APIs.Common;
using UrlRouterService.APIs.Dtos;
using UrlRouterService.APIs.Errors;

namespace UrlRouterService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class UrlPatternsControllerBase : ControllerBase
{
    protected readonly IUrlPatternsService _service;

    public UrlPatternsControllerBase(IUrlPatternsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one URLPattern
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<UrlPattern>> CreateUrlPattern(UrlPatternCreateInput input)
    {
        var urlPattern = await _service.CreateUrlPattern(input);

        return CreatedAtAction(nameof(UrlPattern), new { id = urlPattern.Id }, urlPattern);
    }

    /// <summary>
    /// Delete one URLPattern
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteUrlPattern(
        [FromRoute()] UrlPatternWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteUrlPattern(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many URLPatterns
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<UrlPattern>>> UrlPatterns(
        [FromQuery()] UrlPatternFindManyArgs filter
    )
    {
        return Ok(await _service.UrlPatterns(filter));
    }

    /// <summary>
    /// Meta data about URLPattern records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> UrlPatternsMeta(
        [FromQuery()] UrlPatternFindManyArgs filter
    )
    {
        return Ok(await _service.UrlPatternsMeta(filter));
    }

    /// <summary>
    /// Get one URLPattern
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<UrlPattern>> UrlPattern(
        [FromRoute()] UrlPatternWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.UrlPattern(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one URLPattern
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateUrlPattern(
        [FromRoute()] UrlPatternWhereUniqueInput uniqueId,
        [FromQuery()] UrlPatternUpdateInput urlPatternUpdateDto
    )
    {
        try
        {
            await _service.UpdateUrlPattern(uniqueId, urlPatternUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
