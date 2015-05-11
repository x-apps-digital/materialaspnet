using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;
using Autofac;
using Autofac.Integration.SignalR;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.SignalR;
using Owin;
using SpaApp.Common;
using SpaApp.Models;
using SpaApp.Modules;

namespace SpaApp
{
    public partial class Startup
    {
        public static void ConfigureContainer(IAppBuilder app, HttpConfiguration config)
        {
            IContainer container = CreateContainer(config);

            app.UseAutofacMiddleware(container);

            // Set the WebApi dependency resolver to be Autofac.
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Set the SignalR dependency resolver to be Autofac.
            GlobalHost.DependencyResolver = new AutofacDependencyResolver(container);

            // Set the ServiceLocator provider to be Autofac.
            //var serviceLocator = new AutofacServiceLocator(container);
            //ServiceLocator.SetLocatorProvider(() => serviceLocator);

            
        }

        private static IContainer CreateContainer(HttpConfiguration config)
        {
            ContainerBuilder builder = new ContainerBuilder();

            Assembly assembly = Assembly.GetExecutingAssembly();
            
            RegisterWebApi(builder, config, assembly);
            RegisterSignalR(builder, assembly);
            RegisterServices(builder);

            IContainer container = builder.Build();

            return container;
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IRepository<User>>();
            

            builder.RegisterModule<LoggingModule>();
        }

        private static void RegisterSignalR(ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterHubs(assembly);
        }

        private static void RegisterWebApi(ContainerBuilder builder, HttpConfiguration config, Assembly assembly)
        {
            builder.RegisterApiControllers(assembly);

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);
        }
    }
}