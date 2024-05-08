namespace ProjetoIntegrador.Application.Commands.User.Address
{
    public class RemoveAddressCommand : IRequest<bool>
    {
        public long UserId { get; set; }
        public long AddressId { get; set; }
    }
}