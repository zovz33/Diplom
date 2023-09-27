using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrimeTableware.ASPNET.API.Controllers.Base;
using PrimeTableware.ASPNET.API.Models;
using PrimeTableware.ASPNET.Application.Items.User.Commands;
using PrimeTableware.ASPNET.Application.Items.User.Commands.DeleteUser;
using PrimeTableware.ASPNET.Application.Items.User.Queries.GetUserById;
using PrimeTableware.ASPNET.Application.Lists.Queries.GetUserList;

namespace PrimeTableware.ASPNET.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        public UserController(IMapper mapper) => _mapper = mapper;
        [HttpGet("List")]
        public async Task<ActionResult<UserListQueryResult>> GetAll()
        {
            var query = new GetUserListQuery
            {
                Id = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserByIdQueryResult>> Get(int id)
        {
            var query = new GetUserByIdQuery
            {
                Id = id,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Created([FromBody] CreateUserDto createUserDto)
        {
            var command = _mapper.Map<CreateUserCommand>(createUserDto);
            command.UserName = createUserDto.UserName;
            var userId = await Mediator.Send(command);
            return Ok(userId);
        }

        // -------------------- Update

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto updateUserDto)
        {
            var command = _mapper.Map<UpdateUserCommand>(updateUserDto);
            command.Id = updateUserDto.Id;
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
