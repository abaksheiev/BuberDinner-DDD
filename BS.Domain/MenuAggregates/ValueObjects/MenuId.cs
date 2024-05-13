using BS.Domain.Common.Models;

namespace BS.Domain.MenuAggregates.ValueObjects
{
    public sealed class MenuId : ValueObject
    {
        public Guid Value { get; private set; }

        private MenuId(Guid value)
        {
            Value = value;
        }

        public static MenuId CreateUnique()
        { 
            return new MenuId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static MenuId Create(Guid value)
        {
            return new(value);
        }
    }
}
