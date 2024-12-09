using Microsoft.AspNetCore.Mvc;
using UrlRouterService.APIs;
using UrlRouterService.APIs.Common;
using UrlRouterService.APIs.Dtos;
using UrlRouterService.APIs.Errors;

namespace UrlRouterService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class HistoriesControllerBase : ControllerBase
{
    protected readonly IHistoriesService _service;

    public HistoriesControllerBase(IHistoriesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one History
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<History>> CreateHistory(HistoryCreateInput input)
    {
        var history = await _service.CreateHistory(input);

        return CreatedAtAction(nameof(History), new { id = history.Id }, history);
    }

    /// <summary>
    /// Delete one History
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteHistory([FromRoute()] HistoryWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteHistory(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Histories
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<History>>> Histories(
        [FromQuery()] HistoryFindManyArgs filter
    )
    {
        return Ok(await _service.Histories(filter));
    }

    /// <summary>
    /// Meta data about History records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> HistoriesMeta(
        [FromQuery()] HistoryFindManyArgs filter
    )
    {
        return Ok(await _service.HistoriesMeta(filter));
    }

    /// <summary>
    /// Get one History
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<History>> History([FromRoute()] HistoryWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.History(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one History
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateHistory(
        [FromRoute()] HistoryWhereUniqueInput uniqueId,
        [FromQuery()] HistoryUpdateInput historyUpdateDto
    )
    {
        try
        {
            await _service.UpdateHistory(uniqueId, historyUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
