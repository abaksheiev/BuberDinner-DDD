using BS.Domain.Common.Models;
using BS.Domain.Dinner.ValueObjects;
using BS.Domain.Host.ValueObjects;
using BS.Domain.MenuAggregates.Entities;
using BS.Domain.MenuAggregates.ValueObjects;
using BS.Domain.MenuReview.ValueObjects;
using BS.Domain.Common.ValueObjects;

namespace BS.Domain.MenuAggregates
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        public string Name { get; private set; }
        public string Description { get; }
        public AverageRating AverageRating { get; private set; }

        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

        public HostId HostId { get; private set; }

        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        public Menu(MenuId menuId, string name, string description, HostId hostId, DateTime createdDateTime, DateTime updatedDateTime) : base(menuId)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        private Menu(
        MenuId menuId,
        HostId hostId,
        string name,
        string description,
        AverageRating averageRating,
        List<MenuSection>? sections)
        : base(menuId)
        {
            HostId = hostId;
            Name = name;
            Description = description;
            _sections = sections;
            AverageRating = averageRating;
        }

        public static Menu Create(
            string name,
            string description,
            HostId hostId
            )
        {
            return new(MenuId.CreateUnique(),
                       name,
                       description,
                       hostId,
                       DateTime.UtcNow,
                       DateTime.UtcNow);
        }
        public static Menu Create(
              HostId hostId,
              string name,
              string description,
              List<MenuSection>? sections = null)
                {
                    var menu = new Menu(
                        MenuId.CreateUnique(),
                        name,
                        description,
                        hostId,
                        DateTime.UtcNow,
                        DateTime.UtcNow);
                    return menu;
                }
    }
}
