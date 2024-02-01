using MediatR;

namespace Diplom.ASPNET.Application.Items.Product.Queries.GetProductById;

public class GetProductByIdQuery : IRequest<GetProductByIdQueryResult>
{
    public int Id { get; set; }
}