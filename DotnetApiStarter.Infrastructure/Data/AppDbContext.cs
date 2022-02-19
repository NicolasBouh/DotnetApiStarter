using DotnetApiStarter.Application.Interfaces;
using DotnetApiStarter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetApiStarter.Infrastructure.Data;

public class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<User> Users { get; set; } = default!;
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var userBuilder = modelBuilder.Entity<User>();
        userBuilder.HasKey(x => x.Id);
        userBuilder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        userBuilder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
        userBuilder.Property(x => x.Email).IsRequired().HasMaxLength(100);
        userBuilder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(300);
        userBuilder.Property(x => x.PasswordSalt).IsRequired().HasMaxLength(50);
    }
}