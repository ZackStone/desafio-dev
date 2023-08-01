using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using DesafioCnab.Domain.Entities;
using DesafioCnab.Domain.Interfaces.Repositories;
using DesafioCnab.Infra.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DesafioCnab.Infra.Data.Repository;

[ExcludeFromCodeCoverage]
public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected SqlConnection GetSqlConnection() => new(_configuration["ConnectionString:DesafioCnabDB"]);

    protected readonly IConfiguration _configuration;

    protected readonly DesafioCnabContext _dbContext;

    public BaseRepository(DesafioCnabContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }

    public virtual Task<List<TEntity>> GetAll() => _dbContext.Set<TEntity>().ToListAsync();

    public virtual Task<TEntity> Get(Guid id) => _dbContext.Set<TEntity>().FindAsync(id).AsTask();

    public async Task<TEntity> Insert(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity[]> InsertRange(TEntity[] entities)
    {
        _dbContext.Set<TEntity>().AddRange(entities);
        await _dbContext.SaveChangesAsync();
        return entities;
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> Delete(Guid id)
    {
        var entity = await _dbContext.Set<TEntity>().FindAsync(id);
        if (entity == null)
        {
            return entity;
        }

        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }
}