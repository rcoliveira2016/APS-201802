using APS.Domain.Core.Exceptions;
using APS.Domain.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Domain.Core.Validation
{
    public partial class ValidationRule<TEntity> where TEntity : Entity
    {
        public ICollection<string> Errors { get { return _errors; } }
        private readonly List<string> _errors;
        public bool IsValidReturn { get
            {
                if (!_errors.Any())
                    throw new ServiceException(_errors);
                return true;
            }
        }
        private readonly TEntity entity;

        public ValidationRule(TEntity entidade)
        {
            this.entity = entidade;
            this._errors = new List<string>();
        }

        public void AddError(string error)
        {
            _errors.Add(error);
        }

        public void AddError(ICollection<string> errors)
        {
            _errors.AddRange(errors);
        }

        public void IsValid()
        {
            if (_errors.Any())
                throw new ServiceException(_errors);
        }

        public ICollection<string> GetErros()
        {
            return _errors;
        }

    }
}
