using System.ComponentModel.DataAnnotations;
using DesafioCnab.Domain.Entities.Validators;

namespace DesafioCnab.Domain.Entities
{
    public class Tamanho : BaseEntity
    {

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Label { get; set; }

        [Required]
        [NotDefault]
        public int TamanhoMl { get; set; }

        [Required]
        [NotDefault]
        public decimal Preco { get; set; }

        [Required]
        [NotDefault]
        public int TempoDePreparo { get; set; }
    }
}