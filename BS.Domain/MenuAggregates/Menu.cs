﻿using BS.Domain.Common.Models;
using BS.Domain.Dinner.ValueObjects;
using BS.Domain.Host.ValueObjects;
using BS.Domain.MenuAggregates.Entities;
using BS.Domain.MenuAggregates.ValueObjects;
using BS.Domain.MenuReview.ValueObjects;
using BS.Domain.Common.ValueObjects;
using BS.Domain.MenuAggregates.Events;

namespace BS.Domain.MenuAggregates
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public AverageRating AverageRating { get; }

        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

        public HostId HostId { get; private set; }
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

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
            HostId hostId,
            string name,
            string description,
            List<MenuSection>? sections = null)
        {
            var menu = new Menu(
                MenuId.CreateUnique(),
                hostId,
                name,
                description,
                AverageRating.CreateNew(0),
                sections ?? new());

            menu.AddDomainEvent(new MenuCreated(menu));

            return menu;
        }

       
#pragma warning disable CS8618
        private Menu() { }
#pragma warning restore CS8618
    }
}