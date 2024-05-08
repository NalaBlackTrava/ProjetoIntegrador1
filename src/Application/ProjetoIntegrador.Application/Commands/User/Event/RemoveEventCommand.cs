namespace ProjetoIntegrador.Application.Commands.User.Event
{
    public class RemoveEventCommand : IRequest<bool>
    {
        public long UserId { get; set; }
        public long EventId { get; set; }
    }
}