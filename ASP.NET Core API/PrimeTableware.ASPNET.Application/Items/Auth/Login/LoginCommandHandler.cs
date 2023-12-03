using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PrimeTableware.ASPNET.Application.Common.Exceptions;
using PrimeTableware.ASPNET.Application.Interfaces;
using PrimeTableware.ASPNET.Application.Items.Auth.Login;
using PrimeTableware.ASPNET.Domain.Entities.Identity;

namespace PrimeTableware.ASPNET.Application.Items.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseResult>
    {
        private readonly UserManager<Domain.Entities.Identity.User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IApplicationDbContext _dbContext;

        public LoginCommandHandler(UserManager<Domain.Entities.Identity.User> userManager,
            IApplicationDbContext dbContext, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _dbContext = dbContext;
        }

        public async Task<LoginResponseResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.Email);
            }

            if (!await _userManager.CheckPasswordAsync(user, request.PasswordHash))
            {
                throw new InvalidPasswordException(nameof(Domain.Entities.Identity.User), request.PasswordHash);
            }

            // Пользователь аутентифицирован? генерация токена:
            var roleNames = await _userManager.GetRolesAsync(user);
            var roles = roleNames.Select(roleName => new Role { Name = roleName }).ToList();

            var accessToken = _tokenService.CreateToken(user, roles);

            //user.RefreshToken = _tokenService.RefreshToken();
            //user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7); // Время обновления токена

            await _userManager.UpdateAsync(user);

            return new LoginResponseResult
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = accessToken,
                //RefreshToken = user.RefreshToken
            };
        }
    }
}