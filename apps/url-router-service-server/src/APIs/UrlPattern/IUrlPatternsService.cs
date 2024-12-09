using UrlRouterService.APIs.Common;
using UrlRouterService.APIs.Dtos;

namespace UrlRouterService.APIs;

public interface IUrlPatternsService
{
    /// <summary>
    /// Create one URLPattern
    /// </summary>
    public Task<UrlPattern> CreateUrlPattern(UrlPatternCreateInput urlpattern);

    /// <summary>
    /// Delete one URLPattern
    /// </summary>
    public Task DeleteUrlPattern(UrlPatternWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many URLPatterns
    /// </summary>
    public Task<List<UrlPattern>> UrlPatterns(UrlPatternFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about URLPattern records
    /// </summary>
    public Task<MetadataDto> UrlPatternsMeta(UrlPatternFindManyArgs findManyArgs);

    /// <summary>
    /// Get one URLPattern
    /// </summary>
    public Task<UrlPattern> UrlPattern(UrlPatternWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one URLPattern
    /// </summary>
    public Task UpdateUrlPattern(
        UrlPatternWhereUniqueInput uniqueId,
        UrlPatternUpdateInput updateDto
    );
}
