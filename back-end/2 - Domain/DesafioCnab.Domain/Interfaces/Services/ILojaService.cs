using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioCnab.Domain.Interfaces.Services;

public interface ILojaService
{
    Task<IEnumerable<string>> GetLojas();
}