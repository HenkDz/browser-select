using Microsoft.AspNetCore.Mvc;
using UrlRouterService.APIs;
using UrlRouterService.APIs.Common;
using UrlRouterService.APIs.Dtos;
using UrlRouterService.APIs.Errors;

namespace UrlRouterService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class UserSettingsItemsControllerBase : ControllerBase
{
    protected readonly IUserSettingsItemsService _service;

    public UserSettingsItemsControllerBase(IUserSettingsItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one UserSettings
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<UserSettings>> CreateUserSettings(UserSettingsCreateInput input)
    {
        var userSettings = await _service.CreateUserSettings(input);

        return CreatedAtAction(nameof(UserSettings), new { id = userSettings.Id }, userSettings);
    }

    /// <summary>
    /// Delete one UserSettings
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteUserSettings(
        [FromRoute()] UserSettingsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteUserSettings(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many UserSettingsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<UserSettings>>> UserSettingsItems(
        [FromQuery()] UserSettingsFindManyArgs filter
    )
    {
        return Ok(await _service.UserSettingsItems(filter));
    }

    /// <summary>
    /// Meta data about UserSettings records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> UserSettingsItemsMeta(
        [FromQuery()] UserSettingsFindManyArgs filter
    )
    {
        return Ok(await _service.UserSettingsItemsMeta(filter));
    }

    /// <summary>
    /// Get one UserSettings
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<UserSettings>> UserSettings(
        [FromRoute()] UserSettingsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.UserSettings(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one UserSettings
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateUserSettings(
        [FromRoute()] UserSettingsWhereUniqueInput uniqueId,
        [FromQuery()] UserSettingsUpdateInput userSettingsUpdateDto
    )
    {
        try
        {
            await _service.UpdateUserSettings(uniqueId, userSettingsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
