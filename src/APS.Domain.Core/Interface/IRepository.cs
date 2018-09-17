using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace APS.Domain.Core.Interface
{
    public interface IRepository<TEntity> :IDisposable
    {
        void Add(TEntity entidade);
        void Update(TEntity entidade);
        void Remove(TEntity entidade);

        IEnumerable<TEntity> All();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(long id);

    }
}
