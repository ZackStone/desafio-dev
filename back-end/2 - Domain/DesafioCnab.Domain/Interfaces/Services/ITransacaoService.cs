using DesafioCnab.Domain.Dto;
using DesafioCnab.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioCnab.Domain.Interfaces.Services;

public interface ITransacaoService : IService<Transacao>
{
    Task<TransacoesPorLojaDto> GetTransacoesPorLoja(string nomeLoja);

    decimal CalcularSaldo(IEnumerable<Transacao> transacoes);
}