using Projeto_NFe.Domain.Features.Issuers;
using Projeto_NFe.Domain.Features.ShippingCompanies;
using Projeto_NFe.Domain.Utils;
using Projeto_NFe.Domain.Features.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Features.Addressees;
using Projeto_NFe.Application.Features.Products;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.InvoiceTaxes;
using Projeto_NFe.Domain.Features.ProductTaxes;
using Projeto_NFe.Application.Features.Issuers.Commands;
using Projeto_NFe.Application.Features.ShippingCompanies.Commands;
using Projeto_NFe.Application.Features.Addressees.Commands;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Application.Features.Products.Commands;
using Projeto_NFe.Domain.Features.SoldProducts;
using Projeto_NFe.Application.Features.Addresses.Commands;
using Projeto_NFe.Application.Features.Invoices.Commands;
using Projeto_NFe.Application.Features.SoldProducts.Commands;

namespace Projeto_NFe.Common.Tests
{
    public static partial class ObjectMother
    {
        #region Issuer
        public static IssuerRegisterCommand IssuerCommandToRegister()
        {
            IssuerRegisterCommand issuer = new IssuerRegisterCommand();
            issuer.BusinessName = "NDDIGITAL";
            issuer.CorporateName = "NDDIGITAL S/A - SOFTWARE";
            issuer.Cnpj = "12.345.678/0009-09";
            issuer.StateRegistration = "12.234.5678-9";
            issuer.MunicipalRegistration = "1234";
            issuer.Address = AddressCommandToRegister();
            return issuer;
        }
        public static IssuerRemoveCommand IssuerCommandToRemove()
        {
            return new IssuerRemoveCommand()
            {
                IssuersId = new int[] { 1 },
            };
        }
        public static IssuerUpdateCommand IssuerCommandToUpdate()
        {
            IssuerUpdateCommand issuer = new IssuerUpdateCommand();
            issuer.Id = 1;
            issuer.BusinessName = "NDDIGITAL";
            issuer.CorporateName = "NDDIGITAL S/A - SOFTWARE";
            issuer.Cnpj = "12.345.678/0009-09";
            issuer.StateRegistration = "12.234.5678-9";
            issuer.MunicipalRegistration = "1234";
            issuer.Address = AddressCommandToRegister();
            return issuer;
        }
        public static Issuer IssuerValidWithIdAndWithAddress()
        {
            Issuer issuer = new Issuer();
            issuer.Id = 1;
            issuer.BusinessName = "NDDIGITAL";
            issuer.CorporateName = "NDDIGITAL S/A - SOFTWARE";
            issuer.Cnpj = "12.345.678/0009-09";
            issuer.StateRegistration = "12.234.5678-9";
            issuer.MunicipalRegistration = "1234";
            issuer.Address = AddressValid();
            return issuer;
        }
        public static Issuer IssuerValidWithoutIdAndWithAddress()
        {
            Issuer issuer = new Issuer();
            issuer.BusinessName = "NDDIGITAL";
            issuer.CorporateName = "NDDIGITAL S/A - SOFTWARE";
            issuer.Cnpj = "12.345.678/0009-09";
            issuer.StateRegistration = "12.234.5678-9";
            issuer.MunicipalRegistration = "1234";
            issuer.Address = AddressValid();
            return issuer;
        }
        #endregion

        #region Address
        public static AddressCommand AddressCommandToRegister()
        {
            AddressCommand address = new AddressCommand();
            address.StreetName = "Rua Avenida";
            address.Number = 400;
            address.Neighborhood = "Coral";
            address.City = "Lages";
            address.State = "SC";
            address.Country = "Brasil";
            return address;
        }

        public static Address AddressValid()
        {
            Address address = new Address();
            address.StreetName = "Rua Avenida";
            address.Number = 400;
            address.Neighborhood = "Coral";
            address.City = "Lages";
            address.State = "SC";
            address.Country = "Brasil";
            return address;
        }
        #endregion

        #region ShippingCompany
        public static ShippingCompanyRegisterCommand ShippingCompanyCommandToRegister()
        {
            ShippingCompanyRegisterCommand shippingCompany = new ShippingCompanyRegisterCommand();
            shippingCompany.BusinessName = "NDDIGITAL";
            shippingCompany.CorporateName = "NDDIGITAL S/A - SOFTWARE";
            shippingCompany.Cnpj = "12.345.678/0009-09";
            shippingCompany.StateRegistration = "12.234.5678-9";
            shippingCompany.Address = new AddressCommand
            {
                StreetName = "Rua Avenida",
                Number = 400,
                Neighborhood = "Coral",
                City = "Lages",
                State = "SC",
                Country = "Brasil"
            };
            return shippingCompany;
        }

        public static ShippingCompanyUpdateCommand ShippingCompanyCommandToUpdate()
        {
            ShippingCompanyUpdateCommand shippingCompany = new ShippingCompanyUpdateCommand();
            shippingCompany.Id = 1;
            shippingCompany.BusinessName = "NDDIGITAL";
            shippingCompany.CorporateName = "NDDIGITAL S/A - SOFTWARE";
            shippingCompany.Cnpj = "12.345.678/0009-09";
            shippingCompany.StateRegistration = "12.234.5678-9";
            shippingCompany.Address = new AddressCommand
            {
                StreetName = "Rua Avenida",
                Number = 400,
                Neighborhood = "Coral",
                City = "Lages",
                State = "SC",
                Country = "Brasil"
            };
            return shippingCompany;
        }

        public static ShippingCompanyRemoveCommand ShippingCompanyCommandToRemove()
        {
            return new ShippingCompanyRemoveCommand()
            {
                Ids = new int[] { 1 },
            };
        }

        public static ShippingCompany ShippingCompanyValidWithoutIdWithAddress()
        {
            ShippingCompany shippingCompany = new ShippingCompany();

            shippingCompany.BusinessName = "Letícia";
            shippingCompany.Address = AddressValid();
            shippingCompany.Cpf = "12345678901";
            shippingCompany.PersonType = EnumPersonType.PessoaFisica;
            shippingCompany.ShippingResponsability = true;

            return shippingCompany;
        }

        public static ShippingCompany ShippingCompanyValidWithIdWithAddress()
        {
            ShippingCompany shippingCompany = new ShippingCompany();

            shippingCompany.Id = 1;
            shippingCompany.BusinessName = "Letícia";
            shippingCompany.Address = AddressValid();
            shippingCompany.Cpf = "12345678901";
            shippingCompany.PersonType = EnumPersonType.PessoaFisica;
            shippingCompany.ShippingResponsability = true;

            return shippingCompany;
        }

        public static ShippingCompany ShippingCompanyPessoaFisicaValida(Address address)
        {
            ShippingCompany t = new ShippingCompany
            {
                Id = 1,
                BusinessName = "Sedex",
                Address = address,
                Cpf = "12345678901",
                PersonType = EnumPersonType.PessoaFisica,
                ShippingResponsability = true
            };
            return t;
        }

        public static ShippingCompany ShippingCompanyPessoaJuridicaValida(Address address)
        {
            return new ShippingCompany
            {
                Id = 1,
                BusinessName = "Sedex",
                CorporateName = "Lages Ltda",
                StateRegistration = "128398213791",
                Address = address,
                Cnpj = "12345678901234",
                PersonType = EnumPersonType.PessoaJuridica,
                ShippingResponsability = false
            };
        }
        #endregion

        #region Addressee
        public static AddresseeRegisterCommand AddresseeCommandToRegister()
        {
            AddresseeRegisterCommand addressee = new AddresseeRegisterCommand();
            addressee.BusinessName = "NDDIGITAL";
            addressee.CorporateName = "NDDIGITAL S/A - SOFTWARE";
            addressee.Cnpj = "12.345.678/0009-09";
            addressee.StateRegistration = "12.234.5678-9";
            addressee.Address = AddressCommandToRegister();
            return addressee;
        }

        public static AddresseeUpdateCommand AddresseeCommandToUpdate()
        {
            AddresseeUpdateCommand addressee = new AddresseeUpdateCommand();
            addressee.Id = 1;
            addressee.BusinessName = "NDDIGITAL";
            addressee.CorporateName = "NDDIGITAL S/A - SOFTWARE";
            addressee.Cnpj = "12.345.678/0009-09";
            addressee.StateRegistration = "12.234.5678-9";
            addressee.Address = AddressCommandToRegister();
            return addressee;
        }

        public static AddresseeRemoveCommand AddresseeCommandToRemove()
        {
            return new AddresseeRemoveCommand()
            {
                AddresseesId = new int[] { 1 },
            };
        }

        public static Addressee AddresseeValidWithoutIdWithAddress()
        {
            Addressee addressee = new Addressee();

            addressee.BusinessName = "Bruno Barba";
            addressee.Address = AddressValid();
            addressee.Cpf = "12345678901";
            addressee.PersonType = EnumPersonType.PessoaFisica;

            return addressee;
        }

        public static Addressee AddresseeValidWithIdWithAddress()
        {
            Addressee addressee = new Addressee();

            addressee.Id = 1;
            addressee.BusinessName = "Bruno Barba";
            addressee.CorporateName = "Bruno Barba ltda";
            addressee.Address = AddressValid();
            addressee.Cpf = "12345678901";
            addressee.PersonType = EnumPersonType.PessoaFisica;

            return addressee;
        }

        public static Addressee AddresseeValidComCnpjWithIdWithAddress()
        {
            Addressee addressee = new Addressee();

            addressee.Id = 1;
            addressee.BusinessName = "Bruno Barba";
            addressee.CorporateName = "Bruno Barba";
            addressee.Address = AddressValid();
            addressee.Cnpj = "12345678901234";
            addressee.StateRegistration = "89032487087";
            addressee.PersonType = EnumPersonType.PessoaJuridica;

            return addressee;
        }

        public static Addressee AddresseePessoaFisicaValida(Address address)
        {
            return new Addressee
            {
                Id = 1,
                BusinessName = "Comprador",
                Address = address,
                Cpf = "12345678901",
                PersonType = EnumPersonType.PessoaFisica
            };
        }
        public static Addressee AddresseePessoaJuridicaValida(Address address)
        {
            return new Addressee
            {
                Id = 1,
                BusinessName = "Lenew",
                CorporateName = "Notebooks",
                StateRegistration = "128398213791",
                Address = address,
                Cnpj = "12345678901234",
                PersonType = EnumPersonType.PessoaJuridica
            };
        }
        #endregion

        #region Product
        public static ProductRegisterCommand ProductCommandToRegister()
        {
            ProductRegisterCommand product = new ProductRegisterCommand();

            product.Code = "ABY-Y7ASA";
            product.Description = "Bolacha Maria";
            product.UnitaryValue = 10.00;

            return product;
        }

        public static ProductUpdateCommand ProductCommandToUpdate()
        {
            ProductUpdateCommand product = new ProductUpdateCommand();

            product.Code = "ABY-Y7ASA";
            product.Description = "Bolacha Maria";
            product.UnitaryValue = 10.00;

            return product;
        }

        public static ProductRemoveCommand ProductCommandToRemove()
        {
            return new ProductRemoveCommand()
            {
                ProductsId = new int[] { 1 }
            };
        }

        public static Product ProductValidWithoutId()
        {
            Product product = new Product();

            product.Code = "1A12312BC123";
            product.Description = "Bolacha Negresco";
            product.UnitaryValue = 2.00;

            return product;
        }

        public static Product ProductValidWithId()
        {
            Product product = new Product();

            product.Id = 1;
            product.Code = "1A12312BC123";
            product.Description = "Bolacha Negresco";
            product.UnitaryValue = 2.00;

            return product;
        }
        #endregion

        #region SoldProduct
        public static SoldProduct SoldProductValidWithId()
        {
            SoldProduct soldProduct = new SoldProduct();

            soldProduct.Id = 1;
            soldProduct.Product = ProductValidWithId();
            soldProduct.Quantity = 2;

            return soldProduct;
        }

        public static SoldProduct SoldProductValidWithoutId()
        {
            SoldProduct soldProduct = new SoldProduct();

            soldProduct.Product = ProductValidWithId();
            soldProduct.Product.Tax = new ProductTax() { IcmsAliquot = 4, IpiAliquot = 10 };
            soldProduct.Quantity = 2;

            return soldProduct;
        }

        public static SoldProductRegisterCommand SoldProductRegisterCommand(int invoiceId)
        {
            SoldProductRegisterCommand soldProduct = new SoldProductRegisterCommand();

            soldProduct.Quantity = 2;
            soldProduct.ProductId = 1;

            return soldProduct;
        }

        public static SoldProduct SoldProductFull(Product product)
        {
            return new SoldProduct
            {
                Id = 1,
                Product = product,
                Quantity = 2,
            };
        }

        #endregion

        #region Invoice
        public static InvoiceRegisterCommand InvoiceCommandToRegister(int issuerId, int addresseeId, int shippingCompanyId)
        {
            InvoiceRegisterCommand invoice = new InvoiceRegisterCommand();
            invoice.OperationNature = "Venda";
            invoice.EntryDate = DateTime.Now;
            invoice.IssuerId = issuerId;
            invoice.AddresseeId = addresseeId;
            invoice.ShippingCompanyId = shippingCompanyId;
            invoice.SoldProducts = new List<SoldProductRegisterCommand>() { SoldProductRegisterCommand(1) };
            return invoice;
        }

        public static InvoiceAddProductCommand InvoiceAddProductCommand()
        {
            return new InvoiceAddProductCommand
            {
                Id = 1,
                SoldProduct = new SoldProductRegisterCommand
                {
                    ProductId = 1,
                    Quantity = 2
                }
            };
        }

        public static InvoiceRemoveProductsCommand InvoiceRemoveProducstCommand()
        {
            return new InvoiceRemoveProductsCommand
            {
                Id = 1,
                SoldProductsIds = new int[] {1, 2}
            };
        }

        public static InvoiceUpdateCommand InvoiceCommandToUpdate(int issuerId, int addresseeId, int shippingCompanyId)
        {
            InvoiceUpdateCommand invoice = new InvoiceUpdateCommand();
            invoice.Id = 1;
            invoice.OperationNature = "Venda";
            invoice.EntryDate = DateTime.Now;
            invoice.IssuerId = issuerId;
            invoice.AddresseeId = addresseeId;
            invoice.ShippingCompanyId = shippingCompanyId;
            return invoice;
        }

        public static InvoiceRemoveCommand InvoiceCommandToRemove()
        {
            return new InvoiceRemoveCommand()
            {
                InvoicesId = new int[] { 1 }
            };
        }

        public static Invoice InvoiceWithoutIdNeedMock()
        {
            Invoice invoice = new Invoice();
            invoice.OperationNature = "Venda";
            invoice.EntryDate = DateTime.Now;
            invoice.AcessKey = "111111111111111111111111";
            return invoice;
        }

        public static Invoice InvoiceValidWithIdWithoutIssuerAddresseeShippingCompanyId()
        {
            Invoice invoice = new Invoice();
            invoice.Id = 1;
            invoice.OperationNature = "Venda";
            invoice.EntryDate = DateTime.Now;
            invoice.AcessKey = "BAJDSA0123IU43I249206954";
            invoice.Issuer = IssuerValidWithoutIdAndWithAddress();
            invoice.Addressee = AddresseeValidWithoutIdWithAddress();
            invoice.ShippingCompany = ShippingCompanyValidWithoutIdWithAddress();
            invoice.SoldProducts = new List<SoldProduct>() { SoldProductValidWithoutId() };
            invoice.InvoiceTax = new InvoiceTax();
            return invoice;
        }

        public static Invoice InvoiceValidWithId()
        {
            Invoice invoice = new Invoice();
            invoice.Id = 1;
            invoice.OperationNature = "Venda";
            invoice.EntryDate = DateTime.Now;
            invoice.AcessKey = "BAJDSA0123IU43I249206954";
            invoice.Issuer = IssuerValidWithIdAndWithAddress();
            invoice.Addressee = AddresseeValidWithIdWithAddress();
            invoice.ShippingCompany = ShippingCompanyValidWithIdWithAddress();
            invoice.SoldProducts = new List<SoldProduct>() { SoldProductValidWithoutId() };
            invoice.InvoiceTax = new InvoiceTax();
            return invoice;
        }
        public static Invoice InvoiceValidWithoutIdWithIssuerAddresseeShippingCompanyId(int issuerId, int addresseeId, int shippingCompanyId)
        {
            Invoice invoice = new Invoice();
            invoice.OperationNature = "Venda";
            invoice.EntryDate = DateTime.Now;
            invoice.AcessKey = "BAJDSA0123IU43I249206954";
            invoice.IssuerId = issuerId;
            invoice.AddresseeId = addresseeId;
            invoice.ShippingCompanyId = shippingCompanyId;
            invoice.SoldProducts = new List<SoldProduct>() { SoldProductValidWithId() };
            return invoice;
        }
        #endregion

        #region Issued Invoice
        public static Invoice IssuedInvoiceValidWithoutId()
        {
            Invoice invoice = new Invoice();
            invoice.OperationNature = "Venda";
            invoice.EntryDate = DateTime.Now;
            invoice.AcessKey = "BAJDSA0123IU43I249206954";
            invoice.Issuer = IssuerValidWithoutIdAndWithAddress();
            invoice.Addressee = AddresseeValidWithoutIdWithAddress();
            invoice.ShippingCompany = ShippingCompanyValidWithoutIdWithAddress();
            invoice.SoldProducts = new List<SoldProduct>() { SoldProductValidWithoutId() };
            invoice.InvoiceTax = new InvoiceTax();
            return invoice;
        }
        public static Invoice IssuedInvoiceValidWithId()
        {
            Invoice invoice = new Invoice();
            invoice.Id = 1;
            invoice.OperationNature = "Venda";
            invoice.EntryDate = DateTime.Now;
            invoice.IssueDate = DateTime.Now;
            invoice.AcessKey = "BAJDSA0123IU43I249206954";
            invoice.Issuer = IssuerValidWithoutIdAndWithAddress();
            invoice.Addressee = AddresseeValidWithoutIdWithAddress();
            invoice.ShippingCompany = ShippingCompanyValidWithoutIdWithAddress();
            invoice.SoldProducts = new List<SoldProduct>() { SoldProductValidWithoutId() };
            invoice.InvoiceTax = new InvoiceTax();
            invoice.CalculateTax();
            invoice.InvoiceTax.ShippingValue = 10;
            return invoice;
        }

        public static Invoice IssuedInvoiceValidWithShippingCompanyLegalPerson()
        {
            Invoice invoice = new Invoice();
            invoice.Id = 1;
            invoice.OperationNature = "Venda";
            invoice.EntryDate = DateTime.Now;
            invoice.IssueDate = DateTime.Now;
            invoice.AcessKey = "BAJDSA0123IU43I249206954";
            invoice.Issuer = IssuerValidWithoutIdAndWithAddress();
            invoice.Addressee = AddresseeValidWithoutIdWithAddress();
            invoice.ShippingCompany = ShippingCompanyPessoaJuridicaValida(AddressValid());
            List<SoldProduct> productsSold = new List<SoldProduct>();
            for (int i = 0; i < 20; i++)
            {
                SoldProduct soldProduct = SoldProductValidWithoutId();
                soldProduct.Product.Code = i.ToString();
                productsSold.Add(soldProduct);
            }
            invoice.SoldProducts = productsSold;
            invoice.InvoiceTax = new InvoiceTax();
            invoice.CalculateTax();
            invoice.InvoiceTax.ShippingValue = 10;
            return invoice;
        }

        public static Invoice IssuedInvoiceValidWithShippingCompanyPerson()
        {
            Invoice invoice = new Invoice();
            invoice.Id = 1;
            invoice.OperationNature = "Venda";
            invoice.EntryDate = DateTime.Now;
            invoice.IssueDate = DateTime.Now;
            invoice.AcessKey = "BAJDSA0123IU43I249206954";
            invoice.Issuer = IssuerValidWithoutIdAndWithAddress();
            invoice.Addressee = AddresseeValidWithoutIdWithAddress();
            invoice.ShippingCompany = ShippingCompanyPessoaFisicaValida(AddressValid());
            List<SoldProduct> productsSold = new List<SoldProduct>();
            for (int i = 0; i < 20; i++)
            {
                SoldProduct soldProduct = SoldProductValidWithoutId();
                soldProduct.Product.Code = i.ToString();
                productsSold.Add(soldProduct);
            }
            invoice.SoldProducts = productsSold;
            invoice.InvoiceTax = new InvoiceTax();
            invoice.CalculateTax();
            invoice.InvoiceTax.ShippingValue = 10;
            return invoice;
        }

        public static Invoice IssuedInvoiceValidWithoutShippingCompanyWithAddresseePerson()
        {
            Invoice invoice = new Invoice();
            invoice.Id = 1;
            invoice.OperationNature = "Venda";
            invoice.EntryDate = DateTime.Now;
            invoice.IssueDate = DateTime.Now;
            invoice.AcessKey = "BAJDSA0123IU43I249206954";
            invoice.Issuer = IssuerValidWithoutIdAndWithAddress();
            invoice.Addressee = AddresseePessoaFisicaValida(AddressValid());
            invoice.ShippingCompany = null;
            List<SoldProduct> productsSold = new List<SoldProduct>();
            for (int i = 0; i < 20; i++)
            {
                SoldProduct soldProduct = SoldProductValidWithoutId();
                soldProduct.Product.Code = i.ToString();
                productsSold.Add(soldProduct);
            }
            invoice.SoldProducts = productsSold;
            invoice.InvoiceTax = new InvoiceTax();
            invoice.CalculateTax();
            invoice.InvoiceTax.ShippingValue = 10;
            return invoice;
        }

        public static Invoice IssuedInvoiceValidWithoutShippingCompanyWithAddresseeLegalPerson()
        {
            Invoice invoice = new Invoice();
            invoice.Id = 1;
            invoice.OperationNature = "Venda";
            invoice.EntryDate = DateTime.Now;
            invoice.IssueDate = DateTime.Now;
            invoice.AcessKey = "BAJDSA0123IU43I249206954";
            invoice.Issuer = IssuerValidWithoutIdAndWithAddress();
            invoice.Addressee = AddresseePessoaJuridicaValida(AddressValid());
            invoice.ShippingCompany = null;
            List<SoldProduct> productsSold = new List<SoldProduct>();
            for (int i = 0; i < 20; i++)
            {
                SoldProduct soldProduct = SoldProductValidWithoutId();
                soldProduct.Product.Code = i.ToString();
                productsSold.Add(soldProduct);
            }
            invoice.SoldProducts = productsSold;
            invoice.InvoiceTax = new InvoiceTax();
            invoice.CalculateTax();
            invoice.InvoiceTax.ShippingValue = 10;
            return invoice;
        }

        public static Invoice IssuedInvoiceFullToExport()
        {
            var product = ProductValidWithId();
            product.Tax = new ProductTax { IcmsAliquot = 10, IpiValue = 0.16, IcmsValue = 0.4, IpiAliquot = 4, Id = 1 };
            return new Invoice
            {
                AcessKey = "BAJDSA0123IU43I249206954",
                IssueDate = DateTime.Now,
                EntryDate = DateTime.Now,
                Id = 1,
                OperationNature = "venda",
                Addressee = AddresseeValidComCnpjWithIdWithAddress(),
                Issuer = IssuerValidWithIdAndWithAddress(),
                ShippingCompany = ShippingCompanyValidWithIdWithAddress(),
                SoldProducts = new List<SoldProduct> { SoldProductFull(product) },
                InvoiceTax = new InvoiceTax
                {
                    ShippingValue = 20,
                    Id = 1,
                    InvoiceIcmsValue = 0.4,
                    ProductAmount = 4.56,
                    InvoiceIpiValue = 0.16,
                    InvoiceAmount = 24.56
                }
            };
        }
        #endregion

        #region Tax Product
        public static ProductTax ValidProductTax()
        {
            return new ProductTax
            {
                Id = 1,
                IcmsAliquot = 4,
                IpiAliquot = 10
            };
        }
        #endregion
    }
}
