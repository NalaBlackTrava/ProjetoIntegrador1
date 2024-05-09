using ProjetoIntegrador.Domain.Entity.Creches;

namespace ProjetoIntegrador.Application.Commands.Creches
{
    public class UpdateCrecheCommand : IRequest<CrecheEntity>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
    }
}