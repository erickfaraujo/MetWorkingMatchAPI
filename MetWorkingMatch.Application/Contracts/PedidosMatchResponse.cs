using System;
using System.Collections.Generic;

namespace MetWorkingMatch.Application.Contracts
{
    public class PedidosMatchResponse
    {
        public Guid IdUser{ get; set; }
        public List<PedidoResponse> Pedidos { get; set; }
    }
}
