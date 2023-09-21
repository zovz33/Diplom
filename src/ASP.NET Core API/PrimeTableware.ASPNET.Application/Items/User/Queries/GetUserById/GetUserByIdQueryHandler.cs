using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PrimeTableware.ASPNET.Application.Common.Exceptions;
using PrimeTableware.ASPNET.Application.Interfaces;

namespace PrimeTableware.ASPNET.Application.Items.User.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResult>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetUserByIdQueryHandler(IApplicationDbContext dbContext, 
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
 
        public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users
                .FirstOrDefaultAsync(user => 
                user.Id == request.Id, cancellationToken);
            if (entity == null || entity.Id != request.Id) 
            { 
                throw new NotFoundException(nameof(User), request.Id);
            }
            return _mapper.Map<GetUserByIdQueryResult>(entity);
        }
    }
}
