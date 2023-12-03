using FluentValidation;


namespace Diplom.ASPNET.Application.Items.User.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {

            RuleFor(updateUserCommand =>
               updateUserCommand.Email).NotEmpty().Length(2, 20).EmailAddress();
            RuleFor(updateUserCommand =>
               updateUserCommand.UserName).NotEmpty().Length(2, 20);
            RuleFor(updateUserCommand =>
               updateUserCommand.PasswordHash).NotEmpty().Length(2, 20);
            RuleFor(updateUserCommand =>
               updateUserCommand.Gender).MaximumLength(1);
            RuleFor(updateUserCommand =>
               updateUserCommand.RoleId).NotEmpty();
            RuleFor(updateUserCommand =>
               updateUserCommand.PhoneNumber).Length(7, 20);
            RuleFor(updateUserCommand =>
               updateUserCommand.FirstName).Length(2, 20);
            RuleFor(updateUserCommand =>
               updateUserCommand.MiddleName).Length(2, 20);
            RuleFor(updateUserCommand =>
               updateUserCommand.LastName).Length(2, 20);
            RuleFor(updateUserCommand =>
               updateUserCommand.Address).Length(0, 30); 
            RuleFor(updateUserCommand =>
               updateUserCommand.DateOfBirth).LessThan(DateTime.Now);
            RuleFor(updateUserCommand =>
               updateUserCommand.ProfileImage).Length(0, 200);
        }
    }
}
