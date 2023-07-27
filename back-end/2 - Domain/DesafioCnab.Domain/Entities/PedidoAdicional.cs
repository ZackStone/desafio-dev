using System;

namespace DesafioCnab.Domain.Entities
{
    public class PedidoAdicional
    {
        public Guid PedidoId { get; set; }

        public Pedido Pedido { get; set; }

        public Guid AdicionalId { get; set; }

        public Adicional Adicional { get; set; }
    }
}