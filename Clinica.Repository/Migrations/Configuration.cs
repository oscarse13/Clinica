namespace Clinica.Repository.Migrations
{
    using Model.Common;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Clinica.Repository.ClinicaDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Clinica.Repository.ClinicaDB context)
        {
            context.Paciente.AddOrUpdate(
             p => p.Id, new Paciente { Id = 1, Documento = 123456789, Edad = 33, Nombre = "Oscar Quiñones", Sexo = "M" }
             );

            context.Paciente.AddOrUpdate(
                p => p.Id, new Paciente { Id = 2, Documento = 987654321, Edad = 30, Nombre = "Andres Quiñones", Sexo = "M" }
                );

            context.Paciente.AddOrUpdate(
                p => p.Id, new Paciente { Id = 3, Documento = 123459876, Edad = 27, Nombre = "Melisa Marin", Sexo = "F" }
                );

            context.TipoCita.AddOrUpdate(
                t => t.Id, new TipoCita { Id = 1, Descripcion = "Medicina General" });

            context.TipoCita.AddOrUpdate(
                t => t.Id, new TipoCita { Id = 2, Descripcion = "Odontología" });

            context.TipoCita.AddOrUpdate(
                t => t.Id, new TipoCita { Id = 3, Descripcion = "Pediatría" });

            context.TipoCita.AddOrUpdate(
                t => t.Id, new TipoCita { Id = 4, Descripcion = "Neurología" });


            context.Usuario.AddOrUpdate(
             p => p.Id, new Usuario { Id = 1, NombreUsuario = "oscarse", Contrasena = "123456", Correo = "oscar@gmail.com", Nombre = "Oscar Quiñones", Rol = "Admin" }
             );

            context.Usuario.AddOrUpdate(
           p => p.Id, new Usuario { Id = 2, NombreUsuario = "otro", Contrasena = "123456", Correo = "otro@gmail.com", Nombre = "Otro Usuario", Rol = "User" }
           );

            context.SaveChanges();
        }
    }
}
