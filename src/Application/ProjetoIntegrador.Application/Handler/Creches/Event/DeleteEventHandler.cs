using ProjetoIntegrador.Application.Commands.Creches.Event;
using ProjetoIntegrador.Domain.Entity.Creches;

namespace ProjetoIntegrador.Application.Handler.Creches.Event
{
    public class DeleteEventHandler : IRequestHandler<DeleteEventCommand, bool>
    {
        private readonly IRepository<EventEntity> _eventRepository;

        public DeleteEventHandler(IRepository<EventEntity> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<bool> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var eventEntity = await _eventRepository.FindAsync(request.Id);

            if (eventEntity == null)
            {
                throw new KeyNotFoundException("Event not found");
            }

            _eventRepository.Remove(eventEntity);
            await _eventRepository.SaveChangesAsync();
            return true;
        }
    }
}