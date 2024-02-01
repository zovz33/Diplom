using MediatR;

namespace Diplom.ASPNET.Application.Items.Product.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<Unit>
{
    public int Id { get; set; } // удаление по Id
}