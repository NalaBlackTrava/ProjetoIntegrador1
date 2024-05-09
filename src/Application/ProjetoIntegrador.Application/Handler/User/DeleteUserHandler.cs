// DeleteUserHandler.cs
using ProjetoIntegrador.Application.Commands.User;
using ProjetoIntegrador.Domain.Entity.User;

namespace ProjetoIntegrador.Application.Handler.User
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IRepository<UserEntity> _userRepository;

        public DeleteUserHandler(IRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(request.Id);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            _userRepository.Remove(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }
    }
}