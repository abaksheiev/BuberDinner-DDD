using BS.Domain.Common.Models;
using BS.Domain.MenuAggregates.ValueObjects;

namespace BS.Domain.MenuAggregates.ValueObjects
{

    public sealed class MenuItem : Entity<MenuItemId>
    {
        public string Name { get; }
        public string Description { get; }

        private MenuItem(MenuItemId menuItemId, string name, string description)
            : base(menuItemId)
        {
            Name = name;
            Description = description;
        }

        public static MenuItem Create(string name, string description)
        {
            return new(MenuItemId.CreateUnique(), name, description);
        }

#pragma warning disable CS7036
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private MenuItem() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS7036
    }
}
