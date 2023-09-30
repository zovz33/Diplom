using FluentValidation;


namespace PrimeTableware.ASPNET.Application.Items.User.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(createUserCommand =>
               createUserCommand.Email).NotEmpty().Length(2, 20).EmailAddress();
            RuleFor(createUserCommand =>
               createUserCommand.UserName).NotEmpty().Length(2, 20);
            RuleFor(createUserCommand =>
               createUserCommand.PasswordHash).NotEmpty().Length(2, 20).Equal(createUserCommand => createUserCommand.ConfirmPasswordHash);
        }
    }
}
