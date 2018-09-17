using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace APS.Domain.Core.Interface
{
    public interface IServiceCRUD<TEntity> : IDisposable
    {
        void Cadastrar(TEntity entidade);
        void Atualizar(TEntity entidade);
        void Remover(long id);


        ICollection<TEntity> BuscarTodos(Expression<Func<TEntity, bool>> predicate = null);
        TEntity BuscarPorId(long id);
        
    }
}
