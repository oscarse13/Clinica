namespace Clinica.Repository
{
    using Model.Common;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ClinicaDB : Clinica.Repository.Infrastructure.DataContext
    {
        // Your context has been configured to use a 'Clinica' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Clinica.Repository.Clinica' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Clinica' 
        // connection string in the application configuration file.
        public ClinicaDB()
            : base("Clinica")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ClinicaDB, Clinica.Repository.Migrations.Configuration>("Clinica"));
        }


        #region Maestros

        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<TipoCita> TipoCita { get; set; }

        public DbSet<Cita> Cita { get; set; }

        public DbSet<Usuario> Usuario { get; set; }
        #endregion
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}