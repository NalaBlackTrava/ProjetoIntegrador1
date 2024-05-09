using ProjetoIntegrador.Application.Commands.Creches.Event;
using ProjetoIntegrador.Domain.Entity.Creches;

namespace ProjetoIntegrador.Application.Handler.Creches.Event
{
    public class ReadEventHandler : IRequestHandler<ReadEventCommand, EventEntity>
    {
        private readonly IRepository<EventEntity> _eventRepository;

        public ReadEventHandler(IRepository<EventEntity> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<EventEntity> Handle(ReadEventCommand request, CancellationToken cancellationToken)
        {
            var eventEntity = await _eventRepository.FindAsync(request.Id);

            if (eventEntity == null)
            {
                throw new KeyNotFoundException("Event not found");
            }

            return eventEntity;
        }
    }
}