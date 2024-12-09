using UrlRouterService.APIs.Dtos;
using UrlRouterService.Infrastructure.Models;

namespace UrlRouterService.APIs.Extensions;

public static class BrowsersExtensions
{
    public static Browser ToDto(this BrowserDbModel model)
    {
        return new Browser
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static BrowserDbModel ToModel(
        this BrowserUpdateInput updateDto,
        BrowserWhereUniqueInput uniqueId
    )
    {
        var browser = new BrowserDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            browser.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            browser.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return browser;
    }
}
