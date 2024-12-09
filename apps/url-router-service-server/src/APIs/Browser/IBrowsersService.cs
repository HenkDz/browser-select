using UrlRouterService.APIs.Common;
using UrlRouterService.APIs.Dtos;

namespace UrlRouterService.APIs;

public interface IBrowsersService
{
    /// <summary>
    /// Create one Browser
    /// </summary>
    public Task<Browser> CreateBrowser(BrowserCreateInput browser);

    /// <summary>
    /// Delete one Browser
    /// </summary>
    public Task DeleteBrowser(BrowserWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Browsers
    /// </summary>
    public Task<List<Browser>> Browsers(BrowserFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Browser records
    /// </summary>
    public Task<MetadataDto> BrowsersMeta(BrowserFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Browser
    /// </summary>
    public Task<Browser> Browser(BrowserWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Browser
    /// </summary>
    public Task UpdateBrowser(BrowserWhereUniqueInput uniqueId, BrowserUpdateInput updateDto);
}
