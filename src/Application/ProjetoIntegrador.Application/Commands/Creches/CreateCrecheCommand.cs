using ProjetoIntegrador.Domain.Entity.Creches;

namespace ProjetoIntegrador.Application.Commands.Creches
{
    public class CreateCrecheCommand : IRequest<CrecheEntity>
    {
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
    }
}