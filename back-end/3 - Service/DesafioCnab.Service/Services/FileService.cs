using DesafioCnab.Domain.DTO;
using DesafioCnab.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DesafioCnab.Service.Services
{
    public class FileService : IFileService
    {
        public FileService() { }

        public async Task ProcessarArquivo(Stream stream)
        {
            List<CnabFileLine> cnabList = new();

            using TextReader reader = new StreamReader(stream);
            var fileLine = await reader.ReadLineAsync();
            while (fileLine != null)
            {
                cnabList.Add(new CnabFileLine(fileLine));
                fileLine = await reader.ReadLineAsync();
            }
        }
    }
}