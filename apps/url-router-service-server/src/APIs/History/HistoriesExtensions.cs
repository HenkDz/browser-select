using UrlRouterService.APIs.Dtos;
using UrlRouterService.Infrastructure.Models;

namespace UrlRouterService.APIs.Extensions;

public static class HistoriesExtensions
{
    public static History ToDto(this HistoryDbModel model)
    {
        return new History
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            SelectedBrowser = model.SelectedBrowser,
            Timestamp = model.Timestamp,
            UpdatedAt = model.UpdatedAt,
            Url = model.Url,
        };
    }

    public static HistoryDbModel ToModel(
        this HistoryUpdateInput updateDto,
        HistoryWhereUniqueInput uniqueId
    )
    {
        var history = new HistoryDbModel
        {
            Id = uniqueId.Id,
            SelectedBrowser = updateDto.SelectedBrowser,
            Timestamp = updateDto.Timestamp,
            Url = updateDto.Url
        };

        if (updateDto.CreatedAt != null)
        {
            history.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            history.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return history;
    }
}
