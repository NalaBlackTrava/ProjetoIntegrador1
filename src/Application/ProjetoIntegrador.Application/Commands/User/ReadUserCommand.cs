using ProjetoIntegrador.Domain.Entity.User;

namespace ProjetoIntegrador.Application.Commands.User
{
    public class ReadUserCommand : IRequest<UserEntity>
    {
        public int Id { get; set; }
    }
}