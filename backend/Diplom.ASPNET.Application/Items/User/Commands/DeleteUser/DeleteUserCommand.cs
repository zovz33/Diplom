using MediatR;

namespace Diplom.ASPNET.Application.Items.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public int Id { get; set; } // удаление по Id
    }
}
