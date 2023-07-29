using DesafioCnab.Domain.Entities.Validators;
using System.ComponentModel.DataAnnotations;

namespace DesafioCnab.Domain.Entities;

public class TipoTransacao
{
    public TipoTransacao() { }

    [NotEmpty]
    [Required]
    public int Id { get; set; }

    public int IdNaturezaTransacao { get; set; }

    public NaturezaTransacao NaturezaTransacao { get; set; }

    public string Descricao { get; set; }
}