using ProjetoIntegrador.Application.Commands.User.Event;
using ProjetoIntegrador.Domain.Entity.User;

namespace ProjetoIntegrador.Application.Handler.User.Event
{
    public class RemoveEventHandler : IRequestHandler<RemoveEventCommand, bool>
    {
        private readonly IRepository<UserEntity> _userRepository;

        public RemoveEventHandler(IRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RemoveEventCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(request.UserId);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            var eventEntity = user.Events.FirstOrDefault(e => e.Id == request.EventId);

            if (eventEntity == null)
            {
                throw new KeyNotFoundException("Event not found");
            }

            user.Events.Remove(eventEntity);
            await _userRepository.UpdateAsync(user);
            return true;
        }
    }
}