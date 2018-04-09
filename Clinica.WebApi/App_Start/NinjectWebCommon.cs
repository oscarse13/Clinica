using System.Data.Entity;
using System.Web.Http;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Clinica.WebApi.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Clinica.WebApi.NinjectWebCommon), "Stop")]

namespace Clinica.WebApi
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Repository;
    using Service;
    using Clinica.Repository.Repositories;
    using Model.Common;
    using Repository.Infrastructure;
    using Repository.DataContext;
    using Repository.UnitOfWork;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                kernel.Bind<ClinicaDB>().ToSelf().InRequestScope();

                RegisterServices(kernel);

                // Install our Ninject-based IDependencyResolver into the Web API config
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<DbContext>().To<ClinicaDB>().InRequestScope();
            kernel.Bind<IDataContextAsync>().To<ClinicaDB>().InRequestScope().Named("Clinica");
            kernel.Bind<IUnitOfWorkAsync>().To<UnitOfWork>().InRequestScope();
            //Repositories;
            kernel.Bind<IRepository<Cita>>().To<RepositoryCita>().InRequestScope();
            kernel.Bind<IRepository<TipoCita>>().To<RepositoryTipoCita>().InRequestScope();
            kernel.Bind<IRepository<Paciente>>().To<RepositoryPaciente>().InRequestScope();
            kernel.Bind<IRepository<Usuario>>().To<RepositoryUsuario>().InRequestScope();

            //Services
            kernel.Bind<ICitaService>().To<CitaService>().InRequestScope();
            kernel.Bind<ITipoCitaService>().To<TipoCitaService>().InRequestScope();
            kernel.Bind<IPacienteService>().To<PacienteService>().InRequestScope();
            kernel.Bind<IUsuarioService>().To<UsuarioService>().InRequestScope();
        }
    }
}