using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DesafioCnab.Domain.Entities.Validators;

namespace DesafioCnab.Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public Pedido()
        {
            Adicionais = new HashSet<PedidoAdicional>();
        }

        [NotEmpty]
        [Required]
        public Guid TamanhoId { get; set; }

        public Tamanho Tamanho { get; set; }

        [NotEmpty]
        [Required]
        public Guid SaborId { get; set; }

        public Sabor Sabor { get; set; }

        public ICollection<PedidoAdicional> Adicionais { get; set; }

        [NotDefault]
        public int TempoDePreparo { get; set; }

        [NotDefault]
        public decimal PrecoTotal { get; set; }
    }
}