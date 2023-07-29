using DesafioCnab.Domain.DTO;
using DesafioCnab.Domain.Entities;
using DesafioCnab.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCnab.Service.Services;

public class FileService : IFileService
{
    public FileService() { }

    public async Task ProcessarArquivo(Stream stream)
    {
        List<CnabFileLine> cnabList = new();

        using TextReader reader = new StreamReader(stream);
        var fileLine = await reader.ReadLineAsync();
        while (fileLine != null)
        {
            cnabList.Add(new CnabFileLine(fileLine));
            fileLine = await reader.ReadLineAsync();
        }

        SalvarLista(cnabList);
    }

    private void SalvarLista(List<CnabFileLine> cnabList)
    {
        var objList = cnabList.Select(x => InstanciarObjeto(x));
    }

    private static Transacao InstanciarObjeto(CnabFileLine fileLine)
    {
        string dateTimeMask = "yyyyMMddHHmmss";

        var transacao = new Transacao
        {
            Cpf = fileLine.CPF,
            Cartao = fileLine.Cartao,
            DonoLoja = fileLine.DonoLoja.Trim(),
            NomeLoja = fileLine.NomeLoja.Trim(),
            Valor = decimal.Parse(fileLine.Valor, CultureInfo.InvariantCulture) / 100m,
            DataHora = DateTime.ParseExact(fileLine.Data + fileLine.Hora, dateTimeMask, CultureInfo.InvariantCulture),
            IdTipoTransacao = Convert.ToInt32(fileLine.Tipo)
        };

        return transacao;
    }

}