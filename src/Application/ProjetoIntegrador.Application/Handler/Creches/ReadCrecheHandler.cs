using ProjetoIntegrador.Application.Commands.Creches;
using ProjetoIntegrador.Domain.Entity.Creches;

namespace ProjetoIntegrador.Application.Handler.Creches
{
    public class ReadCrecheHandler : IRequestHandler<ReadCrecheCommand, CrecheEntity>
    {
        private readonly IRepository<CrecheEntity> _crecheRepository;

        public ReadCrecheHandler(IRepository<CrecheEntity> crecheRepository)
        {
            _crecheRepository = crecheRepository;
        }

        public async Task<CrecheEntity> Handle(ReadCrecheCommand request, CancellationToken cancellationToken)
        {
            var creche = await _crecheRepository.FindAsync(request.Id);

            if (creche == null)
            {
                throw new KeyNotFoundException("Creche not found");
            }

            return creche;
        }
    }
}