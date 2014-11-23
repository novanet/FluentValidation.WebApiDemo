using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using FluentValidation.WebApi;
using Fluentvalidation.WebApiDemo.Windsor;

namespace Fluentvalidation.WebApiDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;

            var container = new WindsorContainerConfigurator().Configure(config);
            FluentValidationModelValidatorProvider
                .Configure(config, provider => provider.ValidatorFactory = new WindsorValidatorFactory(container));
            app.UseWebApi(config);
        }
    }
}
