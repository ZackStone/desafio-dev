using DesafioCnab.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioCnab.Domain.Interfaces.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task<T> Get(Guid id);

    Task<List<T>> GetAll();

    Task<T> Insert(T entity);

    Task<T[]> InsertRange(T[] entities);

    Task<T> Update(T entity);

    Task<T> Delete(Guid id);
}