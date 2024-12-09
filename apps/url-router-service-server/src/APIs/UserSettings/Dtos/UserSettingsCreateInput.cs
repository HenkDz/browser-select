namespace UrlRouterService.APIs.Dtos;

public class UserSettingsCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? DefaultBrowser { get; set; }

    public string? Id { get; set; }

    public DateTime UpdatedAt { get; set; }
}
