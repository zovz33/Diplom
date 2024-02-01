using AutoMapper;
using Diplom.ASPNET.API.Controllers.Base;
using Diplom.ASPNET.API.Models;
using Diplom.ASPNET.Application.Items.AppUser.Commands.CreateUser;
using Diplom.ASPNET.Application.Items.User.Commands.DeleteUser;
using Diplom.ASPNET.Application.Items.User.Commands.UpdateUser;
using Diplom.ASPNET.Application.Items.User.Queries.GetUserById;
using Diplom.ASPNET.Application.Lists.Queries.GetUserList;
using Microsoft.AspNetCore.Mvc;

namespace Diplom.ASPNET.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : BaseController
{
    private readonly IMapper _mapper;

    public UsersController(IMapper mapper)
    {
        _mapper = mapper;
    }
    // -------------------- Create

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateUserDto request)
    {
        var command = _mapper.Map<CreateUserCommand>(request);
        command.UserName = request.UserName;
        var userId = await Mediator.Send(command);
        return Ok(userId);
    }

    // -------------------- Update

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDto request)
    {
        var command = _mapper.Map<UpdateUserCommand>(request);
        command.Id = id;
        await Mediator.Send(command);
        return NoContent();
    }

    //[HttpPatch("{id}")]
    //public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<UpdateUserDto> patchDoc)
    //{
    //    if (patchDoc == null)
    //    {
    //        return BadRequest();
    //    }

    //    // Получить текущий GetUserByIdQueryResult
    //    var query = new GetUserByIdQuery
    //    {
    //        Id = id,
    //    };
    //    var result = await Mediator.Send(query);

    //    if (result == null)
    //    {
    //        throw new NotFoundException(nameof(User), id);
    //    }

    //    // Преобразовать GetUserByIdQueryResult в UpdateUserDto
    //    var request = _mapper.Map<UpdateUserDto>(result);

    //    // Применить patchDoc к request
    //    patchDoc.ApplyTo(request);

    //    // Сопоставить UpdateUserDto с UpdateUserCommand
    //    var command = _mapper.Map<UpdateUserCommand>(request);
    //    command.Id = id;

    //    await Mediator.Send(command);

    //    return NoContent();
    //}


    // -------------------- Delete

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteUserCommand
        {
            Id = id
        };
        await Mediator.Send(command);
        return NoContent();
    }

    // -------------------- Query

    [HttpGet("List")]
    public async Task<ActionResult<GetUserListQueryResult>> GetAll()
    {
        var query = new GetUserListQuery();
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetUserByIdQueryResult>> GetById(int id)
    {
        var query = new GetUserByIdQuery
        {
            Id = id
        };
        var result = await Mediator.Send(query);
        return Ok(result);
    }
}