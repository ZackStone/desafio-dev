using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioCnab.Domain.Entities;
using DesafioCnab.Domain.Interfaces.Repositories;
using DesafioCnab.Domain.Interfaces.Services;

namespace DesafioCnab.Service.Services;

public class BaseService<TEntity> : IService<TEntity> where TEntity : BaseEntity
{
    private readonly IRepository<TEntity> _repository;

    public BaseService(IRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public virtual Task<List<TEntity>> GetAll() => _repository.GetAll();

    public virtual Task<TEntity> Get(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Campo 'Id' não pode ser vazio.");

        return _repository.Get(id);
    }

    public virtual async Task<TEntity> Insert(TEntity obj) => 
        await _repository.Insert(obj);

    public virtual async Task<IEnumerable<TEntity>> InsertRange(IEnumerable<TEntity> entities) => 
        await _repository.InsertRange(entities.ToArray());

    public async Task<TEntity> Update(TEntity obj) => 
        await _repository.Update(obj);

    public async Task<TEntity> Delete(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Campo 'Id' é obrigatório.");

        var obj = await _repository.Delete(id);
        return obj;
    }
}