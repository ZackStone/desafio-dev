using DesafioCnab.Domain.Dto;
using DesafioCnab.Domain.Entities;
using DesafioCnab.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCnab.Service.Services;

public class CnabFileService : ICnabFileService
{
    private readonly ITransacaoService _transacaoService;

    public CnabFileService(ITransacaoService transacaoService)
    {
        _transacaoService = transacaoService;
    }

    public async Task<IEnumerable<Transacao>> ProcessarArquivo(Stream stream)
    {
        List<CnabFileLineDto> cnabList = new();

        using TextReader reader = new StreamReader(stream);
        var fileLine = await reader.ReadLineAsync();
        while (fileLine != null)
        {
            cnabList.Add(new CnabFileLineDto(fileLine));
            fileLine = await reader.ReadLineAsync();
        }

        var objList = cnabList.Select(x => x.InstanciarEntidadeTransacao()).ToList();

        return await _transacaoService.InsertRange(objList);
    }
}