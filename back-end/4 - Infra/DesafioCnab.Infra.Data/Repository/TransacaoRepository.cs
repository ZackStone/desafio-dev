using Dapper;
using DesafioCnab.Domain.Entities;
using DesafioCnab.Domain.Interfaces.Repositories;
using DesafioCnab.Infra.Data.Context;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioCnab.Infra.Data.Repository;

public class TransacaoRepository : BaseRepository<Transacao>, ITransacaoRepository
{
    public TransacaoRepository(DesafioCnabContext dbContext, IConfiguration configuration) : base(dbContext, configuration) { }

    public async Task<IEnumerable<string>> GetLojas()
    {
        using var connection = GetSqlConnection();
        connection.Open();
        var result = await connection.QueryAsync<string>("SELECT DISTINCT NomeLoja FROM Transacao");
        return result;
    }

    public async Task<IEnumerable<Transacao>> GetTransacoesPorLoja(string nomeLoja)
    {
        using var connection = GetSqlConnection();
        connection.Open();
        
        var result = await connection.QueryAsync<Transacao>(
            "SELECT * FROM Transacao WHERE NomeLoja = @nomeLoja", 
            new { nomeLoja });

        return result;
    }
}