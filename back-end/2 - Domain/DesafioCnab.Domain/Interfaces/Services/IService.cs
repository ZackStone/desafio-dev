using DesafioCnab.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioCnab.Domain.Interfaces.Services;

public interface IService<T> where T : BaseEntity
{
    Task<T> Insert(T entity);

    Task<IEnumerable<T>> InsertRange(IEnumerable<T> entities);

    Task<T> Update(T entity);

    Task<T> Delete(Guid id);

    Task<T> Get(Guid id);

    Task<List<T>> GetAll();
}