using APS.Domain.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Domain.Models.Common.Anexos
{
    public partial class ArquivoFisico
    {
        public byte[] Conteudo { get; private set; }
        public string Caminho { get; private set; }
        public string Nome { get; private set; }

        protected ArquivoFisico() { }

        private void SetarCaminho(string caminho)
        {
            Caminho = caminho;
        }

        public static ArquivoFisico CriarNovo(
                string nome,
                byte[] arquivo
            )
        {
            return new ArquivoFisico()
            {
                Nome = nome,
                Conteudo = arquivo
            };
        }

        public static ArquivoFisico CriarExistente(
                string nome,
                byte[] arquivo
            )
        {
            return new ArquivoFisico()
            {
                Nome = nome,
                Conteudo = arquivo
            };
        }

        public static ArquivoFisico CriarUpload(
                string nome,
                byte[] arquivo
            )
        {
            return new ArquivoFisico()
            {
                Nome = nome,
                Conteudo = arquivo
            };
        }
    }
}
