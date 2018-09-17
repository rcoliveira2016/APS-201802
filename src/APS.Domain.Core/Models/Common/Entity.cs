using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Domain.Core.Models.Common
{
    public class Entity
    {
        public long Id { get; set; }

        public bool IsNew { get => Id <= 0; }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
