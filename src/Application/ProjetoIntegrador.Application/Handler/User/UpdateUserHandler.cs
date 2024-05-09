using ProjetoIntegrador.Application.Commands.User;
using ProjetoIntegrador.Domain.Entity.User;
using ProjetoIntegrador.Domain.Interfaces;

namespace ProjetoIntegrador.Application.Handler.User
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserEntity>
    {
        private readonly IRepository<UserEntity> _userRepository;

        public UpdateUserHandler(IRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserEntity> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            UserEntity user = await _userRepository.FindAsync(request.Id);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            user.Name = request.Name;
            user.CPF = request.CPF;
            user.Phone = request.Phone;
            user.Email = request.Email;
            user.Image = request.Image;

            await _userRepository.UpsetAsync(user);
            return user;
        }
    }
}