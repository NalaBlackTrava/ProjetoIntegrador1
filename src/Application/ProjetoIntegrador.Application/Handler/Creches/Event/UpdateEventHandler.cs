using ProjetoIntegrador.Application.Commands.Creches.Event;
using ProjetoIntegrador.Domain.Entity.Creches;

namespace ProjetoIntegrador.Application.Handler.Creches.Event
{
    public class UpdateEventHandler : IRequestHandler<UpdateEventCommand, EventEntity>
    {
        private readonly IRepository<EventEntity> _eventRepository;

        public UpdateEventHandler(IRepository<EventEntity> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<EventEntity> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventEntity = await _eventRepository.FindAsync(request.Id);

            if (eventEntity == null)
            {
                throw new KeyNotFoundException("Event not found");
            }

            eventEntity.Name = request.Name;
            eventEntity.Description = request.Description;
            eventEntity.Date = request.Date;
            eventEntity.Image = request.Image;

            await _eventRepository.UpdateAsync(eventEntity);
            return eventEntity;
        }
    }
}