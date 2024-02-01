using FluentValidation;

namespace Diplom.ASPNET.Application.Items.Auth.Registartion;

public class LoginCommandValidator : AbstractValidator<RegisterCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(createUserCommand =>
            createUserCommand.Email).NotEmpty().Length(2, 25).EmailAddress();
        RuleFor(createUserCommand =>
            createUserCommand.UserName).NotEmpty().Length(2, 25);
        RuleFor(createUserCommand =>
                createUserCommand.Password).NotEmpty().Length(2, 20)
            .Equal(createUserCommand => createUserCommand.ConfirmPassword);
    }
}