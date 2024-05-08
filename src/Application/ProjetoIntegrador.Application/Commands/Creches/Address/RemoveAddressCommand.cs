using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Application.Commands.Creches.Address
{
    public class RemoveAddressCommand : IRequest<bool>
    {
        public long CrecheId { get; set; }
        public long AddressId { get; set; }
    }
}
