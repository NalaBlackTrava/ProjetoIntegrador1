using ProjetoIntegrador.Application.Commands.User.Address;
using ProjetoIntegrador.Domain.Entity;
using ProjetoIntegrador.Domain.Entity.User;

namespace ProjetoIntegrador.Application.Handler.User.Address
{
    public class AddAddressHandler : IRequestHandler<AddAddressCommand, bool>
    {
        private readonly IRepository<UserEntity> _userRepository;

        public AddAddressHandler(IRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(request.UserId);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            var address = new AddressEntity
            {
                Street = request.Address.Street,
                City = request.Address.City,
                State = request.Address.State,
                Complement = request.Address.Complement,
                Neighborhood = request.Address.Neighborhood,
                Number = request.Address.Number,
                ZipCode = request.Address.ZipCode,
                Capacity = request.Address.Capacity,
                Schedule = request.Address.Schedule,
                Responsible = request.Address.Responsible,
                ResponsiblePhone = request.Address.ResponsiblePhone,
                ResponsibleEmail = request.Address.ResponsibleEmail,
                Value = request.Address.Value,
                Images = request.Address.Images
            };

            user.Addresses.Add(address);
            await _userRepository.UpdateAsync(user);
            return true;
        }
    }
}