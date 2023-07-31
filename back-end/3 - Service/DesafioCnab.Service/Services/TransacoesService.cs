using DesafioCnab.Domain.DTO;
using DesafioCnab.Domain.Interfaces.Repositories;
using DesafioCnab.Domain.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCnab.Service.Services;

public class TransacoesService : ITransacoesService
{
    private readonly ITransacaoRepository _transacaoRepository;

    public TransacoesService(ITransacaoRepository transacaoRepository)
    {
        _transacaoRepository = transacaoRepository;
    }

    public async Task<TransacoesPorLojaDto> GetTransacoesPorLoja(string nomeLoja)
    {
        var transacoes = await _transacaoRepository.GetTransacoesPorLoja(nomeLoja);
        var saldo = transacoes.Aggregate(0m, (acc, i) => i.TipoTransacao.NaturezaTransacao.Sinal == '+' ? acc + i.Valor : acc - i.Valor);
        var dto = new TransacoesPorLojaDto(transacoes, saldo);
        return dto;
    }
}