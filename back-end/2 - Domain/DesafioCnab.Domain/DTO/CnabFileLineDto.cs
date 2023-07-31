using DesafioCnab.Domain.Entities;
using System.Globalization;
using System;

namespace DesafioCnab.Domain.DTO;

public class CnabFileLineDto
{
    public CnabFileLineDto(string str)
    {
        Tipo = str[..1];
        Data = str[1..9];
        Valor = str[9..19];
        CPF = str[19..30];
        Cartao = str[30..42];
        Hora = str[42..48];
        DonoLoja = str[48..62];
        NomeLoja = str[62..];
    }

    public string Tipo { get; set; }
    public string Data { get; set; }
    public string Valor { get; set; }
    public string CPF { get; set; }
    public string Cartao { get; set; }
    public string Hora { get; set; }
    public string DonoLoja { get; set; }
    public string NomeLoja { get; set; }

    public Transacao InstanciarEntidadeTransacao() => new()
    {
        Cpf = CPF,
        Cartao = Cartao,
        DonoLoja = DonoLoja.Trim(),
        NomeLoja = NomeLoja.Trim(),
        Valor = decimal.Parse(Valor, CultureInfo.InvariantCulture) / 100m,
        DataHora = DateTime.ParseExact(Data + Hora, "yyyyMMddHHmmss", CultureInfo.InvariantCulture),
        TipoTransacaoId = Convert.ToInt32(Tipo)
    };
}