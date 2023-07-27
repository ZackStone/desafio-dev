using DesafioCnab.Domain.Entities;
using DesafioCnab.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DesafioCnab.Infra.Data.Context
{
    public class DesafioCnabContext : DbContext
    {
        public DbSet<Tamanho> Tamanho { get; set; }

        public DbSet<Sabor> Sabor { get; set; }

        public DbSet<Adicional> Adicional { get; set; }

        public DbSet<Pedido> Pedido { get; set; }

        public DbSet<PedidoAdicional> PedidoAdicional { get; set; }

        public DesafioCnabContext(DbContextOptions<DesafioCnabContext> opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PedidoAdicional>(new PedidoAdicionalMap().Configure);
            modelBuilder.Entity<Pedido>(new PedidoMap().Configure);
        }
    }
}