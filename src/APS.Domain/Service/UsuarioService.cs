using APS.Domain.Interfaces.Service;
using APS.Domain.Core.Service;
using APS.Domain.Models.Usurios;
using System.Linq;
using APS.Domain.Interfaces.Repository.Usuario;
using APS.Domain.Core.Interface;
using APS.Domain.Core.Exceptions;

namespace APS.Domain.Service
{
    public class UsuarioService: ServiceCRUD<Usuario>, IUsuarioService
    {
        

        public UsuarioService(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork) :base(unitOfWork, usuarioRepository)
        {
            
        }

        protected override void ValidarCadastro(Usuario entidade)
        {           
            this.ValidacaoBasica(entidade);


            var usuario = repositorio.Find(x => x.Login == entidade.Login).FirstOrDefault();
            ValidarRegras(entidade).AddValidacao(() => usuario == null, "Login Repitido");
            

            ValidarRegras().IsValid();
        }

        protected override void ValidarAtualizar(Usuario entidade)
        {

            this.ValidacaoBasica(entidade);

            ValidarRegras().IsValid();
        }        


        private void ValidacaoBasica(Usuario entidade) {
            ValidarRegras(entidade)
                .NotEmpty(x => x.Login, "Login vazio")
                .NotEmpty(x => x.Nome, "Nome vazio")
                .NotEmpty(x => x.Senha, "Senha vazio")
                .IsEnum(x => x.TipoUsuario, "Enum inválido");                      
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
