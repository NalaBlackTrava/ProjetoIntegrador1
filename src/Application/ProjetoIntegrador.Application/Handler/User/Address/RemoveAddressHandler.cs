using ProjetoIntegrador.Application.Commands.User.Address;
using ProjetoIntegrador.Domain.Entity.User;

public class RemoveAddressHandler : IRequestHandler<UserRemoveAddressCommand, bool>
{
    private readonly IRepository<UserEntity> _userRepository;

    public RemoveAddressHandler(IRepository<UserEntity> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(UserRemoveAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindAsync(request.UserId);

        if (user == null)
        {
            throw new KeyNotFoundException("User not found");
        }

        var address = user.Addresses.FirstOrDefault(a => a.Id == request.AddressId);

        if (address == null)
        {
            throw new KeyNotFoundException("Address not found");
        }

        user.Addresses.Remove(address);
        await _userRepository.UpdateAsync(user);
        return true;
    }
}

