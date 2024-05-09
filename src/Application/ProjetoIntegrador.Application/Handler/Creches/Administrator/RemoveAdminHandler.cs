using ProjetoIntegrador.Application.Commands.Creches.Administrator;
using ProjetoIntegrador.Domain.Entity.Creches;

namespace ProjetoIntegrador.Application.Handler.Creches.Administrator
{
    public class RemoveAdminHandler : IRequestHandler<RemoveAdminCommand, bool>
    {
        private readonly IRepository<CrecheEntity> _crecheRepository;

        public RemoveAdminHandler(IRepository<CrecheEntity> crecheRepository)
        {
            _crecheRepository = crecheRepository;
        }

        public async Task<bool> Handle(RemoveAdminCommand request, CancellationToken cancellationToken)
        {
            var creche = await _crecheRepository.FindAsync(request.CrecheId);

            if (creche == null)
            {
                throw new KeyNotFoundException("Creche not found");
            }

            var user = creche.Administradores.FirstOrDefault(a => a.Id == request.UserId);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            creche.Administradores.Remove(user);
            await _crecheRepository.UpdateAsync(creche);
            return true;
        }
    }
}