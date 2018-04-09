using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using Clinica.Service;
using System.Web.Mvc;
using System.Web.Http;

namespace Clinica.WebApi
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            //registering Unity for web API
            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            IUnityContainer container = new UnityContainer()
          .RegisterType<IControllerActivator, CustomControllerActivator>()
          .RegisterType<ICitaService, CitaService>()
          .RegisterType<IPacienteService, PacienteService>()
          .RegisterType<ITipoCitaService, TipoCitaService>();

            return container;
        }
    }
}