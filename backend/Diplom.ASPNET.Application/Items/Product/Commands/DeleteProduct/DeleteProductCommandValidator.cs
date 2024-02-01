using FluentValidation;

namespace Diplom.ASPNET.Application.Items.Product.Commands.DeleteProduct;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(deleteProductCommand => deleteProductCommand.Id)
            .NotEmpty().GreaterThan(0);
    }
}