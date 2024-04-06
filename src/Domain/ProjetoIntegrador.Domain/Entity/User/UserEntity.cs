namespace ProjetoIntegrador.Domain.Entity.User
{
    public abstract class UserEntity : DomainEntity
    {
        public string? Name { get; set; }
        public string? CPF { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public virtual List<Address> Address { get; set; } = [];
        public virtual List<CrecheEntity> CrecheEntity { get; set; } = [];
    }
}
