namespace TourBy.Domain.Base;

public class Entity<T> :
    IBaseEntity<T>,
    IEquatable<Entity<T>>
{
    public T Id { get; protected set; }

    protected Entity(T id)
    {
        if (Equals(id, default(T)))
        {
            throw new ArgumentException("The ID cannot be the type's default value.", nameof(id));
        }

        Id = id;
    }

    protected Entity()
    {
    }

    public override bool Equals(object obj)
    {
        var entity = obj as Entity<T>;
        if (entity != null)
        {
            return Equals(entity);
        }

        return Equals(obj);
    }

    public virtual bool Equals(Entity<T> other)
    {
        if (other == null)
        {
            return false;
        }

        return Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}