using MediatR;
using System;


namespace PrimeTableware.ASPNET.Application.Lists.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<UserListQueryResult>
    {
        public int Id { get; set; }
    }
}
