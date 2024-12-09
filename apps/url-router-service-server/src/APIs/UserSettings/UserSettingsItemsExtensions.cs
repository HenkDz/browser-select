using UrlRouterService.APIs.Dtos;
using UrlRouterService.Infrastructure.Models;

namespace UrlRouterService.APIs.Extensions;

public static class UserSettingsItemsExtensions
{
    public static UserSettings ToDto(this UserSettingsDbModel model)
    {
        return new UserSettings
        {
            CreatedAt = model.CreatedAt,
            DefaultBrowser = model.DefaultBrowser,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static UserSettingsDbModel ToModel(
        this UserSettingsUpdateInput updateDto,
        UserSettingsWhereUniqueInput uniqueId
    )
    {
        var userSettings = new UserSettingsDbModel
        {
            Id = uniqueId.Id,
            DefaultBrowser = updateDto.DefaultBrowser
        };

        if (updateDto.CreatedAt != null)
        {
            userSettings.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            userSettings.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return userSettings;
    }
}
