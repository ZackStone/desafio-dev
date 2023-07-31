using DesafioCnab.Domain.DTO;
using System.Threading.Tasks;

namespace DesafioCnab.Domain.Interfaces.Services;

public interface ITransacoesService
{
    Task<TransacoesPorLojaDto> GetTransacoesPorLoja(string nomeLoja);
}