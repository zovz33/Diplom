using FluentValidation;


namespace PrimeTableware.ASPNET.Application.Lists.Queries.GetUserList
{
    public class GetUserListQueryValidator : AbstractValidator<GetUserListQuery>
    {
        public GetUserListQueryValidator()
        {
            RuleFor(x =>
                    x.Id).NotEmpty();
        }
    }
}
