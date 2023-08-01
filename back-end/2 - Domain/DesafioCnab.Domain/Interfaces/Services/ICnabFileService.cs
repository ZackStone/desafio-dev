using DesafioCnab.Domain.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DesafioCnab.Domain.Interfaces.Services;

public interface ICnabFileService
{
    Task<IEnumerable<Transacao>> ProcessarArquivo(Stream stream);
}