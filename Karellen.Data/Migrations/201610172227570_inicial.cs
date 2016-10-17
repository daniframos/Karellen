namespace Karellen.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBGrupo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBUsuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Sobrenome = c.String(maxLength: 100),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        Senha = c.String(),
                        Cidade = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBLoginExterno",
                c => new
                    {
                        LoginProvedor = c.String(nullable: false, maxLength: 128),
                        KeyProvedor = c.String(nullable: false, maxLength: 128),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvedor, t.KeyProvedor, t.UsuarioId })
                .ForeignKey("dbo.TBUsuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.TBOcorrencia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        DataAcontecimento = c.DateTime(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataResolucao = c.DateTime(),
                        Excluida = c.Boolean(nullable: false),
                        SexoVitima = c.Int(nullable: false),
                        Detalhes = c.String(),
                        HaBoletimDeOcorrencia = c.Boolean(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBUsuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.TBTipoOcorrencia",
                c => new
                    {
                        OcorrenciaId = c.Int(nullable: false),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OcorrenciaId, t.Tipo })
                .ForeignKey("dbo.TBOcorrencia", t => t.OcorrenciaId)
                .Index(t => t.OcorrenciaId);
            
            CreateTable(
                "dbo.TBLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ip = c.String(),
                        Local = c.String(),
                        UserAgent = c.String(),
                        Browser = c.String(),
                        Data = c.DateTime(nullable: false),
                        SessaoId = c.Guid(nullable: false),
                        EntidadeNome = c.String(),
                        EntidadeId = c.String(),
                        Acao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBUsuarioGrupo",
                c => new
                    {
                        GrupoId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GrupoId, t.UsuarioId })
                .ForeignKey("dbo.TBGrupo", t => t.GrupoId, cascadeDelete: true)
                .ForeignKey("dbo.TBUsuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.GrupoId)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBUsuarioGrupo", "UsuarioId", "dbo.TBUsuario");
            DropForeignKey("dbo.TBUsuarioGrupo", "GrupoId", "dbo.TBGrupo");
            DropForeignKey("dbo.TBOcorrencia", "UsuarioId", "dbo.TBUsuario");
            DropForeignKey("dbo.TBTipoOcorrencia", "OcorrenciaId", "dbo.TBOcorrencia");
            DropForeignKey("dbo.TBLoginExterno", "UsuarioId", "dbo.TBUsuario");
            DropIndex("dbo.TBUsuarioGrupo", new[] { "UsuarioId" });
            DropIndex("dbo.TBUsuarioGrupo", new[] { "GrupoId" });
            DropIndex("dbo.TBTipoOcorrencia", new[] { "OcorrenciaId" });
            DropIndex("dbo.TBOcorrencia", new[] { "UsuarioId" });
            DropIndex("dbo.TBLoginExterno", new[] { "UsuarioId" });
            DropTable("dbo.TBUsuarioGrupo");
            DropTable("dbo.TBLog");
            DropTable("dbo.TBTipoOcorrencia");
            DropTable("dbo.TBOcorrencia");
            DropTable("dbo.TBLoginExterno");
            DropTable("dbo.TBUsuario");
            DropTable("dbo.TBGrupo");
        }
    }
}
