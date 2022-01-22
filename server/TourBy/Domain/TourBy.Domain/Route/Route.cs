using TourBy.Domain.Base;

namespace TourBy.Domain.Route;

public class Route : Entity<Guid>
{
    public Route(Guid id) : base(id) { }

    public string Name { get; set; }
    public List<Post.Post> Posts { get; set; } = new();
}