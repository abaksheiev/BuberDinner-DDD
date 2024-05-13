using BS.Domain.Common.Models;

namespace BS.Domain.MenuAggregates.ValueObjects
{
    public sealed class MenuItemId : ValueObject
    {
        public Guid Value { get; private set; }

        private MenuItemId(Guid value)
        {
            Value = value;
        }

        public static MenuItemId CreateUnique()
        {
            return new MenuItemId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static MenuItemId Create(Guid value)
        {
            return new(value);
        }
    }
}
