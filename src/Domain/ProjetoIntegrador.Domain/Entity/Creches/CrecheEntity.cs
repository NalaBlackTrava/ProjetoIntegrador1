using ProjetoIntegrador.Domain.Entity.User;

namespace ProjetoIntegrador.Domain.Entity.Creches
{
    public class CrecheEntity : DomainEntity
    {
        public string? Name { get; set; }
        public string? CNPJ { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public virtual List<UserEntity> Administradores { get; set; } = [];
        public virtual List<AddressEntity> Addresses { get; set; } = [];
        public virtual List<EventEntity> Events { get; set; } = [];
    }
}
