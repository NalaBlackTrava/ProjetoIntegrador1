namespace ProjetoIntegrador.Application.Commands.Creches
{
    public class DeleteCrecheCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}