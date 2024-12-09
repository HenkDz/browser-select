using UrlRouterService.APIs.Dtos;
using UrlRouterService.Infrastructure.Models;

namespace UrlRouterService.APIs.Extensions;

public static class UrlPatternsExtensions
{
    public static UrlPattern ToDto(this UrlPatternDbModel model)
    {
        return new UrlPattern
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static UrlPatternDbModel ToModel(
        this UrlPatternUpdateInput updateDto,
        UrlPatternWhereUniqueInput uniqueId
    )
    {
        var urlPattern = new UrlPatternDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            urlPattern.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            urlPattern.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return urlPattern;
    }
}
