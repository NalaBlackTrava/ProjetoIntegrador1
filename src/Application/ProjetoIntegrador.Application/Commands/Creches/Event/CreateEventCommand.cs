using ProjetoIntegrador.Domain.Entity.Creches;

namespace ProjetoIntegrador.Application.Commands.Creches.Event
{
    public class CreateEventCommand : IRequest<EventEntity>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateOnly Date { get; set; }
        public required string Image { get; set; }
        public long CrecheId { get; set; }
    }
}