using DesafioCnab.Domain.Dto;
using DesafioCnab.Domain.Entities;
using DesafioCnab.Domain.Interfaces.Repositories;
using DesafioCnab.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCnab.Service.Services;

public class TransacaoService : BaseService<Transacao>, ITransacaoService
{
    private readonly ITransacaoRepository _transacaoRepository;

    public TransacaoService(ITransacaoRepository transacaoRepository) : base(transacaoRepository)
    {
        _transacaoRepository = transacaoRepository;
    }

    public async Task<TransacoesPorLojaDto> GetTransacoesPorLoja(string nomeLoja)
    {
        var transacoes = await _transacaoRepository.GetTransacoesPorLoja(nomeLoja);
        var saldo = CalcularSaldo(transacoes);
        var dto = new TransacoesPorLojaDto(transacoes, saldo);
        return dto;
    }

    public decimal CalcularSaldo(IEnumerable<Transacao> transacoes)
    {
        return transacoes.Aggregate(0m, 
            (acc, i) => i.TipoTransacao.NaturezaTransacao.Sinal == '+' ? acc + i.Valor : acc - i.Valor);
    }
}