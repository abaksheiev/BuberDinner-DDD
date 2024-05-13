namespace BS.Domain.Common.Models
{
    public abstract class AggregateRoot<TId> : Entity<TId>
    {
        
        protected AggregateRoot(TId id):base(id)
        {
            Id = id;
        }

#pragma warning disable CS7036
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        protected AggregateRoot()
        {
        }
#pragma warning restore CS8618
#pragma warning restore CS7036
    }
}
