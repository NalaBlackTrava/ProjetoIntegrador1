using ProjetoIntegrador.Application.Commands.Creches;
using ProjetoIntegrador.Domain.Entity.Creches;

namespace ProjetoIntegrador.Application.Handler.Creches
{
    public class DeleteCrecheHandler : IRequestHandler<DeleteCrecheCommand, bool>
    {
        private readonly IRepository<CrecheEntity> _crecheRepository;

        public DeleteCrecheHandler(IRepository<CrecheEntity> crecheRepository)
        {
            _crecheRepository = crecheRepository;
        }

        public async Task<bool> Handle(DeleteCrecheCommand request, CancellationToken cancellationToken)
        {
            var creche = await _crecheRepository.FindAsync(request.Id);

            if (creche == null)
            {
                throw new KeyNotFoundException("Creche not found");
            }

            _crecheRepository.Remove(creche);
            await _crecheRepository.SaveChangesAsync();
            return true;
        }
    }
}