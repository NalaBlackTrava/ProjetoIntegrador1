using ProjetoIntegrador.Application.Commands.Creches;
using ProjetoIntegrador.Domain.Entity.Creches;

namespace ProjetoIntegrador.Application.Handler.Creches
{
    public class CreateCrecheHandler : IRequestHandler<CreateCrecheCommand, CrecheEntity>
    {
        private readonly IRepository<CrecheEntity> _crecheRepository;

        public CreateCrecheHandler(IRepository<CrecheEntity> crecheRepository)
        {
            _crecheRepository = crecheRepository;
        }

        public async Task<CrecheEntity> Handle(CreateCrecheCommand request, CancellationToken cancellationToken)
        {
            CrecheEntity creche = new()
            {
                Name = request.Name,
                CNPJ = request.CNPJ,
                Phone = request.Phone,
                Email = request.Email,
                Image = request.Image
            };

            await _crecheRepository.UpsetAsync(creche);
            return creche;
        }
    }
}