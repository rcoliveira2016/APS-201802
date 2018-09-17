using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Domain.Core.Exceptions
{
    [Serializable]
    public class ServiceException: Exception
    {

        public IEnumerable<string> Mesagens { get; protected set; }

        public ServiceException(string mensagem):base(mensagem)
        {
            this.Mesagens = Enumerable.Empty<string>(); 
        }

        public ServiceException(IEnumerable<string> mesagens) 
            : base(mesagens !=null && mesagens.Any()? mesagens.Aggregate((a,b)=> $@"{a} \n{b}") : string.Empty)
        {
            this.Mesagens = mesagens;
        }
    }
}
