using APS.Domain.Models.Clientes;
using APS.Domain.Models.Usurios;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Infra.Data.Context.Mappings.EntityFramework
{
    public sealed class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable("Clientes");

            HasKey(x => x.Id);

            Property(x => x.Nome)
                .HasMaxLength(150)
                .IsRequired();

            Property(x => x.Descricao)
                .HasMaxLength(1000)
                .IsRequired();

            Property(x => x.Endereco)
                .HasMaxLength(500)
                .IsRequired();

            Property(x => x.Telefone)
                .HasMaxLength(20)
                .IsRequired();

            Property(x => x.Ativo)
                .IsRequired();
        }
    }
}
