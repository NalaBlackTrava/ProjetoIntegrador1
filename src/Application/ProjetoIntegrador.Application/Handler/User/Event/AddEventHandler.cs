using ProjetoIntegrador.Application.Commands.User.Event;
using ProjetoIntegrador.Domain.Entity.Creches;
using ProjetoIntegrador.Domain.Entity.User;

namespace ProjetoIntegrador.Application.Handler.User.Event
{
    public class AddEventHandler : IRequestHandler<AddEventCommand, bool>
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IRepository<EventEntity> _eventRepository;

        public AddEventHandler(IRepository<UserEntity> userRepository, IRepository<EventEntity> eventRepository)
        {
            _userRepository = userRepository;
            _eventRepository = eventRepository;
        }

        public async Task<bool> Handle(AddEventCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(request.UserId);
            var eventEntity = await _eventRepository.FindAsync(request.EventId);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            if (eventEntity == null)
            {
                throw new KeyNotFoundException("Event not found");
            }

            user.Events.Add(eventEntity);
            await _userRepository.UpdateAsync(user);
            return true;
        }
    }
}