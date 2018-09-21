using APS.Domain.Interfaces.Service;
using APS.Domain.Core.Service;
using APS.Domain.Models.Usurios;
using System.Linq;
using APS.Domain.Interfaces.Repository.Usuario;
using APS.Domain.Core.Interface;
using APS.Domain.Core.Exceptions;
using APS.Domain.Models.Clientes;
using APS.Domain.Models.Agendamentos;
using System;

namespace APS.Domain.Service
{
    public class AgendamentoService : ServiceCRUD<Agendamento>, IAgendamentoService
    {
        

        public AgendamentoService(IAgendamentoRepository agendamentoRepository, IUnitOfWork unitOfWork) :base(unitOfWork, agendamentoRepository)
        {
            
        }

        protected override void ValidarCadastro(Agendamento entidade)
        {           
            this.ValidacaoBasica(entidade);

            ValidarRegras().IsValid();
        }

        protected override void ValidarAtualizar(Agendamento entidade)
        {

            this.ValidacaoBasica(entidade);

            ValidarRegras().IsValid();
        }        


        private void ValidacaoBasica(Agendamento entidade) {
            ValidarRegras(entidade)
                .NotEmpty(x => x.Descricao, "Descrição vazia")
                .NotEmpty(x => x.Endereco, "Endereço vazio")
                .Greater(x => x.Data, DateTime.Now, "Data não pode ser inferior a data atual");
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
