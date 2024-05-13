using BS.Domain.Common.Models;
using BS.Domain.MenuAggregates.ValueObjects;

namespace BS.Domain.MenuAggregates.ValueObjects
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public MenuItem(MenuItemId menuItemId, string name, string description) : base(menuItemId)
        {
            Name = name;
            Description = description;
        }

        public static MenuItem Create(string name, string description)
        {
            return new(MenuItemId.CreateUnique(), name, description);
        }
    }
}
