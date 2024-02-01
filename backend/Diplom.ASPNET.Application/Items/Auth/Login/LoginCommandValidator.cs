using FluentValidation;

namespace Diplom.ASPNET.Application.Items.Auth.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        // RuleFor(createUserCommand =>
        //    createUserCommand.Email).NotEmpty().Length(2, 20).EmailAddress();
        RuleFor(r =>
            r.UserName).NotEmpty().Length(2, 25);
        RuleFor(r =>
            r.Password).NotEmpty().Length(2, 20);
    }
}