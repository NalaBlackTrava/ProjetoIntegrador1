using ProjetoIntegrador.Domain.Entity.User;

namespace ProjetoIntegrador.Application.Commands.User
{
    public class CreateUserCommand : IRequest<UserEntity>
    {
        public required string Name { get; set; }
        public required string CPF { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public required string Image { get; set; }
    }
}
