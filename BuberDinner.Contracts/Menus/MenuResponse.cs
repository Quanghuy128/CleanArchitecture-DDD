namespace BuberDinner.Contracts.Menus
{
    public record MenuResponse
    (
        Guid Id,
        string Name,
        string Description,
        float? AverageRating,
        string HostId,
        List<string> DinnerIds,
        List<string> MenuReviewIds,
        List<MenuSectionResponse> Sections
    );
    public record MenuSectionResponse(
        Guid Id,
        string Name,
        string Description,
        List<MenuItemResponse> Items
    );
    public record MenuItemResponse(
        string Id,
        string Name,
        string Description
    );
}
