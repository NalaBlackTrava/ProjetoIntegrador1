using ProjetoIntegrador.Application.Contracts;

namespace ProjetoIntegrador.Application.Commands.Creches.Address
{
    public class CrecheAddAddressCommand : IRequest<bool>
    {
        public long CrecheId { get; set; }
        public required AddressDTO Address { get; set; }
    }
}