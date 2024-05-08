using ProjetoIntegrador.Domain.Entity.Creches;

namespace ProjetoIntegrador.Application.Commands.Creches.Event
{
    public class UpdateEventCommand : IRequest<EventEntity>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly Date { get; set; }
        public string Image { get; set; }
    }
}