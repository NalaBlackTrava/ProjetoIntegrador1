using ProjetoIntegrador.Application.Contracts;

namespace ProjetoIntegrador.Application.Commands.User.Address
{
    public class AddAddressCommand : IRequest<bool>
    {
        public long UserId { get; set; }
        public required AddressDTO Address { get; set; }
    }
}