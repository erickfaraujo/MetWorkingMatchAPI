using System;

namespace MetWorkingMatch.Application.Contracts
{
    public class UpdatePedidoRequest
    {
        public Guid IdUserSolicitante { get; set; }
        public Guid IdUserAprovador { get; set; }
        public int? Action { get; set; }

    }
}
