using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();

        public string Name { get; set; }
        public string Description { get; set; }
        public AverageRating AverageRating { get; set; }
        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
        public HostId HostId { get; }

        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

        public DateTime CreateDateTime { get; set; }

        public DateTime UpdateDateTime { get; set; }

        private Menu(
            MenuId menuId,
            string name,
            string description,
            AverageRating averageRating,
            HostId hostId,
            List<MenuSection> sections,
            DateTime createDateTime,
            DateTime updateDateTime
        ) : base(menuId)
        {
            Name = name;
            Description = description;
            AverageRating = averageRating;
            HostId = hostId;
            _sections = sections;
            CreateDateTime = createDateTime;
            UpdateDateTime = updateDateTime;
        }

        public static Menu Create
        (
            HostId hostId,
            string name,
            string description,
            List<MenuSection>? sections
        )
        {
            return new(
                MenuId.CreateUnique(),
                name,
                description,
                AverageRating.CreateNew(),
                hostId,
                sections,
                DateTime.UtcNow,
                DateTime.UtcNow
            ); ;
        }
    }
}
