namespace ProjetoIntegrador.Application.Commands.Creches.Administrator
{
    public class AddAdminCommand : IRequest<bool>
    {
        public long CrecheId { get; set; }
        public long UserId { get; set; }
    }
}