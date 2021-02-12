using MetWorkingMatch.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace MetWorkingMatch.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<PedidoMatch> PedidosMatch { get; set; }
        public DbSet<StatusPedido> StatusPedido { get; set; }
        public DbSet<Match> Matches { get; set; }

    }
}
