using APS.Domain.Core.Models.Common;
using APS.Infra.Data.Core.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;


namespace APS.Infra.Data.Core.Config
{
    public abstract class BaseDbContext : DbContext, IDbContext
    {
        protected BaseDbContext(string connectionStringName) : base(connectionStringName) { }

        public int ExecuteSqlCommand(string sql, params object[] parameters) =>
            Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, sql, parameters);

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : Entity => base.Set<TEntity>();

        public IEnumerable<TEntity> SqlQuery<TEntity>(string sql, params object[] parameters) =>
            Database.SqlQuery<TEntity>(sql, parameters);
    }
}
