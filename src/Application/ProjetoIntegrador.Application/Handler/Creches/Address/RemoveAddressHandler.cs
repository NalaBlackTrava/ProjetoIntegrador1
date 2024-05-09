using ProjetoIntegrador.Application.Commands.Creches.Address;
using ProjetoIntegrador.Domain.Entity.Creches;

namespace ProjetoIntegrador.Application.Handler.Creches.Address
{
    public class RemoveAddressHandler : IRequestHandler<CrecheRemoveAddressCommand, bool>
    {
        private readonly IRepository<CrecheEntity> _crecheRepository;

        public RemoveAddressHandler(IRepository<CrecheEntity> crecheRepository)
        {
            _crecheRepository = crecheRepository;
        }

        public async Task<bool> Handle(CrecheRemoveAddressCommand request, CancellationToken cancellationToken)
        {
            var creche = await _crecheRepository.FindAsync(request.CrecheId);

            if (creche == null)
            {
                throw new KeyNotFoundException("Creche not found");
            }

            var address = creche.Addresses.FirstOrDefault(a => a.Id == request.AddressId);

            if (address == null)
            {
                throw new KeyNotFoundException("Address not found");
            }

            creche.Addresses.Remove(address);
            await _crecheRepository.UpdateAsync(creche);
            return true;
        }
    }
}