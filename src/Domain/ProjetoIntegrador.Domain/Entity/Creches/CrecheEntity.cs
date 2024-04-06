using ProjetoIntegrador.Domain.Entity.Creches;
using ProjetoIntegrador.Domain.Entity.User;

namespace ProjetoIntegrador.Domain.Entity
{
    public class CrecheEntity : DomainEntity
    {
        public string? Name { get; set; }
        public string? CNPJ { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public List<UserEntity> Administradores { get; set; } = [];
        public List<AddressEntity> Addresses { get; set; } = [];
        public List<EventEntity> Events { get; set; } = [];
    }
}
