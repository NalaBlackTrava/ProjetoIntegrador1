namespace ProjetoIntegrador.Application.Commands.Creches.Event
{
    public class DeleteEventCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}