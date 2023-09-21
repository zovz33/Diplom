﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PrimeTableware.ASPNET.Application.Interfaces;


namespace PrimeTableware.ASPNET.Application.Lists.Queries.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListQueryResult>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetUserListQueryHandler(IApplicationDbContext dbContext,
            IMapper mapper) => 
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UserListQueryResult> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var userQuery = await _dbContext.Users
                .Where(user => user.Id == request.Id)
                .ProjectTo<UserLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new UserListQueryResult { Users = userQuery };
        }
    }
}
