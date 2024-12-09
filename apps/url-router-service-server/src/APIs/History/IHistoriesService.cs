using UrlRouterService.APIs.Common;
using UrlRouterService.APIs.Dtos;

namespace UrlRouterService.APIs;

public interface IHistoriesService
{
    /// <summary>
    /// Create one History
    /// </summary>
    public Task<History> CreateHistory(HistoryCreateInput history);

    /// <summary>
    /// Delete one History
    /// </summary>
    public Task DeleteHistory(HistoryWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Histories
    /// </summary>
    public Task<List<History>> Histories(HistoryFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about History records
    /// </summary>
    public Task<MetadataDto> HistoriesMeta(HistoryFindManyArgs findManyArgs);

    /// <summary>
    /// Get one History
    /// </summary>
    public Task<History> History(HistoryWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one History
    /// </summary>
    public Task UpdateHistory(HistoryWhereUniqueInput uniqueId, HistoryUpdateInput updateDto);
}
