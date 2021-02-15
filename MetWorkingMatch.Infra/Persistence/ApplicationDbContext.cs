using MetWorkingMatch.Domain.Entities;
using MetWorkingMatch.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace MetWorkingMatch.Infra.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<PedidoMatch> PedidosMatch { get; set; }
        public DbSet<StatusPedido> StatusPedido { get; set; }
        public DbSet<Match> Matches { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusPedido>().HasData(new StatusPedido { Id = 1, DescricaoStatus = "Pendente" });
            modelBuilder.Entity<StatusPedido>().HasData(new StatusPedido { Id = 2, DescricaoStatus = "Aceito" });
            modelBuilder.Entity<StatusPedido>().HasData(new StatusPedido { Id = 3, DescricaoStatus = "Recusado" });
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
