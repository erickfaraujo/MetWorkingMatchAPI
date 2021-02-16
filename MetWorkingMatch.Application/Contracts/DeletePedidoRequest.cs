using System;


namespace MetWorkingMatch.Application.Contracts
{
    public class DeletePedidoRequest
    {
        public Guid IdUserSolicitante { get; set; }
        public Guid IdUserAprovador { get; set; }
    }
}
