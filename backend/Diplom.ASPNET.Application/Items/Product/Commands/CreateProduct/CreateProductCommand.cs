using MediatR;

namespace Diplom.ASPNET.Application.Items.Product.Commands.CreateProduct;

public class CreateProductCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public string Category { get; set; } 
    public string ImageUrl { get; set; }
}