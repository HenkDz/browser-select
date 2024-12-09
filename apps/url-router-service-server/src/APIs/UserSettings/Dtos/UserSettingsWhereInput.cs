namespace UrlRouterService.APIs.Dtos;

public class UserSettingsWhereInput
{
    public DateTime? CreatedAt { get; set; }

    public string? DefaultBrowser { get; set; }

    public string? Id { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
