using APS.Domain.Interfaces.Service;
using APS.Domain.Core.Service;
using APS.Domain.Models.Usurios;
using System.Linq;
using APS.Domain.Interfaces.Repository.Usuario;
using APS.Domain.Core.Interface;
using APS.Domain.Core.Exceptions;
using APS.Domain.Models.Clientes;

namespace APS.Domain.Service
{
    public class ClienteService : ServiceCRUD<Cliente>, IClienteService
    {
        

        public ClienteService(IClienteRepository clienteRepository, IUnitOfWork unitOfWork) :base(unitOfWork, clienteRepository)
        {
            
        }

        protected override void ValidarCadastro(Cliente entidade)
        {           
            this.ValidacaoBasica(entidade);


            var usuario = repositorio.Find(x => x.Nome == entidade.Nome).FirstOrDefault();
            ValidarRegras(entidade).AddValidacao(() => usuario == null, "Nome do cliente repetido");
            

            ValidarRegras().IsValid();
        }

        protected override void ValidarAtualizar(Cliente entidade)
        {

            this.ValidacaoBasica(entidade);

            ValidarRegras().IsValid();
        }

        protected override void ValidarRemover(Cliente entidade)
        {
            var clienteExixtente = BuscarPorId(entidade.Id);
            ValidarRegras(entidade)
                .AddValidacao(() => !clienteExixtente.Agendamentos.Any(), "Existem dados relacionados a esse cliente")
                .IsValid();
        }

        private void ValidacaoBasica(Cliente entidade) {
            ValidarRegras(entidade)
                .NotEmpty(x => x.Descricao, "Descrição vazia")
                .NotEmpty(x => x.Nome, "Nome vazio")
                .NotEmpty(x => x.Endereco, "Endereço vazio")
                .NotEmpty(x => x.Telefone, "Telefone vazio");                      
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
