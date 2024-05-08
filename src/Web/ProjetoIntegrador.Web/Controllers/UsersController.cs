using Microsoft.AspNetCore.Mvc;
using MediatR;
using ProjetoIntegrador.Application.Commands.User;
using ProjetoIntegrador.Application.Commands.User.Address;

namespace ProjetoIntegrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Read(int id)
        {
            var result = await _mediator.Send(new ReadUserCommand { Id = id });
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand { Id = id });
            return Ok(result);
        }

        [HttpPost("address")]
        public async Task<IActionResult> Add(AddAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{userId}/address/{addressId}")]
        public async Task<IActionResult> Remove(long userId, long addressId)
        {
            var result = await _mediator.Send(new RemoveAddressCommand { AddressId = addressId, UserId = userId });
            return Ok(result);
        }
    }
}