namespace ProjetoIntegrador.Domain.Entity.Professores
{
    public class ProfessorEntity
    {
        public string? Name { get; set; }
        public string? CPF { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public List<Address> Address { get; set; } = [];
    }
}
