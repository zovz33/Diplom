using FluentValidation;

namespace Diplom.ASPNET.Application.Items.User.Queries.GetUserById
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator() 
        {
            RuleFor(user => 
                user.Id).NotEmpty();
        }
    }
}
