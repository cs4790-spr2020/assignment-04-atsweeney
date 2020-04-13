using System;
using System.Collections.Generic;

namespace BlabberApp.Domain.Interfaces
{
    public interface iRepository<T> where T : iEntity
    {
        void Add(T entity);

        void Remove(T entity);

        void Update(T entity);

        IEnumerable<T> GetAll();

        T GetById(Guid sysId);
    }
}