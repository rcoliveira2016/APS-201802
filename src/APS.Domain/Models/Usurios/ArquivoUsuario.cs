using APS.Domain.Core.Models.Common;
using APS.Domain.Models.Common.Anexos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Domain.Models.Usurios
{
    public partial class ArquivoUsuario:Entity
    {
        public virtual Usuario Usuario { get; private set; }        

        public ArquivoFisico Arquivo { get; private set; }

    }
}
