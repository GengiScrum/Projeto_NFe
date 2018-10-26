using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Utils;
using Projeto_NFe.Infra.XML.Base;
using Projeto_NFe.Infra.XML.Features.Addressees;
using Projeto_NFe.Infra.XML.Features.Issuers;
using Projeto_NFe.Infra.XML.Features.Addresses;
using Projeto_NFe.Infra.XML.Features.InvoiceTaxes;
using Projeto_NFe.Infra.XML.Features.ProductTaxes;
using Projeto_NFe.Infra.XML.Features.Invoices;
using Projeto_NFe.Infra.XML.Features.SoldProducts;
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
                        Name = (invoiceEmitida.Addressee.PersonType == EnumPersonType.PessoaFisica) ? invoiceEmitida.Addressee.BusinessName : invoiceEmitida.Addressee.CorporateName,
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
                            ShippingValue = invoiceEmitida.InvoiceTax.ShippingValue,
                            IcmsValue = invoiceEmitida.InvoiceTax.InvoiceIcmsValue,
                            IpiValue = invoiceEmitida.InvoiceTax.InvoiceIpiValue,
                            ValueProducts = invoiceEmitida.InvoiceTax.ProductAmount,
                            InvoiceAmount = invoiceEmitida.InvoiceTax.InvoiceAmount
                        }
                    }
                }
            };
        }

        private List<SoldProductsModel> preparaListaProductsSold(Invoice nf)
        {
            var listaDeProductDaNota = nf.SoldProducts.ToArray();
            List<SoldProductsModel> listaFinal = new List<SoldProductsModel>();
            for (int x = 0; x < listaDeProductDaNota.Count(); x++)
            {
                SoldProductsModel modelo = new SoldProductsModel
                {
                    nItemNumber = x + 1,
                    Tax = new TaxModel
                    {
                        Icms = new IcmsModel
                        {
                            IcmsProduct = new IcmsProductModel
                            {
                                IcmsAliquota = listaDeProductDaNota[x].Product.Tax.IcmsAliquot,
                                IcmsAmount = listaDeProductDaNota[x].Product.Tax.IcmsValue
                            }
                        }
                    },
                    Prod = new SoldProductModel
                    {
                        CodeProduct = listaDeProductDaNota[x].Product.Code,
                        DescriptionProduct = listaDeProductDaNota[x].Product.Description,
                        Quantity = listaDeProductDaNota[x].Quantity,
                        Amount = listaDeProductDaNota[x].Amount,
                        UnitaryValue = listaDeProductDaNota[x].Product.UnitaryValue
                    }
                };
                listaFinal.Add(modelo);
            }
            return listaFinal;
        }

        public void Export(Invoice invoice, string file)
        {
            using (StreamWriter sw = File.CreateText(file))
            {
                sw.Write(PrepararInvoiceToExportacao(invoice).Serialize());
            }
        }
    }
}
