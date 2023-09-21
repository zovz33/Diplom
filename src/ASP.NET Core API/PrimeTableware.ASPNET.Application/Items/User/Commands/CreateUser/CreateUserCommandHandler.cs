using MediatR;
using PrimeTableware.ASPNET.Application.Interfaces;
using PrimeTableware.ASPNET.Domain.Entities;

namespace PrimeTableware.ASPNET.Application.Items.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateUserCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new Domain.Entities.User
            {
                UserName = request.UserName,
                PasswordHash = request.PasswordHash,
                Email = request.Email,
                RoleId = 1,
                CreatedDateTime = DateTime.UtcNow,
                UpdatedDateTime = null,
            };

            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}