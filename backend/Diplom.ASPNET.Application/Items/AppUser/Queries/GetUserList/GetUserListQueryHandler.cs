using AutoMapper;
using AutoMapper.QueryableExtensions;
using Diplom.ASPNET.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Diplom.ASPNET.Application.Lists.Queries.GetUserList;

public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, GetUserListQueryResult>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUserListQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetUserListQueryResult> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        // var userQuery = await _dbContext.Users
        //.Where(user => user.Id == request.Id)
        //.ProjectTo<UserLookupDto>(_mapper.ConfigurationProvider)
        //.ToListAsync(cancellationToken);

        var userQuery = await _dbContext.Users
            .ProjectTo<UserLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new GetUserListQueryResult { Users = userQuery };
    }
}