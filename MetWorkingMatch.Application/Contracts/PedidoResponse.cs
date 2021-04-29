using System;
using MetWorkingMatch.Domain.Models;

namespace MetWorkingMatch.Application.Contracts
{
    public class PedidoResponse
    {
        public Guid IdUser { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public User User { get; set; }
    }
}
