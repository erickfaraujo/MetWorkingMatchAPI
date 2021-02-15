using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetWorkingMatch.Application.Contracts
{
    public class CreatePedidoRequest
    {
        public Guid idUserSolicitante { get; set; }
        public Guid idUserAprovador { get; set; }

    }
}
