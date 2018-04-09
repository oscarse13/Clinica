using Autofac;
using System;
using System.Reflection;
using Autofac.Integration.Mvc;

using System.Web.Mvc;
using Clinica.Repository;
using Clinica.Repository.Infrastructure;
using Clinica.Repository.UnitOfWork;
using Clinica.Repository.DataContext;
using Clinica.Repository.Repositories;

namespace Clinica.WebApi.App_Start
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            //Configure AutoMapper
            //AutoMapperConfiguration.Configure();
        }

        static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ClinicaDB>().As<IDataContextAsync>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWorkAsync>().InstancePerRequest();
           

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .AsClosedTypesOf(typeof(IRepositoryAsync<>)).AsImplementedInterfaces();

            //// Services
            //builder.RegisterAssemblyTypes(typeof(TipRecomendacionService).Assembly)
            //   .Where(t => t.Name.EndsWith("Service"))
            //   .AsImplementedInterfaces().InstancePerRequest();

            //IContainer container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}