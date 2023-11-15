using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimeTableware.ASPNET.API.Controllers.Base;
using PrimeTableware.ASPNET.API.Models;
using PrimeTableware.ASPNET.Application.Common.Exceptions;
using PrimeTableware.ASPNET.Application.Items.User.Commands.CreateUser;
using PrimeTableware.ASPNET.Application.Items.User.Commands.DeleteUser;
using PrimeTableware.ASPNET.Application.Items.User.Commands.UpdateUser;
using PrimeTableware.ASPNET.Application.Items.User.Queries.GetUserById;
using PrimeTableware.ASPNET.Application.Lists.Queries.GetUserList;

namespace PrimeTableware.ASPNET.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        public UserController(IMapper mapper) => _mapper = mapper;

        // -------------------- Create

        [HttpPost]
        public async Task<ActionResult<int>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
           var command = _mapper.Map<CreateUserCommand>(createUserDto);
           command.UserName = createUserDto.UserName;
           var userId = await Mediator.Send(command);
           return Ok(userId);
        }

        // -------------------- Update

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
        {
            var command = _mapper.Map<UpdateUserCommand>(updateUserDto);
            command.Id = id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUser(int id, [FromBody] JsonPatchDocument<UpdateUserDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            // Получить текущий GetUserByIdQueryResult
            var query = new GetUserByIdQuery
            {
                Id = id,
            }; 
            var result = await Mediator.Send(query);

            if (result == null)
            {
                throw new NotFoundException(nameof(User), id);
            }

            // Преобразовать GetUserByIdQueryResult в UpdateUserDto
            var updateUserDto = _mapper.Map<UpdateUserDto>(result);

            // Применить patchDoc к updateUserDto
            patchDoc.ApplyTo(updateUserDto);

            // Сопоставить UpdateUserDto с UpdateUserCommand
            var command = _mapper.Map<UpdateUserCommand>(updateUserDto);
            command.Id = id;

            await Mediator.Send(command);

            return NoContent();
        }


        // -------------------- Delete

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var command = new DeleteUserCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }

        // -------------------- Query

        [HttpGet("List")]
        public async Task<ActionResult<GetUserListQueryResult>> GetAllUsers()
        {
            var query = new GetUserListQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserByIdQueryResult>> GetUserById(int id)
        {
            var query = new GetUserByIdQuery
            {
                Id = id,
            };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

    }
}
