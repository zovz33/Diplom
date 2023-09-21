using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTableware.ASPNET.Application.Items.User.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserVm>
    {
        public int Id { get; set; }
    }
}
