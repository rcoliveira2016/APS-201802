using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APS.Domain.Core.Validation
{
    public partial class ValidationRule<TEntity>
    {
        public ValidationRule<TEntity> AddValidacao(Func<bool> func, string error)
        {
            if (!func.Invoke())
                _errors.Add(error);

            return this;
        }

        #region Length

        public ValidationRule<TEntity> Length(Func<TEntity, string> func, int min, int max, string mensagem)
        {
            var retorno = func.Invoke(entity);
            if (string.IsNullOrEmpty(retorno) || !(retorno.Length >= min && retorno.Length <= max))
                _errors.Add(mensagem);
            return this;
        }
        #endregion

        #region NotEmpty
        public ValidationRule<TEntity> NotEmpty<R>(Func<TEntity, R> func, string mensagem) where R : class
        {
            var r = func.Invoke(entity) as string;
            if (r == null)
            {
                _errors.Add(mensagem);
                return this;
            }

            if (string.IsNullOrEmpty(r))
                _errors.Add(mensagem);
            return this;
        }

        public ValidationRule<TEntity> NotEmpty<T>(Func<TEntity, IEnumerable<T>> func, string mensagem)
        {
            var r = func.Invoke(entity);
            if (r == null || !r.Any())
                _errors.Add(mensagem);
            return this;
        }

        public ValidationRule<TEntity> NotEmpty<T>(Func<TEntity, T[]> func, string mensagem)where T:struct
        {
            var r = func.Invoke(entity);
            if (r == null || !r.Any())
                _errors.Add(mensagem);
            return this;
        }
        #endregion

        public ValidationRule<TEntity> Equals<R>(Func<TEntity, R> objectPrimary, Func<TEntity, R> objectSecond, string mensagem) where R : class
        {
            var p = objectPrimary.Invoke(entity);
            var s = objectSecond.Invoke(entity);
            if (!p.Equals(s))
                _errors.Add(mensagem);
            return this;
        }

        public ValidationRule<TEntity> IsValidEmail(Func<TEntity, string> func, string mensagem)
        {
            var email = func.Invoke(entity);

            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (!rg.IsMatch(email))
                _errors.Add(mensagem);

            return this;
        }

        public ValidationRule<TEntity> IsEnum<TEnum>(Func<TEntity, TEnum> func, string mensagem)
        {
            var @enum = func.Invoke(entity);

            if (!(@enum is Enum))
                _errors.Add(mensagem);

            return this;
        }

        public ValidationRule<TEntity> NotNull<R>(Func<TEntity, R> func, string mensagem)
        {
            var r = func.Invoke(entity);
            if (r == null)
                _errors.Add(mensagem);
            return this;
        }

        public ValidationRule<TEntity> Greater<R>(Func<TEntity, R> func, R number, string mensagem) where R: struct, IComparable, IComparable<R>
        {
            var r = func.Invoke(entity);
            if (r.CompareTo(number) < 0)
                _errors.Add(mensagem);
            return this;
        }

        public ValidationRule<TEntity> GreaterDateTrunc(Func<TEntity, DateTime> func, DateTime date, string mensagem)
        {
            var r = func.Invoke(entity).Date;           
            if (r.CompareTo(date.Date) < 0)
                _errors.Add(mensagem);
            return this;
        }
    }
}
