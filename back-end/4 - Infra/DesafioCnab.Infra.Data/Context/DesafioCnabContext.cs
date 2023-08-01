using DesafioCnab.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioCnab.Infra.Data.Context;

public class DesafioCnabContext : DbContext
{
    public DbSet<NaturezaTransacao> NaturezaTransacao { get; set; }

    public DbSet<TipoTransacao> TipoTransacao { get; set; }

    public DbSet<Transacao> Transacao { get; set; }

    public DesafioCnabContext(DbContextOptions<DesafioCnabContext> opts) : base(opts) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}