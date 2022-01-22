using TourBy.Domain.Base;

namespace TourBy.Domain.Tag;

public class Tag : Entity<Guid>
{
    public Tag(Guid id) : base(id) { }

    public string Name { get; set; }
}