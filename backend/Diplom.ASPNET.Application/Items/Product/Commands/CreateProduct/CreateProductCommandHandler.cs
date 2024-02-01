using Diplom.ASPNET.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Diplom.ASPNET.Application.Items.Product.Commands.CreateProduct;

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateProductCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (await _dbContext.Products.AnyAsync(p => p.Name == request.Name, cancellationToken))
            {
                throw new Exception("Имя продукта не уникально.");
            }
            var entity = new Domain.Entities.Product
            {
                Name = request.Name,
                Description = request.Description, 
                Price = request.Price,
                Quantity = request.Quantity,
                Category = request.Category,
                ImageUrl = request.ImageUrl,
                //CreatedBy = ,
                CreatedDateTime = DateTime.UtcNow,
                UpdatedDateTime = null
            }; 

            await _dbContext.Products.AddAsync(entity, cancellationToken);
            var saveChangesResult = await _dbContext.SaveChangesAsync(cancellationToken);

            if (saveChangesResult <= 0)
            { 
                throw new Exception("Product creation failed: Unable to save changes.");
            }
            return entity.Id;
        }
    }