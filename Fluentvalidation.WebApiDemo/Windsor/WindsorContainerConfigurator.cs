using Castle.Windsor;
using System.Web.Http;
using WebApiContrib.IoC.CastleWindsor;

namespace Fluentvalidation.WebApiDemo.Windsor
{
    public class WindsorContainerConfigurator
    {
        public IWindsorContainer Configure(HttpConfiguration config)
        {
            var container = new WindsorContainer()
                .Install(new CustomerInstaller());
            config.DependencyResolver = new WindsorResolver(container);
            return container;
        }
    }
}