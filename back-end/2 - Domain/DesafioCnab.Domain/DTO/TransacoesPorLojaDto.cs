using DesafioCnab.Domain.Entities;
using System.Collections.Generic;

namespace DesafioCnab.Domain.Dto;

public class TransacoesPorLojaDto
{
    public TransacoesPorLojaDto(List<Transacao> transacoes, decimal saldo)
    {
        Transacoes = transacoes;
        Saldo = saldo;
    }

    public List<Transacao> Transacoes { get; }

    public decimal Saldo { get; }
}