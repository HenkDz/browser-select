using Microsoft.EntityFrameworkCore;
using UrlRouterService.Infrastructure.Models;

namespace UrlRouterService.Infrastructure;

public class UrlRouterServiceDbContext : DbContext
{
    public UrlRouterServiceDbContext(DbContextOptions<UrlRouterServiceDbContext> options)
        : base(options) { }

    public DbSet<BrowserDbModel> Browsers { get; set; }

    public DbSet<RuleDbModel> Rules { get; set; }

    public DbSet<UrlPatternDbModel> UrlPatterns { get; set; }
}