// CreateEventHandler.cs
using ProjetoIntegrador.Application.Commands.Creches.Event;
using ProjetoIntegrador.Domain.Entity.Creches;

public class CreateEventHandler : IRequestHandler<CreateEventCommand, EventEntity>
{
    private readonly IRepository<EventEntity> _eventRepository;

    public CreateEventHandler(IRepository<EventEntity> eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<EventEntity> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var eventEntity = new EventEntity
        {
            Name = request.Name,
            Description = request.Description,
            Date = request.Date,
            Image = request.Image,
            CrecheId = request.CrecheId
        };

        await _eventRepository.UpsetAsync(eventEntity);
        return eventEntity;
    }
}
