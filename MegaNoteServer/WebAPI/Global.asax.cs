using Business.Interfaces;
using Business.Services;
using Domain;
using Domain.Repositories;
using Domain.RepositoriesInterfaces;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WebAPI
{
    public class Global : HttpApplication
    {
        public void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            ConfigureContainer();
        }

        private void ConfigureContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();


            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);


            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);


            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            container.Register(() => new StorageContext(connectionString), Lifestyle.Scoped);

            // Register repositories
            container.Register<INoteRepository, NoteRepository>(Lifestyle.Scoped);

            //Register services
            container.Register<INoteService, NoteService>(Lifestyle.Scoped);

            container.Verify();
        }

    }
}