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
using Projeto_NFe.Domain.Features.ProductsSold;

namespace Projeto_NFe.Common.Tests
{
    public static partial class ObjectMother
    {
        #region Issuer
        public static Issuer IssuerValidWithoutIdAndWithoutAddress()
        {
            Issuer issuer = new Issuer();
            issuer.BusinessName = "NDDIGITAL";
            issuer.CorporateName = "NDDIGITAL S/A - SOFTWARE";
            issuer.Cnpj = "12.345.678/0009-09";
            issuer.StateRegistration = "12.234.5678-9";
            issuer.MunicipalRegistration = "1234";
            return issuer;
        }

        public static IssuerRegisterCommand IssuerCommandToRegister()
        {
            IssuerRegisterCommand issuer = new IssuerRegisterCommand();
            issuer.BusinessName = "NDDIGITAL";
            issuer.CorporateName = "NDDIGITAL S/A - SOFTWARE";
            issuer.Cnpj = "12.345.678/0009-09";
            issuer.StateRegistration = "12.234.5678-9";
            issuer.MunicipalRegistration = "1234";
            issuer.StreetName = "Rua Avenida";
            issuer.Number = 400;
            issuer.Neighborhood = "Coral";
            issuer.City = "Lages";
            issuer.State = "SC";
            issuer.Country = "Brasil";
            return issuer;
        }

        public static Issuer IssuerValidWithIdEWithoutAddress()
        {
            Issuer issuer = new Issuer();
            issuer.Id = 1;
            issuer.BusinessName = "NDDIGITAL";
            issuer.CorporateName = "NDDIGITAL S/A - SOFTWARE";
            issuer.Cnpj = "12.345.678/0009-09";
            issuer.StateRegistration = "12.234.5678-9";
            issuer.MunicipalRegistration = "1234";
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
            issuer.StreetName = "Rua Avenida";
            issuer.Number = 400;
            issuer.Neighborhood = "Coral";
            issuer.City = "Lages";
            issuer.State = "SC";
            issuer.Country = "Brasil";
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

        public static Issuer IssuerBusinessNameInvalid()
        {
            Issuer issuer = new Issuer();
            issuer.BusinessName = "ND";
            issuer.CorporateName = "NDDIGITAL S/A - SOFTWARE";
            issuer.Cnpj = "12.345.678/0009-09";
            issuer.StateRegistration = "12.234.5678-9";
            issuer.MunicipalRegistration = "1234";
            return issuer;
        }

        public static Issuer IssuerCorporateNameInvalid()
        {
            Issuer issuer = new Issuer();
            issuer.BusinessName = "NDDIGITAL";
            issuer.CorporateName = "ND";
            issuer.Cnpj = "12.345.678/0009-09";
            issuer.StateRegistration = "12.234.5678-9";
            issuer.MunicipalRegistration = "1234";
            return issuer;
        }

        public static Issuer IssuerCnpjInvalid()
        {
            Issuer issuer = new Issuer();
            issuer.BusinessName = "NDDIGITAL";
            issuer.CorporateName = "NDDIGITAL S/A - SOFTWARE";
            issuer.Cnpj = "12.345.678/0009";
            issuer.StateRegistration = "12.234.5678-9";
            issuer.MunicipalRegistration = "1234";
            return issuer;
        }

        public static Issuer IssuerStateRegistrationInvalid()
        {
            Issuer issuer = new Issuer();
            issuer.BusinessName = "NDDIGITAL";
            issuer.CorporateName = "NDDIGITAL S/A - SOFTWARE";
            issuer.Cnpj = "12.345.678/0009-09";
            issuer.StateRegistration = "12";
            issuer.MunicipalRegistration = "1234";
            return issuer;
        }

        public static Issuer IssuerMunicipalRegistrationInvalid()
        {
            Issuer issuer = new Issuer();
            issuer.BusinessName = "NDDIGITAL";
            issuer.CorporateName = "NDDIGITAL S/A - SOFTWARE";
            issuer.Cnpj = "12.345.678/0009-09";
            issuer.StateRegistration = "12.234.5678-9";
            issuer.MunicipalRegistration = "14";
            return issuer;
        }

        #endregion

        #region Address

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

        public static Address AddressStreetNameInvalid()
        {
            Address address = new Address();
            address.StreetName = "Ru";
            address.Number = 400;
            address.Neighborhood = "Coral";
            address.City = "Lages";
            address.State = "SC";
            address.Country = "Brasil";
            return address;
        }

        public static Address AddressNumberInvalid()
        {
            Address address = new Address();
            address.StreetName = "Rua Avenida";
            address.Number = 0;
            address.Neighborhood = "Coral";
            address.City = "Lages";
            address.State = "SC";
            address.Country = "Brasil";
            return address;
        }

        public static Address AddressNeighborhoodInvalid()
        {
            Address address = new Address();
            address.StreetName = "Rua Avenida";
            address.Number = 400;
            address.Neighborhood = "Co";
            address.City = "Lages";
            address.State = "SC";
            address.Country = "Brasil";
            return address;
        }

        public static Address AddressCityInvalid()
        {
            Address address = new Address();
            address.StreetName = "Rua Avenida";
            address.Number = 400;
            address.Neighborhood = "Coral";
            address.City = "L";
            address.State = "SC";
            address.Country = "Brasil";
            return address;
        }

        public static Address AddressStateInvalid()
        {
            Address address = new Address();
            address.StreetName = "Rua Avenida";
            address.Number = 400;
            address.Neighborhood = "Coral";
            address.City = "Lages";
            address.State = "S";
            address.Country = "Brasil";
            return address;
        }

        public static Address AddressCountryInvalid()
        {
            Address address = new Address();
            address.StreetName = "Rua Avenida";
            address.Number = 400;
            address.Neighborhood = "Coral";
            address.City = "Lages";
            address.State = "SC";
            address.Country = "B";
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
            shippingCompany.StreetName = "Rua Avenida";
            shippingCompany.Number = 400;
            shippingCompany.Neighborhood = "Coral";
            shippingCompany.City = "Lages";
            shippingCompany.State = "SC";
            shippingCompany.Country = "Brasil";
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
            shippingCompany.StreetName = "Rua Avenida";
            shippingCompany.Number = 400;
            shippingCompany.Neighborhood = "Coral";
            shippingCompany.City = "Lages";
            shippingCompany.State = "SC";
            shippingCompany.Country = "Brasil";
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
            AddresseeRegisterCommand adressee = new AddresseeRegisterCommand();
            adressee.BusinessName = "NDDIGITAL";
            adressee.CorporateName = "NDDIGITAL S/A - SOFTWARE";
            adressee.Cnpj = "12.345.678/0009-09";
            adressee.StateRegistration = "12.234.5678-9";
            adressee.StreetName = "Rua Avenida";
            adressee.Number = 400;
            adressee.Neighborhood = "Coral";
            adressee.City = "Lages";
            adressee.State = "SC";
            adressee.Country = "Brasil";
            return adressee;
        }

        public static AddresseeUpdateCommand AddresseeCommandToUpdate()
        {
            AddresseeUpdateCommand addressee = new AddresseeUpdateCommand();
            addressee.Id = 1;
            addressee.BusinessName = "NDDIGITAL";
            addressee.CorporateName = "NDDIGITAL S/A - SOFTWARE";
            addressee.Cnpj = "12.345.678/0009-09";
            addressee.StateRegistration = "12.234.5678-9";
            addressee.StreetName = "Rua Avenida";
            addressee.Number = 400;
            addressee.Neighborhood = "Coral";
            addressee.City = "Lages";
            addressee.State = "SC";
            addressee.Country = "Brasil";
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

        public static Addressee AddresseePessoaFisicaComNameInvalid(Address address)
        {
            return new Addressee
            {
                Id = 1,
                BusinessName = "Let",
                Address = address,
                Cpf = "12345678901",
                PersonType = EnumPersonType.PessoaFisica
            };
        }

        public static Addressee AddresseePessoaFisicaComNameMaxCaracteres(Address address)
        {
            return new Addressee
            {
                Id = 1,
                BusinessName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Address = address,
                Cpf = "12345678901",
                PersonType = EnumPersonType.PessoaFisica
            };
        }

        public static Addressee AddresseePessoaFisicaWithIdInvalid(Address address)
        {
            return new Addressee
            {
                BusinessName = "Leticia",
                Address = address,
                Cpf = "12345678901",
                PersonType = EnumPersonType.PessoaFisica
            };
        }

        public static Addressee AddresseePessoaFisicaComCpfInvalid(Address address)
        {
            return new Addressee
            {
                Id = 1,
                BusinessName = "Letícia",
                Address = address,
                Cpf = "1234567",
                PersonType = EnumPersonType.PessoaFisica
            };
        }

        public static Addressee AddresseePessoaFisicaComCpfComCaractereInvalid(Address address)
        {
            return new Addressee
            {
                Id = 1,
                BusinessName = "Letícia",
                Address = address,
                Cpf = "123vfd456gyh90",
                PersonType = EnumPersonType.PessoaFisica
            };
        }

        public static Addressee AddresseePessoaFisicaWithAddressInvalid()
        {
            return new Addressee
            {
                Id = 1,
                BusinessName = "Letícia",
                Cpf = "12345678901",
                PersonType = EnumPersonType.PessoaFisica
            };
        }

        public static Addressee AddresseePessoaFisicaComCnpj(Address address)
        {
            return new Addressee
            {
                Id = 1,
                BusinessName = "Letícia",
                Address = address,
                Cpf = "12345678901",
                Cnpj = "12345678901234",
                PersonType = EnumPersonType.PessoaFisica
            };
        }

        public static Addressee AddresseePessoaFisicaComCorporateName(Address address)
        {
            return new Addressee
            {
                Id = 1,
                BusinessName = "Letícia",
                CorporateName = "Empresa Ltda",
                Address = address,
                Cpf = "12345678901",
                PersonType = EnumPersonType.PessoaFisica,
            };
        }

        public static Addressee AddresseePessoaFisicaComStateRegistration(Address address)
        {
            return new Addressee
            {
                Id = 1,
                BusinessName = "Letícia",
                Address = address,
                StateRegistration = "123435235235324",
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

        public static Addressee AddresseePessoaJuridicaWithIdInvalid(Address address)
        {
            return new Addressee
            {
                BusinessName = "Name",
                CorporateName = "Letícia Ltda",
                StateRegistration = "128398213791",
                Address = address,
                Cnpj = "12345678901234",
                PersonType = EnumPersonType.PessoaJuridica
            };
        }

        public static Addressee AddresseePessoaJuridicaComCorporateNameInvalid(Address address)
        {
            return new Addressee
            {
                Id = 1,
                BusinessName = "Name",
                CorporateName = "Le",
                StateRegistration = "128398213791",
                Address = address,
                Cnpj = "12345678901234",
                PersonType = EnumPersonType.PessoaJuridica,
            };
        }

        public static Addressee AddresseePessoaJuridicaComCorporateNameMaxCaracteres(Address address)
        {
            return new Addressee
            {
                Id = 1,
                BusinessName = "Name",
                CorporateName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                StateRegistration = "128398213791",
                Address = address,
                Cnpj = "12345678901234",
                PersonType = EnumPersonType.PessoaJuridica,
            };
        }

        public static Addressee AddresseePessoaJuridicaAddressInvalid()
        {
            return new Addressee
            {
                Id = 1,
                BusinessName = "Name",
                CorporateName = "Letícia Ltda",
                StateRegistration = "128398213791",
                Cnpj = "12345678901234",
                PersonType = EnumPersonType.PessoaJuridica
            };
        }

        public static Addressee AddresseePessoaJuridicaComCnpjInvalid(Address address)
        {
            return new Addressee
            {
                Id = 1,
                BusinessName = "Name",
                CorporateName = "Leticia Ltda",
                StateRegistration = "128398213791",
                Address = address,
                Cnpj = "123456",
                PersonType = EnumPersonType.PessoaJuridica
            };
        }

        public static Addressee AddresseePessoaJuridicaComCnpjComCaractereInvalid(Address address)
        {
            return new Addressee
            {
                Id = 1,
                BusinessName = "Name",
                CorporateName = "Leticia Ltda",
                StateRegistration = "128398213791",
                Address = address,
                Cnpj = "123456ndj38nsk",
                PersonType = EnumPersonType.PessoaJuridica
            };
        }

        public static Addressee AddresseePessoaJuridicaComStateRegistrationInvalid(Address address)
        {
            return new Addressee
            {
                Id = 1,
                BusinessName = "Name",
                CorporateName = "Letícia Ltda",
                Address = address,
                Cnpj = "12345678901234",
                PersonType = EnumPersonType.PessoaJuridica
            };
        }

        public static Addressee AddresseePessoaJuridicaComCpf(Address address)
        {
            return new Addressee
            {
                Id = 1,
                BusinessName = "Name",
                CorporateName = "Letícia Ltda",
                StateRegistration = "128398213791",
                Address = address,
                Cnpj = "12345678901234",
                Cpf = "12345678901",
                PersonType = EnumPersonType.PessoaJuridica
            };
        }

        public static Addressee AddresseePessoaJuridicaComName(Address address)
        {
            return new Addressee
            {
                Id = 1,
                CorporateName = "Letícia Ltda",
                BusinessName = "Leticia",
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

        public static Product ProductCodeInvalidWithoutId()
        {
            Product product = new Product();

            product.Code = "";
            product.Description = "Bolacha Negresco";
            product.UnitaryValue = 2.00;

            return product;
        }

        public static Product ProductDescriptionInvalidWithoutId()
        {
            Product product = new Product();

            product.Code = "1A12312BC123";
            product.Description = "";
            product.UnitaryValue = 2.00;

            return product;
        }

        public static Product ProductUnitaryValueInvalidWithoutId()
        {
            Product product = new Product();

            product.Code = "1A12312BC123";
            product.Description = "Bolacha Negresco";
            product.UnitaryValue = 0;

            return product;
        }

        public static Product ProductCodeInvalidWithId()
        {
            Product product = new Product();

            product.Id = 1;
            product.Code = "";
            product.Description = "Bolacha Negresco";
            product.UnitaryValue = 2.00;

            return product;
        }

        public static Product ProductDescriptionInvalidWithId()
        {
            Product product = new Product();

            product.Id = 1;
            product.Code = "1A12312BC123";
            product.Description = "";
            product.UnitaryValue = 2.00;

            return product;
        }

        public static Product ProductUnitaryValueInvalidWithId()
        {
            Product product = new Product();

            product.Id = 1;
            product.Code = "1A12312BC123";
            product.Description = "Bolacha Negresco";
            product.UnitaryValue = 0;

            return product;
        }
        #endregion

        #region ProductSold
        public static ProductSold ProductSoldValidWithoutId()
        {
            ProductSold productSold = new ProductSold();

            productSold.Code = "24398012984";
            productSold.Description = "Bolacha";
            productSold.Tax = new ProductTax() { IcmsAliquot = 4, IpiAliquot = 10 };
            productSold.Quantity = 2;
            productSold.UnitaryValue = 2;

            return productSold;
        }

        public static ProductSold ProductSoldValidWithId()
        {
            ProductSold productSold = new ProductSold();

            productSold.Id = 1;
            productSold.Tax = new ProductTax();
            productSold.Quantity = 2;
            productSold.UnitaryValue = 2;

            return productSold;
        }

        public static ProductSold ProductSoldFull(ProductTax tax)
        {
            return new ProductSold
            {
                Id = 1,
                Code = "123132",
                Description = "descricao",
                IdProductSold = 1,
                Tax = tax,
                Quantity = 2,
                UnitaryValue = 25
            };
        }

        public static ProductSold ProductSoldQuantityInvalid(ProductTax tax)
        {
            return new ProductSold
            {
                Id = 1,
                Code = "123132",
                Description = "descricao",
                IdProductSold = 1,
                Tax = tax,
                Quantity = 0,
                UnitaryValue = 25
            };
        }

        #endregion

        #region Invoice
        public static Invoice InvoiceWithoutIdNeedMock()
        {
            Invoice invoice = new Invoice();
            invoice.OperationNature = "Venda";
            invoice.EntryDate = DateTime.Now;
            invoice.AcessKey = "BAJDSA0123IU43I249206954";
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
            invoice.Products = new List<ProductSold>() { ProductSoldValidWithoutId() };
            invoice.Tax = new InvoiceTax();
            return invoice;
        }

        public static Invoice InvoiceValidaWithIdAndIssuerAddresseeShippingCompanyId()
        {
            Invoice invoice = new Invoice();
            invoice.Id = 1;
            invoice.OperationNature = "Venda";
            invoice.EntryDate = DateTime.Now;
            invoice.AcessKey = "BAJDSA0123IU43I249206954";
            invoice.Issuer = IssuerValidWithIdAndWithAddress();
            invoice.Addressee = AddresseeValidWithIdWithAddress();
            invoice.ShippingCompany = ShippingCompanyValidWithIdWithAddress();
            invoice.Products = new List<ProductSold>() { ProductSoldValidWithoutId() };
            return invoice;
        }

        public static Invoice InvoiceValidWithoutIdWithIssuerAddresseeShippingCompanyId()
        {
            Invoice invoice = new Invoice();
            invoice.OperationNature = "Venda";
            invoice.EntryDate = DateTime.Now;
            invoice.AcessKey = "BAJDSA0123IU43I249206954";
            invoice.Issuer = IssuerValidWithIdAndWithAddress();
            invoice.Addressee = AddresseeValidWithIdWithAddress();
            invoice.ShippingCompany = ShippingCompanyValidWithIdWithAddress();
            invoice.Products = new List<ProductSold>() { ProductSoldValidWithId() };
            return invoice;
        }

        public static Invoice InvoiceFull(Addressee addressee, Issuer issuer, InvoiceTax tax, ShippingCompany shippingCompany)
        {
            return new Invoice
            {
                EntryDate = DateTime.Now,
                Addressee = addressee,
                Issuer = issuer,
                Tax = tax,
                OperationNature = "Venda",
                Products = new List<ProductSold> { ProductSoldValidWithId() },
                ShippingCompany = shippingCompany
            };
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
            invoice.Products = new List<ProductSold>() { ProductSoldValidWithoutId() };
            invoice.Tax = new InvoiceTax();
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
            invoice.Products = new List<ProductSold>() { ProductSoldValidWithoutId() };
            invoice.Tax = new InvoiceTax();
            invoice.CalculateTax();
            invoice.Tax.ShippingValue = 10;
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
            List<ProductSold> productsSold = new List<ProductSold>();
            for (int i = 0; i < 20; i++)
            {
                ProductSold productSold = ProductSoldValidWithoutId();
                productSold.Code = i.ToString();
                productsSold.Add(productSold);
            }
            invoice.Products = productsSold;
            invoice.Tax = new InvoiceTax();
            invoice.CalculateTax();
            invoice.Tax.ShippingValue = 10;
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
            List<ProductSold> productsSold = new List<ProductSold>();
            for (int i = 0; i < 20; i++)
            {
                ProductSold productSold = ProductSoldValidWithoutId();
                productSold.Code = i.ToString();
                productsSold.Add(productSold);
            }
            invoice.Products = productsSold;
            invoice.Tax = new InvoiceTax();
            invoice.CalculateTax();
            invoice.Tax.ShippingValue = 10;
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
            List<ProductSold> productsSold = new List<ProductSold>();
            for (int i = 0; i < 20; i++)
            {
                ProductSold productSold = ProductSoldValidWithoutId();
                productSold.Code = i.ToString();
                productsSold.Add(productSold);
            }
            invoice.Products = productsSold;
            invoice.Tax = new InvoiceTax();
            invoice.CalculateTax();
            invoice.Tax.ShippingValue = 10;
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
            List<ProductSold> productsSold = new List<ProductSold>();
            for (int i = 0; i < 20; i++)
            {
                ProductSold productSold = ProductSoldValidWithoutId();
                productSold.Code = i.ToString();
                productsSold.Add(productSold);
            }
            invoice.Products = productsSold;
            invoice.Tax = new InvoiceTax();
            invoice.CalculateTax();
            invoice.Tax.ShippingValue = 10;
            return invoice;
        }

        public static Invoice IssuedInvoiceFullToExport()
        {
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
                Products = new List<ProductSold> { ProductSoldFull(new ProductTax { IcmsAliquot = 10, IpiValue = 0.16, IcmsValue = 0.4, IpiAliquot = 4, Id = 1 }) },
                Tax = new InvoiceTax
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

        public static Invoice IssuedInvoiceWithoutAcessKey()
        {
            Invoice invoice = new Invoice();
            invoice.OperationNature = "Venda";
            invoice.EntryDate = DateTime.Now;
            invoice.Issuer = IssuerValidWithoutIdAndWithAddress();
            invoice.Addressee = AddresseeValidWithoutIdWithAddress();
            invoice.ShippingCompany = ShippingCompanyValidWithoutIdWithAddress();
            invoice.Products = new List<ProductSold>() { ProductSoldValidWithoutId() };
            invoice.Tax = new InvoiceTax();
            return invoice;
        }

        public static Invoice IssuedInvoiceWithoutIdWithoutIssuer()
        {
            Invoice invoice = new Invoice();
            invoice.OperationNature = "Venda";
            invoice.EntryDate = DateTime.Now;
            invoice.AcessKey = "BAJDSA0123IU43I249206954";
            invoice.Addressee = AddresseeValidWithoutIdWithAddress();
            invoice.ShippingCompany = ShippingCompanyValidWithoutIdWithAddress();
            invoice.Products = new List<ProductSold>() { ProductSoldValidWithoutId() };
            invoice.Tax = new InvoiceTax();
            return invoice;
        }

        public static Invoice IssuedInvoiceWithoutIdWithoutShippingCompany()
        {
            Invoice invoice = new Invoice();
            invoice.OperationNature = "Venda";
            invoice.EntryDate = DateTime.Now;
            invoice.AcessKey = "BAJDSA0123IU43I249206954";
            invoice.Issuer = IssuerValidWithoutIdAndWithAddress();
            invoice.Addressee = AddresseeValidWithoutIdWithAddress();
            invoice.Products = new List<ProductSold>() { ProductSoldValidWithoutId() };
            invoice.Tax = new InvoiceTax();
            return invoice;
        }

        public static Invoice IssuedInvoiceWithoutIdWithoutAddressee()
        {
            Invoice invoice = new Invoice();
            invoice.OperationNature = "Venda";
            invoice.EntryDate = DateTime.Now;
            invoice.AcessKey = "BAJDSA0123IU43I249206954";
            invoice.Issuer = IssuerValidWithoutIdAndWithAddress();
            invoice.ShippingCompany = ShippingCompanyValidWithoutIdWithAddress();
            invoice.Products = new List<ProductSold>() { ProductSoldValidWithoutId() };
            invoice.Tax = new InvoiceTax();
            return invoice;
        }

        public static Invoice IssuedInvoiceWithoutIdOperationNatureInvalid()
        {
            Invoice invoice = new Invoice();
            invoice.EntryDate = DateTime.Now;
            invoice.AcessKey = "BAJDSA0123IU43I249206954";
            invoice.Issuer = IssuerValidWithoutIdAndWithAddress();
            invoice.Addressee = AddresseeValidWithoutIdWithAddress();
            invoice.ShippingCompany = ShippingCompanyValidWithoutIdWithAddress();
            invoice.Products = new List<ProductSold>() { ProductSoldValidWithoutId() };
            invoice.Tax = new InvoiceTax();
            return invoice;
        }

        public static Invoice IssuedInvoiceWithoutIdEntryDateInvalid()
        {
            Invoice invoice = new Invoice();
            invoice.OperationNature = "Venda";
            invoice.EntryDate = new DateTime();
            invoice.AcessKey = "BAJDSA0123IU43I249206954";
            invoice.IssueDate = DateTime.Now;
            invoice.Issuer = IssuerValidWithoutIdAndWithAddress();
            invoice.Addressee = AddresseeValidWithoutIdWithAddress();
            invoice.ShippingCompany = ShippingCompanyValidWithoutIdWithAddress();
            invoice.Products = new List<ProductSold>() { ProductSoldValidWithoutId() };
            invoice.Tax = new InvoiceTax();
            return invoice;
        }

        public static Invoice IssuedInvoiceWithoutIdWithoutProducts()
        {
            Invoice invoice = new Invoice();
            invoice.OperationNature = "Venda";
            invoice.EntryDate = DateTime.Now;
            invoice.AcessKey = "BAJDSA0123IU43I249206954";
            invoice.Issuer = IssuerValidWithoutIdAndWithAddress();
            invoice.Addressee = AddresseeValidWithoutIdWithAddress();
            invoice.ShippingCompany = ShippingCompanyValidWithoutIdWithAddress();
            invoice.Products = new List<ProductSold>();
            invoice.Tax = new InvoiceTax();
            return invoice;
        }

        public static Invoice IssuedInvoiceWithoutIdComIssuerIgualAddressee()
        {
            Invoice invoice = new Invoice();
            invoice.OperationNature = "Venda";
            invoice.EntryDate = DateTime.Now;
            invoice.AcessKey = "BAJDSA0123IU43I249206954";
            invoice.Issuer = IssuerValidWithoutIdAndWithAddress();
            invoice.Issuer.BusinessName = "Bruno Barba";
            invoice.Addressee = AddresseeValidWithoutIdWithAddress();
            invoice.ShippingCompany = ShippingCompanyValidWithoutIdWithAddress();
            invoice.Products = new List<ProductSold>() { ProductSoldValidWithoutId() };
            invoice.Tax = new InvoiceTax();
            return invoice;
        }
        #endregion

        #region Tax Product
        public static ProductTax ProductTaxWithAliquotIcsmAndIpiAliquot()
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
