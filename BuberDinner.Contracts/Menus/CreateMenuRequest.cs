namespace BuberDinner.Contracts.Menus
{
    public record CreateMenuRequest
    (
        string Name,
        string Description,
        List<MenuSection> Sections,
        string HostId,
        List<string> DinnerIds,
        List<string> MenuReviews,
        DateTime CreateDateTime,
        DateTime UpdateDateTime
    );
    public record MenuSection(
        string Name,
        string Description,
        List<MenuItem> Items
    );
    public record MenuItem(
        string Name,
        string Description
    );
}
