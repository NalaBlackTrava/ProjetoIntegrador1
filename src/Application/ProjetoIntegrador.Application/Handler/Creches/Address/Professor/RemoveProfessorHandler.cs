using ProjetoIntegrador.Application.Commands.Creches.Address.Professor;
using ProjetoIntegrador.Domain.Entity;

namespace ProjetoIntegrador.Application.Handler.Creches.Address.Professor
{
    public class RemoveProfessorHandler : IRequestHandler<RemoveProfessorCommand, bool>
    {
        private readonly IRepository<AddressEntity> _addressRepository;

        public RemoveProfessorHandler(IRepository<AddressEntity> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<bool> Handle(RemoveProfessorCommand request, CancellationToken cancellationToken)
        {
            var address = await _addressRepository.FindAsync(request.AddressId);

            if (address == null)
            {
                throw new KeyNotFoundException("Address not found");
            }

            var professor = address.Professores.FirstOrDefault(p => p.Id == request.ProfessorId);

            if (professor == null)
            {
                throw new KeyNotFoundException("Professor not found");
            }

            address.Professores.Remove(professor);
            await _addressRepository.UpdateAsync(address);
            return true;
        }
    }
}