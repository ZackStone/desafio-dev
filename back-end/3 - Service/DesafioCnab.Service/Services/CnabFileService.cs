using DesafioCnab.Domain.DTO;
using DesafioCnab.Domain.Entities;
using DesafioCnab.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCnab.Service.Services;

public class CnabFileService : ICnabFileService
{
    private readonly IService<Transacao> _transacaoService;

    public CnabFileService(IService<Transacao> transacaoService)
    {
        _transacaoService = transacaoService;
    }

    public async Task<IEnumerable<Transacao>> ProcessarArquivo(Stream stream)
    {
        List<CnabFileLine> cnabList = new();

        using TextReader reader = new StreamReader(stream);
        var fileLine = await reader.ReadLineAsync();
        while (fileLine != null)
        {
            cnabList.Add(new CnabFileLine(fileLine));
            fileLine = await reader.ReadLineAsync();
        }

        var objList = cnabList.Select(x => x.InstanciarEntidadeTransacao());

        objList = await _transacaoService.InsertRange(objList);

        return objList;
    }
}