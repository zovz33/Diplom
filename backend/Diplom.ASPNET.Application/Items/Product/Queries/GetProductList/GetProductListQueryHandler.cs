using AutoMapper;
using AutoMapper.QueryableExtensions;
using Diplom.ASPNET.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Diplom.ASPNET.Application.Lists.Queries.GetProductList;

public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, GetProductListQueryResult>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetProductListQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetProductListQueryResult> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        // var ProductQuery = await _dbContext.Products
        //.Where(Product => Product.Id == request.Id)
        //.ProjectTo<ProductLookupDto>(_mapper.ConfigurationProvider)
        //.ToListAsync(cancellationToken);

        var ProductQuery = await _dbContext.Products
            .ProjectTo<ProductLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new GetProductListQueryResult { Products = ProductQuery };
    }
}