using ProjetoIntegrador.Application.Commands.Creches.Administrator;
using ProjetoIntegrador.Domain.Entity.Creches;
using ProjetoIntegrador.Domain.Entity.User;

namespace ProjetoIntegrador.Application.Handler.Creches.Administrator
{
    public class AddAdminHandler : IRequestHandler<AddAdminCommand, bool>
    {
        private readonly IRepository<CrecheEntity> _crecheRepository;
        private readonly IRepository<UserEntity> _userRepository;

        public AddAdminHandler(IRepository<CrecheEntity> crecheRepository, IRepository<UserEntity> userRepository)
        {
            _crecheRepository = crecheRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(AddAdminCommand request, CancellationToken cancellationToken)
        {
            var creche = await _crecheRepository.FindAsync(request.CrecheId);
            var user = await _userRepository.FindAsync(request.UserId);

            if (creche == null)
            {
                throw new KeyNotFoundException("Creche not found");
            }

            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            creche.Administradores.Add(user);
            await _crecheRepository.UpdateAsync(creche);
            return true;
        }
    }
}