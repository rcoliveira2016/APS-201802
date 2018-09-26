using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Application.ViewModel.Agendamentos
{
    public class CadastroViewModel
    {
        public long Id { get; set; }
        public long IdCliente { get; set; }
        public string Cliente { get; set; }
        public string Data { get; set; }
        public string DataNumero { get; set; }
        public string HoraInicial { get; set; }
        public string HoraFinal { get; set; }
        public string Endereco { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
    }
}
