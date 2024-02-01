using Diplom.ASPNET.Application.Common.Exceptions;
using Diplom.ASPNET.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Diplom.ASPNET.Application.Items.Auth.Registartion;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, int>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly SignInManager<Domain.Entities.Identity.User> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly UserManager<Domain.Entities.Identity.User> _userManager;

    public RegisterCommandHandler(UserManager<Domain.Entities.Identity.User> userManager,
        SignInManager<Domain.Entities.Identity.User> signInManager,
        IApplicationDbContext dbContext, ITokenService tokenService)
    {
        _signInManager = signInManager;
        _tokenService = tokenService;
        _userManager = userManager;
        _dbContext = dbContext;
    }

    public async Task<int> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _userManager.Users.AnyAsync(x => x.Email == request.Email.ToLower()))
            throw new CustomException($"Пользователь с почтой {request.Email} уже зарегистрирован");
        if (await _userManager.Users.AnyAsync(x => x.UserName == request.UserName.ToLower()))
            throw new CustomException($"Пользователь {request.UserName} уже зарегистрирован");

        var user = new Domain.Entities.Identity.User
        {
            UserName = request.Email.ToLower(),
            Email = request.Email.ToLower(),
            // FirstName = string.Empty,
            // LastName = string.Empty,
            EmailConfirmed = true
        };
        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            throw new CustomException($"Ошибка при регистрации пользователя {request.UserName}");

        // Добавление роли
        // await _userManager.AddToRoleAsync(userToAdd, SD.Role);

        return user.Id;
    }
    // private async Task<bool> CheckEmailExistsAsync(string email)
    // {
    //     return await _userManager.Users.AnyAsync(x => x.Email == email.ToLower());
    // }
}