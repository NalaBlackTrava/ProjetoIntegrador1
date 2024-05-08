using ProjetoIntegrador.Application.Commands.Creches;
using ProjetoIntegrador.Domain.Entity.Creches;
public class UpdateCrecheHandler : IRequestHandler<UpdateCrecheCommand, CrecheEntity>
{
    private readonly IRepository<CrecheEntity> _crecheRepository;

    public UpdateCrecheHandler(IRepository<CrecheEntity> crecheRepository)
    {
        _crecheRepository = crecheRepository;
    }

    public async Task<CrecheEntity> Handle(UpdateCrecheCommand request, CancellationToken cancellationToken)
    {
        var creche = await _crecheRepository.FindAsync(request.Id);

        if (creche == null)
        {
            throw new KeyNotFoundException("Creche not found");
        }

        creche.Name = request.Name;
        creche.CNPJ = request.CNPJ;
        creche.Phone = request.Phone;
        creche.Email = request.Email;
        creche.Image = request.Image;

        await _crecheRepository.UpsetAsync(creche);
        return creche;
    }
}
