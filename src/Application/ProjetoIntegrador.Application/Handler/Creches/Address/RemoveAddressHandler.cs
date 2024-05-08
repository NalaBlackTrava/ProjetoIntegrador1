using ProjetoIntegrador.Application.Commands.Creches.Address;
using ProjetoIntegrador.Application.Commands.User.Address;
using ProjetoIntegrador.Domain.Entity.Creches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Application.Handler.Creches.Address
{
    public class RemoveAddressHandler : IRequestHandler<RemoveAddressCommand, bool>
    {
        private readonly IRepository<CrecheEntity> _crecheRepository;

        public RemoveAddressHandler(IRepository<CrecheEntity> crecheRepository)
        {
            _crecheRepository = crecheRepository;
        }

        public async Task<bool> Handle(RemoveAddressCommand request, CancellationToken cancellationToken)
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