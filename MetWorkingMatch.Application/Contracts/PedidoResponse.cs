using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetWorkingMatch.Application.Contracts
{
    public class PedidosResponse
    {
        public Guid Solicitante { get; set; }
        public DateTime DataSolicitacao { get; set; }
    }
}
