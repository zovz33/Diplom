using FluentValidation;


namespace PrimeTableware.ASPNET.Application.Items.User.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(deleteUserCommand =>
                deleteUserCommand.Id).NotEmpty().GreaterThan(0);
        }
    }
}
