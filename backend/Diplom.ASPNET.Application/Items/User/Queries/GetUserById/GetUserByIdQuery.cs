using MediatR;

namespace Diplom.ASPNET.Application.Items.User.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<GetUserByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
