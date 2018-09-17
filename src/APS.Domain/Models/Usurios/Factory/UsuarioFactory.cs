

using APS.Domain.Core.Models.Usurios;

namespace APS.Domain.Models.Usurios
{
    public partial class Usuario
    {
        public static Usuario CriarNovo(
                string nome,
                string senha,
                string email,
                string login,
                eTipoUsuario tipoUsuario
            )
        {
            return new Usuario(0)
            {
                Login = login,
                Nome = nome,
                Senha = senha,
                Email = email,
                TipoUsuario = tipoUsuario
            };
        }

        public static Usuario Criar(
                long id,
                string nome,
                string senha,
                string email,
                string login,
                eTipoUsuario tipoUsuario
            )
        {
            return new Usuario(id)
            {
                Login = login,
                Nome = nome,
                Senha = senha,
                Email = email,
                TipoUsuario = tipoUsuario
            };
        }
    }
}
