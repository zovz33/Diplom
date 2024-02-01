using AutoMapper;
using Diplom.ASPNET.Application.Common.Exceptions;
using Diplom.ASPNET.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Diplom.ASPNET.Application.Items.Product.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResult>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IApplicationDbContext dbContext,
        IMapper mapper)
    {
        (_dbContext, _mapper) = (dbContext, mapper);
    }

    public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Products
            .FirstOrDefaultAsync(Product =>
                Product.Id == request.Id, cancellationToken);
        if (entity == null || entity.Id != request.Id) throw new NotFoundException(nameof(Product), request.Id);
        return _mapper.Map<GetProductByIdQueryResult>(entity);
    }
}