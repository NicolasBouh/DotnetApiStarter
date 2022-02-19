using DotnetApiStarter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetApiStarter.Application.Interfaces;

public interface IAppDbContext
{
    DbSet<User> Users { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}