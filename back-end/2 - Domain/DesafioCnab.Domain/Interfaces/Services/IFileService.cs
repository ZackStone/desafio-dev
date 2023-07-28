using System.IO;
using System.Threading.Tasks;

namespace DesafioCnab.Domain.Interfaces.Services
{
    public interface IFileService
    {
        Task ProcessarArquivo(Stream stream);
    }
}