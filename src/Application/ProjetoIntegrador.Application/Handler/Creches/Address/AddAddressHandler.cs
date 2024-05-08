using ProjetoIntegrador.Application.Commands.Creches.Address;
using ProjetoIntegrador.Domain.Entity;
using ProjetoIntegrador.Domain.Entity.Creches;

namespace ProjetoIntegrador.Application.Handler.Creches.Address
{
    public class AddAddressHandler : IRequestHandler<AddAddressCommand, bool>
    {
        private readonly IRepository<CrecheEntity> _crecheRepository;

        public AddAddressHandler(IRepository<CrecheEntity> crecheRepository)
        {
            _crecheRepository = crecheRepository;
        }

        public async Task<bool> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            var creche = await _crecheRepository.FindAsync(request.CrecheId);

            if (creche == null)
            {
                throw new KeyNotFoundException("Creche not found");
            }

            var address = new AddressEntity
            {
                Street = request.Address.Street,
                City = request.Address.City,
                State = request.Address.State,
                Complement = request.Address.Complement,
                Neighborhood = request.Address.Neighborhood,
                Number = request.Address.Number,
                Images = request.Address.Images,
                Capacity = request.Address.Capacity,
                Schedule = request.Address.Schedule,
                Responsible = request.Address.Responsible,
                ResponsiblePhone = request.Address.ResponsiblePhone,
                ResponsibleEmail = request.Address.ResponsibleEmail,
                Value = request.Address.Value,
                ZipCode = request.Address.ZipCode
            };

            creche.Addresses.Add(address);
            await _crecheRepository.UpdateAsync(creche);
            return true;
        }
    }
}