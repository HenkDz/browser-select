namespace UrlRouterService.APIs.Dtos;

public class HistoryCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? SelectedBrowser { get; set; }

    public DateTime? Timestamp { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Url { get; set; }
}
