using ProjetoIntegrador.Domain.Entity.User;

namespace ProjetoIntegrador.Domain.Entity.Creches
{
    public class EventEntity : DomainEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateOnly? Date { get; set; }
        public string? Image { get; set; }
        public long CrecheId { get; set; }
        public virtual CrecheEntity? Creche { get; set; } = null;
        public virtual List<UserEntity> Users { get; set; } = [];
    }
}
