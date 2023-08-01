using DesafioCnab.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioCnab.Domain.Interfaces.Repositories;

public interface ITransacaoRepository : IRepository<Transacao>
{
    Task<IEnumerable<string>> GetLojas();

    Task<List<Transacao>> GetTransacoesPorLoja(string nomeLoja);
}