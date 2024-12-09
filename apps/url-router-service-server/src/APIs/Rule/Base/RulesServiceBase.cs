using Microsoft.EntityFrameworkCore;
using UrlRouterService.APIs;
using UrlRouterService.APIs.Common;
using UrlRouterService.APIs.Dtos;
using UrlRouterService.APIs.Errors;
using UrlRouterService.APIs.Extensions;
using UrlRouterService.Infrastructure;
using UrlRouterService.Infrastructure.Models;

namespace UrlRouterService.APIs;

public abstract class RulesServiceBase : IRulesService
{
    protected readonly UrlRouterServiceDbContext _context;

    public RulesServiceBase(UrlRouterServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Rule
    /// </summary>
    public async Task<Rule> CreateRule(RuleCreateInput createDto)
    {
        var rule = new RuleDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            rule.Id = createDto.Id;
        }

        _context.Rules.Add(rule);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<RuleDbModel>(rule.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Rule
    /// </summary>
    public async Task DeleteRule(RuleWhereUniqueInput uniqueId)
    {
        var rule = await _context.Rules.FindAsync(uniqueId.Id);
        if (rule == null)
        {
            throw new NotFoundException();
        }

        _context.Rules.Remove(rule);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Rules
    /// </summary>
    public async Task<List<Rule>> Rules(RuleFindManyArgs findManyArgs)
    {
        var rules = await _context
            .Rules.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return rules.ConvertAll(rule => rule.ToDto());
    }

    /// <summary>
    /// Meta data about Rule records
    /// </summary>
    public async Task<MetadataDto> RulesMeta(RuleFindManyArgs findManyArgs)
    {
        var count = await _context.Rules.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Rule
    /// </summary>
    public async Task<Rule> Rule(RuleWhereUniqueInput uniqueId)
    {
        var rules = await this.Rules(
            new RuleFindManyArgs { Where = new RuleWhereInput { Id = uniqueId.Id } }
        );
        var rule = rules.FirstOrDefault();
        if (rule == null)
        {
            throw new NotFoundException();
        }

        return rule;
    }

    /// <summary>
    /// Update one Rule
    /// </summary>
    public async Task UpdateRule(RuleWhereUniqueInput uniqueId, RuleUpdateInput updateDto)
    {
        var rule = updateDto.ToModel(uniqueId);

        _context.Entry(rule).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Rules.Any(e => e.Id == rule.Id))
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
