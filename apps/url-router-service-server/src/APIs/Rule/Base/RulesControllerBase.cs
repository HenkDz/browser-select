using Microsoft.AspNetCore.Mvc;
using UrlRouterService.APIs;
using UrlRouterService.APIs.Common;
using UrlRouterService.APIs.Dtos;
using UrlRouterService.APIs.Errors;

namespace UrlRouterService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class RulesControllerBase : ControllerBase
{
    protected readonly IRulesService _service;

    public RulesControllerBase(IRulesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Rule
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Rule>> CreateRule(RuleCreateInput input)
    {
        var rule = await _service.CreateRule(input);

        return CreatedAtAction(nameof(Rule), new { id = rule.Id }, rule);
    }

    /// <summary>
    /// Delete one Rule
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteRule([FromRoute()] RuleWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteRule(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Rules
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Rule>>> Rules([FromQuery()] RuleFindManyArgs filter)
    {
        return Ok(await _service.Rules(filter));
    }

    /// <summary>
    /// Meta data about Rule records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> RulesMeta([FromQuery()] RuleFindManyArgs filter)
    {
        return Ok(await _service.RulesMeta(filter));
    }

    /// <summary>
    /// Get one Rule
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Rule>> Rule([FromRoute()] RuleWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Rule(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Rule
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateRule(
        [FromRoute()] RuleWhereUniqueInput uniqueId,
        [FromQuery()] RuleUpdateInput ruleUpdateDto
    )
    {
        try
        {
            await _service.UpdateRule(uniqueId, ruleUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
