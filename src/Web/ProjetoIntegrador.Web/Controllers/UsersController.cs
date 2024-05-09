using Microsoft.AspNetCore.Mvc;
using MediatR;
using ProjetoIntegrador.Application.Commands.User;
using ProjetoIntegrador.Application.Commands.User.Address;
using ProjetoIntegrador.Application.Commands.User.Event;
using ProjetoIntegrador.Application.Commands.Creches.Administrator;

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
        public async Task<IActionResult> Add(UserAddAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{userId}/address/{addressId}")]
        public async Task<IActionResult> Remove(long userId, long addressId)
        {
            var result = await _mediator.Send(new UserRemoveAddressCommand { AddressId = addressId, UserId = userId });
            return Ok(result);
        }

        [HttpPost("{userId}/events/{eventId}")]
        public async Task<IActionResult> AddEvent(long userId, long eventId)
        {
            var result = await _mediator.Send(new AddEventCommand { UserId = userId, EventId = eventId });
            return Ok(result);
        }

        [HttpDelete("{userId}/events/{eventId}")]
        public async Task<IActionResult> RemoveEvent(long userId, long eventId)
        {
            var result = await _mediator.Send(new RemoveEventCommand { UserId = userId, EventId = eventId });
            return Ok(result);
        }

        [HttpPost("{userId}/creches/{crecheId}/admins")]
        public async Task<IActionResult> AddAdmin(long userId, long crecheId)
        {
            var result = await _mediator.Send(new AddAdminCommand { UserId = userId, CrecheId = crecheId });
            return Ok(result);
        }

        [HttpDelete("{userId}/creches/{crecheId}/admins")]
        public async Task<IActionResult> RemoveAdmin(long userId, long crecheId)
        {
            var result = await _mediator.Send(new RemoveAdminCommand { UserId = userId, CrecheId = crecheId });
            return Ok(result);
        }
    }
}