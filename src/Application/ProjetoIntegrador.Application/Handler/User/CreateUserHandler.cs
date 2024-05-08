using ProjetoIntegrador.Application.Commands.User;
using ProjetoIntegrador.Domain.Entity.User;
using ProjetoIntegrador.Domain.Interfaces;

namespace ProjetoIntegrador.Application.Handler.User
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserEntity>
    {
        private readonly IRepository<UserEntity> _userRepository;

        public CreateUserHandler(IRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserEntity> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            UserEntity user = new()
            {
                Name = request.Name,
                CPF = request.CPF,
                Phone = request.Phone,
                Email = request.Email,
                Image = request.Image
            };

            await _userRepository.UpsetAsync(user);
            return user;
        }
    }
}