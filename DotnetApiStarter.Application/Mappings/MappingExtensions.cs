using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace DotnetApiStarter.Application.Mappings;

public static class MappingExtensions
{
    public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, AutoMapper.IConfigurationProvider configuration)
        => queryable.ProjectTo<TDestination>(configuration).ToListAsync();
}