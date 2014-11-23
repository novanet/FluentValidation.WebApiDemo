using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentValidation;
using System.Web.Http;

namespace Fluentvalidation.WebApiDemo.Windsor
{
    public class CustomerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly()
                .BasedOn<ApiController>()
                .WithServiceSelf()
                .LifestylePerWebRequest());
            container.Register(
                Classes.FromThisAssembly()
                .BasedOn(typeof(AbstractValidator<>))
                .WithServiceFirstInterface()
                .LifestylePerWebRequest());
        }
    }
}