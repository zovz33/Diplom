using Diplom.ASPNET.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Diplom.ASPNET.Application.Items.AppUser.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly UserManager<Domain.Entities.Identity.User> _userManager;

    public CreateUserCommandHandler(IApplicationDbContext dbContext,
        UserManager<Domain.Entities.Identity.User> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new Domain.Entities.Identity.User
        {
            UserName = request.UserName,
            Email = request.Email,
            //RoleId = request.RoleId,
            PhoneNumber = request.PhoneNumber,
            FirstName = request.FirstName,
            MiddleName = request.MiddleName,
            LastName = request.LastName,
            Gender = request.Gender,
            Address = request.Address,
            DateOfBirth = request.DateOfBirth,
            ProfileImage = request.ProfileImage,
            //CreatedBy = ,
            CreatedDateTime = DateTime.UtcNow,
            UpdatedDateTime = null
        };
        var result = await _userManager.CreateAsync(user, request.PasswordHash);
        if (!result.Succeeded)
            throw new Exception($"User creation failed: {string.Join(", ", result.Errors.Select(e => e.Description))}");

        return user.Id;
    }
}