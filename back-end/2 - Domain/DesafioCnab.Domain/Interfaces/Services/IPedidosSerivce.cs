using System.Threading.Tasks;
using DesafioCnab.Domain.DTO;
using DesafioCnab.Domain.Entities;

namespace DesafioCnab.Domain.Interfaces.Services
{
    public interface IPedidosService : IService<Pedido>
    {
        Task<Pedido> PostDTO(PedidoDTO dto);

        Pedido Checkout(PedidoDTO dto);
     }
}