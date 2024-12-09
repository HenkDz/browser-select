using UrlRouterService.APIs.Common;
using UrlRouterService.APIs.Dtos;

namespace UrlRouterService.APIs;

public interface IUserSettingsItemsService
{
    /// <summary>
    /// Create one UserSettings
    /// </summary>
    public Task<UserSettings> CreateUserSettings(UserSettingsCreateInput usersettings);

    /// <summary>
    /// Delete one UserSettings
    /// </summary>
    public Task DeleteUserSettings(UserSettingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many UserSettingsItems
    /// </summary>
    public Task<List<UserSettings>> UserSettingsItems(UserSettingsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about UserSettings records
    /// </summary>
    public Task<MetadataDto> UserSettingsItemsMeta(UserSettingsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one UserSettings
    /// </summary>
    public Task<UserSettings> UserSettings(UserSettingsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one UserSettings
    /// </summary>
    public Task UpdateUserSettings(
        UserSettingsWhereUniqueInput uniqueId,
        UserSettingsUpdateInput updateDto
    );
}
