using ProjetoIntegrador.Application.Commands.User;
using ProjetoIntegrador.Domain.Entity.User;
using ProjetoIntegrador.Domain.Interfaces;

namespace ProjetoIntegrador.Application.Handler.User
{
    public class ReadUserHandler : IRequestHandler<ReadUserCommand, UserEntity>
    {
        private readonly IRepository<UserEntity> _userRepository;

        public ReadUserHandler(IRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserEntity> Handle(ReadUserCommand request, CancellationToken cancellationToken)
        {
            UserEntity user = await _userRepository.FindAsync(request.Id);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            return user;
        }
    }
}