using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetWorkingMatch.Application.Contracts
{
    public class PedidoResponse
    {
        public Guid IdUserAprovador { get; set; }
        public DateTime DataSolicitacao { get; set; }
    }
}
