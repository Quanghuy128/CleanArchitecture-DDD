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
        Guid Id,
        string Name,
        string Description,
        List<MenuItem> Items
    );
    public record MenuItem(
        Guid Id,
        string Name,
        string Description
    );
}
