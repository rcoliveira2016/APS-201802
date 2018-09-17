using APS.Domain.Models.Common.Anexos;

namespace APS.Domain.Models.Usurios
{
    public partial class ArquivoUsuario
    {
        public static ArquivoUsuario CriarNovo(
                string nome,
                byte[] arquivo
            )
        {
            return new ArquivoUsuario()
            {
                Id = 0,
                Arquivo = ArquivoFisico.CriarExistente(
                        nome,
                        arquivo
                    )
            };
        }

        public static ArquivoUsuario CriarUpload(
                long id,
                string nome,
                byte[] arquivo
            )
        {
            return new ArquivoUsuario()
            {
                Id = id,
                Arquivo = ArquivoFisico.CriarUpload(
                        nome,
                        arquivo
                    )
            };
        }

        public static ArquivoUsuario CriarExistente(
                long id,
                string nome,
                byte[] arquivo
            )
        {
            return new ArquivoUsuario()
            {
                Id = id,
                Arquivo = ArquivoFisico.CriarExistente(
                        nome,
                        arquivo
                    )
            };
        }
    }
}
