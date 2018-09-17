using System;
using System.Collections.Generic;
using APS.Domain.Core.Interface;
using System.Data.Entity;
using APS.Domain.Core.Models.Common;
using APS.Infra.Data.Core.Interfaces;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;

namespace APS.Infra.Data.Context.Repository.EntityFramework.Usuario.Common
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {

        private readonly IDbSet<TEntity> dbSet;
        private readonly IDbContext dbContext;


        public Repository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TEntity>();
        }


        public void Add(TEntity entidade)
        {
            dbSet.Add(entidade);
        }

        public IEnumerable<TEntity> All()
        {
            return Find();
        }


        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate=null)
        {
            return predicate != null?
                dbSet.Where(predicate).AsNoTracking():
                dbSet.AsNoTracking();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return predicate != null ?
                dbSet.FirstOrDefault(predicate) :
                dbSet.FirstOrDefault();
        }

        public TEntity Get(long id)
        {
            return dbSet.FirstOrDefault(x=> x.Id == id);
        }

        public void Remove(TEntity entidade)
        {
            var entry = dbContext.Entry(entidade);
            entry.State = EntityState.Deleted;
        }

        public void Update(TEntity entidade)
        {
            var entry = dbContext.Entry(entidade);
            if (entry.State == EntityState.Detached)
                entry.State = EntityState.Modified;
        }

        public virtual void ChangeObjectState(object model, EntityState state)
        {
            //Aqui trocamos o estado do objeto, 
            //facilita quando temos alterações e exclusões
            ((IObjectContextAdapter)this)
                          .ObjectContext
                          .ObjectStateManager
                          .ChangeObjectState(model, state);
        }

        public void Dispose()
        {
            dbContext?.Dispose();
        }
    }
}
