using DesafioCnab.Domain.Entities.Validators;
using System.ComponentModel.DataAnnotations;

namespace DesafioCnab.Domain.Entities;

public class NaturezaTransacao
{
    public NaturezaTransacao() { }

    [NotEmpty]
    [NotDefault]
    [Required]
    public int Id { get; set; }

    public string Descricao { get; set; }

    public char Sinal { get; set; }
}