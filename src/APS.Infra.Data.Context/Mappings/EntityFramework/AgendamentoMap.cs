using APS.Domain.Models.Agendamentos;
using APS.Domain.Models.Usurios;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Infra.Data.Context.Mappings.EntityFramework
{
    public sealed class AgendamentoMap : EntityTypeConfiguration<Agendamento>
    {
        public AgendamentoMap()
        {
            ToTable("Agendamentos");

            HasKey(x => x.Id);

            HasRequired(x => x.Cliente)
                .WithMany(x => x.Agendamentos)
                .HasForeignKey(x => x.IdCliente);

            Property(x => x.Data)
                .IsRequired();

            Property(x => x.HoraInicial)
                .IsRequired();

            Property(x => x.HoraFinal)
                .IsRequired();

            Property(x => x.Descricao)
                .HasMaxLength(150)
                .IsRequired();

            Property(x => x.Endereco)
                .HasMaxLength(150)
                .IsRequired();

            Property(x => x.Preco)
                .IsRequired();
        }
    }
}
