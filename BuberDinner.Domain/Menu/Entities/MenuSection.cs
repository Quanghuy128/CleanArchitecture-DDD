using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();
        public string Name { get; set; }
        public string Description { get; set; }

        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        private MenuSection(MenuSectionId menuSectionId, string name, string description)
            :base(menuSectionId)
        {
            Name = name;
            Description = description;
        }
        public static MenuSection Create(string name, string description)
        {
            return new(
                MenuSectionId.CreateUnique(),
                name,
                description
            );
        }
    }
}
