using Dapper;
using DesafioCnab.Domain.Entities;
using DesafioCnab.Domain.Interfaces.Repositories;
using DesafioCnab.Infra.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioCnab.Infra.Data.Repository;

public class TransacaoRepository : BaseRepository<Transacao>, ITransacaoRepository
{
    private readonly IConfiguration _configuration;

    public TransacaoRepository(DesafioCnabContext dbContext, IConfiguration configuration) : base(dbContext)
    {
        _configuration = configuration;
    }

    public async Task<IEnumerable<string>> GetLojas()
    {
        using var connection = new SqlConnection(_configuration["ConnectionString:DesafioCnabDB"]);
        connection.Open();
        var result = await connection.QueryAsync<string>("SELECT DISTINCT NomeLoja FROM Transacao");
        return result;
    }
}