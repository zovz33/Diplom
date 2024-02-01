using Diplom.ASPNET.Application.Common.Exceptions;
using Diplom.ASPNET.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Diplom.ASPNET.Application.Items.Auth.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseResult>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly SignInManager<Domain.Entities.Identity.User> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly UserManager<Domain.Entities.Identity.User> _userManager;

    public LoginCommandHandler(UserManager<Domain.Entities.Identity.User> userManager,
        SignInManager<Domain.Entities.Identity.User> signInManager,
        IApplicationDbContext dbContext, ITokenService tokenService)
    {
        _signInManager = signInManager;
        _tokenService = tokenService;
        _userManager = userManager;
        _dbContext = dbContext;
    }

    public async Task<LoginResponseResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        // Получаем пользователя из базы данных
        var user = await _userManager.FindByNameAsync(request.UserName);
        // var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == request.UserName);
        // Проверяем, существует ли пользователь
        if (user == null) 
            throw new UserNotFoundException(request.UserName);

        // Проверяем пароль
        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!result.Succeeded)
            throw new InvalidPasswordException(request.UserName);


        // Проверяем, подтвержден ли email
        // if (user.EmailConfirmed == false)
        // {
        //     throw new NotFoundException(nameof(User), "Почта не подтверждена");
        // }

        // Возвращаем результат
        return new LoginResponseResult
        {
            UserName = user.UserName,
            Email = user.Email,
            JWT = await _tokenService.CreateJWT(user)
        };
    }
}

// Пользователь аутентифицирован? генерация токена:
//var roleNames = await _userManager.GetRolesAsync(user);
//var roles = roleNames.Select(roleName => new Role { Name = roleName }).ToList();

//var accessToken = _tokenService.CreateToken(user, roles);

//user.RefreshToken = _tokenService.RefreshToken();
//user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7); // Время обновления токена