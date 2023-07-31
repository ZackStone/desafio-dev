using DesafioCnab.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioCnab.Domain.Interfaces.Services;

public interface ITransacoesService
{
    Task<IEnumerable<Transacao>> GetTransacoesPorLoja(string nomeLoja);
}