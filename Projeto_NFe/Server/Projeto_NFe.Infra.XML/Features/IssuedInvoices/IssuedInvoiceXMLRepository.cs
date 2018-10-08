using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.IssuedInvoices;
using Projeto_NFe.Domain.Utils;
using Projeto_NFe.Infra.XML.Base;
using Projeto_NFe.Infra.XML.Features.Addressees;
using Projeto_NFe.Infra.XML.Features.Issuers;
using Projeto_NFe.Infra.XML.Features.Addresses;
using Projeto_NFe.Infra.XML.Features.InvoiceTaxes;
using Projeto_NFe.Infra.XML.Features.ProductTaxes;
using Projeto_NFe.Infra.XML.Features.Invoices;
using Projeto_NFe.Infra.XML.Features.ProductsSold;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.XML.Features.IssuedInvoices
{
    public class IssuedInvoiceXMLRepository : IIssuedInvoiceXMLRepository
    {
        private InvoiceXmlModel PrepararInvoiceToExportacao(Invoice invoiceEmitida)
        {
            return new InvoiceXmlModel
            {
                infNFe = new InfNFeModel
                {
                    AcessKey = invoiceEmitida.AcessKey,
                    Versao = "1.0",
                    emit = new IssuerModel
                    {
                        CnpjIssuer = invoiceEmitida.Issuer.Cnpj,
                        StateRegistration = invoiceEmitida.Issuer.StateRegistration,
                        MunicipalRegistration = invoiceEmitida.Issuer.MunicipalRegistration,
                        Name = invoiceEmitida.Issuer.BusinessName,
                        CorporateName = invoiceEmitida.Issuer.CorporateName,
                        enderEmit = new AddressModel
                        {
                            Neighborhood = invoiceEmitida.Issuer.Address.Neighborhood,
                            State = invoiceEmitida.Issuer.Address.State,
                            City = invoiceEmitida.Issuer.Address.City,
                            Number = invoiceEmitida.Issuer.Address.Number,
                            Country = invoiceEmitida.Issuer.Address.Country,
                            StreetName = invoiceEmitida.Issuer.Address.StreetName
                        }
                    },
                    dest = new AddresseeModel
                    {
                        CnpjAddressee = invoiceEmitida.Addressee.Cnpj,
                        CpfAddressee = invoiceEmitida.Addressee.Cpf,
                        StateRegistration = invoiceEmitida.Addressee.StateRegistration,
                        Name = (invoiceEmitida.Addressee.PersonType == EnumPersonType.PessoaFisica) ? invoiceEmitida.Addressee.Name : invoiceEmitida.Addressee.CorporateName,
                        enderDest = new AddressModel
                        {
                            Neighborhood = invoiceEmitida.Addressee.Address.Neighborhood,
                            State = invoiceEmitida.Addressee.Address.State,
                            City = invoiceEmitida.Addressee.Address.City,
                            Number = invoiceEmitida.Addressee.Address.Number,
                            Country = invoiceEmitida.Addressee.Address.Country,
                            StreetName = invoiceEmitida.Addressee.Address.StreetName
                        }
                    },
                    det = preparaListaProductsSold(invoiceEmitida),
                    ide = new IdeModel
                    {
                        IssueDate = invoiceEmitida.IssueDate,
                        OperationNature = invoiceEmitida.OperationNature
                    },
                    total = new InvoiceAmountModel
                    {
                        ICMSTot = new InvoiceTaxModel
                        {
                            ShippingValue = invoiceEmitida.Tax.ShippingValue,
                            IcmsValue = invoiceEmitida.Tax.InvoiceIcmsValue,
                            IpiValue = invoiceEmitida.Tax.InvoiceIpiValue,
                            ValueProducts = invoiceEmitida.Tax.ProductAmount,
                            InvoiceAmount = invoiceEmitida.Tax.InvoiceAmount
                        }
                    }
                }
            };
        }

        private List<ProductsSoldModel> preparaListaProductsSold(Invoice nf)
        {
            var listaDeProductDaNota = nf.Products.ToArray();
            List<ProductsSoldModel> listaFinal = new List<ProductsSoldModel>();
            for (int x = 0; x < listaDeProductDaNota.Count(); x++)
            {
                ProductsSoldModel modelo = new ProductsSoldModel
                {
                    nItemNumber = x + 1,
                    Tax = new TaxModel
                    {
                        Icms = new IcmsModel
                        {
                            IcmsProduct = new IcmsProductModel
                            {
                                IcmsAliquota = listaDeProductDaNota[x].Tax.IcmsAliquot,
                                IcmsAmount = listaDeProductDaNota[x].Tax.IcmsValue
                            }
                        }
                    },
                    Prod = new ProductSoldModel
                    {
                        CodeProduct = listaDeProductDaNota[x].Code,
                        DescriptionProduct = listaDeProductDaNota[x].Description,
                        Quantity = listaDeProductDaNota[x].Quantity,
                        Amount = listaDeProductDaNota[x].Amount,
                        UnitaryValue = listaDeProductDaNota[x].UnitaryValue
                    }
                };
                listaFinal.Add(modelo);
            }
            return listaFinal;
        }

        public void Export(Invoice invoice, string file)
        {
            invoice.Validate();
            using (StreamWriter sw = File.CreateText(file))
            {
                sw.Write(PrepararInvoiceToExportacao(invoice).Serialize());
            }
        }
    }
}
