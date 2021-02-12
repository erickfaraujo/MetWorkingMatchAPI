using MetWorkingMatch.Domain.Entities;
using MetWorkingMatch.Application.Interfaces;
using Microsoft.EntityFrameworkCore;


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
            modelBuilder.Entity<StatusPedido>().HasData(new StatusPedido { Id = 1, descricaoStatus = "Pendente" });
            modelBuilder.Entity<StatusPedido>().HasData(new StatusPedido { Id = 2, descricaoStatus = "Aceito" });
            modelBuilder.Entity<StatusPedido>().HasData(new StatusPedido { Id = 3, descricaoStatus = "Recusado" });
        }
    }
}
