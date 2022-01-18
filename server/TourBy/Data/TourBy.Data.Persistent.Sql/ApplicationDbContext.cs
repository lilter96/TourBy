using Microsoft.EntityFrameworkCore;
using TourBy.Domain.Post;

namespace TourBy.Data.Persistent.Sql;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Post>(x => x.HasKey(p => p.Id));
    }
}