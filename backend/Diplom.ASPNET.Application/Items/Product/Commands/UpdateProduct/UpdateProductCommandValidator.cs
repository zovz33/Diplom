using FluentValidation;

namespace Diplom.ASPNET.Application.Items.Product.Commands.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(updateProductCommand => updateProductCommand.Id)
            .NotEmpty().GreaterThan(0);

        RuleFor(updateProductCommand => updateProductCommand.Name)
            .NotEmpty().Length(2, 50);

        RuleFor(updateProductCommand => updateProductCommand.Description)
            .NotEmpty().Length(2, 200);

        RuleFor(updateProductCommand => updateProductCommand.Price)
            .NotEmpty().GreaterThan(0);

        RuleFor(updateProductCommand => updateProductCommand.Quantity)
            .NotEmpty().GreaterThan(0);

        RuleFor(updateProductCommand => updateProductCommand.Category)
            .NotEmpty().Length(2, 50);

        RuleFor(updateProductCommand => updateProductCommand.ImageUrl)
            .Length(0, 200);
    }
}