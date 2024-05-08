namespace ProjetoIntegrador.Application.Commands.Creches.Address.Professor
{
    public class RemoveProfessorCommand : IRequest<bool>
    {
        public long AddressId { get; set; }
        public long ProfessorId { get; set; }
    }
}