using UrlRouterService.Core.Enums;

namespace UrlRouterService.APIs.Dtos;

public class RuleCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? DestinationBrowser { get; set; }

    public string? Id { get; set; }

    public bool? IsActive { get; set; }

    public MatchTypeEnum? MatchType { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? UrlPattern { get; set; }
}
