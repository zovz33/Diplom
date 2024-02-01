using Diplom.ASPNET.Application.Common.Exceptions;
using Diplom.ASPNET.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Diplom.ASPNET.Application.Items.Product.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateProductCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Products.FirstOrDefaultAsync(Product => Product.Id == request.Id, cancellationToken);
        if (entity == null) throw new NotFoundException(nameof(Product), request.Id);

        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.Price = request.Price; 
        entity.Quantity = request.Quantity;
        entity.Category = request.Category;
        entity.ImageUrl = request.ImageUrl;
        entity.UpdatedDateTime = DateTime.UtcNow;
        
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}