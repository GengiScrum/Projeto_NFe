using Microsoft.Owin;
using Owin;
using Projeto_NFe.API.App_Start;
using Projeto_NFe.API.IoC;
using Projeto_NFe.Application.Mapping;
using SimpleInjector.Integration.WebApi;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;

[assembly: OwinStartup(typeof(Projeto_NFe.API.Startup))]
namespace Projeto_NFe.API
{
    /// <summary>
    /// Classe para o inicio da API.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            SimpleInjectorContainer.Initializer();
            AutoMapperInitializer.Initialize();
            HttpConfiguration config = new HttpConfiguration()
            {
                DependencyResolver = new SimpleInjectorWebApiDependencyResolver(SimpleInjectorContainer.ContainerInstance)
            };
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}