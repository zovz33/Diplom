using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Diplom.ASPNET.Application.Items.Product.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<Unit>
{
    [Required] public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public string Category { get; set; } 
    public string ImageUrl { get; set; }
}