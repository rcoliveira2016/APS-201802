using APS.Domain.Models.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Domain.Models.Agendamentos
{
    public class Agendamento
    {

        public Cliente Cliente { get; set; }
        public DateTime Data { get; set; }
        public DateTime HoraInicial { get; set; }
        public DateTime HoraFinal { get; set; }
        public string Endereço { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

    }
}
