namespace ProjetoIntegrador.Application.Commands.Creches.Event
{
    public class DeleteEventCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}