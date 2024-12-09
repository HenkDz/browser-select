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
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static RuleDbModel ToModel(this RuleUpdateInput updateDto, RuleWhereUniqueInput uniqueId)
    {
        var rule = new RuleDbModel { Id = uniqueId.Id };

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
