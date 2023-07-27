using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioCnab.Domain.Entities;
using DesafioCnab.Domain.Interfaces.Repositories;
using DesafioCnab.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioCnab.Infra.Data.Repository
{
    public class PedidosRepository : BaseRepository<Pedido>, IPedidosRepository
    {
        public PedidosRepository(DesafioCnabContext dbContext) : base(dbContext) { }

        public override Task<List<Pedido>> GetAll() =>
            _dbContext.Pedido
                .Include(p => p.Tamanho)
                .Include(p => p.Sabor)
                .ToListAsync();

        public override Task<Pedido> Get(Guid id) =>
            _dbContext.Pedido
                .Include(p => p.Tamanho)
                .Include(p => p.Sabor)
                .Include(p => p.Adicionais)
                    .ThenInclude(a => a.Adicional)
                .SingleOrDefaultAsync(p => p.Id == id);
    }
}