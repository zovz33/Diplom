using FluentValidation;


namespace Diplom.ASPNET.Application.Items.User.Commands.CreateUser
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
               createUserCommand.PasswordHash).NotEmpty().Length(2, 20);
            RuleFor(createUserCommand =>
               createUserCommand.Gender).MaximumLength(1);
            RuleFor(createUserCommand =>
               createUserCommand.RoleId).NotEmpty();
            RuleFor(createUserCommand =>
               createUserCommand.PhoneNumber).Length(7, 20);
            RuleFor(createUserCommand =>
               createUserCommand.FirstName).Length(2, 20);
            RuleFor(createUserCommand =>
               createUserCommand.MiddleName).Length(2, 20);
            RuleFor(createUserCommand =>
               createUserCommand.LastName).Length(2, 20);
            RuleFor(createUserCommand =>
               createUserCommand.Address).Length(0, 30);
            RuleFor(createUserCommand =>
               createUserCommand.DateOfBirth).LessThan(DateTime.Now);
            RuleFor(createUserCommand =>
               createUserCommand.ProfileImage).Length(0, 200);

        }
    }
}
