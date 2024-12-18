using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UrlRouterService.Core.Enums;

namespace UrlRouterService.Infrastructure.Models;

[Table("Rules")]
public class RuleDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? DestinationBrowser { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public bool? IsActive { get; set; }

    public MatchTypeEnum? MatchType { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [StringLength(1000)]
    public string? UrlPattern { get; set; }
}
