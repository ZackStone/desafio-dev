using DesafioCnab.Domain.Entities.Validators;
using System.ComponentModel.DataAnnotations;

namespace DesafioCnab.Domain.Entities;

public class TipoTransacao
{
    public TipoTransacao() { }

    [NotEmpty]
    [NotDefault]
    [Required]
    public int Id { get; set; }

    public int NaturezaTransacaoId { get; set; }

    public NaturezaTransacao NaturezaTransacao { get; set; }

    public string Descricao { get; set; }
}