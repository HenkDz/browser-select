using Microsoft.EntityFrameworkCore;
using UrlRouterService.APIs;
using UrlRouterService.APIs.Common;
using UrlRouterService.APIs.Dtos;
using UrlRouterService.APIs.Errors;
using UrlRouterService.APIs.Extensions;
using UrlRouterService.Infrastructure;
using UrlRouterService.Infrastructure.Models;

namespace UrlRouterService.APIs;

public abstract class BrowsersServiceBase : IBrowsersService
{
    protected readonly UrlRouterServiceDbContext _context;

    public BrowsersServiceBase(UrlRouterServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Browser
    /// </summary>
    public async Task<Browser> CreateBrowser(BrowserCreateInput createDto)
    {
        var browser = new BrowserDbModel
        {
            CreatedAt = createDto.CreatedAt,
            ExecutablePath = createDto.ExecutablePath,
            Name = createDto.Name,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            browser.Id = createDto.Id;
        }

        _context.Browsers.Add(browser);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<BrowserDbModel>(browser.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Browser
    /// </summary>
    public async Task DeleteBrowser(BrowserWhereUniqueInput uniqueId)
    {
        var browser = await _context.Browsers.FindAsync(uniqueId.Id);
        if (browser == null)
        {
            throw new NotFoundException();
        }

        _context.Browsers.Remove(browser);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Browsers
    /// </summary>
    public async Task<List<Browser>> Browsers(BrowserFindManyArgs findManyArgs)
    {
        var browsers = await _context
            .Browsers.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return browsers.ConvertAll(browser => browser.ToDto());
    }

    /// <summary>
    /// Meta data about Browser records
    /// </summary>
    public async Task<MetadataDto> BrowsersMeta(BrowserFindManyArgs findManyArgs)
    {
        var count = await _context.Browsers.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Browser
    /// </summary>
    public async Task<Browser> Browser(BrowserWhereUniqueInput uniqueId)
    {
        var browsers = await this.Browsers(
            new BrowserFindManyArgs { Where = new BrowserWhereInput { Id = uniqueId.Id } }
        );
        var browser = browsers.FirstOrDefault();
        if (browser == null)
        {
            throw new NotFoundException();
        }

        return browser;
    }

    /// <summary>
    /// Update one Browser
    /// </summary>
    public async Task UpdateBrowser(BrowserWhereUniqueInput uniqueId, BrowserUpdateInput updateDto)
    {
        var browser = updateDto.ToModel(uniqueId);

        _context.Entry(browser).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Browsers.Any(e => e.Id == browser.Id))
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
