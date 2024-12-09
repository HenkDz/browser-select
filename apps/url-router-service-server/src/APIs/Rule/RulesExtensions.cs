using UrlRouterService.APIs.Dtos;
using UrlRouterService.Infrastructure.Models;

namespace UrlRouterService.APIs.Extensions;

public static class RulesExtensions
{
    public static Rule ToDto(this RuleDbModel model)
    {
        return new Rule
        {
            CreatedAt = model.CreatedAt,
            DestinationBrowser = model.DestinationBrowser,
            Id = model.Id,
            IsActive = model.IsActive,
            MatchType = model.MatchType,
            UpdatedAt = model.UpdatedAt,
            UrlPattern = model.UrlPattern,
        };
    }

    public static RuleDbModel ToModel(this RuleUpdateInput updateDto, RuleWhereUniqueInput uniqueId)
    {
        var rule = new RuleDbModel
        {
            Id = uniqueId.Id,
            DestinationBrowser = updateDto.DestinationBrowser,
            IsActive = updateDto.IsActive,
            MatchType = updateDto.MatchType,
            UrlPattern = updateDto.UrlPattern
        };

        if (updateDto.CreatedAt != null)
        {
            rule.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            rule.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return rule;
    }
}
