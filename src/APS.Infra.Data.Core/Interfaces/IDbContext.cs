using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace APS.Infra.Data.Core.Interfaces
{
    public interface IDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int ExecuteSqlCommand(string sql, params object[] parameters);

        int SaveChanges();

        IEnumerable<TEntity> SqlQuery<TEntity>(string sql, params object[] parameters);
    }
}
