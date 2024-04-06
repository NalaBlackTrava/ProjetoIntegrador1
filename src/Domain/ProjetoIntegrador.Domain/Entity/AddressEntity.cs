using ProjetoIntegrador.Domain.Entity.Professores;
using ProjetoIntegrador.Domain.Entity.User;

namespace ProjetoIntegrador.Domain.Entity
{
    public class AddressEntity : DomainEntity
    {
        public string? Responsible { get; set; }
        public string? ResponsiblePhone { get; set; }
        public string? ResponsibleEmail { get; set; }

        public string? Capacity { get; set; }
        public double Value { get; set; }
        public string? Schedule { get; set; }

        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? Complement { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public List<string> Images { get; set; } = [];
        public long CrecheId { get; set; }
        public long UserId { get; set; }
        public virtual UserEntity? User { get; set; }
        public virtual CrecheEntity? Creche { get; set; }
        public virtual List<ProfessorEntity> Professores { get; set; } = [];
    }
}
