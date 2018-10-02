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
using System.Collections.Generic;

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
            ValidarRegras().GreaterDateTrunc(x => x.Data, DateTime.Now, "Data não pode ser inferior a data atual");
            ValidarRegras().IsValid();
        }

        protected override void ValidarAtualizar(Agendamento entidade)
        {

            this.ValidacaoBasica(entidade);
            var agendamento = repositorio.Get(entidade.Id);
            if (entidade.Data.Date != agendamento.Data)
                ValidarRegras().GreaterDateTrunc(x => x.Data, DateTime.Now, "Data não pode ser inferior a data atual");
            ValidarRegras().IsValid();
        }        


        private void ValidacaoBasica(Agendamento entidade) {
            ValidarRegras(entidade)
                .NotEmpty(x => x.Descricao, "Descrição vazia")
                .NotEmpty(x => x.Endereco, "Endereço vazio")                
                .Greater(x => x.IdCliente, -1, "Cliente deve ser maior q zero")
                .Greater(x => x.Preco, -1, "Preço deve ser maior q zero")
                .Greater(x => x.HoraFinal, entidade.HoraInicial, "Honar inical não pode ser menor que a final");

        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
