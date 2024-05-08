namespace ProjetoIntegrador.Application.Contracts
{
    public class AddressDTO
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string Capacity { get; set; }
        public string Schedule { get; set; }
        public string? Responsible { get; set; }
        public string? ResponsiblePhone { get; set; }
        public string? ResponsibleEmail { get; set; }
        public double Value { get; set; }
        public List<string> Images { get; set; } = [];
    }
}