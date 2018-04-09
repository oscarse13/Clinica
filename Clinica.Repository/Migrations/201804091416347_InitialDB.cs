namespace Clinica.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Citas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TipoCitaId = c.Short(nullable: false),
                        PacienteId = c.Long(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pacientes", t => t.PacienteId, cascadeDelete: true)
                .ForeignKey("dbo.TipoCitas", t => t.TipoCitaId, cascadeDelete: true)
                .Index(t => t.TipoCitaId)
                .Index(t => t.PacienteId);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Documento = c.Int(nullable: false),
                        Edad = c.Short(nullable: false),
                        Sexo = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoCitas",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        NombreUsuario = c.String(nullable: false, maxLength: 100),
                        Correo = c.String(nullable: false, maxLength: 100),
                        Contrasena = c.String(nullable: false, maxLength: 100),
                        Rol = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Citas", "TipoCitaId", "dbo.TipoCitas");
            DropForeignKey("dbo.Citas", "PacienteId", "dbo.Pacientes");
            DropIndex("dbo.Citas", new[] { "PacienteId" });
            DropIndex("dbo.Citas", new[] { "TipoCitaId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.TipoCitas");
            DropTable("dbo.Pacientes");
            DropTable("dbo.Citas");
        }
    }
}
