namespace ProjetoIntegrador.Application.Commands.User.Event
{
    public class AddEventCommand : IRequest<bool>
    {
        public long UserId { get; set; }
        public long EventId { get; set; }
    }
}