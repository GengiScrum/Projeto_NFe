using Projeto_NFe.Application.Features.Issuers;
using Projeto_NFe.Application.Features.ShippingCompanies;
using Projeto_NFe.Domain.Features.Issuers;
using Projeto_NFe.Domain.Features.ShippingCompanies;
using Projeto_NFe.Infra.ORM.Features.Issuers;
using Projeto_NFe.Infra.ORM.Features.ShippingCompanies;
using Projeto_NFe.Infra.ORM.Contexts;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Projeto_NFe.API.IoC
{
    /// <summary>
    /// Classe responsável por realizar as configurações de injeção de depêndencia.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class SimpleInjectorContainer
    {
        public static Container ContainerInstance { get; private set; }

        public static void Initializer()
        {
            ContainerInstance = new Container();

            RegisterServices();

            ContainerInstance.Verify();
        }

        public static void RegisterServices()
        {
            ContainerInstance.Register<IIssuerService, IssuerService>();
            ContainerInstance.Register<IIssuerRepository, IssuerRepository>();
            ContainerInstance.Register<IShippingCompanyRepository, ShippingCompanyRepository>();
            ContainerInstance.Register<IShippingCompanyService, ShippingCompanyService>();

            // TODO: Por enquanto estaremos criando o context do EF por aqui. Precisaremos trocar por uma Factory
            ContainerInstance.Register<NFeContext>(() => new NFeContext(), Lifestyle.Singleton);
        }
    }
}