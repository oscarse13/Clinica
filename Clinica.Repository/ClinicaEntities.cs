using Clinica.Model.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Clinica.Repository
{


    public class ClinicaEntities : Clinica.Repository.Infrastructure.DataContext
    {
        public ClinicaEntities() : base("ClinicaContext")
        {
            Database.SetInitializer<ClinicaEntities>(new CreateDatabaseIfNotExists<ClinicaEntities>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ClinicaEntities, Clinica.Repository.Migrations.Configuration>("ClinicaContext"));
        }

        #region Maestros
        
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<TipoCita> TipoCitas { get; set; }

        public DbSet<Cita> Citas { get; set; }
        #endregion


        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public static ClinicaEntities Create()
        {
            return new ClinicaEntities();
        }

       
    }
}