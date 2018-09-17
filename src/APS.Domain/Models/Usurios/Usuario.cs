using APS.Domain.Core.Models.Common;
using APS.Domain.Core.Models.Usurios;

namespace APS.Domain.Models.Usurios
{
    public partial class Usuario : Entity
    {        

        Usuario(long id)
        {
            Id = id;
        }

        protected Usuario() { }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public eTipoUsuario TipoUsuario { get; set; }

    }
}
