using FluentValidation;

namespace Diplom.ASPNET.Application.Items.Product.Queries.GetProductById;

public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdQueryValidator()
    {
        RuleFor(Product =>
            Product.Id).NotEmpty();
    }
}