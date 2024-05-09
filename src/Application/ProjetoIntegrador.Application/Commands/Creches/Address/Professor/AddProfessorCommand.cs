using ProjetoIntegrador.Application.Contracts;

namespace ProjetoIntegrador.Application.Commands.Creches.Address.Professor
{
    public class AddProfessorCommand : IRequest<bool>
    {
        public long AddressId { get; set; }
        public ProfessorDTO Professor { get; set; }
    }
}