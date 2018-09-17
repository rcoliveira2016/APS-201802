using APS.Domain.Core.Interface;
using APS.Domain.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using APS.Domain.Core.Exceptions;
using APS.Domain.Core.Validation;

namespace APS.Domain.Core.Service
{
    public abstract class ServiceCRUD<TEntity> : ServiceCommon, IServiceCRUD<TEntity> where TEntity : Entity
    {

        protected readonly IRepository<TEntity> repositorio;
        private ValidationRule<TEntity> validar;

        protected ServiceCRUD(IUnitOfWork unitOfWork, IRepository<TEntity> repositorio) : base(unitOfWork)
        {
            this.repositorio = repositorio;
        }

        #region Metodos Vitual publicos CRUD

        public virtual TEntity BuscarPorId(long id)
        {
            return repositorio.Get(id);
        }

        public virtual ICollection<TEntity> BuscarTodos(Expression<Func<TEntity, bool>> predicate = null)
        {
            return (predicate == null ?
                repositorio.All() :
                repositorio.Find(predicate))?.ToList();
        }

        public virtual void Remover(long id)
        {
            var entidade = BuscarPorId(id);
            ValidarEntidadeNula(entidade);
            ValidarRemover(entidade);
            repositorio.Remove(entidade);
            Commit();
        }
        public virtual void Cadastrar(TEntity entidade)
        {
            ValidarEntidadeNula(entidade);
            ValidarCadastro(entidade);
            repositorio.Add(entidade);
            Commit();
        }

        public virtual void Atualizar(TEntity entidade)
        {
            ValidarEntidadeNula(entidade);
            this.ValidarAtualizar(entidade);
            repositorio.Update(entidade);
            Commit();
        }
        #endregion

        protected virtual void ValidarCadastro(TEntity entidade)
        {
        }

        protected virtual void ValidarAtualizar(TEntity entidade)
        {

        }

        protected virtual void ValidarRemover(TEntity entidade)
        {
        }

        protected void ValidarEntidadeNula(TEntity entidade)
        {
            if (entidade==null)
            {
                throw new ServiceException("A entidade está vazia");
            }
        }

        protected ValidationRule<TEntity> ValidarRegras(TEntity entidade)
        {
            if(this.validar == null)
                this.validar =  new ValidationRule<TEntity>(entidade);

            return this.validar;
        }

        protected ValidationRule<TEntity> ValidarRegras()
        {
            return validar;
        }

        public virtual void Dispose()
        {
            repositorio.Dispose();
        }
    }
}
