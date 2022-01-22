using Microsoft.EntityFrameworkCore;
using TourBy.Domain.Base;
using TourBy.Domain.Post;
using TourBy.Domain.Route;

namespace TourBy.Data.Persistent.Sql;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Route> Routes { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Route>(builder => builder.HasKey(r => r.Id));

        modelBuilder.Entity<Post>(builder => builder.HasKey(p => p.Id));

        modelBuilder.Entity<Post>(builder => builder.HasOne<Route>().WithMany(n => n.Posts));
        
        base.OnModelCreating(modelBuilder);
    }
}