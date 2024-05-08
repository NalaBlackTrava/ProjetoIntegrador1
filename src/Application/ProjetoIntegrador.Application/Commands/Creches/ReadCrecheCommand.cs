using ProjetoIntegrador.Domain.Entity.Creches;

namespace ProjetoIntegrador.Application.Commands.Creches
{
    public class ReadCrecheCommand : IRequest<CrecheEntity>
    {
        public int Id { get; set; }
    }
}