using TourBy.Domain.Base;

namespace TourBy.Domain.Post;

public class Post : Entity<Guid>
{
    public Post(Guid id) 
        : base(id)
    {
    }
    public string Title { get; set; }
    public Guid RouteId { get; set; }
}

