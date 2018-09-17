using APS.Domain.Core.Exceptions;
using APS.Domain.Core.Interface;
using APS.Infra.Data.Core.Interfaces;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace APS.Infra.Data.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext context;
        private bool disposed;

        public UnitOfWork(IDbContext context)
        {
            this.context = context;
        }

        public void BeginTransaction()
        {
            disposed = false;
        }

        public bool Commit()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                var errorMessage = new StringBuilder();
                errorMessage.AppendLine(e.Message);

                var innerException = e.InnerException;
                while (innerException != null)
                {
                    if (innerException.InnerException == null)
                        errorMessage.AppendLine(innerException.Message);
                    innerException = innerException.InnerException;
                }

                var dbEntityValidationException = e as DbEntityValidationException;
                if (dbEntityValidationException != null)
                {
                    dbEntityValidationException.EntityValidationErrors
                        .Where(x => !x.IsValid)
                            .Select(x =>
                                $"Erro de validação da entidade: {x.Entry.Entity.GetType().Name}" +
                                x.ValidationErrors.Select(y => $"{y.PropertyName}: {y.ErrorMessage}").Aggregate((n, k) => $"{n}\n{k}")
                            )
                        .ToList()
                            .ForEach(x => errorMessage.AppendLine(x));
                }
                throw new ServiceException(errorMessage.ToString());
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    context.Dispose();
            }
            disposed = true;
        }
    }
}
