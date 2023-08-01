using DesafioCnab.Domain.Entities;
using FluentValidation;
using System;
using System.Globalization;

namespace DesafioCnab.Domain.Dto;

public class CnabFileLineDto
{
    public CnabFileLineDto() { }

    public CnabFileLineDto(string str)
    {
        try
        {
            Tipo = str[..1];
            Data = str[1..9];
            Valor = str[9..19];
            Cpf = str[19..30];
            Cartao = str[30..42];
            Hora = str[42..48];
            DonoLoja = str[48..62];
            NomeLoja = str[62..];
        }
        catch (Exception)
        {
            throw new ValidationException("O arquivo não está formatado corretamente.");
        }
    }

    public string Tipo { get; set; }
    public string Data { get; set; }
    public string Valor { get; set; }
    public string Cpf { get; set; }
    public string Cartao { get; set; }
    public string Hora { get; set; }
    public string DonoLoja { get; set; }
    public string NomeLoja { get; set; }

    public Transacao InstanciarEntidadeTransacao()
    {
        try
        {
            return new()
            {
                Cpf = Cpf,
                Cartao = Cartao,
                DonoLoja = DonoLoja.Trim(),
                NomeLoja = NomeLoja.Trim(),
                Valor = int.Parse(Valor, CultureInfo.InvariantCulture) / 100m,
                DataHora = DateTime.ParseExact(Data + Hora, "yyyyMMddHHmmss", CultureInfo.InvariantCulture),
                TipoTransacaoId = Convert.ToInt32(Tipo)
            };
        }
        catch (Exception)
        {
            throw new ValidationException("O arquivo não está formatado corretamente.");
        }
    }
}