using Microsoft.EntityFrameworkCore;
using UrlRouterService.APIs;
using UrlRouterService.APIs.Common;
using UrlRouterService.APIs.Dtos;
using UrlRouterService.APIs.Errors;
using UrlRouterService.APIs.Extensions;
using UrlRouterService.Infrastructure;
using UrlRouterService.Infrastructure.Models;

namespace UrlRouterService.APIs;

public abstract class UserSettingsItemsServiceBase : IUserSettingsItemsService
{
    protected readonly UrlRouterServiceDbContext _context;

    public UserSettingsItemsServiceBase(UrlRouterServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one UserSettings
    /// </summary>
    public async Task<UserSettings> CreateUserSettings(UserSettingsCreateInput createDto)
    {
        var userSettings = new UserSettingsDbModel
        {
            CreatedAt = createDto.CreatedAt,
            DefaultBrowser = createDto.DefaultBrowser,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            userSettings.Id = createDto.Id;
        }

        _context.UserSettingsItems.Add(userSettings);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<UserSettingsDbModel>(userSettings.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one UserSettings
    /// </summary>
    public async Task DeleteUserSettings(UserSettingsWhereUniqueInput uniqueId)
    {
        var userSettings = await _context.UserSettingsItems.FindAsync(uniqueId.Id);
        if (userSettings == null)
        {
            throw new NotFoundException();
        }

        _context.UserSettingsItems.Remove(userSettings);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many UserSettingsItems
    /// </summary>
    public async Task<List<UserSettings>> UserSettingsItems(UserSettingsFindManyArgs findManyArgs)
    {
        var userSettingsItems = await _context
            .UserSettingsItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return userSettingsItems.ConvertAll(userSettings => userSettings.ToDto());
    }

    /// <summary>
    /// Meta data about UserSettings records
    /// </summary>
    public async Task<MetadataDto> UserSettingsItemsMeta(UserSettingsFindManyArgs findManyArgs)
    {
        var count = await _context.UserSettingsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one UserSettings
    /// </summary>
    public async Task<UserSettings> UserSettings(UserSettingsWhereUniqueInput uniqueId)
    {
        var userSettingsItems = await this.UserSettingsItems(
            new UserSettingsFindManyArgs { Where = new UserSettingsWhereInput { Id = uniqueId.Id } }
        );
        var userSettings = userSettingsItems.FirstOrDefault();
        if (userSettings == null)
        {
            throw new NotFoundException();
        }

        return userSettings;
    }

    /// <summary>
    /// Update one UserSettings
    /// </summary>
    public async Task UpdateUserSettings(
        UserSettingsWhereUniqueInput uniqueId,
        UserSettingsUpdateInput updateDto
    )
    {
        var userSettings = updateDto.ToModel(uniqueId);

        _context.Entry(userSettings).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.UserSettingsItems.Any(e => e.Id == userSettings.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
