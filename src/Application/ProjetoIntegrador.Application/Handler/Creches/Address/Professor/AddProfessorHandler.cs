using ProjetoIntegrador.Application.Commands.Creches.Address.Professor;
using ProjetoIntegrador.Domain.Entity;
using ProjetoIntegrador.Domain.Entity.Professores;

namespace ProjetoIntegrador.Application.Handler.Creches.Address.Professor
{
    public class AddProfessorHandler : IRequestHandler<AddProfessorCommand, bool>
    {
        private readonly IRepository<AddressEntity> _addressRepository;

        public AddProfessorHandler(IRepository<AddressEntity> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<bool> Handle(AddProfessorCommand request, CancellationToken cancellationToken)
        {
            var address = await _addressRepository.FindAsync(request.AddressId);

            if (address == null)
            {
                throw new KeyNotFoundException("Address not found");
            }

            var professor = new ProfessorEntity
            {
                Name = request.Professor.Name,
                CPF = request.Professor.CPF,
                Phone = request.Professor.Phone,
                Email = request.Professor.Email,
                Image = request.Professor.Image
            };

            address.Professores.Add(professor);
            await _addressRepository.UpdateAsync(address);
            return true;
        }
    }
}