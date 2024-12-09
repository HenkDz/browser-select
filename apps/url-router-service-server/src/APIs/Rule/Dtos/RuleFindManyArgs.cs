using Microsoft.AspNetCore.Mvc;
using UrlRouterService.APIs.Common;
using UrlRouterService.Infrastructure.Models;

namespace UrlRouterService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class RuleFindManyArgs : FindManyInput<Rule, RuleWhereInput> { }