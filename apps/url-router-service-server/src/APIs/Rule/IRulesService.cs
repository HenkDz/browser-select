using UrlRouterService.APIs.Common;
using UrlRouterService.APIs.Dtos;

namespace UrlRouterService.APIs;

public interface IRulesService
{
    /// <summary>
    /// Create one Rule
    /// </summary>
    public Task<Rule> CreateRule(RuleCreateInput rule);

    /// <summary>
    /// Delete one Rule
    /// </summary>
    public Task DeleteRule(RuleWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Rules
    /// </summary>
    public Task<List<Rule>> Rules(RuleFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Rule records
    /// </summary>
    public Task<MetadataDto> RulesMeta(RuleFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Rule
    /// </summary>
    public Task<Rule> Rule(RuleWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Rule
    /// </summary>
    public Task UpdateRule(RuleWhereUniqueInput uniqueId, RuleUpdateInput updateDto);
}
