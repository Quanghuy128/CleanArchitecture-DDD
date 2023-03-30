
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menu;

namespace BuberDinner.Infrastucture.Persistence
{
    public class MenuRepository : IMenuRepository
    {
        private readonly List<Menu> _menus;
        public void Add(Menu menu)
        {
            _menus.Add(menu);
        }
    }
}
