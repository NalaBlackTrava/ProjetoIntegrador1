using ProjetoIntegrador.Domain.Interfaces;

namespace ProjetoIntegrador.Domain.Entity
{
    public abstract class DomainEntity : IEntity
    {
        public long Id { get; set; }
    }
}
