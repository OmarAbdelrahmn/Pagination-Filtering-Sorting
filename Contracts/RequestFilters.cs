
namespace Pagination_Filtering_Sorting.Contracts;
public record RequestFilters
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;

    public string? SearchValue { get; init; } = string.Empty;
    public string? SortColumn { get; init; } = string.Empty;
    public string? SortDirestion { get; init; } = "ASC";


}
