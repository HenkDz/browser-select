using Microsoft.EntityFrameworkCore;
using UrlRouterService.APIs;
using UrlRouterService.APIs.Common;
using UrlRouterService.APIs.Dtos;
using UrlRouterService.APIs.Errors;
using UrlRouterService.APIs.Extensions;
using UrlRouterService.Infrastructure;
using UrlRouterService.Infrastructure.Models;

namespace UrlRouterService.APIs;

public abstract class UrlPatternsServiceBase : IUrlPatternsService
{
    protected readonly UrlRouterServiceDbContext _context;

    public UrlPatternsServiceBase(UrlRouterServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one URLPattern
    /// </summary>
    public async Task<UrlPattern> CreateUrlPattern(UrlPatternCreateInput createDto)
    {
        var urlPattern = new UrlPatternDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            urlPattern.Id = createDto.Id;
        }

        _context.UrlPatterns.Add(urlPattern);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<UrlPatternDbModel>(urlPattern.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one URLPattern
    /// </summary>
    public async Task DeleteUrlPattern(UrlPatternWhereUniqueInput uniqueId)
    {
        var urlPattern = await _context.UrlPatterns.FindAsync(uniqueId.Id);
        if (urlPattern == null)
        {
            throw new NotFoundException();
        }

        _context.UrlPatterns.Remove(urlPattern);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many URLPatterns
    /// </summary>
    public async Task<List<UrlPattern>> UrlPatterns(UrlPatternFindManyArgs findManyArgs)
    {
        var urlPatterns = await _context
            .UrlPatterns.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return urlPatterns.ConvertAll(urlPattern => urlPattern.ToDto());
    }

    /// <summary>
    /// Meta data about URLPattern records
    /// </summary>
    public async Task<MetadataDto> UrlPatternsMeta(UrlPatternFindManyArgs findManyArgs)
    {
        var count = await _context.UrlPatterns.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one URLPattern
    /// </summary>
    public async Task<UrlPattern> UrlPattern(UrlPatternWhereUniqueInput uniqueId)
    {
        var urlPatterns = await this.UrlPatterns(
            new UrlPatternFindManyArgs { Where = new UrlPatternWhereInput { Id = uniqueId.Id } }
        );
        var urlPattern = urlPatterns.FirstOrDefault();
        if (urlPattern == null)
        {
            throw new NotFoundException();
        }

        return urlPattern;
    }

    /// <summary>
    /// Update one URLPattern
    /// </summary>
    public async Task UpdateUrlPattern(
        UrlPatternWhereUniqueInput uniqueId,
        UrlPatternUpdateInput updateDto
    )
    {
        var urlPattern = updateDto.ToModel(uniqueId);

        _context.Entry(urlPattern).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.UrlPatterns.Any(e => e.Id == urlPattern.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
