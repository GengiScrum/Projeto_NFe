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
using Projeto_NFe.Application.Features.Addressees;
using Projeto_NFe.Domain.Features.Addressees;
using Projeto_NFe.Infra.ORM.Features.Addressees;
using Projeto_NFe.Application.Features.Products;
using Projeto_NFe.Infra.ORM.Features.Products;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Infra.ORM.Features.Invoices;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Application.Features.Invoices;

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
            ContainerInstance.Register<IShippingCompanyService, ShippingCompanyService>();
            ContainerInstance.Register<IShippingCompanyRepository, ShippingCompanyRepository>();
            ContainerInstance.Register<IAddresseeService, AddresseeService>();
            ContainerInstance.Register<IAddresseeRepository, AddresseReposiotory>();
            ContainerInstance.Register<IProductService, ProductService>();
            ContainerInstance.Register<IProductRepository, ProductRepository>();
            ContainerInstance.Register<IInvoiceService, InvoiceService>();
            ContainerInstance.Register<IInvoiceRepository, InvoiceRepository>();
            // TODO: Por enquanto estaremos criando o context do EF por aqui. Precisaremos trocar por uma Factory
            ContainerInstance.Register<NFeContext>(() => new NFeContext(), Lifestyle.Singleton);
        }
    }
}