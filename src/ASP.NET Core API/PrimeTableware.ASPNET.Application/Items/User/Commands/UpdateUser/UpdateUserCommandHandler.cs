using MediatR;
using Microsoft.EntityFrameworkCore;
using PrimeTableware.ASPNET.Application.Common.Exceptions;
using PrimeTableware.ASPNET.Application.Interfaces;

namespace PrimeTableware.ASPNET.Application.Items.User.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateUserCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            entity.UserName = request.UserName;
            entity.PasswordHash = request.PasswordHash;
            entity.Email = request.Email;
            entity.RoleId = request.RoleId;
            entity.MobilePhone = request.MobilePhone;
            entity.FirstName = request.FirstName;
            entity.MiddleName = request.MiddleName;
            entity.LastName = request.LastName;
            entity.Gender = request.Gender;
            entity.Address = request.Address;
            entity.HomePhone = request.HomePhone;
            entity.DateOfBirth = request.DateOfBirth;
            entity.ProfileImage = request.ProfileImage;
            entity.UpdatedDateTime = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
