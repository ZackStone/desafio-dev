using DesafioCnab.Domain.Entities.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioCnab.Domain.Entities;

public class Transacao : BaseEntity
{
    public Transacao() { }

    [NotEmpty]
    [NotDefault]
    [Required]
    public int TipoTransacaoId { get; set; }

    public TipoTransacao TipoTransacao { get; set; }

    public string Cpf { get; set; }

    public string Cartao { get; set; }

    public DateTime DataHora { get; set; }

    public string NomeLoja { get; set; }

    public string DonoLoja { get; set; }

    public decimal Valor { get; set; }
}