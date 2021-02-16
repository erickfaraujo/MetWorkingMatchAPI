
using MetWorkingMatch.Domain.Interfaces;
using System;

namespace MetWorkingMatch.Domain.Entities
{
    public class PedidoMatch : IEntity
    {

        public PedidoMatch()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public Guid IdUserSolicitante { get; set; }
        public Guid IdUserAprovador { get; set; }
        public virtual StatusPedido IdStatusSolicitacao { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime? DataAceite { get; set; }

    }
}
