using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetWorkingMatch.Application.Contracts
{
    public class PedidosMatchResponse
    {
        public Guid IdUser{ get; set; }
        public List<PedidoResponse> Pedidos { get; set; }
    }
}
