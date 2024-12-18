namespace UrlRouterService.APIs.Dtos;

public class BrowserCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? ExecutablePath { get; set; }

    public string? Id { get; set; }

    public string? Name { get; set; }

    public DateTime UpdatedAt { get; set; }
}
