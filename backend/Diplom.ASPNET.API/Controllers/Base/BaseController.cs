using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Security.Claims;

namespace Diplom.ASPNET.API.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        internal int Id => !User.Identity.IsAuthenticated
            ? 0 : int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
