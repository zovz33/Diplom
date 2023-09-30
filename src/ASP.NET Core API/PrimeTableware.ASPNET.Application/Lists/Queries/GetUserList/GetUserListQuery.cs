using MediatR;


namespace PrimeTableware.ASPNET.Application.Lists.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<GetUserListQueryResult>
    {
        public int Id { get; set; }
    }
}
