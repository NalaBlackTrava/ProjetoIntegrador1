// CrechesController.cs
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ProjetoIntegrador.Application.Commands.Creches;
using System.Threading.Tasks;
using ProjetoIntegrador.Application.Commands.Creches.Address;

namespace ProjetoIntegrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrechesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CrechesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCrecheCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCrecheCommand command)
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
            var result = await _mediator.Send(new ReadCrecheCommand { Id = id });
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCrecheCommand { Id = id });
            return Ok(result);
        }

        [HttpPost("address")]
        public async Task<IActionResult> Add(CrecheAddAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{crecheId}/address/{addressId}")]
        public async Task<IActionResult> Remove(long crecheId, long addressId)
        {
            var result = await _mediator.Send(new CrecheRemoveAddressCommand { AddressId = addressId, CrecheId = crecheId });
            return Ok(result);
        }
    }
}