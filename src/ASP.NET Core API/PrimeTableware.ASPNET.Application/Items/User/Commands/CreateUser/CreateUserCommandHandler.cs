﻿using MediatR;
using PrimeTableware.ASPNET.Application.Interfaces;

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
                RoleId = request.RoleId,
                MobilePhone = request.MobilePhone,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                Gender = request.Gender,
                Address = request.Address,
                HomePhone = request.HomePhone,
                DateOfBirth = request.DateOfBirth,
                ProfileImage = request.ProfileImage,
      //        CreatedBy = ,
                CreatedDateTime = DateTime.UtcNow,
                UpdatedDateTime = null,
            };

            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}