using MediatR;
using ErrorOr;
using BuberDinner.Domain.Menu;
namespace BuberDinner.Application.CreateMenu
{
    public record CreateMenuCommand
    (
        string HostId,
        string Name,
        string Description,
        List<MenuSectionCommand> Sections
    ) : IRequest<ErrorOr<Menu>>;
    public record MenuSectionCommand(
        string Name,
        string Description,
        List<MenuItemCommand> Items
    );
    public record MenuItemCommand(
        string Name,
        string Description
    );
}
