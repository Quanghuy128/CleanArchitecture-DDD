using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        public string Name { get; set; }
        public string Description { get; set; }
        public float AverageRating { get; set; }

        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    }
}
