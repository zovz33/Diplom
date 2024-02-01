using MediatR;

namespace Diplom.ASPNET.Application.Lists.Queries.GetProductList;

public class GetProductListQuery : IRequest<GetProductListQueryResult>
{
    // ДЛЯ ФИЛЬТРАЦИИ ДАННЫХ
    //public int PageNumber { get; set; }
    //public int PageSize { get; set; }
    //public string SortBy { get; set; } ??
    //public SortOrder SortOrder { get; set; } ??
    //public int? RoleId { get; set; }
    //public string? ProductName { get; set; }
}