using FluentValidation;
using System;


namespace PrimeTableware.ASPNET.Application.Items.User.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(createUserCommand =>
               createUserCommand.Email).NotEmpty();
            RuleFor(createUserCommand =>
               createUserCommand.UserName).NotEmpty().MaximumLength(20);
        }
    }
}
