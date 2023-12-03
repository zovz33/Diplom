using MediatR;


namespace PrimeTableware.ASPNET.Application.Lists.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<GetUserListQueryResult>
    {
        // ДЛЯ ФИЛЬТРАЦИИ ДАННЫХ
        //public int PageNumber { get; set; }
        //public int PageSize { get; set; }
        //public string SortBy { get; set; } ??
        //public SortOrder SortOrder { get; set; } ??
        //public int? RoleId { get; set; }
        //public string? UserName { get; set; }
    }
}
