using System.Security.Claims;
using Diplom.ASPNET.Application.Common.Exceptions;
using Diplom.ASPNET.Application.Interfaces;
using Diplom.ASPNET.Application.Items.Auth.Login;
using Diplom.ASPNET.Application.Items.Auth.Registartion;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diplom.ASPNET.Application.Items.Auth.RefreshToken;

public class RefreshCommandHandler : IRequestHandler<RefreshCommand, RefreshResponseResult>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly SignInManager<Domain.Entities.Identity.User> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly UserManager<Domain.Entities.Identity.User> _userManager;

    public RefreshCommandHandler(UserManager<Domain.Entities.Identity.User> userManager,
        SignInManager<Domain.Entities.Identity.User> signInManager,
        IApplicationDbContext dbContext, ITokenService tokenService)
    {
        _signInManager = signInManager;
        _tokenService = tokenService;
        _userManager = userManager;
        _dbContext = dbContext;
    }

    public async Task<RefreshResponseResult> Handle(RefreshCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        
        if (await _userManager.IsLockedOutAsync(user))
        {
            throw new UnauthorizedAccessException("You have been locked out");
        }

        return new RefreshResponseResult
        {
            UserName = user.UserName,
            Email = user.Email,
            JWT = await _tokenService.CreateJWT(user)
        };
    }
}