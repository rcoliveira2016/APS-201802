using APS.Domain.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Domain.Core.Service
{
    public abstract class ServiceCommon
    {
        private readonly IUnitOfWork unitOfWork;

        protected ServiceCommon(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected void Commit()
        {
            unitOfWork.Commit();
        }
    }
}
