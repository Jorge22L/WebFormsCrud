using DAL.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebFormsCrud
{
    public class Global : HttpApplication
    {
        private static SimpleInjector.Container _container;
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureDependencyInjection();
        }

        private void ConfigureDependencyInjection()
        {
            _container = new SimpleInjector.Container();
            _container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            // Aquí puedes registrar otros repositorios o servicios según sea necesario
            _container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);

            _container.Verify();
        }

        public static T GetInstance<T>() where T : class
        {
            return _container.GetInstance<T>();
        }
    }
}