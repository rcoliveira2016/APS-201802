namespace APS.Infra.Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agendamentos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agendamentos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IdCliente = c.Long(nullable: false),
                        Data = c.DateTime(nullable: false),
                        HoraInicial = c.DateTime(nullable: false),
                        HoraFinal = c.DateTime(nullable: false),
                        Endereco = c.String(nullable: false, maxLength: 150, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 150, unicode: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.IdCliente)
                .Index(t => t.IdCliente);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agendamentos", "IdCliente", "dbo.Clientes");
            DropIndex("dbo.Agendamentos", new[] { "IdCliente" });
            DropTable("dbo.Agendamentos");
        }
    }
}
