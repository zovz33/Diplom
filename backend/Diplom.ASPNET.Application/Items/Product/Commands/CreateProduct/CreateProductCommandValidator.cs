using FluentValidation;

namespace Diplom.ASPNET.Application.Items.Product.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
 
        
        RuleFor(createProductCommand => createProductCommand.Name)
            .NotEmpty().Length(2, 50);
        RuleFor(createProductCommand => createProductCommand.Description)
            .Length(2, 200);
        RuleFor(createProductCommand => createProductCommand.Price)
            .NotEmpty().GreaterThan(0);
        RuleFor(createProductCommand => createProductCommand.Quantity)
            .NotEmpty().GreaterThan(0);
        RuleFor(createProductCommand => createProductCommand.Category)
            .NotEmpty().Length(2, 50);
        RuleFor(createProductCommand => createProductCommand.ImageUrl)
            .Length(0, 200);

    }
}