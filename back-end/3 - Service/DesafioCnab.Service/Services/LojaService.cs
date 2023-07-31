using DesafioCnab.Domain.Interfaces.Repositories;
using DesafioCnab.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioCnab.Service.Services;

public class LojaService : ILojaService
{
    private readonly ITransacaoRepository _transacaoRepository;

    public LojaService(ITransacaoRepository transacaoRepository)
    {
        _transacaoRepository = transacaoRepository;
    }

    public async Task<IEnumerable<string>> GetLojas() => await _transacaoRepository.GetLojas();
}