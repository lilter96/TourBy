namespace TourBy.Domain.Base;

public interface IBaseEntity<out T> : IEntity
{
    T Id { get; }
}