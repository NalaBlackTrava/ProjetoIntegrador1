using ProjetoIntegrador.Domain.Entity.Creches;

namespace ProjetoIntegrador.Application.Commands.Creches.Event
{
    public class ReadEventCommand : IRequest<EventEntity>
    {
        public long Id { get; set; }
    }
}