namespace medicofinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        CidadeID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 70),
                    })
                .PrimaryKey(t => t.CidadeID);
            
            CreateTable(
                "dbo.Especialidade",
                c => new
                    {
                        EspecialidadeID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.EspecialidadeID);
            
            CreateTable(
                "dbo.Medico",
                c => new
                    {
                        MedicoID = c.Int(nullable: false, identity: true),
                        EspecialidadeID = c.Int(nullable: false),
                        CidadeID = c.Int(nullable: false),
                        CRM = c.String(nullable: false, maxLength: 10),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Endereco = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false, maxLength: 70),
                        Convenio = c.Boolean(nullable: false),
                        pClinica = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MedicoID)
                .ForeignKey("dbo.Cidade", t => t.CidadeID, cascadeDelete: true)
                .ForeignKey("dbo.Especialidade", t => t.EspecialidadeID, cascadeDelete: true)
                .Index(t => t.EspecialidadeID)
                .Index(t => t.CidadeID);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Login = c.String(nullable: false, maxLength: 20),
                        Senha = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medico", "EspecialidadeID", "dbo.Especialidade");
            DropForeignKey("dbo.Medico", "CidadeID", "dbo.Cidade");
            DropIndex("dbo.Medico", new[] { "CidadeID" });
            DropIndex("dbo.Medico", new[] { "EspecialidadeID" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Medico");
            DropTable("dbo.Especialidade");
            DropTable("dbo.Cidade");
        }
    }
}
