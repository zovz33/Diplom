using FluentValidation;


namespace PrimeTableware.ASPNET.Application.Items.Auth.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
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
