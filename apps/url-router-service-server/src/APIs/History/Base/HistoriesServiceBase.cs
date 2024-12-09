using Microsoft.EntityFrameworkCore;
using UrlRouterService.APIs;
using UrlRouterService.APIs.Common;
using UrlRouterService.APIs.Dtos;
using UrlRouterService.APIs.Errors;
using UrlRouterService.APIs.Extensions;
using UrlRouterService.Infrastructure;
using UrlRouterService.Infrastructure.Models;

namespace UrlRouterService.APIs;

public abstract class HistoriesServiceBase : IHistoriesService
{
    protected readonly UrlRouterServiceDbContext _context;

    public HistoriesServiceBase(UrlRouterServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one History
    /// </summary>
    public async Task<History> CreateHistory(HistoryCreateInput createDto)
    {
        var history = new HistoryDbModel
        {
            CreatedAt = createDto.CreatedAt,
            SelectedBrowser = createDto.SelectedBrowser,
            Timestamp = createDto.Timestamp,
            UpdatedAt = createDto.UpdatedAt,
            Url = createDto.Url
        };

        if (createDto.Id != null)
        {
            history.Id = createDto.Id;
        }

        _context.Histories.Add(history);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<HistoryDbModel>(history.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one History
    /// </summary>
    public async Task DeleteHistory(HistoryWhereUniqueInput uniqueId)
    {
        var history = await _context.Histories.FindAsync(uniqueId.Id);
        if (history == null)
        {
            throw new NotFoundException();
        }

        _context.Histories.Remove(history);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Histories
    /// </summary>
    public async Task<List<History>> Histories(HistoryFindManyArgs findManyArgs)
    {
        var histories = await _context
            .Histories.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return histories.ConvertAll(history => history.ToDto());
    }

    /// <summary>
    /// Meta data about History records
    /// </summary>
    public async Task<MetadataDto> HistoriesMeta(HistoryFindManyArgs findManyArgs)
    {
        var count = await _context.Histories.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one History
    /// </summary>
    public async Task<History> History(HistoryWhereUniqueInput uniqueId)
    {
        var histories = await this.Histories(
            new HistoryFindManyArgs { Where = new HistoryWhereInput { Id = uniqueId.Id } }
        );
        var history = histories.FirstOrDefault();
        if (history == null)
        {
            throw new NotFoundException();
        }

        return history;
    }

    /// <summary>
    /// Update one History
    /// </summary>
    public async Task UpdateHistory(HistoryWhereUniqueInput uniqueId, HistoryUpdateInput updateDto)
    {
        var history = updateDto.ToModel(uniqueId);

        _context.Entry(history).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Histories.Any(e => e.Id == history.Id))
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
