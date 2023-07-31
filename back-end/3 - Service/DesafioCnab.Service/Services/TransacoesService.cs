using DesafioCnab.Domain.Entities;
using DesafioCnab.Domain.Interfaces.Repositories;
using DesafioCnab.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioCnab.Service.Services;

public class TransacoesService : ITransacoesService
{
    private readonly ITransacaoRepository _transacaoRepository;

    public TransacoesService(ITransacaoRepository transacaoRepository)
    {
        _transacaoRepository = transacaoRepository;
    }

    public async Task<IEnumerable<Transacao>> GetTransacoesPorLoja(string nomeLoja) =>
        await _transacaoRepository.GetTransacoesPorLoja(nomeLoja);
}